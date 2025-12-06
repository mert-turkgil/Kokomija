using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kokomija.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProductCategoryToBlogCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductCategoryId",
                table: "BlogCategories",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ProductCategoryId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 14, 53, 16, 871, DateTimeKind.Utc).AddTicks(4729), null, new DateTime(2025, 12, 6, 14, 53, 16, 871, DateTimeKind.Utc).AddTicks(5187) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ProductCategoryId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 14, 53, 16, 871, DateTimeKind.Utc).AddTicks(5638), null, new DateTime(2025, 12, 6, 14, 53, 16, 871, DateTimeKind.Utc).AddTicks(5638) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ProductCategoryId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 14, 53, 16, 871, DateTimeKind.Utc).AddTicks(5642), null, new DateTime(2025, 12, 6, 14, 53, 16, 871, DateTimeKind.Utc).AddTicks(5642) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ProductCategoryId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 14, 53, 16, 871, DateTimeKind.Utc).AddTicks(5646), null, new DateTime(2025, 12, 6, 14, 53, 16, 871, DateTimeKind.Utc).AddTicks(5646) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ProductCategoryId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 14, 53, 16, 871, DateTimeKind.Utc).AddTicks(5649), null, new DateTime(2025, 12, 6, 14, 53, 16, 871, DateTimeKind.Utc).AddTicks(5650) });

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
                name: "IX_BlogCategories_ProductCategoryId",
                table: "BlogCategories",
                column: "ProductCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogCategories_Categories_ProductCategoryId",
                table: "BlogCategories",
                column: "ProductCategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogCategories_Categories_ProductCategoryId",
                table: "BlogCategories");

            migrationBuilder.DropIndex(
                name: "IX_BlogCategories_ProductCategoryId",
                table: "BlogCategories");

            migrationBuilder.DropColumn(
                name: "ProductCategoryId",
                table: "BlogCategories");

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

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 38, 28, 298, DateTimeKind.Utc).AddTicks(4432), new DateTime(2025, 12, 5, 14, 38, 28, 298, DateTimeKind.Utc).AddTicks(4737) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 38, 28, 298, DateTimeKind.Utc).AddTicks(5073), new DateTime(2025, 12, 5, 14, 38, 28, 298, DateTimeKind.Utc).AddTicks(5074) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 38, 28, 298, DateTimeKind.Utc).AddTicks(5078), new DateTime(2025, 12, 5, 14, 38, 28, 298, DateTimeKind.Utc).AddTicks(5078) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 38, 28, 298, DateTimeKind.Utc).AddTicks(5114), new DateTime(2025, 12, 5, 14, 38, 28, 298, DateTimeKind.Utc).AddTicks(5114) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 38, 28, 298, DateTimeKind.Utc).AddTicks(5118), new DateTime(2025, 12, 5, 14, 38, 28, 298, DateTimeKind.Utc).AddTicks(5118) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 38, 28, 300, DateTimeKind.Utc).AddTicks(1022), new DateTime(2025, 12, 5, 14, 38, 28, 300, DateTimeKind.Utc).AddTicks(1362) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 38, 28, 300, DateTimeKind.Utc).AddTicks(1695), new DateTime(2025, 12, 5, 14, 38, 28, 300, DateTimeKind.Utc).AddTicks(1696) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 38, 28, 300, DateTimeKind.Utc).AddTicks(1699), new DateTime(2025, 12, 5, 14, 38, 28, 300, DateTimeKind.Utc).AddTicks(1699) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 38, 28, 300, DateTimeKind.Utc).AddTicks(1703), new DateTime(2025, 12, 5, 14, 38, 28, 300, DateTimeKind.Utc).AddTicks(1703) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 38, 28, 300, DateTimeKind.Utc).AddTicks(1707), new DateTime(2025, 12, 5, 14, 38, 28, 300, DateTimeKind.Utc).AddTicks(1708) });

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

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 38, 28, 300, DateTimeKind.Utc).AddTicks(9979), new DateTime(2025, 12, 5, 14, 38, 28, 301, DateTimeKind.Utc).AddTicks(329) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 38, 28, 301, DateTimeKind.Utc).AddTicks(782), new DateTime(2025, 12, 5, 14, 38, 28, 301, DateTimeKind.Utc).AddTicks(782) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 38, 28, 301, DateTimeKind.Utc).AddTicks(785), new DateTime(2025, 12, 5, 14, 38, 28, 301, DateTimeKind.Utc).AddTicks(786) });
        }
    }
}
