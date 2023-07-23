using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Formula1Store.Infrastructure.Migrations
{
    public partial class RemovedOrderStatusProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a13d4a4-ac13-41fa-9de1-9de5331984d5",
                column: "ConcurrencyStamp",
                value: "42f1a06a-c808-4ab5-9f15-77a8b8c1630d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7a7d258-3928-49d8-b91b-3a3c5683e124",
                column: "ConcurrencyStamp",
                value: "2506caa8-0250-4b26-b2eb-d07a106001f4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1566b311-5fd9-4d09-8cd7-3b126ffcf80e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b446aea-e2d2-4241-8a65-41883c4bacf6", "AQAAAAEAACcQAAAAEL1k9LixwHTYFQUqyqnMF9LpdzAd1VraS7+vj1NwC8ClpwlmS1/7/1eFz90uPH4dvA==", "f5353a26-9ca1-460c-944b-6180d0a5b11b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c3d5a085-6769-4739-9ae6-c5155c996db2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c50cdc23-f387-4ea6-a6f1-7b7aee24d1b4", "AQAAAAEAACcQAAAAEOgpUNEOPPGrpB6GL8nyUJJQMqPvIFpK7zpdXWDXcCdMEh5NruAOhTQKfW4GHAtFyw==", "9f84d10c-0adc-4b09-9879-c9c34aacb177" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderStatus",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
