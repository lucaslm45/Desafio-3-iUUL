using Microsoft.EntityFrameworkCore;
using NovoOdonto.data;
using NovoOdonto.data.validator;
using NovoOdonto.presentation.agendamento;
using NovoOdonto.util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoOdonto.controller
{
    public class ConsultarAgendaController
    {
        /// <summary>
        /// Faz a consulta de todos os agendamentos
        /// </summary>
        /// <param name="contexto"></param>
        public static void Inicia(OdontoDbContext contexto)
        {
            MostraAgendamentos(contexto, DateTime.MinValue, DateTime.MaxValue);
        }
        /// <summary>
        /// Faz a consulta de agendamentos de um determinado período
        /// </summary>
        /// <param name="contexto"></param>
        public static void IniciaPorPeriodo(OdontoDbContext contexto)
        {
            bool isValid;
            var Form = new ConsultarAgendaForm();

            // Data da Inicial do Período
            DateTime dataInicial;
            do
            {
                Form.SolicitarDataInicial();
                (isValid, dataInicial) = isValidData(Form.DataInicioPeriodo);

            } while (!isValid);

            // Data da Final do Período
            DateTime dataFinal;
            do
            {
                Form.SolicitarDataFinal();
                (isValid, dataFinal) = isValidData(Form.DataFinalPeriodo);

            } while (!isValid);

            MostraAgendamentos(contexto, dataInicial, dataFinal);
        }
        private static (bool, DateTime) isValidData(string data)
        {
            if (DateTime.TryParseExact(data, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataPeriodo))
                return (true, dataPeriodo);
            else
                Console.WriteLine("Erro: Data deve estar no formato ddMMaaaa");

            return (false, dataPeriodo);

        }
        private static void MostraAgendamentos(OdontoDbContext contexto, DateTime inicioPeriodo, DateTime finalPeriodo)
        {
            var agendamentos = contexto.Agendamentos
                           .Include(a => a.Paciente)
                           .Where(a => a.DataConsulta >= inicioPeriodo.ToUniversalTime() &&
                                  a.DataConsulta <= finalPeriodo.ToUniversalTime());

            if (agendamentos.Any())
            {
                Extensions.CabecalhoListaAgenda();

                foreach (var consulta in agendamentos) { Console.WriteLine(consulta); }

                Extensions.RodapeListaAgenda();
            }
            else
                Console.WriteLine("\nNão há nenhum agendamento no sistema.");
        }
    }
}
