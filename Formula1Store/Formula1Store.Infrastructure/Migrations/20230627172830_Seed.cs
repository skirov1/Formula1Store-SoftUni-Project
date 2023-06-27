using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Formula1Store.Infrastructure.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "T-Shirt" },
                    { 2, "Jackets" },
                    { 3, "Headwear" },
                    { 4, "Shorts" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 1, 1, "Show your love and support for the Scuderia Ferrari F1 team with the official Replica range. This classic tee has team and sponsor details for an authentic trackside look that you can wear anywhere from the circuit to the street.", "https://images.footballfanatics.com/scuderia-ferrari/scuderia-ferrari-2023-team-t-shirt_ss4_p-13368608+u-ya0zcr5gjt4kzyrcb08m+v-f28b0bcee21c492bbbd3d4f328095725.jpg?_hv=2&w=900", "Scuderia Ferrari 2023 Team T-Shirt", 49.50m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 2, 1, "Show your love and support for the Scuderia Ferrari F1 team with the official Replica range. Combining Sainz's car number on the back with classic team and sponsor styling for an iconic F1 look, this is a garment that should be in every Scuderia Ferrari fan's collection.", "https://images.footballfanatics.com/scuderia-ferrari/scuderia-ferrari-2023-team-carlos-sainz-t-shirt_ss4_p-13368597+u-fam96qn766o6oy69jf7d+v-c1f28d272ac34896880395300bce9652.jpg?_hv=2&w=900", "Scuderia Ferrari 2023 Team Carlos Sainz T-Shirt", 53.25m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 3, 1, "Take your Scuderia Ferrari passion from the track to the streets with the official Puma collection. This classic tee features a stylized Scuderia Ferrari artwork print on the back. The Scuderia Ferrari name is also featured on a badge on the chest, and the Ferrari and Puma logos are printed on the sleeves. The classic fit makes this ideal for working into any outfit.", "https://images.footballfanatics.com/scuderia-ferrari/scuderia-ferrari-race-graphic-t-shirt-by-puma-black_ss4_p-13345747+u-2625jalyqhcpob0ff9dh+v-0aa98a1cc1c44b3e82d146c4500fac20.jpg?_hv=2&w=900", "Scuderia Ferrari Race Graphic T-Shirt", 35.25m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
