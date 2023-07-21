using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Formula1Store.Infrastructure.Migrations
{
    public partial class EditedShoppingCartEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ShoppingCarts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a13d4a4-ac13-41fa-9de1-9de5331984d5",
                column: "ConcurrencyStamp",
                value: "d7fdcba3-ec94-49be-acd8-2623740f5bdf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7a7d258-3928-49d8-b91b-3a3c5683e124",
                column: "ConcurrencyStamp",
                value: "e486eabd-4ab2-4f7b-b11a-6f4e027bb6d0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1566b311-5fd9-4d09-8cd7-3b126ffcf80e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28852dd0-5d13-4f30-9546-30882b5363db", "AQAAAAEAACcQAAAAENjgwJCrMOEs021ny6XQufiJ4yBd0qNH1UnMK2j7GIJ+ygIiknBJUzi0bXHAIWcShA==", "a8347c67-be01-4dd3-9742-cb6785b43d5a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c3d5a085-6769-4739-9ae6-c5155c996db2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21737a87-6e81-4829-9426-2319de218f5f", "AQAAAAEAACcQAAAAEHeIk/IL97GJFQYZLx/cFnXYfjzLhWXdr9EYH28A1G6jZIQWx3ABSgBl+2Hv4tT7tA==", "ce09f4cf-ba7c-49e9-a10f-3f7e33405852" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ShoppingCarts");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a13d4a4-ac13-41fa-9de1-9de5331984d5",
                column: "ConcurrencyStamp",
                value: "492fea4c-f9b1-45b4-9eca-fab2056469db");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7a7d258-3928-49d8-b91b-3a3c5683e124",
                column: "ConcurrencyStamp",
                value: "707a1e6e-9e51-4ffc-a477-af6ce76b6141");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1566b311-5fd9-4d09-8cd7-3b126ffcf80e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "397616c0-6b42-46fe-b16d-53f4b85fe6fd", "AQAAAAEAACcQAAAAENJBxhmUYrtAHlWlbINk/krzZrOYNsP515PDEzyYWEJmEyOMeawjlJPa2dVdtLk/FQ==", "8d54d0fd-56eb-4b9c-a9e9-2ef64d305d65" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c3d5a085-6769-4739-9ae6-c5155c996db2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d9ed7b5-4d55-4f92-b24f-f8cdb7efb934", "AQAAAAEAACcQAAAAEMAcy9XIh197OPYxWH8QJ9nLX+46xHuxEUgj6tYnQz14yC0lg8LTqzsW2iSLXylNZQ==", "d1c157c4-4630-4916-9f7a-b94f1d3d9988" });
        }
    }
}
