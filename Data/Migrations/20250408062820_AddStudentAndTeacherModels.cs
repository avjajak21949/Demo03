using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo03.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentAndTeacherModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Student_StudentID",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Student_StudentID",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Student_StudentID",
                table: "Meetings");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Meetings_StudentID",
                table: "Meetings");

            migrationBuilder.DropIndex(
                name: "IX_Documents_StudentID",
                table: "Documents");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "Documents");

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "StudentEnrollment",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "StudentClass",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherId",
                table: "Meetings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherId",
                table: "Documents",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherId",
                table: "Class",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StudentID",
                table: "Attendance",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentNumber",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Student_Department",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Student_FullName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Student_Password",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "user0", 0, "c4694df1-d053-48da-ae36-ff5c7ad2eb2c", "IdentityUser", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEEEko3jmfb7PH5kQ98LXo4YHA/UkCibrl2/VuZE7Ql228kzH/zZXgbvar2sK/z3V2A==", null, false, "7b17916f-cba8-42b8-95f9-dd4f6cbd1cb1", false, "admin@gmail.com" },
                    { "user1", 0, "6804b424-5a82-4ec1-8e48-5de83688ef35", "IdentityUser", "student@gmail.com", true, false, null, "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAIAAYagAAAAEAEMHVl8c0/svohuGxnBWHn/6Uha7vSI93sPkb3zzeRZMg+49anLVTXF1gLfDKLWIw==", null, false, "5dd9df40-1db0-4d6a-853b-22e7d5e2453d", false, "student@gmail.com" },
                    { "user2", 0, "54f06cd6-277e-423a-bd37-fea26e13b4b4", "IdentityUser", "employer@gmail.com", true, false, null, "EMPLOYER@GMAIL.COM", "EMPLOYER@GMAIL.COM", "AQAAAAIAAYagAAAAEB8Jrp/9osRg320Pz9HJN5ISgTP4tj/FPTnrxqMC6ObKRw96S1jZDyE+UtOermgR/w==", null, false, "8ed8ae70-2c3b-4d66-ad4f-007236dcf21f", false, "employer@gmail.com" },
                    { "user3", 0, "24ea7168-ba23-46d7-a1de-82a1e731d59e", "IdentityUser", "teacher@gmail.com", true, false, null, "TEACHER@GMAIL.COM", "TEACHER@GMAIL.COM", "AQAAAAIAAYagAAAAEKwgMwWiorXZedvFYu9jInlLxEVnyDGW+rsV/rmOdO9FPrLNldF2DakvKZ9DOd3qeQ==", null, false, "970e2e18-a763-4f5d-b03f-d72da67fc6d2", false, "teacher@gmail.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollment_StudentId",
                table: "StudentEnrollment",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClass_StudentId",
                table: "StudentClass",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_TeacherId",
                table: "Meetings",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_TeacherId",
                table: "Documents",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Class_TeacherId",
                table: "Class",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_AspNetUsers_StudentID",
                table: "Attendance",
                column: "StudentID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Class_AspNetUsers_TeacherId",
                table: "Class",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_AspNetUsers_TeacherId",
                table: "Documents",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_AspNetUsers_TeacherId",
                table: "Meetings",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClass_AspNetUsers_StudentId",
                table: "StudentClass",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEnrollment_AspNetUsers_StudentId",
                table: "StudentEnrollment",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_AspNetUsers_StudentID",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Class_AspNetUsers_TeacherId",
                table: "Class");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_AspNetUsers_TeacherId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_AspNetUsers_TeacherId",
                table: "Meetings");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentClass_AspNetUsers_StudentId",
                table: "StudentClass");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentEnrollment_AspNetUsers_StudentId",
                table: "StudentEnrollment");

            migrationBuilder.DropIndex(
                name: "IX_StudentEnrollment_StudentId",
                table: "StudentEnrollment");

            migrationBuilder.DropIndex(
                name: "IX_StudentClass_StudentId",
                table: "StudentClass");

            migrationBuilder.DropIndex(
                name: "IX_Meetings_TeacherId",
                table: "Meetings");

            migrationBuilder.DropIndex(
                name: "IX_Documents_TeacherId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Class_TeacherId",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "StudentEnrollment");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "StudentClass");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StudentNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Student_Department",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Student_FullName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Student_Password",
                table: "AspNetUsers");

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

            migrationBuilder.AlterColumn<int>(
                name: "StudentID",
                table: "Attendance",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Course = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StudentNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f1dcbd8-df60-4038-9f11-8dfbdc89f08f", "AQAAAAIAAYagAAAAENgP4Jxrb6raGVZ5tUD+7U+wtY/ROdC/nIzdlXEEVEyG0qzc15HK+bEpMTLCi2HNCA==", "c0197b75-6fc2-4bd2-b287-2343e452a13f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a45ebc46-df41-4634-8cbc-fb6f9a344286", "AQAAAAIAAYagAAAAEPydpZqLvPNbAOwiwWRgXBCaInAfF82kmZF9X4DTdeUtf9uU6TlsDcu4hWlwAwGqZA==", "72095bc0-8fc7-4e3c-9e42-81d4306d8c1d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a582bdf-fda6-462b-b1b1-5cfa7a9c562b", "AQAAAAIAAYagAAAAEM38UUKuilp1/fowMfwdxBf6IXCpbNSEs2PG3OhE2HSTQlPhQ3rat6aw5b+djYRopA==", "4d85f1cc-9007-4de3-b5c9-aa67e2eda97f" });

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_StudentID",
                table: "Meetings",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_StudentID",
                table: "Documents",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_UserId",
                table: "Student",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Student_StudentID",
                table: "Attendance",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Restrict);

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
    }
}
