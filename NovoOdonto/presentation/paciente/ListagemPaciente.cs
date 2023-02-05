using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovoOdonto.data;
using NovoOdonto.util;
using NovoOdonto.model;

namespace NovoOdonto.presentation.paciente
{
    public class ListagemPaciente
    {
        public static void ListarPorCPF(OdontoDbContext contexto)
        {
            Extensions.CabecalhoListaPacientes();

            var pacientes = from paciente in contexto.Pacientes orderby paciente.CPF select paciente;

            foreach (var paciente in pacientes) { Console.WriteLine(paciente); }

            Extensions.RodapeListaPacientes();

        }

        public static void ListarPorNome(OdontoDbContext contexto)
        {
            Extensions.CabecalhoListaPacientes();

            var pacientes = from paciente in contexto.Pacientes orderby paciente.Nome select paciente;

            foreach (var paciente in pacientes) { Console.WriteLine(paciente); }

            Extensions.RodapeListaPacientes();

        }
    }
}
