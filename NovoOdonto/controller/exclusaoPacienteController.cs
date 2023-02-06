using NovoOdonto.data;
using NovoOdonto.data.validator;
using NovoOdonto.presentation.paciente;
using NovoOdonto.util;

namespace NovoOdonto.controller
{
    public class ExclusaoPacienteController
    {

        public static void Inicia(OdontoDbContext contexto)
        {
            Console.WriteLine("Digite o CPF do paciente que você quer excluir: ");
            string cpf = Console.ReadLine();
            if (cpf.IsCpf())
            {
                var paciente = contexto.Pacientes.Find(cpf);
                if (paciente != null)
                {
                    contexto.Pacientes.Remove(paciente);
                    contexto.SaveChanges();
                }
            }
            else { Console.WriteLine("CPF inválido!"); }

        }
    }
}
