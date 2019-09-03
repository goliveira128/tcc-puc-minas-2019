using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IncidentesSGQ.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Incidentes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    IdUsuario = table.Column<string>(nullable: true),
                    DataOcorrido = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    NaoConformidadeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NaoConformidades",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaoConformidades", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incidentes");

            migrationBuilder.DropTable(
                name: "NaoConformidades");
        }
    }
}
