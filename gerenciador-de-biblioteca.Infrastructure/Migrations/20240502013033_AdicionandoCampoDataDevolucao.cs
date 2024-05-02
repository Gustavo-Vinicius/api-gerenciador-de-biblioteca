using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gerenciador_de_biblioteca.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoCampoDataDevolucao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataDevolucao",
                table: "Emprestimos",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDevolucao",
                table: "Emprestimos");
        }
    }
}
