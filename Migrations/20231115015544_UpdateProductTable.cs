using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Allup_Template.Migrations
{
    public partial class UpdateProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPrice",
                table: "Products",
                type: "smallmoney",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPrice",
                table: "Products",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "smallmoney");
        }
    }
}
