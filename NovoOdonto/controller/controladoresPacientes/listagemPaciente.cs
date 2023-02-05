using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovoOdonto.data;
using NovoOdonto.model;

namespace NovoOdonto.controller.controladoresPacientes
{
    public class listagemPaciente
    {
        public listagemPaciente(OdontoDbContext contexto)
        {
            Contexto = contexto;
        }

        private OdontoDbContext Contexto { get; set; }

        public void ListarPorCPF()
        {
            var pacientesListadosPorCPF = new List<Paciente>();

            var pacientes = from paciente in Contexto.Pacientes orderby paciente.CPF select paciente;

            foreach (var paciente in pacientes) { Console.WriteLine($"{paciente.CPF} - {paciente.Nome}"); }
        }

        public void ListarPorNome()
        {
            var pacientesListadosPorNome = new List<Paciente>();

            var pacientes = from paciente in Contexto.Pacientes orderby paciente.Nome select paciente;

            foreach (var paciente in pacientes) { Console.WriteLine($"{paciente.CPF} - {paciente.Nome}"); }
        }
    }
}
