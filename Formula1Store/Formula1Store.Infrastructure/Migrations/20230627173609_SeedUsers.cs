using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Formula1Store.Infrastructure.Migrations
{
    public partial class SeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "06078462-5a16-440a-b4e1-67f940716a1d", 0, "1b9ae439-1710-4fe3-bc51-3f7023e2856a", "admin@email.com", false, "Admin", "Admin", false, null, "ADMIN@EMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEC7jgF81nPIDJUw3Xi/VK1N96eg7qRpWyQVBSH8wuFm1kZbuoPu4Q5BZxALcRWaBrg==", null, false, "945b95cf-8cb6-4e12-9ecd-ec49af625c80", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f1d7e58f-aff4-476d-bf3a-b621be15c5e8", 0, "a361241d-e4e3-4591-a2bc-01533144bffd", "kiro@gmail.com", false, "Kiril", "Atanasov", false, null, "KIRO@GMAIL.COM", "KIRO", "AQAAAAEAACcQAAAAENtSEijGb+64el3AhvSkHWTqgLtAG91UfuLq5H87T5WbXkKQBhbh7CreLeOP7RfvlA==", null, false, "21e9472f-f214-4b3d-8007-33f79e6a51d4", false, "Kiro" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06078462-5a16-440a-b4e1-67f940716a1d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1d7e58f-aff4-476d-bf3a-b621be15c5e8");
        }
    }
}
