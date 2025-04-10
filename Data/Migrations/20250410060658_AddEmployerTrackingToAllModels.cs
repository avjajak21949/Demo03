using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo03.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployerTrackingToAllModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedByManagerId",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByEmployerId",
                table: "Classes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByEmployerId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50e03010-a604-4097-acfe-340c72214b8d", "AQAAAAIAAYagAAAAECVfIkhSFKFpPEvCJxAXNU8YLWjUqx9ZzsvE/DAzSnp0iE8B6sDXgd0t6GfwE+/ovg==", "ba71c489-b8fb-430c-b9e9-2065a8c71e5b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e948995a-8a13-4f54-8aa8-52ba3d4b87a7", "AQAAAAIAAYagAAAAEPLXQIIRoAWmhxtmYRmK1qbg3g2ZlQMqjKvMczeG7iYOskZZvIeAcAzpu1wq/J7VbQ==", "d65c786e-d1e6-4fa8-823b-e2571f3d08f8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7eb53f83-5056-43a6-9ac4-49651eb2f3f0", "AQAAAAIAAYagAAAAEKq7xaYW5rYtwSox5cemMq9ZTLZ2WrAnwRLpXtuR9SQJnpgLy2xNjL8Im2tDJE0qsA==", "2e32754d-85ab-49a4-8c48-88c60c4fcd85" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77cf1d13-6b89-40fe-862c-12c541aed95a", "AQAAAAIAAYagAAAAEBSzA5tRMgsldD64uOB/znU/OklH6oIlavV1ZvM72ICuADv5XG3QGDZWoDNJawzTBw==", "5334ea29-a1e2-45ea-97c8-5637941669a7" });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ManagerId",
                table: "Courses",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_CreatedByEmployerId",
                table: "Classes",
                column: "CreatedByEmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CreatedByEmployerId",
                table: "AspNetUsers",
                column: "CreatedByEmployerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_CreatedByEmployerId",
                table: "AspNetUsers",
                column: "CreatedByEmployerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_AspNetUsers_CreatedByEmployerId",
                table: "Classes",
                column: "CreatedByEmployerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_ManagerId",
                table: "Courses",
                column: "ManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_CreatedByEmployerId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_AspNetUsers_CreatedByEmployerId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_ManagerId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_ManagerId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Classes_CreatedByEmployerId",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CreatedByEmployerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreatedByManagerId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CreatedByEmployerId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "CreatedByEmployerId",
                table: "AspNetUsers");

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
