using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NovoOdonto.model;
using NovoOdonto.util;
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
            optionsBuilder.UseNpgsql(Conexao.ConnectionString);
        }
    }
}
