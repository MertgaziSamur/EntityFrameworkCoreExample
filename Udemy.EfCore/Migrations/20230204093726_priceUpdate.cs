using Microsoft.EntityFrameworkCore.Migrations;

namespace Udemy.EfCore.Migrations
{
    public partial class priceUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "product_price");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "product_price",
                table: "Products",
                newName: "Price");
        }
    }
}
