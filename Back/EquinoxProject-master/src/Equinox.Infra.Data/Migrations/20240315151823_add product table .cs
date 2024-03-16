using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Infra.Data.Migrations
{
    public partial class addproducttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customers",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldMaxLength: 11);

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Productname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Merchanname = table.Column<string>(type: "varchar(100)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    deliveryCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customers",
                type: "varchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);
        }
    }
}
