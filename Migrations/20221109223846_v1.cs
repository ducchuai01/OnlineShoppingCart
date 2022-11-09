using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShoppingCart.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrative_regions",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    name_en = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    code_name_en = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrative_regions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Administrative_units",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    full_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    full_name_en = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    short_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    short_name_en = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    code_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    code_name_en = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrative_units", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<string>(maxLength: 36, nullable: false),
                    CategoryName = table.Column<string>(maxLength: 50, nullable: false),
                    Descripton = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Created_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    DiscountID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    DiscountPercent = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Created_at = table.Column<DateTime>(nullable: false),
                    Delete_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.DiscountID);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    name_en = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    full_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    full_name_en = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    code_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    administrative_unit_id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    administrative_region_id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Administrative_Unitsid = table.Column<int>(nullable: true),
                    Administrative_Regionsid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.code);
                    table.ForeignKey(
                        name: "FK_Provinces_Administrative_regions_Administrative_Regionsid",
                        column: x => x.Administrative_Regionsid,
                        principalTable: "Administrative_regions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Provinces_Administrative_units_Administrative_Unitsid",
                        column: x => x.Administrative_Unitsid,
                        principalTable: "Administrative_units",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<string>(maxLength: 36, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Image = table.Column<string>(nullable: false),
                    RelatedImages = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    CategoryID = table.Column<string>(maxLength: 36, nullable: true),
                    CategoriesCategoryID = table.Column<string>(nullable: true),
                    DiscountID = table.Column<int>(nullable: false),
                    DiscountsDiscountID = table.Column<int>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Created_at = table.Column<DateTime>(nullable: false),
                    Deleted_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoriesCategoryID",
                        column: x => x.CategoriesCategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Discounts_DiscountsDiscountID",
                        column: x => x.DiscountsDiscountID,
                        principalTable: "Discounts",
                        principalColumn: "DiscountID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    name_en = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    full_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    full_name_en = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    code_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    province_code = table.Column<string>(type: "nvarchar(255)", maxLength: 20, nullable: true),
                    administrative_unit_id = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Administrative_Unitsid = table.Column<int>(nullable: true),
                    Provincescode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.code);
                    table.ForeignKey(
                        name: "FK_Districts_Administrative_units_Administrative_Unitsid",
                        column: x => x.Administrative_Unitsid,
                        principalTable: "Administrative_units",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Districts_Provinces_Provincescode",
                        column: x => x.Provincescode,
                        principalTable: "Provinces",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<string>(maxLength: 36, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(maxLength: 15, nullable: false),
                    provinces_code = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: false),
                    Created_at = table.Column<DateTime>(nullable: false),
                    Updated_at = table.Column<DateTime>(nullable: false),
                    Provincescode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Provinces_Provincescode",
                        column: x => x.Provincescode,
                        principalTable: "Provinces",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wards",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    name_en = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    full_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    full_name_en = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    code_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    district_code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    administrative_unit_id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Administrative_Unitsid = table.Column<int>(nullable: true),
                    Districtscode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wards", x => x.code);
                    table.ForeignKey(
                        name: "FK_Wards_Administrative_units_Administrative_Unitsid",
                        column: x => x.Administrative_Unitsid,
                        principalTable: "Administrative_units",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wards_Districts_Districtscode",
                        column: x => x.Districtscode,
                        principalTable: "Districts",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FeedBacks",
                columns: table => new
                {
                    FeedBackID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(nullable: false),
                    UsersUserID = table.Column<string>(nullable: true),
                    DateSend = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(type: "ntext", nullable: true),
                    Created_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedBacks", x => x.FeedBackID);
                    table.ForeignKey(
                        name: "FK_FeedBacks_Users_UsersUserID",
                        column: x => x.UsersUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Districts_Administrative_Unitsid",
                table: "Districts",
                column: "Administrative_Unitsid");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_Provincescode",
                table: "Districts",
                column: "Provincescode");

            migrationBuilder.CreateIndex(
                name: "IX_FeedBacks_UsersUserID",
                table: "FeedBacks",
                column: "UsersUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoriesCategoryID",
                table: "Products",
                column: "CategoriesCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DiscountsDiscountID",
                table: "Products",
                column: "DiscountsDiscountID");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_Administrative_Regionsid",
                table: "Provinces",
                column: "Administrative_Regionsid");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_Administrative_Unitsid",
                table: "Provinces",
                column: "Administrative_Unitsid");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Provincescode",
                table: "Users",
                column: "Provincescode");

            migrationBuilder.CreateIndex(
                name: "IX_Wards_Administrative_Unitsid",
                table: "Wards",
                column: "Administrative_Unitsid");

            migrationBuilder.CreateIndex(
                name: "IX_Wards_Districtscode",
                table: "Wards",
                column: "Districtscode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedBacks");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Wards");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Administrative_regions");

            migrationBuilder.DropTable(
                name: "Administrative_units");
        }
    }
}
