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
            var isValid = false;
            //var Form = new ExclusaoPacienteForm();
            var Validador = new PacienteValidador();
            Console.WriteLine("\nExclusaoPacienteController not implemented\n");
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
    }
}
