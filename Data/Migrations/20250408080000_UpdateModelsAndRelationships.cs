using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo03.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelsAndRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_AspNetUsers_StudentID",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Class_ClassID",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Class_AspNetUsers_TeacherId",
                table: "Class");

            migrationBuilder.DropForeignKey(
                name: "FK_Class_Course_CourseID",
                table: "Class");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Category_CategoryID",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Class_ClassID",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Course_CourseID",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Class_ClassID",
                table: "Meetings");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Class_ClassID",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentClass_AspNetUsers_StudentId",
                table: "StudentClass");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentClass_Class_ClassID",
                table: "StudentClass");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentClass_StudentEnrollment_SEID",
                table: "StudentClass");

            migrationBuilder.DropTable(
                name: "StudentEnrollment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentClass",
                table: "StudentClass");

            migrationBuilder.DropIndex(
                name: "IX_StudentClass_SEID",
                table: "StudentClass");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Class",
                table: "Class");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "SEID",
                table: "StudentClass");

            migrationBuilder.RenameTable(
                name: "StudentClass",
                newName: "StudentClasses");

            migrationBuilder.RenameTable(
                name: "Schedule",
                newName: "Schedules");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameTable(
                name: "Class",
                newName: "Classes");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "Attendance",
                newName: "Attendances");

            migrationBuilder.RenameIndex(
                name: "IX_StudentClass_StudentId",
                table: "StudentClasses",
                newName: "IX_StudentClasses_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentClass_ClassID",
                table: "StudentClasses",
                newName: "IX_StudentClasses_ClassID");

            migrationBuilder.RenameIndex(
                name: "IX_Schedule_ClassID",
                table: "Schedules",
                newName: "IX_Schedules_ClassID");

            migrationBuilder.RenameIndex(
                name: "IX_Course_CategoryID",
                table: "Courses",
                newName: "IX_Courses_CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Class_TeacherId",
                table: "Classes",
                newName: "IX_Classes_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Class_CourseID",
                table: "Classes",
                newName: "IX_Classes_CourseID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Attendance_StudentID",
                table: "Attendances",
                newName: "IX_Attendances_StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_Attendance_ClassID",
                table: "Attendances",
                newName: "IX_Attendances_ClassID");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "StudentClasses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentClasses",
                table: "StudentClasses",
                column: "StudentClassID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules",
                column: "ScheduleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "CourseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classes",
                table: "Classes",
                column: "ClassID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances",
                column: "AttendanceID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_AspNetUsers_StudentID",
                table: "Attendances",
                column: "StudentID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Classes_ClassID",
                table: "Attendances",
                column: "ClassID",
                principalTable: "Classes",
                principalColumn: "ClassID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_AspNetUsers_TeacherId",
                table: "Classes",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Courses_CourseID",
                table: "Classes",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Categories_CategoryID",
                table: "Courses",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Classes_ClassID",
                table: "Documents",
                column: "ClassID",
                principalTable: "Classes",
                principalColumn: "ClassID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Courses_CourseID",
                table: "Documents",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Classes_ClassID",
                table: "Meetings",
                column: "ClassID",
                principalTable: "Classes",
                principalColumn: "ClassID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Classes_ClassID",
                table: "Schedules",
                column: "ClassID",
                principalTable: "Classes",
                principalColumn: "ClassID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClasses_AspNetUsers_StudentId",
                table: "StudentClasses",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClasses_Classes_ClassID",
                table: "StudentClasses",
                column: "ClassID",
                principalTable: "Classes",
                principalColumn: "ClassID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_AspNetUsers_StudentID",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Classes_ClassID",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_AspNetUsers_TeacherId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Courses_CourseID",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Categories_CategoryID",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Classes_ClassID",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Courses_CourseID",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Classes_ClassID",
                table: "Meetings");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Classes_ClassID",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentClasses_AspNetUsers_StudentId",
                table: "StudentClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentClasses_Classes_ClassID",
                table: "StudentClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentClasses",
                table: "StudentClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classes",
                table: "Classes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "Schedules");

            migrationBuilder.RenameTable(
                name: "StudentClasses",
                newName: "StudentClass");

            migrationBuilder.RenameTable(
                name: "Schedules",
                newName: "Schedule");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameTable(
                name: "Classes",
                newName: "Class");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "Attendances",
                newName: "Attendance");

            migrationBuilder.RenameIndex(
                name: "IX_StudentClasses_StudentId",
                table: "StudentClass",
                newName: "IX_StudentClass_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentClasses_ClassID",
                table: "StudentClass",
                newName: "IX_StudentClass_ClassID");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_ClassID",
                table: "Schedule",
                newName: "IX_Schedule_ClassID");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_CategoryID",
                table: "Course",
                newName: "IX_Course_CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Classes_TeacherId",
                table: "Class",
                newName: "IX_Class_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Classes_CourseID",
                table: "Class",
                newName: "IX_Class_CourseID");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Category",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_StudentID",
                table: "Attendance",
                newName: "IX_Attendance_StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_ClassID",
                table: "Attendance",
                newName: "IX_Attendance_ClassID");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "StudentClass",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "SEID",
                table: "StudentClass",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentClass",
                table: "StudentClass",
                column: "StudentClassID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule",
                column: "ScheduleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "CourseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Class",
                table: "Class",
                column: "ClassID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance",
                column: "AttendanceID");

            migrationBuilder.CreateTable(
                name: "StudentEnrollment",
                columns: table => new
                {
                    SEID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentEnrollment", x => x.SEID);
                    table.ForeignKey(
                        name: "FK_StudentEnrollment_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_StudentClass_SEID",
                table: "StudentClass",
                column: "SEID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollment_StudentId",
                table: "StudentEnrollment",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_AspNetUsers_StudentID",
                table: "Attendance",
                column: "StudentID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Class_ClassID",
                table: "Attendance",
                column: "ClassID",
                principalTable: "Class",
                principalColumn: "ClassID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Class_AspNetUsers_TeacherId",
                table: "Class",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Class_Course_CourseID",
                table: "Class",
                column: "CourseID",
                principalTable: "Course",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Category_CategoryID",
                table: "Course",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Class_ClassID",
                table: "Documents",
                column: "ClassID",
                principalTable: "Class",
                principalColumn: "ClassID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Course_CourseID",
                table: "Documents",
                column: "CourseID",
                principalTable: "Course",
                principalColumn: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Class_ClassID",
                table: "Meetings",
                column: "ClassID",
                principalTable: "Class",
                principalColumn: "ClassID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Class_ClassID",
                table: "Schedule",
                column: "ClassID",
                principalTable: "Class",
                principalColumn: "ClassID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClass_AspNetUsers_StudentId",
                table: "StudentClass",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClass_Class_ClassID",
                table: "StudentClass",
                column: "ClassID",
                principalTable: "Class",
                principalColumn: "ClassID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClass_StudentEnrollment_SEID",
                table: "StudentClass",
                column: "SEID",
                principalTable: "StudentEnrollment",
                principalColumn: "SEID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
