using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Formula1Store.Infrastructure.Migrations
{
    public partial class AddedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2cb0c3a8-a50f-45fe-9d3d-aeb31d3100c9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b3f5f84c-2d4e-4eb7-80ab-38732fbc7acb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9a13d4a4-ac13-41fa-9de1-9de5331984d5", "7e9a3f9d-9439-46e1-8f71-9ab0688b9fcb", "User", "USER" },
                    { "e7a7d258-3928-49d8-b91b-3a3c5683e124", "d06cbce0-e86f-4c1e-a969-0a8bf95647eb", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1566b311-5fd9-4d09-8cd7-3b126ffcf80e", 0, "09151801-895b-4ac6-8f2b-e8e1a551a773", "kiro@gmail.com", false, "Kiril", "Atanasov", false, null, "KIRO@GMAIL.COM", "KIRO", "AQAAAAEAACcQAAAAENH/t6oCS4S/LO3hen7bSRiC8oxpQo7PZlPfnstbLrBqIgdQ9bI7zeI0SN7L1ymwNw==", null, false, "7a2d6b2a-ce68-44e7-951d-eea9deed13e0", false, "Kiro" },
                    { "c3d5a085-6769-4739-9ae6-c5155c996db2", 0, "29f6ced1-09a3-4276-8646-b300820af8d4", "admin@email.com", false, "Admin", "Admin", false, null, "ADMIN@EMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEHVa4M03xnZlboDzB0kuw40+ThQpUCfS43zqzhEFC3yBxOUTfVbspv66nB4ZxdY7Sg==", null, false, "e458cb96-ec2b-467e-a9cd-63eac5f7db79", false, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9a13d4a4-ac13-41fa-9de1-9de5331984d5", "1566b311-5fd9-4d09-8cd7-3b126ffcf80e" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e7a7d258-3928-49d8-b91b-3a3c5683e124", "c3d5a085-6769-4739-9ae6-c5155c996db2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9a13d4a4-ac13-41fa-9de1-9de5331984d5", "1566b311-5fd9-4d09-8cd7-3b126ffcf80e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e7a7d258-3928-49d8-b91b-3a3c5683e124", "c3d5a085-6769-4739-9ae6-c5155c996db2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a13d4a4-ac13-41fa-9de1-9de5331984d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7a7d258-3928-49d8-b91b-3a3c5683e124");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1566b311-5fd9-4d09-8cd7-3b126ffcf80e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c3d5a085-6769-4739-9ae6-c5155c996db2");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2cb0c3a8-a50f-45fe-9d3d-aeb31d3100c9", 0, "e4c48adb-4a79-43ee-a990-6ab9d4cd6e21", "kiro@gmail.com", false, "Kiril", "Atanasov", false, null, "KIRO@GMAIL.COM", "KIRO", "AQAAAAEAACcQAAAAEDskKZS2y8gvJhf/7qLegScu8VMIO60Aae70YeEYtPtZg3XcPpfArgHkH+VHqCRbfw==", null, false, "5daab961-e951-405f-9d96-8ce38736a4a9", false, "Kiro" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b3f5f84c-2d4e-4eb7-80ab-38732fbc7acb", 0, "2ccb3ae5-986b-4821-9884-6fb998b92eee", "admin@email.com", false, "Admin", "Admin", false, null, "ADMIN@EMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEJdZOZptRgZDK8F1tatZItrdAlD4NfaFCZfYnR1vLMScHaaiUnXYnRz65IXGJjVFGg==", null, false, "5aeb62cc-9fbf-468a-bde9-cbee46bb8c42", false, "Admin" });
        }
    }
}
