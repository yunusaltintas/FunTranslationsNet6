using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunTranslation.Persistence.Migrations
{
    public partial class AddLanguageSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "CreateDate", "CreateUserId", "LanguageName", "UpdateDate", "UpdateUserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 5, 23, 10, 21, 15, 757, DateTimeKind.Local).AddTicks(8699), 1, "Leetspeak", null, null },
                    { 2, new DateTime(2022, 5, 23, 10, 21, 15, 757, DateTimeKind.Local).AddTicks(8715), 1, "Morse", null, null },
                    { 3, new DateTime(2022, 5, 23, 10, 21, 15, 757, DateTimeKind.Local).AddTicks(8716), 1, "Hodor", null, null },
                    { 4, new DateTime(2022, 5, 23, 10, 21, 15, 757, DateTimeKind.Local).AddTicks(8717), 1, "Chef", null, null },
                    { 5, new DateTime(2022, 5, 23, 10, 21, 15, 757, DateTimeKind.Local).AddTicks(8718), 1, "Shakespeare", null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
