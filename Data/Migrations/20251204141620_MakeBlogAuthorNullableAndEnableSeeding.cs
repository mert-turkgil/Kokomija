using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kokomija.Data.Migrations
{
    /// <inheritdoc />
    public partial class MakeBlogAuthorNullableAndEnableSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Blogs",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 4, 14, 16, 16, 665, DateTimeKind.Utc).AddTicks(4198), new DateTime(2025, 12, 4, 14, 16, 16, 665, DateTimeKind.Utc).AddTicks(4556) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 4, 14, 16, 16, 665, DateTimeKind.Utc).AddTicks(4882), new DateTime(2025, 12, 4, 14, 16, 16, 665, DateTimeKind.Utc).AddTicks(4882) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 4, 14, 16, 16, 665, DateTimeKind.Utc).AddTicks(4885), new DateTime(2025, 12, 4, 14, 16, 16, 665, DateTimeKind.Utc).AddTicks(4886) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 4, 14, 16, 16, 665, DateTimeKind.Utc).AddTicks(4888), new DateTime(2025, 12, 4, 14, 16, 16, 665, DateTimeKind.Utc).AddTicks(4889) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 4, 14, 16, 16, 665, DateTimeKind.Utc).AddTicks(4892), new DateTime(2025, 12, 4, 14, 16, 16, 665, DateTimeKind.Utc).AddTicks(4892) });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "AllowComments", "AuthorId", "CategoryId", "CreatedAt", "FeaturedImage", "IsPublished", "ProductId", "PublishedDate", "UpdatedAt" },
                values: new object[] { 1, true, null, 3, new DateTime(2025, 12, 4, 14, 16, 16, 666, DateTimeKind.Utc).AddTicks(1514), "/img/Blog/fashion-trends-2025.jpg", true, null, new DateTime(2025, 12, 4, 14, 16, 16, 666, DateTimeKind.Utc).AddTicks(36), new DateTime(2025, 12, 4, 14, 16, 16, 666, DateTimeKind.Utc).AddTicks(1831) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 680, DateTimeKind.Utc).AddTicks(6911));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 680, DateTimeKind.Utc).AddTicks(7326));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 4, 14, 16, 16, 678, DateTimeKind.Utc).AddTicks(2046), new DateTime(2025, 12, 4, 14, 16, 16, 678, DateTimeKind.Utc).AddTicks(1459) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 662, DateTimeKind.Utc).AddTicks(8123));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 662, DateTimeKind.Utc).AddTicks(8464));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 662, DateTimeKind.Utc).AddTicks(8468));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 662, DateTimeKind.Utc).AddTicks(8471));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 662, DateTimeKind.Utc).AddTicks(8803));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 662, DateTimeKind.Utc).AddTicks(8810));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 662, DateTimeKind.Utc).AddTicks(8813));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 662, DateTimeKind.Utc).AddTicks(8816));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 662, DateTimeKind.Utc).AddTicks(8819));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 662, DateTimeKind.Utc).AddTicks(8823));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 662, DateTimeKind.Utc).AddTicks(8826));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 662, DateTimeKind.Utc).AddTicks(8829));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 661, DateTimeKind.Utc).AddTicks(3996));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 661, DateTimeKind.Utc).AddTicks(4334));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 661, DateTimeKind.Utc).AddTicks(4337));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 661, DateTimeKind.Utc).AddTicks(4340));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 661, DateTimeKind.Utc).AddTicks(4342));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 661, DateTimeKind.Utc).AddTicks(4345));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 661, DateTimeKind.Utc).AddTicks(4347));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 661, DateTimeKind.Utc).AddTicks(4350));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2025, 12, 4, 14, 16, 16, 670, DateTimeKind.Utc).AddTicks(2381), new DateTime(2025, 12, 4, 14, 16, 16, 669, DateTimeKind.Utc).AddTicks(9207), new DateTime(2026, 6, 4, 14, 16, 16, 669, DateTimeKind.Utc).AddTicks(9598) });

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 670, DateTimeKind.Utc).AddTicks(9756));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 674, DateTimeKind.Utc).AddTicks(9481));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 674, DateTimeKind.Utc).AddTicks(9960));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 674, DateTimeKind.Utc).AddTicks(9964));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 674, DateTimeKind.Utc).AddTicks(9967));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 674, DateTimeKind.Utc).AddTicks(9970));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 674, DateTimeKind.Utc).AddTicks(9985));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 674, DateTimeKind.Utc).AddTicks(9988));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 675, DateTimeKind.Utc).AddTicks(131));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 675, DateTimeKind.Utc).AddTicks(137));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 675, DateTimeKind.Utc).AddTicks(142));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 675, DateTimeKind.Utc).AddTicks(145));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 675, DateTimeKind.Utc).AddTicks(148));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 675, DateTimeKind.Utc).AddTicks(151));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 675, DateTimeKind.Utc).AddTicks(154));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 675, DateTimeKind.Utc).AddTicks(157));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 675, DateTimeKind.Utc).AddTicks(160));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 675, DateTimeKind.Utc).AddTicks(167));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 675, DateTimeKind.Utc).AddTicks(171));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 675, DateTimeKind.Utc).AddTicks(175));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 675, DateTimeKind.Utc).AddTicks(178));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 675, DateTimeKind.Utc).AddTicks(181));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 675, DateTimeKind.Utc).AddTicks(184));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 675, DateTimeKind.Utc).AddTicks(187));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 675, DateTimeKind.Utc).AddTicks(190));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 676, DateTimeKind.Utc).AddTicks(9214));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 676, DateTimeKind.Utc).AddTicks(9802));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 676, DateTimeKind.Utc).AddTicks(9807));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 676, DateTimeKind.Utc).AddTicks(9810));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 676, DateTimeKind.Utc).AddTicks(9813));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 676, DateTimeKind.Utc).AddTicks(9830));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 676, DateTimeKind.Utc).AddTicks(9835));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 676, DateTimeKind.Utc).AddTicks(9838));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 676, DateTimeKind.Utc).AddTicks(9841));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 676, DateTimeKind.Utc).AddTicks(9847));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 676, DateTimeKind.Utc).AddTicks(9938));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 676, DateTimeKind.Utc).AddTicks(9943));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 676, DateTimeKind.Utc).AddTicks(9946));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 676, DateTimeKind.Utc).AddTicks(9949));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 676, DateTimeKind.Utc).AddTicks(9952));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 672, DateTimeKind.Utc).AddTicks(9256));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 672, DateTimeKind.Utc).AddTicks(9784));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 672, DateTimeKind.Utc).AddTicks(9790));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 667, DateTimeKind.Utc).AddTicks(9892));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 668, DateTimeKind.Utc).AddTicks(216));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 668, DateTimeKind.Utc).AddTicks(218));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 668, DateTimeKind.Utc).AddTicks(220));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 668, DateTimeKind.Utc).AddTicks(222));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 668, DateTimeKind.Utc).AddTicks(224));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 668, DateTimeKind.Utc).AddTicks(226));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 668, DateTimeKind.Utc).AddTicks(228));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 668, DateTimeKind.Utc).AddTicks(230));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 668, DateTimeKind.Utc).AddTicks(233));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 668, DateTimeKind.Utc).AddTicks(235));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 659, DateTimeKind.Utc).AddTicks(1784));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 659, DateTimeKind.Utc).AddTicks(2283));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 659, DateTimeKind.Utc).AddTicks(2287));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 659, DateTimeKind.Utc).AddTicks(2292));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 659, DateTimeKind.Utc).AddTicks(2294));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 659, DateTimeKind.Utc).AddTicks(2296));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 663, DateTimeKind.Utc).AddTicks(8361));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 14, 16, 16, 663, DateTimeKind.Utc).AddTicks(8810));

            migrationBuilder.InsertData(
                table: "BlogTranslations",
                columns: new[] { "Id", "BlogId", "Content", "CreatedAt", "CultureCode", "Excerpt", "MetaDescription", "MetaKeywords", "Slug", "Tags", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, "<p>Discover the hottest fashion trends that will dominate 2025. From sustainable fabrics to bold colors, we present everything you need to know to stay stylish.</p><p>This season brings a return to classics with a modern twist - oversized blazers, midi skirts, and minimalist accessories are the must-haves in every wardrobe.</p><p><strong>Key trends:</strong></p><ul><li>Sustainable and eco-friendly materials</li><li>Bold color combinations</li><li>Oversized silhouettes</li><li>Minimalist accessories</li><li>Vintage revival</li></ul><p>Stay tuned for more fashion tips and style inspiration on our blog!</p>", new DateTime(2025, 12, 4, 14, 16, 16, 666, DateTimeKind.Utc).AddTicks(9877), "en-US", "Discover the hottest fashion trends that will dominate 2025. From sustainable fabrics to bold colors.", "Discover the hottest fashion trends for 2025 - sustainable materials, bold colors, and timeless style.", "fashion,trends,2025,style,clothing,sustainable fashion", "fashion-trends-2025", "fashion,trends,2025,style", "Fashion Trends for 2025", new DateTime(2025, 12, 4, 14, 16, 16, 667, DateTimeKind.Utc).AddTicks(196) },
                    { 2, 1, "<p>Odkryj najgorętsze trendy modowe, które zdominują rok 2025. Od zrównoważonych materiałów po odważne kolory, prezentujemy wszystko, co musisz wiedzieć, aby być na czasie.</p><p>Ten sezon przynosi powrót do klasyki z nowoczesnym akcentem - oversize'owe marynarki, midi spódnice i minimalistyczna biżuteria to must-have w każdej garderobie.</p><p><strong>Kluczowe trendy:</strong></p><ul><li>Zrównoważone i ekologiczne materiały</li><li>Odważne kombinacje kolorów</li><li>Oversize'owe sylwetki</li><li>Minimalistyczne akcesoria</li><li>Powrót vintage</li></ul><p>Bądź na bieżąco z naszymi poradami modowymi i inspiracjami stylistycznymi na blogu!</p>", new DateTime(2025, 12, 4, 14, 16, 16, 667, DateTimeKind.Utc).AddTicks(508), "pl-PL", "Odkryj najgorętsze trendy modowe, które zdominują rok 2025. Od zrównoważonych materiałów po odważne kolory.", "Odkryj najgorętsze trendy modowe na rok 2025 - zrównoważone materiały, odważne kolory i ponadczasowy styl.", "moda,trendy,2025,styl,odzież,zrównoważona moda", "trendy-modowe-2025", "moda,trendy,2025,styl", "Trendy Modowe na 2025", new DateTime(2025, 12, 4, 14, 16, 16, 667, DateTimeKind.Utc).AddTicks(509) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Blogs",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 4, 9, 17, 28, 774, DateTimeKind.Utc).AddTicks(3735), new DateTime(2025, 12, 4, 9, 17, 28, 774, DateTimeKind.Utc).AddTicks(4050) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 4, 9, 17, 28, 774, DateTimeKind.Utc).AddTicks(4361), new DateTime(2025, 12, 4, 9, 17, 28, 774, DateTimeKind.Utc).AddTicks(4362) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 4, 9, 17, 28, 774, DateTimeKind.Utc).AddTicks(4364), new DateTime(2025, 12, 4, 9, 17, 28, 774, DateTimeKind.Utc).AddTicks(4365) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 4, 9, 17, 28, 774, DateTimeKind.Utc).AddTicks(4368), new DateTime(2025, 12, 4, 9, 17, 28, 774, DateTimeKind.Utc).AddTicks(4368) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 4, 9, 17, 28, 774, DateTimeKind.Utc).AddTicks(4371), new DateTime(2025, 12, 4, 9, 17, 28, 774, DateTimeKind.Utc).AddTicks(4372) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 782, DateTimeKind.Utc).AddTicks(2311));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 782, DateTimeKind.Utc).AddTicks(2611));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 4, 9, 17, 28, 781, DateTimeKind.Utc).AddTicks(5484), new DateTime(2025, 12, 4, 9, 17, 28, 781, DateTimeKind.Utc).AddTicks(5144) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 772, DateTimeKind.Utc).AddTicks(9367));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 772, DateTimeKind.Utc).AddTicks(9695));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 772, DateTimeKind.Utc).AddTicks(9698));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 772, DateTimeKind.Utc).AddTicks(9701));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 773, DateTimeKind.Utc).AddTicks(30));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 773, DateTimeKind.Utc).AddTicks(36));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 773, DateTimeKind.Utc).AddTicks(108));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 773, DateTimeKind.Utc).AddTicks(112));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 773, DateTimeKind.Utc).AddTicks(115));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 773, DateTimeKind.Utc).AddTicks(119));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 773, DateTimeKind.Utc).AddTicks(122));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 773, DateTimeKind.Utc).AddTicks(125));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 771, DateTimeKind.Utc).AddTicks(4742));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 771, DateTimeKind.Utc).AddTicks(5078));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 771, DateTimeKind.Utc).AddTicks(5080));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 771, DateTimeKind.Utc).AddTicks(5082));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 771, DateTimeKind.Utc).AddTicks(5085));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 771, DateTimeKind.Utc).AddTicks(5087));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 771, DateTimeKind.Utc).AddTicks(5090));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 771, DateTimeKind.Utc).AddTicks(5092));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2025, 12, 4, 9, 17, 28, 777, DateTimeKind.Utc).AddTicks(319), new DateTime(2025, 12, 4, 9, 17, 28, 776, DateTimeKind.Utc).AddTicks(8367), new DateTime(2026, 6, 4, 9, 17, 28, 776, DateTimeKind.Utc).AddTicks(8847) });

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 777, DateTimeKind.Utc).AddTicks(4584));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1345));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1670));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1673));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1747));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1749));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1759));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1761));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1764));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1768));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1772));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1774));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1777));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1779));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1781));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1784));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1786));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1791));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1795));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1798));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1801));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1803));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1806));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1808));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1810));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 780, DateTimeKind.Utc).AddTicks(6155));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 780, DateTimeKind.Utc).AddTicks(6697));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 780, DateTimeKind.Utc).AddTicks(6701));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 780, DateTimeKind.Utc).AddTicks(6704));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 780, DateTimeKind.Utc).AddTicks(6843));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 780, DateTimeKind.Utc).AddTicks(6865));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 780, DateTimeKind.Utc).AddTicks(6868));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 780, DateTimeKind.Utc).AddTicks(6871));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 780, DateTimeKind.Utc).AddTicks(6873));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 780, DateTimeKind.Utc).AddTicks(6877));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 780, DateTimeKind.Utc).AddTicks(6882));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 780, DateTimeKind.Utc).AddTicks(6885));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 780, DateTimeKind.Utc).AddTicks(6888));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 780, DateTimeKind.Utc).AddTicks(6890));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 780, DateTimeKind.Utc).AddTicks(6893));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 778, DateTimeKind.Utc).AddTicks(4651));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 778, DateTimeKind.Utc).AddTicks(4955));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 778, DateTimeKind.Utc).AddTicks(4959));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 775, DateTimeKind.Utc).AddTicks(4712));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 775, DateTimeKind.Utc).AddTicks(5723));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 775, DateTimeKind.Utc).AddTicks(5725));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 775, DateTimeKind.Utc).AddTicks(5727));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 775, DateTimeKind.Utc).AddTicks(5729));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 775, DateTimeKind.Utc).AddTicks(5731));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 775, DateTimeKind.Utc).AddTicks(5732));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 775, DateTimeKind.Utc).AddTicks(5734));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 775, DateTimeKind.Utc).AddTicks(5736));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 775, DateTimeKind.Utc).AddTicks(5738));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 775, DateTimeKind.Utc).AddTicks(5740));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 769, DateTimeKind.Utc).AddTicks(3341));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 769, DateTimeKind.Utc).AddTicks(3682));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 769, DateTimeKind.Utc).AddTicks(3684));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 769, DateTimeKind.Utc).AddTicks(3686));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 769, DateTimeKind.Utc).AddTicks(3689));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 769, DateTimeKind.Utc).AddTicks(3691));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 773, DateTimeKind.Utc).AddTicks(5939));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 9, 17, 28, 773, DateTimeKind.Utc).AddTicks(6324));
        }
    }
}
