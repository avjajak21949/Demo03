using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo03.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTeacherToClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Class_AspNetUsers_TeacherId",
                table: "Class");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherId",
                table: "Class",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ScheduleInfo",
                table: "Class",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Class",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Class_AspNetUsers_TeacherId",
                table: "Class");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherId",
                table: "Class",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ScheduleInfo",
                table: "Class",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Class",
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
                values: new object[] { "c4694df1-d053-48da-ae36-ff5c7ad2eb2c", "AQAAAAIAAYagAAAAEEEko3jmfb7PH5kQ98LXo4YHA/UkCibrl2/VuZE7Ql228kzH/zZXgbvar2sK/z3V2A==", "7b17916f-cba8-42b8-95f9-dd4f6cbd1cb1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6804b424-5a82-4ec1-8e48-5de83688ef35", "AQAAAAIAAYagAAAAEAEMHVl8c0/svohuGxnBWHn/6Uha7vSI93sPkb3zzeRZMg+49anLVTXF1gLfDKLWIw==", "5dd9df40-1db0-4d6a-853b-22e7d5e2453d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54f06cd6-277e-423a-bd37-fea26e13b4b4", "AQAAAAIAAYagAAAAEB8Jrp/9osRg320Pz9HJN5ISgTP4tj/FPTnrxqMC6ObKRw96S1jZDyE+UtOermgR/w==", "8ed8ae70-2c3b-4d66-ad4f-007236dcf21f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24ea7168-ba23-46d7-a1de-82a1e731d59e", "AQAAAAIAAYagAAAAEKwgMwWiorXZedvFYu9jInlLxEVnyDGW+rsV/rmOdO9FPrLNldF2DakvKZ9DOd3qeQ==", "970e2e18-a763-4f5d-b03f-d72da67fc6d2" });

            migrationBuilder.AddForeignKey(
                name: "FK_Class_AspNetUsers_TeacherId",
                table: "Class",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
