using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AddedLocationField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<string>(
                name: "RoomID",
                table: "ConferenceRooms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2026, 2, 11, 12, 35, 46, 965, DateTimeKind.Utc).AddTicks(3920), new DateTime(2026, 2, 12, 13, 35, 46, 965, DateTimeKind.Utc).AddTicks(3919), new DateTime(2026, 2, 12, 12, 35, 46, 965, DateTimeKind.Utc).AddTicks(3913) });

            migrationBuilder.UpdateData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2026, 2, 11, 12, 35, 46, 965, DateTimeKind.Utc).AddTicks(3925), new DateTime(2026, 2, 13, 13, 35, 46, 965, DateTimeKind.Utc).AddTicks(3924), new DateTime(2026, 2, 13, 12, 35, 46, 965, DateTimeKind.Utc).AddTicks(3923) });

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Location", "RoomID" },
                values: new object[] { "Bloemfontein", "Room A" });

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Location", "RoomID" },
                values: new object[] { "Cape Town", "Room B" });

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Location", "RoomID" },
                values: new object[] { "Bloemfontein", "Room D" });

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Location", "RoomID" },
                values: new object[] { "Bloemfontein", "Room E" });

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Location", "RoomID" },
                values: new object[] { "Bloemfontein", "Room F" });

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Location", "RoomID" },
                values: new object[] { "Cape Town", "Room G" });

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Location", "RoomID" },
                values: new object[] { "Bloemfontein", "Room H" });

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Location", "RoomID" },
                values: new object[] { "Bloemfontein", "Room I" });

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Location", "RoomID" },
                values: new object[] { "Cape Town", "Room J" });

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Location", "RoomID" },
                values: new object[] { "Cape Town", "Room K" });

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Location", "RoomID" },
                values: new object[] { "Bloemfontein", "Room L" });

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Location", "RoomID" },
                values: new object[] { "Bloemfontein", "Room M" });

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Location", "RoomID" },
                values: new object[] { "Bloemfontein", "Room N" });

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Location", "RoomID" },
                values: new object[] { "Bloemfontein", "Room O" });

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Location", "RoomID" },
                values: new object[] { "Cape Town", "Room P" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomID",
                table: "ConferenceRooms");

            migrationBuilder.UpdateData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2026, 2, 10, 16, 43, 58, 106, DateTimeKind.Utc).AddTicks(2767), new DateTime(2026, 2, 11, 17, 43, 58, 106, DateTimeKind.Utc).AddTicks(2766), new DateTime(2026, 2, 11, 16, 43, 58, 106, DateTimeKind.Utc).AddTicks(2748) });

            migrationBuilder.UpdateData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2026, 2, 10, 16, 43, 58, 106, DateTimeKind.Utc).AddTicks(2793), new DateTime(2026, 2, 12, 17, 43, 58, 106, DateTimeKind.Utc).AddTicks(2793), new DateTime(2026, 2, 12, 16, 43, 58, 106, DateTimeKind.Utc).AddTicks(2792) });

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "Location",
                value: "Room A");

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "Location",
                value: "Room B");

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 4,
                column: "Location",
                value: "Room D");

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 5,
                column: "Location",
                value: "Room E");

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 6,
                column: "Location",
                value: "Room F");

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 7,
                column: "Location",
                value: "Room G");

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 8,
                column: "Location",
                value: "Room H");

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 9,
                column: "Location",
                value: "Room I");

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 10,
                column: "Location",
                value: "Room J");

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 11,
                column: "Location",
                value: "Room K");

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 12,
                column: "Location",
                value: "Room L");

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 13,
                column: "Location",
                value: "Room M");

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 14,
                column: "Location",
                value: "Room N");

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 15,
                column: "Location",
                value: "Room O");

            migrationBuilder.UpdateData(
                table: "ConferenceRooms",
                keyColumn: "Id",
                keyValue: 16,
                column: "Location",
                value: "Room P");

            migrationBuilder.InsertData(
                table: "ConferenceRooms",
                columns: new[] { "Id", "Capacity", "Location", "Status" },
                values: new object[] { 3, 15, "Room C", 2 });
        }
    }
}
