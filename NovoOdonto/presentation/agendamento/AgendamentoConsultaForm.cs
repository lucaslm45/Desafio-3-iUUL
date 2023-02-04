using NovoOdonto.data.dto;
using NovoOdonto.Infrastructure;
using NovoOdonto.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoOdonto.presentation.agendamento
{
    public class AgendamentoConsultaForm
    {
        public AgendamentoDTO Agendamento { get; private set; }
        public AgendamentoConsultaForm() =>
            Agendamento = new();
        /// <summary>
        /// Solicita um valor de CPF ao usuário.
        /// </summary>
        public void SolicitarCPF()
        {
            Console.Write("CPF: ");
            Agendamento.CPF = Console.ReadLine();
        }
        /// <summary>
        /// Solicita uma data de consulta ao usuário.
        /// </summary>
        public void SolicitarDataConsulta()
        {
            Console.Write("Data da consulta (ddMMaaaa): ");
            Agendamento.DataConsulta = Console.ReadLine();
        }
        /// <summary>
        /// Solicita o horário de início da consulta ao usuário.
        /// </summary>
        public void SolicitarHoraInicio()
        {
            Console.Write("Hora inicial (HHmm): ");
            Agendamento.HoraInicio = Console.ReadLine();
        }
        /// <summary>
        /// Solicita o horário de término da consulta ao usuário.
        /// </summary>
        public void SolicitarHoraFim()
        {
            Console.Write("Hora final (HHmm): ");
            Agendamento.HoraFim = Console.ReadLine();
        }
        public void Process(StatusOperacao status)
        {
            switch (status)
            {
                case StatusOperacao.Sucesso:
                    Console.WriteLine(Labels.Sucesso);
                    break;
                case StatusOperacao.PacienteNaoCadastrado:
                    Console.WriteLine(Labels.PacienteNaoCadastrado);
                    break;
                case StatusOperacao.PacienteJaCadastrado:
                    break;
                case StatusOperacao.DadosInvalidosPaciente:
                    Console.WriteLine(Labels.DadosInvalidosPaciente);
                    break;
                case StatusOperacao.ConsultaAgendada:
                    Console.WriteLine(Labels.ConsultaAgendada);
                    break;
                case StatusOperacao.ConflitoAgendamento:
                    Console.WriteLine(Labels.ConflitoAgendamento);
                    break;
                case StatusOperacao.AgendamentoNaoCadastrado:
                    Console.WriteLine(Labels.AgendamentoNaoCadastrado);
                    break;
            }
        }
    }
}
