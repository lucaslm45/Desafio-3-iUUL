using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovoOdonto.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaTempoConsulta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "Tempo",
                table: "Agendamentos",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tempo",
                table: "Agendamentos");
        }
    }
}
