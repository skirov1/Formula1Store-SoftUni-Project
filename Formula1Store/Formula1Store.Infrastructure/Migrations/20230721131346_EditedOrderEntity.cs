using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Formula1Store.Infrastructure.Migrations
{
    public partial class EditedOrderEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderNumber",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a13d4a4-ac13-41fa-9de1-9de5331984d5",
                column: "ConcurrencyStamp",
                value: "7e9a3f9d-9439-46e1-8f71-9ab0688b9fcb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7a7d258-3928-49d8-b91b-3a3c5683e124",
                column: "ConcurrencyStamp",
                value: "d06cbce0-e86f-4c1e-a969-0a8bf95647eb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1566b311-5fd9-4d09-8cd7-3b126ffcf80e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09151801-895b-4ac6-8f2b-e8e1a551a773", "AQAAAAEAACcQAAAAENH/t6oCS4S/LO3hen7bSRiC8oxpQo7PZlPfnstbLrBqIgdQ9bI7zeI0SN7L1ymwNw==", "7a2d6b2a-ce68-44e7-951d-eea9deed13e0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c3d5a085-6769-4739-9ae6-c5155c996db2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29f6ced1-09a3-4276-8646-b300820af8d4", "AQAAAAEAACcQAAAAEHVa4M03xnZlboDzB0kuw40+ThQpUCfS43zqzhEFC3yBxOUTfVbspv66nB4ZxdY7Sg==", "e458cb96-ec2b-467e-a9cd-63eac5f7db79" });
        }
    }
}
