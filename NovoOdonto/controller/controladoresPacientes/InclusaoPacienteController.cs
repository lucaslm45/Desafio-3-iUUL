using NovoOdonto.data;
using NovoOdonto.data.validator;
using NovoOdonto.Infrastructure;
using NovoOdonto.model;
using NovoOdonto.presentation.paciente;

namespace NovoOdonto.controller.controladoresPacientes
{
    public class InclusaoPacienteController
    {
        public static void Inicia(OdontoDbContext contexto)
        {
            var isValid = false;
            var Form = new InclusaoPacienteForm();
            var Validador = new PacienteValidador();
            // CPF
            do
            {
                Form.SolicitarCPF();
                isValid = Validador.IsValidCPF(Form.Paciente.CPF, contexto);

            } while (!isValid);

            // Nome
            do
            {
                Form.SolicitarNome();
                isValid = Validador.IsValidNome(Form.Paciente.Nome);

            } while (!isValid);

            // Nascimento
            do
            {
                Form.SolicitarNascimento();
                isValid = Validador.IsValidNascimento(Form.Paciente.DataNascimento);

            } while (!isValid);

            try
            {
                var Paciente = new Paciente(Validador.Paciente.CPF, Validador.Paciente.Nome, Validador.Paciente.DataNascimento);
                contexto.Pacientes.Add(Paciente);
                contexto.SaveChanges();
                Console.WriteLine("Paciente cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}