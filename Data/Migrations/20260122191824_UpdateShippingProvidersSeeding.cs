using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kokomija.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateShippingProvidersSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 388, DateTimeKind.Utc).AddTicks(6132), new DateTime(2026, 1, 22, 19, 18, 21, 388, DateTimeKind.Utc).AddTicks(6537) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 388, DateTimeKind.Utc).AddTicks(6914), new DateTime(2026, 1, 22, 19, 18, 21, 388, DateTimeKind.Utc).AddTicks(6914) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 388, DateTimeKind.Utc).AddTicks(6917), new DateTime(2026, 1, 22, 19, 18, 21, 388, DateTimeKind.Utc).AddTicks(6918) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 388, DateTimeKind.Utc).AddTicks(6921), new DateTime(2026, 1, 22, 19, 18, 21, 388, DateTimeKind.Utc).AddTicks(6921) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 388, DateTimeKind.Utc).AddTicks(6925), new DateTime(2026, 1, 22, 19, 18, 21, 388, DateTimeKind.Utc).AddTicks(6925) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 391, DateTimeKind.Utc).AddTicks(2246), new DateTime(2026, 1, 22, 19, 18, 21, 391, DateTimeKind.Utc).AddTicks(2597) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 391, DateTimeKind.Utc).AddTicks(2920), new DateTime(2026, 1, 22, 19, 18, 21, 391, DateTimeKind.Utc).AddTicks(2921) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 389, DateTimeKind.Utc).AddTicks(5737), new DateTime(2026, 1, 22, 19, 18, 21, 389, DateTimeKind.Utc).AddTicks(3951), new DateTime(2026, 1, 22, 19, 18, 21, 389, DateTimeKind.Utc).AddTicks(6120) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 433, DateTimeKind.Utc).AddTicks(9180));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 433, DateTimeKind.Utc).AddTicks(9720));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 432, DateTimeKind.Utc).AddTicks(8443), new DateTime(2026, 1, 22, 19, 18, 21, 432, DateTimeKind.Utc).AddTicks(8066) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 385, DateTimeKind.Utc).AddTicks(8780));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 385, DateTimeKind.Utc).AddTicks(9390));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 385, DateTimeKind.Utc).AddTicks(9397));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 385, DateTimeKind.Utc).AddTicks(9401));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 385, DateTimeKind.Utc).AddTicks(9923));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 385, DateTimeKind.Utc).AddTicks(9932));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 385, DateTimeKind.Utc).AddTicks(9936));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 385, DateTimeKind.Utc).AddTicks(9941));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 385, DateTimeKind.Utc).AddTicks(9946));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 385, DateTimeKind.Utc).AddTicks(9949));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 385, DateTimeKind.Utc).AddTicks(9953));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 385, DateTimeKind.Utc).AddTicks(9957));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 383, DateTimeKind.Utc).AddTicks(3630));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 383, DateTimeKind.Utc).AddTicks(4163));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 383, DateTimeKind.Utc).AddTicks(4168));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 383, DateTimeKind.Utc).AddTicks(4171));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 383, DateTimeKind.Utc).AddTicks(4173));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 383, DateTimeKind.Utc).AddTicks(4177));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 383, DateTimeKind.Utc).AddTicks(4180));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 383, DateTimeKind.Utc).AddTicks(4183));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 398, DateTimeKind.Utc).AddTicks(8236), new DateTime(2026, 1, 22, 19, 18, 21, 398, DateTimeKind.Utc).AddTicks(4895), new DateTime(2026, 7, 22, 19, 18, 21, 398, DateTimeKind.Utc).AddTicks(5732) });

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 381, DateTimeKind.Utc).AddTicks(9082));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 381, DateTimeKind.Utc).AddTicks(9503));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 381, DateTimeKind.Utc).AddTicks(9507));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 381, DateTimeKind.Utc).AddTicks(9512));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 381, DateTimeKind.Utc).AddTicks(9515));

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 399, DateTimeKind.Utc).AddTicks(5761));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 402, DateTimeKind.Utc).AddTicks(1737));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 402, DateTimeKind.Utc).AddTicks(2080));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 402, DateTimeKind.Utc).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 402, DateTimeKind.Utc).AddTicks(2086));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 402, DateTimeKind.Utc).AddTicks(2089));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 402, DateTimeKind.Utc).AddTicks(2101));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 402, DateTimeKind.Utc).AddTicks(2103));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 402, DateTimeKind.Utc).AddTicks(2106));

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 403, DateTimeKind.Utc).AddTicks(3933), new DateTime(2026, 1, 22, 19, 18, 21, 403, DateTimeKind.Utc).AddTicks(3937) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 426, DateTimeKind.Utc).AddTicks(6781), new DateTime(2026, 1, 22, 19, 18, 21, 426, DateTimeKind.Utc).AddTicks(6785) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 426, DateTimeKind.Utc).AddTicks(7716), new DateTime(2026, 1, 22, 19, 18, 21, 426, DateTimeKind.Utc).AddTicks(7717) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 426, DateTimeKind.Utc).AddTicks(9910), new DateTime(2026, 1, 22, 19, 18, 21, 426, DateTimeKind.Utc).AddTicks(9911) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 426, DateTimeKind.Utc).AddTicks(9970), new DateTime(2026, 1, 22, 19, 18, 21, 426, DateTimeKind.Utc).AddTicks(9970) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 426, DateTimeKind.Utc).AddTicks(9992), new DateTime(2026, 1, 22, 19, 18, 21, 426, DateTimeKind.Utc).AddTicks(9993) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 426, DateTimeKind.Utc).AddTicks(9999), new DateTime(2026, 1, 22, 19, 18, 21, 426, DateTimeKind.Utc).AddTicks(9999) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 427, DateTimeKind.Utc).AddTicks(4), new DateTime(2026, 1, 22, 19, 18, 21, 427, DateTimeKind.Utc).AddTicks(5) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(7985));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8482));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8486));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8490));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8494));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8506));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8509));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8513));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8517));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8522));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8525));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8529));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8532));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8569));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8572));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8576));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8579));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8584));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8587));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8591));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8594));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8598));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8601));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8604));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8608));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8612));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8616));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8619));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8622));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8626));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8630));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8633));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8636));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8641));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8645));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8648));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8652));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8655));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8659));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8662));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8666));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8669));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8673));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8676));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8680));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8683));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8687));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8690));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8694));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8711));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8716));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8719));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8723));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8726));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8730));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8733));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8737));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8740));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8744));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8747));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8751));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8754));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8758));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8761));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8765));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8770));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8774));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8777));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8781));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8784));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8788));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8791));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8794));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8798));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8801));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8805));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8809));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8812));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8816));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8819));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8822));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8826));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8829));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8833));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8836));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8852));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8855));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8859));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8862));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8866));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8869));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8873));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8876));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8880));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8883));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8887));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8890));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8894));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8897));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 431, DateTimeKind.Utc).AddTicks(8900));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 401, DateTimeKind.Utc).AddTicks(4985));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 401, DateTimeKind.Utc).AddTicks(5310));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 401, DateTimeKind.Utc).AddTicks(5314));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 401, DateTimeKind.Utc).AddTicks(5319));

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { "inpost_paczkomat", new DateTime(2026, 1, 22, 19, 18, 21, 393, DateTimeKind.Utc).AddTicks(2215), "InPost Paczkomat", new DateTime(2026, 1, 22, 19, 18, 21, 393, DateTimeKind.Utc).AddTicks(2605) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Code", "CreatedAt", "EstimatedDeliveryDays", "Name", "SupportedCountries", "TrackingUrlTemplate", "UpdatedAt" },
                values: new object[] { "inpost_courier", new DateTime(2026, 1, 22, 19, 18, 21, 393, DateTimeKind.Utc).AddTicks(2933), 1, "InPost Kurier", "[\"PL\"]", "https://inpost.pl/sledzenie-przesylek?number={trackingNumber}", new DateTime(2026, 1, 22, 19, 18, 21, 393, DateTimeKind.Utc).AddTicks(2934) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Code", "CreatedAt", "EstimatedDeliveryDays", "Name", "SupportedCountries", "TrackingUrlTemplate", "UpdatedAt" },
                values: new object[] { "dhl_express", new DateTime(2026, 1, 22, 19, 18, 21, 393, DateTimeKind.Utc).AddTicks(2937), 2, "DHL Express", "[\"PL\",\"DE\",\"US\",\"GB\",\"FR\",\"IT\"]", "https://www.dhl.com/en/express/tracking.html?AWB={trackingNumber}", new DateTime(2026, 1, 22, 19, 18, 21, 393, DateTimeKind.Utc).AddTicks(2938) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Code", "CreatedAt", "EstimatedDeliveryDays", "Name", "SupportedCountries", "TrackingUrlTemplate", "UpdatedAt" },
                values: new object[] { "dhl_standard", new DateTime(2026, 1, 22, 19, 18, 21, 393, DateTimeKind.Utc).AddTicks(2941), 4, "DHL Standard", "[\"PL\",\"DE\",\"US\",\"GB\",\"FR\",\"IT\"]", "https://www.dhl.com/en/express/tracking.html?AWB={trackingNumber}", new DateTime(2026, 1, 22, 19, 18, 21, 393, DateTimeKind.Utc).AddTicks(2942) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 393, DateTimeKind.Utc).AddTicks(2945), new DateTime(2026, 1, 22, 19, 18, 21, 393, DateTimeKind.Utc).AddTicks(2946) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 395, DateTimeKind.Utc).AddTicks(5288), new DateTime(2026, 1, 22, 19, 18, 21, 395, DateTimeKind.Utc).AddTicks(6540) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name", "ShippingProviderId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 395, DateTimeKind.Utc).AddTicks(9258), "InPost Kurier", 2, new DateTime(2026, 1, 22, 19, 18, 21, 395, DateTimeKind.Utc).AddTicks(9259) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BasePrice", "CreatedAt", "Description", "MaxDeliveryDays", "MinDeliveryDays", "Name", "ShippingProviderId", "UpdatedAt" },
                values: new object[] { 49.99m, new DateTime(2026, 1, 22, 19, 18, 21, 395, DateTimeKind.Utc).AddTicks(9263), "Express international delivery", 2, 1, "DHL Express", 3, new DateTime(2026, 1, 22, 19, 18, 21, 395, DateTimeKind.Utc).AddTicks(9264) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BasePrice", "CreatedAt", "Description", "MaxDeliveryDays", "MinDeliveryDays", "Name", "ShippingProviderId", "UpdatedAt" },
                values: new object[] { 29.99m, new DateTime(2026, 1, 22, 19, 18, 21, 395, DateTimeKind.Utc).AddTicks(9268), "Standard international delivery", 5, 3, "DHL Standard", 4, new DateTime(2026, 1, 22, 19, 18, 21, 395, DateTimeKind.Utc).AddTicks(9269) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 395, DateTimeKind.Utc).AddTicks(9275), new DateTime(2026, 1, 22, 19, 18, 21, 395, DateTimeKind.Utc).AddTicks(9277) });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 392, DateTimeKind.Utc).AddTicks(3100));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 392, DateTimeKind.Utc).AddTicks(3436));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 392, DateTimeKind.Utc).AddTicks(3438));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 392, DateTimeKind.Utc).AddTicks(3440));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 392, DateTimeKind.Utc).AddTicks(3443));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 392, DateTimeKind.Utc).AddTicks(3445));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 392, DateTimeKind.Utc).AddTicks(3447));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 392, DateTimeKind.Utc).AddTicks(3449));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 392, DateTimeKind.Utc).AddTicks(3451));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 392, DateTimeKind.Utc).AddTicks(3453));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 392, DateTimeKind.Utc).AddTicks(3455));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 378, DateTimeKind.Utc).AddTicks(8107));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 378, DateTimeKind.Utc).AddTicks(8728));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 378, DateTimeKind.Utc).AddTicks(8730));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 378, DateTimeKind.Utc).AddTicks(8734));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 378, DateTimeKind.Utc).AddTicks(8737));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 378, DateTimeKind.Utc).AddTicks(8787));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 387, DateTimeKind.Utc).AddTicks(3211));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 22, 19, 18, 21, 387, DateTimeKind.Utc).AddTicks(3857));

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 397, DateTimeKind.Utc).AddTicks(174), new DateTime(2026, 1, 22, 19, 18, 21, 397, DateTimeKind.Utc).AddTicks(600) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 397, DateTimeKind.Utc).AddTicks(1007), new DateTime(2026, 1, 22, 19, 18, 21, 397, DateTimeKind.Utc).AddTicks(1008) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 22, 19, 18, 21, 397, DateTimeKind.Utc).AddTicks(1013), new DateTime(2026, 1, 22, 19, 18, 21, 397, DateTimeKind.Utc).AddTicks(1014) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 12, 40, 12, 749, DateTimeKind.Utc).AddTicks(4266), new DateTime(2026, 1, 15, 12, 40, 12, 749, DateTimeKind.Utc).AddTicks(4631) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 12, 40, 12, 749, DateTimeKind.Utc).AddTicks(4968), new DateTime(2026, 1, 15, 12, 40, 12, 749, DateTimeKind.Utc).AddTicks(4968) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 12, 40, 12, 749, DateTimeKind.Utc).AddTicks(4971), new DateTime(2026, 1, 15, 12, 40, 12, 749, DateTimeKind.Utc).AddTicks(4972) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 12, 40, 12, 749, DateTimeKind.Utc).AddTicks(4975), new DateTime(2026, 1, 15, 12, 40, 12, 749, DateTimeKind.Utc).AddTicks(4975) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 12, 40, 12, 749, DateTimeKind.Utc).AddTicks(4978), new DateTime(2026, 1, 15, 12, 40, 12, 749, DateTimeKind.Utc).AddTicks(4979) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 12, 40, 12, 751, DateTimeKind.Utc).AddTicks(69), new DateTime(2026, 1, 15, 12, 40, 12, 751, DateTimeKind.Utc).AddTicks(494) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 12, 40, 12, 751, DateTimeKind.Utc).AddTicks(933), new DateTime(2026, 1, 15, 12, 40, 12, 751, DateTimeKind.Utc).AddTicks(936) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 12, 40, 12, 750, DateTimeKind.Utc).AddTicks(1283), new DateTime(2026, 1, 15, 12, 40, 12, 749, DateTimeKind.Utc).AddTicks(9854), new DateTime(2026, 1, 15, 12, 40, 12, 750, DateTimeKind.Utc).AddTicks(1595) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 787, DateTimeKind.Utc).AddTicks(9939));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 788, DateTimeKind.Utc).AddTicks(404));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 15, 12, 40, 12, 786, DateTimeKind.Utc).AddTicks(9968), new DateTime(2026, 1, 15, 12, 40, 12, 786, DateTimeKind.Utc).AddTicks(9470) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 747, DateTimeKind.Utc).AddTicks(320));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 747, DateTimeKind.Utc).AddTicks(887));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 747, DateTimeKind.Utc).AddTicks(895));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 747, DateTimeKind.Utc).AddTicks(903));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 747, DateTimeKind.Utc).AddTicks(1408));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 747, DateTimeKind.Utc).AddTicks(1420));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 747, DateTimeKind.Utc).AddTicks(1424));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 747, DateTimeKind.Utc).AddTicks(1429));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 747, DateTimeKind.Utc).AddTicks(1433));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 747, DateTimeKind.Utc).AddTicks(1438));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 747, DateTimeKind.Utc).AddTicks(1441));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 747, DateTimeKind.Utc).AddTicks(1445));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 745, DateTimeKind.Utc).AddTicks(3340));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 745, DateTimeKind.Utc).AddTicks(3662));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 745, DateTimeKind.Utc).AddTicks(3665));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 745, DateTimeKind.Utc).AddTicks(3667));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 745, DateTimeKind.Utc).AddTicks(3670));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 745, DateTimeKind.Utc).AddTicks(3672));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 745, DateTimeKind.Utc).AddTicks(3675));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 745, DateTimeKind.Utc).AddTicks(3677));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2026, 1, 15, 12, 40, 12, 756, DateTimeKind.Utc).AddTicks(7821), new DateTime(2026, 1, 15, 12, 40, 12, 756, DateTimeKind.Utc).AddTicks(5848), new DateTime(2026, 7, 15, 12, 40, 12, 756, DateTimeKind.Utc).AddTicks(6206) });

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 744, DateTimeKind.Utc).AddTicks(4006));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 744, DateTimeKind.Utc).AddTicks(4350));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 744, DateTimeKind.Utc).AddTicks(4352));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 744, DateTimeKind.Utc).AddTicks(4354));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 744, DateTimeKind.Utc).AddTicks(4357));

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 757, DateTimeKind.Utc).AddTicks(4844));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 759, DateTimeKind.Utc).AddTicks(3949));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 759, DateTimeKind.Utc).AddTicks(4285));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 759, DateTimeKind.Utc).AddTicks(4288));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 759, DateTimeKind.Utc).AddTicks(4291));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 759, DateTimeKind.Utc).AddTicks(4294));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 759, DateTimeKind.Utc).AddTicks(4307));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 759, DateTimeKind.Utc).AddTicks(4310));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 759, DateTimeKind.Utc).AddTicks(4312));

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 12, 40, 12, 760, DateTimeKind.Utc).AddTicks(2663), new DateTime(2026, 1, 15, 12, 40, 12, 760, DateTimeKind.Utc).AddTicks(2664) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 12, 40, 12, 781, DateTimeKind.Utc).AddTicks(11), new DateTime(2026, 1, 15, 12, 40, 12, 781, DateTimeKind.Utc).AddTicks(16) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 12, 40, 12, 781, DateTimeKind.Utc).AddTicks(1135), new DateTime(2026, 1, 15, 12, 40, 12, 781, DateTimeKind.Utc).AddTicks(1136) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 12, 40, 12, 781, DateTimeKind.Utc).AddTicks(4269), new DateTime(2026, 1, 15, 12, 40, 12, 781, DateTimeKind.Utc).AddTicks(4270) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 12, 40, 12, 781, DateTimeKind.Utc).AddTicks(4320), new DateTime(2026, 1, 15, 12, 40, 12, 781, DateTimeKind.Utc).AddTicks(4321) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 12, 40, 12, 781, DateTimeKind.Utc).AddTicks(4405), new DateTime(2026, 1, 15, 12, 40, 12, 781, DateTimeKind.Utc).AddTicks(4407) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 12, 40, 12, 781, DateTimeKind.Utc).AddTicks(4415), new DateTime(2026, 1, 15, 12, 40, 12, 781, DateTimeKind.Utc).AddTicks(4416) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 12, 40, 12, 781, DateTimeKind.Utc).AddTicks(4422), new DateTime(2026, 1, 15, 12, 40, 12, 781, DateTimeKind.Utc).AddTicks(4423) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(6860));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7576));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7584));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7589));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7594));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7607));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7611));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7616));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7620));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7626));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7630));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7634));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7639));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7643));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7647));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7682));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7687));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7696));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7700));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7706));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7711));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7715));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7719));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7724));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7728));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7734));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7738));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7743));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7747));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7751));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7760));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7765));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7770));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7776));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7785));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7790));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7794));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7798));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7802));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7806));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7811));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7816));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7820));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7824));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7828));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7832));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7838));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7843));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7848));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7852));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7856));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7863));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7880));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7885));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7890));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7895));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7901));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7905));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7909));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7913));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7918));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7923));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7929));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7934));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7938));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7945));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7950));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7954));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7958));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7965));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7970));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7974));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7978));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7983));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7988));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7993));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(7998));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(8002));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(8006));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(8010));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(8015));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(8020));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(8024));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(8029));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(8034));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(8039));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(8044));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(8050));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(8069));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(8073));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(8078));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(8082));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(8086));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(8091));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(8095));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(8099));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(8104));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(8108));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(8113));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 785, DateTimeKind.Utc).AddTicks(8118));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 758, DateTimeKind.Utc).AddTicks(7881));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 758, DateTimeKind.Utc).AddTicks(8193));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 758, DateTimeKind.Utc).AddTicks(8197));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 758, DateTimeKind.Utc).AddTicks(8201));

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { "inpost", new DateTime(2026, 1, 15, 12, 40, 12, 753, DateTimeKind.Utc).AddTicks(5909), "InPost", new DateTime(2026, 1, 15, 12, 40, 12, 753, DateTimeKind.Utc).AddTicks(6233) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Code", "CreatedAt", "EstimatedDeliveryDays", "Name", "SupportedCountries", "TrackingUrlTemplate", "UpdatedAt" },
                values: new object[] { "dhl", new DateTime(2026, 1, 15, 12, 40, 12, 753, DateTimeKind.Utc).AddTicks(6547), 3, "DHL", "[\"PL\",\"DE\",\"US\",\"GB\"]", "https://www.dhl.com/en/express/tracking.html?AWB={trackingNumber}", new DateTime(2026, 1, 15, 12, 40, 12, 753, DateTimeKind.Utc).AddTicks(6547) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Code", "CreatedAt", "EstimatedDeliveryDays", "Name", "SupportedCountries", "TrackingUrlTemplate", "UpdatedAt" },
                values: new object[] { "ups", new DateTime(2026, 1, 15, 12, 40, 12, 753, DateTimeKind.Utc).AddTicks(6551), 3, "UPS", "[\"PL\",\"DE\",\"US\",\"GB\"]", "https://www.ups.com/track?tracknum={trackingNumber}", new DateTime(2026, 1, 15, 12, 40, 12, 753, DateTimeKind.Utc).AddTicks(6551) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Code", "CreatedAt", "EstimatedDeliveryDays", "Name", "SupportedCountries", "TrackingUrlTemplate", "UpdatedAt" },
                values: new object[] { "fedex", new DateTime(2026, 1, 15, 12, 40, 12, 753, DateTimeKind.Utc).AddTicks(6554), 3, "FedEx", "[\"PL\",\"DE\",\"US\",\"GB\"]", "https://www.fedex.com/fedextrack/?trknbr={trackingNumber}", new DateTime(2026, 1, 15, 12, 40, 12, 753, DateTimeKind.Utc).AddTicks(6555) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 12, 40, 12, 753, DateTimeKind.Utc).AddTicks(6558), new DateTime(2026, 1, 15, 12, 40, 12, 753, DateTimeKind.Utc).AddTicks(6559) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 12, 40, 12, 754, DateTimeKind.Utc).AddTicks(7155), new DateTime(2026, 1, 15, 12, 40, 12, 754, DateTimeKind.Utc).AddTicks(7465) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name", "ShippingProviderId", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 12, 40, 12, 754, DateTimeKind.Utc).AddTicks(7772), "InPost Courier", 1, new DateTime(2026, 1, 15, 12, 40, 12, 754, DateTimeKind.Utc).AddTicks(7772) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BasePrice", "CreatedAt", "Description", "MaxDeliveryDays", "MinDeliveryDays", "Name", "ShippingProviderId", "UpdatedAt" },
                values: new object[] { 29.99m, new DateTime(2026, 1, 15, 12, 40, 12, 754, DateTimeKind.Utc).AddTicks(7776), "Standard international delivery", 5, 3, "DHL Standard", 2, new DateTime(2026, 1, 15, 12, 40, 12, 754, DateTimeKind.Utc).AddTicks(7776) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BasePrice", "CreatedAt", "Description", "MaxDeliveryDays", "MinDeliveryDays", "Name", "ShippingProviderId", "UpdatedAt" },
                values: new object[] { 49.99m, new DateTime(2026, 1, 15, 12, 40, 12, 754, DateTimeKind.Utc).AddTicks(7779), "Express international delivery", 2, 1, "DHL Express", 2, new DateTime(2026, 1, 15, 12, 40, 12, 754, DateTimeKind.Utc).AddTicks(7780) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 12, 40, 12, 754, DateTimeKind.Utc).AddTicks(7784), new DateTime(2026, 1, 15, 12, 40, 12, 754, DateTimeKind.Utc).AddTicks(7784) });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 752, DateTimeKind.Utc).AddTicks(4170));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 752, DateTimeKind.Utc).AddTicks(4709));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 752, DateTimeKind.Utc).AddTicks(4716));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 752, DateTimeKind.Utc).AddTicks(4720));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 752, DateTimeKind.Utc).AddTicks(4722));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 752, DateTimeKind.Utc).AddTicks(4725));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 752, DateTimeKind.Utc).AddTicks(4774));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 752, DateTimeKind.Utc).AddTicks(4777));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 752, DateTimeKind.Utc).AddTicks(4779));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 752, DateTimeKind.Utc).AddTicks(4781));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 752, DateTimeKind.Utc).AddTicks(4784));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 742, DateTimeKind.Utc).AddTicks(3972));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 742, DateTimeKind.Utc).AddTicks(4508));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 742, DateTimeKind.Utc).AddTicks(4514));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 742, DateTimeKind.Utc).AddTicks(4516));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 742, DateTimeKind.Utc).AddTicks(4519));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 742, DateTimeKind.Utc).AddTicks(4521));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 748, DateTimeKind.Utc).AddTicks(2484));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 15, 12, 40, 12, 748, DateTimeKind.Utc).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 12, 40, 12, 755, DateTimeKind.Utc).AddTicks(4414), new DateTime(2026, 1, 15, 12, 40, 12, 755, DateTimeKind.Utc).AddTicks(4745) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 12, 40, 12, 755, DateTimeKind.Utc).AddTicks(5133), new DateTime(2026, 1, 15, 12, 40, 12, 755, DateTimeKind.Utc).AddTicks(5134) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 15, 12, 40, 12, 755, DateTimeKind.Utc).AddTicks(5137), new DateTime(2026, 1, 15, 12, 40, 12, 755, DateTimeKind.Utc).AddTicks(5138) });
        }
    }
}
