using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovoOdonto.data.validator;
using NovoOdonto.data;
using NovoOdonto.model;
using NovoOdonto.presentation.paciente;
using System.Xml.Linq;

namespace NovoOdonto.controller
{
    public class exclusaoPacienteController
    {
        protected OdontoDbContext Contexto { get; set; } = new OdontoDbContext();

        public void ExcluirPaciente()
        {
            string cpf = Console.ReadLine();
            if (util.Extensions.IsCpf(cpf))
            {
                var paciente = Contexto.Pacientes.Find(cpf);
                Contexto.Pacientes.Remove(paciente);
                Contexto.SaveChanges();
            }
            else { Console.WriteLine("CPF inválido!"); }
            
        }
    }
}
