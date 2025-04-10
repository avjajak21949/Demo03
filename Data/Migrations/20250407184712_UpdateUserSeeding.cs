using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo03.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "3de97dd0-6b7a-4774-8568-582ce0c3b2d5", "AQAAAAIAAYagAAAAEANIQLoDsysRczmBc27La9KY3oCtNzsG58g0weIiPK8N0sVTqIf4k4X2B7zQKEzhyQ==", "0c39a8fa-a3bd-4a16-9e48-956d0c8a34c6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "9bf8fc1c-cc0f-4457-814e-3c851cd6646b", "student1@gmail.com", "STUDENT1@GMAIL.COM", "STUDENT1@GMAIL.COM", "AQAAAAIAAYagAAAAEHGv2r8NyDBg9hdwLX21eroSjpk3K/Rm7UUg2DbFeaPIEsH7D0XOTBc6psNMlGltng==", "979cd9b1-74b0-4fc4-9787-762eb8b6b90b", "student1@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "4a5dc2d9-0410-4241-8919-57940a7ef62d", "student2@gmail.com", "STUDENT2@GMAIL.COM", "STUDENT2@GMAIL.COM", "AQAAAAIAAYagAAAAEOxF4TJ3g1+dpGC777RqjAMwHd4vznmvnMSiEVN7jVqQPoebSFQr+ts1zX71B23+wQ==", "d6b090f9-52e5-4056-9e00-51d826c2de7a", "student2@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "6d818fb5-c892-41f5-8c98-9af16139ff7b", "student3@gmail.com", "STUDENT3@GMAIL.COM", "STUDENT3@GMAIL.COM", "AQAAAAIAAYagAAAAEHBVWAD7wFVVcPxB/AJxCv33H7CyEZcMt40udSy61AXlIbioD0jwk1RADpdMxM5c3g==", "2c099333-3206-448d-8b8a-4ad3c3b29abf", "student3@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "user4", 0, "09b14979-5037-423f-b562-ec16be66bbaa", "teacher@gmail.com", true, false, null, "TEACHER@GMAIL.COM", "TEACHER@GMAIL.COM", "AQAAAAIAAYagAAAAEPzGO1b7uEgJ8wLUWwh/trMWXH5H2MwjQ1G/QJuVtHeJXU9O2U2zRUAc3HU94jLsEg==", null, false, "e5bb0c49-a07c-4802-bb60-7396b8cb60d4", false, "teacher@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "role3", "user4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "c631967f-29c3-4fc9-bfd5-dbe8dbb259af", "AQAAAAIAAYagAAAAEBXb6+ArIP0zlJIZyqw3M93gpzG+XCWHgAvQ1hWoCx1ARHFvCRPYzHkEtc3VMTwlHw==", "012feb2c-c937-43c6-92c9-42c73a6e5b0d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "8337a5c7-d7fb-4bdb-a987-9558ee1c4b68", "student@gmail.com", "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAIAAYagAAAAEKulVJk+t7UX82HZoDoi81MBwzH12S05s0dCmuMrhJjsG5zwLlbTHVTSg/+xw2jIrA==", "7744f6d2-5c41-4fb7-aa03-244fd96b46fd", "student@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "463133a5-e809-4cc2-bc95-66c6727d251e", "employer@gmail.com", "EMPLOYER@GMAIL.COM", "EMPLOYER@GMAIL.COM", "AQAAAAIAAYagAAAAEPDMXm9cZzl6EZ0k2CZ3o9fdKUZmVL/O2Mcbh6qkumjV0Px0iqj5GEdsL473HUE60Q==", "a53b8f70-4816-4245-b56e-a291719875f1", "employer@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "93fc9ffb-b115-4fc1-9810-422d9783daa7", "teacher@gmail.com", "TEACHER@GMAIL.COM", "TEACHER@GMAIL.COM", "AQAAAAIAAYagAAAAEKKxjHjHWOFTgFon+xDtG0K82U0K2unUJMvdaJvEzVPcJdFMLYgTRxtBtZ1F7UhcZA==", "00047344-cc72-46bb-903f-1150de6c61f6", "teacher@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "role2", "user2" });
        }
    }
}
