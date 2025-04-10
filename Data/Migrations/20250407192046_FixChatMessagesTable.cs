using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo03.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixChatMessagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a922e60-2ce1-435c-af75-fbf0d3c86e51", "AQAAAAIAAYagAAAAEFa2z99gH2nwhPPni4mcPcXCcrm+zl3zGYX2Ndky+mkSFxe6KvZIbW6jpsfXbmFUbw==", "bd8ec1e0-c614-4b6b-a6db-47d8a4752eaa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44f504e1-1614-4aa9-a0b6-d311a3b926f8", "AQAAAAIAAYagAAAAEE+Foic5zH60aBfEmYKgfW1n1dJLziYxwCLp9bc691cYCb7ntpL8MjkIpq4xL3cR6g==", "f12c3d41-7afb-485c-8002-5f95ca5db44a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49f722bb-8a95-40f6-8f67-0ba6b8cd7c97", "AQAAAAIAAYagAAAAELferrMqtOYiqgVOxvF/9GC/OD1SIAYOEwVVHykZ3TwCy2F7z27EP2p2+2qZUFE2Hw==", "f896e531-3d31-4224-97f2-0a970bac1c8a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84e9f6a5-5a2d-42b2-8288-9e964d5f88af", "AQAAAAIAAYagAAAAEETv5YZrgu9PUS7V7KEtZu8e8QgxJUFvTfxNhLsneIbxqA45F/kqcfxFsGFfgrmoYA==", "700bd7f7-0744-4a50-80aa-9814e74f673a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d798176c-14c1-42aa-ad32-c739835a51b0", "AQAAAAIAAYagAAAAEJVjiq/v8dWXZbG9kq7AZuBicEzDV82ql9zpgaeogwrqPT/vR7EiBRwedYqcSyaY+g==", "e46b886d-b53e-4e5e-94a8-236fc42ecf4d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "250bdccd-1963-4015-b424-80df9c1b2398", "AQAAAAIAAYagAAAAEIj926dWXw3Pjb6GPGnbXSXXZ6BJY0w3opjoH5snHBIzdnGrtB3BdZC22e5YKyKltA==", "038835e5-cb1e-4452-949b-7bda118483fc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "715f5022-eebf-48b8-8b38-e757cae1b2c4", "AQAAAAIAAYagAAAAEOWqAF+dJ6Wvuc5aPKDODEvO6n/HDMIx+6B65nSUlUIQu161KZf+9XsKuEVAqeDBTQ==", "21c25feb-9108-4f89-be40-4ba65b94d01c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f7afceb-fe66-40dd-bced-8f72b69c099b", "AQAAAAIAAYagAAAAEMY8d02yQV9D5cdB3JCpFQjCULS+8bhJiTrGXeR5HDrvUjlaHRFXlogtJadqiebrvQ==", "d0495a0b-cc50-4b42-8e05-2dfae736908e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "387a453f-239b-4502-8189-28bb55492537", "AQAAAAIAAYagAAAAEIt9CQaY5olpc8UZiRajCBlXj6Yga6HG/Y43tgH57BTL6COluuix9tVoQVyPKLnUPA==", "a30ad00f-d659-45f3-b305-16cdccd08697" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5486d3fc-ba77-40b8-9665-22c7dc8c4a07", "AQAAAAIAAYagAAAAEMHQejs2pkdqAywNI9LE2Mxblvqae7kW+/za3cijk/41poXTMLhHTdMU6qed7J47AQ==", "cdc587e9-c6ce-4299-beeb-2448f81f5a56" });
        }
    }
}
