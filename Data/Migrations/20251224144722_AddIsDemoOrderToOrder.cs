using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kokomija.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDemoOrderToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDemoOrder",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 14, 47, 20, 210, DateTimeKind.Utc).AddTicks(7480), new DateTime(2025, 12, 24, 14, 47, 20, 210, DateTimeKind.Utc).AddTicks(7786) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 14, 47, 20, 210, DateTimeKind.Utc).AddTicks(8082), new DateTime(2025, 12, 24, 14, 47, 20, 210, DateTimeKind.Utc).AddTicks(8082) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 14, 47, 20, 210, DateTimeKind.Utc).AddTicks(8085), new DateTime(2025, 12, 24, 14, 47, 20, 210, DateTimeKind.Utc).AddTicks(8086) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 14, 47, 20, 210, DateTimeKind.Utc).AddTicks(8088), new DateTime(2025, 12, 24, 14, 47, 20, 210, DateTimeKind.Utc).AddTicks(8089) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 14, 47, 20, 210, DateTimeKind.Utc).AddTicks(8091), new DateTime(2025, 12, 24, 14, 47, 20, 210, DateTimeKind.Utc).AddTicks(8092) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 14, 47, 20, 213, DateTimeKind.Utc).AddTicks(243), new DateTime(2025, 12, 24, 14, 47, 20, 213, DateTimeKind.Utc).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 14, 47, 20, 213, DateTimeKind.Utc).AddTicks(842), new DateTime(2025, 12, 24, 14, 47, 20, 213, DateTimeKind.Utc).AddTicks(843) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 14, 47, 20, 212, DateTimeKind.Utc).AddTicks(1619), new DateTime(2025, 12, 24, 14, 47, 20, 211, DateTimeKind.Utc).AddTicks(4816), new DateTime(2025, 12, 24, 14, 47, 20, 212, DateTimeKind.Utc).AddTicks(2050) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 223, DateTimeKind.Utc).AddTicks(8582));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 223, DateTimeKind.Utc).AddTicks(8905));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 24, 14, 47, 20, 223, DateTimeKind.Utc).AddTicks(1572), new DateTime(2025, 12, 24, 14, 47, 20, 223, DateTimeKind.Utc).AddTicks(1215) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 209, DateTimeKind.Utc).AddTicks(4033));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 209, DateTimeKind.Utc).AddTicks(4351));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 209, DateTimeKind.Utc).AddTicks(4354));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 209, DateTimeKind.Utc).AddTicks(4357));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 209, DateTimeKind.Utc).AddTicks(4710));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 209, DateTimeKind.Utc).AddTicks(4716));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 209, DateTimeKind.Utc).AddTicks(4718));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 209, DateTimeKind.Utc).AddTicks(4721));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 209, DateTimeKind.Utc).AddTicks(4724));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 209, DateTimeKind.Utc).AddTicks(4727));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 209, DateTimeKind.Utc).AddTicks(4730));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 209, DateTimeKind.Utc).AddTicks(4733));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 208, DateTimeKind.Utc).AddTicks(897));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 208, DateTimeKind.Utc).AddTicks(1226));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 208, DateTimeKind.Utc).AddTicks(1229));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 208, DateTimeKind.Utc).AddTicks(1231));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 208, DateTimeKind.Utc).AddTicks(1234));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 208, DateTimeKind.Utc).AddTicks(1236));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 208, DateTimeKind.Utc).AddTicks(1238));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 208, DateTimeKind.Utc).AddTicks(1240));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2025, 12, 24, 14, 47, 20, 218, DateTimeKind.Utc).AddTicks(3475), new DateTime(2025, 12, 24, 14, 47, 20, 218, DateTimeKind.Utc).AddTicks(1788), new DateTime(2026, 6, 24, 14, 47, 20, 218, DateTimeKind.Utc).AddTicks(2117) });

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 218, DateTimeKind.Utc).AddTicks(8429));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 220, DateTimeKind.Utc).AddTicks(5760));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 220, DateTimeKind.Utc).AddTicks(6098));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 220, DateTimeKind.Utc).AddTicks(6101));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 220, DateTimeKind.Utc).AddTicks(6104));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 220, DateTimeKind.Utc).AddTicks(6107));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 220, DateTimeKind.Utc).AddTicks(6120));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 220, DateTimeKind.Utc).AddTicks(6123));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 220, DateTimeKind.Utc).AddTicks(6125));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 220, DateTimeKind.Utc).AddTicks(6130));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 220, DateTimeKind.Utc).AddTicks(6134));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 220, DateTimeKind.Utc).AddTicks(6136));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 220, DateTimeKind.Utc).AddTicks(6139));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 220, DateTimeKind.Utc).AddTicks(6141));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 220, DateTimeKind.Utc).AddTicks(6143));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 220, DateTimeKind.Utc).AddTicks(6146));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 220, DateTimeKind.Utc).AddTicks(6148));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 220, DateTimeKind.Utc).AddTicks(6153));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 220, DateTimeKind.Utc).AddTicks(6157));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 220, DateTimeKind.Utc).AddTicks(6189));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 220, DateTimeKind.Utc).AddTicks(6191));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 220, DateTimeKind.Utc).AddTicks(6194));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 220, DateTimeKind.Utc).AddTicks(6196));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 220, DateTimeKind.Utc).AddTicks(6198));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 220, DateTimeKind.Utc).AddTicks(6201));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 222, DateTimeKind.Utc).AddTicks(2410));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 222, DateTimeKind.Utc).AddTicks(3016));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 222, DateTimeKind.Utc).AddTicks(3022));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 222, DateTimeKind.Utc).AddTicks(3026));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 222, DateTimeKind.Utc).AddTicks(3028));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 222, DateTimeKind.Utc).AddTicks(3050));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 222, DateTimeKind.Utc).AddTicks(3055));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 222, DateTimeKind.Utc).AddTicks(3057));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 222, DateTimeKind.Utc).AddTicks(3060));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 222, DateTimeKind.Utc).AddTicks(3065));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 222, DateTimeKind.Utc).AddTicks(3070));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 222, DateTimeKind.Utc).AddTicks(3073));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 222, DateTimeKind.Utc).AddTicks(3076));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 222, DateTimeKind.Utc).AddTicks(3079));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 222, DateTimeKind.Utc).AddTicks(3081));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 219, DateTimeKind.Utc).AddTicks(8478));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 219, DateTimeKind.Utc).AddTicks(8793));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 219, DateTimeKind.Utc).AddTicks(8797));

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 14, 47, 20, 214, DateTimeKind.Utc).AddTicks(7016), new DateTime(2025, 12, 24, 14, 47, 20, 214, DateTimeKind.Utc).AddTicks(7323) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 14, 47, 20, 214, DateTimeKind.Utc).AddTicks(7627), new DateTime(2025, 12, 24, 14, 47, 20, 214, DateTimeKind.Utc).AddTicks(7627) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 14, 47, 20, 214, DateTimeKind.Utc).AddTicks(7630), new DateTime(2025, 12, 24, 14, 47, 20, 214, DateTimeKind.Utc).AddTicks(7631) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 14, 47, 20, 214, DateTimeKind.Utc).AddTicks(7633), new DateTime(2025, 12, 24, 14, 47, 20, 214, DateTimeKind.Utc).AddTicks(7634) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 14, 47, 20, 214, DateTimeKind.Utc).AddTicks(7637), new DateTime(2025, 12, 24, 14, 47, 20, 214, DateTimeKind.Utc).AddTicks(7637) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 14, 47, 20, 215, DateTimeKind.Utc).AddTicks(7483), new DateTime(2025, 12, 24, 14, 47, 20, 215, DateTimeKind.Utc).AddTicks(7787) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 14, 47, 20, 215, DateTimeKind.Utc).AddTicks(8141), new DateTime(2025, 12, 24, 14, 47, 20, 215, DateTimeKind.Utc).AddTicks(8142) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 14, 47, 20, 215, DateTimeKind.Utc).AddTicks(8145), new DateTime(2025, 12, 24, 14, 47, 20, 215, DateTimeKind.Utc).AddTicks(8146) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 14, 47, 20, 215, DateTimeKind.Utc).AddTicks(8149), new DateTime(2025, 12, 24, 14, 47, 20, 215, DateTimeKind.Utc).AddTicks(8150) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 14, 47, 20, 215, DateTimeKind.Utc).AddTicks(8154), new DateTime(2025, 12, 24, 14, 47, 20, 215, DateTimeKind.Utc).AddTicks(8154) });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 213, DateTimeKind.Utc).AddTicks(8884));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 213, DateTimeKind.Utc).AddTicks(9192));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 213, DateTimeKind.Utc).AddTicks(9194));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 213, DateTimeKind.Utc).AddTicks(9196));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 213, DateTimeKind.Utc).AddTicks(9198));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 213, DateTimeKind.Utc).AddTicks(9200));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 213, DateTimeKind.Utc).AddTicks(9202));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 213, DateTimeKind.Utc).AddTicks(9204));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 213, DateTimeKind.Utc).AddTicks(9206));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 213, DateTimeKind.Utc).AddTicks(9208));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 213, DateTimeKind.Utc).AddTicks(9210));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 205, DateTimeKind.Utc).AddTicks(7210));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 205, DateTimeKind.Utc).AddTicks(7534));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 205, DateTimeKind.Utc).AddTicks(7536));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 205, DateTimeKind.Utc).AddTicks(7538));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 205, DateTimeKind.Utc).AddTicks(7540));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 205, DateTimeKind.Utc).AddTicks(7542));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 210, DateTimeKind.Utc).AddTicks(581));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 14, 47, 20, 210, DateTimeKind.Utc).AddTicks(893));

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 14, 47, 20, 217, DateTimeKind.Utc).AddTicks(82), new DateTime(2025, 12, 24, 14, 47, 20, 217, DateTimeKind.Utc).AddTicks(1083) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 14, 47, 20, 217, DateTimeKind.Utc).AddTicks(2217), new DateTime(2025, 12, 24, 14, 47, 20, 217, DateTimeKind.Utc).AddTicks(2217) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 14, 47, 20, 217, DateTimeKind.Utc).AddTicks(2221), new DateTime(2025, 12, 24, 14, 47, 20, 217, DateTimeKind.Utc).AddTicks(2221) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDemoOrder",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 15, DateTimeKind.Utc).AddTicks(2174), new DateTime(2025, 12, 19, 16, 7, 56, 15, DateTimeKind.Utc).AddTicks(2485) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 15, DateTimeKind.Utc).AddTicks(2784), new DateTime(2025, 12, 19, 16, 7, 56, 15, DateTimeKind.Utc).AddTicks(2785) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 15, DateTimeKind.Utc).AddTicks(2787), new DateTime(2025, 12, 19, 16, 7, 56, 15, DateTimeKind.Utc).AddTicks(2788) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 15, DateTimeKind.Utc).AddTicks(2791), new DateTime(2025, 12, 19, 16, 7, 56, 15, DateTimeKind.Utc).AddTicks(2791) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 15, DateTimeKind.Utc).AddTicks(2794), new DateTime(2025, 12, 19, 16, 7, 56, 15, DateTimeKind.Utc).AddTicks(2794) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 16, DateTimeKind.Utc).AddTicks(5679), new DateTime(2025, 12, 19, 16, 7, 56, 16, DateTimeKind.Utc).AddTicks(5988) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 16, DateTimeKind.Utc).AddTicks(6370), new DateTime(2025, 12, 19, 16, 7, 56, 16, DateTimeKind.Utc).AddTicks(6371) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 15, DateTimeKind.Utc).AddTicks(8607), new DateTime(2025, 12, 19, 16, 7, 56, 15, DateTimeKind.Utc).AddTicks(7258), new DateTime(2025, 12, 19, 16, 7, 56, 15, DateTimeKind.Utc).AddTicks(8906) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 28, DateTimeKind.Utc).AddTicks(2335));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 28, DateTimeKind.Utc).AddTicks(2641));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 27, DateTimeKind.Utc).AddTicks(6031), new DateTime(2025, 12, 19, 16, 7, 56, 27, DateTimeKind.Utc).AddTicks(5689) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 13, DateTimeKind.Utc).AddTicks(4787));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 13, DateTimeKind.Utc).AddTicks(5103));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 13, DateTimeKind.Utc).AddTicks(5106));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 13, DateTimeKind.Utc).AddTicks(5109));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 13, DateTimeKind.Utc).AddTicks(5437));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 13, DateTimeKind.Utc).AddTicks(5444));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 13, DateTimeKind.Utc).AddTicks(5446));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 13, DateTimeKind.Utc).AddTicks(5449));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 13, DateTimeKind.Utc).AddTicks(5452));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 13, DateTimeKind.Utc).AddTicks(5455));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 13, DateTimeKind.Utc).AddTicks(5459));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 13, DateTimeKind.Utc).AddTicks(5461));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 12, DateTimeKind.Utc).AddTicks(1691));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 12, DateTimeKind.Utc).AddTicks(2012));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 12, DateTimeKind.Utc).AddTicks(2014));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 12, DateTimeKind.Utc).AddTicks(2016));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 12, DateTimeKind.Utc).AddTicks(2018));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 12, DateTimeKind.Utc).AddTicks(2020));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 12, DateTimeKind.Utc).AddTicks(2023));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 12, DateTimeKind.Utc).AddTicks(2025));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 22, DateTimeKind.Utc).AddTicks(5375), new DateTime(2025, 12, 19, 16, 7, 56, 22, DateTimeKind.Utc).AddTicks(3360), new DateTime(2026, 6, 19, 16, 7, 56, 22, DateTimeKind.Utc).AddTicks(3743) });

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 23, DateTimeKind.Utc).AddTicks(835));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7356));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7735));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7739));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7742));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7745));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7757));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7760));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7763));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7768));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7811));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7814));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7816));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7818));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7821));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7823));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7825));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7830));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7833));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7836));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7838));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7841));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7843));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7845));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7847));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 26, DateTimeKind.Utc).AddTicks(8170));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 26, DateTimeKind.Utc).AddTicks(8504));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 26, DateTimeKind.Utc).AddTicks(8506));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 26, DateTimeKind.Utc).AddTicks(8508));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 26, DateTimeKind.Utc).AddTicks(8510));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 26, DateTimeKind.Utc).AddTicks(8517));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 26, DateTimeKind.Utc).AddTicks(8520));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 26, DateTimeKind.Utc).AddTicks(8521));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 26, DateTimeKind.Utc).AddTicks(8523));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 26, DateTimeKind.Utc).AddTicks(8526));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 26, DateTimeKind.Utc).AddTicks(8530));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 26, DateTimeKind.Utc).AddTicks(8532));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 26, DateTimeKind.Utc).AddTicks(8534));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 26, DateTimeKind.Utc).AddTicks(8550));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 26, DateTimeKind.Utc).AddTicks(8552));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 24, DateTimeKind.Utc).AddTicks(5154));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 24, DateTimeKind.Utc).AddTicks(5565));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 24, DateTimeKind.Utc).AddTicks(5572));

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 18, DateTimeKind.Utc).AddTicks(7395), new DateTime(2025, 12, 19, 16, 7, 56, 18, DateTimeKind.Utc).AddTicks(7838) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 18, DateTimeKind.Utc).AddTicks(8268), new DateTime(2025, 12, 19, 16, 7, 56, 18, DateTimeKind.Utc).AddTicks(8269) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 18, DateTimeKind.Utc).AddTicks(8273), new DateTime(2025, 12, 19, 16, 7, 56, 18, DateTimeKind.Utc).AddTicks(8273) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 18, DateTimeKind.Utc).AddTicks(8334), new DateTime(2025, 12, 19, 16, 7, 56, 18, DateTimeKind.Utc).AddTicks(8334) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 18, DateTimeKind.Utc).AddTicks(8339), new DateTime(2025, 12, 19, 16, 7, 56, 18, DateTimeKind.Utc).AddTicks(8339) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 20, DateTimeKind.Utc).AddTicks(5326), new DateTime(2025, 12, 19, 16, 7, 56, 20, DateTimeKind.Utc).AddTicks(5697) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 20, DateTimeKind.Utc).AddTicks(6017), new DateTime(2025, 12, 19, 16, 7, 56, 20, DateTimeKind.Utc).AddTicks(6018) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 20, DateTimeKind.Utc).AddTicks(6020), new DateTime(2025, 12, 19, 16, 7, 56, 20, DateTimeKind.Utc).AddTicks(6021) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 20, DateTimeKind.Utc).AddTicks(6025), new DateTime(2025, 12, 19, 16, 7, 56, 20, DateTimeKind.Utc).AddTicks(6025) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 20, DateTimeKind.Utc).AddTicks(6029), new DateTime(2025, 12, 19, 16, 7, 56, 20, DateTimeKind.Utc).AddTicks(6029) });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 17, DateTimeKind.Utc).AddTicks(5505));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 17, DateTimeKind.Utc).AddTicks(5815));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 17, DateTimeKind.Utc).AddTicks(5817));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 17, DateTimeKind.Utc).AddTicks(5819));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 17, DateTimeKind.Utc).AddTicks(5820));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 17, DateTimeKind.Utc).AddTicks(5822));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 17, DateTimeKind.Utc).AddTicks(5824));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 17, DateTimeKind.Utc).AddTicks(5826));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 17, DateTimeKind.Utc).AddTicks(5828));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 17, DateTimeKind.Utc).AddTicks(5830));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 17, DateTimeKind.Utc).AddTicks(5832));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 10, DateTimeKind.Utc).AddTicks(6085));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 10, DateTimeKind.Utc).AddTicks(6423));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 10, DateTimeKind.Utc).AddTicks(6425));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 10, DateTimeKind.Utc).AddTicks(6427));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 10, DateTimeKind.Utc).AddTicks(6430));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 10, DateTimeKind.Utc).AddTicks(6432));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 14, DateTimeKind.Utc).AddTicks(2417));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 14, DateTimeKind.Utc).AddTicks(2796));

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 21, DateTimeKind.Utc).AddTicks(3598), new DateTime(2025, 12, 19, 16, 7, 56, 21, DateTimeKind.Utc).AddTicks(3901) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 21, DateTimeKind.Utc).AddTicks(4203), new DateTime(2025, 12, 19, 16, 7, 56, 21, DateTimeKind.Utc).AddTicks(4204) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 21, DateTimeKind.Utc).AddTicks(4207), new DateTime(2025, 12, 19, 16, 7, 56, 21, DateTimeKind.Utc).AddTicks(4207) });
        }
    }
}
