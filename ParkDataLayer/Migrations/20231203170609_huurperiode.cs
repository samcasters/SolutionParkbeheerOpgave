using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkDataLayer.Migrations
{
    /// <inheritdoc />
    public partial class huurperiode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gegevenstelefoon",
                table: "huurder",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_huurder_Gegevenstelefoon",
                table: "huurder",
                column: "Gegevenstelefoon");

            migrationBuilder.AddForeignKey(
                name: "FK_huurder_contactGegevens_Gegevenstelefoon",
                table: "huurder",
                column: "Gegevenstelefoon",
                principalTable: "contactGegevens",
                principalColumn: "telefoon");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_huurder_contactGegevens_Gegevenstelefoon",
                table: "huurder");

            migrationBuilder.DropIndex(
                name: "IX_huurder_Gegevenstelefoon",
                table: "huurder");

            migrationBuilder.DropColumn(
                name: "Gegevenstelefoon",
                table: "huurder");
        }
    }
}
