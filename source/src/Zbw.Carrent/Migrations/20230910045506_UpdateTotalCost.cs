using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zbw.Carrent.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTotalCost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReservationNr",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCost",
                table: "Reservations",
                type: "decimal(8,2)",
                precision: 8,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservationNr",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "Reservations");
        }
    }
}
