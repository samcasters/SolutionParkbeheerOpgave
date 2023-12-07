using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkDataLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contactGegevens",
                columns: table => new
                {
                    telefoon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    adres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contactGegevens", x => x.telefoon);
                });

            migrationBuilder.CreateTable(
                name: "huurder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naam = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_huurder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "huurPeriode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    startDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    eindDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dagenVerhuurd = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_huurPeriode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "park",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Locatie = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_park", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "huis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    actief = table.Column<bool>(type: "bit", nullable: false),
                    nr = table.Column<int>(type: "int", nullable: false),
                    straat = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ParkId = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_huis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_huis_park_ParkId",
                        column: x => x.ParkId,
                        principalTable: "park",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "huurContract",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    HuurderId = table.Column<int>(type: "int", nullable: true),
                    HuurPeriodeId = table.Column<int>(type: "int", nullable: true),
                    HuisId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_huurContract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_huurContract_huis_HuisId",
                        column: x => x.HuisId,
                        principalTable: "huis",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_huurContract_huurPeriode_HuurPeriodeId",
                        column: x => x.HuurPeriodeId,
                        principalTable: "huurPeriode",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_huurContract_huurder_HuurderId",
                        column: x => x.HuurderId,
                        principalTable: "huurder",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_huis_ParkId",
                table: "huis",
                column: "ParkId");

            migrationBuilder.CreateIndex(
                name: "IX_huurContract_HuisId",
                table: "huurContract",
                column: "HuisId");

            migrationBuilder.CreateIndex(
                name: "IX_huurContract_HuurderId",
                table: "huurContract",
                column: "HuurderId");

            migrationBuilder.CreateIndex(
                name: "IX_huurContract_HuurPeriodeId",
                table: "huurContract",
                column: "HuurPeriodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contactGegevens");

            migrationBuilder.DropTable(
                name: "huurContract");

            migrationBuilder.DropTable(
                name: "huis");

            migrationBuilder.DropTable(
                name: "huurPeriode");

            migrationBuilder.DropTable(
                name: "huurder");

            migrationBuilder.DropTable(
                name: "park");
        }
    }
}
