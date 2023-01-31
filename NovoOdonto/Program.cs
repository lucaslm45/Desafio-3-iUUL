using NovoOdonto.controller;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using NovoOdonto.data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace NovoOdonto
{
    public class Program
    {
        static void Main(string[] args)
        {
            MainController controlador = new MainController();

            var localizacaoPastaProjeto = "C:\\Users\\lucas\\Documents\\GitHub\\";
            var configuration = new ConfigurationBuilder()
                .AddJsonFile($"{localizacaoPastaProjeto}Desafio-3-iUUL\\NovoOdonto\\util\\appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var services = new ServiceCollection();

            using var connection = new NpgsqlConnection(connectionString);

            try
            {
                // O banco de Dados existe?
                connection.Open();

                services.AddDbContext<OdontoDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString(connectionString)));
            }
            catch (NpgsqlException)
            {
                Console.WriteLine("O Banco de Dados não Existe.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + $"Não possível efetuar a conexão com o Banco de " +
                    $"Dados usando a string de conexão: {connectionString}");
            }
            finally
            {
                //ListaPacientes lista = new ListaPacientes();
                //Paciente p1 = new Paciente(62813265047, "Marcos", "17/07/2001");
                //lista.AdicionarNaLista(p1);

                //Paciente p2 = new Paciente(92188860020, "Larissa", "01/02/2000");
                //lista.AdicionarNaLista(p2);

                ////Paciente p3 = new Paciente(92188860020, "Maria Helena", "04/10/1999");
                ////lista.AdicionarNaLista(p3);

                ////lista.RemoverDaLista(p3);

                //lista.ListarPacientes();

                controlador.Inicia();
            }

        }

    }


}