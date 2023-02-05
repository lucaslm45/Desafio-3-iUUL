using NovoOdonto.data;
using NovoOdonto.data.validator;
using NovoOdonto.Infrastructure;
using NovoOdonto.model;
using NovoOdonto.presentation.paciente;

namespace NovoOdonto.controller.controladoresPacientes
{
    public class InclusaoPacienteController : IController
    {
        public InclusaoPacienteController(OdontoDbContext contexto)
        {
            Contexto = contexto;
        }
        private OdontoDbContext Contexto { get; set; }
        private InclusaoPacienteForm Form { get; set; } = new InclusaoPacienteForm();
        private PacienteValidador Validador { get; set; } = new PacienteValidador();
        public bool isValid { get; set; }

        public void Inicia()
        {
            // CPF
            do
            {
                Form.SolicitarCPF();
                isValid = Validador.IsValidCPF(Form.Paciente.CPF, Contexto);

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
                Contexto.Pacientes.Add(Paciente);
                Contexto.SaveChanges();
                Console.WriteLine("Paciente cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}