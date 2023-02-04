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
            var controlador = new MainController();
            var  context = new OdontoDbContext();

            context.IniciaBanco();
            controlador.Inicia();
        }

    }


}