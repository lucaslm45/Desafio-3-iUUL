using NovoOdonto.data;
using NovoOdonto.data.validator;
using NovoOdonto.presentation.paciente;
using NovoOdonto.util;

namespace NovoOdonto.controller.controladoresPacientes
{
    public class ExclusaoPacienteController
    {
        public static void Inicia(OdontoDbContext contexto)
        {
            var isValid = false;
            //var Form = new ExclusaoPacienteForm();
            var Validador = new PacienteValidador();
            Console.WriteLine("ExclusaoPacienteController not implemented\n");
        }

        //public void ExcluirPaciente()
        //{
        //    string cpf = Console.ReadLine();
        //    if (cpf.IsCpf())
        //    {
        //        var paciente = Contexto.Pacientes.Find(cpf);
        //        if (paciente != null)
        //        {
        //            Contexto.Pacientes.Remove(paciente);
        //            Contexto.SaveChanges();
        //        }
        //    }
        //    else { Console.WriteLine("CPF inválido!"); }

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
