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
    }
}
