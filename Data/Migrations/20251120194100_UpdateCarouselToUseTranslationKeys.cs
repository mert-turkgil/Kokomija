using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kokomija.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCarouselToUseTranslationKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ButtonText", "CreatedAt", "StartDate", "Subtitle", "Title" },
                values: new object[] { "Carousel_ShopNow", new DateTime(2025, 11, 20, 19, 40, 59, 236, DateTimeKind.Utc).AddTicks(8677), new DateTime(2025, 11, 20, 19, 40, 59, 236, DateTimeKind.Utc).AddTicks(8093), "Carousel_NewCollection_Subtitle", "Carousel_NewCollection" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 20, 19, 25, 11, 348, DateTimeKind.Utc).AddTicks(5499), new DateTime(2025, 11, 20, 19, 25, 11, 348, DateTimeKind.Utc).AddTicks(5886) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 20, 19, 25, 11, 348, DateTimeKind.Utc).AddTicks(6303), new DateTime(2025, 11, 20, 19, 25, 11, 348, DateTimeKind.Utc).AddTicks(6303) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 20, 19, 25, 11, 348, DateTimeKind.Utc).AddTicks(6308), new DateTime(2025, 11, 20, 19, 25, 11, 348, DateTimeKind.Utc).AddTicks(6309) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 20, 19, 25, 11, 348, DateTimeKind.Utc).AddTicks(6312), new DateTime(2025, 11, 20, 19, 25, 11, 348, DateTimeKind.Utc).AddTicks(6313) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 20, 19, 25, 11, 348, DateTimeKind.Utc).AddTicks(6317), new DateTime(2025, 11, 20, 19, 25, 11, 348, DateTimeKind.Utc).AddTicks(6318) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ButtonText", "CreatedAt", "StartDate", "Subtitle", "Title" },
                values: new object[] { "Kup Teraz", new DateTime(2025, 11, 20, 19, 25, 11, 355, DateTimeKind.Utc).AddTicks(667), new DateTime(2025, 11, 20, 19, 25, 11, 355, DateTimeKind.Utc).AddTicks(305), "Odkryj najnowsze trendy w modzie damskiej i męskiej", "Nowa Kolekcja Wiosna 2025" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 346, DateTimeKind.Utc).AddTicks(8191));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 346, DateTimeKind.Utc).AddTicks(8600));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 346, DateTimeKind.Utc).AddTicks(8604));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 346, DateTimeKind.Utc).AddTicks(8608));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 346, DateTimeKind.Utc).AddTicks(9025));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 346, DateTimeKind.Utc).AddTicks(9033));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 346, DateTimeKind.Utc).AddTicks(9036));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 346, DateTimeKind.Utc).AddTicks(9040));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 346, DateTimeKind.Utc).AddTicks(9043));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 346, DateTimeKind.Utc).AddTicks(9047));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 346, DateTimeKind.Utc).AddTicks(9050));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 346, DateTimeKind.Utc).AddTicks(9054));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 345, DateTimeKind.Utc).AddTicks(2020));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 345, DateTimeKind.Utc).AddTicks(2431));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 345, DateTimeKind.Utc).AddTicks(2434));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 345, DateTimeKind.Utc).AddTicks(2437));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 345, DateTimeKind.Utc).AddTicks(2439));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 345, DateTimeKind.Utc).AddTicks(2442));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 345, DateTimeKind.Utc).AddTicks(2445));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 345, DateTimeKind.Utc).AddTicks(2448));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2025, 11, 20, 19, 25, 11, 350, DateTimeKind.Utc).AddTicks(9258), new DateTime(2025, 11, 20, 19, 25, 11, 350, DateTimeKind.Utc).AddTicks(7257), new DateTime(2026, 5, 20, 19, 25, 11, 350, DateTimeKind.Utc).AddTicks(7836) });

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 351, DateTimeKind.Utc).AddTicks(3600));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 353, DateTimeKind.Utc).AddTicks(1695));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 353, DateTimeKind.Utc).AddTicks(2042));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 353, DateTimeKind.Utc).AddTicks(2046));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 353, DateTimeKind.Utc).AddTicks(2050));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 353, DateTimeKind.Utc).AddTicks(2053));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 353, DateTimeKind.Utc).AddTicks(2063));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 353, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 353, DateTimeKind.Utc).AddTicks(2069));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 353, DateTimeKind.Utc).AddTicks(2076));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 353, DateTimeKind.Utc).AddTicks(2081));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 353, DateTimeKind.Utc).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 353, DateTimeKind.Utc).AddTicks(2087));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 353, DateTimeKind.Utc).AddTicks(2090));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 353, DateTimeKind.Utc).AddTicks(2093));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 353, DateTimeKind.Utc).AddTicks(2096));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 353, DateTimeKind.Utc).AddTicks(2099));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 353, DateTimeKind.Utc).AddTicks(2105));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 353, DateTimeKind.Utc).AddTicks(2109));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 353, DateTimeKind.Utc).AddTicks(2113));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 353, DateTimeKind.Utc).AddTicks(2116));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 353, DateTimeKind.Utc).AddTicks(2119));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 353, DateTimeKind.Utc).AddTicks(2122));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 353, DateTimeKind.Utc).AddTicks(2125));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 353, DateTimeKind.Utc).AddTicks(2128));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 354, DateTimeKind.Utc).AddTicks(2646));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 354, DateTimeKind.Utc).AddTicks(2995));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 354, DateTimeKind.Utc).AddTicks(2999));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 354, DateTimeKind.Utc).AddTicks(3001));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 354, DateTimeKind.Utc).AddTicks(3004));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 354, DateTimeKind.Utc).AddTicks(3013));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 354, DateTimeKind.Utc).AddTicks(3016));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 354, DateTimeKind.Utc).AddTicks(3018));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 354, DateTimeKind.Utc).AddTicks(3021));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 354, DateTimeKind.Utc).AddTicks(3025));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 354, DateTimeKind.Utc).AddTicks(3029));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 354, DateTimeKind.Utc).AddTicks(3032));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 354, DateTimeKind.Utc).AddTicks(3035));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 354, DateTimeKind.Utc).AddTicks(3038));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 354, DateTimeKind.Utc).AddTicks(3040));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 352, DateTimeKind.Utc).AddTicks(4255));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 352, DateTimeKind.Utc).AddTicks(4570));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 352, DateTimeKind.Utc).AddTicks(4648));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 349, DateTimeKind.Utc).AddTicks(6308));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 349, DateTimeKind.Utc).AddTicks(6734));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 349, DateTimeKind.Utc).AddTicks(6737));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 349, DateTimeKind.Utc).AddTicks(6739));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 349, DateTimeKind.Utc).AddTicks(6741));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 349, DateTimeKind.Utc).AddTicks(6744));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 349, DateTimeKind.Utc).AddTicks(6746));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 349, DateTimeKind.Utc).AddTicks(6748));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 349, DateTimeKind.Utc).AddTicks(6750));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 349, DateTimeKind.Utc).AddTicks(6753));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 349, DateTimeKind.Utc).AddTicks(6755));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 343, DateTimeKind.Utc).AddTicks(2945));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 343, DateTimeKind.Utc).AddTicks(3360));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 343, DateTimeKind.Utc).AddTicks(3363));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 343, DateTimeKind.Utc).AddTicks(3366));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 343, DateTimeKind.Utc).AddTicks(3368));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 343, DateTimeKind.Utc).AddTicks(3371));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 347, DateTimeKind.Utc).AddTicks(6186));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 19, 25, 11, 347, DateTimeKind.Utc).AddTicks(6587));
        }
    }
}
