using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NovoOdonto.model;

#nullable disable

namespace NovoOdonto.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelaPacientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    CPF = table.Column<string>(type: "text", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Nascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Idade = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.CPF);
                });
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pacientes");
        }


    }
}
