using NovoOdonto.controller;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using NovoOdonto.data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using NovoOdonto.util;

namespace NovoOdonto
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\"Atenção\": Para o funcionamento adequado do sistema, as variáveis de conexão \n" +
                "devem ser ajustadas na classe Conexão, localizada em: NovoOdonto.util");

            // Inicializa o contexto da Aplicação
            var contexto = new OdontoDbContext(new DbContextOptionsBuilder<OdontoDbContext>()
                .UseNpgsql(Conexao.ConnectionString)
                .Options);

            // Garante que o Database seja criado
            contexto.Database.EnsureCreated();

            // Verifica conexão com o Database
            var connection = new NpgsqlConnection(Conexao.ConnectionString);
            connection.Open();

            // Inicia o Controlador Principal
            var controlador = new MainController(contexto);
            controlador.Inicia();
        }
    }
}