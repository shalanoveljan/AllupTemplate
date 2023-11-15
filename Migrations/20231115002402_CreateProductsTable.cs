using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Allup_Template.Migrations
{
    public partial class CreateProductsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    DiscountPrice = table.Column<decimal>(type: "money", nullable: false),
                    ExTax = table.Column<decimal>(type: "money", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    SmallDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    MainImage = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    HoverImage = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Seria = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    IsNewArrival = table.Column<bool>(type: "bit", nullable: false),
                    IsBestSeller = table.Column<bool>(type: "bit", nullable: false),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
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
        }
    }
}
