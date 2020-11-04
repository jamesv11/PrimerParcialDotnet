using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class InicialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apoyos",
                columns: table => new
                {
                    ApoyoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorApoyo = table.Column<int>(nullable: false),
                    ModalidadApoyo = table.Column<string>(maxLength: 15, nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apoyos", x => x.ApoyoId);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Identificacion = table.Column<string>(maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(maxLength: 15, nullable: true),
                    Apellido = table.Column<string>(maxLength: 20, nullable: true),
                    Sexo = table.Column<string>(maxLength: 2, nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    Departamento = table.Column<string>(maxLength: 20, nullable: true),
                    Ciudad = table.Column<string>(maxLength: 20, nullable: true),
                    ApoyoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Identificacion);
                    table.ForeignKey(
                        name: "FK_Personas_Apoyos_ApoyoId",
                        column: x => x.ApoyoId,
                        principalTable: "Apoyos",
                        principalColumn: "ApoyoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_ApoyoId",
                table: "Personas",
                column: "ApoyoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Apoyos");
        }
    }
}
