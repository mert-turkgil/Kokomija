using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kokomija.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCarouselSlideTranslations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarouselSlideTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarouselSlideId = table.Column<int>(type: "int", nullable: false),
                    CultureCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ButtonText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LinkUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ControllerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ActionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AreaName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RouteParameters = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ImageAlt = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarouselSlideTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarouselSlideTranslations_CarouselSlides_CarouselSlideId",
                        column: x => x.CarouselSlideId,
                        principalTable: "CarouselSlides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 21, 0, 13, 4, 59, DateTimeKind.Utc).AddTicks(8516), new DateTime(2025, 11, 21, 0, 13, 4, 59, DateTimeKind.Utc).AddTicks(8817) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 21, 0, 13, 4, 59, DateTimeKind.Utc).AddTicks(9180), new DateTime(2025, 11, 21, 0, 13, 4, 59, DateTimeKind.Utc).AddTicks(9180) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 21, 0, 13, 4, 59, DateTimeKind.Utc).AddTicks(9183), new DateTime(2025, 11, 21, 0, 13, 4, 59, DateTimeKind.Utc).AddTicks(9184) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 21, 0, 13, 4, 59, DateTimeKind.Utc).AddTicks(9186), new DateTime(2025, 11, 21, 0, 13, 4, 59, DateTimeKind.Utc).AddTicks(9187) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 21, 0, 13, 4, 59, DateTimeKind.Utc).AddTicks(9190), new DateTime(2025, 11, 21, 0, 13, 4, 59, DateTimeKind.Utc).AddTicks(9190) });

            migrationBuilder.InsertData(
                table: "CarouselSlideTranslations",
                columns: new[] { "Id", "ActionName", "AreaName", "ButtonText", "CarouselSlideId", "ControllerName", "CreatedAt", "CultureCode", "ImageAlt", "LinkUrl", "RouteParameters", "Subtitle", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Index", null, "Shop Now", 1, "Product", new DateTime(2025, 11, 21, 0, 13, 4, 67, DateTimeKind.Utc).AddTicks(1653), "en-US", "New Spring 2025 Collection - Premium women's fashion", null, "{\"category\":\"women\"}", "Discover the latest trends in women's fashion", "New Spring 2025 Collection", null },
                    { 2, "Index", null, "Kup Teraz", 1, "Product", new DateTime(2025, 11, 21, 0, 13, 4, 67, DateTimeKind.Utc).AddTicks(1963), "pl-PL", "Nowa Kolekcja Wiosna 2025 - Wysokiej jakości moda damska", null, "{\"category\":\"damskie\"}", "Odkryj najnowsze trendy w modzie damskiej", "Nowa Kolekcja Wiosna 2025", null }
                });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ImageAlt", "LinkUrl", "Location", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 21, 0, 13, 4, 66, DateTimeKind.Utc).AddTicks(3894), "New Spring 2025 Collection", null, "Home", new DateTime(2025, 11, 21, 0, 13, 4, 66, DateTimeKind.Utc).AddTicks(3530) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 58, DateTimeKind.Utc).AddTicks(4426));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 58, DateTimeKind.Utc).AddTicks(4743));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 58, DateTimeKind.Utc).AddTicks(4746));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 58, DateTimeKind.Utc).AddTicks(4749));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 58, DateTimeKind.Utc).AddTicks(5059));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 58, DateTimeKind.Utc).AddTicks(5064));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 58, DateTimeKind.Utc).AddTicks(5067));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 58, DateTimeKind.Utc).AddTicks(5070));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 58, DateTimeKind.Utc).AddTicks(5073));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 58, DateTimeKind.Utc).AddTicks(5076));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 58, DateTimeKind.Utc).AddTicks(5078));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 58, DateTimeKind.Utc).AddTicks(5081));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 57, DateTimeKind.Utc).AddTicks(1693));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 57, DateTimeKind.Utc).AddTicks(2010));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 57, DateTimeKind.Utc).AddTicks(2012));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 57, DateTimeKind.Utc).AddTicks(2014));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 57, DateTimeKind.Utc).AddTicks(2016));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 57, DateTimeKind.Utc).AddTicks(2019));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 57, DateTimeKind.Utc).AddTicks(2021));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 57, DateTimeKind.Utc).AddTicks(2023));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2025, 11, 21, 0, 13, 4, 62, DateTimeKind.Utc).AddTicks(1968), new DateTime(2025, 11, 21, 0, 13, 4, 61, DateTimeKind.Utc).AddTicks(9952), new DateTime(2026, 5, 21, 0, 13, 4, 62, DateTimeKind.Utc).AddTicks(509) });

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 62, DateTimeKind.Utc).AddTicks(7033));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 64, DateTimeKind.Utc).AddTicks(3920));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 64, DateTimeKind.Utc).AddTicks(4247));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 64, DateTimeKind.Utc).AddTicks(4251));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 64, DateTimeKind.Utc).AddTicks(4254));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 64, DateTimeKind.Utc).AddTicks(4257));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 64, DateTimeKind.Utc).AddTicks(4268));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 64, DateTimeKind.Utc).AddTicks(4270));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 64, DateTimeKind.Utc).AddTicks(4273));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 64, DateTimeKind.Utc).AddTicks(4278));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 64, DateTimeKind.Utc).AddTicks(4282));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 64, DateTimeKind.Utc).AddTicks(4284));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 64, DateTimeKind.Utc).AddTicks(4287));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 64, DateTimeKind.Utc).AddTicks(4289));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 64, DateTimeKind.Utc).AddTicks(4292));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 64, DateTimeKind.Utc).AddTicks(4294));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 64, DateTimeKind.Utc).AddTicks(4296));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 64, DateTimeKind.Utc).AddTicks(4301));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 64, DateTimeKind.Utc).AddTicks(4305));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 64, DateTimeKind.Utc).AddTicks(4374));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 64, DateTimeKind.Utc).AddTicks(4377));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 64, DateTimeKind.Utc).AddTicks(4379));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 64, DateTimeKind.Utc).AddTicks(4382));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 64, DateTimeKind.Utc).AddTicks(4384));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 64, DateTimeKind.Utc).AddTicks(4386));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 65, DateTimeKind.Utc).AddTicks(5091));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 65, DateTimeKind.Utc).AddTicks(5442));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 65, DateTimeKind.Utc).AddTicks(5444));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 65, DateTimeKind.Utc).AddTicks(5447));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 65, DateTimeKind.Utc).AddTicks(5449));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 65, DateTimeKind.Utc).AddTicks(5456));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 65, DateTimeKind.Utc).AddTicks(5459));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 65, DateTimeKind.Utc).AddTicks(5461));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 65, DateTimeKind.Utc).AddTicks(5463));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 65, DateTimeKind.Utc).AddTicks(5466));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 65, DateTimeKind.Utc).AddTicks(5470));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 65, DateTimeKind.Utc).AddTicks(5472));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 65, DateTimeKind.Utc).AddTicks(5474));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 65, DateTimeKind.Utc).AddTicks(5476));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 65, DateTimeKind.Utc).AddTicks(5477));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 63, DateTimeKind.Utc).AddTicks(7097));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 63, DateTimeKind.Utc).AddTicks(7417));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 63, DateTimeKind.Utc).AddTicks(7421));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 60, DateTimeKind.Utc).AddTicks(7660));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 60, DateTimeKind.Utc).AddTicks(8053));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 60, DateTimeKind.Utc).AddTicks(8055));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 60, DateTimeKind.Utc).AddTicks(8057));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 60, DateTimeKind.Utc).AddTicks(8059));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 60, DateTimeKind.Utc).AddTicks(8061));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 60, DateTimeKind.Utc).AddTicks(8063));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 60, DateTimeKind.Utc).AddTicks(8065));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 60, DateTimeKind.Utc).AddTicks(8067));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 60, DateTimeKind.Utc).AddTicks(8069));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 60, DateTimeKind.Utc).AddTicks(8071));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 55, DateTimeKind.Utc).AddTicks(1704));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 55, DateTimeKind.Utc).AddTicks(2032));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 55, DateTimeKind.Utc).AddTicks(2096));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 55, DateTimeKind.Utc).AddTicks(2098));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 55, DateTimeKind.Utc).AddTicks(2100));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 55, DateTimeKind.Utc).AddTicks(2103));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 59, DateTimeKind.Utc).AddTicks(1109));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 0, 13, 4, 59, DateTimeKind.Utc).AddTicks(1730));

            migrationBuilder.CreateIndex(
                name: "IX_CarouselSlideTranslations_SlideId_Culture",
                table: "CarouselSlideTranslations",
                columns: new[] { "CarouselSlideId", "CultureCode" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarouselSlideTranslations");

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 20, 19, 40, 59, 229, DateTimeKind.Utc).AddTicks(2004), new DateTime(2025, 11, 20, 19, 40, 59, 229, DateTimeKind.Utc).AddTicks(2397) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 20, 19, 40, 59, 229, DateTimeKind.Utc).AddTicks(2789), new DateTime(2025, 11, 20, 19, 40, 59, 229, DateTimeKind.Utc).AddTicks(2789) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 20, 19, 40, 59, 229, DateTimeKind.Utc).AddTicks(2793), new DateTime(2025, 11, 20, 19, 40, 59, 229, DateTimeKind.Utc).AddTicks(2793) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 20, 19, 40, 59, 229, DateTimeKind.Utc).AddTicks(2796), new DateTime(2025, 11, 20, 19, 40, 59, 229, DateTimeKind.Utc).AddTicks(2797) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 20, 19, 40, 59, 229, DateTimeKind.Utc).AddTicks(2800), new DateTime(2025, 11, 20, 19, 40, 59, 229, DateTimeKind.Utc).AddTicks(2801) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ImageAlt", "LinkUrl", "Location", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 20, 19, 40, 59, 236, DateTimeKind.Utc).AddTicks(8677), "Nowa kolekcja wiosenna 2025", "/damskie", "home", new DateTime(2025, 11, 20, 19, 40, 59, 236, DateTimeKind.Utc).AddTicks(8093) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 227, DateTimeKind.Utc).AddTicks(3903));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 227, DateTimeKind.Utc).AddTicks(4312));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 227, DateTimeKind.Utc).AddTicks(4315));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 227, DateTimeKind.Utc).AddTicks(4319));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 227, DateTimeKind.Utc).AddTicks(4740));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 227, DateTimeKind.Utc).AddTicks(4748));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 227, DateTimeKind.Utc).AddTicks(4751));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 227, DateTimeKind.Utc).AddTicks(4755));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 227, DateTimeKind.Utc).AddTicks(4759));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 227, DateTimeKind.Utc).AddTicks(4762));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 227, DateTimeKind.Utc).AddTicks(4767));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 227, DateTimeKind.Utc).AddTicks(4770));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 225, DateTimeKind.Utc).AddTicks(7302));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 225, DateTimeKind.Utc).AddTicks(7757));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 225, DateTimeKind.Utc).AddTicks(7760));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 225, DateTimeKind.Utc).AddTicks(7763));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 225, DateTimeKind.Utc).AddTicks(7766));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 225, DateTimeKind.Utc).AddTicks(7769));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 225, DateTimeKind.Utc).AddTicks(7771));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 225, DateTimeKind.Utc).AddTicks(7774));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2025, 11, 20, 19, 40, 59, 231, DateTimeKind.Utc).AddTicks(6490), new DateTime(2025, 11, 20, 19, 40, 59, 231, DateTimeKind.Utc).AddTicks(4157), new DateTime(2026, 5, 20, 19, 40, 59, 231, DateTimeKind.Utc).AddTicks(4742) });

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 232, DateTimeKind.Utc).AddTicks(2176));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 234, DateTimeKind.Utc).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 234, DateTimeKind.Utc).AddTicks(4933));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 234, DateTimeKind.Utc).AddTicks(4937));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 234, DateTimeKind.Utc).AddTicks(4942));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 234, DateTimeKind.Utc).AddTicks(4946));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 234, DateTimeKind.Utc).AddTicks(4958));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 234, DateTimeKind.Utc).AddTicks(4962));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 234, DateTimeKind.Utc).AddTicks(4965));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 234, DateTimeKind.Utc).AddTicks(4972));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 234, DateTimeKind.Utc).AddTicks(4978));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 234, DateTimeKind.Utc).AddTicks(4982));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 234, DateTimeKind.Utc).AddTicks(4986));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 234, DateTimeKind.Utc).AddTicks(4991));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 234, DateTimeKind.Utc).AddTicks(4994));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 234, DateTimeKind.Utc).AddTicks(4998));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 234, DateTimeKind.Utc).AddTicks(5001));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 234, DateTimeKind.Utc).AddTicks(5007));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 234, DateTimeKind.Utc).AddTicks(5013));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 234, DateTimeKind.Utc).AddTicks(5016));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 234, DateTimeKind.Utc).AddTicks(5020));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 234, DateTimeKind.Utc).AddTicks(5090));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 234, DateTimeKind.Utc).AddTicks(5095));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 234, DateTimeKind.Utc).AddTicks(5098));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 234, DateTimeKind.Utc).AddTicks(5102));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 235, DateTimeKind.Utc).AddTicks(6663));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 235, DateTimeKind.Utc).AddTicks(7028));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 235, DateTimeKind.Utc).AddTicks(7032));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 235, DateTimeKind.Utc).AddTicks(7034));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 235, DateTimeKind.Utc).AddTicks(7037));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 235, DateTimeKind.Utc).AddTicks(7052));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 235, DateTimeKind.Utc).AddTicks(7055));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 235, DateTimeKind.Utc).AddTicks(7058));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 235, DateTimeKind.Utc).AddTicks(7060));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 235, DateTimeKind.Utc).AddTicks(7064));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 235, DateTimeKind.Utc).AddTicks(7069));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 235, DateTimeKind.Utc).AddTicks(7072));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 235, DateTimeKind.Utc).AddTicks(7074));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 235, DateTimeKind.Utc).AddTicks(7077));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 235, DateTimeKind.Utc).AddTicks(7079));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 233, DateTimeKind.Utc).AddTicks(5344));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 233, DateTimeKind.Utc).AddTicks(5744));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 233, DateTimeKind.Utc).AddTicks(5749));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 230, DateTimeKind.Utc).AddTicks(2867));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 230, DateTimeKind.Utc).AddTicks(3264));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 230, DateTimeKind.Utc).AddTicks(3267));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 230, DateTimeKind.Utc).AddTicks(3270));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 230, DateTimeKind.Utc).AddTicks(3273));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 230, DateTimeKind.Utc).AddTicks(3276));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 230, DateTimeKind.Utc).AddTicks(3278));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 230, DateTimeKind.Utc).AddTicks(3281));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 230, DateTimeKind.Utc).AddTicks(3283));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 230, DateTimeKind.Utc).AddTicks(3285));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 230, DateTimeKind.Utc).AddTicks(3288));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 223, DateTimeKind.Utc).AddTicks(8291));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 223, DateTimeKind.Utc).AddTicks(8710));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 223, DateTimeKind.Utc).AddTicks(8713));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 223, DateTimeKind.Utc).AddTicks(8715));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 223, DateTimeKind.Utc).AddTicks(8718));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 223, DateTimeKind.Utc).AddTicks(8721));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 228, DateTimeKind.Utc).AddTicks(2281));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 40, 59, 228, DateTimeKind.Utc).AddTicks(2681));
        }
    }
}
