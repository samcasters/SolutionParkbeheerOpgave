using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkDataLayer.Migrations
{
    /// <inheritdoc />
    public partial class huurcontractrelationidincsharp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_huurContract_huis_HuisId",
                table: "huurContract");

            migrationBuilder.DropForeignKey(
                name: "FK_huurContract_huurPeriode_HuurPeriodeId",
                table: "huurContract");

            migrationBuilder.DropForeignKey(
                name: "FK_huurContract_huurder_HuurderId",
                table: "huurContract");

            migrationBuilder.AlterColumn<int>(
                name: "HuurderId",
                table: "huurContract",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HuurPeriodeId",
                table: "huurContract",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HuisId",
                table: "huurContract",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_huurContract_huis_HuisId",
                table: "huurContract",
                column: "HuisId",
                principalTable: "huis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_huurContract_huurPeriode_HuurPeriodeId",
                table: "huurContract",
                column: "HuurPeriodeId",
                principalTable: "huurPeriode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_huurContract_huurder_HuurderId",
                table: "huurContract",
                column: "HuurderId",
                principalTable: "huurder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_huurContract_huis_HuisId",
                table: "huurContract");

            migrationBuilder.DropForeignKey(
                name: "FK_huurContract_huurPeriode_HuurPeriodeId",
                table: "huurContract");

            migrationBuilder.DropForeignKey(
                name: "FK_huurContract_huurder_HuurderId",
                table: "huurContract");

            migrationBuilder.AlterColumn<int>(
                name: "HuurderId",
                table: "huurContract",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HuurPeriodeId",
                table: "huurContract",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HuisId",
                table: "huurContract",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_huurContract_huis_HuisId",
                table: "huurContract",
                column: "HuisId",
                principalTable: "huis",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_huurContract_huurPeriode_HuurPeriodeId",
                table: "huurContract",
                column: "HuurPeriodeId",
                principalTable: "huurPeriode",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_huurContract_huurder_HuurderId",
                table: "huurContract",
                column: "HuurderId",
                principalTable: "huurder",
                principalColumn: "Id");
        }
    }
}
