using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jovana_Golijanin.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Igrac",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojIndeksa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Igrac", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Partija",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VremePocetka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VremeKraja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuzinaPartije = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrviIgracID = table.Column<int>(type: "int", nullable: true),
                    DrugiIgracID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partija", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Partija_Igrac_DrugiIgracID",
                        column: x => x.DrugiIgracID,
                        principalTable: "Igrac",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Partija_Igrac_PrviIgracID",
                        column: x => x.PrviIgracID,
                        principalTable: "Igrac",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Potezi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrsta = table.Column<int>(type: "int", nullable: false),
                    Kolona = table.Column<int>(type: "int", nullable: false),
                    PartijaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Potezi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Potezi_Partija_PartijaID",
                        column: x => x.PartijaID,
                        principalTable: "Partija",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Partija_DrugiIgracID",
                table: "Partija",
                column: "DrugiIgracID");

            migrationBuilder.CreateIndex(
                name: "IX_Partija_PrviIgracID",
                table: "Partija",
                column: "PrviIgracID");

            migrationBuilder.CreateIndex(
                name: "IX_Potezi_PartijaID",
                table: "Potezi",
                column: "PartijaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Potezi");

            migrationBuilder.DropTable(
                name: "Partija");

            migrationBuilder.DropTable(
                name: "Igrac");
        }
    }
}
