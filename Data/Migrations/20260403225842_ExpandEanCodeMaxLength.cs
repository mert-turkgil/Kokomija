using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kokomija.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExpandEanCodeMaxLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EanCode",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 690, DateTimeKind.Utc).AddTicks(7869), new DateTime(2026, 4, 3, 22, 58, 40, 690, DateTimeKind.Utc).AddTicks(8198) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 690, DateTimeKind.Utc).AddTicks(8510), new DateTime(2026, 4, 3, 22, 58, 40, 690, DateTimeKind.Utc).AddTicks(8511) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 690, DateTimeKind.Utc).AddTicks(8513), new DateTime(2026, 4, 3, 22, 58, 40, 690, DateTimeKind.Utc).AddTicks(8513) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 690, DateTimeKind.Utc).AddTicks(8515), new DateTime(2026, 4, 3, 22, 58, 40, 690, DateTimeKind.Utc).AddTicks(8516) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 690, DateTimeKind.Utc).AddTicks(8518), new DateTime(2026, 4, 3, 22, 58, 40, 690, DateTimeKind.Utc).AddTicks(8518) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 692, DateTimeKind.Utc).AddTicks(433), new DateTime(2026, 4, 3, 22, 58, 40, 692, DateTimeKind.Utc).AddTicks(760) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 692, DateTimeKind.Utc).AddTicks(1158), new DateTime(2026, 4, 3, 22, 58, 40, 692, DateTimeKind.Utc).AddTicks(1159) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 691, DateTimeKind.Utc).AddTicks(3578), new DateTime(2026, 4, 3, 22, 58, 40, 691, DateTimeKind.Utc).AddTicks(2167), new DateTime(2026, 4, 3, 22, 58, 40, 691, DateTimeKind.Utc).AddTicks(3908) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 703, DateTimeKind.Utc).AddTicks(3183));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 703, DateTimeKind.Utc).AddTicks(3517));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 702, DateTimeKind.Utc).AddTicks(6083), new DateTime(2026, 4, 3, 22, 58, 40, 702, DateTimeKind.Utc).AddTicks(5726) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 689, DateTimeKind.Utc).AddTicks(4984));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 689, DateTimeKind.Utc).AddTicks(5330));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 689, DateTimeKind.Utc).AddTicks(5333));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 689, DateTimeKind.Utc).AddTicks(5337));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 689, DateTimeKind.Utc).AddTicks(5689));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 689, DateTimeKind.Utc).AddTicks(5695));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 689, DateTimeKind.Utc).AddTicks(5699));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 689, DateTimeKind.Utc).AddTicks(5702));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 689, DateTimeKind.Utc).AddTicks(5705));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 689, DateTimeKind.Utc).AddTicks(5707));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 689, DateTimeKind.Utc).AddTicks(5709));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 689, DateTimeKind.Utc).AddTicks(5711));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 687, DateTimeKind.Utc).AddTicks(9526));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 688, DateTimeKind.Utc).AddTicks(85));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 688, DateTimeKind.Utc).AddTicks(88));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 688, DateTimeKind.Utc).AddTicks(90));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 688, DateTimeKind.Utc).AddTicks(92));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 688, DateTimeKind.Utc).AddTicks(93));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 688, DateTimeKind.Utc).AddTicks(95));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 688, DateTimeKind.Utc).AddTicks(97));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 696, DateTimeKind.Utc).AddTicks(887), new DateTime(2026, 4, 3, 22, 58, 40, 695, DateTimeKind.Utc).AddTicks(7928), new DateTime(2026, 10, 3, 22, 58, 40, 695, DateTimeKind.Utc).AddTicks(8583) });

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 686, DateTimeKind.Utc).AddTicks(9855));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 687, DateTimeKind.Utc).AddTicks(364));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 687, DateTimeKind.Utc).AddTicks(366));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 687, DateTimeKind.Utc).AddTicks(369));

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 696, DateTimeKind.Utc).AddTicks(5443));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 698, DateTimeKind.Utc).AddTicks(1004));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 698, DateTimeKind.Utc).AddTicks(1386));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 698, DateTimeKind.Utc).AddTicks(1388));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 698, DateTimeKind.Utc).AddTicks(1390));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 698, DateTimeKind.Utc).AddTicks(1392));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 698, DateTimeKind.Utc).AddTicks(1403));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 698, DateTimeKind.Utc).AddTicks(1404));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 698, DateTimeKind.Utc).AddTicks(1406));

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 698, DateTimeKind.Utc).AddTicks(8864), new DateTime(2026, 4, 3, 22, 58, 40, 698, DateTimeKind.Utc).AddTicks(8865) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 699, DateTimeKind.Utc).AddTicks(3290), new DateTime(2026, 4, 3, 22, 58, 40, 699, DateTimeKind.Utc).AddTicks(3291) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 699, DateTimeKind.Utc).AddTicks(3952), new DateTime(2026, 4, 3, 22, 58, 40, 699, DateTimeKind.Utc).AddTicks(3953) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 699, DateTimeKind.Utc).AddTicks(5096), new DateTime(2026, 4, 3, 22, 58, 40, 699, DateTimeKind.Utc).AddTicks(5097) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 699, DateTimeKind.Utc).AddTicks(5110), new DateTime(2026, 4, 3, 22, 58, 40, 699, DateTimeKind.Utc).AddTicks(5110) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 699, DateTimeKind.Utc).AddTicks(5122), new DateTime(2026, 4, 3, 22, 58, 40, 699, DateTimeKind.Utc).AddTicks(5122) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 699, DateTimeKind.Utc).AddTicks(5126), new DateTime(2026, 4, 3, 22, 58, 40, 699, DateTimeKind.Utc).AddTicks(5126) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 699, DateTimeKind.Utc).AddTicks(5144), new DateTime(2026, 4, 3, 22, 58, 40, 699, DateTimeKind.Utc).AddTicks(5145) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8371));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8773));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8777));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8779));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8782));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8789));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8791));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8793));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8795));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8798));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8800));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8802));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8804));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8806));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8807));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8809));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8811));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8813));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8815));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8817));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8819));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8821));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8823));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8838));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8840));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8842));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8844));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8847));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8849));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8851));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8853));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8855));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8857));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8861));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8863));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8865));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8867));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8869));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8871));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8873));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8875));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8877));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8879));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8880));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8882));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8884));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8886));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8888));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8890));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8892));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8894));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8896));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8898));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8900));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8902));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8904));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8906));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8908));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8910));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8912));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8921));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8923));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8924));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8926));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8928));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8931));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8933));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8934));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8936));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8938));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8940));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8942));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8944));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8946));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8948));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8951));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8952));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8954));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8956));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8958));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8960));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8962));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8964));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8965));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8967));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8969));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8971));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8974));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8975));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8977));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8979));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8980));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8982));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8984));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8992));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8994));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8995));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8997));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(8999));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 701, DateTimeKind.Utc).AddTicks(9001));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EanCode" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 697, DateTimeKind.Utc).AddTicks(5893), "5901234100011" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EanCode" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 697, DateTimeKind.Utc).AddTicks(6236), "5901234100028" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EanCode" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 697, DateTimeKind.Utc).AddTicks(6240), "5901234100035" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EanCode" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 697, DateTimeKind.Utc).AddTicks(6243), "5901234100042" });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 693, DateTimeKind.Utc).AddTicks(3977), new DateTime(2026, 4, 3, 22, 58, 40, 693, DateTimeKind.Utc).AddTicks(4307) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 693, DateTimeKind.Utc).AddTicks(4631), new DateTime(2026, 4, 3, 22, 58, 40, 693, DateTimeKind.Utc).AddTicks(4632) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 693, DateTimeKind.Utc).AddTicks(4634), new DateTime(2026, 4, 3, 22, 58, 40, 693, DateTimeKind.Utc).AddTicks(4635) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 693, DateTimeKind.Utc).AddTicks(4637), new DateTime(2026, 4, 3, 22, 58, 40, 693, DateTimeKind.Utc).AddTicks(4637) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 693, DateTimeKind.Utc).AddTicks(4639), new DateTime(2026, 4, 3, 22, 58, 40, 693, DateTimeKind.Utc).AddTicks(4639) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 694, DateTimeKind.Utc).AddTicks(2790), new DateTime(2026, 4, 3, 22, 58, 40, 694, DateTimeKind.Utc).AddTicks(3122) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 694, DateTimeKind.Utc).AddTicks(3449), new DateTime(2026, 4, 3, 22, 58, 40, 694, DateTimeKind.Utc).AddTicks(3450) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 694, DateTimeKind.Utc).AddTicks(3453), new DateTime(2026, 4, 3, 22, 58, 40, 694, DateTimeKind.Utc).AddTicks(3453) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 694, DateTimeKind.Utc).AddTicks(3455), new DateTime(2026, 4, 3, 22, 58, 40, 694, DateTimeKind.Utc).AddTicks(3456) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 694, DateTimeKind.Utc).AddTicks(3458), new DateTime(2026, 4, 3, 22, 58, 40, 694, DateTimeKind.Utc).AddTicks(3459) });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 692, DateTimeKind.Utc).AddTicks(7376));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 692, DateTimeKind.Utc).AddTicks(7701));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 692, DateTimeKind.Utc).AddTicks(7703));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 692, DateTimeKind.Utc).AddTicks(7705));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 692, DateTimeKind.Utc).AddTicks(7706));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 692, DateTimeKind.Utc).AddTicks(7707));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 692, DateTimeKind.Utc).AddTicks(7709));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 692, DateTimeKind.Utc).AddTicks(7710));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 692, DateTimeKind.Utc).AddTicks(7711));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 692, DateTimeKind.Utc).AddTicks(7713));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 692, DateTimeKind.Utc).AddTicks(7714));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 685, DateTimeKind.Utc).AddTicks(2364));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 685, DateTimeKind.Utc).AddTicks(2787));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 685, DateTimeKind.Utc).AddTicks(2789));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 685, DateTimeKind.Utc).AddTicks(2791));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 685, DateTimeKind.Utc).AddTicks(2793));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 685, DateTimeKind.Utc).AddTicks(2794));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 690, DateTimeKind.Utc).AddTicks(1476));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 3, 22, 58, 40, 690, DateTimeKind.Utc).AddTicks(1807));

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 694, DateTimeKind.Utc).AddTicks(9203), new DateTime(2026, 4, 3, 22, 58, 40, 694, DateTimeKind.Utc).AddTicks(9610) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 694, DateTimeKind.Utc).AddTicks(9969), new DateTime(2026, 4, 3, 22, 58, 40, 694, DateTimeKind.Utc).AddTicks(9970) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 4, 3, 22, 58, 40, 694, DateTimeKind.Utc).AddTicks(9972), new DateTime(2026, 4, 3, 22, 58, 40, 694, DateTimeKind.Utc).AddTicks(9973) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EanCode",
                table: "Products",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 722, DateTimeKind.Utc).AddTicks(638), new DateTime(2026, 3, 19, 19, 41, 42, 722, DateTimeKind.Utc).AddTicks(955) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 722, DateTimeKind.Utc).AddTicks(1263), new DateTime(2026, 3, 19, 19, 41, 42, 722, DateTimeKind.Utc).AddTicks(1263) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 722, DateTimeKind.Utc).AddTicks(1266), new DateTime(2026, 3, 19, 19, 41, 42, 722, DateTimeKind.Utc).AddTicks(1266) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 722, DateTimeKind.Utc).AddTicks(1269), new DateTime(2026, 3, 19, 19, 41, 42, 722, DateTimeKind.Utc).AddTicks(1269) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 722, DateTimeKind.Utc).AddTicks(1271), new DateTime(2026, 3, 19, 19, 41, 42, 722, DateTimeKind.Utc).AddTicks(1272) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 723, DateTimeKind.Utc).AddTicks(9268), new DateTime(2026, 3, 19, 19, 41, 42, 723, DateTimeKind.Utc).AddTicks(9602) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 723, DateTimeKind.Utc).AddTicks(9924), new DateTime(2026, 3, 19, 19, 41, 42, 723, DateTimeKind.Utc).AddTicks(9924) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 722, DateTimeKind.Utc).AddTicks(9105), new DateTime(2026, 3, 19, 19, 41, 42, 722, DateTimeKind.Utc).AddTicks(6864), new DateTime(2026, 3, 19, 19, 41, 42, 722, DateTimeKind.Utc).AddTicks(9644) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 735, DateTimeKind.Utc).AddTicks(7131));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 735, DateTimeKind.Utc).AddTicks(7468));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(9601), new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(9241) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 720, DateTimeKind.Utc).AddTicks(7413));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 720, DateTimeKind.Utc).AddTicks(7797));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 720, DateTimeKind.Utc).AddTicks(7800));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 720, DateTimeKind.Utc).AddTicks(7803));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 720, DateTimeKind.Utc).AddTicks(8174));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 720, DateTimeKind.Utc).AddTicks(8181));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 720, DateTimeKind.Utc).AddTicks(8183));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 720, DateTimeKind.Utc).AddTicks(8185));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 720, DateTimeKind.Utc).AddTicks(8187));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 720, DateTimeKind.Utc).AddTicks(8189));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 720, DateTimeKind.Utc).AddTicks(8191));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 720, DateTimeKind.Utc).AddTicks(8193));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 719, DateTimeKind.Utc).AddTicks(7311));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 719, DateTimeKind.Utc).AddTicks(7642));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 719, DateTimeKind.Utc).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 719, DateTimeKind.Utc).AddTicks(7647));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 719, DateTimeKind.Utc).AddTicks(7648));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 719, DateTimeKind.Utc).AddTicks(7650));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 719, DateTimeKind.Utc).AddTicks(7652));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 719, DateTimeKind.Utc).AddTicks(7653));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 728, DateTimeKind.Utc).AddTicks(2234), new DateTime(2026, 3, 19, 19, 41, 42, 727, DateTimeKind.Utc).AddTicks(9310), new DateTime(2026, 9, 19, 19, 41, 42, 727, DateTimeKind.Utc).AddTicks(9859) });

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 719, DateTimeKind.Utc).AddTicks(541));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 719, DateTimeKind.Utc).AddTicks(868));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 719, DateTimeKind.Utc).AddTicks(870));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 719, DateTimeKind.Utc).AddTicks(872));

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 728, DateTimeKind.Utc).AddTicks(7835));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 730, DateTimeKind.Utc).AddTicks(2252));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 730, DateTimeKind.Utc).AddTicks(2598));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 730, DateTimeKind.Utc).AddTicks(2601));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 730, DateTimeKind.Utc).AddTicks(2603));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 730, DateTimeKind.Utc).AddTicks(2605));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 730, DateTimeKind.Utc).AddTicks(2610));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 730, DateTimeKind.Utc).AddTicks(2612));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 730, DateTimeKind.Utc).AddTicks(2613));

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 730, DateTimeKind.Utc).AddTicks(8910), new DateTime(2026, 3, 19, 19, 41, 42, 730, DateTimeKind.Utc).AddTicks(8911) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 731, DateTimeKind.Utc).AddTicks(2468), new DateTime(2026, 3, 19, 19, 41, 42, 731, DateTimeKind.Utc).AddTicks(2468) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 731, DateTimeKind.Utc).AddTicks(3099), new DateTime(2026, 3, 19, 19, 41, 42, 731, DateTimeKind.Utc).AddTicks(3100) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 731, DateTimeKind.Utc).AddTicks(4643), new DateTime(2026, 3, 19, 19, 41, 42, 731, DateTimeKind.Utc).AddTicks(4644) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 731, DateTimeKind.Utc).AddTicks(4665), new DateTime(2026, 3, 19, 19, 41, 42, 731, DateTimeKind.Utc).AddTicks(4665) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 731, DateTimeKind.Utc).AddTicks(4680), new DateTime(2026, 3, 19, 19, 41, 42, 731, DateTimeKind.Utc).AddTicks(4681) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 731, DateTimeKind.Utc).AddTicks(4686), new DateTime(2026, 3, 19, 19, 41, 42, 731, DateTimeKind.Utc).AddTicks(4686) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 731, DateTimeKind.Utc).AddTicks(4690), new DateTime(2026, 3, 19, 19, 41, 42, 731, DateTimeKind.Utc).AddTicks(4691) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 733, DateTimeKind.Utc).AddTicks(9446));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(37));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(42));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(46));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(49));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(58));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(62));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(64));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(68));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(72));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(75));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(79));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(82));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(84));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(87));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(90));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(94));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(98));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(101));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(104));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(107));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(110));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(113));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(116));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(119));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(123));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(126));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(129));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(132));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(134));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(137));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(140));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(161));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(167));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(170));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(173));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(177));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(179));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(183));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(187));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(190));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(193));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(196));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(199));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(202));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(204));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(207));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(210));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(213));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(216));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(219));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(223));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(226));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(229));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(233));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(236));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(240));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(243));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(246));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(249));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(252));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(255));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(258));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(260));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(264));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(278));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(282));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(285));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(288));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(291));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(295));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(298));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(301));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(304));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(307));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(311));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(313));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(316));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(319));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(322));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(325));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(328));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(331));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(334));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(336));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(340));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(343));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(346));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(348));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(351));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(354));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(357));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(360));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(363));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(366));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(369));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(372));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(376));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(380));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 734, DateTimeKind.Utc).AddTicks(383));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EanCode" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 729, DateTimeKind.Utc).AddTicks(7314), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EanCode" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 729, DateTimeKind.Utc).AddTicks(7632), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EanCode" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 729, DateTimeKind.Utc).AddTicks(7637), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EanCode" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 729, DateTimeKind.Utc).AddTicks(7640), null });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 725, DateTimeKind.Utc).AddTicks(3563), new DateTime(2026, 3, 19, 19, 41, 42, 725, DateTimeKind.Utc).AddTicks(3996) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 725, DateTimeKind.Utc).AddTicks(4479), new DateTime(2026, 3, 19, 19, 41, 42, 725, DateTimeKind.Utc).AddTicks(4479) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 725, DateTimeKind.Utc).AddTicks(4482), new DateTime(2026, 3, 19, 19, 41, 42, 725, DateTimeKind.Utc).AddTicks(4482) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 725, DateTimeKind.Utc).AddTicks(4485), new DateTime(2026, 3, 19, 19, 41, 42, 725, DateTimeKind.Utc).AddTicks(4485) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 725, DateTimeKind.Utc).AddTicks(4505), new DateTime(2026, 3, 19, 19, 41, 42, 725, DateTimeKind.Utc).AddTicks(4506) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 726, DateTimeKind.Utc).AddTicks(2646), new DateTime(2026, 3, 19, 19, 41, 42, 726, DateTimeKind.Utc).AddTicks(2972) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 726, DateTimeKind.Utc).AddTicks(3288), new DateTime(2026, 3, 19, 19, 41, 42, 726, DateTimeKind.Utc).AddTicks(3288) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 726, DateTimeKind.Utc).AddTicks(3291), new DateTime(2026, 3, 19, 19, 41, 42, 726, DateTimeKind.Utc).AddTicks(3291) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 726, DateTimeKind.Utc).AddTicks(3294), new DateTime(2026, 3, 19, 19, 41, 42, 726, DateTimeKind.Utc).AddTicks(3294) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 726, DateTimeKind.Utc).AddTicks(3297), new DateTime(2026, 3, 19, 19, 41, 42, 726, DateTimeKind.Utc).AddTicks(3297) });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 724, DateTimeKind.Utc).AddTicks(6535));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 724, DateTimeKind.Utc).AddTicks(6858));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 724, DateTimeKind.Utc).AddTicks(6861));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 724, DateTimeKind.Utc).AddTicks(6863));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 724, DateTimeKind.Utc).AddTicks(6864));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 724, DateTimeKind.Utc).AddTicks(6866));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 724, DateTimeKind.Utc).AddTicks(6867));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 724, DateTimeKind.Utc).AddTicks(6869));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 724, DateTimeKind.Utc).AddTicks(6870));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 724, DateTimeKind.Utc).AddTicks(6871));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 724, DateTimeKind.Utc).AddTicks(6873));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 717, DateTimeKind.Utc).AddTicks(8421));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 717, DateTimeKind.Utc).AddTicks(8779));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 717, DateTimeKind.Utc).AddTicks(8781));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 717, DateTimeKind.Utc).AddTicks(8784));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 717, DateTimeKind.Utc).AddTicks(8785));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 717, DateTimeKind.Utc).AddTicks(8787));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 721, DateTimeKind.Utc).AddTicks(3958));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 19, 41, 42, 721, DateTimeKind.Utc).AddTicks(4459));

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 726, DateTimeKind.Utc).AddTicks(9863), new DateTime(2026, 3, 19, 19, 41, 42, 727, DateTimeKind.Utc).AddTicks(179) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 727, DateTimeKind.Utc).AddTicks(484), new DateTime(2026, 3, 19, 19, 41, 42, 727, DateTimeKind.Utc).AddTicks(484) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 727, DateTimeKind.Utc).AddTicks(487), new DateTime(2026, 3, 19, 19, 41, 42, 727, DateTimeKind.Utc).AddTicks(487) });
        }
    }
}
