using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo03.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ScheduleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassID = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    DaysOfWeek = table.Column<string>(nullable: false),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    AvailableSeats = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ScheduleID);
                    table.ForeignKey(
                        name: "FK_Schedule_Class_ClassID",
                        column: x => x.ClassID,
                        principalTable: "Class",
                        principalColumn: "ClassID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role0",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9fe14023-c8e3-437d-94c6-0d1167a28997", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role1",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fcbf9000-fbbe-49d6-a586-f3928232abfc", "Student", "STUDENT" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role2",
                column: "ConcurrencyStamp",
                value: "fbaf13cc-b6c9-46f7-884a-84cee2253ddf");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "role3", "da52f2cd-43e0-4ae2-af95-3eb366eb837a", "Teacher", "TEACHER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0be8d23d-2a8b-4179-a12f-0348ae20ac33", "AQAAAAEAACcQAAAAEOTOHUBDf9sTxJcBzsE20xCW5ucvC3Dc2RX457NmtiLK2/a3wE/Fs9nWRoUQG7gCZg==", "24bcbcb2-1534-4287-bf69-d5b3b5d09e76" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "b7670b60-7254-4f13-b3b9-26f454295c28", "student@gmail.com", "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAEAACcQAAAAEDFO5TIgSLYRgoRKhvtP/tLFB8eKDf2C6fAUAodOa1iFZVUsnzxFaqJhV7BfNM8sTQ==", "4e467427-9eb8-42d9-9d53-1c122bf5cb0c", "student@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9364b88-202a-4a3b-98dc-28d0d2eea0b5", "AQAAAAEAACcQAAAAEHOyRaOYgUUdUuYH/Cs3hpry7eBQMifQK+Vr48a0w5jHy23T77mYwzqQ7lzG6MgPvA==", "18cb4306-d325-4356-b896-92334382b6db" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "user3", 0, "bfc59e8e-968f-4546-9e14-353dd4d398dc", "teacher@gmail.com", true, false, null, "TEACHER@GMAIL.COM", "TEACHER@GMAIL.COM", "AQAAAAEAACcQAAAAEBtVxQP7y6WDZ0AP+lDqeHyW/1k2u6wlmVh0yzXI0kYOEkepq1BiA5UgT0DACmUniQ==", null, false, "b7f5c3f6-24e7-421c-9533-41ce93f617d5", false, "teacher@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "user3", "role3" });

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_ClassID",
                table: "Schedule",
                column: "ClassID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "user3", "role3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role0",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "98aa31c4-8ce7-4c61-a037-d6dfe5de675a", "Adminstator", "ADMINSTRATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role1",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0b9a8064-bf16-48c3-aee0-5fc6bf50cf13", "Jobseeker", "JOBSEEKER" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role2",
                column: "ConcurrencyStamp",
                value: "6def6636-938d-4b34-88a9-df6617ade0e7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36b233f4-794f-4df2-a35d-e170043bd7a8", "AQAAAAEAACcQAAAAELSq+Wrfljta8lTv1+c+66YgqxM5+GR9FzFKVPpw64aYc8za3b7jDaErBiHUyeUL5w==", "1d41f9f6-c203-45b9-9afb-c1afad2508e7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "6991ada3-2cf9-47f4-96a1-94b37051fc39", "jobseeker@gmail.com", "JOBSEEKER@GMAIL.COM", "JOBSEEKER@GMAIL.COM", "AQAAAAEAACcQAAAAEG0Afmy7RD0VO2yb0xmy7Ke8yMRAfgNcnRYrAOZbNFPXGVYZcfdTiUa8qcccJh77Qg==", "1495ae2b-ff5f-43f0-9d32-c60635888093", "jobseeker@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72f77798-ae61-4842-b7f1-69df045b9266", "AQAAAAEAACcQAAAAEC7oxkQBpR4TviBxZUeo1zITI+Ffv19deFG4JSKQ0vPSUdRLzwystKeq6PY7BlLSJw==", "559de346-8b19-49e1-b639-02f48c342b17" });
        }
    }
}
