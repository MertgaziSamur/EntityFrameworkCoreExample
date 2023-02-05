using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Udemy.EfCore.Migrations
{
    public partial class @default : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Products");
        }
    }
}
