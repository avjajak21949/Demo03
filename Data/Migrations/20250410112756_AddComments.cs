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
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "role0", "user0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user0");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DocumentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Documents_DocumentID",
                        column: x => x.DocumentID,
                        principalTable: "Documents",
                        principalColumn: "DocumentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role2",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Manager", "MANAGER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d760caf7-8898-4aac-80a3-b45c950fd1d4", "AQAAAAIAAYagAAAAEBAi6gw2aV0V442ZX3CXO39R24ICHN3zLIUNOQeuT1q4ogEUDRwMLu5plQe6PD/Zwg==", "cdf3f423-acdd-4931-9790-c83334f9a88d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "77d20c2a-04dc-4440-abee-539df55a7636", "manager@gmail.com", "MANAGER@GMAIL.COM", "MANAGER@GMAIL.COM", "AQAAAAIAAYagAAAAELcSmXQLrpaNlaULBCqQdYLZ/4BhaoaJjT18MhDKuHwaL60t/rJao4azZwOKqGVipg==", "0c292ea1-f81c-4019-907c-b2254caa616f", "manager@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3919078d-1720-430e-ac82-47d846bba32a", "AQAAAAIAAYagAAAAENrhEFHZlWjSL6KTHo1oyp6cOYpKX4wNfye9jw+WtywHUIIO8DONLSDcmqBqvLcFuA==", "0e6a1c21-e357-42a2-94b7-398fd8d83e1a" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_DocumentID",
                table: "Comments",
                column: "DocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserID",
                table: "Comments",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role2",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Employer", "EMPLOYER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "role0", null, "Administrator", "ADMINISTRATOR" });

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
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "22b1c26b-c503-4e4d-91e3-08cf68403e1d", "employer@gmail.com", "EMPLOYER@GMAIL.COM", "EMPLOYER@GMAIL.COM", "AQAAAAIAAYagAAAAEPNkD9neJpn4HkWTMqibuIff2iF64tWcK1T8krDPyoKOXYSyN0jMmzFbYGSOHlPJ9w==", "04846c9c-9508-431d-8d18-fec6c134f6c1", "employer@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "509ae34a-b13e-478c-967a-62e87502bfd7", "AQAAAAIAAYagAAAAEOrR+HpAIfcLKuCR5+EPvcf6TaBvuaZuZgLxCuR6ddSXFwby4Xb6lkHZ1v1TX7vLTA==", "4843c99b-2b2c-4bc8-8535-40ba6b9bd82b" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "user0", 0, "9e485716-2722-4e52-afd5-9fe2eae7fc99", "IdentityUser", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEEVh5vYhrG59eG4xrQHb+DP9QZ2yK8brmem57PMvrXLku5GhGCe78+T8bPPterZucA==", null, false, "1bc98494-1445-48f5-ac0c-aba3c79eaa04", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "role0", "user0" });
        }
    }
}
