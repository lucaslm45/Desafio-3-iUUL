using System.Runtime.ExceptionServices;
using NovoOdonto.data;
using NovoOdonto.data.dto;
using NovoOdonto.data.validator;
using NovoOdonto.model;
using NovoOdonto.presentation.agendamento;
using NovoOdonto.util;

namespace NovoOdonto.controller
{
    public class AgendamentoConsultaController
    {
        public static void Inicia(OdontoDbContext contexto)
        {
            if (contexto.Pacientes.Any())
            {
                Process(contexto);
            }
            else
                Console.WriteLine("Erro: não há nenhum paciente cadastrado.");
        }
        private static void Process(OdontoDbContext contexto)
        {
            const int NumeroTentivas = 3;
            bool isValid;
            var Form = new AgendamentoConsultaForm();
            var Validador = new AgendamentoValidador(contexto);

            // CPF
            do
            {
                try
                {
                    Form.SolicitarCPF();
                    isValid = Validador.IsValidCPF(Form.Agendamento.CPF) &&
                              Validador.Agendamento.CPF.NaoExisteAgendamentoFuturo(contexto);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }


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
                    {
                        var paciente = contexto.Pacientes.Find(Validador.Agendamento.CPF);
                        var Agendamento = new Agendamento(Validador.Agendamento.DataConsulta, Validador.Agendamento.HoraInicio, Validador.Agendamento.HoraFim, paciente);
                        contexto.Agendamentos.Add(Agendamento);
                        contexto.SaveChanges();

                        Console.WriteLine("Agendamento feito com sucesso!");
                        break;
                    }
                    tentativas--;
                }

                // Reinicia a busca solicitando novamente uma data de Consulta
                if (tentativas == 0)
                {
                    Console.WriteLine($"A quantidade de tentativas foi excedida, reinsira a data da consulta.");
                    isValid = false;
                }
            }
        }
    }
}
