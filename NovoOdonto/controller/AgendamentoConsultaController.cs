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
        private AgendamentoConsultaForm Form { get; set; } = new AgendamentoConsultaForm();
        private AgendamentoValidador Validador { get; set; } = new AgendamentoValidador();
        protected bool isValid { get; set; }
        public static void Inicia(OdontoDbContext contexto)
        {
            var isValid = false;
            var Form = new AgendamentoConsultaForm();
            var Validador = new AgendamentoValidador();

            // CPF
            do
            {
                Form.SolicitarCPF();
                isValid = Validador.IsValidCPF(Form.Agendamento.CPF);
                //ToDo : Validar se o CPF possui 11 digitos, se é de verdade e por último validar no Banco de Dados

            } while (!isValid);

            // data da consulta
            do
            {
                Form.SolicitarDataConsulta();
                isValid = Validador.IsValidDataConsulta(Form.Agendamento.DataConsulta);
            } while (!isValid);

            //Hora Incio
            do
            {
                Form.SolicitarHoraInicio();
                isValid = Validador.IsValidHoraInicio(Form.Agendamento.HoraInicio);

            } while (!isValid);

            //Hora fim
            do
            {
                Form.SolicitarHoraFim();
                isValid = Validador.IsValidHoraFim(Form.Agendamento.HoraFim);
            } while (!isValid);

            

            var paciente = contexto.Pacientes.Find(Validador.Agendamento.CPF);
            var Agendamento = new Agendamento(paciente, Validador.Agendamento.HoraInicio, Validador.Agendamento.HoraFim, Validador.Agendamento.DataConsulta);
            contexto.Agenda.Add(Agendamento);
            contexto.SaveChanges();
            Console.WriteLine("Agendamento feito com sucesso!@");
        }

    }
}
