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
            var Agendamento = new Agendamento(Validador.Agendamento.DataConsulta, Validador.Agendamento.HoraInicio, Validador.Agendamento.HoraFim, paciente);
            contexto.Agendamentos.Add(Agendamento);
            contexto.SaveChanges();
            Console.WriteLine("Agendamento feito com sucesso!@");
        }

    }
}
