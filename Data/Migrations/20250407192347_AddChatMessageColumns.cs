using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo03.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddChatMessageColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReceiverId",
                table: "ChatMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7308bdcb-4a6b-4555-90d1-0f37bdae8ed0", "AQAAAAIAAYagAAAAEIItKHqy8b6jLxGbndR6Cid0KNqQhW37ijSkYhKadNCIcliemkUeBEH8iwVtL//XMg==", "29618e30-28af-4896-b718-8365fae7fd3a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "864c7621-604b-4951-b549-7c2869173c05", "AQAAAAIAAYagAAAAEA2J4G4o2M4L/zq75WaUMHSFjX7F+gI/FU4sxxwhUhcmG8nvjbBgOzNPhBOsX0DXhA==", "bed4d767-5311-44ae-b33d-aab394db4859" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4b8ce18-51f1-4519-990a-e769a2d467a3", "AQAAAAIAAYagAAAAEHNUIpGgtwdgPU9NUgOA9dA8ZPFIyeDkOv+VLcrfVGnlBbhzajlmDzoZbVRWrPwbaA==", "1bcf82bf-4280-4177-adab-8583c597a3da" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea473367-3ea7-4c9f-b112-e2c837026922", "AQAAAAIAAYagAAAAEMOsR9AgbUzJ+OF8Vz+1c6tITiEjNcTHRaQ7RMiQjT+4kEf/xlbnPOuc+wx79Xtuww==", "381afb43-eb2e-4ced-99c5-791677c8e8f6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "484d719a-60a9-47ae-a432-f0595a03b3e0", "AQAAAAIAAYagAAAAEKnIVVhkra3GPxOph+NF5YqOnjuzQuqNpfg4MU7eCHOJwd9bUzUy0HsidydLShIkTQ==", "395231b0-35dd-4e61-b44d-0fd5e929adb4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "ChatMessages");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a922e60-2ce1-435c-af75-fbf0d3c86e51", "AQAAAAIAAYagAAAAEFa2z99gH2nwhPPni4mcPcXCcrm+zl3zGYX2Ndky+mkSFxe6KvZIbW6jpsfXbmFUbw==", "bd8ec1e0-c614-4b6b-a6db-47d8a4752eaa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44f504e1-1614-4aa9-a0b6-d311a3b926f8", "AQAAAAIAAYagAAAAEE+Foic5zH60aBfEmYKgfW1n1dJLziYxwCLp9bc691cYCb7ntpL8MjkIpq4xL3cR6g==", "f12c3d41-7afb-485c-8002-5f95ca5db44a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49f722bb-8a95-40f6-8f67-0ba6b8cd7c97", "AQAAAAIAAYagAAAAELferrMqtOYiqgVOxvF/9GC/OD1SIAYOEwVVHykZ3TwCy2F7z27EP2p2+2qZUFE2Hw==", "f896e531-3d31-4224-97f2-0a970bac1c8a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84e9f6a5-5a2d-42b2-8288-9e964d5f88af", "AQAAAAIAAYagAAAAEETv5YZrgu9PUS7V7KEtZu8e8QgxJUFvTfxNhLsneIbxqA45F/kqcfxFsGFfgrmoYA==", "700bd7f7-0744-4a50-80aa-9814e74f673a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d798176c-14c1-42aa-ad32-c739835a51b0", "AQAAAAIAAYagAAAAEJVjiq/v8dWXZbG9kq7AZuBicEzDV82ql9zpgaeogwrqPT/vR7EiBRwedYqcSyaY+g==", "e46b886d-b53e-4e5e-94a8-236fc42ecf4d" });
        }
    }
}
