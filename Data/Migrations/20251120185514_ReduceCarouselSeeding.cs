using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kokomija.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReduceCarouselSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 20, 18, 55, 12, 793, DateTimeKind.Utc).AddTicks(3566), new DateTime(2025, 11, 20, 18, 55, 12, 793, DateTimeKind.Utc).AddTicks(3889) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 20, 18, 55, 12, 793, DateTimeKind.Utc).AddTicks(4208), new DateTime(2025, 11, 20, 18, 55, 12, 793, DateTimeKind.Utc).AddTicks(4209) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 20, 18, 55, 12, 793, DateTimeKind.Utc).AddTicks(4212), new DateTime(2025, 11, 20, 18, 55, 12, 793, DateTimeKind.Utc).AddTicks(4212) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 20, 18, 55, 12, 793, DateTimeKind.Utc).AddTicks(4215), new DateTime(2025, 11, 20, 18, 55, 12, 793, DateTimeKind.Utc).AddTicks(4216) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 20, 18, 55, 12, 793, DateTimeKind.Utc).AddTicks(4218), new DateTime(2025, 11, 20, 18, 55, 12, 793, DateTimeKind.Utc).AddTicks(4219) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 20, 18, 55, 12, 800, DateTimeKind.Utc).AddTicks(734), new DateTime(2025, 11, 20, 18, 55, 12, 800, DateTimeKind.Utc).AddTicks(347) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 791, DateTimeKind.Utc).AddTicks(4883));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 791, DateTimeKind.Utc).AddTicks(5264));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 791, DateTimeKind.Utc).AddTicks(5382));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 791, DateTimeKind.Utc).AddTicks(5385));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 791, DateTimeKind.Utc).AddTicks(5756));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 791, DateTimeKind.Utc).AddTicks(5762));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 791, DateTimeKind.Utc).AddTicks(5765));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 791, DateTimeKind.Utc).AddTicks(5768));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 791, DateTimeKind.Utc).AddTicks(5771));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 791, DateTimeKind.Utc).AddTicks(5774));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 791, DateTimeKind.Utc).AddTicks(5776));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 791, DateTimeKind.Utc).AddTicks(5779));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 789, DateTimeKind.Utc).AddTicks(7324));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 789, DateTimeKind.Utc).AddTicks(7665));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 789, DateTimeKind.Utc).AddTicks(7667));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 789, DateTimeKind.Utc).AddTicks(7670));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 789, DateTimeKind.Utc).AddTicks(7672));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 789, DateTimeKind.Utc).AddTicks(7675));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 789, DateTimeKind.Utc).AddTicks(7677));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 789, DateTimeKind.Utc).AddTicks(7680));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2025, 11, 20, 18, 55, 12, 795, DateTimeKind.Utc).AddTicks(4628), new DateTime(2025, 11, 20, 18, 55, 12, 795, DateTimeKind.Utc).AddTicks(2406), new DateTime(2026, 5, 20, 18, 55, 12, 795, DateTimeKind.Utc).AddTicks(2894) });

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 796, DateTimeKind.Utc).AddTicks(1136));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 798, DateTimeKind.Utc).AddTicks(2469));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 798, DateTimeKind.Utc).AddTicks(2910));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 798, DateTimeKind.Utc).AddTicks(2915));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 798, DateTimeKind.Utc).AddTicks(2919));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 798, DateTimeKind.Utc).AddTicks(2922));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 798, DateTimeKind.Utc).AddTicks(2934));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 798, DateTimeKind.Utc).AddTicks(2937));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 798, DateTimeKind.Utc).AddTicks(2940));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 798, DateTimeKind.Utc).AddTicks(2945));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 798, DateTimeKind.Utc).AddTicks(2950));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 798, DateTimeKind.Utc).AddTicks(2953));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 798, DateTimeKind.Utc).AddTicks(2957));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 798, DateTimeKind.Utc).AddTicks(2960));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 798, DateTimeKind.Utc).AddTicks(2963));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 798, DateTimeKind.Utc).AddTicks(2966));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 798, DateTimeKind.Utc).AddTicks(2969));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 798, DateTimeKind.Utc).AddTicks(2974));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 798, DateTimeKind.Utc).AddTicks(2979));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 798, DateTimeKind.Utc).AddTicks(2982));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 798, DateTimeKind.Utc).AddTicks(2985));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 798, DateTimeKind.Utc).AddTicks(2988));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 798, DateTimeKind.Utc).AddTicks(2991));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 798, DateTimeKind.Utc).AddTicks(2994));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 798, DateTimeKind.Utc).AddTicks(2997));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 799, DateTimeKind.Utc).AddTicks(3503));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 799, DateTimeKind.Utc).AddTicks(3846));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 799, DateTimeKind.Utc).AddTicks(3907));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 799, DateTimeKind.Utc).AddTicks(3911));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 799, DateTimeKind.Utc).AddTicks(3914));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 799, DateTimeKind.Utc).AddTicks(3922));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 799, DateTimeKind.Utc).AddTicks(3924));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 799, DateTimeKind.Utc).AddTicks(3927));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 799, DateTimeKind.Utc).AddTicks(3929));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 799, DateTimeKind.Utc).AddTicks(3933));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 799, DateTimeKind.Utc).AddTicks(3938));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 799, DateTimeKind.Utc).AddTicks(3941));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 799, DateTimeKind.Utc).AddTicks(3944));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 799, DateTimeKind.Utc).AddTicks(3946));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 799, DateTimeKind.Utc).AddTicks(3949));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 797, DateTimeKind.Utc).AddTicks(4571));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 797, DateTimeKind.Utc).AddTicks(4913));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 797, DateTimeKind.Utc).AddTicks(4917));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 794, DateTimeKind.Utc).AddTicks(2889));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 794, DateTimeKind.Utc).AddTicks(3219));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 794, DateTimeKind.Utc).AddTicks(3221));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 794, DateTimeKind.Utc).AddTicks(3223));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 794, DateTimeKind.Utc).AddTicks(3225));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 794, DateTimeKind.Utc).AddTicks(3227));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 794, DateTimeKind.Utc).AddTicks(3229));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 794, DateTimeKind.Utc).AddTicks(3232));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 794, DateTimeKind.Utc).AddTicks(3234));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 794, DateTimeKind.Utc).AddTicks(3236));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 794, DateTimeKind.Utc).AddTicks(3238));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 787, DateTimeKind.Utc).AddTicks(8579));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 787, DateTimeKind.Utc).AddTicks(9071));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 787, DateTimeKind.Utc).AddTicks(9074));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 787, DateTimeKind.Utc).AddTicks(9077));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 787, DateTimeKind.Utc).AddTicks(9080));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 787, DateTimeKind.Utc).AddTicks(9083));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 792, DateTimeKind.Utc).AddTicks(4463));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 18, 55, 12, 792, DateTimeKind.Utc).AddTicks(4803));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 20, 16, 59, 13, 968, DateTimeKind.Utc).AddTicks(8544), new DateTime(2025, 11, 20, 16, 59, 13, 968, DateTimeKind.Utc).AddTicks(9016) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 20, 16, 59, 13, 968, DateTimeKind.Utc).AddTicks(9475), new DateTime(2025, 11, 20, 16, 59, 13, 968, DateTimeKind.Utc).AddTicks(9476) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 20, 16, 59, 13, 968, DateTimeKind.Utc).AddTicks(9480), new DateTime(2025, 11, 20, 16, 59, 13, 968, DateTimeKind.Utc).AddTicks(9480) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 20, 16, 59, 13, 968, DateTimeKind.Utc).AddTicks(9484), new DateTime(2025, 11, 20, 16, 59, 13, 968, DateTimeKind.Utc).AddTicks(9484) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 20, 16, 59, 13, 968, DateTimeKind.Utc).AddTicks(9488), new DateTime(2025, 11, 20, 16, 59, 13, 968, DateTimeKind.Utc).AddTicks(9489) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 20, 16, 59, 13, 978, DateTimeKind.Utc).AddTicks(9877), new DateTime(2025, 11, 20, 16, 59, 13, 978, DateTimeKind.Utc).AddTicks(9431) });

            migrationBuilder.InsertData(
                table: "CarouselSlides",
                columns: new[] { "Id", "AnimationType", "BackgroundColor", "ButtonClass", "ButtonText", "CategoryId", "CreatedAt", "CreatedBy", "CustomCssClass", "DeletedAt", "DeletedBy", "DisplayOrder", "Duration", "EndDate", "ImageAlt", "ImagePath", "IsActive", "LinkUrl", "Location", "MobileImagePath", "StartDate", "Subtitle", "TextAlign", "TextColor", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 2, "fade", null, "btn-primary", "Zobacz Ofertę", null, new DateTime(2025, 11, 20, 16, 59, 13, 979, DateTimeKind.Utc).AddTicks(261), null, null, null, null, 2, 5000, null, "Wielka wyprzedaż do -50%", "2.jpg", true, "/meskie", "home", null, new DateTime(2025, 11, 20, 16, 59, 13, 979, DateTimeKind.Utc).AddTicks(260), "Nie przegap okazji! Setki produktów w obniżonych cenach", "center", null, "Wyprzedaż do -50%", null, null },
                    { 3, "fade", null, "btn-primary", "Przeglądaj", null, new DateTime(2025, 11, 20, 16, 59, 13, 979, DateTimeKind.Utc).AddTicks(265), null, null, null, null, 3, 5000, null, "Elegancka odzież na specjalne okazje", "3.jpg", true, "/odziez-wierzchnia", "home", null, new DateTime(2025, 11, 20, 16, 59, 13, 979, DateTimeKind.Utc).AddTicks(264), "Koszule, sukienki i dodatki dla wymagających", "center", null, "Elegancja na Każdą Okazję", null, null },
                    { 4, "fade", null, "btn-primary", "Sprawdź", null, new DateTime(2025, 11, 20, 16, 59, 13, 979, DateTimeKind.Utc).AddTicks(268), null, null, null, null, 4, 5000, null, "Darmowa dostawa powyżej 200 PLN", "4.jpg", true, "/akcesoria", "home", null, new DateTime(2025, 11, 20, 16, 59, 13, 979, DateTimeKind.Utc).AddTicks(267), "Przy zamówieniach powyżej 200 PLN", "center", null, "Darmowa Dostawa", null, null },
                    { 5, "fade", null, "btn-primary", "Odkryj Więcej", null, new DateTime(2025, 11, 20, 16, 59, 13, 979, DateTimeKind.Utc).AddTicks(271), null, null, null, null, 5, 5000, null, "Kolekcja zimowych kurtek", "5.jpg", true, "/odziez-wierzchnia", "home", null, new DateTime(2025, 11, 20, 16, 59, 13, 979, DateTimeKind.Utc).AddTicks(271), "Przygotuj się na zimę z naszą kolekcją kurtek", "center", null, "Stylowe Kurtki", null, null }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 966, DateTimeKind.Utc).AddTicks(2111));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 966, DateTimeKind.Utc).AddTicks(2615));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 966, DateTimeKind.Utc).AddTicks(2620));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 966, DateTimeKind.Utc).AddTicks(2626));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 966, DateTimeKind.Utc).AddTicks(3108));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 966, DateTimeKind.Utc).AddTicks(3116));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 966, DateTimeKind.Utc).AddTicks(3389));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 966, DateTimeKind.Utc).AddTicks(3394));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 966, DateTimeKind.Utc).AddTicks(3400));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 966, DateTimeKind.Utc).AddTicks(3404));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 966, DateTimeKind.Utc).AddTicks(3407));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 966, DateTimeKind.Utc).AddTicks(3410));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 964, DateTimeKind.Utc).AddTicks(5223));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 964, DateTimeKind.Utc).AddTicks(5564));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 964, DateTimeKind.Utc).AddTicks(5567));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 964, DateTimeKind.Utc).AddTicks(5569));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 964, DateTimeKind.Utc).AddTicks(5572));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 964, DateTimeKind.Utc).AddTicks(5574));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 964, DateTimeKind.Utc).AddTicks(5576));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 964, DateTimeKind.Utc).AddTicks(5579));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2025, 11, 20, 16, 59, 13, 972, DateTimeKind.Utc).AddTicks(7063), new DateTime(2025, 11, 20, 16, 59, 13, 972, DateTimeKind.Utc).AddTicks(4679), new DateTime(2026, 5, 20, 16, 59, 13, 972, DateTimeKind.Utc).AddTicks(5280) });

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 973, DateTimeKind.Utc).AddTicks(3648));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1224));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1710));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1717));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1721));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1888));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1907));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1911));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1914));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1920));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1927));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1930));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1934));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1937));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1941));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1945));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1948));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1959));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1965));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1968));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1972));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1976));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1980));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1983));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1987));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 977, DateTimeKind.Utc).AddTicks(8204));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 977, DateTimeKind.Utc).AddTicks(8649));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 977, DateTimeKind.Utc).AddTicks(8653));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 977, DateTimeKind.Utc).AddTicks(8656));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 977, DateTimeKind.Utc).AddTicks(8659));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 977, DateTimeKind.Utc).AddTicks(8674));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 977, DateTimeKind.Utc).AddTicks(8770));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 977, DateTimeKind.Utc).AddTicks(8773));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 977, DateTimeKind.Utc).AddTicks(8777));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 977, DateTimeKind.Utc).AddTicks(8781));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 977, DateTimeKind.Utc).AddTicks(8787));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 977, DateTimeKind.Utc).AddTicks(8790));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 977, DateTimeKind.Utc).AddTicks(8793));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 977, DateTimeKind.Utc).AddTicks(8796));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 977, DateTimeKind.Utc).AddTicks(8799));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 974, DateTimeKind.Utc).AddTicks(8773));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 974, DateTimeKind.Utc).AddTicks(9140));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 974, DateTimeKind.Utc).AddTicks(9144));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 970, DateTimeKind.Utc).AddTicks(5248));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 970, DateTimeKind.Utc).AddTicks(6775));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 970, DateTimeKind.Utc).AddTicks(6780));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 970, DateTimeKind.Utc).AddTicks(6782));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 970, DateTimeKind.Utc).AddTicks(6785));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 970, DateTimeKind.Utc).AddTicks(6788));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 970, DateTimeKind.Utc).AddTicks(6791));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 970, DateTimeKind.Utc).AddTicks(6793));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 970, DateTimeKind.Utc).AddTicks(6796));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 970, DateTimeKind.Utc).AddTicks(6798));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 970, DateTimeKind.Utc).AddTicks(6801));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 962, DateTimeKind.Utc).AddTicks(8178));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 962, DateTimeKind.Utc).AddTicks(8518));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 962, DateTimeKind.Utc).AddTicks(8521));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 962, DateTimeKind.Utc).AddTicks(8523));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 962, DateTimeKind.Utc).AddTicks(8525));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 962, DateTimeKind.Utc).AddTicks(8528));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 967, DateTimeKind.Utc).AddTicks(4109));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 59, 13, 967, DateTimeKind.Utc).AddTicks(4438));
        }
    }
}
