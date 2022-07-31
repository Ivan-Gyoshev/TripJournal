using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripJournal.Data.Migrations
{
    public partial class UpdateTripModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedOn",
                table: "Trip",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedOn",
                table: "Trip",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Trip",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedOn",
                table: "Trip",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trip_IsDeleted",
                table: "Trip",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Trip_IsDeleted",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Trip");
        }
    }
}
