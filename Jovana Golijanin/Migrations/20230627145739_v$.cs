using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jovana_Golijanin.Migrations
{
    /// <inheritdoc />
    public partial class v : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partija_Igrac_DrugiIgracID",
                table: "Partija");

            migrationBuilder.DropForeignKey(
                name: "FK_Partija_Igrac_PrviIgracID",
                table: "Partija");

            migrationBuilder.DropTable(
                name: "Potezi");

            migrationBuilder.DropIndex(
                name: "IX_Partija_DrugiIgracID",
                table: "Partija");

            migrationBuilder.DropColumn(
                name: "DrugiIgracID",
                table: "Partija");

            migrationBuilder.RenameColumn(
                name: "PrviIgracID",
                table: "Partija",
                newName: "IgracID");

            migrationBuilder.RenameIndex(
                name: "IX_Partija_PrviIgracID",
                table: "Partija",
                newName: "IX_Partija_IgracID");

            migrationBuilder.AddColumn<string>(
                name: "PobednikCovek",
                table: "Partija",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "BrojNeresenih",
                table: "Igrac",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BrojPobeda",
                table: "Igrac",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BrojPoraza",
                table: "Igrac",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Partija_Igrac_IgracID",
                table: "Partija",
                column: "IgracID",
                principalTable: "Igrac",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partija_Igrac_IgracID",
                table: "Partija");

            migrationBuilder.DropColumn(
                name: "PobednikCovek",
                table: "Partija");

            migrationBuilder.DropColumn(
                name: "BrojNeresenih",
                table: "Igrac");

            migrationBuilder.DropColumn(
                name: "BrojPobeda",
                table: "Igrac");

            migrationBuilder.DropColumn(
                name: "BrojPoraza",
                table: "Igrac");

            migrationBuilder.RenameColumn(
                name: "IgracID",
                table: "Partija",
                newName: "PrviIgracID");

            migrationBuilder.RenameIndex(
                name: "IX_Partija_IgracID",
                table: "Partija",
                newName: "IX_Partija_PrviIgracID");

            migrationBuilder.AddColumn<int>(
                name: "DrugiIgracID",
                table: "Partija",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Potezi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartijaID = table.Column<int>(type: "int", nullable: true),
                    Kolona = table.Column<int>(type: "int", nullable: false),
                    Vrsta = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_Potezi_PartijaID",
                table: "Potezi",
                column: "PartijaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Partija_Igrac_DrugiIgracID",
                table: "Partija",
                column: "DrugiIgracID",
                principalTable: "Igrac",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Partija_Igrac_PrviIgracID",
                table: "Partija",
                column: "PrviIgracID",
                principalTable: "Igrac",
                principalColumn: "ID");
        }
    }
}
