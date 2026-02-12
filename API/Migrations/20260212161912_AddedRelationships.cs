using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AddedRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_ConferenceRooms_RoomId",
                table: "Booking");

            migrationBuilder.DeleteData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Booking",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserId",
                table: "Booking",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_AspNetUsers_UserId",
                table: "Booking",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_ConferenceRooms_RoomId",
                table: "Booking",
                column: "RoomId",
                principalTable: "ConferenceRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_AspNetUsers_UserId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_ConferenceRooms_RoomId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_UserId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Booking");

            migrationBuilder.InsertData(
                table: "Booking",
                columns: new[] { "Id", "BookingFor", "CancelledAt", "Capacity", "CreatedAt", "CreatedBy", "EndTime", "RoomId", "StartTime", "Status" },
                values: new object[,]
                {
                    { 1, "", null, 5, new DateTime(2026, 2, 11, 12, 35, 46, 965, DateTimeKind.Utc).AddTicks(3920), "Admin", new DateTime(2026, 2, 12, 13, 35, 46, 965, DateTimeKind.Utc).AddTicks(3919), 1, new DateTime(2026, 2, 12, 12, 35, 46, 965, DateTimeKind.Utc).AddTicks(3913), 0 },
                    { 2, "", null, 7, new DateTime(2026, 2, 11, 12, 35, 46, 965, DateTimeKind.Utc).AddTicks(3925), "Admin", new DateTime(2026, 2, 13, 13, 35, 46, 965, DateTimeKind.Utc).AddTicks(3924), 2, new DateTime(2026, 2, 13, 12, 35, 46, 965, DateTimeKind.Utc).AddTicks(3923), 2 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_ConferenceRooms_RoomId",
                table: "Booking",
                column: "RoomId",
                principalTable: "ConferenceRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
