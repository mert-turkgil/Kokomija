using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kokomija.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProductTranslations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionKey",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "NameKey",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ProductTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CultureCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MetaKeywords = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTranslations_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 4, 21, 24, 54, 281, DateTimeKind.Utc).AddTicks(4005), new DateTime(2025, 12, 4, 21, 24, 54, 281, DateTimeKind.Utc).AddTicks(4308) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 4, 21, 24, 54, 281, DateTimeKind.Utc).AddTicks(4604), new DateTime(2025, 12, 4, 21, 24, 54, 281, DateTimeKind.Utc).AddTicks(4605) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 4, 21, 24, 54, 281, DateTimeKind.Utc).AddTicks(4607), new DateTime(2025, 12, 4, 21, 24, 54, 281, DateTimeKind.Utc).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 4, 21, 24, 54, 281, DateTimeKind.Utc).AddTicks(4611), new DateTime(2025, 12, 4, 21, 24, 54, 281, DateTimeKind.Utc).AddTicks(4611) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 4, 21, 24, 54, 281, DateTimeKind.Utc).AddTicks(4614), new DateTime(2025, 12, 4, 21, 24, 54, 281, DateTimeKind.Utc).AddTicks(4614) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 4, 21, 24, 54, 282, DateTimeKind.Utc).AddTicks(7376), new DateTime(2025, 12, 4, 21, 24, 54, 282, DateTimeKind.Utc).AddTicks(7655) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 4, 21, 24, 54, 282, DateTimeKind.Utc).AddTicks(7932), new DateTime(2025, 12, 4, 21, 24, 54, 282, DateTimeKind.Utc).AddTicks(7933) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 4, 21, 24, 54, 282, DateTimeKind.Utc).AddTicks(135), new DateTime(2025, 12, 4, 21, 24, 54, 281, DateTimeKind.Utc).AddTicks(8807), new DateTime(2025, 12, 4, 21, 24, 54, 282, DateTimeKind.Utc).AddTicks(434) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 290, DateTimeKind.Utc).AddTicks(1617));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 290, DateTimeKind.Utc).AddTicks(1928));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 4, 21, 24, 54, 289, DateTimeKind.Utc).AddTicks(4535), new DateTime(2025, 12, 4, 21, 24, 54, 289, DateTimeKind.Utc).AddTicks(4170) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 278, DateTimeKind.Utc).AddTicks(6233));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 278, DateTimeKind.Utc).AddTicks(6965));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 278, DateTimeKind.Utc).AddTicks(6969));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 278, DateTimeKind.Utc).AddTicks(6973));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 278, DateTimeKind.Utc).AddTicks(7581));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 278, DateTimeKind.Utc).AddTicks(7590));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 278, DateTimeKind.Utc).AddTicks(7595));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 278, DateTimeKind.Utc).AddTicks(7599));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 278, DateTimeKind.Utc).AddTicks(7604));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 278, DateTimeKind.Utc).AddTicks(7609));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 278, DateTimeKind.Utc).AddTicks(7613));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 278, DateTimeKind.Utc).AddTicks(7618));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 277, DateTimeKind.Utc).AddTicks(3495));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 277, DateTimeKind.Utc).AddTicks(3814));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 277, DateTimeKind.Utc).AddTicks(3816));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 277, DateTimeKind.Utc).AddTicks(3818));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 277, DateTimeKind.Utc).AddTicks(3820));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 277, DateTimeKind.Utc).AddTicks(3823));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 277, DateTimeKind.Utc).AddTicks(3825));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 277, DateTimeKind.Utc).AddTicks(3827));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2025, 12, 4, 21, 24, 54, 285, DateTimeKind.Utc).AddTicks(3482), new DateTime(2025, 12, 4, 21, 24, 54, 285, DateTimeKind.Utc).AddTicks(1408), new DateTime(2026, 6, 4, 21, 24, 54, 285, DateTimeKind.Utc).AddTicks(1805) });

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 285, DateTimeKind.Utc).AddTicks(8422));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(4970));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5300));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5303));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5306));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5308));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5319));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5322));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5324));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5328));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5332));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5335));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5337));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5339));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5341));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5344));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5346));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5350));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5354));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5357));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5359));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5414));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5416));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5419));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5421));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 288, DateTimeKind.Utc).AddTicks(4368));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 288, DateTimeKind.Utc).AddTicks(4700));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 288, DateTimeKind.Utc).AddTicks(4703));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 288, DateTimeKind.Utc).AddTicks(4706));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 288, DateTimeKind.Utc).AddTicks(4709));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 288, DateTimeKind.Utc).AddTicks(4718));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 288, DateTimeKind.Utc).AddTicks(4723));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 288, DateTimeKind.Utc).AddTicks(4726));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 288, DateTimeKind.Utc).AddTicks(4729));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 288, DateTimeKind.Utc).AddTicks(4734));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 288, DateTimeKind.Utc).AddTicks(4739));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 288, DateTimeKind.Utc).AddTicks(4742));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 288, DateTimeKind.Utc).AddTicks(4745));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 288, DateTimeKind.Utc).AddTicks(4749));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 288, DateTimeKind.Utc).AddTicks(4752));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 286, DateTimeKind.Utc).AddTicks(7957));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 286, DateTimeKind.Utc).AddTicks(8256));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 286, DateTimeKind.Utc).AddTicks(8260));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 284, DateTimeKind.Utc).AddTicks(380));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 284, DateTimeKind.Utc).AddTicks(767));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 284, DateTimeKind.Utc).AddTicks(770));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 284, DateTimeKind.Utc).AddTicks(772));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 284, DateTimeKind.Utc).AddTicks(775));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 284, DateTimeKind.Utc).AddTicks(778));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 284, DateTimeKind.Utc).AddTicks(779));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 284, DateTimeKind.Utc).AddTicks(782));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 284, DateTimeKind.Utc).AddTicks(784));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 284, DateTimeKind.Utc).AddTicks(786));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 284, DateTimeKind.Utc).AddTicks(788));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 275, DateTimeKind.Utc).AddTicks(8230));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 275, DateTimeKind.Utc).AddTicks(8560));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 275, DateTimeKind.Utc).AddTicks(8562));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 275, DateTimeKind.Utc).AddTicks(8564));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 275, DateTimeKind.Utc).AddTicks(8566));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 275, DateTimeKind.Utc).AddTicks(8568));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 280, DateTimeKind.Utc).AddTicks(5993));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 280, DateTimeKind.Utc).AddTicks(6369));

            migrationBuilder.CreateIndex(
                name: "IX_ProductTranslations_ProductId_CultureCode",
                table: "ProductTranslations",
                columns: new[] { "ProductId", "CultureCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductTranslations_Slug",
                table: "ProductTranslations",
                column: "Slug");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductTranslations");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionKey",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKey",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 4, 14, 16, 16, 665, DateTimeKind.Utc).AddTicks(4198), new DateTime(2025, 12, 4, 14, 16, 16, 665, DateTimeKind.Utc).AddTicks(4556) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 4, 14, 16, 16, 665, DateTimeKind.Utc).AddTicks(4882), new DateTime(2025, 12, 4, 14, 16, 16, 665, DateTimeKind.Utc).AddTicks(4882) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 4, 14, 16, 16, 665, DateTimeKind.Utc).AddTicks(4885), new DateTime(2025, 12, 4, 14, 16, 16, 665, DateTimeKind.Utc).AddTicks(4886) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 4, 14, 16, 16, 665, DateTimeKind.Utc).AddTicks(4888), new DateTime(2025, 12, 4, 14, 16, 16, 665, DateTimeKind.Utc).AddTicks(4889) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 4, 14, 16, 16, 665, DateTimeKind.Utc).AddTicks(4892), new DateTime(2025, 12, 4, 14, 16, 16, 665, DateTimeKind.Utc).AddTicks(4892) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 4, 14, 16, 16, 666, DateTimeKind.Utc).AddTicks(9877), new DateTime(2025, 12, 4, 14, 16, 16, 667, DateTimeKind.Utc).AddTicks(196) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 4, 14, 16, 16, 667, DateTimeKind.Utc).AddTicks(508), new DateTime(2025, 12, 4, 14, 16, 16, 667, DateTimeKind.Utc).AddTicks(509) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 4, 14, 16, 16, 666, DateTimeKind.Utc).AddTicks(1514), new DateTime(2025, 12, 4, 14, 16, 16, 666, DateTimeKind.Utc).AddTicks(36), new DateTime(2025, 12, 4, 14, 16, 16, 666, DateTimeKind.Utc).AddTicks(1831) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 680, DateTimeKind.Utc).AddTicks(6911));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 680, DateTimeKind.Utc).AddTicks(7326));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 4, 14, 16, 16, 678, DateTimeKind.Utc).AddTicks(2046), new DateTime(2025, 12, 4, 14, 16, 16, 678, DateTimeKind.Utc).AddTicks(1459) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 662, DateTimeKind.Utc).AddTicks(8123));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 662, DateTimeKind.Utc).AddTicks(8464));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 662, DateTimeKind.Utc).AddTicks(8468));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 662, DateTimeKind.Utc).AddTicks(8471));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 662, DateTimeKind.Utc).AddTicks(8803));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 662, DateTimeKind.Utc).AddTicks(8810));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 662, DateTimeKind.Utc).AddTicks(8813));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 662, DateTimeKind.Utc).AddTicks(8816));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 662, DateTimeKind.Utc).AddTicks(8819));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 662, DateTimeKind.Utc).AddTicks(8823));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 662, DateTimeKind.Utc).AddTicks(8826));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 662, DateTimeKind.Utc).AddTicks(8829));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 661, DateTimeKind.Utc).AddTicks(3996));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 661, DateTimeKind.Utc).AddTicks(4334));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 661, DateTimeKind.Utc).AddTicks(4337));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 661, DateTimeKind.Utc).AddTicks(4340));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 661, DateTimeKind.Utc).AddTicks(4342));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 661, DateTimeKind.Utc).AddTicks(4345));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 661, DateTimeKind.Utc).AddTicks(4347));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 661, DateTimeKind.Utc).AddTicks(4350));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2025, 12, 4, 14, 16, 16, 670, DateTimeKind.Utc).AddTicks(2381), new DateTime(2025, 12, 4, 14, 16, 16, 669, DateTimeKind.Utc).AddTicks(9207), new DateTime(2026, 6, 4, 14, 16, 16, 669, DateTimeKind.Utc).AddTicks(9598) });

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 670, DateTimeKind.Utc).AddTicks(9756));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 674, DateTimeKind.Utc).AddTicks(9481));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 674, DateTimeKind.Utc).AddTicks(9960));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 674, DateTimeKind.Utc).AddTicks(9964));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 674, DateTimeKind.Utc).AddTicks(9967));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 674, DateTimeKind.Utc).AddTicks(9970));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 674, DateTimeKind.Utc).AddTicks(9985));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 674, DateTimeKind.Utc).AddTicks(9988));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 675, DateTimeKind.Utc).AddTicks(131));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 675, DateTimeKind.Utc).AddTicks(137));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 675, DateTimeKind.Utc).AddTicks(142));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 675, DateTimeKind.Utc).AddTicks(145));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 675, DateTimeKind.Utc).AddTicks(148));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 675, DateTimeKind.Utc).AddTicks(151));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 675, DateTimeKind.Utc).AddTicks(154));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 675, DateTimeKind.Utc).AddTicks(157));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 675, DateTimeKind.Utc).AddTicks(160));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 675, DateTimeKind.Utc).AddTicks(167));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 675, DateTimeKind.Utc).AddTicks(171));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 675, DateTimeKind.Utc).AddTicks(175));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 675, DateTimeKind.Utc).AddTicks(178));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 675, DateTimeKind.Utc).AddTicks(181));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 675, DateTimeKind.Utc).AddTicks(184));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 675, DateTimeKind.Utc).AddTicks(187));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 675, DateTimeKind.Utc).AddTicks(190));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 676, DateTimeKind.Utc).AddTicks(9214));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 676, DateTimeKind.Utc).AddTicks(9802));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 676, DateTimeKind.Utc).AddTicks(9807));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 676, DateTimeKind.Utc).AddTicks(9810));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 676, DateTimeKind.Utc).AddTicks(9813));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 676, DateTimeKind.Utc).AddTicks(9830));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 676, DateTimeKind.Utc).AddTicks(9835));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 676, DateTimeKind.Utc).AddTicks(9838));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 676, DateTimeKind.Utc).AddTicks(9841));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 676, DateTimeKind.Utc).AddTicks(9847));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 676, DateTimeKind.Utc).AddTicks(9938));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 676, DateTimeKind.Utc).AddTicks(9943));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 676, DateTimeKind.Utc).AddTicks(9946));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 676, DateTimeKind.Utc).AddTicks(9949));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 676, DateTimeKind.Utc).AddTicks(9952));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DescriptionKey", "NameKey" },
                values: new object[] { new DateTime(2025, 12, 4, 14, 16, 16, 672, DateTimeKind.Utc).AddTicks(9256), "Product_WomenBriefs5Pack_Description", "Product_WomenBriefs5Pack_Name" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DescriptionKey", "NameKey" },
                values: new object[] { new DateTime(2025, 12, 4, 14, 16, 16, 672, DateTimeKind.Utc).AddTicks(9784), "Product_WomenBriefs6Pack_Description", "Product_WomenBriefs6Pack_Name" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "DescriptionKey", "NameKey" },
                values: new object[] { new DateTime(2025, 12, 4, 14, 16, 16, 672, DateTimeKind.Utc).AddTicks(9790), "Product_WomenBriefs8Pack_Description", "Product_WomenBriefs8Pack_Name" });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 667, DateTimeKind.Utc).AddTicks(9892));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 668, DateTimeKind.Utc).AddTicks(216));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 668, DateTimeKind.Utc).AddTicks(218));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 668, DateTimeKind.Utc).AddTicks(220));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 668, DateTimeKind.Utc).AddTicks(222));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 668, DateTimeKind.Utc).AddTicks(224));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 668, DateTimeKind.Utc).AddTicks(226));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 668, DateTimeKind.Utc).AddTicks(228));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 668, DateTimeKind.Utc).AddTicks(230));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 668, DateTimeKind.Utc).AddTicks(233));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 668, DateTimeKind.Utc).AddTicks(235));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 659, DateTimeKind.Utc).AddTicks(1784));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 659, DateTimeKind.Utc).AddTicks(2283));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 659, DateTimeKind.Utc).AddTicks(2287));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 659, DateTimeKind.Utc).AddTicks(2292));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 659, DateTimeKind.Utc).AddTicks(2294));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 659, DateTimeKind.Utc).AddTicks(2296));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 663, DateTimeKind.Utc).AddTicks(8361));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 663, DateTimeKind.Utc).AddTicks(8810));
        }
    }
}
