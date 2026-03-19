using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kokomija.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEanCodeToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EanCode",
                table: "Products",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true);

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
                columns: new[] { "CreatedAt", "RouteParameters" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 735, DateTimeKind.Utc).AddTicks(7131), "{\"sort\":\"newest\"}" });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "RouteParameters" },
                values: new object[] { new DateTime(2026, 3, 19, 19, 41, 42, 735, DateTimeKind.Utc).AddTicks(7468), "{\"sort\":\"newest\"}" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EanCode",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 695, DateTimeKind.Utc).AddTicks(2928), new DateTime(2026, 3, 13, 14, 13, 4, 695, DateTimeKind.Utc).AddTicks(3252) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 695, DateTimeKind.Utc).AddTicks(3566), new DateTime(2026, 3, 13, 14, 13, 4, 695, DateTimeKind.Utc).AddTicks(3567) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 695, DateTimeKind.Utc).AddTicks(3569), new DateTime(2026, 3, 13, 14, 13, 4, 695, DateTimeKind.Utc).AddTicks(3570) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 695, DateTimeKind.Utc).AddTicks(3572), new DateTime(2026, 3, 13, 14, 13, 4, 695, DateTimeKind.Utc).AddTicks(3572) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 695, DateTimeKind.Utc).AddTicks(3596), new DateTime(2026, 3, 13, 14, 13, 4, 695, DateTimeKind.Utc).AddTicks(3596) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 696, DateTimeKind.Utc).AddTicks(5875), new DateTime(2026, 3, 13, 14, 13, 4, 696, DateTimeKind.Utc).AddTicks(6196) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 696, DateTimeKind.Utc).AddTicks(6506), new DateTime(2026, 3, 13, 14, 13, 4, 696, DateTimeKind.Utc).AddTicks(6506) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 695, DateTimeKind.Utc).AddTicks(9006), new DateTime(2026, 3, 13, 14, 13, 4, 695, DateTimeKind.Utc).AddTicks(7639), new DateTime(2026, 3, 13, 14, 13, 4, 695, DateTimeKind.Utc).AddTicks(9321) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "RouteParameters" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 710, DateTimeKind.Utc).AddTicks(2636), null });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "RouteParameters" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 710, DateTimeKind.Utc).AddTicks(3141), null });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 709, DateTimeKind.Utc).AddTicks(2976), new DateTime(2026, 3, 13, 14, 13, 4, 709, DateTimeKind.Utc).AddTicks(2458) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 694, DateTimeKind.Utc).AddTicks(674));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 694, DateTimeKind.Utc).AddTicks(1014));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 694, DateTimeKind.Utc).AddTicks(1017));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 694, DateTimeKind.Utc).AddTicks(1019));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 694, DateTimeKind.Utc).AddTicks(1357));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 694, DateTimeKind.Utc).AddTicks(1363));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 694, DateTimeKind.Utc).AddTicks(1365));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 694, DateTimeKind.Utc).AddTicks(1367));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 694, DateTimeKind.Utc).AddTicks(1369));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 694, DateTimeKind.Utc).AddTicks(1371));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 694, DateTimeKind.Utc).AddTicks(1374));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 694, DateTimeKind.Utc).AddTicks(1376));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 692, DateTimeKind.Utc).AddTicks(9745));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 693, DateTimeKind.Utc).AddTicks(69));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 693, DateTimeKind.Utc).AddTicks(72));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 693, DateTimeKind.Utc).AddTicks(74));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 693, DateTimeKind.Utc).AddTicks(76));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 693, DateTimeKind.Utc).AddTicks(77));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 693, DateTimeKind.Utc).AddTicks(79));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 693, DateTimeKind.Utc).AddTicks(81));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 700, DateTimeKind.Utc).AddTicks(7782), new DateTime(2026, 3, 13, 14, 13, 4, 700, DateTimeKind.Utc).AddTicks(5800), new DateTime(2026, 9, 13, 14, 13, 4, 700, DateTimeKind.Utc).AddTicks(6143) });

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 692, DateTimeKind.Utc).AddTicks(3273));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 692, DateTimeKind.Utc).AddTicks(3609));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 692, DateTimeKind.Utc).AddTicks(3611));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 692, DateTimeKind.Utc).AddTicks(3613));

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 701, DateTimeKind.Utc).AddTicks(2666));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 702, DateTimeKind.Utc).AddTicks(7445));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 702, DateTimeKind.Utc).AddTicks(7797));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 702, DateTimeKind.Utc).AddTicks(7800));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 702, DateTimeKind.Utc).AddTicks(7802));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 702, DateTimeKind.Utc).AddTicks(7803));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 702, DateTimeKind.Utc).AddTicks(7820));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 702, DateTimeKind.Utc).AddTicks(7822));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 702, DateTimeKind.Utc).AddTicks(7823));

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 703, DateTimeKind.Utc).AddTicks(6736), new DateTime(2026, 3, 13, 14, 13, 4, 703, DateTimeKind.Utc).AddTicks(6738) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 704, DateTimeKind.Utc).AddTicks(4695), new DateTime(2026, 3, 13, 14, 13, 4, 704, DateTimeKind.Utc).AddTicks(4698) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 704, DateTimeKind.Utc).AddTicks(6382), new DateTime(2026, 3, 13, 14, 13, 4, 704, DateTimeKind.Utc).AddTicks(6383) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 704, DateTimeKind.Utc).AddTicks(9438), new DateTime(2026, 3, 13, 14, 13, 4, 704, DateTimeKind.Utc).AddTicks(9439) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 704, DateTimeKind.Utc).AddTicks(9553), new DateTime(2026, 3, 13, 14, 13, 4, 704, DateTimeKind.Utc).AddTicks(9553) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 704, DateTimeKind.Utc).AddTicks(9589), new DateTime(2026, 3, 13, 14, 13, 4, 704, DateTimeKind.Utc).AddTicks(9590) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 704, DateTimeKind.Utc).AddTicks(9598), new DateTime(2026, 3, 13, 14, 13, 4, 704, DateTimeKind.Utc).AddTicks(9598) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 704, DateTimeKind.Utc).AddTicks(9605), new DateTime(2026, 3, 13, 14, 13, 4, 704, DateTimeKind.Utc).AddTicks(9605) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(3798));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4238));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4242));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4246));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4249));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4261));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4263));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4266));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4268));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4272));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4274));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4277));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4300));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4302));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4304));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4307));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4309));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4315));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4318));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4320));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4323));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4325));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4328));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4330));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4334));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4337));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4339));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4342));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4344));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4347));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4349));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4351));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4355));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4357));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4360));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4362));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4364));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4367));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4369));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4371));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4374));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4376));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4379));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4381));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4384));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4386));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4398));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4400));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4403));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4405));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4408));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4410));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4412));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4415));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4417));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4419));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4422));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4424));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4427));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4430));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4432));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4434));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4436));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4438));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4442));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4444));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4446));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4448));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4451));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4454));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4456));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4459));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4461));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4464));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4467));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4469));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4471));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4474));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4476));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4478));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4481));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4491));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4493));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4495));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4498));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4500));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4502));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4504));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4507));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4512));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4514));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4516));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4518));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4521));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4524));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4526));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4528));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 708, DateTimeKind.Utc).AddTicks(4531));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 702, DateTimeKind.Utc).AddTicks(2280));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 702, DateTimeKind.Utc).AddTicks(2608));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 702, DateTimeKind.Utc).AddTicks(2612));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 702, DateTimeKind.Utc).AddTicks(2615));

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 697, DateTimeKind.Utc).AddTicks(9856), new DateTime(2026, 3, 13, 14, 13, 4, 698, DateTimeKind.Utc).AddTicks(178) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 698, DateTimeKind.Utc).AddTicks(504), new DateTime(2026, 3, 13, 14, 13, 4, 698, DateTimeKind.Utc).AddTicks(505) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 698, DateTimeKind.Utc).AddTicks(507), new DateTime(2026, 3, 13, 14, 13, 4, 698, DateTimeKind.Utc).AddTicks(508) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 698, DateTimeKind.Utc).AddTicks(510), new DateTime(2026, 3, 13, 14, 13, 4, 698, DateTimeKind.Utc).AddTicks(510) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 698, DateTimeKind.Utc).AddTicks(513), new DateTime(2026, 3, 13, 14, 13, 4, 698, DateTimeKind.Utc).AddTicks(514) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 698, DateTimeKind.Utc).AddTicks(8715), new DateTime(2026, 3, 13, 14, 13, 4, 698, DateTimeKind.Utc).AddTicks(9220) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 698, DateTimeKind.Utc).AddTicks(9635), new DateTime(2026, 3, 13, 14, 13, 4, 698, DateTimeKind.Utc).AddTicks(9636) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 698, DateTimeKind.Utc).AddTicks(9639), new DateTime(2026, 3, 13, 14, 13, 4, 698, DateTimeKind.Utc).AddTicks(9639) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 698, DateTimeKind.Utc).AddTicks(9642), new DateTime(2026, 3, 13, 14, 13, 4, 698, DateTimeKind.Utc).AddTicks(9642) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 698, DateTimeKind.Utc).AddTicks(9644), new DateTime(2026, 3, 13, 14, 13, 4, 698, DateTimeKind.Utc).AddTicks(9645) });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 697, DateTimeKind.Utc).AddTicks(2795));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 697, DateTimeKind.Utc).AddTicks(3119));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 697, DateTimeKind.Utc).AddTicks(3121));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 697, DateTimeKind.Utc).AddTicks(3125));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 697, DateTimeKind.Utc).AddTicks(3127));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 697, DateTimeKind.Utc).AddTicks(3129));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 697, DateTimeKind.Utc).AddTicks(3130));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 697, DateTimeKind.Utc).AddTicks(3132));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 697, DateTimeKind.Utc).AddTicks(3133));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 697, DateTimeKind.Utc).AddTicks(3134));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 697, DateTimeKind.Utc).AddTicks(3136));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 690, DateTimeKind.Utc).AddTicks(9292));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 690, DateTimeKind.Utc).AddTicks(9636));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 690, DateTimeKind.Utc).AddTicks(9638));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 690, DateTimeKind.Utc).AddTicks(9641));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 690, DateTimeKind.Utc).AddTicks(9655));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 690, DateTimeKind.Utc).AddTicks(9657));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 694, DateTimeKind.Utc).AddTicks(6577));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 694, DateTimeKind.Utc).AddTicks(6900));

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 699, DateTimeKind.Utc).AddTicks(6015), new DateTime(2026, 3, 13, 14, 13, 4, 699, DateTimeKind.Utc).AddTicks(6467) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 699, DateTimeKind.Utc).AddTicks(6954), new DateTime(2026, 3, 13, 14, 13, 4, 699, DateTimeKind.Utc).AddTicks(6954) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 699, DateTimeKind.Utc).AddTicks(6957), new DateTime(2026, 3, 13, 14, 13, 4, 699, DateTimeKind.Utc).AddTicks(6957) });
        }
    }
}
