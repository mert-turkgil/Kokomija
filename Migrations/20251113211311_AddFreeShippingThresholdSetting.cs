using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kokomija.Migrations
{
    /// <inheritdoc />
    public partial class AddFreeShippingThresholdSetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 13, 21, 13, 10, 317, DateTimeKind.Utc).AddTicks(3913), new DateTime(2025, 11, 13, 21, 13, 10, 317, DateTimeKind.Utc).AddTicks(4318) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 13, 21, 13, 10, 317, DateTimeKind.Utc).AddTicks(5009), new DateTime(2025, 11, 13, 21, 13, 10, 317, DateTimeKind.Utc).AddTicks(5012) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 13, 21, 13, 10, 317, DateTimeKind.Utc).AddTicks(5018), new DateTime(2025, 11, 13, 21, 13, 10, 317, DateTimeKind.Utc).AddTicks(5018) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 13, 21, 13, 10, 317, DateTimeKind.Utc).AddTicks(5021), new DateTime(2025, 11, 13, 21, 13, 10, 317, DateTimeKind.Utc).AddTicks(5022) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 13, 21, 13, 10, 317, DateTimeKind.Utc).AddTicks(5027), new DateTime(2025, 11, 13, 21, 13, 10, 317, DateTimeKind.Utc).AddTicks(5028) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 13, 21, 13, 10, 325, DateTimeKind.Utc).AddTicks(680), new DateTime(2025, 11, 13, 21, 13, 10, 325, DateTimeKind.Utc).AddTicks(291) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 13, 21, 13, 10, 325, DateTimeKind.Utc).AddTicks(1016), new DateTime(2025, 11, 13, 21, 13, 10, 325, DateTimeKind.Utc).AddTicks(1015) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 13, 21, 13, 10, 325, DateTimeKind.Utc).AddTicks(1019), new DateTime(2025, 11, 13, 21, 13, 10, 325, DateTimeKind.Utc).AddTicks(1019) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 13, 21, 13, 10, 325, DateTimeKind.Utc).AddTicks(1023), new DateTime(2025, 11, 13, 21, 13, 10, 325, DateTimeKind.Utc).AddTicks(1022) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 13, 21, 13, 10, 325, DateTimeKind.Utc).AddTicks(1026), new DateTime(2025, 11, 13, 21, 13, 10, 325, DateTimeKind.Utc).AddTicks(1025) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 315, DateTimeKind.Utc).AddTicks(7148));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 315, DateTimeKind.Utc).AddTicks(7607));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 315, DateTimeKind.Utc).AddTicks(7611));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 315, DateTimeKind.Utc).AddTicks(7614));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 315, DateTimeKind.Utc).AddTicks(8048));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 315, DateTimeKind.Utc).AddTicks(8055));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 315, DateTimeKind.Utc).AddTicks(8059));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 315, DateTimeKind.Utc).AddTicks(8062));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 315, DateTimeKind.Utc).AddTicks(8083));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 315, DateTimeKind.Utc).AddTicks(8086));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 315, DateTimeKind.Utc).AddTicks(8090));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 315, DateTimeKind.Utc).AddTicks(8094));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 314, DateTimeKind.Utc).AddTicks(426));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 314, DateTimeKind.Utc).AddTicks(1265));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 314, DateTimeKind.Utc).AddTicks(1268));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 314, DateTimeKind.Utc).AddTicks(1271));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 314, DateTimeKind.Utc).AddTicks(1273));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 314, DateTimeKind.Utc).AddTicks(1276));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 314, DateTimeKind.Utc).AddTicks(1278));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 314, DateTimeKind.Utc).AddTicks(1281));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2025, 11, 13, 21, 13, 10, 319, DateTimeKind.Utc).AddTicks(8833), new DateTime(2025, 11, 13, 21, 13, 10, 319, DateTimeKind.Utc).AddTicks(6920), new DateTime(2026, 5, 13, 21, 13, 10, 319, DateTimeKind.Utc).AddTicks(7422) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 321, DateTimeKind.Utc).AddTicks(5854));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 321, DateTimeKind.Utc).AddTicks(6198));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 321, DateTimeKind.Utc).AddTicks(6202));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 321, DateTimeKind.Utc).AddTicks(6205));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 321, DateTimeKind.Utc).AddTicks(6209));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 321, DateTimeKind.Utc).AddTicks(6217));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 321, DateTimeKind.Utc).AddTicks(6221));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 321, DateTimeKind.Utc).AddTicks(6224));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 321, DateTimeKind.Utc).AddTicks(6229));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 321, DateTimeKind.Utc).AddTicks(6234));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 321, DateTimeKind.Utc).AddTicks(6237));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 321, DateTimeKind.Utc).AddTicks(6267));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 321, DateTimeKind.Utc).AddTicks(6271));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 321, DateTimeKind.Utc).AddTicks(6274));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 321, DateTimeKind.Utc).AddTicks(6277));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 321, DateTimeKind.Utc).AddTicks(6280));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 321, DateTimeKind.Utc).AddTicks(6285));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 321, DateTimeKind.Utc).AddTicks(6290));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 321, DateTimeKind.Utc).AddTicks(6294));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 321, DateTimeKind.Utc).AddTicks(6297));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 321, DateTimeKind.Utc).AddTicks(6300));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 321, DateTimeKind.Utc).AddTicks(6303));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 321, DateTimeKind.Utc).AddTicks(6306));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 321, DateTimeKind.Utc).AddTicks(6309));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 323, DateTimeKind.Utc).AddTicks(4259));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 323, DateTimeKind.Utc).AddTicks(5617));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 323, DateTimeKind.Utc).AddTicks(5621));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 323, DateTimeKind.Utc).AddTicks(5623));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 323, DateTimeKind.Utc).AddTicks(5626));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 323, DateTimeKind.Utc).AddTicks(5642));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 323, DateTimeKind.Utc).AddTicks(5645));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 323, DateTimeKind.Utc).AddTicks(5648));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 323, DateTimeKind.Utc).AddTicks(5651));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 323, DateTimeKind.Utc).AddTicks(5655));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 323, DateTimeKind.Utc).AddTicks(5661));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 323, DateTimeKind.Utc).AddTicks(5664));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 323, DateTimeKind.Utc).AddTicks(5667));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 323, DateTimeKind.Utc).AddTicks(5670));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 323, DateTimeKind.Utc).AddTicks(5672));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 320, DateTimeKind.Utc).AddTicks(8061));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 320, DateTimeKind.Utc).AddTicks(8377));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 320, DateTimeKind.Utc).AddTicks(8381));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 318, DateTimeKind.Utc).AddTicks(5835));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 318, DateTimeKind.Utc).AddTicks(6311));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 318, DateTimeKind.Utc).AddTicks(6313));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 318, DateTimeKind.Utc).AddTicks(6316));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 318, DateTimeKind.Utc).AddTicks(6318));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 318, DateTimeKind.Utc).AddTicks(6321));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 318, DateTimeKind.Utc).AddTicks(6323));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 318, DateTimeKind.Utc).AddTicks(6325));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 318, DateTimeKind.Utc).AddTicks(6327));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 318, DateTimeKind.Utc).AddTicks(6330));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "UpdatedAt" },
                values: new object[] { "Minimum order value for free shipping in PLN", new DateTime(2025, 11, 13, 21, 13, 10, 318, DateTimeKind.Utc).AddTicks(6332) });

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 311, DateTimeKind.Utc).AddTicks(8113));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 311, DateTimeKind.Utc).AddTicks(8450));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 311, DateTimeKind.Utc).AddTicks(8452));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 311, DateTimeKind.Utc).AddTicks(8455));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 311, DateTimeKind.Utc).AddTicks(8457));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 311, DateTimeKind.Utc).AddTicks(8459));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 316, DateTimeKind.Utc).AddTicks(5313));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 316, DateTimeKind.Utc).AddTicks(5634));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 316, DateTimeKind.Utc).AddTicks(5637));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 21, 13, 10, 316, DateTimeKind.Utc).AddTicks(5640));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 13, 18, 51, 11, 303, DateTimeKind.Utc).AddTicks(4479), new DateTime(2025, 11, 13, 18, 51, 11, 303, DateTimeKind.Utc).AddTicks(4999) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 13, 18, 51, 11, 303, DateTimeKind.Utc).AddTicks(5557), new DateTime(2025, 11, 13, 18, 51, 11, 303, DateTimeKind.Utc).AddTicks(5558) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 13, 18, 51, 11, 303, DateTimeKind.Utc).AddTicks(5561), new DateTime(2025, 11, 13, 18, 51, 11, 303, DateTimeKind.Utc).AddTicks(5562) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 13, 18, 51, 11, 303, DateTimeKind.Utc).AddTicks(5565), new DateTime(2025, 11, 13, 18, 51, 11, 303, DateTimeKind.Utc).AddTicks(5566) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 13, 18, 51, 11, 303, DateTimeKind.Utc).AddTicks(5569), new DateTime(2025, 11, 13, 18, 51, 11, 303, DateTimeKind.Utc).AddTicks(5570) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 13, 18, 51, 11, 311, DateTimeKind.Utc).AddTicks(4177), new DateTime(2025, 11, 13, 18, 51, 11, 311, DateTimeKind.Utc).AddTicks(3746) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 13, 18, 51, 11, 311, DateTimeKind.Utc).AddTicks(4529), new DateTime(2025, 11, 13, 18, 51, 11, 311, DateTimeKind.Utc).AddTicks(4528) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 13, 18, 51, 11, 311, DateTimeKind.Utc).AddTicks(4532), new DateTime(2025, 11, 13, 18, 51, 11, 311, DateTimeKind.Utc).AddTicks(4531) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 13, 18, 51, 11, 311, DateTimeKind.Utc).AddTicks(4535), new DateTime(2025, 11, 13, 18, 51, 11, 311, DateTimeKind.Utc).AddTicks(4535) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 13, 18, 51, 11, 311, DateTimeKind.Utc).AddTicks(4539), new DateTime(2025, 11, 13, 18, 51, 11, 311, DateTimeKind.Utc).AddTicks(4538) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 300, DateTimeKind.Utc).AddTicks(9751));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 301, DateTimeKind.Utc).AddTicks(250));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 301, DateTimeKind.Utc).AddTicks(254));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 301, DateTimeKind.Utc).AddTicks(262));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 301, DateTimeKind.Utc).AddTicks(864));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 301, DateTimeKind.Utc).AddTicks(873));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 301, DateTimeKind.Utc).AddTicks(877));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 301, DateTimeKind.Utc).AddTicks(884));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 301, DateTimeKind.Utc).AddTicks(888));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 301, DateTimeKind.Utc).AddTicks(895));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 301, DateTimeKind.Utc).AddTicks(901));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 301, DateTimeKind.Utc).AddTicks(904));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 299, DateTimeKind.Utc).AddTicks(2576));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 299, DateTimeKind.Utc).AddTicks(2974));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 299, DateTimeKind.Utc).AddTicks(2977));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 299, DateTimeKind.Utc).AddTicks(2979));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 299, DateTimeKind.Utc).AddTicks(2982));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 299, DateTimeKind.Utc).AddTicks(2984));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 299, DateTimeKind.Utc).AddTicks(2987));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 299, DateTimeKind.Utc).AddTicks(2989));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2025, 11, 13, 18, 51, 11, 307, DateTimeKind.Utc).AddTicks(262), new DateTime(2025, 11, 13, 18, 51, 11, 306, DateTimeKind.Utc).AddTicks(8081), new DateTime(2026, 5, 13, 18, 51, 11, 306, DateTimeKind.Utc).AddTicks(8735) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 308, DateTimeKind.Utc).AddTicks(8999));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 308, DateTimeKind.Utc).AddTicks(9351));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 308, DateTimeKind.Utc).AddTicks(9355));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 308, DateTimeKind.Utc).AddTicks(9358));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 308, DateTimeKind.Utc).AddTicks(9362));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 308, DateTimeKind.Utc).AddTicks(9374));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 308, DateTimeKind.Utc).AddTicks(9377));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 308, DateTimeKind.Utc).AddTicks(9380));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 308, DateTimeKind.Utc).AddTicks(9385));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 308, DateTimeKind.Utc).AddTicks(9389));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 308, DateTimeKind.Utc).AddTicks(9393));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 308, DateTimeKind.Utc).AddTicks(9396));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 308, DateTimeKind.Utc).AddTicks(9399));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 308, DateTimeKind.Utc).AddTicks(9402));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 308, DateTimeKind.Utc).AddTicks(9405));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 308, DateTimeKind.Utc).AddTicks(9408));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 308, DateTimeKind.Utc).AddTicks(9413));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 308, DateTimeKind.Utc).AddTicks(9418));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 308, DateTimeKind.Utc).AddTicks(9421));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 308, DateTimeKind.Utc).AddTicks(9424));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 308, DateTimeKind.Utc).AddTicks(9427));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 308, DateTimeKind.Utc).AddTicks(9430));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 308, DateTimeKind.Utc).AddTicks(9433));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 308, DateTimeKind.Utc).AddTicks(9436));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 309, DateTimeKind.Utc).AddTicks(9486));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 310, DateTimeKind.Utc).AddTicks(2));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 310, DateTimeKind.Utc).AddTicks(5));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 310, DateTimeKind.Utc).AddTicks(8));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 310, DateTimeKind.Utc).AddTicks(11));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 310, DateTimeKind.Utc).AddTicks(20));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 310, DateTimeKind.Utc).AddTicks(23));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 310, DateTimeKind.Utc).AddTicks(27));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 310, DateTimeKind.Utc).AddTicks(29));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 310, DateTimeKind.Utc).AddTicks(34));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 310, DateTimeKind.Utc).AddTicks(39));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 310, DateTimeKind.Utc).AddTicks(43));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 310, DateTimeKind.Utc).AddTicks(45));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 310, DateTimeKind.Utc).AddTicks(48));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 310, DateTimeKind.Utc).AddTicks(51));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 308, DateTimeKind.Utc).AddTicks(1112));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 308, DateTimeKind.Utc).AddTicks(1434));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 308, DateTimeKind.Utc).AddTicks(1438));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 304, DateTimeKind.Utc).AddTicks(7570));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 304, DateTimeKind.Utc).AddTicks(8039));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 304, DateTimeKind.Utc).AddTicks(8041));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 304, DateTimeKind.Utc).AddTicks(8044));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 304, DateTimeKind.Utc).AddTicks(8046));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 304, DateTimeKind.Utc).AddTicks(8048));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 304, DateTimeKind.Utc).AddTicks(8051));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 304, DateTimeKind.Utc).AddTicks(8053));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 304, DateTimeKind.Utc).AddTicks(8055));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 304, DateTimeKind.Utc).AddTicks(8058));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "UpdatedAt" },
                values: new object[] { "Minimum order amount for free shipping in PLN", new DateTime(2025, 11, 13, 18, 51, 11, 304, DateTimeKind.Utc).AddTicks(8060) });

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 297, DateTimeKind.Utc).AddTicks(6520));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 297, DateTimeKind.Utc).AddTicks(6855));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 297, DateTimeKind.Utc).AddTicks(6858));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 297, DateTimeKind.Utc).AddTicks(6860));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 297, DateTimeKind.Utc).AddTicks(6862));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 297, DateTimeKind.Utc).AddTicks(6865));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 302, DateTimeKind.Utc).AddTicks(2103));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 302, DateTimeKind.Utc).AddTicks(2553));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 302, DateTimeKind.Utc).AddTicks(2556));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 51, 11, 302, DateTimeKind.Utc).AddTicks(2559));
        }
    }
}
