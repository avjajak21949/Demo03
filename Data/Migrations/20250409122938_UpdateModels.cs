using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo03.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
