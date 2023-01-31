using Microsoft.EntityFrameworkCore;
using NovoOdonto.model;
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
        public OdontoDbContext(DbContextOptions<OdontoDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Agendamento>()
            //    .HasOne(agendamento => agendamento.Paciente)
            //    .WithOne(paciente => paciente.Agendamento)
            //    .HasForeignKey<Paciente>(paciente => paciente.AgendamentoId);
        }

        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }


    }
}
