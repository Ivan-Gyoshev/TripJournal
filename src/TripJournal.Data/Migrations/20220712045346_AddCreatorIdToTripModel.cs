using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripJournal.Data.Migrations
{
    public partial class AddCreatorIdToTripModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "Trip",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Trip");
        }
    }
}
