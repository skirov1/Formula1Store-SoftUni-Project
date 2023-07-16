using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Formula1Store.Infrastructure.Migrations
{
    public partial class AddedIsActivePropertyToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5121aae5-79d5-4879-82fc-8b78d47f202e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5f1f05a6-c846-431b-bfd5-d6607cb33cec");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2cb0c3a8-a50f-45fe-9d3d-aeb31d3100c9", 0, "e4c48adb-4a79-43ee-a990-6ab9d4cd6e21", "kiro@gmail.com", false, "Kiril", "Atanasov", false, null, "KIRO@GMAIL.COM", "KIRO", "AQAAAAEAACcQAAAAEDskKZS2y8gvJhf/7qLegScu8VMIO60Aae70YeEYtPtZg3XcPpfArgHkH+VHqCRbfw==", null, false, "5daab961-e951-405f-9d96-8ce38736a4a9", false, "Kiro" },
                    { "b3f5f84c-2d4e-4eb7-80ab-38732fbc7acb", 0, "2ccb3ae5-986b-4821-9884-6fb998b92eee", "admin@email.com", false, "Admin", "Admin", false, null, "ADMIN@EMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEJdZOZptRgZDK8F1tatZItrdAlD4NfaFCZfYnR1vLMScHaaiUnXYnRz65IXGJjVFGg==", null, false, "5aeb62cc-9fbf-468a-bde9-cbee46bb8c42", false, "Admin" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsActive",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2cb0c3a8-a50f-45fe-9d3d-aeb31d3100c9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b3f5f84c-2d4e-4eb7-80ab-38732fbc7acb");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5121aae5-79d5-4879-82fc-8b78d47f202e", 0, "d951db03-f7e4-4e14-b3d6-ea26a0dfd07d", "admin@email.com", false, "Admin", "Admin", false, null, "ADMIN@EMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEBGcbnruGb3QiY2meEr2df2+SEeEsVH1yRdd1AMBe3tDR1dt/sYEwOLtBKyGuLgzyQ==", null, false, "d6a587e8-5741-4396-8e16-64885af1c680", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5f1f05a6-c846-431b-bfd5-d6607cb33cec", 0, "997693c2-7e51-4479-8dae-8f5f0085e44e", "kiro@gmail.com", false, "Kiril", "Atanasov", false, null, "KIRO@GMAIL.COM", "KIRO", "AQAAAAEAACcQAAAAECe0Eup43pZ68KlTmeiKPeVXubu6dJ+iTlm+d/Safr9MZYVUKLZaj3C7VNcQH/KPzg==", null, false, "3cb3dbba-c83f-439c-a62a-eeb73313fea0", false, "Kiro" });
        }
    }
}
