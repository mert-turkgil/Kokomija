using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kokomija.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProductSlugField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Products",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 778, DateTimeKind.Utc).AddTicks(9977), new DateTime(2026, 1, 8, 23, 40, 38, 779, DateTimeKind.Utc).AddTicks(1072) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 779, DateTimeKind.Utc).AddTicks(1777), new DateTime(2026, 1, 8, 23, 40, 38, 779, DateTimeKind.Utc).AddTicks(1778) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 779, DateTimeKind.Utc).AddTicks(1782), new DateTime(2026, 1, 8, 23, 40, 38, 779, DateTimeKind.Utc).AddTicks(1782) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 779, DateTimeKind.Utc).AddTicks(1786), new DateTime(2026, 1, 8, 23, 40, 38, 779, DateTimeKind.Utc).AddTicks(1787) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 779, DateTimeKind.Utc).AddTicks(1789), new DateTime(2026, 1, 8, 23, 40, 38, 779, DateTimeKind.Utc).AddTicks(1790) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 781, DateTimeKind.Utc).AddTicks(68), new DateTime(2026, 1, 8, 23, 40, 38, 781, DateTimeKind.Utc).AddTicks(390) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 781, DateTimeKind.Utc).AddTicks(700), new DateTime(2026, 1, 8, 23, 40, 38, 781, DateTimeKind.Utc).AddTicks(700) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 780, DateTimeKind.Utc).AddTicks(1007), new DateTime(2026, 1, 8, 23, 40, 38, 779, DateTimeKind.Utc).AddTicks(9437), new DateTime(2026, 1, 8, 23, 40, 38, 780, DateTimeKind.Utc).AddTicks(1331) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 796, DateTimeKind.Utc).AddTicks(4992));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 796, DateTimeKind.Utc).AddTicks(5303));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 795, DateTimeKind.Utc).AddTicks(7233), new DateTime(2026, 1, 8, 23, 40, 38, 795, DateTimeKind.Utc).AddTicks(6800) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 776, DateTimeKind.Utc).AddTicks(2037));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 776, DateTimeKind.Utc).AddTicks(2532));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 776, DateTimeKind.Utc).AddTicks(2538));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 776, DateTimeKind.Utc).AddTicks(2546));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 776, DateTimeKind.Utc).AddTicks(3048));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 776, DateTimeKind.Utc).AddTicks(3058));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 776, DateTimeKind.Utc).AddTicks(3063));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 776, DateTimeKind.Utc).AddTicks(3070));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 776, DateTimeKind.Utc).AddTicks(3074));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 776, DateTimeKind.Utc).AddTicks(3079));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 776, DateTimeKind.Utc).AddTicks(3084));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 776, DateTimeKind.Utc).AddTicks(3091));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 773, DateTimeKind.Utc).AddTicks(8023));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 773, DateTimeKind.Utc).AddTicks(8590));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 773, DateTimeKind.Utc).AddTicks(8593));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 773, DateTimeKind.Utc).AddTicks(8597));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 773, DateTimeKind.Utc).AddTicks(8605));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 773, DateTimeKind.Utc).AddTicks(8609));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 773, DateTimeKind.Utc).AddTicks(8613));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 773, DateTimeKind.Utc).AddTicks(8616));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 788, DateTimeKind.Utc).AddTicks(7274), new DateTime(2026, 1, 8, 23, 40, 38, 788, DateTimeKind.Utc).AddTicks(5072), new DateTime(2026, 7, 8, 23, 40, 38, 788, DateTimeKind.Utc).AddTicks(5474) });

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 789, DateTimeKind.Utc).AddTicks(4862));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(437));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1073));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1080));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1084));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1088));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1104));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1108));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1112));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1119));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1125));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1129));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1137));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1141));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1144));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1148));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1151));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1157));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1163));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1168));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1171));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1175));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1178));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1183));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 792, DateTimeKind.Utc).AddTicks(1186));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 793, DateTimeKind.Utc).AddTicks(8926));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 793, DateTimeKind.Utc).AddTicks(9398));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 793, DateTimeKind.Utc).AddTicks(9406));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 793, DateTimeKind.Utc).AddTicks(9410));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 793, DateTimeKind.Utc).AddTicks(9412));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 793, DateTimeKind.Utc).AddTicks(9433));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 793, DateTimeKind.Utc).AddTicks(9436));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 793, DateTimeKind.Utc).AddTicks(9440));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 793, DateTimeKind.Utc).AddTicks(9442));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 793, DateTimeKind.Utc).AddTicks(9446));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 793, DateTimeKind.Utc).AddTicks(9451));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 793, DateTimeKind.Utc).AddTicks(9460));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 793, DateTimeKind.Utc).AddTicks(9463));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 793, DateTimeKind.Utc).AddTicks(9466));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 793, DateTimeKind.Utc).AddTicks(9468));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Slug" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 790, DateTimeKind.Utc).AddTicks(9472), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Slug" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 790, DateTimeKind.Utc).AddTicks(9933), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Slug" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 790, DateTimeKind.Utc).AddTicks(9938), null });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 783, DateTimeKind.Utc).AddTicks(1257), new DateTime(2026, 1, 8, 23, 40, 38, 783, DateTimeKind.Utc).AddTicks(1793) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 783, DateTimeKind.Utc).AddTicks(2626), new DateTime(2026, 1, 8, 23, 40, 38, 783, DateTimeKind.Utc).AddTicks(2627) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 783, DateTimeKind.Utc).AddTicks(2634), new DateTime(2026, 1, 8, 23, 40, 38, 783, DateTimeKind.Utc).AddTicks(2635) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 783, DateTimeKind.Utc).AddTicks(2638), new DateTime(2026, 1, 8, 23, 40, 38, 783, DateTimeKind.Utc).AddTicks(2639) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 783, DateTimeKind.Utc).AddTicks(2642), new DateTime(2026, 1, 8, 23, 40, 38, 783, DateTimeKind.Utc).AddTicks(2642) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 785, DateTimeKind.Utc).AddTicks(6578), new DateTime(2026, 1, 8, 23, 40, 38, 785, DateTimeKind.Utc).AddTicks(6891) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 785, DateTimeKind.Utc).AddTicks(7193), new DateTime(2026, 1, 8, 23, 40, 38, 785, DateTimeKind.Utc).AddTicks(7193) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 785, DateTimeKind.Utc).AddTicks(7196), new DateTime(2026, 1, 8, 23, 40, 38, 785, DateTimeKind.Utc).AddTicks(7196) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 785, DateTimeKind.Utc).AddTicks(7199), new DateTime(2026, 1, 8, 23, 40, 38, 785, DateTimeKind.Utc).AddTicks(7200) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 785, DateTimeKind.Utc).AddTicks(7203), new DateTime(2026, 1, 8, 23, 40, 38, 785, DateTimeKind.Utc).AddTicks(7204) });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 782, DateTimeKind.Utc).AddTicks(771));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 782, DateTimeKind.Utc).AddTicks(1094));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 782, DateTimeKind.Utc).AddTicks(1096));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 782, DateTimeKind.Utc).AddTicks(1137));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 782, DateTimeKind.Utc).AddTicks(1140));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 782, DateTimeKind.Utc).AddTicks(1142));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 782, DateTimeKind.Utc).AddTicks(1144));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 782, DateTimeKind.Utc).AddTicks(1146));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 782, DateTimeKind.Utc).AddTicks(1148));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 782, DateTimeKind.Utc).AddTicks(1150));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 782, DateTimeKind.Utc).AddTicks(1152));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 771, DateTimeKind.Utc).AddTicks(8724));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 771, DateTimeKind.Utc).AddTicks(9049));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 771, DateTimeKind.Utc).AddTicks(9051));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 771, DateTimeKind.Utc).AddTicks(9053));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 771, DateTimeKind.Utc).AddTicks(9056));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 771, DateTimeKind.Utc).AddTicks(9058));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 777, DateTimeKind.Utc).AddTicks(2932));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 8, 23, 40, 38, 777, DateTimeKind.Utc).AddTicks(3403));

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 786, DateTimeKind.Utc).AddTicks(7294), new DateTime(2026, 1, 8, 23, 40, 38, 786, DateTimeKind.Utc).AddTicks(7762) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 786, DateTimeKind.Utc).AddTicks(8204), new DateTime(2026, 1, 8, 23, 40, 38, 786, DateTimeKind.Utc).AddTicks(8205) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 8, 23, 40, 38, 786, DateTimeKind.Utc).AddTicks(8209), new DateTime(2026, 1, 8, 23, 40, 38, 786, DateTimeKind.Utc).AddTicks(8210) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Products");

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
    }
}
