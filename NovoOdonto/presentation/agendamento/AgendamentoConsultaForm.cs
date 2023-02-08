using NovoOdonto.data.dto;
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
        public AgendamentoDTO Agendamento { get; private set; } = new();

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
    }
}
