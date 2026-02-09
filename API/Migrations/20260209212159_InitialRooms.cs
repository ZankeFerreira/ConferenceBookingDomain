using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class InitialRooms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_ConferenceRoom_RoomID",
                table: "Booking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConferenceRoom",
                table: "ConferenceRoom");

            migrationBuilder.RenameTable(
                name: "ConferenceRoom",
                newName: "Rooms");

            migrationBuilder.RenameColumn(
                name: "RoomID",
                table: "Booking",
                newName: "RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_RoomID",
                table: "Booking",
                newName: "IX_Booking_RoomId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Rooms",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Rooms_RoomId",
                table: "Booking",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Rooms_RoomId",
                table: "Booking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "ConferenceRoom");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Booking",
                newName: "RoomID");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_RoomId",
                table: "Booking",
                newName: "IX_Booking_RoomID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ConferenceRoom",
                newName: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConferenceRoom",
                table: "ConferenceRoom",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_ConferenceRoom_RoomID",
                table: "Booking",
                column: "RoomID",
                principalTable: "ConferenceRoom",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
