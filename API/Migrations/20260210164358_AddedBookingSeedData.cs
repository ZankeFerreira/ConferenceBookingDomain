using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AddedBookingSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Booking",
                columns: new[] { "Id", "BookingFor", "CancelledAt", "Capacity", "CreatedAt", "CreatedBy", "EndTime", "RoomId", "StartTime", "Status" },
                values: new object[,]
                {
                    { 1, "", null, 5, new DateTime(2026, 2, 10, 16, 43, 58, 106, DateTimeKind.Utc).AddTicks(2767), "Admin", new DateTime(2026, 2, 11, 17, 43, 58, 106, DateTimeKind.Utc).AddTicks(2766), 1, new DateTime(2026, 2, 11, 16, 43, 58, 106, DateTimeKind.Utc).AddTicks(2748), 0 },
                    { 2, "", null, 7, new DateTime(2026, 2, 10, 16, 43, 58, 106, DateTimeKind.Utc).AddTicks(2793), "Admin", new DateTime(2026, 2, 12, 17, 43, 58, 106, DateTimeKind.Utc).AddTicks(2793), 2, new DateTime(2026, 2, 12, 16, 43, 58, 106, DateTimeKind.Utc).AddTicks(2792), 2 }
                });

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: 0);
        }
    }
}
