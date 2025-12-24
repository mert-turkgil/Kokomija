using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kokomija.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStripePayoutIdToDeveloperEarnings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StripePayoutId",
                table: "DeveloperEarnings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 16, 55, 29, 282, DateTimeKind.Utc).AddTicks(9599), new DateTime(2025, 12, 24, 16, 55, 29, 283, DateTimeKind.Utc).AddTicks(20) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 16, 55, 29, 283, DateTimeKind.Utc).AddTicks(447), new DateTime(2025, 12, 24, 16, 55, 29, 283, DateTimeKind.Utc).AddTicks(448) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 16, 55, 29, 283, DateTimeKind.Utc).AddTicks(451), new DateTime(2025, 12, 24, 16, 55, 29, 283, DateTimeKind.Utc).AddTicks(452) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 16, 55, 29, 283, DateTimeKind.Utc).AddTicks(455), new DateTime(2025, 12, 24, 16, 55, 29, 283, DateTimeKind.Utc).AddTicks(456) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 16, 55, 29, 283, DateTimeKind.Utc).AddTicks(459), new DateTime(2025, 12, 24, 16, 55, 29, 283, DateTimeKind.Utc).AddTicks(460) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 16, 55, 29, 284, DateTimeKind.Utc).AddTicks(8716), new DateTime(2025, 12, 24, 16, 55, 29, 284, DateTimeKind.Utc).AddTicks(9173) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 16, 55, 29, 284, DateTimeKind.Utc).AddTicks(9620), new DateTime(2025, 12, 24, 16, 55, 29, 284, DateTimeKind.Utc).AddTicks(9621) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 16, 55, 29, 283, DateTimeKind.Utc).AddTicks(8488), new DateTime(2025, 12, 24, 16, 55, 29, 283, DateTimeKind.Utc).AddTicks(6949), new DateTime(2025, 12, 24, 16, 55, 29, 283, DateTimeKind.Utc).AddTicks(8922) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 300, DateTimeKind.Utc).AddTicks(214));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 300, DateTimeKind.Utc).AddTicks(625));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 24, 16, 55, 29, 298, DateTimeKind.Utc).AddTicks(9767), new DateTime(2025, 12, 24, 16, 55, 29, 298, DateTimeKind.Utc).AddTicks(9204) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 280, DateTimeKind.Utc).AddTicks(2498));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 280, DateTimeKind.Utc).AddTicks(3128));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 280, DateTimeKind.Utc).AddTicks(3134));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 280, DateTimeKind.Utc).AddTicks(3141));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 280, DateTimeKind.Utc).AddTicks(3674));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 280, DateTimeKind.Utc).AddTicks(3683));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 280, DateTimeKind.Utc).AddTicks(3746));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 280, DateTimeKind.Utc).AddTicks(3750));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 280, DateTimeKind.Utc).AddTicks(3757));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 280, DateTimeKind.Utc).AddTicks(3761));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 280, DateTimeKind.Utc).AddTicks(3765));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 280, DateTimeKind.Utc).AddTicks(3769));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 278, DateTimeKind.Utc).AddTicks(2076));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 278, DateTimeKind.Utc).AddTicks(2578));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 278, DateTimeKind.Utc).AddTicks(2581));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 278, DateTimeKind.Utc).AddTicks(2584));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 278, DateTimeKind.Utc).AddTicks(2587));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 278, DateTimeKind.Utc).AddTicks(2590));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 278, DateTimeKind.Utc).AddTicks(2593));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 278, DateTimeKind.Utc).AddTicks(2597));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2025, 12, 24, 16, 55, 29, 292, DateTimeKind.Utc).AddTicks(2848), new DateTime(2025, 12, 24, 16, 55, 29, 292, DateTimeKind.Utc).AddTicks(298), new DateTime(2026, 6, 24, 16, 55, 29, 292, DateTimeKind.Utc).AddTicks(776) });

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 293, DateTimeKind.Utc).AddTicks(1296));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 295, DateTimeKind.Utc).AddTicks(5178));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 295, DateTimeKind.Utc).AddTicks(5579));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 295, DateTimeKind.Utc).AddTicks(5584));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 295, DateTimeKind.Utc).AddTicks(5588));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 295, DateTimeKind.Utc).AddTicks(5591));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 295, DateTimeKind.Utc).AddTicks(5612));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 295, DateTimeKind.Utc).AddTicks(5615));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 295, DateTimeKind.Utc).AddTicks(5618));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 295, DateTimeKind.Utc).AddTicks(5624));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 295, DateTimeKind.Utc).AddTicks(5629));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 295, DateTimeKind.Utc).AddTicks(5632));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 295, DateTimeKind.Utc).AddTicks(5635));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 295, DateTimeKind.Utc).AddTicks(5638));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 295, DateTimeKind.Utc).AddTicks(5642));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 295, DateTimeKind.Utc).AddTicks(5722));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 295, DateTimeKind.Utc).AddTicks(5725));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 295, DateTimeKind.Utc).AddTicks(5731));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 295, DateTimeKind.Utc).AddTicks(5735));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 295, DateTimeKind.Utc).AddTicks(5739));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 295, DateTimeKind.Utc).AddTicks(5742));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 295, DateTimeKind.Utc).AddTicks(5745));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 295, DateTimeKind.Utc).AddTicks(5748));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 295, DateTimeKind.Utc).AddTicks(5751));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 295, DateTimeKind.Utc).AddTicks(5754));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 297, DateTimeKind.Utc).AddTicks(3303));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 297, DateTimeKind.Utc).AddTicks(5348));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 297, DateTimeKind.Utc).AddTicks(5353));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 297, DateTimeKind.Utc).AddTicks(5359));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 297, DateTimeKind.Utc).AddTicks(5363));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 297, DateTimeKind.Utc).AddTicks(5385));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 297, DateTimeKind.Utc).AddTicks(5391));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 297, DateTimeKind.Utc).AddTicks(5395));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 297, DateTimeKind.Utc).AddTicks(5399));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 297, DateTimeKind.Utc).AddTicks(5405));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 297, DateTimeKind.Utc).AddTicks(5414));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 297, DateTimeKind.Utc).AddTicks(5419));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 297, DateTimeKind.Utc).AddTicks(5424));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 297, DateTimeKind.Utc).AddTicks(5427));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 297, DateTimeKind.Utc).AddTicks(5431));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 294, DateTimeKind.Utc).AddTicks(4907));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 294, DateTimeKind.Utc).AddTicks(5321));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 294, DateTimeKind.Utc).AddTicks(5326));

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 16, 55, 29, 287, DateTimeKind.Utc).AddTicks(6959), new DateTime(2025, 12, 24, 16, 55, 29, 287, DateTimeKind.Utc).AddTicks(7478) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 16, 55, 29, 287, DateTimeKind.Utc).AddTicks(7936), new DateTime(2025, 12, 24, 16, 55, 29, 287, DateTimeKind.Utc).AddTicks(7936) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 16, 55, 29, 287, DateTimeKind.Utc).AddTicks(7940), new DateTime(2025, 12, 24, 16, 55, 29, 287, DateTimeKind.Utc).AddTicks(7941) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 16, 55, 29, 287, DateTimeKind.Utc).AddTicks(7944), new DateTime(2025, 12, 24, 16, 55, 29, 287, DateTimeKind.Utc).AddTicks(7945) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 16, 55, 29, 287, DateTimeKind.Utc).AddTicks(7948), new DateTime(2025, 12, 24, 16, 55, 29, 287, DateTimeKind.Utc).AddTicks(7949) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 16, 55, 29, 289, DateTimeKind.Utc).AddTicks(3851), new DateTime(2025, 12, 24, 16, 55, 29, 289, DateTimeKind.Utc).AddTicks(4270) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 16, 55, 29, 289, DateTimeKind.Utc).AddTicks(4695), new DateTime(2025, 12, 24, 16, 55, 29, 289, DateTimeKind.Utc).AddTicks(4696) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 16, 55, 29, 289, DateTimeKind.Utc).AddTicks(4700), new DateTime(2025, 12, 24, 16, 55, 29, 289, DateTimeKind.Utc).AddTicks(4700) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 16, 55, 29, 289, DateTimeKind.Utc).AddTicks(4760), new DateTime(2025, 12, 24, 16, 55, 29, 289, DateTimeKind.Utc).AddTicks(4761) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 16, 55, 29, 289, DateTimeKind.Utc).AddTicks(4765), new DateTime(2025, 12, 24, 16, 55, 29, 289, DateTimeKind.Utc).AddTicks(4765) });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 286, DateTimeKind.Utc).AddTicks(80));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 286, DateTimeKind.Utc).AddTicks(411));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 286, DateTimeKind.Utc).AddTicks(413));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 286, DateTimeKind.Utc).AddTicks(416));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 286, DateTimeKind.Utc).AddTicks(418));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 286, DateTimeKind.Utc).AddTicks(420));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 286, DateTimeKind.Utc).AddTicks(422));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 286, DateTimeKind.Utc).AddTicks(424));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 286, DateTimeKind.Utc).AddTicks(426));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 286, DateTimeKind.Utc).AddTicks(428));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 286, DateTimeKind.Utc).AddTicks(430));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 275, DateTimeKind.Utc).AddTicks(3495));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 275, DateTimeKind.Utc).AddTicks(3844));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 275, DateTimeKind.Utc).AddTicks(3846));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 275, DateTimeKind.Utc).AddTicks(3848));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 275, DateTimeKind.Utc).AddTicks(3851));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 275, DateTimeKind.Utc).AddTicks(3853));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 281, DateTimeKind.Utc).AddTicks(8504));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 24, 16, 55, 29, 281, DateTimeKind.Utc).AddTicks(8954));

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 16, 55, 29, 290, DateTimeKind.Utc).AddTicks(4416), new DateTime(2025, 12, 24, 16, 55, 29, 290, DateTimeKind.Utc).AddTicks(4910) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 16, 55, 29, 290, DateTimeKind.Utc).AddTicks(5457), new DateTime(2025, 12, 24, 16, 55, 29, 290, DateTimeKind.Utc).AddTicks(5458) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 24, 16, 55, 29, 290, DateTimeKind.Utc).AddTicks(5462), new DateTime(2025, 12, 24, 16, 55, 29, 290, DateTimeKind.Utc).AddTicks(5462) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StripePayoutId",
                table: "DeveloperEarnings");

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
    }
}
