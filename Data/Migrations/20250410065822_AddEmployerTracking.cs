using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo03.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployerTracking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_ManagerId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CreatedByManagerId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "ManagerId",
                table: "Courses",
                newName: "CreatedByEmployerId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_ManagerId",
                table: "Courses",
                newName: "IX_Courses_CreatedByEmployerId");

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "Courses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CourseID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Student_CreatedByEmployerId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e485716-2722-4e52-afd5-9fe2eae7fc99", "AQAAAAIAAYagAAAAEEVh5vYhrG59eG4xrQHb+DP9QZ2yK8brmem57PMvrXLku5GhGCe78+T8bPPterZucA==", "1bc98494-1445-48f5-ac0c-aba3c79eaa04" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ef2a4a8-358f-41ce-b071-c9df10c01782", "AQAAAAIAAYagAAAAEInd2SUprMmuWiFubkG7Xlhfd4R+ZLMgFuTzg+XfM0nG511Dh9QRHdgYFi51ovz83A==", "e9f17961-bbce-4529-a464-ad00c1289012" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22b1c26b-c503-4e4d-91e3-08cf68403e1d", "AQAAAAIAAYagAAAAEPNkD9neJpn4HkWTMqibuIff2iF64tWcK1T8krDPyoKOXYSyN0jMmzFbYGSOHlPJ9w==", "04846c9c-9508-431d-8d18-fec6c134f6c1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "509ae34a-b13e-478c-967a-62e87502bfd7", "AQAAAAIAAYagAAAAEOrR+HpAIfcLKuCR5+EPvcf6TaBvuaZuZgLxCuR6ddSXFwby4Xb6lkHZ1v1TX7vLTA==", "4843c99b-2b2c-4bc8-8535-40ba6b9bd82b" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CourseID",
                table: "AspNetUsers",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Student_CreatedByEmployerId",
                table: "AspNetUsers",
                column: "Student_CreatedByEmployerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_Student_CreatedByEmployerId",
                table: "AspNetUsers",
                column: "Student_CreatedByEmployerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Courses_CourseID",
                table: "AspNetUsers",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_CreatedByEmployerId",
                table: "Courses",
                column: "CreatedByEmployerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_Student_CreatedByEmployerId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Courses_CourseID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_CreatedByEmployerId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CourseID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Student_CreatedByEmployerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Student_CreatedByEmployerId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "CreatedByEmployerId",
                table: "Courses",
                newName: "ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_CreatedByEmployerId",
                table: "Courses",
                newName: "IX_Courses_ManagerId");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByManagerId",
                table: "Courses",
                type: "nvarchar(max)",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_ManagerId",
                table: "Courses",
                column: "ManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
