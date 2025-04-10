using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo03.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_Comments_Documents_DocumentID",
                        column: x => x.DocumentID,
                        principalTable: "Documents",
                        principalColumn: "DocumentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "641a4523-fa49-4715-9aae-dc554e83ca5d", "AQAAAAIAAYagAAAAEBbWuHKC4TX1bGHZyRWE6ANOSs8B/nxhw+C0AykgZL4yP1LmX0o7NkNMUJZRX+TcPA==", "a58a3ec9-4a30-4730-95f8-b2ecaca1cb18" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f102c7ce-930e-4e07-b6eb-669341f534bc", "AQAAAAIAAYagAAAAEGvwTx7ehamvVegMd467A33CxrUF600GKfMfB16+JVFnbYHAIUZo0bfX0kcrvnBJVw==", "4f2eb6a8-f1e8-4744-b9c9-a60a1ab9b9e9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b719499a-7bdd-4a0c-afda-f861a689060d", "AQAAAAIAAYagAAAAEIXBSQl8W6mYrRXHrSFjYL65J6ph744qO4ZGAHVeYfuNjJo9DhdGZE/GknRIvQ1WYQ==", "a2dbebaf-be76-4939-b74e-d8377e645dff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa37074e-688c-40ff-bf15-628f53882dad", "AQAAAAIAAYagAAAAEG85ngWMl9NvU8MUCK1MNz9rE1djbZWuYGw+QvHqlom5NQobZ1aHxVXNfrB8YVJ2gw==", "d075a75d-d231-4cc3-809d-ecb012623794" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_DocumentID",
                table: "Comments",
                column: "DocumentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "deb11211-62c9-405b-a7f8-51ba9c581676", "AQAAAAIAAYagAAAAEP6HPUaGkaUogKoQV38NHR9I5roJ352vptL6RBfeUXT6M4jv9IgrpJ/DpbgKooFxpg==", "f07f708f-7652-4ffd-bf83-f54f77445945" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "91a8c8ac-0082-4636-b7f8-2993de5fb1b5", "AQAAAAIAAYagAAAAEIWoRszmAraYoHCL/Qt9hgRFFPBUqXvfLwDzyK2d4kJuH7FF9Kt8YH3wACry5EbOzg==", "a86a4a63-0c6f-4404-b325-f5ee9d77e2c5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3046b033-f98a-473e-8354-1f520354ccc5", "AQAAAAIAAYagAAAAEEPun3qH1EROVQmJOx7LNQOYx596zl1coVTR9WHlV6BirZ9W95tvf+r0FOrD4zVHng==", "f02ddde6-23be-415e-854d-d2079f5d76e3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7429740b-10d8-47a8-83cc-12bc6587e1c1", "AQAAAAIAAYagAAAAEMYhC9BjrHnelO4vY6X81QAaHcVlV9N6plrdRgqeQbCR6ScIV4pN0eE5HzCT3x7SsQ==", "78b1e08d-ca60-4465-8f25-cb3fa6d0f61d" });
        }
    }
}
