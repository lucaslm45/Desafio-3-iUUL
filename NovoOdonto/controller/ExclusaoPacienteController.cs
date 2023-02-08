using NovoOdonto.data;
using NovoOdonto.data.validator;
using NovoOdonto.presentation.paciente;
using NovoOdonto.util;
using System.Diagnostics;

namespace NovoOdonto.controller
{
    public class ExclusaoPacienteController
    {
        public static void Inicia(OdontoDbContext contexto)
        {
            if (contexto.Pacientes.Any())
                Process(contexto);
            else
                Console.WriteLine("Não há nenhum paciente cadastrado no sistema.");
        }
        private static void Process(OdontoDbContext contexto)
        {
            Console.Write("Digite o CPF do paciente que você quer excluir: ");
            string cpf = Console.ReadLine();
            if (cpf.IsCpf())
            {
                if (contexto.PacienteExisteNoBanco(cpf))
                {
                    if (!cpf.PacienteTemAgendamentoFuturo(contexto))
                    {
                        var paciente = contexto.Pacientes.FirstOrDefault(p => p.CPF == cpf);
                        if (paciente != null)
                        {
                            contexto.Pacientes.Remove(paciente);
                            contexto.SaveChanges();
                            Console.WriteLine($"O paciente com CPF {cpf} foi excluído com sucesso.");
                        }
                        else
                        {
                            Console.WriteLine($"Erro: Paciente com CPF {cpf} não foi encontrado.");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Erro: paciente possui os agendamentos futuros acima.");
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
