using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kokomija.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserBirthday : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 20, 6, 32, 356, DateTimeKind.Utc).AddTicks(2595), new DateTime(2026, 1, 8, 20, 6, 32, 356, DateTimeKind.Utc).AddTicks(3182) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 20, 6, 32, 356, DateTimeKind.Utc).AddTicks(3712), new DateTime(2026, 1, 8, 20, 6, 32, 356, DateTimeKind.Utc).AddTicks(3713) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 20, 6, 32, 356, DateTimeKind.Utc).AddTicks(3716), new DateTime(2026, 1, 8, 20, 6, 32, 356, DateTimeKind.Utc).AddTicks(3717) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 20, 6, 32, 356, DateTimeKind.Utc).AddTicks(3724), new DateTime(2026, 1, 8, 20, 6, 32, 356, DateTimeKind.Utc).AddTicks(3724) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 20, 6, 32, 356, DateTimeKind.Utc).AddTicks(3730), new DateTime(2026, 1, 8, 20, 6, 32, 356, DateTimeKind.Utc).AddTicks(3730) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 20, 6, 32, 359, DateTimeKind.Utc).AddTicks(9838), new DateTime(2026, 1, 8, 20, 6, 32, 360, DateTimeKind.Utc).AddTicks(350) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 20, 6, 32, 360, DateTimeKind.Utc).AddTicks(2026), new DateTime(2026, 1, 8, 20, 6, 32, 360, DateTimeKind.Utc).AddTicks(2027) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 20, 6, 32, 358, DateTimeKind.Utc).AddTicks(7456), new DateTime(2026, 1, 8, 20, 6, 32, 358, DateTimeKind.Utc).AddTicks(1101), new DateTime(2026, 1, 8, 20, 6, 32, 358, DateTimeKind.Utc).AddTicks(8017) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 378, DateTimeKind.Utc).AddTicks(6468));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 378, DateTimeKind.Utc).AddTicks(7109));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 8, 20, 6, 32, 377, DateTimeKind.Utc).AddTicks(5419), new DateTime(2026, 1, 8, 20, 6, 32, 377, DateTimeKind.Utc).AddTicks(5050) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 351, DateTimeKind.Utc).AddTicks(8466));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 351, DateTimeKind.Utc).AddTicks(9119));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 351, DateTimeKind.Utc).AddTicks(9123));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 351, DateTimeKind.Utc).AddTicks(9127));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 351, DateTimeKind.Utc).AddTicks(9659));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 351, DateTimeKind.Utc).AddTicks(9667));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 351, DateTimeKind.Utc).AddTicks(9671));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 351, DateTimeKind.Utc).AddTicks(9675));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 351, DateTimeKind.Utc).AddTicks(9679));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 351, DateTimeKind.Utc).AddTicks(9683));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 351, DateTimeKind.Utc).AddTicks(9687));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 351, DateTimeKind.Utc).AddTicks(9695));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 348, DateTimeKind.Utc).AddTicks(6278));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 348, DateTimeKind.Utc).AddTicks(7031));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 348, DateTimeKind.Utc).AddTicks(7035));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 348, DateTimeKind.Utc).AddTicks(7038));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 348, DateTimeKind.Utc).AddTicks(7041));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 348, DateTimeKind.Utc).AddTicks(7044));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 348, DateTimeKind.Utc).AddTicks(7046));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 348, DateTimeKind.Utc).AddTicks(7049));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2026, 1, 8, 20, 6, 32, 369, DateTimeKind.Utc).AddTicks(8808), new DateTime(2026, 1, 8, 20, 6, 32, 369, DateTimeKind.Utc).AddTicks(6684), new DateTime(2026, 7, 8, 20, 6, 32, 369, DateTimeKind.Utc).AddTicks(7270) });

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 370, DateTimeKind.Utc).AddTicks(5070));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 374, DateTimeKind.Utc).AddTicks(8914));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 374, DateTimeKind.Utc).AddTicks(9344));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 374, DateTimeKind.Utc).AddTicks(9349));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 374, DateTimeKind.Utc).AddTicks(9353));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 374, DateTimeKind.Utc).AddTicks(9357));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 374, DateTimeKind.Utc).AddTicks(9375));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 374, DateTimeKind.Utc).AddTicks(9379));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 374, DateTimeKind.Utc).AddTicks(9397));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 374, DateTimeKind.Utc).AddTicks(9424));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 374, DateTimeKind.Utc).AddTicks(9431));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 374, DateTimeKind.Utc).AddTicks(9435));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 374, DateTimeKind.Utc).AddTicks(9439));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 374, DateTimeKind.Utc).AddTicks(9443));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 374, DateTimeKind.Utc).AddTicks(9453));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 374, DateTimeKind.Utc).AddTicks(9462));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 374, DateTimeKind.Utc).AddTicks(9466));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 374, DateTimeKind.Utc).AddTicks(9472));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 374, DateTimeKind.Utc).AddTicks(9478));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 374, DateTimeKind.Utc).AddTicks(9482));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 374, DateTimeKind.Utc).AddTicks(9486));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 374, DateTimeKind.Utc).AddTicks(9490));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 374, DateTimeKind.Utc).AddTicks(9494));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 374, DateTimeKind.Utc).AddTicks(9498));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 374, DateTimeKind.Utc).AddTicks(9502));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 376, DateTimeKind.Utc).AddTicks(4580));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 376, DateTimeKind.Utc).AddTicks(5135));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 376, DateTimeKind.Utc).AddTicks(5139));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 376, DateTimeKind.Utc).AddTicks(5142));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 376, DateTimeKind.Utc).AddTicks(5145));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 376, DateTimeKind.Utc).AddTicks(5165));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 376, DateTimeKind.Utc).AddTicks(5170));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 376, DateTimeKind.Utc).AddTicks(5173));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 376, DateTimeKind.Utc).AddTicks(5176));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 376, DateTimeKind.Utc).AddTicks(5181));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 376, DateTimeKind.Utc).AddTicks(5186));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 376, DateTimeKind.Utc).AddTicks(5190));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 376, DateTimeKind.Utc).AddTicks(5193));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 376, DateTimeKind.Utc).AddTicks(5196));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 376, DateTimeKind.Utc).AddTicks(5199));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 373, DateTimeKind.Utc).AddTicks(5514));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 373, DateTimeKind.Utc).AddTicks(6688));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 373, DateTimeKind.Utc).AddTicks(6694));

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 20, 6, 32, 363, DateTimeKind.Utc).AddTicks(2468), new DateTime(2026, 1, 8, 20, 6, 32, 363, DateTimeKind.Utc).AddTicks(3177) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 20, 6, 32, 363, DateTimeKind.Utc).AddTicks(5734), new DateTime(2026, 1, 8, 20, 6, 32, 363, DateTimeKind.Utc).AddTicks(5735) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 20, 6, 32, 363, DateTimeKind.Utc).AddTicks(5738), new DateTime(2026, 1, 8, 20, 6, 32, 363, DateTimeKind.Utc).AddTicks(5739) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 20, 6, 32, 363, DateTimeKind.Utc).AddTicks(5743), new DateTime(2026, 1, 8, 20, 6, 32, 363, DateTimeKind.Utc).AddTicks(5744) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 20, 6, 32, 363, DateTimeKind.Utc).AddTicks(5749), new DateTime(2026, 1, 8, 20, 6, 32, 363, DateTimeKind.Utc).AddTicks(5749) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 20, 6, 32, 365, DateTimeKind.Utc).AddTicks(9234), new DateTime(2026, 1, 8, 20, 6, 32, 365, DateTimeKind.Utc).AddTicks(9579) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 20, 6, 32, 365, DateTimeKind.Utc).AddTicks(9926), new DateTime(2026, 1, 8, 20, 6, 32, 365, DateTimeKind.Utc).AddTicks(9926) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 20, 6, 32, 365, DateTimeKind.Utc).AddTicks(9930), new DateTime(2026, 1, 8, 20, 6, 32, 365, DateTimeKind.Utc).AddTicks(9930) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 20, 6, 32, 365, DateTimeKind.Utc).AddTicks(9935), new DateTime(2026, 1, 8, 20, 6, 32, 365, DateTimeKind.Utc).AddTicks(9936) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 20, 6, 32, 365, DateTimeKind.Utc).AddTicks(9940), new DateTime(2026, 1, 8, 20, 6, 32, 365, DateTimeKind.Utc).AddTicks(9940) });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 361, DateTimeKind.Utc).AddTicks(5236));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 361, DateTimeKind.Utc).AddTicks(5629));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 361, DateTimeKind.Utc).AddTicks(5632));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 361, DateTimeKind.Utc).AddTicks(5634));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 361, DateTimeKind.Utc).AddTicks(5636));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 361, DateTimeKind.Utc).AddTicks(5638));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 361, DateTimeKind.Utc).AddTicks(5640));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 361, DateTimeKind.Utc).AddTicks(5643));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 361, DateTimeKind.Utc).AddTicks(5645));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 361, DateTimeKind.Utc).AddTicks(5647));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 361, DateTimeKind.Utc).AddTicks(5649));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 345, DateTimeKind.Utc).AddTicks(2522));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 345, DateTimeKind.Utc).AddTicks(5130));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 345, DateTimeKind.Utc).AddTicks(5133));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 345, DateTimeKind.Utc).AddTicks(5135));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 345, DateTimeKind.Utc).AddTicks(5138));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 345, DateTimeKind.Utc).AddTicks(5141));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 354, DateTimeKind.Utc).AddTicks(1796));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 20, 6, 32, 354, DateTimeKind.Utc).AddTicks(2416));

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 20, 6, 32, 367, DateTimeKind.Utc).AddTicks(3505), new DateTime(2026, 1, 8, 20, 6, 32, 367, DateTimeKind.Utc).AddTicks(6459) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 20, 6, 32, 367, DateTimeKind.Utc).AddTicks(7519), new DateTime(2026, 1, 8, 20, 6, 32, 367, DateTimeKind.Utc).AddTicks(7520) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 20, 6, 32, 367, DateTimeKind.Utc).AddTicks(7525), new DateTime(2026, 1, 8, 20, 6, 32, 367, DateTimeKind.Utc).AddTicks(7527) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 300, DateTimeKind.Utc).AddTicks(9082), new DateTime(2026, 1, 2, 20, 31, 49, 301, DateTimeKind.Utc).AddTicks(4687) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 301, DateTimeKind.Utc).AddTicks(6066), new DateTime(2026, 1, 2, 20, 31, 49, 301, DateTimeKind.Utc).AddTicks(6067) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 301, DateTimeKind.Utc).AddTicks(6071), new DateTime(2026, 1, 2, 20, 31, 49, 301, DateTimeKind.Utc).AddTicks(6072) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 301, DateTimeKind.Utc).AddTicks(6078), new DateTime(2026, 1, 2, 20, 31, 49, 301, DateTimeKind.Utc).AddTicks(6078) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 301, DateTimeKind.Utc).AddTicks(6082), new DateTime(2026, 1, 2, 20, 31, 49, 301, DateTimeKind.Utc).AddTicks(6083) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 304, DateTimeKind.Utc).AddTicks(7137), new DateTime(2026, 1, 2, 20, 31, 49, 304, DateTimeKind.Utc).AddTicks(9569) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 305, DateTimeKind.Utc).AddTicks(689), new DateTime(2026, 1, 2, 20, 31, 49, 305, DateTimeKind.Utc).AddTicks(690) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 303, DateTimeKind.Utc).AddTicks(4540), new DateTime(2026, 1, 2, 20, 31, 49, 303, DateTimeKind.Utc).AddTicks(1893), new DateTime(2026, 1, 2, 20, 31, 49, 303, DateTimeKind.Utc).AddTicks(5050) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 323, DateTimeKind.Utc).AddTicks(7091));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 323, DateTimeKind.Utc).AddTicks(7414));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 322, DateTimeKind.Utc).AddTicks(9394), new DateTime(2026, 1, 2, 20, 31, 49, 322, DateTimeKind.Utc).AddTicks(9008) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 296, DateTimeKind.Utc).AddTicks(7058));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 296, DateTimeKind.Utc).AddTicks(7661));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 296, DateTimeKind.Utc).AddTicks(7667));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 296, DateTimeKind.Utc).AddTicks(7671));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 296, DateTimeKind.Utc).AddTicks(9640));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 296, DateTimeKind.Utc).AddTicks(9693));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 296, DateTimeKind.Utc).AddTicks(9700));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 296, DateTimeKind.Utc).AddTicks(9710));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 296, DateTimeKind.Utc).AddTicks(9714));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 296, DateTimeKind.Utc).AddTicks(9718));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 296, DateTimeKind.Utc).AddTicks(9722));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 296, DateTimeKind.Utc).AddTicks(9728));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 293, DateTimeKind.Utc).AddTicks(7490));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 293, DateTimeKind.Utc).AddTicks(7820));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 293, DateTimeKind.Utc).AddTicks(7823));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 293, DateTimeKind.Utc).AddTicks(7826));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 293, DateTimeKind.Utc).AddTicks(7860));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 293, DateTimeKind.Utc).AddTicks(7863));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 293, DateTimeKind.Utc).AddTicks(7865));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 293, DateTimeKind.Utc).AddTicks(7868));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 314, DateTimeKind.Utc).AddTicks(606), new DateTime(2026, 1, 2, 20, 31, 49, 313, DateTimeKind.Utc).AddTicks(7980), new DateTime(2026, 7, 2, 20, 31, 49, 313, DateTimeKind.Utc).AddTicks(8484) });

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 316, DateTimeKind.Utc).AddTicks(1354));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(1899));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2303));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2341));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2346));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2350));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2368));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2372));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2376));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2382));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2397));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2401));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2405));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2409));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2412));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2451));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2457));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2463));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2469));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2474));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2478));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2482));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2486));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2490));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2494));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 321, DateTimeKind.Utc).AddTicks(5728));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 321, DateTimeKind.Utc).AddTicks(6239));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 321, DateTimeKind.Utc).AddTicks(6244));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 321, DateTimeKind.Utc).AddTicks(6288));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 321, DateTimeKind.Utc).AddTicks(6292));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 321, DateTimeKind.Utc).AddTicks(6325));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 321, DateTimeKind.Utc).AddTicks(6328));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 321, DateTimeKind.Utc).AddTicks(6331));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 321, DateTimeKind.Utc).AddTicks(6334));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 321, DateTimeKind.Utc).AddTicks(6339));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 321, DateTimeKind.Utc).AddTicks(6345));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 321, DateTimeKind.Utc).AddTicks(6349));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 321, DateTimeKind.Utc).AddTicks(6353));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 321, DateTimeKind.Utc).AddTicks(6357));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 321, DateTimeKind.Utc).AddTicks(6360));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 318, DateTimeKind.Utc).AddTicks(488));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 318, DateTimeKind.Utc).AddTicks(943));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 318, DateTimeKind.Utc).AddTicks(949));

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 308, DateTimeKind.Utc).AddTicks(4535), new DateTime(2026, 1, 2, 20, 31, 49, 308, DateTimeKind.Utc).AddTicks(4869) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 308, DateTimeKind.Utc).AddTicks(5187), new DateTime(2026, 1, 2, 20, 31, 49, 308, DateTimeKind.Utc).AddTicks(5188) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 308, DateTimeKind.Utc).AddTicks(5192), new DateTime(2026, 1, 2, 20, 31, 49, 308, DateTimeKind.Utc).AddTicks(5193) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 308, DateTimeKind.Utc).AddTicks(5197), new DateTime(2026, 1, 2, 20, 31, 49, 308, DateTimeKind.Utc).AddTicks(5197) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 308, DateTimeKind.Utc).AddTicks(5200), new DateTime(2026, 1, 2, 20, 31, 49, 308, DateTimeKind.Utc).AddTicks(5201) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 311, DateTimeKind.Utc).AddTicks(2527), new DateTime(2026, 1, 2, 20, 31, 49, 311, DateTimeKind.Utc).AddTicks(3045) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 311, DateTimeKind.Utc).AddTicks(3545), new DateTime(2026, 1, 2, 20, 31, 49, 311, DateTimeKind.Utc).AddTicks(3546) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 311, DateTimeKind.Utc).AddTicks(3550), new DateTime(2026, 1, 2, 20, 31, 49, 311, DateTimeKind.Utc).AddTicks(3551) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 311, DateTimeKind.Utc).AddTicks(3555), new DateTime(2026, 1, 2, 20, 31, 49, 311, DateTimeKind.Utc).AddTicks(3556) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 311, DateTimeKind.Utc).AddTicks(3562), new DateTime(2026, 1, 2, 20, 31, 49, 311, DateTimeKind.Utc).AddTicks(3562) });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 307, DateTimeKind.Utc).AddTicks(4618));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 307, DateTimeKind.Utc).AddTicks(4956));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 307, DateTimeKind.Utc).AddTicks(4958));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 307, DateTimeKind.Utc).AddTicks(4960));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 307, DateTimeKind.Utc).AddTicks(4962));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 307, DateTimeKind.Utc).AddTicks(4965));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 307, DateTimeKind.Utc).AddTicks(4967));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 307, DateTimeKind.Utc).AddTicks(4969));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 307, DateTimeKind.Utc).AddTicks(4971));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 307, DateTimeKind.Utc).AddTicks(4973));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 307, DateTimeKind.Utc).AddTicks(4976));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 291, DateTimeKind.Utc).AddTicks(4127));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 291, DateTimeKind.Utc).AddTicks(4598));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 291, DateTimeKind.Utc).AddTicks(4601));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 291, DateTimeKind.Utc).AddTicks(4603));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 291, DateTimeKind.Utc).AddTicks(4606));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 291, DateTimeKind.Utc).AddTicks(4609));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 299, DateTimeKind.Utc).AddTicks(2657));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 299, DateTimeKind.Utc).AddTicks(3445));

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 312, DateTimeKind.Utc).AddTicks(5318), new DateTime(2026, 1, 2, 20, 31, 49, 312, DateTimeKind.Utc).AddTicks(5692) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 312, DateTimeKind.Utc).AddTicks(6119), new DateTime(2026, 1, 2, 20, 31, 49, 312, DateTimeKind.Utc).AddTicks(6120) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 312, DateTimeKind.Utc).AddTicks(6123), new DateTime(2026, 1, 2, 20, 31, 49, 312, DateTimeKind.Utc).AddTicks(6124) });
        }
    }
}
