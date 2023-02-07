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
            Console.Write("Digite o CPF do paciente que você quer excluir: ");
            string cpf = Console.ReadLine();
            if (cpf.IsCpf())
            {
                if (contexto.PacienteExisteNoBanco(cpf))
                {
                    if (!cpf.PacienteTemAgendamentoFuturo(contexto))
                    {
                        var paciente = contexto.Pacientes.First(p => p.CPF == cpf);
                        contexto.Pacientes.Remove(paciente);
                        contexto.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Erro: paciente possui os agendamentos futuros acima.\n");
                    }
                }
                else
                    Console.WriteLine("Erro: paciente não cadastrado.");
            }
            else
                Console.WriteLine("Erro: CPF inválido");

        }
    }
}
