using NovoOdonto.data;
using NovoOdonto.data.validator;
using NovoOdonto.Infrastructure;
using NovoOdonto.model;
using NovoOdonto.presentation.agendamento;
using NovoOdonto.util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoOdonto.controller
{
    public class InclusaoPacienteController
    {
        protected OdontoDbContext Contexto { get; set; } = new OdontoDbContext();
        private InclusaoPacienteForm Form { get; set; } = new InclusaoPacienteForm();
        private PacienteValidador Validador { get; set; } = new PacienteValidador();
        protected bool isValid { get; set; }

        public void Roda()
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Paciente cadastrado com sucesso!");
            }
        }
    }
}
