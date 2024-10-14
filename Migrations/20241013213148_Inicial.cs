using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MarianelaVeras_Ap1_P1.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deudores",
                columns: table => new
                {
                    DeudorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deudores", x => x.DeudorId);
                });

            migrationBuilder.CreateTable(
                name: "Cobros",
                columns: table => new
                {
                    CobroId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Monto = table.Column<decimal>(type: "TEXT", nullable: false),
                    DeudorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobros", x => x.CobroId);
                    table.ForeignKey(
                        name: "FK_Cobros_Deudores_DeudorId",
                        column: x => x.DeudorId,
                        principalTable: "Deudores",
                        principalColumn: "DeudorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    PrestamoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Concepto = table.Column<string>(type: "TEXT", nullable: false),
                    Monto = table.Column<decimal>(type: "TEXT", nullable: false),
                    Balance = table.Column<decimal>(type: "TEXT", nullable: false),
                    DeudorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.PrestamoId);
                    table.ForeignKey(
                        name: "FK_Prestamos_Deudores_DeudorId",
                        column: x => x.DeudorId,
                        principalTable: "Deudores",
                        principalColumn: "DeudorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CobroDetalles",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CobroId = table.Column<int>(type: "INTEGER", nullable: false),
                    PrestamoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorCobrado = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CobroDetalles", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_CobroDetalles_Cobros_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "Cobros",
                        principalColumn: "CobroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CobroDetalles_Prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "Prestamos",
                        principalColumn: "PrestamoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Deudores",
                columns: new[] { "DeudorId", "Nombres" },
                values: new object[,]
                {
                    { 1, "Unohana Retsu" },
                    { 2, "Kurosaki Ichigo" },
                    { 3, "Zaraki Kenpachii" },
                    { 4, "Roronoa Zoro" },
                    { 5, "Monkey D. Luffy" },
                    { 6, "Soul King Brook" },
                    { 7, "Uzumaki Naruto" },
                    { 8, "Uchiha Sasuke" },
                    { 9, "Hatake Kakashi" },
                    { 10, "Haruno Sakura" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CobroDetalles_PrestamoId",
                table: "CobroDetalles",
                column: "PrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cobros_DeudorId",
                table: "Cobros",
                column: "DeudorId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_DeudorId",
                table: "Prestamos",
                column: "DeudorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CobroDetalles");

            migrationBuilder.DropTable(
                name: "Cobros");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Deudores");
        }
    }
}
