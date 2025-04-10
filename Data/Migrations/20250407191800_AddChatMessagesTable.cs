using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo03.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddChatMessagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "ReceiverName",
                table: "ChatMessages");

            migrationBuilder.RenameColumn(
                name: "ReceiverId",
                table: "ChatMessages",
                newName: "Content");

            migrationBuilder.AlterColumn<string>(
                name: "SenderName",
                table: "ChatMessages",
                type: "nvarchar(max)",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "ChatMessages",
                newName: "ReceiverId");

            migrationBuilder.AlterColumn<string>(
                name: "SenderName",
                table: "ChatMessages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "ChatMessages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "ChatMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverName",
                table: "ChatMessages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3de97dd0-6b7a-4774-8568-582ce0c3b2d5", "AQAAAAIAAYagAAAAEANIQLoDsysRczmBc27La9KY3oCtNzsG58g0weIiPK8N0sVTqIf4k4X2B7zQKEzhyQ==", "0c39a8fa-a3bd-4a16-9e48-956d0c8a34c6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9bf8fc1c-cc0f-4457-814e-3c851cd6646b", "AQAAAAIAAYagAAAAEHGv2r8NyDBg9hdwLX21eroSjpk3K/Rm7UUg2DbFeaPIEsH7D0XOTBc6psNMlGltng==", "979cd9b1-74b0-4fc4-9787-762eb8b6b90b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a5dc2d9-0410-4241-8919-57940a7ef62d", "AQAAAAIAAYagAAAAEOxF4TJ3g1+dpGC777RqjAMwHd4vznmvnMSiEVN7jVqQPoebSFQr+ts1zX71B23+wQ==", "d6b090f9-52e5-4056-9e00-51d826c2de7a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d818fb5-c892-41f5-8c98-9af16139ff7b", "AQAAAAIAAYagAAAAEHBVWAD7wFVVcPxB/AJxCv33H7CyEZcMt40udSy61AXlIbioD0jwk1RADpdMxM5c3g==", "2c099333-3206-448d-8b8a-4ad3c3b29abf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09b14979-5037-423f-b562-ec16be66bbaa", "AQAAAAIAAYagAAAAEPzGO1b7uEgJ8wLUWwh/trMWXH5H2MwjQ1G/QJuVtHeJXU9O2U2zRUAc3HU94jLsEg==", "e5bb0c49-a07c-4802-bb60-7396b8cb60d4" });
        }
    }
}
