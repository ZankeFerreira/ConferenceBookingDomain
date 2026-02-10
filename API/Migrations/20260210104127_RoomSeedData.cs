using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class RoomSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ConferenceRooms",
                columns: new[] { "Id", "Capacity", "RoomNumber", "Status" },
                values: new object[,]
                {
                    { 1, 10, "Room A", 0 },
                    { 2, 20, "Room B", 0 },
                    { 3, 15, "Room C", 0 },
                    { 4, 25, "Room D", 0 },
                    { 5, 30, "Room E", 0 },
                    { 6, 10, "Room F", 0 },
                    { 7, 20, "Room G", 0 },
                    { 8, 15, "Room H", 0 },
                    { 9, 13, "Room I", 0 },
                    { 10, 20, "Room J", 0 },
                    { 11, 10, "Room K", 0 },
                    { 12, 5, "Room L", 0 },
                    { 13, 12, "Room M", 0 },
                    { 14, 15, "Room N", 0 },
                    { 15, 12, "Room O", 0 },
                    { 16, 30, "Room P", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 16);
        }
    }
}
