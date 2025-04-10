using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo03.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveApprovalAndUpdateCourseModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Courses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Courses",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Place",
                table: "Courses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Courses",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreditHours",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e5805c0-5fcd-4511-a149-5f09b8e4cecc", "AQAAAAIAAYagAAAAEEH2bTQzhAljNyeodRDIu81CPRqwnK8HAV+T2oGjhHU1bs5kLIrRIkHwIa8yEhfLWQ==", "355532b4-f416-4ea6-9a42-92aa727e53fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b41248d-d56b-4ffb-862f-9e8e8799645c", "AQAAAAIAAYagAAAAEFJZHFpiCP0GSGIZIExVsHXSBAXKgct1uyrr2WrKik4RCTRugisURWVKoMwPFrSIIA==", "6cdfa869-d76e-41d9-9a9f-761617c1e430" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c3754f2e-b9d2-44d7-9d9b-75158a4e610b", "AQAAAAIAAYagAAAAEDZw6/f+MXpusCGHIBOzW3WmO372t9+guwBY+/oBuleOaRwyDWR8Fruy/cJlT5lqpA==", "baa55358-561c-45a6-becb-f6d0ae8cc727" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa05394e-7af5-4a24-9b6a-39f28532cff9", "AQAAAAIAAYagAAAAEIGHUX1/9ulcBN+tux5xeQDTOvJ+q7g/itnMYQNwncP+J0rGhCfS2hNFTkeE+94SrQ==", "f200e035-1b86-4f16-a06e-eca27cbb9d23" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "Courses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Courses",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Place",
                table: "Courses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Courses",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<int>(
                name: "CreditHours",
                table: "Courses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5fdc1086-d1d1-4f8e-84f3-6c694532d3a7", "AQAAAAIAAYagAAAAEMIY8tyDbnSJo786HNt7rg/YaAIlkHmdsmBmrgdTcZZESYeHBI5aho7/w4JHjCjiKA==", "75e9abf9-37d0-4e0e-bde5-d4ee1b6574a8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2edbab8b-7873-4801-ab91-6dee0f05e2c2", "AQAAAAIAAYagAAAAELEHzn5abMeDxOqy9MK5NIVAyO+WAUb2ZF1SRSW9IIsVAK0Kn/z4340G2YcyDZhm/Q==", "6c3255d7-051f-494d-892c-d6ba6d7c53bd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4cb79b8-730b-4778-b6c5-4cf3b886bb6c", "AQAAAAIAAYagAAAAEMSnMrEmX+jGnp8dt7gPxf0ZIHeijLlldpoH9g0ElwPzWTWErU8aB5YRIRad6Al/Sw==", "e2675fbf-1146-4134-9189-0c891ea2afe4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "603b821f-82d4-4bed-84ea-27dcd1b0e668", "AQAAAAIAAYagAAAAEEMJEE+Ao5M2ogYefGGB98JOZwFvpdL9jDTQs2DRF9ONdm89OW8PzB1wr9tfBRmvAQ==", "55f5f83b-bbef-4122-a2fc-f63c2041a584" });
        }
    }
}
