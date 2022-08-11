using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripJournal.Data.Migrations
{
    public partial class EditTripModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Trips");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Trips");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Trips",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
