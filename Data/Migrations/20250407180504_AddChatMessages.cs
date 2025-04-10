using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo03.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddChatMessages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "StudentEnrollment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ChatMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiverId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c631967f-29c3-4fc9-bfd5-dbe8dbb259af", "AQAAAAIAAYagAAAAEBXb6+ArIP0zlJIZyqw3M93gpzG+XCWHgAvQ1hWoCx1ARHFvCRPYzHkEtc3VMTwlHw==", "012feb2c-c937-43c6-92c9-42c73a6e5b0d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8337a5c7-d7fb-4bdb-a987-9558ee1c4b68", "AQAAAAIAAYagAAAAEKulVJk+t7UX82HZoDoi81MBwzH12S05s0dCmuMrhJjsG5zwLlbTHVTSg/+xw2jIrA==", "7744f6d2-5c41-4fb7-aa03-244fd96b46fd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "463133a5-e809-4cc2-bc95-66c6727d251e", "AQAAAAIAAYagAAAAEPDMXm9cZzl6EZ0k2CZ3o9fdKUZmVL/O2Mcbh6qkumjV0Px0iqj5GEdsL473HUE60Q==", "a53b8f70-4816-4245-b56e-a291719875f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "93fc9ffb-b115-4fc1-9810-422d9783daa7", "AQAAAAIAAYagAAAAEKKxjHjHWOFTgFon+xDtG0K82U0K2unUJMvdaJvEzVPcJdFMLYgTRxtBtZ1F7UhcZA==", "00047344-cc72-46bb-903f-1150de6c61f6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "StudentEnrollment");

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
        }
    }
}
