using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo03.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDocumentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    UploadedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClassID = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    Category = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentID);
                    table.ForeignKey(
                        name: "FK_Documents_AspNetUsers_UploadedByUserId",
                        column: x => x.UploadedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Documents_Class_ClassID",
                        column: x => x.ClassID,
                        principalTable: "Class",
                        principalColumn: "ClassID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Documents_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role0",
                column: "ConcurrencyStamp",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role1",
                column: "ConcurrencyStamp",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role2",
                column: "ConcurrencyStamp",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role3",
                column: "ConcurrencyStamp",
                value: null);

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

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ClassID",
                table: "Documents",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_CourseID",
                table: "Documents",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_UploadedByUserId",
                table: "Documents",
                column: "UploadedByUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role0",
                column: "ConcurrencyStamp",
                value: "9fe14023-c8e3-437d-94c6-0d1167a28997");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role1",
                column: "ConcurrencyStamp",
                value: "fcbf9000-fbbe-49d6-a586-f3928232abfc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role2",
                column: "ConcurrencyStamp",
                value: "fbaf13cc-b6c9-46f7-884a-84cee2253ddf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role3",
                column: "ConcurrencyStamp",
                value: "da52f2cd-43e0-4ae2-af95-3eb366eb837a");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7670b60-7254-4f13-b3b9-26f454295c28", "AQAAAAEAACcQAAAAEDFO5TIgSLYRgoRKhvtP/tLFB8eKDf2C6fAUAodOa1iFZVUsnzxFaqJhV7BfNM8sTQ==", "4e467427-9eb8-42d9-9d53-1c122bf5cb0c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9364b88-202a-4a3b-98dc-28d0d2eea0b5", "AQAAAAEAACcQAAAAEHOyRaOYgUUdUuYH/Cs3hpry7eBQMifQK+Vr48a0w5jHy23T77mYwzqQ7lzG6MgPvA==", "18cb4306-d325-4356-b896-92334382b6db" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bfc59e8e-968f-4546-9e14-353dd4d398dc", "AQAAAAEAACcQAAAAEBtVxQP7y6WDZ0AP+lDqeHyW/1k2u6wlmVh0yzXI0kYOEkepq1BiA5UgT0DACmUniQ==", "b7f5c3f6-24e7-421c-9533-41ce93f617d5" });
        }
    }
}
