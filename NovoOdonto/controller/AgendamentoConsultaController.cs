using System.Runtime.ExceptionServices;
using NovoOdonto.data;
using NovoOdonto.data.dto;
using NovoOdonto.data.validator;
using NovoOdonto.model;
using NovoOdonto.presentation.agendamento;

namespace NovoOdonto.controller
{
    public class AgendamentoConsultaController
    {
        public static void Inicia(OdontoDbContext contexto)
        {
            const int NumeroTentivas = 3;
            bool isValid;
            var Form = new AgendamentoConsultaForm();
            var Validador = new AgendamentoValidador(contexto);

            // CPF
            do
            {
                Form.SolicitarCPF();
                isValid = Validador.IsValidCPF(Form.Agendamento.CPF);

            } while (!isValid);

            isValid = false;

            while (!isValid)
            {
                // Data da Consulta
                do
                {
                    Form.SolicitarDataConsulta();
                    isValid = Validador.IsValidDataConsulta(Form.Agendamento.DataConsulta);
                } while (!isValid);

                Console.WriteLine($"\"Atenção\" Número de tentativas para encontrar um horário de início: {NumeroTentivas}");

                var tentativas = NumeroTentivas;
                //Hora Inicio
                while (tentativas > 0)
                {
                    Form.SolicitarHoraInicio();
                    if (Validador.IsValidHoraInicio(Form.Agendamento.HoraInicio))
                        break;

                    tentativas--;
                }

                // Reinicia a busca solicitando novamente uma data de Consulta
                if (tentativas == 0)
                {
                    Console.WriteLine($"A quantidade de tentativas foi excedida, reinsira a data da consulta.");
                    continue;
                }

                //Hora Fim
                Console.WriteLine($"\"Atenção\" Número de tentativas para encontrar um horário de fim: {NumeroTentivas}");

                tentativas = NumeroTentivas;

                while (tentativas > 0)
                {
                    Form.SolicitarHoraFim();
                    if (Validador.IsValidHoraFim(Form.Agendamento.HoraFim) && Validador.IsAgendamentoDisponivel())
                        break;

                    tentativas--;
                }

                // Reinicia a busca solicitando novamente uma data de Consulta
                if (tentativas == 0)
                {
                    Console.WriteLine($"A quantidade de tentativas foi excedida, reinsira a data da consulta.");
                    continue;
                }
                isValid = true;
            }

            var paciente = contexto.Pacientes.Find(Validador.Agendamento.CPF);
            var Agendamento = new Agendamento(Validador.Agendamento.DataConsulta, Validador.Agendamento.HoraInicio, Validador.Agendamento.HoraFim, paciente);
            contexto.Agendamentos.Add(Agendamento);
            contexto.SaveChanges();

            Console.WriteLine("Agendamento feito com sucesso!\n");
        }

    }
}
