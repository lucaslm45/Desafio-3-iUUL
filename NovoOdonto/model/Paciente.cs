using NovoOdonto.presentation.paciente;
using NovoOdonto.util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoOdonto.model
{
    public class Paciente
    {
        [Key]
        [Required]
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public int Idade { get; set; }
        //public Agendamento Consulta { get; private set; }

        public Paciente()
        { }
        public Paciente(string cpf, String nome, string nascimento)
        {
            CPF = cpf;
            Nome = nome;
            Nascimento = nascimento.VerificaData().ToUniversalTime();

            Idade = Nascimento.Idade();
            //Consulta = new Agendamento();
        }
        /// <summary>
        /// Sobreescreve o método ToString para fornecer a saída desejada.
        /// </summary>
        /// <returns>Retorna uma sequência de valores de texto, de uma instância de Paciente, de acordo com os requisitos do projeto.</returns>
        public override string ToString()
        {
            var saida = CPF.ToString().PadRight((int)Espacos.CPF) +
                   Nome.ToString().PadRight((int)Espacos.Nome) +
                   Nascimento.ToShortDateString().PadRight((int)Espacos.Nascimento) +
                   Idade.ToString().PadLeft((int)Espacos.Idade);

            //if (Consulta != null)
            //{
            //    saida += "\n" + "".PadRight((int)Espacos.CPF) +
            //             $"Agendado para: {Consulta.DataConsulta.ToShortDateString()}".PadRight((int)Espacos.Nome) +
            //             "".PadRight((int)Espacos.Nascimento) +
            //             "".PadLeft((int)Espacos.Idade) +
            //             "\n" + "".PadRight((int)Espacos.CPF) +
            //             $"{Consulta.HoraInicio:hh\\:mm} às {Consulta.HoraFim:hh\\:mm}".PadRight((int)Espacos.Nome) +
            //             "".PadRight((int)Espacos.Nascimento) +
            //             "".PadLeft((int)Espacos.Idade);
            //}
            return saida;
        }
    }
}
