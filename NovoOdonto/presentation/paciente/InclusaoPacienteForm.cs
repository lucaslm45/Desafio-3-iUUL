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
        /// <summary>
        /// Recebe o CPF em formato string pelo console e atribui o valor recebido a propriedade CPF da Paciente
        /// </summary>
        public void SolicitarCPF()
        {
            Console.Write("CPF: ");
            Paciente.CPF = Console.ReadLine();
        }
        /// <summary>
        /// Recebe um nome em formato string pelo console e atribui o valor recebido a propriedade Nome da classe Paciente
        /// </summary>
        public void SolicitarNome()
        {
            Console.Write("Nome: ");
            Paciente.Nome = Console.ReadLine();
        }
        /// <summary>
        /// Recebe data no formato ddMMaaaa em formato string pelo console e atribui o valor recebido a propriedade DataNascimento da classe Paciente
        /// </summary>
        public void SolicitarNascimento()
        {
            Console.Write("Data de Nascimento (ddMMaaaa):");
            Paciente.DataNascimento = Console.ReadLine();
        }
    }
}
