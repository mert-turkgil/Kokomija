using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kokomija.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryNameKeyAndImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameKey",
                table: "Categories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 27, 18, 3, 55, 465, DateTimeKind.Utc).AddTicks(1655), new DateTime(2025, 10, 27, 18, 3, 55, 465, DateTimeKind.Utc).AddTicks(1974) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 27, 18, 3, 55, 465, DateTimeKind.Utc).AddTicks(2362), new DateTime(2025, 10, 27, 18, 3, 55, 465, DateTimeKind.Utc).AddTicks(2363) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 27, 18, 3, 55, 465, DateTimeKind.Utc).AddTicks(2366), new DateTime(2025, 10, 27, 18, 3, 55, 465, DateTimeKind.Utc).AddTicks(2366) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 27, 18, 3, 55, 465, DateTimeKind.Utc).AddTicks(2369), new DateTime(2025, 10, 27, 18, 3, 55, 465, DateTimeKind.Utc).AddTicks(2369) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 27, 18, 3, 55, 465, DateTimeKind.Utc).AddTicks(2372), new DateTime(2025, 10, 27, 18, 3, 55, 465, DateTimeKind.Utc).AddTicks(2373) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 27, 18, 3, 55, 476, DateTimeKind.Utc).AddTicks(1472), new DateTime(2025, 10, 27, 18, 3, 55, 476, DateTimeKind.Utc).AddTicks(789) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 27, 18, 3, 55, 476, DateTimeKind.Utc).AddTicks(1905), new DateTime(2025, 10, 27, 18, 3, 55, 476, DateTimeKind.Utc).AddTicks(1904) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 27, 18, 3, 55, 476, DateTimeKind.Utc).AddTicks(1909), new DateTime(2025, 10, 27, 18, 3, 55, 476, DateTimeKind.Utc).AddTicks(1908) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 27, 18, 3, 55, 476, DateTimeKind.Utc).AddTicks(1913), new DateTime(2025, 10, 27, 18, 3, 55, 476, DateTimeKind.Utc).AddTicks(1912) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 27, 18, 3, 55, 476, DateTimeKind.Utc).AddTicks(1917), new DateTime(2025, 10, 27, 18, 3, 55, 476, DateTimeKind.Utc).AddTicks(1917) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ImageUrl", "NameKey" },
                values: new object[] { new DateTime(2025, 10, 27, 18, 3, 55, 463, DateTimeKind.Utc).AddTicks(3558), "categories/women.jpg", "Category_Women" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ImageUrl", "NameKey" },
                values: new object[] { new DateTime(2025, 10, 27, 18, 3, 55, 463, DateTimeKind.Utc).AddTicks(3954), "categories/men.jpg", "Category_Men" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ImageUrl", "NameKey" },
                values: new object[] { new DateTime(2025, 10, 27, 18, 3, 55, 463, DateTimeKind.Utc).AddTicks(3957), "categories/outerwear.jpg", "Category_Outerwear" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ImageUrl", "NameKey" },
                values: new object[] { new DateTime(2025, 10, 27, 18, 3, 55, 463, DateTimeKind.Utc).AddTicks(3960), "categories/accessories.jpg", "Category_Accessories" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "IconCssClass", "NameKey" },
                values: new object[] { new DateTime(2025, 10, 27, 18, 3, 55, 463, DateTimeKind.Utc).AddTicks(4312), "fas fa-tshirt", "Category_Dresses" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "IconCssClass", "NameKey" },
                values: new object[] { new DateTime(2025, 10, 27, 18, 3, 55, 463, DateTimeKind.Utc).AddTicks(4318), "fas fa-tshirt", "Category_Skirts" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "IconCssClass", "NameKey" },
                values: new object[] { new DateTime(2025, 10, 27, 18, 3, 55, 463, DateTimeKind.Utc).AddTicks(4321), "fas fa-tshirt", "Category_Blouses" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "IconCssClass", "NameKey" },
                values: new object[] { new DateTime(2025, 10, 27, 18, 3, 55, 463, DateTimeKind.Utc).AddTicks(4324), "fas fa-tshirt", "Category_WomenPants" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "IconCssClass", "NameKey" },
                values: new object[] { new DateTime(2025, 10, 27, 18, 3, 55, 463, DateTimeKind.Utc).AddTicks(4328), "fas fa-tshirt", "Category_Shirts" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "IconCssClass", "NameKey" },
                values: new object[] { new DateTime(2025, 10, 27, 18, 3, 55, 463, DateTimeKind.Utc).AddTicks(4331), "fas fa-tshirt", "Category_MenPants" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "IconCssClass", "NameKey" },
                values: new object[] { new DateTime(2025, 10, 27, 18, 3, 55, 463, DateTimeKind.Utc).AddTicks(4334), "fas fa-tshirt", "Category_TShirts" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "IconCssClass", "NameKey" },
                values: new object[] { new DateTime(2025, 10, 27, 18, 3, 55, 463, DateTimeKind.Utc).AddTicks(4337), "fas fa-tshirt", "Category_Sweatshirts" });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 461, DateTimeKind.Utc).AddTicks(2806));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 461, DateTimeKind.Utc).AddTicks(3345));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 461, DateTimeKind.Utc).AddTicks(3348));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 461, DateTimeKind.Utc).AddTicks(3351));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 461, DateTimeKind.Utc).AddTicks(3401));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 461, DateTimeKind.Utc).AddTicks(3405));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 461, DateTimeKind.Utc).AddTicks(3408));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 461, DateTimeKind.Utc).AddTicks(3411));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1498));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1905));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1910));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1913));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1916));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1931));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1935));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1938));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1941));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1946));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1949));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1952));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1955));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1959));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1962));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1965));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1968));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1972));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1976));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1979));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1982));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1985));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1989));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1992));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1995));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1998));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2001));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2046));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2049));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2053));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2056));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2059));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2062));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2068));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2071));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2074));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2077));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2080));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2087));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2090));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2093));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2097));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2100));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2103));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(7780));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8310));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8315));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8323));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8329));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8347));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8351));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8355));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8360));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8368));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8372));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8415));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8448));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8453));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8457));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8462));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8466));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8473));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8478));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8482));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8487));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8492));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8497));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8501));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8545));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8551));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8555));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8559));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8579));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8584));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8590));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8595));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8600));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8606));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8610));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8615));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8619));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8623));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8638));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8642));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8657));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8661));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8665));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8668));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8672));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8676));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8680));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8683));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8687));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8691));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8695));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8698));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8702));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8729));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8733));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8738));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8741));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8745));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8749));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8753));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8757));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8768));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8772));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8776));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8780));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8785));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8789));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8793));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8796));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8800));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8816));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8820));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8824));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8828));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8832));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8836));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8843));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8847));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8850));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8854));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8857));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8863));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8866));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8870));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8873));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8877));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8883));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8887));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8891));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8895));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8899));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8903));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8906));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8910));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8914));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8918));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8921));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8925));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8931));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8934));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8938));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8941));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8948));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8952));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8956));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8960));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8971));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8975));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8979));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8983));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8987));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8991));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8998));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9002));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9006));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9010));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9014));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9018));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9022));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9025));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9029));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9033));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9037));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 124,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9040));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 125,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9047));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 126,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9051));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 127,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9055));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 128,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9059));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 129,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9063));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 130,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9069));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 131,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9073));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 132,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9077));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 133,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9091));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 134,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9095));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 135,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9099));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 136,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9102));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 468, DateTimeKind.Utc).AddTicks(3172));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 468, DateTimeKind.Utc).AddTicks(3792));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 468, DateTimeKind.Utc).AddTicks(3795));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 468, DateTimeKind.Utc).AddTicks(3798));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 468, DateTimeKind.Utc).AddTicks(3802));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 468, DateTimeKind.Utc).AddTicks(3857));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 468, DateTimeKind.Utc).AddTicks(3860));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 468, DateTimeKind.Utc).AddTicks(3864));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 468, DateTimeKind.Utc).AddTicks(3867));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 468, DateTimeKind.Utc).AddTicks(3870));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 468, DateTimeKind.Utc).AddTicks(3874));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 468, DateTimeKind.Utc).AddTicks(3877));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 468, DateTimeKind.Utc).AddTicks(3880));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 468, DateTimeKind.Utc).AddTicks(3884));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 468, DateTimeKind.Utc).AddTicks(3887));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 466, DateTimeKind.Utc).AddTicks(235));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 466, DateTimeKind.Utc).AddTicks(588));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 466, DateTimeKind.Utc).AddTicks(591));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 466, DateTimeKind.Utc).AddTicks(593));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 466, DateTimeKind.Utc).AddTicks(595));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 466, DateTimeKind.Utc).AddTicks(597));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 466, DateTimeKind.Utc).AddTicks(599));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 466, DateTimeKind.Utc).AddTicks(601));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 458, DateTimeKind.Utc).AddTicks(9124));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 458, DateTimeKind.Utc).AddTicks(9721));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 458, DateTimeKind.Utc).AddTicks(9724));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 458, DateTimeKind.Utc).AddTicks(9727));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 458, DateTimeKind.Utc).AddTicks(9730));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 458, DateTimeKind.Utc).AddTicks(9733));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 464, DateTimeKind.Utc).AddTicks(3142));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 464, DateTimeKind.Utc).AddTicks(3471));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 464, DateTimeKind.Utc).AddTicks(3473));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 464, DateTimeKind.Utc).AddTicks(3476));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameKey",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 22, 15, 55, 48, 501, DateTimeKind.Utc).AddTicks(4070), new DateTime(2025, 10, 22, 15, 55, 48, 501, DateTimeKind.Utc).AddTicks(5164) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 22, 15, 55, 48, 501, DateTimeKind.Utc).AddTicks(6474), new DateTime(2025, 10, 22, 15, 55, 48, 501, DateTimeKind.Utc).AddTicks(6475) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 22, 15, 55, 48, 501, DateTimeKind.Utc).AddTicks(6478), new DateTime(2025, 10, 22, 15, 55, 48, 501, DateTimeKind.Utc).AddTicks(6479) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 22, 15, 55, 48, 501, DateTimeKind.Utc).AddTicks(6482), new DateTime(2025, 10, 22, 15, 55, 48, 501, DateTimeKind.Utc).AddTicks(6482) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 22, 15, 55, 48, 501, DateTimeKind.Utc).AddTicks(6485), new DateTime(2025, 10, 22, 15, 55, 48, 501, DateTimeKind.Utc).AddTicks(6486) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 22, 15, 55, 48, 511, DateTimeKind.Utc).AddTicks(1594), new DateTime(2025, 10, 22, 15, 55, 48, 511, DateTimeKind.Utc).AddTicks(1010) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 22, 15, 55, 48, 511, DateTimeKind.Utc).AddTicks(1988), new DateTime(2025, 10, 22, 15, 55, 48, 511, DateTimeKind.Utc).AddTicks(1986) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 22, 15, 55, 48, 511, DateTimeKind.Utc).AddTicks(1991), new DateTime(2025, 10, 22, 15, 55, 48, 511, DateTimeKind.Utc).AddTicks(1991) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 22, 15, 55, 48, 511, DateTimeKind.Utc).AddTicks(1995), new DateTime(2025, 10, 22, 15, 55, 48, 511, DateTimeKind.Utc).AddTicks(1994) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 22, 15, 55, 48, 511, DateTimeKind.Utc).AddTicks(1998), new DateTime(2025, 10, 22, 15, 55, 48, 511, DateTimeKind.Utc).AddTicks(1997) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 10, 22, 15, 55, 48, 499, DateTimeKind.Utc).AddTicks(1300), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 10, 22, 15, 55, 48, 499, DateTimeKind.Utc).AddTicks(1637), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 10, 22, 15, 55, 48, 499, DateTimeKind.Utc).AddTicks(1640), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2025, 10, 22, 15, 55, 48, 499, DateTimeKind.Utc).AddTicks(1643), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "IconCssClass" },
                values: new object[] { new DateTime(2025, 10, 22, 15, 55, 48, 499, DateTimeKind.Utc).AddTicks(1980), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "IconCssClass" },
                values: new object[] { new DateTime(2025, 10, 22, 15, 55, 48, 499, DateTimeKind.Utc).AddTicks(1986), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "IconCssClass" },
                values: new object[] { new DateTime(2025, 10, 22, 15, 55, 48, 499, DateTimeKind.Utc).AddTicks(1989), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "IconCssClass" },
                values: new object[] { new DateTime(2025, 10, 22, 15, 55, 48, 499, DateTimeKind.Utc).AddTicks(1992), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "IconCssClass" },
                values: new object[] { new DateTime(2025, 10, 22, 15, 55, 48, 499, DateTimeKind.Utc).AddTicks(1995), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "IconCssClass" },
                values: new object[] { new DateTime(2025, 10, 22, 15, 55, 48, 499, DateTimeKind.Utc).AddTicks(1998), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "IconCssClass" },
                values: new object[] { new DateTime(2025, 10, 22, 15, 55, 48, 499, DateTimeKind.Utc).AddTicks(2001), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "IconCssClass" },
                values: new object[] { new DateTime(2025, 10, 22, 15, 55, 48, 499, DateTimeKind.Utc).AddTicks(2004), null });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 497, DateTimeKind.Utc).AddTicks(8094));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 497, DateTimeKind.Utc).AddTicks(8443));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 497, DateTimeKind.Utc).AddTicks(8447));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 497, DateTimeKind.Utc).AddTicks(8449));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 497, DateTimeKind.Utc).AddTicks(8452));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 497, DateTimeKind.Utc).AddTicks(8454));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 497, DateTimeKind.Utc).AddTicks(8457));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 497, DateTimeKind.Utc).AddTicks(8460));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(3218));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4470));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4474));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4478));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4482));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4497));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4501));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4505));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4516));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4521));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4525));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4530));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4534));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4582));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4587));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4592));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4599));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4603));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4607));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4610));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4614));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4617));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4621));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4624));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4627));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4631));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4638));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4642));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4645));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4649));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4653));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4656));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4665));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4669));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4673));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4676));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4681));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4690));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4696));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4700));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4705));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4709));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4712));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 505, DateTimeKind.Utc).AddTicks(4716));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(8422));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(8831));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(8837));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(8841));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(8846));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(8859));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(8863));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(8866));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(8870));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(8875));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(8879));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(8883));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(8909));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(8913));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(8917));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(8921));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(8925));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(8930));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(8934));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(8938));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(8941));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(8945));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(8949));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(8953));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(8992));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(8996));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9000));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9003));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9016));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9020));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9024));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9028));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9031));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9046));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9049));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9053));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9057));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9061));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9076));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9080));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9084));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9088));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9092));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9096));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9099));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9103));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9107));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9111));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9115));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9118));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9122));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9126));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9129));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9140));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9145));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9149));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9153));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9157));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9161));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9164));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9168));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9192));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9197));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9201));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9214));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9220));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9224));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9228));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9232));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9235));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9239));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9243));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9247));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9251));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9255));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9259));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9266));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9270));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9273));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9276));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9280));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9285));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9289));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9293));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9296));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9299));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9306));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9311));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9315));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9319));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9322));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9326));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9330));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9334));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9338));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9351));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9355));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9358));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9364));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9367));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9371));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9374));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9381));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9385));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9389));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9393));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9397));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9401));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9404));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9408));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9412));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9416));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9423));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9427));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9430));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9434));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9438));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9442));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9445));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9449));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9453));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9457));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9460));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 124,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9464));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 125,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9471));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 126,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9475));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 127,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9479));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 128,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9483));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 129,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9487));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 130,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9502));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 131,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9506));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 132,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9510));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 133,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9516));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 134,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9519));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 135,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9523));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 136,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 509, DateTimeKind.Utc).AddTicks(9526));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 504, DateTimeKind.Utc).AddTicks(5250));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 504, DateTimeKind.Utc).AddTicks(5601));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 504, DateTimeKind.Utc).AddTicks(5605));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 504, DateTimeKind.Utc).AddTicks(5609));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 504, DateTimeKind.Utc).AddTicks(5612));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 504, DateTimeKind.Utc).AddTicks(5616));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 504, DateTimeKind.Utc).AddTicks(5620));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 504, DateTimeKind.Utc).AddTicks(5623));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 504, DateTimeKind.Utc).AddTicks(5627));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 504, DateTimeKind.Utc).AddTicks(5631));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 504, DateTimeKind.Utc).AddTicks(5634));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 504, DateTimeKind.Utc).AddTicks(5638));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 504, DateTimeKind.Utc).AddTicks(5642));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 504, DateTimeKind.Utc).AddTicks(5645));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 504, DateTimeKind.Utc).AddTicks(5649));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 502, DateTimeKind.Utc).AddTicks(5854));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 502, DateTimeKind.Utc).AddTicks(6194));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 502, DateTimeKind.Utc).AddTicks(6230));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 502, DateTimeKind.Utc).AddTicks(6232));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 502, DateTimeKind.Utc).AddTicks(6235));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 502, DateTimeKind.Utc).AddTicks(6237));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 502, DateTimeKind.Utc).AddTicks(6239));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 502, DateTimeKind.Utc).AddTicks(6241));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 495, DateTimeKind.Utc).AddTicks(3701));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 495, DateTimeKind.Utc).AddTicks(4063));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 495, DateTimeKind.Utc).AddTicks(4065));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 495, DateTimeKind.Utc).AddTicks(4068));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 495, DateTimeKind.Utc).AddTicks(4070));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 495, DateTimeKind.Utc).AddTicks(4073));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 500, DateTimeKind.Utc).AddTicks(276));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 500, DateTimeKind.Utc).AddTicks(615));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 500, DateTimeKind.Utc).AddTicks(617));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 55, 48, 500, DateTimeKind.Utc).AddTicks(620));
        }
    }
}
