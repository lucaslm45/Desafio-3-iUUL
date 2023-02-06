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
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var localizacaoPastaProjeto = "C:\\Users\\lucas\\Documents\\GitHub\\";
        //    //var localizacaoPastaProjeto = "E:\\Residencia\\";

        //    var configuration = new ConfigurationBuilder()
        //        .AddJsonFile($"{localizacaoPastaProjeto}Desafio-3-iUUL\\NovoOdonto\\util\\appsettings.json", optional: false, reloadOnChange: true)
        //        .Build();

        //    var connectionString = configuration.GetConnectionString("DefaultConnection");

        //    optionsBuilder.UseNpgsql(connectionString);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agendamento>()
                .HasOne(agendamento => agendamento.Paciente)
                .WithMany(paciente => paciente.Agendamentos)
                .HasForeignKey(agendamento => agendamento.PacienteId);
        }

        //public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Consultorio;Username=postgres;Password=root");
            //optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Consultorio;Username=postgres;Password=136341");
        }
    }
}
