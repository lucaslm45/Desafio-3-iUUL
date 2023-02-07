using NovoOdonto.data.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoOdonto.presentation.agendamento
{
    public class CancelamentoConsultaForm
    {
        public AgendamentoDTO Agendamento { get; set; } = new();

        /// <summary>
        /// Solicita um valor de CPF ao usuário.
        /// </summary>
        public void SolicitarCPF()
        {
            Console.Write("CPF: ");
            Agendamento.CPF = Console.ReadLine();
        }
        /// <summary>
        /// Solicita uma data de consulta para cancelamento.
        /// </summary>
        public void SolicitarDataConsulta()
        {
            Console.Write("Data da consulta (ddMMaaaa): ");
            Agendamento.DataConsulta = Console.ReadLine();
        }
        /// <summary>
        /// Solicita o horário de início para cancelamento.
        /// </summary>
        public void SolicitarHoraInicio()
        {
            Console.Write("Hora inicial (HHmm): ");
            Agendamento.HoraInicio = Console.ReadLine();
        }
    }
}
