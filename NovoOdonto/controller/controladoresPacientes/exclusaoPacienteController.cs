using NovoOdonto.data;
using NovoOdonto.util;

namespace NovoOdonto.controller.controladoresPacientes
{
    public class ExclusaoPacienteController
    {
        public ExclusaoPacienteController(OdontoDbContext contexto)
        {
            Contexto = contexto;
        }

        private OdontoDbContext Contexto { get; set; }

        public void ExcluirPaciente()
        {
            Console.WriteLine("Digite o CPF do paciente que você quer excluir: ");
            string cpf = Console.ReadLine();
            if (cpf.IsCpf())
            {
                var paciente = Contexto.Pacientes.Find(cpf);
                if (paciente != null)
                {
                    Contexto.Pacientes.Remove(paciente);
                    Contexto.SaveChanges();
                }
            }
            else { Console.WriteLine("CPF inválido!"); }

        }
    }
}
