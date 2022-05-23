using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunTranslation.Persistence.Migrations
{
    public partial class AddUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "c703dfec-3f84-4e81-8561-60d924775488");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 2, 0, "3f7a99c7-1446-49c1-aa7e-6860a5165569", "user@user.com", false, false, null, "USER@USER.COM", "USER", "AQAAAAEAACcQAAAAEDJ+SO90wp7h8BBv3JhnGZmuy/ai+JUhV0dgm20MbALPe+nP9jA8+NlzsnNXqjeA6g==", null, false, "VS4SLSW5QYXLWLRGP4X2J3G5NVJLUICB", false, "user" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "09c1c7d3-03d0-4c09-a306-74b12adbb06d");
        }
    }
}
