using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kokomija.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCouponUserProductCategoryRestrictions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductTranslations_ProductId_CultureCode",
                table: "ProductTranslations");

            migrationBuilder.DropIndex(
                name: "IX_ProductTranslations_Slug",
                table: "ProductTranslations");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Coupons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Coupons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Coupons",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 509, DateTimeKind.Utc).AddTicks(5856), new DateTime(2025, 12, 7, 13, 15, 1, 509, DateTimeKind.Utc).AddTicks(6175) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 509, DateTimeKind.Utc).AddTicks(6494), new DateTime(2025, 12, 7, 13, 15, 1, 509, DateTimeKind.Utc).AddTicks(6495) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 509, DateTimeKind.Utc).AddTicks(6498), new DateTime(2025, 12, 7, 13, 15, 1, 509, DateTimeKind.Utc).AddTicks(6499) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 509, DateTimeKind.Utc).AddTicks(6501), new DateTime(2025, 12, 7, 13, 15, 1, 509, DateTimeKind.Utc).AddTicks(6502) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 509, DateTimeKind.Utc).AddTicks(6505), new DateTime(2025, 12, 7, 13, 15, 1, 509, DateTimeKind.Utc).AddTicks(6506) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 511, DateTimeKind.Utc).AddTicks(6155), new DateTime(2025, 12, 7, 13, 15, 1, 511, DateTimeKind.Utc).AddTicks(8876) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 512, DateTimeKind.Utc).AddTicks(123), new DateTime(2025, 12, 7, 13, 15, 1, 512, DateTimeKind.Utc).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 510, DateTimeKind.Utc).AddTicks(2039), new DateTime(2025, 12, 7, 13, 15, 1, 510, DateTimeKind.Utc).AddTicks(587), new DateTime(2025, 12, 7, 13, 15, 1, 510, DateTimeKind.Utc).AddTicks(2357) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 528, DateTimeKind.Utc).AddTicks(9369));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 528, DateTimeKind.Utc).AddTicks(9783));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 525, DateTimeKind.Utc).AddTicks(4840), new DateTime(2025, 12, 7, 13, 15, 1, 525, DateTimeKind.Utc).AddTicks(4465) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 507, DateTimeKind.Utc).AddTicks(9061));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 507, DateTimeKind.Utc).AddTicks(9546));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 507, DateTimeKind.Utc).AddTicks(9550));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 507, DateTimeKind.Utc).AddTicks(9597));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 508, DateTimeKind.Utc).AddTicks(66));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 508, DateTimeKind.Utc).AddTicks(73));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 508, DateTimeKind.Utc).AddTicks(78));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 508, DateTimeKind.Utc).AddTicks(81));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 508, DateTimeKind.Utc).AddTicks(86));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 508, DateTimeKind.Utc).AddTicks(89));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 508, DateTimeKind.Utc).AddTicks(94));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 508, DateTimeKind.Utc).AddTicks(99));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 504, DateTimeKind.Utc).AddTicks(6457));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 504, DateTimeKind.Utc).AddTicks(6915));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 504, DateTimeKind.Utc).AddTicks(6921));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 504, DateTimeKind.Utc).AddTicks(6924));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 504, DateTimeKind.Utc).AddTicks(6927));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 504, DateTimeKind.Utc).AddTicks(6931));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 504, DateTimeKind.Utc).AddTicks(6934));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 504, DateTimeKind.Utc).AddTicks(6937));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "CreatedAt", "ProductId", "UserId", "ValidFrom", "ValidUntil" },
                values: new object[] { null, new DateTime(2025, 12, 7, 13, 15, 1, 519, DateTimeKind.Utc).AddTicks(6935), null, null, new DateTime(2025, 12, 7, 13, 15, 1, 519, DateTimeKind.Utc).AddTicks(4879), new DateTime(2026, 6, 7, 13, 15, 1, 519, DateTimeKind.Utc).AddTicks(5275) });

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 520, DateTimeKind.Utc).AddTicks(2248));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2183));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2612));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2620));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2625));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2629));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2678));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2682));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2686));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2691));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2697));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2701));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2753));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2757));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2761));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2765));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2768));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2775));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2781));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2785));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2789));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2793));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2797));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2800));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2804));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 524, DateTimeKind.Utc).AddTicks(5798));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 524, DateTimeKind.Utc).AddTicks(6287));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 524, DateTimeKind.Utc).AddTicks(6291));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 524, DateTimeKind.Utc).AddTicks(6293));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 524, DateTimeKind.Utc).AddTicks(6296));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 524, DateTimeKind.Utc).AddTicks(6305));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 524, DateTimeKind.Utc).AddTicks(6309));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 524, DateTimeKind.Utc).AddTicks(6312));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 524, DateTimeKind.Utc).AddTicks(6315));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 524, DateTimeKind.Utc).AddTicks(6320));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 524, DateTimeKind.Utc).AddTicks(6326));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 524, DateTimeKind.Utc).AddTicks(6329));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 524, DateTimeKind.Utc).AddTicks(6333));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 524, DateTimeKind.Utc).AddTicks(6336));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 524, DateTimeKind.Utc).AddTicks(6339));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 522, DateTimeKind.Utc).AddTicks(822));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 522, DateTimeKind.Utc).AddTicks(1437));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 522, DateTimeKind.Utc).AddTicks(1444));

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 514, DateTimeKind.Utc).AddTicks(1199), new DateTime(2025, 12, 7, 13, 15, 1, 514, DateTimeKind.Utc).AddTicks(1517) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 514, DateTimeKind.Utc).AddTicks(1865), new DateTime(2025, 12, 7, 13, 15, 1, 514, DateTimeKind.Utc).AddTicks(1865) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 514, DateTimeKind.Utc).AddTicks(1869), new DateTime(2025, 12, 7, 13, 15, 1, 514, DateTimeKind.Utc).AddTicks(1869) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 514, DateTimeKind.Utc).AddTicks(1872), new DateTime(2025, 12, 7, 13, 15, 1, 514, DateTimeKind.Utc).AddTicks(1873) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 514, DateTimeKind.Utc).AddTicks(1876), new DateTime(2025, 12, 7, 13, 15, 1, 514, DateTimeKind.Utc).AddTicks(1876) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 515, DateTimeKind.Utc).AddTicks(4474), new DateTime(2025, 12, 7, 13, 15, 1, 515, DateTimeKind.Utc).AddTicks(4841) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 515, DateTimeKind.Utc).AddTicks(5202), new DateTime(2025, 12, 7, 13, 15, 1, 515, DateTimeKind.Utc).AddTicks(5202) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 515, DateTimeKind.Utc).AddTicks(5206), new DateTime(2025, 12, 7, 13, 15, 1, 515, DateTimeKind.Utc).AddTicks(5207) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 515, DateTimeKind.Utc).AddTicks(5210), new DateTime(2025, 12, 7, 13, 15, 1, 515, DateTimeKind.Utc).AddTicks(5211) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 515, DateTimeKind.Utc).AddTicks(5215), new DateTime(2025, 12, 7, 13, 15, 1, 515, DateTimeKind.Utc).AddTicks(5216) });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 513, DateTimeKind.Utc).AddTicks(1192));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 513, DateTimeKind.Utc).AddTicks(1545));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 513, DateTimeKind.Utc).AddTicks(1548));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 513, DateTimeKind.Utc).AddTicks(1551));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 513, DateTimeKind.Utc).AddTicks(1553));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 513, DateTimeKind.Utc).AddTicks(1555));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 513, DateTimeKind.Utc).AddTicks(1557));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 513, DateTimeKind.Utc).AddTicks(1559));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 513, DateTimeKind.Utc).AddTicks(1561));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 513, DateTimeKind.Utc).AddTicks(1563));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 513, DateTimeKind.Utc).AddTicks(1565));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 502, DateTimeKind.Utc).AddTicks(4420));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 502, DateTimeKind.Utc).AddTicks(5198));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 502, DateTimeKind.Utc).AddTicks(5200));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 502, DateTimeKind.Utc).AddTicks(5203));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 502, DateTimeKind.Utc).AddTicks(5206));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 502, DateTimeKind.Utc).AddTicks(5208));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 508, DateTimeKind.Utc).AddTicks(8013));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 508, DateTimeKind.Utc).AddTicks(8341));

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 518, DateTimeKind.Utc).AddTicks(2590), new DateTime(2025, 12, 7, 13, 15, 1, 518, DateTimeKind.Utc).AddTicks(2964) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 518, DateTimeKind.Utc).AddTicks(3359), new DateTime(2025, 12, 7, 13, 15, 1, 518, DateTimeKind.Utc).AddTicks(3359) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 518, DateTimeKind.Utc).AddTicks(3363), new DateTime(2025, 12, 7, 13, 15, 1, 518, DateTimeKind.Utc).AddTicks(3364) });

            migrationBuilder.CreateIndex(
                name: "IX_ProductTranslations_ProductId",
                table: "ProductTranslations",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_CategoryId",
                table: "Coupons",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_ProductId",
                table: "Coupons",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_UserId",
                table: "Coupons",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coupons_AspNetUsers_UserId",
                table: "Coupons",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Coupons_Categories_CategoryId",
                table: "Coupons",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Coupons_Products_ProductId",
                table: "Coupons",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coupons_AspNetUsers_UserId",
                table: "Coupons");

            migrationBuilder.DropForeignKey(
                name: "FK_Coupons_Categories_CategoryId",
                table: "Coupons");

            migrationBuilder.DropForeignKey(
                name: "FK_Coupons_Products_ProductId",
                table: "Coupons");

            migrationBuilder.DropIndex(
                name: "IX_ProductTranslations_ProductId",
                table: "ProductTranslations");

            migrationBuilder.DropIndex(
                name: "IX_Coupons_CategoryId",
                table: "Coupons");

            migrationBuilder.DropIndex(
                name: "IX_Coupons_ProductId",
                table: "Coupons");

            migrationBuilder.DropIndex(
                name: "IX_Coupons_UserId",
                table: "Coupons");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Coupons");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Coupons");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Coupons");

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 14, 53, 16, 871, DateTimeKind.Utc).AddTicks(4729), new DateTime(2025, 12, 6, 14, 53, 16, 871, DateTimeKind.Utc).AddTicks(5187) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 14, 53, 16, 871, DateTimeKind.Utc).AddTicks(5638), new DateTime(2025, 12, 6, 14, 53, 16, 871, DateTimeKind.Utc).AddTicks(5638) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 14, 53, 16, 871, DateTimeKind.Utc).AddTicks(5642), new DateTime(2025, 12, 6, 14, 53, 16, 871, DateTimeKind.Utc).AddTicks(5642) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 14, 53, 16, 871, DateTimeKind.Utc).AddTicks(5646), new DateTime(2025, 12, 6, 14, 53, 16, 871, DateTimeKind.Utc).AddTicks(5646) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 14, 53, 16, 871, DateTimeKind.Utc).AddTicks(5649), new DateTime(2025, 12, 6, 14, 53, 16, 871, DateTimeKind.Utc).AddTicks(5650) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 14, 53, 16, 875, DateTimeKind.Utc).AddTicks(3740), new DateTime(2025, 12, 6, 14, 53, 16, 875, DateTimeKind.Utc).AddTicks(4187) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 14, 53, 16, 875, DateTimeKind.Utc).AddTicks(4744), new DateTime(2025, 12, 6, 14, 53, 16, 875, DateTimeKind.Utc).AddTicks(4745) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 14, 53, 16, 872, DateTimeKind.Utc).AddTicks(4726), new DateTime(2025, 12, 6, 14, 53, 16, 872, DateTimeKind.Utc).AddTicks(2585), new DateTime(2025, 12, 6, 14, 53, 16, 872, DateTimeKind.Utc).AddTicks(5183) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 899, DateTimeKind.Utc).AddTicks(7373));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 899, DateTimeKind.Utc).AddTicks(7912));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 6, 14, 53, 16, 896, DateTimeKind.Utc).AddTicks(8826), new DateTime(2025, 12, 6, 14, 53, 16, 896, DateTimeKind.Utc).AddTicks(8263) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 856, DateTimeKind.Utc).AddTicks(2719));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 856, DateTimeKind.Utc).AddTicks(3271));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 856, DateTimeKind.Utc).AddTicks(3275));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 856, DateTimeKind.Utc).AddTicks(3278));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 856, DateTimeKind.Utc).AddTicks(3912));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 856, DateTimeKind.Utc).AddTicks(3924));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 856, DateTimeKind.Utc).AddTicks(3927));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 856, DateTimeKind.Utc).AddTicks(3931));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 856, DateTimeKind.Utc).AddTicks(3935));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 856, DateTimeKind.Utc).AddTicks(3939));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 856, DateTimeKind.Utc).AddTicks(3942));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 856, DateTimeKind.Utc).AddTicks(3945));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 853, DateTimeKind.Utc).AddTicks(3929));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 853, DateTimeKind.Utc).AddTicks(4618));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 853, DateTimeKind.Utc).AddTicks(4632));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 853, DateTimeKind.Utc).AddTicks(4636));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 853, DateTimeKind.Utc).AddTicks(4641));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 853, DateTimeKind.Utc).AddTicks(4645));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 853, DateTimeKind.Utc).AddTicks(4651));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 853, DateTimeKind.Utc).AddTicks(4655));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2025, 12, 6, 14, 53, 16, 884, DateTimeKind.Utc).AddTicks(9968), new DateTime(2025, 12, 6, 14, 53, 16, 884, DateTimeKind.Utc).AddTicks(7196), new DateTime(2026, 6, 6, 14, 53, 16, 884, DateTimeKind.Utc).AddTicks(7720) });

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 885, DateTimeKind.Utc).AddTicks(6232));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 893, DateTimeKind.Utc).AddTicks(5414));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 893, DateTimeKind.Utc).AddTicks(9434));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 893, DateTimeKind.Utc).AddTicks(9444));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 893, DateTimeKind.Utc).AddTicks(9447));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 893, DateTimeKind.Utc).AddTicks(9450));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 893, DateTimeKind.Utc).AddTicks(9473));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 893, DateTimeKind.Utc).AddTicks(9477));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 893, DateTimeKind.Utc).AddTicks(9480));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 893, DateTimeKind.Utc).AddTicks(9487));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 893, DateTimeKind.Utc).AddTicks(9549));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 893, DateTimeKind.Utc).AddTicks(9553));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 893, DateTimeKind.Utc).AddTicks(9556));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 893, DateTimeKind.Utc).AddTicks(9560));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 893, DateTimeKind.Utc).AddTicks(9563));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 893, DateTimeKind.Utc).AddTicks(9567));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 893, DateTimeKind.Utc).AddTicks(9571));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 893, DateTimeKind.Utc).AddTicks(9577));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 893, DateTimeKind.Utc).AddTicks(9584));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 893, DateTimeKind.Utc).AddTicks(9588));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 893, DateTimeKind.Utc).AddTicks(9592));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 893, DateTimeKind.Utc).AddTicks(9596));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 893, DateTimeKind.Utc).AddTicks(9605));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 893, DateTimeKind.Utc).AddTicks(9609));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 893, DateTimeKind.Utc).AddTicks(9612));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 895, DateTimeKind.Utc).AddTicks(7125));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 895, DateTimeKind.Utc).AddTicks(7509));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 895, DateTimeKind.Utc).AddTicks(7512));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 895, DateTimeKind.Utc).AddTicks(7515));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 895, DateTimeKind.Utc).AddTicks(7517));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 895, DateTimeKind.Utc).AddTicks(7533));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 895, DateTimeKind.Utc).AddTicks(7536));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 895, DateTimeKind.Utc).AddTicks(7539));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 895, DateTimeKind.Utc).AddTicks(7541));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 895, DateTimeKind.Utc).AddTicks(7545));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 895, DateTimeKind.Utc).AddTicks(7550));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 895, DateTimeKind.Utc).AddTicks(7552));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 895, DateTimeKind.Utc).AddTicks(7555));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 895, DateTimeKind.Utc).AddTicks(7557));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 895, DateTimeKind.Utc).AddTicks(7560));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 886, DateTimeKind.Utc).AddTicks(7302));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 886, DateTimeKind.Utc).AddTicks(7707));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 886, DateTimeKind.Utc).AddTicks(7711));

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 14, 53, 16, 878, DateTimeKind.Utc).AddTicks(7142), new DateTime(2025, 12, 6, 14, 53, 16, 878, DateTimeKind.Utc).AddTicks(8098) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 14, 53, 16, 878, DateTimeKind.Utc).AddTicks(8899), new DateTime(2025, 12, 6, 14, 53, 16, 878, DateTimeKind.Utc).AddTicks(8906) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 14, 53, 16, 878, DateTimeKind.Utc).AddTicks(8917), new DateTime(2025, 12, 6, 14, 53, 16, 878, DateTimeKind.Utc).AddTicks(8919) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 14, 53, 16, 878, DateTimeKind.Utc).AddTicks(8925), new DateTime(2025, 12, 6, 14, 53, 16, 878, DateTimeKind.Utc).AddTicks(8931) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 14, 53, 16, 878, DateTimeKind.Utc).AddTicks(8997), new DateTime(2025, 12, 6, 14, 53, 16, 878, DateTimeKind.Utc).AddTicks(8998) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 14, 53, 16, 880, DateTimeKind.Utc).AddTicks(6980), new DateTime(2025, 12, 6, 14, 53, 16, 880, DateTimeKind.Utc).AddTicks(7429) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 14, 53, 16, 880, DateTimeKind.Utc).AddTicks(7860), new DateTime(2025, 12, 6, 14, 53, 16, 880, DateTimeKind.Utc).AddTicks(7862) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 14, 53, 16, 880, DateTimeKind.Utc).AddTicks(7866), new DateTime(2025, 12, 6, 14, 53, 16, 880, DateTimeKind.Utc).AddTicks(7867) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 14, 53, 16, 880, DateTimeKind.Utc).AddTicks(7871), new DateTime(2025, 12, 6, 14, 53, 16, 880, DateTimeKind.Utc).AddTicks(7872) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 14, 53, 16, 880, DateTimeKind.Utc).AddTicks(7876), new DateTime(2025, 12, 6, 14, 53, 16, 880, DateTimeKind.Utc).AddTicks(7877) });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 876, DateTimeKind.Utc).AddTicks(5304));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 876, DateTimeKind.Utc).AddTicks(5635));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 876, DateTimeKind.Utc).AddTicks(5638));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 876, DateTimeKind.Utc).AddTicks(5640));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 876, DateTimeKind.Utc).AddTicks(5642));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 876, DateTimeKind.Utc).AddTicks(5644));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 876, DateTimeKind.Utc).AddTicks(5646));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 876, DateTimeKind.Utc).AddTicks(5648));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 876, DateTimeKind.Utc).AddTicks(5650));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 876, DateTimeKind.Utc).AddTicks(5652));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 876, DateTimeKind.Utc).AddTicks(5654));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 850, DateTimeKind.Utc).AddTicks(6657));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 850, DateTimeKind.Utc).AddTicks(7204));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 850, DateTimeKind.Utc).AddTicks(7207));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 850, DateTimeKind.Utc).AddTicks(7210));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 850, DateTimeKind.Utc).AddTicks(7214));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 850, DateTimeKind.Utc).AddTicks(7217));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 857, DateTimeKind.Utc).AddTicks(4432));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 6, 14, 53, 16, 857, DateTimeKind.Utc).AddTicks(4902));

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 14, 53, 16, 882, DateTimeKind.Utc).AddTicks(2176), new DateTime(2025, 12, 6, 14, 53, 16, 882, DateTimeKind.Utc).AddTicks(2531) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 14, 53, 16, 882, DateTimeKind.Utc).AddTicks(2851), new DateTime(2025, 12, 6, 14, 53, 16, 882, DateTimeKind.Utc).AddTicks(2852) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 14, 53, 16, 882, DateTimeKind.Utc).AddTicks(2855), new DateTime(2025, 12, 6, 14, 53, 16, 882, DateTimeKind.Utc).AddTicks(2856) });

            migrationBuilder.CreateIndex(
                name: "IX_ProductTranslations_ProductId_CultureCode",
                table: "ProductTranslations",
                columns: new[] { "ProductId", "CultureCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductTranslations_Slug",
                table: "ProductTranslations",
                column: "Slug");
        }
    }
}
