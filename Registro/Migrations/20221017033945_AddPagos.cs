using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registro.Migrations
{
    public partial class AddPagos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ocupaciones",
                columns: table => new
                {
                    OcupacionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Salario = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocupaciones", x => x.OcupacionId);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    PagoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PersonaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Concepto = table.Column<string>(type: "TEXT", nullable: false),
                    Monto = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.PagoId);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    PersonaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Telefono = table.Column<double>(type: "REAL", nullable: false),
                    Celular = table.Column<double>(type: "REAL", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Direccion = table.Column<string>(type: "TEXT", nullable: true),
                    Balance = table.Column<double>(type: "REAL", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OcupacionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.PersonaId);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    PrestamoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Vence = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Monto = table.Column<double>(type: "REAL", nullable: false),
                    Concepto = table.Column<string>(type: "TEXT", nullable: false),
                    Balance = table.Column<double>(type: "REAL", nullable: false),
                    PersonaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.PrestamoId);
                });

            migrationBuilder.CreateTable(
                name: "PagosDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PagoId = table.Column<int>(type: "INTEGER", nullable: false),
                    PrestamoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorPagado = table.Column<int>(type: "INTEGER", nullable: false),
                    OrdenId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagosDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PagosDetalle_Pagos_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Pagos",
                        principalColumn: "PagoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PagosDetalle_OrdenId",
                table: "PagosDetalle",
                column: "OrdenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ocupaciones");

            migrationBuilder.DropTable(
                name: "PagosDetalle");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Pagos");
        }
    }
}
