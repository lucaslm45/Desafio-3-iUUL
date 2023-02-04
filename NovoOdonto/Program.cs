using NovoOdonto.controller;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using NovoOdonto.data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace NovoOdonto
{
    public class Program
    {
        static void Main(string[] args)
        {
            var escolha = "";
            var localizacaoProjeto = "";

            //Informar localizacao do arquivo que contem a informacao da string de conexão
            do
            {
                Console.WriteLine("1 - Usar pasta projeto Lucas");
                Console.WriteLine("2 - Usar pasta projeto Marcos");
                Console.WriteLine("3 - Usar nova pasta projeto");
                Console.Write("Digite sua escolha: ");
                escolha = Console.ReadLine();

            } while (!(escolha != "1" || escolha != "2" || escolha != "3"));

            switch (escolha)
            {
                case "1":
                    localizacaoProjeto = "C:\\Users\\lucas\\Documents\\GitHub\\";
                    break;
                case "2":
                    localizacaoProjeto = "E:\\Residencia\\";
                    break;
                case "3":
                    Console.Write("Insira a localização da pasta de projeto do GitHub");
                    localizacaoProjeto = Console.ReadLine();
                    break;
            }
            // Alterar nome do Database
            var dataBaseName = "Consultorio";
            Console.WriteLine($"O nome do Database utilizado é {dataBaseName}, deseja alterá-lo?");
            do
            {
                Console.WriteLine("S - Sim");
                Console.WriteLine("N ou deixar em branco - Não");
                Console.Write("Digite sua escolha: ");
                escolha = Console.ReadLine();

                escolha = escolha == "" ? "N" : escolha;

            } while (!(escolha?.ToUpper() != "S" || escolha?.ToUpper() != "N"));

            if (escolha == "S")
            {
                do
                {
                    Console.Write("Nome do Database: ");
                    dataBaseName = Console.ReadLine();

                } while (dataBaseName.Length == 0);
            }
            var connectionString = "";

            var configuration = new ConfigurationBuilder()
            .AddJsonFile($"{localizacaoProjeto}Desafio-3-iUUL\\NovoOdonto\\util\\appsettings.json", optional: false, reloadOnChange: true)
            .Build();
            connectionString = configuration.GetConnectionString("DefaultConnection");

            connectionString = connectionString.Replace("Database=Consultorio", $"Database={dataBaseName}");

            // Inicializa o contexto da Aplicação
            var contexto = new OdontoDbContext(new DbContextOptionsBuilder<OdontoDbContext>()
                .UseNpgsql(connectionString)
                .Options);

            // Garante que o Database seja criado
            contexto.Database.EnsureCreated();

            // Verifica conexão com o Database
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            // Inicia o Controlador Principal
            var controlador = new MainController(contexto);
            controlador.Inicia();
            //var teste = new ExclusaoPacienteController(contexto);

            //teste.ExcluirPaciente();
            //controlador.Inicia();
        }

    }

}