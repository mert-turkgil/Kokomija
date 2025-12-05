using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kokomija.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedOrderManagementData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 38, 28, 295, DateTimeKind.Utc).AddTicks(3903), new DateTime(2025, 12, 5, 14, 38, 28, 295, DateTimeKind.Utc).AddTicks(4222) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 38, 28, 295, DateTimeKind.Utc).AddTicks(4538), new DateTime(2025, 12, 5, 14, 38, 28, 295, DateTimeKind.Utc).AddTicks(4538) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 38, 28, 295, DateTimeKind.Utc).AddTicks(4541), new DateTime(2025, 12, 5, 14, 38, 28, 295, DateTimeKind.Utc).AddTicks(4541) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 38, 28, 295, DateTimeKind.Utc).AddTicks(4544), new DateTime(2025, 12, 5, 14, 38, 28, 295, DateTimeKind.Utc).AddTicks(4544) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 38, 28, 295, DateTimeKind.Utc).AddTicks(4547), new DateTime(2025, 12, 5, 14, 38, 28, 295, DateTimeKind.Utc).AddTicks(4547) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 38, 28, 296, DateTimeKind.Utc).AddTicks(7917), new DateTime(2025, 12, 5, 14, 38, 28, 296, DateTimeKind.Utc).AddTicks(8224) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 38, 28, 296, DateTimeKind.Utc).AddTicks(8654), new DateTime(2025, 12, 5, 14, 38, 28, 296, DateTimeKind.Utc).AddTicks(8654) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 38, 28, 296, DateTimeKind.Utc).AddTicks(112), new DateTime(2025, 12, 5, 14, 38, 28, 295, DateTimeKind.Utc).AddTicks(8769), new DateTime(2025, 12, 5, 14, 38, 28, 296, DateTimeKind.Utc).AddTicks(414) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 307, DateTimeKind.Utc).AddTicks(8705));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 307, DateTimeKind.Utc).AddTicks(9160));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 38, 28, 307, DateTimeKind.Utc).AddTicks(681), new DateTime(2025, 12, 5, 14, 38, 28, 307, DateTimeKind.Utc).AddTicks(314) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 293, DateTimeKind.Utc).AddTicks(3767));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 293, DateTimeKind.Utc).AddTicks(4094));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 293, DateTimeKind.Utc).AddTicks(4097));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 293, DateTimeKind.Utc).AddTicks(4099));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 293, DateTimeKind.Utc).AddTicks(4421));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 293, DateTimeKind.Utc).AddTicks(4429));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 293, DateTimeKind.Utc).AddTicks(4432));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 293, DateTimeKind.Utc).AddTicks(4435));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 293, DateTimeKind.Utc).AddTicks(4438));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 293, DateTimeKind.Utc).AddTicks(4441));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 293, DateTimeKind.Utc).AddTicks(4443));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 293, DateTimeKind.Utc).AddTicks(4446));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 292, DateTimeKind.Utc).AddTicks(1482));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 292, DateTimeKind.Utc).AddTicks(1806));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 292, DateTimeKind.Utc).AddTicks(1808));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 292, DateTimeKind.Utc).AddTicks(1810));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 292, DateTimeKind.Utc).AddTicks(1813));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 292, DateTimeKind.Utc).AddTicks(1815));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 292, DateTimeKind.Utc).AddTicks(1817));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 292, DateTimeKind.Utc).AddTicks(1820));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 38, 28, 302, DateTimeKind.Utc).AddTicks(1967), new DateTime(2025, 12, 5, 14, 38, 28, 301, DateTimeKind.Utc).AddTicks(9805), new DateTime(2026, 6, 5, 14, 38, 28, 302, DateTimeKind.Utc).AddTicks(149) });

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 302, DateTimeKind.Utc).AddTicks(6931));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 304, DateTimeKind.Utc).AddTicks(9723));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 305, DateTimeKind.Utc).AddTicks(108));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 305, DateTimeKind.Utc).AddTicks(112));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 305, DateTimeKind.Utc).AddTicks(115));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 305, DateTimeKind.Utc).AddTicks(119));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 305, DateTimeKind.Utc).AddTicks(132));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 305, DateTimeKind.Utc).AddTicks(135));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 305, DateTimeKind.Utc).AddTicks(138));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 305, DateTimeKind.Utc).AddTicks(144));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 305, DateTimeKind.Utc).AddTicks(186));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 305, DateTimeKind.Utc).AddTicks(189));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 305, DateTimeKind.Utc).AddTicks(193));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 305, DateTimeKind.Utc).AddTicks(196));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 305, DateTimeKind.Utc).AddTicks(199));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 305, DateTimeKind.Utc).AddTicks(202));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 305, DateTimeKind.Utc).AddTicks(205));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 305, DateTimeKind.Utc).AddTicks(210));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 305, DateTimeKind.Utc).AddTicks(215));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 305, DateTimeKind.Utc).AddTicks(218));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 305, DateTimeKind.Utc).AddTicks(221));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 305, DateTimeKind.Utc).AddTicks(224));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 305, DateTimeKind.Utc).AddTicks(227));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 305, DateTimeKind.Utc).AddTicks(231));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 305, DateTimeKind.Utc).AddTicks(234));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 306, DateTimeKind.Utc).AddTicks(1776));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 306, DateTimeKind.Utc).AddTicks(2125));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 306, DateTimeKind.Utc).AddTicks(2128));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 306, DateTimeKind.Utc).AddTicks(2131));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 306, DateTimeKind.Utc).AddTicks(2133));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 306, DateTimeKind.Utc).AddTicks(2142));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 306, DateTimeKind.Utc).AddTicks(2144));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 306, DateTimeKind.Utc).AddTicks(2147));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 306, DateTimeKind.Utc).AddTicks(2149));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 306, DateTimeKind.Utc).AddTicks(2153));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 306, DateTimeKind.Utc).AddTicks(2157));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 306, DateTimeKind.Utc).AddTicks(2160));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 306, DateTimeKind.Utc).AddTicks(2162));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 306, DateTimeKind.Utc).AddTicks(2165));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 306, DateTimeKind.Utc).AddTicks(2183));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 303, DateTimeKind.Utc).AddTicks(9186));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 303, DateTimeKind.Utc).AddTicks(9652));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 303, DateTimeKind.Utc).AddTicks(9656));

            migrationBuilder.InsertData(
                table: "ShippingProviders",
                columns: new[] { "Id", "ApiKey", "ApiSecret", "Code", "CreatedAt", "EstimatedDeliveryDays", "IsActive", "LogoUrl", "Name", "SupportedCountries", "TrackingUrlTemplate", "UpdatedAt", "WebhookUrl" },
                values: new object[,]
                {
                    { 1, null, null, "inpost", new DateTime(2025, 12, 5, 14, 38, 28, 298, DateTimeKind.Utc).AddTicks(4432), 2, true, null, "InPost", "[\"PL\"]", "https://inpost.pl/sledzenie-przesylek?number={trackingNumber}", new DateTime(2025, 12, 5, 14, 38, 28, 298, DateTimeKind.Utc).AddTicks(4737), null },
                    { 2, null, null, "dhl", new DateTime(2025, 12, 5, 14, 38, 28, 298, DateTimeKind.Utc).AddTicks(5073), 3, true, null, "DHL", "[\"PL\",\"DE\",\"US\",\"GB\"]", "https://www.dhl.com/en/express/tracking.html?AWB={trackingNumber}", new DateTime(2025, 12, 5, 14, 38, 28, 298, DateTimeKind.Utc).AddTicks(5074), null },
                    { 3, null, null, "ups", new DateTime(2025, 12, 5, 14, 38, 28, 298, DateTimeKind.Utc).AddTicks(5078), 3, true, null, "UPS", "[\"PL\",\"DE\",\"US\",\"GB\"]", "https://www.ups.com/track?tracknum={trackingNumber}", new DateTime(2025, 12, 5, 14, 38, 28, 298, DateTimeKind.Utc).AddTicks(5078), null },
                    { 4, null, null, "fedex", new DateTime(2025, 12, 5, 14, 38, 28, 298, DateTimeKind.Utc).AddTicks(5114), 3, true, null, "FedEx", "[\"PL\",\"DE\",\"US\",\"GB\"]", "https://www.fedex.com/fedextrack/?trknbr={trackingNumber}", new DateTime(2025, 12, 5, 14, 38, 28, 298, DateTimeKind.Utc).AddTicks(5114), null },
                    { 5, null, null, "poczta_polska", new DateTime(2025, 12, 5, 14, 38, 28, 298, DateTimeKind.Utc).AddTicks(5118), 5, true, null, "Poczta Polska", "[\"PL\"]", "https://emonitoring.poczta-polska.pl/?numer={trackingNumber}", new DateTime(2025, 12, 5, 14, 38, 28, 298, DateTimeKind.Utc).AddTicks(5118), null }
                });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 297, DateTimeKind.Utc).AddTicks(6523));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 297, DateTimeKind.Utc).AddTicks(6840));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 297, DateTimeKind.Utc).AddTicks(6843));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 297, DateTimeKind.Utc).AddTicks(6846));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 297, DateTimeKind.Utc).AddTicks(6848));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 297, DateTimeKind.Utc).AddTicks(6852));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 297, DateTimeKind.Utc).AddTicks(6854));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 297, DateTimeKind.Utc).AddTicks(6856));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 297, DateTimeKind.Utc).AddTicks(6859));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 297, DateTimeKind.Utc).AddTicks(6862));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 297, DateTimeKind.Utc).AddTicks(6864));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 290, DateTimeKind.Utc).AddTicks(4515));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 290, DateTimeKind.Utc).AddTicks(4863));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 290, DateTimeKind.Utc).AddTicks(4865));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 290, DateTimeKind.Utc).AddTicks(4868));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 290, DateTimeKind.Utc).AddTicks(4870));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 290, DateTimeKind.Utc).AddTicks(4872));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 294, DateTimeKind.Utc).AddTicks(3765));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 38, 28, 294, DateTimeKind.Utc).AddTicks(4284));

            migrationBuilder.InsertData(
                table: "TaxRates",
                columns: new[] { "Id", "CountryCode", "CreatedAt", "Description", "IsActive", "IsDefault", "Name", "Rate", "StateCode", "StripeTaxRateId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "PL", new DateTime(2025, 12, 5, 14, 38, 28, 300, DateTimeKind.Utc).AddTicks(9979), "Standard VAT rate for Poland", true, true, "VAT 23% (Poland)", 23.00m, null, "txr_placeholder_pl_23", new DateTime(2025, 12, 5, 14, 38, 28, 301, DateTimeKind.Utc).AddTicks(329) },
                    { 2, "PL", new DateTime(2025, 12, 5, 14, 38, 28, 301, DateTimeKind.Utc).AddTicks(782), "Reduced VAT rate for specific products", true, false, "VAT 8% (Poland - Reduced)", 8.00m, null, "txr_placeholder_pl_8", new DateTime(2025, 12, 5, 14, 38, 28, 301, DateTimeKind.Utc).AddTicks(782) },
                    { 3, "PL", new DateTime(2025, 12, 5, 14, 38, 28, 301, DateTimeKind.Utc).AddTicks(785), "Super reduced VAT rate", false, false, "VAT 5% (Poland - Super Reduced)", 5.00m, null, "txr_placeholder_pl_5", new DateTime(2025, 12, 5, 14, 38, 28, 301, DateTimeKind.Utc).AddTicks(786) }
                });

            migrationBuilder.InsertData(
                table: "ShippingRates",
                columns: new[] { "Id", "BasePrice", "CountryCode", "CreatedAt", "Description", "FreeShippingThreshold", "IsActive", "MaxDeliveryDays", "MinDeliveryDays", "Name", "PricePerKg", "PricePerKm", "ShippingProviderId", "StripeShippingRateId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 9.99m, "PL", new DateTime(2025, 12, 5, 14, 38, 28, 300, DateTimeKind.Utc).AddTicks(1022), "Delivery to InPost parcel locker", 100.00m, true, 2, 1, "InPost Paczkomat", null, null, 1, null, new DateTime(2025, 12, 5, 14, 38, 28, 300, DateTimeKind.Utc).AddTicks(1362) },
                    { 2, 14.99m, "PL", new DateTime(2025, 12, 5, 14, 38, 28, 300, DateTimeKind.Utc).AddTicks(1695), "Home delivery by InPost courier", 150.00m, true, 2, 1, "InPost Courier", null, null, 1, null, new DateTime(2025, 12, 5, 14, 38, 28, 300, DateTimeKind.Utc).AddTicks(1696) },
                    { 3, 29.99m, null, new DateTime(2025, 12, 5, 14, 38, 28, 300, DateTimeKind.Utc).AddTicks(1699), "Standard international delivery", null, true, 5, 3, "DHL Standard", null, null, 2, null, new DateTime(2025, 12, 5, 14, 38, 28, 300, DateTimeKind.Utc).AddTicks(1699) },
                    { 4, 49.99m, null, new DateTime(2025, 12, 5, 14, 38, 28, 300, DateTimeKind.Utc).AddTicks(1703), "Express international delivery", null, true, 2, 1, "DHL Express", null, null, 2, null, new DateTime(2025, 12, 5, 14, 38, 28, 300, DateTimeKind.Utc).AddTicks(1703) },
                    { 5, 12.99m, "PL", new DateTime(2025, 12, 5, 14, 38, 28, 300, DateTimeKind.Utc).AddTicks(1707), "Standard postal delivery", 120.00m, true, 5, 3, "Poczta Polska Standard", null, null, 5, null, new DateTime(2025, 12, 5, 14, 38, 28, 300, DateTimeKind.Utc).AddTicks(1708) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 36, 32, 117, DateTimeKind.Utc).AddTicks(4073), new DateTime(2025, 12, 5, 14, 36, 32, 117, DateTimeKind.Utc).AddTicks(4567) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 36, 32, 117, DateTimeKind.Utc).AddTicks(5023), new DateTime(2025, 12, 5, 14, 36, 32, 117, DateTimeKind.Utc).AddTicks(5023) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 36, 32, 117, DateTimeKind.Utc).AddTicks(5027), new DateTime(2025, 12, 5, 14, 36, 32, 117, DateTimeKind.Utc).AddTicks(5027) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 36, 32, 117, DateTimeKind.Utc).AddTicks(5031), new DateTime(2025, 12, 5, 14, 36, 32, 117, DateTimeKind.Utc).AddTicks(5032) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 36, 32, 117, DateTimeKind.Utc).AddTicks(5035), new DateTime(2025, 12, 5, 14, 36, 32, 117, DateTimeKind.Utc).AddTicks(5036) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 36, 32, 121, DateTimeKind.Utc).AddTicks(5076), new DateTime(2025, 12, 5, 14, 36, 32, 121, DateTimeKind.Utc).AddTicks(5515) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 36, 32, 121, DateTimeKind.Utc).AddTicks(6008), new DateTime(2025, 12, 5, 14, 36, 32, 121, DateTimeKind.Utc).AddTicks(6008) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 36, 32, 120, DateTimeKind.Utc).AddTicks(3433), new DateTime(2025, 12, 5, 14, 36, 32, 118, DateTimeKind.Utc).AddTicks(4194), new DateTime(2025, 12, 5, 14, 36, 32, 120, DateTimeKind.Utc).AddTicks(4015) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 136, DateTimeKind.Utc).AddTicks(4280));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 136, DateTimeKind.Utc).AddTicks(4742));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 36, 32, 135, DateTimeKind.Utc).AddTicks(2935), new DateTime(2025, 12, 5, 14, 36, 32, 135, DateTimeKind.Utc).AddTicks(2430) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 115, DateTimeKind.Utc).AddTicks(442));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 115, DateTimeKind.Utc).AddTicks(1015));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 115, DateTimeKind.Utc).AddTicks(1022));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 115, DateTimeKind.Utc).AddTicks(1026));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 115, DateTimeKind.Utc).AddTicks(1788));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 115, DateTimeKind.Utc).AddTicks(1798));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 115, DateTimeKind.Utc).AddTicks(1804));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 115, DateTimeKind.Utc).AddTicks(1807));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 115, DateTimeKind.Utc).AddTicks(1812));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 115, DateTimeKind.Utc).AddTicks(1816));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 115, DateTimeKind.Utc).AddTicks(1820));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 115, DateTimeKind.Utc).AddTicks(1824));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 112, DateTimeKind.Utc).AddTicks(3804));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 112, DateTimeKind.Utc).AddTicks(4339));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 112, DateTimeKind.Utc).AddTicks(4342));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 112, DateTimeKind.Utc).AddTicks(4345));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 112, DateTimeKind.Utc).AddTicks(4348));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 112, DateTimeKind.Utc).AddTicks(4351));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 112, DateTimeKind.Utc).AddTicks(4395));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 112, DateTimeKind.Utc).AddTicks(4398));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 36, 32, 127, DateTimeKind.Utc).AddTicks(3215), new DateTime(2025, 12, 5, 14, 36, 32, 127, DateTimeKind.Utc).AddTicks(228), new DateTime(2026, 6, 5, 14, 36, 32, 127, DateTimeKind.Utc).AddTicks(791) });

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 128, DateTimeKind.Utc).AddTicks(8088));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7253));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7638));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7642));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7646));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7649));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7665));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7669));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7672));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7677));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7681));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7685));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7688));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7691));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7695));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7698));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7701));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7706));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7747));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7751));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7757));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7761));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7764));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7767));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 133, DateTimeKind.Utc).AddTicks(757));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 133, DateTimeKind.Utc).AddTicks(4700));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 133, DateTimeKind.Utc).AddTicks(4708));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 133, DateTimeKind.Utc).AddTicks(4712));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 133, DateTimeKind.Utc).AddTicks(4715));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 133, DateTimeKind.Utc).AddTicks(4739));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 133, DateTimeKind.Utc).AddTicks(4742));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 133, DateTimeKind.Utc).AddTicks(4745));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 133, DateTimeKind.Utc).AddTicks(4747));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 133, DateTimeKind.Utc).AddTicks(4752));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 133, DateTimeKind.Utc).AddTicks(4766));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 133, DateTimeKind.Utc).AddTicks(4769));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 133, DateTimeKind.Utc).AddTicks(4772));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 133, DateTimeKind.Utc).AddTicks(4774));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 133, DateTimeKind.Utc).AddTicks(4777));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 130, DateTimeKind.Utc).AddTicks(5701));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 130, DateTimeKind.Utc).AddTicks(6303));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 130, DateTimeKind.Utc).AddTicks(6310));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 122, DateTimeKind.Utc).AddTicks(6538));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 122, DateTimeKind.Utc).AddTicks(7023));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 122, DateTimeKind.Utc).AddTicks(7025));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 122, DateTimeKind.Utc).AddTicks(7027));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 122, DateTimeKind.Utc).AddTicks(7029));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 122, DateTimeKind.Utc).AddTicks(7031));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 122, DateTimeKind.Utc).AddTicks(7033));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 122, DateTimeKind.Utc).AddTicks(7035));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 122, DateTimeKind.Utc).AddTicks(7037));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 122, DateTimeKind.Utc).AddTicks(7039));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 122, DateTimeKind.Utc).AddTicks(7041));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 110, DateTimeKind.Utc).AddTicks(1135));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 110, DateTimeKind.Utc).AddTicks(1700));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 110, DateTimeKind.Utc).AddTicks(1703));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 110, DateTimeKind.Utc).AddTicks(1706));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 110, DateTimeKind.Utc).AddTicks(1709));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 110, DateTimeKind.Utc).AddTicks(1711));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 116, DateTimeKind.Utc).AddTicks(1897));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 116, DateTimeKind.Utc).AddTicks(2245));
        }
    }
}
