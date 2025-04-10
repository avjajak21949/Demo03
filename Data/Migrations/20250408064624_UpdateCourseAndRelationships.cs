using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo03.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCourseAndRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Class_AspNetUsers_TeacherId",
                table: "Class");

            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "Course",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Place",
                table: "Course",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CreditHours",
                table: "Course",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CourseCode",
                table: "Course",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Category",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bdd3095d-213e-460a-8311-2419417814c7", "AQAAAAIAAYagAAAAEPUdWxl9KClh70GaKwfwHGakSENFQtVJMMVCgIXB7BTBC3blcaGdIcRh7/VVmvhU9Q==", "60c90d92-0183-4d99-b2af-9b5f0f948232" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce44b410-023d-4c28-b6cc-62c7c53f0a5e", "AQAAAAIAAYagAAAAEDkiaRtDDaj12gN3kCBO/S4bGjGu3Pd10yUo2kgxSWP2BXJBSPlcqDvpS5QA2D1rsA==", "23783a18-e0d7-4866-b09a-c0d2844ef2e3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84bc328b-d8ed-40f4-9976-b6cc5f75dfb8", "AQAAAAIAAYagAAAAEJ1/IPDRaMbEbbrrc0lB4s2WTqMn/H+4Uh0fvU1PwzVtaPV3IIY8Bq0QZvTFxngBLw==", "1aff0e47-876d-47d5-bc6a-5a44455c6008" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ef45d99-0b60-4eeb-b649-b6816016f515", "AQAAAAIAAYagAAAAEGFGI4M3C69Jj2d2TWiFKj88XEK0ME3haEQfso7gfyejvNEVPBZ/cVJRIP1ETzFKYw==", "67955e6d-8da2-48fa-a603-ec87cedee914" });

            migrationBuilder.AddForeignKey(
                name: "FK_Class_AspNetUsers_TeacherId",
                table: "Class",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Class_AspNetUsers_TeacherId",
                table: "Class");

            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "Course",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Place",
                table: "Course",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "CreditHours",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CourseCode",
                table: "Course",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1236a08e-f731-4651-9bef-d80ca4525435", "AQAAAAIAAYagAAAAEORwv6aEvsi/n67n7Nrv5ZJvFFTaHi9gnAxxTLSbDhYrmlZD1faGh/uqGsd8Ra/Rgg==", "c078a01f-8e66-470c-87ea-54397ad418c5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6fcdeb3d-c106-40f8-b4e0-e0e09dbcea0b", "AQAAAAIAAYagAAAAEFc2LipdM+Dcfoqt0mjmSQ4eaN/BhuF7zV5X75TLuxGhmHlDGWKEy8PNB5rypDe94A==", "66add7ca-e5c6-444d-aefd-0e04b3d7064f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cca93c70-64a0-4825-bcd4-758f3725a301", "AQAAAAIAAYagAAAAEIFObx/If3zVgfCtt7b80oRReKUKCST0udLAm2yAd9bKMRqzp45Wd+5JUUh8VukM/w==", "a69ea14b-685b-4594-b7e9-fb1f63412205" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc38ccf9-c4b7-4a31-bc8c-3b2e9fc87788", "AQAAAAIAAYagAAAAENh+bmVKzPv4bTv9fpBt7yfGHpiJs3QI1iJYz5nbBr1ol0EGoD0/llp8jTT6uboo4Q==", "03603ab6-311a-44c8-9483-ecbebc8e2452" });

            migrationBuilder.AddForeignKey(
                name: "FK_Class_AspNetUsers_TeacherId",
                table: "Class",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
