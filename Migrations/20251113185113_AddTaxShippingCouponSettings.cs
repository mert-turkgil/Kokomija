using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kokomija.Migrations
{
    /// <inheritdoc />
    public partial class AddTaxShippingCouponSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "Code", "CreatedAt", "Description", "DiscountType", "DiscountValue", "IsActive", "MaximumDiscountAmount", "MinimumOrderAmount", "StripeCouponId", "StripePromotionCodeId", "UpdatedAt", "UsageLimit", "UsageLimitPerUser", "ValidFrom", "ValidUntil" },
                values: new object[] { 1, "WELCOME10", new DateTime(2025, 11, 13, 18, 51, 11, 307, DateTimeKind.Utc).AddTicks(262), "10% off your first order", "percentage", 10.00m, true, 50.00m, 50.00m, "", "", null, 1000, 1, new DateTime(2025, 11, 13, 18, 51, 11, 306, DateTimeKind.Utc).AddTicks(8081), new DateTime(2026, 5, 13, 18, 51, 11, 306, DateTimeKind.Utc).AddTicks(8735) });

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

            migrationBuilder.InsertData(
                table: "SiteSettings",
                columns: new[] { "Id", "Category", "DataType", "Description", "Key", "UpdatedAt", "UpdatedBy", "Value" },
                values: new object[,]
                {
                    { 9, "Tax", "decimal", "Tax rate (VAT) applied to orders (decimal, e.g., 0.23 = 23%)", "TaxRate", new DateTime(2025, 11, 13, 18, 51, 11, 304, DateTimeKind.Utc).AddTicks(8055), null, "0.23" },
                    { 10, "Shipping", "decimal", "Standard shipping cost in PLN", "ShippingRate", new DateTime(2025, 11, 13, 18, 51, 11, 304, DateTimeKind.Utc).AddTicks(8058), null, "15.00" },
                    { 11, "Shipping", "decimal", "Minimum order amount for free shipping in PLN", "FreeShippingThreshold", new DateTime(2025, 11, 13, 18, 51, 11, 304, DateTimeKind.Utc).AddTicks(8060), null, "200.00" }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 13, 18, 6, 40, 394, DateTimeKind.Utc).AddTicks(5088), new DateTime(2025, 11, 13, 18, 6, 40, 394, DateTimeKind.Utc).AddTicks(5418) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 13, 18, 6, 40, 394, DateTimeKind.Utc).AddTicks(5738), new DateTime(2025, 11, 13, 18, 6, 40, 394, DateTimeKind.Utc).AddTicks(5739) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 13, 18, 6, 40, 394, DateTimeKind.Utc).AddTicks(5742), new DateTime(2025, 11, 13, 18, 6, 40, 394, DateTimeKind.Utc).AddTicks(5742) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 13, 18, 6, 40, 394, DateTimeKind.Utc).AddTicks(5745), new DateTime(2025, 11, 13, 18, 6, 40, 394, DateTimeKind.Utc).AddTicks(5746) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 13, 18, 6, 40, 394, DateTimeKind.Utc).AddTicks(5748), new DateTime(2025, 11, 13, 18, 6, 40, 394, DateTimeKind.Utc).AddTicks(5749) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 13, 18, 6, 40, 401, DateTimeKind.Utc).AddTicks(5494), new DateTime(2025, 11, 13, 18, 6, 40, 401, DateTimeKind.Utc).AddTicks(4929) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 13, 18, 6, 40, 401, DateTimeKind.Utc).AddTicks(5828), new DateTime(2025, 11, 13, 18, 6, 40, 401, DateTimeKind.Utc).AddTicks(5827) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 13, 18, 6, 40, 401, DateTimeKind.Utc).AddTicks(5832), new DateTime(2025, 11, 13, 18, 6, 40, 401, DateTimeKind.Utc).AddTicks(5831) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 13, 18, 6, 40, 401, DateTimeKind.Utc).AddTicks(5835), new DateTime(2025, 11, 13, 18, 6, 40, 401, DateTimeKind.Utc).AddTicks(5834) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 13, 18, 6, 40, 401, DateTimeKind.Utc).AddTicks(5838), new DateTime(2025, 11, 13, 18, 6, 40, 401, DateTimeKind.Utc).AddTicks(5838) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 391, DateTimeKind.Utc).AddTicks(9890));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 392, DateTimeKind.Utc).AddTicks(366));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 392, DateTimeKind.Utc).AddTicks(369));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 392, DateTimeKind.Utc).AddTicks(373));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 392, DateTimeKind.Utc).AddTicks(1027));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 392, DateTimeKind.Utc).AddTicks(1039));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 392, DateTimeKind.Utc).AddTicks(1043));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 392, DateTimeKind.Utc).AddTicks(1053));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 392, DateTimeKind.Utc).AddTicks(1056));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 392, DateTimeKind.Utc).AddTicks(1061));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 392, DateTimeKind.Utc).AddTicks(1065));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 392, DateTimeKind.Utc).AddTicks(1069));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 390, DateTimeKind.Utc).AddTicks(6239));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 390, DateTimeKind.Utc).AddTicks(6660));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 390, DateTimeKind.Utc).AddTicks(6662));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 390, DateTimeKind.Utc).AddTicks(6665));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 390, DateTimeKind.Utc).AddTicks(6668));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 390, DateTimeKind.Utc).AddTicks(6670));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 390, DateTimeKind.Utc).AddTicks(6673));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 390, DateTimeKind.Utc).AddTicks(6675));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7266));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7721));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7724));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7728));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7731));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7746));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7749));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7752));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7757));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7763));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7766));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7769));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7772));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7775));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7778));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7781));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7786));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7791));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7794));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7797));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7800));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7803));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7806));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7809));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 400, DateTimeKind.Utc).AddTicks(844));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 400, DateTimeKind.Utc).AddTicks(1491));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 400, DateTimeKind.Utc).AddTicks(1494));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 400, DateTimeKind.Utc).AddTicks(1497));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 400, DateTimeKind.Utc).AddTicks(1500));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 400, DateTimeKind.Utc).AddTicks(1524));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 400, DateTimeKind.Utc).AddTicks(1527));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 400, DateTimeKind.Utc).AddTicks(1533));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 400, DateTimeKind.Utc).AddTicks(1540));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 400, DateTimeKind.Utc).AddTicks(1546));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 400, DateTimeKind.Utc).AddTicks(1551));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 400, DateTimeKind.Utc).AddTicks(1556));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 400, DateTimeKind.Utc).AddTicks(1559));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 400, DateTimeKind.Utc).AddTicks(1562));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 400, DateTimeKind.Utc).AddTicks(1564));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 396, DateTimeKind.Utc).AddTicks(6091));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 396, DateTimeKind.Utc).AddTicks(6423));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 396, DateTimeKind.Utc).AddTicks(6427));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 395, DateTimeKind.Utc).AddTicks(4727));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 395, DateTimeKind.Utc).AddTicks(5190));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 395, DateTimeKind.Utc).AddTicks(5192));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 395, DateTimeKind.Utc).AddTicks(5194));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 395, DateTimeKind.Utc).AddTicks(5196));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 395, DateTimeKind.Utc).AddTicks(5198));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 395, DateTimeKind.Utc).AddTicks(5201));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 395, DateTimeKind.Utc).AddTicks(5203));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 388, DateTimeKind.Utc).AddTicks(8557));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 388, DateTimeKind.Utc).AddTicks(8911));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 388, DateTimeKind.Utc).AddTicks(8913));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 388, DateTimeKind.Utc).AddTicks(8915));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 388, DateTimeKind.Utc).AddTicks(8918));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 388, DateTimeKind.Utc).AddTicks(8920));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 393, DateTimeKind.Utc).AddTicks(4818));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 393, DateTimeKind.Utc).AddTicks(5174));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 393, DateTimeKind.Utc).AddTicks(5177));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 393, DateTimeKind.Utc).AddTicks(5179));
        }
    }
}
