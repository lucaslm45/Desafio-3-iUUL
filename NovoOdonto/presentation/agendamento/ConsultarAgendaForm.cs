using NovoOdonto.data.dto;
using NovoOdonto.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoOdonto.presentation.agendamento
{
    public class ConsultarAgendaForm
    {
        public string DataInicioPeriodo { get; set; }
        public string DataFinalPeriodo { get; set; }

        /// <summary>
        /// Solicita a data de início do período ao usuário.
        /// </summary>
        public void SolicitarDataInicial()
        {
            Console.Write("Data inicial (ddMMaaaa): ");
            DataInicioPeriodo = Console.ReadLine();
        }

        /// <summary>
        /// Solicita a data de início do período ao usuário.
        /// </summary>
        public void SolicitarDataFinal()
        {
            Console.Write("Data final (ddMMaaaa): ");
            DataFinalPeriodo = Console.ReadLine();
        }
    }
}
