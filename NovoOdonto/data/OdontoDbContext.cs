using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NovoOdonto.model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoOdonto.data
{
    public class OdontoDbContext : DbContext
    {
        public OdontoDbContext()
        {
        }

        public OdontoDbContext(DbContextOptions<OdontoDbContext> opt) : base(opt)
        {

        }
        /// <summary>
        /// Metodo utilizado no momento de adição de Migrações
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var localizacaoPastaProjeto = "C:\\Users\\lucas\\Documents\\GitHub\\";
            //var localizacaoPastaProjeto = "E:\\Residencia\\";

            var configuration = new ConfigurationBuilder()
                .AddJsonFile($"{localizacaoPastaProjeto}Desafio-3-iUUL\\NovoOdonto\\util\\appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseNpgsql(connectionString);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //modelBuilder.Entity<Agendamento>()
        //    .HasOne(agendamento => agendamento.Paciente)
        //    .WithOne(paciente => paciente.Agendamento)
        //    .HasForeignKey<Paciente>(paciente => paciente.AgendamentoId);
        //}

        //public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Agendamento> Agenda { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Consultorio;Username=postgres;Password=136341");
        }
    }
}
