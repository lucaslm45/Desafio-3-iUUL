using NovoOdonto.data.dto;
using NovoOdonto.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoOdonto.presentation.paciente
{
    public class InclusaoPacienteForm
    {
        public PacienteDTO Paciente { get; private set; }
        public InclusaoPacienteForm() =>
            Paciente = new();
        public void SolicitarCPF()
        {
            Console.Write("CPF: ");
            Paciente.CPF = Console.ReadLine();
        }
        public void SolicitarNome()
        {
            Console.Write("Nome: ");
            Paciente.Nome = Console.ReadLine();
        }
        public void SolicitarNascimento()
        {
            Console.Write("Data de Nascimento (ddMMaaaa):");
            Paciente.DataNascimento = Console.ReadLine();
        }
    }
}
