using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo03.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMeetingsFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    MeetingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MeetingLink = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HostUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClassID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.MeetingID);
                    table.ForeignKey(
                        name: "FK_Meetings_AspNetUsers_HostUserId",
                        column: x => x.HostUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meetings_Class_ClassID",
                        column: x => x.ClassID,
                        principalTable: "Class",
                        principalColumn: "ClassID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f3b0be9-47d5-401f-9fe6-b93500b9be8a", "AQAAAAIAAYagAAAAEOegcJmwlAPS2gLhWNvwUm/Wq3fCF5U5cfm/x+BkPgcvlU0qry239cvmjEPyPnMH3g==", "b397bb8f-7414-449b-8095-e5103ccaa565" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f32ad85-b26c-474e-a96e-38b68b043412", "AQAAAAIAAYagAAAAEEJNlazSjCEoiCNaCPMy5tifOg6u1IBMWwIFizUGSqXGG70sohLTQMY469sKYa45hw==", "9a9b6d61-dda2-4ae2-89b8-5f18379ddf96" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "366c3a0a-2d82-42f3-aaac-bbcaabb4db7d", "AQAAAAIAAYagAAAAEGlKi+O3le7ak5VhBdljC8kcPzLVkCSEmsWDj4Az0tCyMnT4XQ8M9l+HSsybBb9eSQ==", "7d1f4e75-5020-418a-8db5-d277bccc41bc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ec8c63f-ecde-4749-b2cd-a7d7d5b78c64", "AQAAAAIAAYagAAAAEIU7ik8XWRseQIh3qYCzS/frgxKzU9K/YOqCP3p43zAGp++jfZ6Xfk+QERfHcC3hgw==", "a49103fe-d7b6-4d7a-9d50-d339f388f540" });

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_ClassID",
                table: "Meetings",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_HostUserId",
                table: "Meetings",
                column: "HostUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1380f763-2863-4015-a83a-20c6b7c9aea9", "AQAAAAIAAYagAAAAEEravJ1QJ7bW5vEmuAC0+eYr9lVInZXZuei5okrN8e79/rGx+wVHTbfxZbTUaAdUTg==", "d44eab03-dc94-45d7-b7ba-d97447dd0f21" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5597493-56dd-4a7d-a615-557e68498261", "AQAAAAIAAYagAAAAEKzagZUY5UQu79ijY90v3ZJT6+B/GP/6hmiJ6zNpB2wf/G7vAHxeOG+CZD57gZfVIA==", "66f46eef-f71a-4421-9590-0cb2dde6d6d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c13acac6-ceb8-48ad-9a85-ca67b6190674", "AQAAAAIAAYagAAAAEDRz7FfCmjDKvW5qDlADzSRz+57vyEbmw7Zsvcg+NMQkS60bqW1En6K267A1BfCHgA==", "ed4c7d1c-ba7b-4323-ac34-3884132da51f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e753a5b-65d8-4c20-98a9-93dd193cb882", "AQAAAAIAAYagAAAAEAyfjJk2Pm0NZgcUY0BLUxKiL8MmIJuQ7xAOUSJj4xCXSJWqhfNkG/GJgQdOiIhkZQ==", "141817b8-d7c2-4cde-8d74-fb6a8aab0101" });
        }
    }
}
