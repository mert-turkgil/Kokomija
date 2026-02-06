using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kokomija.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddBusinessStripePriceIdToProductVariant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AddColumn<string>(
                name: "BusinessStripePriceId",
                table: "ProductVariants",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 291, DateTimeKind.Utc).AddTicks(4174), new DateTime(2026, 2, 5, 18, 55, 22, 291, DateTimeKind.Utc).AddTicks(4527) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 291, DateTimeKind.Utc).AddTicks(4862), new DateTime(2026, 2, 5, 18, 55, 22, 291, DateTimeKind.Utc).AddTicks(4863) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 291, DateTimeKind.Utc).AddTicks(4866), new DateTime(2026, 2, 5, 18, 55, 22, 291, DateTimeKind.Utc).AddTicks(4867) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 291, DateTimeKind.Utc).AddTicks(4869), new DateTime(2026, 2, 5, 18, 55, 22, 291, DateTimeKind.Utc).AddTicks(4870) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 291, DateTimeKind.Utc).AddTicks(4873), new DateTime(2026, 2, 5, 18, 55, 22, 291, DateTimeKind.Utc).AddTicks(4874) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 293, DateTimeKind.Utc).AddTicks(1982), new DateTime(2026, 2, 5, 18, 55, 22, 293, DateTimeKind.Utc).AddTicks(2707) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 293, DateTimeKind.Utc).AddTicks(3430), new DateTime(2026, 2, 5, 18, 55, 22, 293, DateTimeKind.Utc).AddTicks(3430) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 292, DateTimeKind.Utc).AddTicks(2651), new DateTime(2026, 2, 5, 18, 55, 22, 292, DateTimeKind.Utc).AddTicks(340), new DateTime(2026, 2, 5, 18, 55, 22, 292, DateTimeKind.Utc).AddTicks(3052) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 334, DateTimeKind.Utc).AddTicks(5466));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 334, DateTimeKind.Utc).AddTicks(6020));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 333, DateTimeKind.Utc).AddTicks(5888), new DateTime(2026, 2, 5, 18, 55, 22, 333, DateTimeKind.Utc).AddTicks(5514) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 288, DateTimeKind.Utc).AddTicks(9383));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 288, DateTimeKind.Utc).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 288, DateTimeKind.Utc).AddTicks(9882));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 288, DateTimeKind.Utc).AddTicks(9885));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 289, DateTimeKind.Utc).AddTicks(279));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 289, DateTimeKind.Utc).AddTicks(286));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 289, DateTimeKind.Utc).AddTicks(289));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 289, DateTimeKind.Utc).AddTicks(292));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 289, DateTimeKind.Utc).AddTicks(296));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 289, DateTimeKind.Utc).AddTicks(340));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 289, DateTimeKind.Utc).AddTicks(343));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 289, DateTimeKind.Utc).AddTicks(347));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 287, DateTimeKind.Utc).AddTicks(4393));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 287, DateTimeKind.Utc).AddTicks(4736));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 287, DateTimeKind.Utc).AddTicks(4739));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 287, DateTimeKind.Utc).AddTicks(4742));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 287, DateTimeKind.Utc).AddTicks(4745));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 287, DateTimeKind.Utc).AddTicks(4747));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 287, DateTimeKind.Utc).AddTicks(4750));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 287, DateTimeKind.Utc).AddTicks(4752));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 301, DateTimeKind.Utc).AddTicks(3086), new DateTime(2026, 2, 5, 18, 55, 22, 301, DateTimeKind.Utc).AddTicks(845), new DateTime(2026, 8, 5, 18, 55, 22, 301, DateTimeKind.Utc).AddTicks(1221) });

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 286, DateTimeKind.Utc).AddTicks(1895));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name", "NameKey", "Quantity" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 286, DateTimeKind.Utc).AddTicks(2625), "3-Pack", "PackQuantity_3Pack", 3 });

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 286, DateTimeKind.Utc).AddTicks(2627));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Name", "NameKey", "Quantity" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 286, DateTimeKind.Utc).AddTicks(2630), "10-Pack", "PackQuantity_10Pack", 10 });

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 302, DateTimeKind.Utc).AddTicks(142));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 304, DateTimeKind.Utc).AddTicks(131));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 304, DateTimeKind.Utc).AddTicks(482));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 304, DateTimeKind.Utc).AddTicks(486));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 304, DateTimeKind.Utc).AddTicks(489));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 304, DateTimeKind.Utc).AddTicks(492));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 304, DateTimeKind.Utc).AddTicks(506));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 304, DateTimeKind.Utc).AddTicks(509));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 304, DateTimeKind.Utc).AddTicks(512));

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 305, DateTimeKind.Utc).AddTicks(2918), new DateTime(2026, 2, 5, 18, 55, 22, 305, DateTimeKind.Utc).AddTicks(2925) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 328, DateTimeKind.Utc).AddTicks(586), new DateTime(2026, 2, 5, 18, 55, 22, 328, DateTimeKind.Utc).AddTicks(590) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "MetaDescription", "Name", "Slug", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 328, DateTimeKind.Utc).AddTicks(1478), "Wysokiej jakości majtki damskie bawełniane (3 sztuki). Wygodne, przewiewne i trwałe. Idealny wybór na co dzień. Dostępne w różnych kolorach i rozmiarach.", "Kup majtki damskie bawełniane wysokie 3 pak. Wygodne, przewiewne i trwałe. Dostawa w Polsce. Najlepsza jakość w przystępnej cenie.", "Majtki damskie bawełniane wysokie 3 pak", "majtki-damskie-bawelniane-wysokie-3-pak", new DateTime(2026, 2, 5, 18, 55, 22, 328, DateTimeKind.Utc).AddTicks(1479) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description", "MetaDescription", "Name", "Slug", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 328, DateTimeKind.Utc).AddTicks(3245), "High quality women's cotton briefs (3 pieces). Comfortable, breathable and durable. Perfect choice for everyday wear. Available in various colors and sizes.", "Buy women's cotton briefs 3-Pack. Comfortable, breathable and durable underwear. Best quality at an affordable price.", "Women's Cotton Briefs 3-Pack", "womens-cotton-briefs-3-pack", new DateTime(2026, 2, 5, 18, 55, 22, 328, DateTimeKind.Utc).AddTicks(3246) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Description", "MetaDescription", "Name", "Slug", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 328, DateTimeKind.Utc).AddTicks(3266), "Wysokiej jakości majtki damskie bawełniane (6 sztuk). Wygodne, przewiewne i trwałe. Idealny wybór na co dzień. Dostępne w różnych kolorach i rozmiarach.", "Kup majtki damskie bawełniane wysokie 6 pak. Wygodne, przewiewne i trwałe. Dostawa w Polsce. Najlepsza jakość w przystępnej cenie.", "Majtki damskie bawełniane wysokie 6 pak", "majtki-damskie-bawelniane-wysokie-6-pak", new DateTime(2026, 2, 5, 18, 55, 22, 328, DateTimeKind.Utc).AddTicks(3267) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Description", "MetaDescription", "Name", "Slug", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 328, DateTimeKind.Utc).AddTicks(3287), "High quality women's cotton briefs (6 pieces). Comfortable, breathable and durable. Perfect choice for everyday wear. Available in various colors and sizes.", "Buy women's cotton briefs 6-Pack. Comfortable, breathable and durable underwear. Best quality at an affordable price.", "Women's Cotton Briefs 6-Pack", "womens-cotton-briefs-6-pack", new DateTime(2026, 2, 5, 18, 55, 22, 328, DateTimeKind.Utc).AddTicks(3287) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Description", "MetaDescription", "Name", "Slug", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 328, DateTimeKind.Utc).AddTicks(3294), "Wysokiej jakości majtki damskie bawełniane (10 sztuk). Wygodne, przewiewne i trwałe. Idealny wybór na co dzień. Dostępne w różnych kolorach i rozmiarach.", "Kup majtki damskie bawełniane wysokie 10 pak. Wygodne, przewiewne i trwałe. Dostawa w Polsce. Najlepsza jakość w przystępnej cenie.", "Majtki damskie bawełniane wysokie 10 pak", "majtki-damskie-bawelniane-wysokie-10-pak", new DateTime(2026, 2, 5, 18, 55, 22, 328, DateTimeKind.Utc).AddTicks(3294) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Description", "MetaDescription", "Name", "Slug", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 328, DateTimeKind.Utc).AddTicks(3300), "High quality women's cotton briefs (10 pieces). Comfortable, breathable and durable. Perfect choice for everyday wear. Available in various colors and sizes.", "Buy women's cotton briefs 10-Pack. Comfortable, breathable and durable underwear. Best quality at an affordable price.", "Women's Cotton Briefs 10-Pack", "womens-cotton-briefs-10-pack", new DateTime(2026, 2, 5, 18, 55, 22, 328, DateTimeKind.Utc).AddTicks(3301) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BusinessStripePriceId", "CreatedAt" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(5442) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BusinessStripePriceId", "CreatedAt" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(5967) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BusinessStripePriceId", "CreatedAt" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(5989) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BusinessStripePriceId", "CreatedAt" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(5994) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BusinessStripePriceId", "CreatedAt" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6009) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BusinessStripePriceId", "CreatedAt" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6031) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BusinessStripePriceId", "CreatedAt" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6035) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BusinessStripePriceId", "CreatedAt" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6040) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BusinessStripePriceId", "CreatedAt" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6044) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BusinessStripePriceId", "CreatedAt" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6057) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "BusinessStripePriceId", "CreatedAt" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6065) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "BusinessStripePriceId", "CreatedAt" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6070) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "BusinessStripePriceId", "CreatedAt" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6074) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "BusinessStripePriceId", "CreatedAt" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6078) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "BusinessStripePriceId", "CreatedAt" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6083) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "BusinessStripePriceId", "CreatedAt" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6087) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "BusinessStripePriceId", "CreatedAt" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6092) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "BusinessStripePriceId", "CreatedAt" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6098) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "BusinessStripePriceId", "CreatedAt" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6105) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "BusinessStripePriceId", "CreatedAt" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6112) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "BusinessStripePriceId", "CreatedAt" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6116) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "BusinessStripePriceId", "CreatedAt" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6121) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "BusinessStripePriceId", "CreatedAt" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6125) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "BusinessStripePriceId", "CreatedAt" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6129) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "BusinessStripePriceId", "CreatedAt" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6134) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6139), 29.85m, "BRIEFS-3PK-C1-S2" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6144), 29.85m, "BRIEFS-3PK-C1-S3" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6151), 29.85m, "BRIEFS-3PK-C1-S4" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6156), 29.85m, "BRIEFS-3PK-C1-S5" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6166), 29.85m, "BRIEFS-3PK-C1-S6" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6171), 29.85m, "BRIEFS-3PK-C2-S2" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6175), 29.85m, "BRIEFS-3PK-C2-S3" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6180), 29.85m, "BRIEFS-3PK-C2-S4" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6186), 29.85m, "BRIEFS-3PK-C2-S5" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6191), 29.85m, "BRIEFS-3PK-C2-S6" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6209), 29.85m, "BRIEFS-3PK-C3-S2" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6214), 29.85m, "BRIEFS-3PK-C3-S3" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6219), 29.85m, "BRIEFS-3PK-C3-S4" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6223), 29.85m, "BRIEFS-3PK-C3-S5" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6227), 29.85m, "BRIEFS-3PK-C3-S6" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6232), 29.85m, "BRIEFS-3PK-C4-S2" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6237), 29.85m, "BRIEFS-3PK-C4-S3" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6241), 29.85m, "BRIEFS-3PK-C4-S4" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6246), 29.85m, "BRIEFS-3PK-C4-S5" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6250), 29.85m, "BRIEFS-3PK-C4-S6" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6255), 29.85m, "BRIEFS-3PK-C7-S2" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6260), 29.85m, "BRIEFS-3PK-C7-S3" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6264), 29.85m, "BRIEFS-3PK-C7-S4" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6268), 29.85m, "BRIEFS-3PK-C7-S5" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6273), 29.85m, "BRIEFS-3PK-C7-S6" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6278), 59.70m, "BRIEFS-6PK-C1-S2" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6283), 59.70m, "BRIEFS-6PK-C1-S3" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6287), 59.70m, "BRIEFS-6PK-C1-S4" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6292), 59.70m, "BRIEFS-6PK-C1-S5" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6296), 59.70m, "BRIEFS-6PK-C1-S6" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6301), 59.70m, "BRIEFS-6PK-C2-S2" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6305), 59.70m, "BRIEFS-6PK-C2-S3" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6309), 59.70m, "BRIEFS-6PK-C2-S4" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6314), 59.70m, "BRIEFS-6PK-C2-S5" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6318), 59.70m, "BRIEFS-6PK-C2-S6" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6323), 59.70m, "BRIEFS-6PK-C3-S2" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6327), 59.70m, "BRIEFS-6PK-C3-S3" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6332), 59.70m, "BRIEFS-6PK-C3-S4" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6336), 59.70m, "BRIEFS-6PK-C3-S5" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6341), 59.70m, "BRIEFS-6PK-C3-S6" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6347), 59.70m, "BRIEFS-6PK-C4-S2" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6351), 59.70m, "BRIEFS-6PK-C4-S3" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6356), 59.70m, "BRIEFS-6PK-C4-S4" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6360), 59.70m, "BRIEFS-6PK-C4-S5" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6376), 59.70m, "BRIEFS-6PK-C4-S6" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6381), 59.70m, "BRIEFS-6PK-C7-S2" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6385), 59.70m, "BRIEFS-6PK-C7-S3" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6390), 59.70m, "BRIEFS-6PK-C7-S4" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6394), 59.70m, "BRIEFS-6PK-C7-S5" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6399), 59.70m, "BRIEFS-6PK-C7-S6" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6404), 99.50m, "BRIEFS-10PK-C1-S2" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6408), 99.50m, "BRIEFS-10PK-C1-S3" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6413), 99.50m, "BRIEFS-10PK-C1-S4" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6417), 99.50m, "BRIEFS-10PK-C1-S5" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6422), 99.50m, "BRIEFS-10PK-C1-S6" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6426), 99.50m, "BRIEFS-10PK-C2-S2" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6431), 99.50m, "BRIEFS-10PK-C2-S3" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6435), 99.50m, "BRIEFS-10PK-C2-S4" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6440), 99.50m, "BRIEFS-10PK-C2-S5" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6445), 99.50m, "BRIEFS-10PK-C2-S6" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6449), 99.50m, "BRIEFS-10PK-C3-S2" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6454), 99.50m, "BRIEFS-10PK-C3-S3" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6458), 99.50m, "BRIEFS-10PK-C3-S4" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6463), 99.50m, "BRIEFS-10PK-C3-S5" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6467), 99.50m, "BRIEFS-10PK-C3-S6" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6472), 99.50m, "BRIEFS-10PK-C4-S2" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6476), 99.50m, "BRIEFS-10PK-C4-S3" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6480), 99.50m, "BRIEFS-10PK-C4-S4" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6485), 99.50m, "BRIEFS-10PK-C4-S5" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6489), 99.50m, "BRIEFS-10PK-C4-S6" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6494), 99.50m, "BRIEFS-10PK-C7-S2" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6498), 99.50m, "BRIEFS-10PK-C7-S3" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6503), 99.50m, "BRIEFS-10PK-C7-S4" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6508), 99.50m, "BRIEFS-10PK-C7-S5" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "BusinessStripePriceId", "CreatedAt", "Price", "SKU" },
                values: new object[] { null, new DateTime(2026, 2, 5, 18, 55, 22, 332, DateTimeKind.Utc).AddTicks(6512), 99.50m, "BRIEFS-10PK-C7-S6" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 303, DateTimeKind.Utc).AddTicks(3875));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Name", "PackSize", "Price", "Slug" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 303, DateTimeKind.Utc).AddTicks(4296), "Wysokiej jakości majtki damskie bawełniane w zestawie 3 sztuk. Wygodne, przewiewne i trwałe. Idealny wybór na co dzień. Dostępne w różnych kolorach i rozmiarach.", "Majtki damskie bawełniane wysokie - 3 pak", 3, 29.85m, "majtki-damskie-bawelniane-wysokie-3-pak" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "Name", "PackSize", "Price", "Slug" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 303, DateTimeKind.Utc).AddTicks(4301), "Wysokiej jakości majtki damskie bawełniane w zestawie 6 sztuk. Wygodne, przewiewne i trwałe. Idealny wybór na co dzień. Dostępne w różnych kolorach i rozmiarach.", "Majtki damskie bawełniane wysokie - 6 pak", 6, 59.70m, "majtki-damskie-bawelniane-wysokie-6-pak" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description", "Name", "PackSize", "Price", "Slug" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 303, DateTimeKind.Utc).AddTicks(4305), "Wysokiej jakości majtki damskie bawełniane w zestawie 10 sztuk. Wygodne, przewiewne i trwałe. Najlepszy wybór wartościowy! Dostępne w różnych kolorach i rozmiarach.", "Majtki damskie bawełniane wysokie - 10 pak", 10, 99.50m, "majtki-damskie-bawelniane-wysokie-10-pak" });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 296, DateTimeKind.Utc).AddTicks(2811), new DateTime(2026, 2, 5, 18, 55, 22, 296, DateTimeKind.Utc).AddTicks(3194) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 296, DateTimeKind.Utc).AddTicks(3584), new DateTime(2026, 2, 5, 18, 55, 22, 296, DateTimeKind.Utc).AddTicks(3584) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 296, DateTimeKind.Utc).AddTicks(3587), new DateTime(2026, 2, 5, 18, 55, 22, 296, DateTimeKind.Utc).AddTicks(3588) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 296, DateTimeKind.Utc).AddTicks(3591), new DateTime(2026, 2, 5, 18, 55, 22, 296, DateTimeKind.Utc).AddTicks(3592) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 296, DateTimeKind.Utc).AddTicks(3595), new DateTime(2026, 2, 5, 18, 55, 22, 296, DateTimeKind.Utc).AddTicks(3596) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 297, DateTimeKind.Utc).AddTicks(6418), new DateTime(2026, 2, 5, 18, 55, 22, 297, DateTimeKind.Utc).AddTicks(6740) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 297, DateTimeKind.Utc).AddTicks(7059), new DateTime(2026, 2, 5, 18, 55, 22, 297, DateTimeKind.Utc).AddTicks(7060) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 297, DateTimeKind.Utc).AddTicks(7063), new DateTime(2026, 2, 5, 18, 55, 22, 297, DateTimeKind.Utc).AddTicks(7064) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 297, DateTimeKind.Utc).AddTicks(7101), new DateTime(2026, 2, 5, 18, 55, 22, 297, DateTimeKind.Utc).AddTicks(7101) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 297, DateTimeKind.Utc).AddTicks(7105), new DateTime(2026, 2, 5, 18, 55, 22, 297, DateTimeKind.Utc).AddTicks(7106) });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 294, DateTimeKind.Utc).AddTicks(6530));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 294, DateTimeKind.Utc).AddTicks(7016));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 294, DateTimeKind.Utc).AddTicks(7019));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 294, DateTimeKind.Utc).AddTicks(7022));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 294, DateTimeKind.Utc).AddTicks(7026));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 294, DateTimeKind.Utc).AddTicks(7029));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 294, DateTimeKind.Utc).AddTicks(7033));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 294, DateTimeKind.Utc).AddTicks(7038));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 294, DateTimeKind.Utc).AddTicks(7040));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 294, DateTimeKind.Utc).AddTicks(7043));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 294, DateTimeKind.Utc).AddTicks(7046));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 283, DateTimeKind.Utc).AddTicks(6174));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 283, DateTimeKind.Utc).AddTicks(6517));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 283, DateTimeKind.Utc).AddTicks(6520));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 283, DateTimeKind.Utc).AddTicks(6522));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 283, DateTimeKind.Utc).AddTicks(6525));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 283, DateTimeKind.Utc).AddTicks(6527));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 289, DateTimeKind.Utc).AddTicks(9719));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 18, 55, 22, 290, DateTimeKind.Utc).AddTicks(249));

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 298, DateTimeKind.Utc).AddTicks(7933), new DateTime(2026, 2, 5, 18, 55, 22, 298, DateTimeKind.Utc).AddTicks(9407) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 299, DateTimeKind.Utc).AddTicks(442), new DateTime(2026, 2, 5, 18, 55, 22, 299, DateTimeKind.Utc).AddTicks(443) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 5, 18, 55, 22, 299, DateTimeKind.Utc).AddTicks(446), new DateTime(2026, 2, 5, 18, 55, 22, 299, DateTimeKind.Utc).AddTicks(447) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessStripePriceId",
                table: "ProductVariants");

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 984, DateTimeKind.Utc).AddTicks(8100), new DateTime(2026, 2, 2, 21, 27, 50, 984, DateTimeKind.Utc).AddTicks(8437) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 984, DateTimeKind.Utc).AddTicks(8755), new DateTime(2026, 2, 2, 21, 27, 50, 984, DateTimeKind.Utc).AddTicks(8756) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 984, DateTimeKind.Utc).AddTicks(8758), new DateTime(2026, 2, 2, 21, 27, 50, 984, DateTimeKind.Utc).AddTicks(8759) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 984, DateTimeKind.Utc).AddTicks(8762), new DateTime(2026, 2, 2, 21, 27, 50, 984, DateTimeKind.Utc).AddTicks(8762) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 984, DateTimeKind.Utc).AddTicks(8765), new DateTime(2026, 2, 2, 21, 27, 50, 984, DateTimeKind.Utc).AddTicks(8766) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 986, DateTimeKind.Utc).AddTicks(4303), new DateTime(2026, 2, 2, 21, 27, 50, 986, DateTimeKind.Utc).AddTicks(4982) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 986, DateTimeKind.Utc).AddTicks(5433), new DateTime(2026, 2, 2, 21, 27, 50, 986, DateTimeKind.Utc).AddTicks(5433) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 985, DateTimeKind.Utc).AddTicks(5864), new DateTime(2026, 2, 2, 21, 27, 50, 985, DateTimeKind.Utc).AddTicks(4450), new DateTime(2026, 2, 2, 21, 27, 50, 985, DateTimeKind.Utc).AddTicks(6178) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 40, DateTimeKind.Utc).AddTicks(380));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 40, DateTimeKind.Utc).AddTicks(1088));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 37, DateTimeKind.Utc).AddTicks(1627), new DateTime(2026, 2, 2, 21, 27, 51, 37, DateTimeKind.Utc).AddTicks(541) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 982, DateTimeKind.Utc).AddTicks(3082));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 982, DateTimeKind.Utc).AddTicks(3816));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 982, DateTimeKind.Utc).AddTicks(3832));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 982, DateTimeKind.Utc).AddTicks(3836));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 982, DateTimeKind.Utc).AddTicks(4483));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 982, DateTimeKind.Utc).AddTicks(4499));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 982, DateTimeKind.Utc).AddTicks(4503));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 982, DateTimeKind.Utc).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 982, DateTimeKind.Utc).AddTicks(4516));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 982, DateTimeKind.Utc).AddTicks(4519));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 982, DateTimeKind.Utc).AddTicks(4530));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 982, DateTimeKind.Utc).AddTicks(4534));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 979, DateTimeKind.Utc).AddTicks(7800));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 979, DateTimeKind.Utc).AddTicks(8267));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 979, DateTimeKind.Utc).AddTicks(8272));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 979, DateTimeKind.Utc).AddTicks(8276));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 979, DateTimeKind.Utc).AddTicks(8279));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 979, DateTimeKind.Utc).AddTicks(8283));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 979, DateTimeKind.Utc).AddTicks(8287));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 979, DateTimeKind.Utc).AddTicks(8291));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 993, DateTimeKind.Utc).AddTicks(2746), new DateTime(2026, 2, 2, 21, 27, 50, 993, DateTimeKind.Utc).AddTicks(99), new DateTime(2026, 8, 2, 21, 27, 50, 993, DateTimeKind.Utc).AddTicks(491) });

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 978, DateTimeKind.Utc).AddTicks(1042));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name", "NameKey", "Quantity" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 978, DateTimeKind.Utc).AddTicks(1893), "5-Pack", "PackQuantity_5Pack", 5 });

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 978, DateTimeKind.Utc).AddTicks(1897));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Name", "NameKey", "Quantity" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 978, DateTimeKind.Utc).AddTicks(1904), "8-Pack", "PackQuantity_8Pack", 8 });

            migrationBuilder.InsertData(
                table: "PackQuantities",
                columns: new[] { "Id", "CreatedAt", "DisplayOrder", "IsActive", "Name", "NameKey", "Quantity", "UpdatedAt" },
                values: new object[] { 5, new DateTime(2026, 2, 2, 21, 27, 50, 978, DateTimeKind.Utc).AddTicks(1910), 5, true, "10-Pack", "PackQuantity_10Pack", 10, null });

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 994, DateTimeKind.Utc).AddTicks(3060));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 998, DateTimeKind.Utc).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 998, DateTimeKind.Utc).AddTicks(7312));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 998, DateTimeKind.Utc).AddTicks(7316));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 998, DateTimeKind.Utc).AddTicks(7319));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 998, DateTimeKind.Utc).AddTicks(7321));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 998, DateTimeKind.Utc).AddTicks(7340));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 998, DateTimeKind.Utc).AddTicks(7343));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 998, DateTimeKind.Utc).AddTicks(7346));

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 0, DateTimeKind.Utc).AddTicks(6553), new DateTime(2026, 2, 2, 21, 27, 51, 0, DateTimeKind.Utc).AddTicks(6559) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 27, DateTimeKind.Utc).AddTicks(9825), new DateTime(2026, 2, 2, 21, 27, 51, 27, DateTimeKind.Utc).AddTicks(9834) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "MetaDescription", "Name", "Slug", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 28, DateTimeKind.Utc).AddTicks(1803), "Wysokiej jakości majtki damskie bawełniane (5 sztuk). Wygodne, przewiewne i trwałe. Idealny wybór na co dzień. Dostępne w różnych kolorach i rozmiarach.", "Kup majtki damskie bawełniane wysokie 5 pak. Wygodne, przewiewne i trwałe. Dostawa w Polsce. Najlepsza jakość w przystępnej cenie.", "Majtki damskie bawełniane wysokie 5 pak", "majtki-damskie-bawelniane-wysokie-5-pak", new DateTime(2026, 2, 2, 21, 27, 51, 28, DateTimeKind.Utc).AddTicks(1806) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description", "MetaDescription", "Name", "Slug", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 28, DateTimeKind.Utc).AddTicks(6544), "High quality women's cotton briefs (5 pieces). Comfortable, breathable and durable. Perfect choice for everyday wear. Available in various colors and sizes.", "Buy women's cotton briefs 5-Pack. Comfortable, breathable and durable underwear. Best quality at an affordable price.", "Women's Cotton Briefs 5-Pack", "womens-cotton-briefs-5-pack", new DateTime(2026, 2, 2, 21, 27, 51, 28, DateTimeKind.Utc).AddTicks(6553) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Description", "MetaDescription", "Name", "Slug", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 28, DateTimeKind.Utc).AddTicks(6600), "Wysokiej jakości majtki damskie bawełniane (7 sztuk). Wygodne, przewiewne i trwałe. Idealny wybór na co dzień. Dostępne w różnych kolorach i rozmiarach.", "Kup majtki damskie bawełniane wysokie 7 pak. Wygodne, przewiewne i trwałe. Dostawa w Polsce. Najlepsza jakość w przystępnej cenie.", "Majtki damskie bawełniane wysokie 7 pak", "majtki-damskie-bawelniane-wysokie-7-pak", new DateTime(2026, 2, 2, 21, 27, 51, 28, DateTimeKind.Utc).AddTicks(6601) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Description", "MetaDescription", "Name", "Slug", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 28, DateTimeKind.Utc).AddTicks(6688), "High quality women's cotton briefs (7 pieces). Comfortable, breathable and durable. Perfect choice for everyday wear. Available in various colors and sizes.", "Buy women's cotton briefs 7-Pack. Comfortable, breathable and durable underwear. Best quality at an affordable price.", "Women's Cotton Briefs 7-Pack", "womens-cotton-briefs-7-pack", new DateTime(2026, 2, 2, 21, 27, 51, 28, DateTimeKind.Utc).AddTicks(6689) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Description", "MetaDescription", "Name", "Slug", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 28, DateTimeKind.Utc).AddTicks(6701), "Wysokiej jakości majtki damskie bawełniane (8 sztuk). Wygodne, przewiewne i trwałe. Idealny wybór na co dzień. Dostępne w różnych kolorach i rozmiarach.", "Kup majtki damskie bawełniane wysokie 8 pak. Wygodne, przewiewne i trwałe. Dostawa w Polsce. Najlepsza jakość w przystępnej cenie.", "Majtki damskie bawełniane wysokie 8 pak", "majtki-damskie-bawelniane-wysokie-8-pak", new DateTime(2026, 2, 2, 21, 27, 51, 28, DateTimeKind.Utc).AddTicks(6701) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Description", "MetaDescription", "Name", "Slug", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 28, DateTimeKind.Utc).AddTicks(6708), "High quality women's cotton briefs (8 pieces). Comfortable, breathable and durable. Perfect choice for everyday wear. Available in various colors and sizes.", "Buy women's cotton briefs 8-Pack. Comfortable, breathable and durable underwear. Best quality at an affordable price.", "Women's Cotton Briefs 8-Pack", "womens-cotton-briefs-8-pack", new DateTime(2026, 2, 2, 21, 27, 51, 28, DateTimeKind.Utc).AddTicks(6708) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9038));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9762));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9770));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9775));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9780));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9798));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9802));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9806));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9810));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9817));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9821));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9825));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9829));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9833));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9837));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9841));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9890));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9896));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9901));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9905));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9914));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9918));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9922));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9926));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9930));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9937), 49.75m, "BRIEFS-5PK-C1-S2" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9941), 49.75m, "BRIEFS-5PK-C1-S3" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9945), 49.75m, "BRIEFS-5PK-C1-S4" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9949), 49.75m, "BRIEFS-5PK-C1-S5" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9953), 49.75m, "BRIEFS-5PK-C1-S6" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9957), 49.75m, "BRIEFS-5PK-C2-S2" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9961), 49.75m, "BRIEFS-5PK-C2-S3" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9966), 49.75m, "BRIEFS-5PK-C2-S4" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9972), 49.75m, "BRIEFS-5PK-C2-S5" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9976), 49.75m, "BRIEFS-5PK-C2-S6" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9981), 49.75m, "BRIEFS-5PK-C3-S2" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9988), 49.75m, "BRIEFS-5PK-C3-S3" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9991), 49.75m, "BRIEFS-5PK-C3-S4" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9995), 49.75m, "BRIEFS-5PK-C3-S5" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc), 49.75m, "BRIEFS-5PK-C3-S6" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(5), 49.75m, "BRIEFS-5PK-C4-S2" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(9), 49.75m, "BRIEFS-5PK-C4-S3" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(13), 49.75m, "BRIEFS-5PK-C4-S4" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(17), 49.75m, "BRIEFS-5PK-C4-S5" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(21), 49.75m, "BRIEFS-5PK-C4-S6" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(25), 49.75m, "BRIEFS-5PK-C7-S2" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(30), 49.75m, "BRIEFS-5PK-C7-S3" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(34), 49.75m, "BRIEFS-5PK-C7-S4" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(38), 49.75m, "BRIEFS-5PK-C7-S5" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(42), 49.75m, "BRIEFS-5PK-C7-S6" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(47), 69.65m, "BRIEFS-7PK-C1-S2" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(51), 69.65m, "BRIEFS-7PK-C1-S3" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(70), 69.65m, "BRIEFS-7PK-C1-S4" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(75), 69.65m, "BRIEFS-7PK-C1-S5" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(80), 69.65m, "BRIEFS-7PK-C1-S6" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(84), 69.65m, "BRIEFS-7PK-C2-S2" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(97), 69.65m, "BRIEFS-7PK-C2-S3" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(101), 69.65m, "BRIEFS-7PK-C2-S4" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(105), 69.65m, "BRIEFS-7PK-C2-S5" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(109), 69.65m, "BRIEFS-7PK-C2-S6" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(113), 69.65m, "BRIEFS-7PK-C3-S2" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(118), 69.65m, "BRIEFS-7PK-C3-S3" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(121), 69.65m, "BRIEFS-7PK-C3-S4" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(125), 69.65m, "BRIEFS-7PK-C3-S5" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(130), 69.65m, "BRIEFS-7PK-C3-S6" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(138), 69.65m, "BRIEFS-7PK-C4-S2" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(142), 69.65m, "BRIEFS-7PK-C4-S3" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(146), 69.65m, "BRIEFS-7PK-C4-S4" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(150), 69.65m, "BRIEFS-7PK-C4-S5" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(154), 69.65m, "BRIEFS-7PK-C4-S6" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(159), 69.65m, "BRIEFS-7PK-C7-S2" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(163), 69.65m, "BRIEFS-7PK-C7-S3" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(167), 69.65m, "BRIEFS-7PK-C7-S4" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(172), 69.65m, "BRIEFS-7PK-C7-S5" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(176), 69.65m, "BRIEFS-7PK-C7-S6" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(181), 79.60m, "BRIEFS-8PK-C1-S2" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(185), 79.60m, "BRIEFS-8PK-C1-S3" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(189), 79.60m, "BRIEFS-8PK-C1-S4" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(194), 79.60m, "BRIEFS-8PK-C1-S5" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(198), 79.60m, "BRIEFS-8PK-C1-S6" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(203), 79.60m, "BRIEFS-8PK-C2-S2" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(207), 79.60m, "BRIEFS-8PK-C2-S3" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(211), 79.60m, "BRIEFS-8PK-C2-S4" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(215), 79.60m, "BRIEFS-8PK-C2-S5" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(219), 79.60m, "BRIEFS-8PK-C2-S6" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(225), 79.60m, "BRIEFS-8PK-C3-S2" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(228), 79.60m, "BRIEFS-8PK-C3-S3" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(234), 79.60m, "BRIEFS-8PK-C3-S4" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(257), 79.60m, "BRIEFS-8PK-C3-S5" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(264), 79.60m, "BRIEFS-8PK-C3-S6" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(269), 79.60m, "BRIEFS-8PK-C4-S2" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(274), 79.60m, "BRIEFS-8PK-C4-S3" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(278), 79.60m, "BRIEFS-8PK-C4-S4" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(283), 79.60m, "BRIEFS-8PK-C4-S5" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(287), 79.60m, "BRIEFS-8PK-C4-S6" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(291), 79.60m, "BRIEFS-8PK-C7-S2" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(296), 79.60m, "BRIEFS-8PK-C7-S3" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(300), 79.60m, "BRIEFS-8PK-C7-S4" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(305), 79.60m, "BRIEFS-8PK-C7-S5" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "CreatedAt", "Price", "SKU" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(309), 79.60m, "BRIEFS-8PK-C7-S6" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 997, DateTimeKind.Utc).AddTicks(2901));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Name", "PackSize", "Price", "Slug" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 997, DateTimeKind.Utc).AddTicks(3764), "Wysokiej jakości majtki damskie bawełniane w zestawie 5 sztuk. Wygodne, przewiewne i trwałe. Idealny wybór na co dzień. Dostępne w różnych kolorach i rozmiarach.", "Majtki damskie bawełniane wysokie - 5 pak", 5, 49.75m, "majtki-damskie-bawelniane-wysokie-5-pak" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "Name", "PackSize", "Price", "Slug" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 997, DateTimeKind.Utc).AddTicks(3768), "Wysokiej jakości majtki damskie bawełniane w zestawie 7 sztuk. Wygodne, przewiewne i trwałe. Idealny wybór na co dzień. Dostępne w różnych kolorach i rozmiarach.", "Majtki damskie bawełniane wysokie - 7 pak", 7, 69.65m, "majtki-damskie-bawelniane-wysokie-7-pak" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description", "Name", "PackSize", "Price", "Slug" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 997, DateTimeKind.Utc).AddTicks(3773), "Wysokiej jakości majtki damskie bawełniane w zestawie 8 sztuk. Wygodne, przewiewne i trwałe. Najlepszy wybór wartościowy! Dostępne w różnych kolorach i rozmiarach.", "Majtki damskie bawełniane wysokie - 8 pak", 8, 79.60m, "majtki-damskie-bawelniane-wysokie-8-pak" });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 989, DateTimeKind.Utc).AddTicks(1341), new DateTime(2026, 2, 2, 21, 27, 50, 989, DateTimeKind.Utc).AddTicks(1694) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 989, DateTimeKind.Utc).AddTicks(2014), new DateTime(2026, 2, 2, 21, 27, 50, 989, DateTimeKind.Utc).AddTicks(2015) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 989, DateTimeKind.Utc).AddTicks(2018), new DateTime(2026, 2, 2, 21, 27, 50, 989, DateTimeKind.Utc).AddTicks(2018) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 989, DateTimeKind.Utc).AddTicks(2022), new DateTime(2026, 2, 2, 21, 27, 50, 989, DateTimeKind.Utc).AddTicks(2022) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 989, DateTimeKind.Utc).AddTicks(2026), new DateTime(2026, 2, 2, 21, 27, 50, 989, DateTimeKind.Utc).AddTicks(2026) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 990, DateTimeKind.Utc).AddTicks(5880), new DateTime(2026, 2, 2, 21, 27, 50, 990, DateTimeKind.Utc).AddTicks(6212) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 990, DateTimeKind.Utc).AddTicks(6544), new DateTime(2026, 2, 2, 21, 27, 50, 990, DateTimeKind.Utc).AddTicks(6545) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 990, DateTimeKind.Utc).AddTicks(6548), new DateTime(2026, 2, 2, 21, 27, 50, 990, DateTimeKind.Utc).AddTicks(6549) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 990, DateTimeKind.Utc).AddTicks(6552), new DateTime(2026, 2, 2, 21, 27, 50, 990, DateTimeKind.Utc).AddTicks(6553) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 990, DateTimeKind.Utc).AddTicks(6557), new DateTime(2026, 2, 2, 21, 27, 50, 990, DateTimeKind.Utc).AddTicks(6557) });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 988, DateTimeKind.Utc).AddTicks(287));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 988, DateTimeKind.Utc).AddTicks(758));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 988, DateTimeKind.Utc).AddTicks(760));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 988, DateTimeKind.Utc).AddTicks(763));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 988, DateTimeKind.Utc).AddTicks(765));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 988, DateTimeKind.Utc).AddTicks(767));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 988, DateTimeKind.Utc).AddTicks(769));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 988, DateTimeKind.Utc).AddTicks(771));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 988, DateTimeKind.Utc).AddTicks(773));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 988, DateTimeKind.Utc).AddTicks(775));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 988, DateTimeKind.Utc).AddTicks(778));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 974, DateTimeKind.Utc).AddTicks(8903));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 974, DateTimeKind.Utc).AddTicks(9509));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 974, DateTimeKind.Utc).AddTicks(9517));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 974, DateTimeKind.Utc).AddTicks(9520));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 974, DateTimeKind.Utc).AddTicks(9525));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 974, DateTimeKind.Utc).AddTicks(9533));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 983, DateTimeKind.Utc).AddTicks(3373));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 983, DateTimeKind.Utc).AddTicks(3980));

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 991, DateTimeKind.Utc).AddTicks(5510), new DateTime(2026, 2, 2, 21, 27, 50, 991, DateTimeKind.Utc).AddTicks(5822) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 991, DateTimeKind.Utc).AddTicks(6137), new DateTime(2026, 2, 2, 21, 27, 50, 991, DateTimeKind.Utc).AddTicks(6138) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 991, DateTimeKind.Utc).AddTicks(6141), new DateTime(2026, 2, 2, 21, 27, 50, 991, DateTimeKind.Utc).AddTicks(6141) });
        }
    }
}
