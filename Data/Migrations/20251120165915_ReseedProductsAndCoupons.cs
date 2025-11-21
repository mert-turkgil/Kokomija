using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kokomija.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReseedProductsAndCoupons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 20, 16, 59, 13, 979, DateTimeKind.Utc).AddTicks(261), new DateTime(2025, 11, 20, 16, 59, 13, 979, DateTimeKind.Utc).AddTicks(260) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 20, 16, 59, 13, 979, DateTimeKind.Utc).AddTicks(265), new DateTime(2025, 11, 20, 16, 59, 13, 979, DateTimeKind.Utc).AddTicks(264) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 20, 16, 59, 13, 979, DateTimeKind.Utc).AddTicks(268), new DateTime(2025, 11, 20, 16, 59, 13, 979, DateTimeKind.Utc).AddTicks(267) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 20, 16, 59, 13, 979, DateTimeKind.Utc).AddTicks(271), new DateTime(2025, 11, 20, 16, 59, 13, 979, DateTimeKind.Utc).AddTicks(271) });

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

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "Code", "CreatedAt", "Description", "DiscountType", "DiscountValue", "IsActive", "MaximumDiscountAmount", "MinimumOrderAmount", "StripeCouponId", "StripePromotionCodeId", "UpdatedAt", "UsageLimit", "UsageLimitPerUser", "ValidFrom", "ValidUntil" },
                values: new object[] { 1, "WELCOME10", new DateTime(2025, 11, 20, 16, 59, 13, 972, DateTimeKind.Utc).AddTicks(7063), "10% off your first order", "percentage", 10.00m, true, 50.00m, 50.00m, "", "", null, 1000, 1, new DateTime(2025, 11, 20, 16, 59, 13, 972, DateTimeKind.Utc).AddTicks(4679), new DateTime(2026, 5, 20, 16, 59, 13, 972, DateTimeKind.Utc).AddTicks(5280) });

            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "Id", "CreatedAt", "Description", "DescriptionKey", "Name", "NameKey", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 11, 20, 16, 59, 13, 973, DateTimeKind.Utc).AddTicks(3648), "High-quality women's cotton briefs in various pack sizes", "ProductGroup_WomenBriefs_Description", "Women's Cotton Briefs Pack Collection", "ProductGroup_WomenBriefs_Name", null });

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

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "DescriptionKey", "IsActive", "Name", "NameKey", "PackSize", "Price", "ProductGroupId", "StripePriceId", "StripeProductId", "StripeTaxCode", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 11, 20, 16, 59, 13, 974, DateTimeKind.Utc).AddTicks(8773), "Wysokiej jakości majtki damskie bawełniane w zestawie 5 sztuk. Wygodne, przewiewne i trwałe. Idealny wybór na co dzień. Dostępne w różnych kolorach i rozmiarach.", "Product_WomenBriefs5Pack_Description", true, "Majtki damskie bawełniane wysokie - 5 pak", "Product_WomenBriefs5Pack_Name", 5, 49.75m, 1, "", "", "txcd_30011000", null },
                    { 2, 1, new DateTime(2025, 11, 20, 16, 59, 13, 974, DateTimeKind.Utc).AddTicks(9140), "Wysokiej jakości majtki damskie bawełniane w zestawie 6 sztuk. Wygodne, przewiewne i trwałe. Idealny wybór na co dzień. Dostępne w różnych kolorach i rozmiarach.", "Product_WomenBriefs6Pack_Description", true, "Majtki damskie bawełniane wysokie - 6 pak", "Product_WomenBriefs6Pack_Name", 6, 59.70m, 1, "", "", "txcd_30011000", null },
                    { 3, 1, new DateTime(2025, 11, 20, 16, 59, 13, 974, DateTimeKind.Utc).AddTicks(9144), "Wysokiej jakości majtki damskie bawełniane w zestawie 8 sztuk. Wygodne, przewiewne i trwałe. Najlepszy wybór wartościowy! Dostępne w różnych kolorach i rozmiarach.", "Product_WomenBriefs8Pack_Description", true, "Majtki damskie bawełniane wysokie - 8 pak", "Product_WomenBriefs8Pack_Name", 8, 79.60m, 1, "", "", "txcd_30011000", null }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "IsPrimary", "ProductId" },
                values: new object[] { 1, "Majtki damskie bawełniane 5-pak - zdjęcie 1", null, new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1224), 1, "products/briefs-5pack/image-1.jpg", true, 1 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 2, "Majtki damskie bawełniane 5-pak - zdjęcie 2", null, new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1710), 2, "products/briefs-5pack/image-2.jpg", 1 },
                    { 3, "Majtki damskie bawełniane 5-pak - zdjęcie 3", null, new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1717), 3, "products/briefs-5pack/image-3.jpg", 1 },
                    { 4, "Majtki damskie bawełniane 5-pak - zdjęcie 4", null, new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1721), 4, "products/briefs-5pack/image-4.jpg", 1 },
                    { 5, "Majtki damskie bawełniane 5-pak - zdjęcie 5", null, new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1888), 5, "products/briefs-5pack/image-5.jpg", 1 },
                    { 6, "Majtki damskie bawełniane 5-pak - zdjęcie 6", null, new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1907), 6, "products/briefs-5pack/image-6.jpg", 1 },
                    { 7, "Majtki damskie bawełniane 5-pak - zdjęcie 7", null, new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1911), 7, "products/briefs-5pack/image-7.jpg", 1 },
                    { 8, "Majtki damskie bawełniane 5-pak - zdjęcie 8", null, new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1914), 8, "products/briefs-5pack/image-8.jpg", 1 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "IsPrimary", "ProductId" },
                values: new object[] { 9, "Majtki damskie bawełniane 6-pak - zdjęcie 1", null, new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1920), 1, "products/briefs-6pack/image-1.jpg", true, 2 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 10, "Majtki damskie bawełniane 6-pak - zdjęcie 2", null, new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1927), 2, "products/briefs-6pack/image-2.jpg", 2 },
                    { 11, "Majtki damskie bawełniane 6-pak - zdjęcie 3", null, new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1930), 3, "products/briefs-6pack/image-3.jpg", 2 },
                    { 12, "Majtki damskie bawełniane 6-pak - zdjęcie 4", null, new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1934), 4, "products/briefs-6pack/image-4.jpg", 2 },
                    { 13, "Majtki damskie bawełniane 6-pak - zdjęcie 5", null, new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1937), 5, "products/briefs-6pack/image-5.jpg", 2 },
                    { 14, "Majtki damskie bawełniane 6-pak - zdjęcie 6", null, new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1941), 6, "products/briefs-6pack/image-6.jpg", 2 },
                    { 15, "Majtki damskie bawełniane 6-pak - zdjęcie 7", null, new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1945), 7, "products/briefs-6pack/image-7.jpg", 2 },
                    { 16, "Majtki damskie bawełniane 6-pak - zdjęcie 8", null, new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1948), 8, "products/briefs-6pack/image-8.jpg", 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "IsPrimary", "ProductId" },
                values: new object[] { 17, "Majtki damskie bawełniane 8-pak - zdjęcie 1", null, new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1959), 1, "products/briefs-8pack/image-1.jpg", true, 3 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 18, "Majtki damskie bawełniane 8-pak - zdjęcie 2", null, new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1965), 2, "products/briefs-8pack/image-2.jpg", 3 },
                    { 19, "Majtki damskie bawełniane 8-pak - zdjęcie 3", null, new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1968), 3, "products/briefs-8pack/image-3.jpg", 3 },
                    { 20, "Majtki damskie bawełniane 8-pak - zdjęcie 4", null, new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1972), 4, "products/briefs-8pack/image-4.jpg", 3 },
                    { 21, "Majtki damskie bawełniane 8-pak - zdjęcie 5", null, new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1976), 5, "products/briefs-8pack/image-5.jpg", 3 },
                    { 22, "Majtki damskie bawełniane 8-pak - zdjęcie 6", null, new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1980), 6, "products/briefs-8pack/image-6.jpg", 3 },
                    { 23, "Majtki damskie bawełniane 8-pak - zdjęcie 7", null, new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1983), 7, "products/briefs-8pack/image-7.jpg", 3 },
                    { 24, "Majtki damskie bawełniane 8-pak - zdjęcie 8", null, new DateTime(2025, 11, 20, 16, 59, 13, 976, DateTimeKind.Utc).AddTicks(1987), 8, "products/briefs-8pack/image-8.jpg", 3 }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "Id", "ColorId", "CreatedAt", "IsActive", "Price", "ProductId", "SKU", "SizeId", "StockQuantity", "StripePriceId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 8, new DateTime(2025, 11, 20, 16, 59, 13, 977, DateTimeKind.Utc).AddTicks(8204), true, 49.75m, 1, "BRIEFS-5PK-S2", 2, 100, "", null },
                    { 2, 8, new DateTime(2025, 11, 20, 16, 59, 13, 977, DateTimeKind.Utc).AddTicks(8649), true, 49.75m, 1, "BRIEFS-5PK-S3", 3, 100, "", null },
                    { 3, 8, new DateTime(2025, 11, 20, 16, 59, 13, 977, DateTimeKind.Utc).AddTicks(8653), true, 49.75m, 1, "BRIEFS-5PK-S4", 4, 100, "", null },
                    { 4, 8, new DateTime(2025, 11, 20, 16, 59, 13, 977, DateTimeKind.Utc).AddTicks(8656), true, 49.75m, 1, "BRIEFS-5PK-S5", 5, 100, "", null },
                    { 5, 8, new DateTime(2025, 11, 20, 16, 59, 13, 977, DateTimeKind.Utc).AddTicks(8659), true, 49.75m, 1, "BRIEFS-5PK-S6", 6, 100, "", null },
                    { 6, 8, new DateTime(2025, 11, 20, 16, 59, 13, 977, DateTimeKind.Utc).AddTicks(8674), true, 59.70m, 2, "BRIEFS-6PK-S2", 2, 100, "", null },
                    { 7, 8, new DateTime(2025, 11, 20, 16, 59, 13, 977, DateTimeKind.Utc).AddTicks(8770), true, 59.70m, 2, "BRIEFS-6PK-S3", 3, 100, "", null },
                    { 8, 8, new DateTime(2025, 11, 20, 16, 59, 13, 977, DateTimeKind.Utc).AddTicks(8773), true, 59.70m, 2, "BRIEFS-6PK-S4", 4, 100, "", null },
                    { 9, 8, new DateTime(2025, 11, 20, 16, 59, 13, 977, DateTimeKind.Utc).AddTicks(8777), true, 59.70m, 2, "BRIEFS-6PK-S5", 5, 100, "", null },
                    { 10, 8, new DateTime(2025, 11, 20, 16, 59, 13, 977, DateTimeKind.Utc).AddTicks(8781), true, 59.70m, 2, "BRIEFS-6PK-S6", 6, 100, "", null },
                    { 11, 8, new DateTime(2025, 11, 20, 16, 59, 13, 977, DateTimeKind.Utc).AddTicks(8787), true, 79.60m, 3, "BRIEFS-8PK-S2", 2, 100, "", null },
                    { 12, 8, new DateTime(2025, 11, 20, 16, 59, 13, 977, DateTimeKind.Utc).AddTicks(8790), true, 79.60m, 3, "BRIEFS-8PK-S3", 3, 100, "", null },
                    { 13, 8, new DateTime(2025, 11, 20, 16, 59, 13, 977, DateTimeKind.Utc).AddTicks(8793), true, 79.60m, 3, "BRIEFS-8PK-S4", 4, 100, "", null },
                    { 14, 8, new DateTime(2025, 11, 20, 16, 59, 13, 977, DateTimeKind.Utc).AddTicks(8796), true, 79.60m, 3, "BRIEFS-8PK-S5", 5, 100, "", null },
                    { 15, 8, new DateTime(2025, 11, 20, 16, 59, 13, 977, DateTimeKind.Utc).AddTicks(8799), true, 79.60m, 3, "BRIEFS-8PK-S6", 6, 100, "", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 20, 16, 56, 5, 494, DateTimeKind.Utc).AddTicks(868), new DateTime(2025, 11, 20, 16, 56, 5, 494, DateTimeKind.Utc).AddTicks(1201) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 20, 16, 56, 5, 494, DateTimeKind.Utc).AddTicks(1521), new DateTime(2025, 11, 20, 16, 56, 5, 494, DateTimeKind.Utc).AddTicks(1521) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 20, 16, 56, 5, 494, DateTimeKind.Utc).AddTicks(1524), new DateTime(2025, 11, 20, 16, 56, 5, 494, DateTimeKind.Utc).AddTicks(1525) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 20, 16, 56, 5, 494, DateTimeKind.Utc).AddTicks(1528), new DateTime(2025, 11, 20, 16, 56, 5, 494, DateTimeKind.Utc).AddTicks(1528) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 20, 16, 56, 5, 494, DateTimeKind.Utc).AddTicks(1531), new DateTime(2025, 11, 20, 16, 56, 5, 494, DateTimeKind.Utc).AddTicks(1532) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 20, 16, 56, 5, 496, DateTimeKind.Utc).AddTicks(7037), new DateTime(2025, 11, 20, 16, 56, 5, 496, DateTimeKind.Utc).AddTicks(6311) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 20, 16, 56, 5, 496, DateTimeKind.Utc).AddTicks(7525), new DateTime(2025, 11, 20, 16, 56, 5, 496, DateTimeKind.Utc).AddTicks(7524) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 20, 16, 56, 5, 496, DateTimeKind.Utc).AddTicks(7529), new DateTime(2025, 11, 20, 16, 56, 5, 496, DateTimeKind.Utc).AddTicks(7528) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 20, 16, 56, 5, 496, DateTimeKind.Utc).AddTicks(7533), new DateTime(2025, 11, 20, 16, 56, 5, 496, DateTimeKind.Utc).AddTicks(7532) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 20, 16, 56, 5, 496, DateTimeKind.Utc).AddTicks(7537), new DateTime(2025, 11, 20, 16, 56, 5, 496, DateTimeKind.Utc).AddTicks(7536) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 492, DateTimeKind.Utc).AddTicks(4693));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 492, DateTimeKind.Utc).AddTicks(5029));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 492, DateTimeKind.Utc).AddTicks(5032));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 492, DateTimeKind.Utc).AddTicks(5035));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 492, DateTimeKind.Utc).AddTicks(5373));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 492, DateTimeKind.Utc).AddTicks(5454));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 492, DateTimeKind.Utc).AddTicks(5458));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 492, DateTimeKind.Utc).AddTicks(5461));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 492, DateTimeKind.Utc).AddTicks(5464));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 492, DateTimeKind.Utc).AddTicks(5467));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 492, DateTimeKind.Utc).AddTicks(5471));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 492, DateTimeKind.Utc).AddTicks(5474));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 491, DateTimeKind.Utc).AddTicks(1215));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 491, DateTimeKind.Utc).AddTicks(1554));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 491, DateTimeKind.Utc).AddTicks(1557));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 491, DateTimeKind.Utc).AddTicks(1559));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 491, DateTimeKind.Utc).AddTicks(1562));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 491, DateTimeKind.Utc).AddTicks(1564));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 491, DateTimeKind.Utc).AddTicks(1567));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 491, DateTimeKind.Utc).AddTicks(1569));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 495, DateTimeKind.Utc).AddTicks(3177));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 495, DateTimeKind.Utc).AddTicks(3664));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 495, DateTimeKind.Utc).AddTicks(3666));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 495, DateTimeKind.Utc).AddTicks(3669));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 495, DateTimeKind.Utc).AddTicks(3671));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 495, DateTimeKind.Utc).AddTicks(3673));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 495, DateTimeKind.Utc).AddTicks(3676));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 495, DateTimeKind.Utc).AddTicks(3678));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 495, DateTimeKind.Utc).AddTicks(3680));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 495, DateTimeKind.Utc).AddTicks(3683));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 495, DateTimeKind.Utc).AddTicks(3685));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 489, DateTimeKind.Utc).AddTicks(3544));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 489, DateTimeKind.Utc).AddTicks(3885));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 489, DateTimeKind.Utc).AddTicks(3887));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 489, DateTimeKind.Utc).AddTicks(3889));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 489, DateTimeKind.Utc).AddTicks(3892));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 489, DateTimeKind.Utc).AddTicks(3894));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 493, DateTimeKind.Utc).AddTicks(1438));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 16, 56, 5, 493, DateTimeKind.Utc).AddTicks(1760));
        }
    }
}
