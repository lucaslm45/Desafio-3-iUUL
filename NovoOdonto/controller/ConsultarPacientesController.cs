using Microsoft.EntityFrameworkCore;
using NovoOdonto.data;
using NovoOdonto.util;

namespace NovoOdonto.controller
{
    public class ConsultarPacientesController
    {
        public static void ListarPorCPF(OdontoDbContext contexto)
        {
            Extensions.CabecalhoListaPacientes();

            var pacientes = contexto.Pacientes.Include(p => p.Agendamentos).OrderBy(p => p.CPF);

            foreach (var paciente in pacientes) Console.WriteLine(paciente);

            Extensions.RodapeListaPacientes();
        }

        public static void ListarPorNome(OdontoDbContext contexto)
        {
            Extensions.CabecalhoListaPacientes();

            var pacientes = contexto.Pacientes.Include(p => p.Agendamentos).OrderBy(p => p.Nome);

            foreach (var paciente in pacientes) Console.WriteLine(paciente);

            Extensions.RodapeListaPacientes();
        }
    }
}
