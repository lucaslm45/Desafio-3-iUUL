using Microsoft.EntityFrameworkCore;
using NovoOdonto.data;
using NovoOdonto.util;

namespace NovoOdonto.controller
{
    public class ConsultarPacientesController
    {
        /// <summary>
        /// Imprime no console a lista de pacientes em ordem crescente com base no número de CPF
        /// </summary>
        /// <param name="contexto"></param>
        public static void ListarPorCPF(OdontoDbContext contexto)
        {
            Extensions.CabecalhoListaPacientes();

            var pacientes = contexto.Pacientes.Include(p => p.Agendamentos).OrderBy(p => p.CPF);

            foreach (var paciente in pacientes) Console.WriteLine(paciente);

            Extensions.RodapeListaPacientes();
        }
        /// <summary>
        /// Imprime no console a lista de pacientes em ordem alfabética com base no Nome
        /// </summary>
        /// <param name="contexto"></param>
        public static void ListarPorNome(OdontoDbContext contexto)
        {
            Extensions.CabecalhoListaPacientes();

            var pacientes = contexto.Pacientes.Include(p => p.Agendamentos).OrderBy(p => p.Nome);

            foreach (var paciente in pacientes) Console.WriteLine(paciente);

            Extensions.RodapeListaPacientes();
        }
    }
}
