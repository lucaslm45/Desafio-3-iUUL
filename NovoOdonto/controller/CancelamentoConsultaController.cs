using NovoOdonto.data;
using NovoOdonto.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoOdonto.controller
{
    internal class CancelamentoConsultaController
    {
        public static void Inicia(OdontoDbContext contexto)
        {
            Console.WriteLine("Digite o CPF do paciente que você quer excluir o agendamento: ");

            

            string cpf = Console.ReadLine();
            //Método para listar agenda do paciente

            Console.WriteLine("Digite o ID do agendamento: ");

            int id = Convert.ToInt32(Console.ReadLine()); 

            

            if (cpf.IsCpf())
            {
                var paciente = contexto.Pacientes.Find(cpf);
                var agendamento = contexto.Agenda.Find(id);
                if (paciente != null)
                {
                    contexto.Agenda.Remove(agendamento);
                    contexto.SaveChanges();
                }
            }
            else { Console.WriteLine("CPF inválido!"); }
        }
    }
}
