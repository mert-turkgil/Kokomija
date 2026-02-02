using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kokomija.Data.Migrations
{
    /// <inheritdoc />
    public partial class IncreaseShippingProviderApiKeyLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ApiSecret",
                table: "ShippingProviders",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApiKey",
                table: "ShippingProviders",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 323, DateTimeKind.Utc).AddTicks(3138), new DateTime(2026, 2, 1, 12, 26, 32, 323, DateTimeKind.Utc).AddTicks(3472) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 323, DateTimeKind.Utc).AddTicks(3799), new DateTime(2026, 2, 1, 12, 26, 32, 323, DateTimeKind.Utc).AddTicks(3800) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 323, DateTimeKind.Utc).AddTicks(3803), new DateTime(2026, 2, 1, 12, 26, 32, 323, DateTimeKind.Utc).AddTicks(3803) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 323, DateTimeKind.Utc).AddTicks(3806), new DateTime(2026, 2, 1, 12, 26, 32, 323, DateTimeKind.Utc).AddTicks(3807) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 323, DateTimeKind.Utc).AddTicks(3809), new DateTime(2026, 2, 1, 12, 26, 32, 323, DateTimeKind.Utc).AddTicks(3810) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 324, DateTimeKind.Utc).AddTicks(8056), new DateTime(2026, 2, 1, 12, 26, 32, 324, DateTimeKind.Utc).AddTicks(8378) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 324, DateTimeKind.Utc).AddTicks(8696), new DateTime(2026, 2, 1, 12, 26, 32, 324, DateTimeKind.Utc).AddTicks(8697) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 324, DateTimeKind.Utc).AddTicks(527), new DateTime(2026, 2, 1, 12, 26, 32, 323, DateTimeKind.Utc).AddTicks(8628), new DateTime(2026, 2, 1, 12, 26, 32, 324, DateTimeKind.Utc).AddTicks(889) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 363, DateTimeKind.Utc).AddTicks(966));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 363, DateTimeKind.Utc).AddTicks(1473));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 362, DateTimeKind.Utc).AddTicks(2203), new DateTime(2026, 2, 1, 12, 26, 32, 362, DateTimeKind.Utc).AddTicks(1824) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 320, DateTimeKind.Utc).AddTicks(9484));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 320, DateTimeKind.Utc).AddTicks(9865));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 320, DateTimeKind.Utc).AddTicks(9869));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 320, DateTimeKind.Utc).AddTicks(9872));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 321, DateTimeKind.Utc).AddTicks(221));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 321, DateTimeKind.Utc).AddTicks(226));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 321, DateTimeKind.Utc).AddTicks(230));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 321, DateTimeKind.Utc).AddTicks(233));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 321, DateTimeKind.Utc).AddTicks(237));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 321, DateTimeKind.Utc).AddTicks(240));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 321, DateTimeKind.Utc).AddTicks(243));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 321, DateTimeKind.Utc).AddTicks(246));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 319, DateTimeKind.Utc).AddTicks(3671));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 319, DateTimeKind.Utc).AddTicks(4113));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 319, DateTimeKind.Utc).AddTicks(4116));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 319, DateTimeKind.Utc).AddTicks(4118));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 319, DateTimeKind.Utc).AddTicks(4121));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 319, DateTimeKind.Utc).AddTicks(4123));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 319, DateTimeKind.Utc).AddTicks(4126));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 319, DateTimeKind.Utc).AddTicks(4128));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 330, DateTimeKind.Utc).AddTicks(5643), new DateTime(2026, 2, 1, 12, 26, 32, 330, DateTimeKind.Utc).AddTicks(3813), new DateTime(2026, 8, 1, 12, 26, 32, 330, DateTimeKind.Utc).AddTicks(4169) });

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 318, DateTimeKind.Utc).AddTicks(1148));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 318, DateTimeKind.Utc).AddTicks(1621));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 318, DateTimeKind.Utc).AddTicks(1625));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 318, DateTimeKind.Utc).AddTicks(1627));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 318, DateTimeKind.Utc).AddTicks(1630));

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 331, DateTimeKind.Utc).AddTicks(1000));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 334, DateTimeKind.Utc).AddTicks(8551));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 334, DateTimeKind.Utc).AddTicks(9902));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 334, DateTimeKind.Utc).AddTicks(9908));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 334, DateTimeKind.Utc).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 334, DateTimeKind.Utc).AddTicks(9913));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 334, DateTimeKind.Utc).AddTicks(9929));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 334, DateTimeKind.Utc).AddTicks(9931));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 334, DateTimeKind.Utc).AddTicks(9934));

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 336, DateTimeKind.Utc).AddTicks(1298), new DateTime(2026, 2, 1, 12, 26, 32, 336, DateTimeKind.Utc).AddTicks(1302) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 357, DateTimeKind.Utc).AddTicks(1386), new DateTime(2026, 2, 1, 12, 26, 32, 357, DateTimeKind.Utc).AddTicks(1391) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 357, DateTimeKind.Utc).AddTicks(2245), new DateTime(2026, 2, 1, 12, 26, 32, 357, DateTimeKind.Utc).AddTicks(2246) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 357, DateTimeKind.Utc).AddTicks(4197), new DateTime(2026, 2, 1, 12, 26, 32, 357, DateTimeKind.Utc).AddTicks(4198) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 357, DateTimeKind.Utc).AddTicks(4217), new DateTime(2026, 2, 1, 12, 26, 32, 357, DateTimeKind.Utc).AddTicks(4218) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 357, DateTimeKind.Utc).AddTicks(4236), new DateTime(2026, 2, 1, 12, 26, 32, 357, DateTimeKind.Utc).AddTicks(4237) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 357, DateTimeKind.Utc).AddTicks(4242), new DateTime(2026, 2, 1, 12, 26, 32, 357, DateTimeKind.Utc).AddTicks(4243) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 357, DateTimeKind.Utc).AddTicks(4248), new DateTime(2026, 2, 1, 12, 26, 32, 357, DateTimeKind.Utc).AddTicks(4248) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1441));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1873));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1877));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1881));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1885));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1897));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1900));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1904));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1907));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1941));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1945));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1948));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1952));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1955));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1958));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1962));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1965));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1970));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1974));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1977));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1981));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1984));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1987));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1991));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1994));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1998));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2002));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2005));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2012));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2016));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2019));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2023));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2028));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2032));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2035));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2039));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2042));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2046));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2049));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2053));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2056));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2059));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2063));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2077));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2082));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2085));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2089));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2095));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2099));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2103));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2106));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2110));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2113));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2117));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2120));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2124));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2127));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2131));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2134));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2138));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2141));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2144));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2148));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2154));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2157));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2160));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2164));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2167));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2171));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2178));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2181));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2184));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2188));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2191));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2195));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2202));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2220));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2224));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2227));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2231));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2234));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2241));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2244));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2248));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2251));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2255));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2258));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2261));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2265));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2268));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2272));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2276));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2279));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2282));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2286));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 333, DateTimeKind.Utc).AddTicks(4460));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 333, DateTimeKind.Utc).AddTicks(4985));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 333, DateTimeKind.Utc).AddTicks(5001));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 333, DateTimeKind.Utc).AddTicks(5013));

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 326, DateTimeKind.Utc).AddTicks(8261), new DateTime(2026, 2, 1, 12, 26, 32, 326, DateTimeKind.Utc).AddTicks(8603) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 326, DateTimeKind.Utc).AddTicks(8931), new DateTime(2026, 2, 1, 12, 26, 32, 326, DateTimeKind.Utc).AddTicks(8932) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 326, DateTimeKind.Utc).AddTicks(8934), new DateTime(2026, 2, 1, 12, 26, 32, 326, DateTimeKind.Utc).AddTicks(8935) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 326, DateTimeKind.Utc).AddTicks(8938), new DateTime(2026, 2, 1, 12, 26, 32, 326, DateTimeKind.Utc).AddTicks(8938) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 326, DateTimeKind.Utc).AddTicks(8942), new DateTime(2026, 2, 1, 12, 26, 32, 326, DateTimeKind.Utc).AddTicks(8942) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 328, DateTimeKind.Utc).AddTicks(361), new DateTime(2026, 2, 1, 12, 26, 32, 328, DateTimeKind.Utc).AddTicks(675) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 328, DateTimeKind.Utc).AddTicks(991), new DateTime(2026, 2, 1, 12, 26, 32, 328, DateTimeKind.Utc).AddTicks(992) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 328, DateTimeKind.Utc).AddTicks(995), new DateTime(2026, 2, 1, 12, 26, 32, 328, DateTimeKind.Utc).AddTicks(995) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 328, DateTimeKind.Utc).AddTicks(998), new DateTime(2026, 2, 1, 12, 26, 32, 328, DateTimeKind.Utc).AddTicks(998) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 328, DateTimeKind.Utc).AddTicks(1002), new DateTime(2026, 2, 1, 12, 26, 32, 328, DateTimeKind.Utc).AddTicks(1002) });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 325, DateTimeKind.Utc).AddTicks(8059));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 325, DateTimeKind.Utc).AddTicks(8398));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 325, DateTimeKind.Utc).AddTicks(8400));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 325, DateTimeKind.Utc).AddTicks(8402));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 325, DateTimeKind.Utc).AddTicks(8405));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 325, DateTimeKind.Utc).AddTicks(8407));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 325, DateTimeKind.Utc).AddTicks(8409));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 325, DateTimeKind.Utc).AddTicks(8411));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 325, DateTimeKind.Utc).AddTicks(8413));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 325, DateTimeKind.Utc).AddTicks(8415));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 325, DateTimeKind.Utc).AddTicks(8418));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 315, DateTimeKind.Utc).AddTicks(5984));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 315, DateTimeKind.Utc).AddTicks(6864));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 315, DateTimeKind.Utc).AddTicks(6866));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 315, DateTimeKind.Utc).AddTicks(6869));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 315, DateTimeKind.Utc).AddTicks(6871));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 315, DateTimeKind.Utc).AddTicks(6873));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 322, DateTimeKind.Utc).AddTicks(3182));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 322, DateTimeKind.Utc).AddTicks(3695));

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 329, DateTimeKind.Utc).AddTicks(901), new DateTime(2026, 2, 1, 12, 26, 32, 329, DateTimeKind.Utc).AddTicks(1388) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 329, DateTimeKind.Utc).AddTicks(1878), new DateTime(2026, 2, 1, 12, 26, 32, 329, DateTimeKind.Utc).AddTicks(1879) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 329, DateTimeKind.Utc).AddTicks(1882), new DateTime(2026, 2, 1, 12, 26, 32, 329, DateTimeKind.Utc).AddTicks(1883) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ApiSecret",
                table: "ShippingProviders",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApiKey",
                table: "ShippingProviders",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 388, DateTimeKind.Utc).AddTicks(6132), new DateTime(2026, 1, 22, 19, 18, 21, 388, DateTimeKind.Utc).AddTicks(6537) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 388, DateTimeKind.Utc).AddTicks(6914), new DateTime(2026, 1, 22, 19, 18, 21, 388, DateTimeKind.Utc).AddTicks(6914) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 388, DateTimeKind.Utc).AddTicks(6917), new DateTime(2026, 1, 22, 19, 18, 21, 388, DateTimeKind.Utc).AddTicks(6918) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 388, DateTimeKind.Utc).AddTicks(6921), new DateTime(2026, 1, 22, 19, 18, 21, 388, DateTimeKind.Utc).AddTicks(6921) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 388, DateTimeKind.Utc).AddTicks(6925), new DateTime(2026, 1, 22, 19, 18, 21, 388, DateTimeKind.Utc).AddTicks(6925) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 391, DateTimeKind.Utc).AddTicks(2246), new DateTime(2026, 1, 22, 19, 18, 21, 391, DateTimeKind.Utc).AddTicks(2597) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 391, DateTimeKind.Utc).AddTicks(2920), new DateTime(2026, 1, 22, 19, 18, 21, 391, DateTimeKind.Utc).AddTicks(2921) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 389, DateTimeKind.Utc).AddTicks(5737), new DateTime(2026, 1, 22, 19, 18, 21, 389, DateTimeKind.Utc).AddTicks(3951), new DateTime(2026, 1, 22, 19, 18, 21, 389, DateTimeKind.Utc).AddTicks(6120) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 433, DateTimeKind.Utc).AddTicks(9180));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 433, DateTimeKind.Utc).AddTicks(9720));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 432, DateTimeKind.Utc).AddTicks(8443), new DateTime(2026, 1, 22, 19, 18, 21, 432, DateTimeKind.Utc).AddTicks(8066) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 385, DateTimeKind.Utc).AddTicks(8780));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 385, DateTimeKind.Utc).AddTicks(9390));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 385, DateTimeKind.Utc).AddTicks(9397));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 385, DateTimeKind.Utc).AddTicks(9401));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 385, DateTimeKind.Utc).AddTicks(9923));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 385, DateTimeKind.Utc).AddTicks(9932));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 385, DateTimeKind.Utc).AddTicks(9936));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 385, DateTimeKind.Utc).AddTicks(9941));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 385, DateTimeKind.Utc).AddTicks(9946));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 385, DateTimeKind.Utc).AddTicks(9949));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 385, DateTimeKind.Utc).AddTicks(9953));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 385, DateTimeKind.Utc).AddTicks(9957));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 383, DateTimeKind.Utc).AddTicks(3630));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 383, DateTimeKind.Utc).AddTicks(4163));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 383, DateTimeKind.Utc).AddTicks(4168));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 383, DateTimeKind.Utc).AddTicks(4171));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 383, DateTimeKind.Utc).AddTicks(4173));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 383, DateTimeKind.Utc).AddTicks(4177));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 383, DateTimeKind.Utc).AddTicks(4180));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 383, DateTimeKind.Utc).AddTicks(4183));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 398, DateTimeKind.Utc).AddTicks(8236), new DateTime(2026, 1, 22, 19, 18, 21, 398, DateTimeKind.Utc).AddTicks(4895), new DateTime(2026, 7, 22, 19, 18, 21, 398, DateTimeKind.Utc).AddTicks(5732) });

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 381, DateTimeKind.Utc).AddTicks(9082));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 381, DateTimeKind.Utc).AddTicks(9503));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 381, DateTimeKind.Utc).AddTicks(9507));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 381, DateTimeKind.Utc).AddTicks(9512));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 381, DateTimeKind.Utc).AddTicks(9515));

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 399, DateTimeKind.Utc).AddTicks(5761));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 402, DateTimeKind.Utc).AddTicks(1737));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 402, DateTimeKind.Utc).AddTicks(2080));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 402, DateTimeKind.Utc).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 402, DateTimeKind.Utc).AddTicks(2086));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 402, DateTimeKind.Utc).AddTicks(2089));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 402, DateTimeKind.Utc).AddTicks(2101));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 402, DateTimeKind.Utc).AddTicks(2103));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 402, DateTimeKind.Utc).AddTicks(2106));

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 403, DateTimeKind.Utc).AddTicks(3933), new DateTime(2026, 1, 22, 19, 18, 21, 403, DateTimeKind.Utc).AddTicks(3937) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 426, DateTimeKind.Utc).AddTicks(6781), new DateTime(2026, 1, 22, 19, 18, 21, 426, DateTimeKind.Utc).AddTicks(6785) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 426, DateTimeKind.Utc).AddTicks(7716), new DateTime(2026, 1, 22, 19, 18, 21, 426, DateTimeKind.Utc).AddTicks(7717) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 426, DateTimeKind.Utc).AddTicks(9910), new DateTime(2026, 1, 22, 19, 18, 21, 426, DateTimeKind.Utc).AddTicks(9911) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 426, DateTimeKind.Utc).AddTicks(9970), new DateTime(2026, 1, 22, 19, 18, 21, 426, DateTimeKind.Utc).AddTicks(9970) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 426, DateTimeKind.Utc).AddTicks(9992), new DateTime(2026, 1, 22, 19, 18, 21, 426, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 426, DateTimeKind.Utc).AddTicks(9999), new DateTime(2026, 1, 22, 19, 18, 21, 426, DateTimeKind.Utc).AddTicks(9999) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 427, DateTimeKind.Utc).AddTicks(4), new DateTime(2026, 1, 22, 19, 18, 21, 427, DateTimeKind.Utc).AddTicks(5) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(7985));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8482));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8486));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8490));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8494));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8506));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8509));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8513));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8517));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8522));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8525));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8529));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8532));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8569));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8572));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8576));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8579));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8584));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8587));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8591));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8594));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8598));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8601));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8604));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8608));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8612));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8616));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8619));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8622));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8626));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8630));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8633));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8636));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8641));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8645));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8648));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8652));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8655));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8659));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8662));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8666));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8669));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8673));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8676));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8680));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8683));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8687));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8690));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8694));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8711));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8716));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8719));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8723));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8726));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8730));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8733));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8737));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8740));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8744));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8747));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8751));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8754));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8758));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8761));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8765));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8770));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8774));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8777));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8781));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8784));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8788));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8791));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8794));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8798));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8801));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8805));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8809));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8812));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8816));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8819));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8822));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8826));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8829));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8833));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8836));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8852));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8855));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8859));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8862));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8866));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8869));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8873));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8876));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8880));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8883));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8887));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8890));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8894));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8897));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8900));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 401, DateTimeKind.Utc).AddTicks(4985));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 401, DateTimeKind.Utc).AddTicks(5310));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 401, DateTimeKind.Utc).AddTicks(5314));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 401, DateTimeKind.Utc).AddTicks(5319));

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 393, DateTimeKind.Utc).AddTicks(2215), new DateTime(2026, 1, 22, 19, 18, 21, 393, DateTimeKind.Utc).AddTicks(2605) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 393, DateTimeKind.Utc).AddTicks(2933), new DateTime(2026, 1, 22, 19, 18, 21, 393, DateTimeKind.Utc).AddTicks(2934) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 393, DateTimeKind.Utc).AddTicks(2937), new DateTime(2026, 1, 22, 19, 18, 21, 393, DateTimeKind.Utc).AddTicks(2938) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 393, DateTimeKind.Utc).AddTicks(2941), new DateTime(2026, 1, 22, 19, 18, 21, 393, DateTimeKind.Utc).AddTicks(2942) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 393, DateTimeKind.Utc).AddTicks(2945), new DateTime(2026, 1, 22, 19, 18, 21, 393, DateTimeKind.Utc).AddTicks(2946) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 395, DateTimeKind.Utc).AddTicks(5288), new DateTime(2026, 1, 22, 19, 18, 21, 395, DateTimeKind.Utc).AddTicks(6540) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 395, DateTimeKind.Utc).AddTicks(9258), new DateTime(2026, 1, 22, 19, 18, 21, 395, DateTimeKind.Utc).AddTicks(9259) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 395, DateTimeKind.Utc).AddTicks(9263), new DateTime(2026, 1, 22, 19, 18, 21, 395, DateTimeKind.Utc).AddTicks(9264) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 395, DateTimeKind.Utc).AddTicks(9268), new DateTime(2026, 1, 22, 19, 18, 21, 395, DateTimeKind.Utc).AddTicks(9269) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 395, DateTimeKind.Utc).AddTicks(9275), new DateTime(2026, 1, 22, 19, 18, 21, 395, DateTimeKind.Utc).AddTicks(9277) });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 392, DateTimeKind.Utc).AddTicks(3100));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 392, DateTimeKind.Utc).AddTicks(3436));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 392, DateTimeKind.Utc).AddTicks(3438));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 392, DateTimeKind.Utc).AddTicks(3440));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 392, DateTimeKind.Utc).AddTicks(3443));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 392, DateTimeKind.Utc).AddTicks(3445));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 392, DateTimeKind.Utc).AddTicks(3447));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 392, DateTimeKind.Utc).AddTicks(3449));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 392, DateTimeKind.Utc).AddTicks(3451));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 392, DateTimeKind.Utc).AddTicks(3453));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 392, DateTimeKind.Utc).AddTicks(3455));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 378, DateTimeKind.Utc).AddTicks(8107));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 378, DateTimeKind.Utc).AddTicks(8728));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 378, DateTimeKind.Utc).AddTicks(8730));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 378, DateTimeKind.Utc).AddTicks(8734));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 378, DateTimeKind.Utc).AddTicks(8737));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 378, DateTimeKind.Utc).AddTicks(8787));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 387, DateTimeKind.Utc).AddTicks(3211));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 387, DateTimeKind.Utc).AddTicks(3857));

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 397, DateTimeKind.Utc).AddTicks(174), new DateTime(2026, 1, 22, 19, 18, 21, 397, DateTimeKind.Utc).AddTicks(600) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 397, DateTimeKind.Utc).AddTicks(1007), new DateTime(2026, 1, 22, 19, 18, 21, 397, DateTimeKind.Utc).AddTicks(1008) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 397, DateTimeKind.Utc).AddTicks(1013), new DateTime(2026, 1, 22, 19, 18, 21, 397, DateTimeKind.Utc).AddTicks(1014) });
        }
    }
}
