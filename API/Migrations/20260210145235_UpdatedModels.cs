using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomNumber",
                table: "ConferenceRooms",
                newName: "Location");

            migrationBuilder.AddColumn<DateTime>(
                name: "CancelledAt",
                table: "Booking",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Booking",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CancelledAt",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "ConferenceRooms",
                newName: "RoomNumber");
        }
    }
}
