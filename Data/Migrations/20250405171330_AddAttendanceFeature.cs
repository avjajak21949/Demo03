using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo03.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAttendanceFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Course",
                newName: "CourseID");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StudentEnrollment",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentID",
                table: "Meetings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentID",
                table: "Documents",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Course",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CourseCode",
                table: "Course",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreditHours",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Course",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudentNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Course = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    YearOfStudy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Student_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    AttendanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    ClassID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPresent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.AttendanceID);
                    table.ForeignKey(
                        name: "FK_Attendance_Class_ClassID",
                        column: x => x.ClassID,
                        principalTable: "Class",
                        principalColumn: "ClassID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attendance_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf192b91-8070-44a3-bf7c-5469ed67c2ea", "AQAAAAIAAYagAAAAEOPug2vVE0WMwv8p/hZWewBneS9p0hw8bZTKdIjMpWozK1KyBHaUcEsVPi8rOuggUA==", "e9ace0f7-9fb6-47e1-b3af-bb0eed22f3e4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee34c60c-4234-480d-ba4a-88f3b260eec6", "AQAAAAIAAYagAAAAEIttEnUFHZV/3qqRJu5XAcfVyCAMTurpQNSkbvJkRS6dKdzFJPwDgeMkPXyW+b2sOw==", "5f4858d7-60db-4284-8e50-01d7dd5ed32d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e194a8e6-87a6-4110-9f41-6e3d25605b0f", "AQAAAAIAAYagAAAAEEmOF+auoqopaIaKMG5Xe/dVAtIhAeHVOftpl0Jzlxh7CSbwT2n2GsXQgX04q9PYvQ==", "ef7cac97-89f5-4e99-b113-cfa48bde205b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "664e1c35-6209-470e-b7f6-0992beecc828", "AQAAAAIAAYagAAAAECGdJpruvXaONEClUfiBwfUezIYoD2pMGhwCRFic6CxQHiMky51F6g4U63HuJRUIfA==", "b4e5afec-ea5d-4a62-a729-02b344541397" });

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_StudentID",
                table: "Meetings",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_StudentID",
                table: "Documents",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_ClassID",
                table: "Attendance",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_StudentID",
                table: "Attendance",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_UserId",
                table: "Student",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Student_StudentID",
                table: "Documents",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Student_StudentID",
                table: "Meetings",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "StudentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Student_StudentID",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Student_StudentID",
                table: "Meetings");

            migrationBuilder.DropTable(
                name: "Attendance");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Meetings_StudentID",
                table: "Meetings");

            migrationBuilder.DropIndex(
                name: "IX_Documents_StudentID",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "CourseCode",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CreditHours",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Course",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StudentEnrollment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Course",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Course",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
        }
    }
}
