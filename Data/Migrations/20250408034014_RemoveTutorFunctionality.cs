using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo03.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTutorFunctionality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "role1", "user2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "role1", "user3" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "role3", "user4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "role2", null, "Employer", "EMPLOYER" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "role3", "user3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "00f43daf-876c-4dd1-8590-1b03cfdc515f", "AQAAAAIAAYagAAAAEPnEs/RjC1D3Oq1pqaQhuh22yIBARzZaL2dC/dFsIJPX6D6oWsUZ81LAODc/TtpPWA==", "970d8a07-feba-4f5a-83d5-f1c6ece52a3e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "6f1dcbd8-df60-4038-9f11-8dfbdc89f08f", "student@gmail.com", "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAIAAYagAAAAENgP4Jxrb6raGVZ5tUD+7U+wtY/ROdC/nIzdlXEEVEyG0qzc15HK+bEpMTLCi2HNCA==", "c0197b75-6fc2-4bd2-b287-2343e452a13f", "student@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "a45ebc46-df41-4634-8cbc-fb6f9a344286", "employer@gmail.com", "EMPLOYER@GMAIL.COM", "EMPLOYER@GMAIL.COM", "AQAAAAIAAYagAAAAEPydpZqLvPNbAOwiwWRgXBCaInAfF82kmZF9X4DTdeUtf9uU6TlsDcu4hWlwAwGqZA==", "72095bc0-8fc7-4e3c-9e42-81d4306d8c1d", "employer@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "9a582bdf-fda6-462b-b1b1-5cfa7a9c562b", "teacher@gmail.com", "TEACHER@GMAIL.COM", "TEACHER@GMAIL.COM", "AQAAAAIAAYagAAAAEM38UUKuilp1/fowMfwdxBf6IXCpbNSEs2PG3OhE2HSTQlPhQ3rat6aw5b+djYRopA==", "4d85f1cc-9007-4de3-b5c9-aa67e2eda97f", "teacher@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "role2", "user2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "role2", "user2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "role3", "user3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role2");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "role1", "user2" },
                    { "role1", "user3" }
                });

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
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "864c7621-604b-4951-b549-7c2869173c05", "student1@gmail.com", "STUDENT1@GMAIL.COM", "STUDENT1@GMAIL.COM", "AQAAAAIAAYagAAAAEA2J4G4o2M4L/zq75WaUMHSFjX7F+gI/FU4sxxwhUhcmG8nvjbBgOzNPhBOsX0DXhA==", "bed4d767-5311-44ae-b33d-aab394db4859", "student1@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "b4b8ce18-51f1-4519-990a-e769a2d467a3", "student2@gmail.com", "STUDENT2@GMAIL.COM", "STUDENT2@GMAIL.COM", "AQAAAAIAAYagAAAAEHNUIpGgtwdgPU9NUgOA9dA8ZPFIyeDkOv+VLcrfVGnlBbhzajlmDzoZbVRWrPwbaA==", "1bcf82bf-4280-4177-adab-8583c597a3da", "student2@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "ea473367-3ea7-4c9f-b112-e2c837026922", "student3@gmail.com", "STUDENT3@GMAIL.COM", "STUDENT3@GMAIL.COM", "AQAAAAIAAYagAAAAEMOsR9AgbUzJ+OF8Vz+1c6tITiEjNcTHRaQ7RMiQjT+4kEf/xlbnPOuc+wx79Xtuww==", "381afb43-eb2e-4ced-99c5-791677c8e8f6", "student3@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "user4", 0, "484d719a-60a9-47ae-a432-f0595a03b3e0", "teacher@gmail.com", true, false, null, "TEACHER@GMAIL.COM", "TEACHER@GMAIL.COM", "AQAAAAIAAYagAAAAEKnIVVhkra3GPxOph+NF5YqOnjuzQuqNpfg4MU7eCHOJwd9bUzUy0HsidydLShIkTQ==", null, false, "395231b0-35dd-4e61-b44d-0fd5e929adb4", false, "teacher@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "role3", "user4" });
        }
    }
}
