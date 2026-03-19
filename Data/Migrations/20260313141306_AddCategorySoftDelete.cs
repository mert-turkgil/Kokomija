using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kokomija.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCategorySoftDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Categories",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 710, DateTimeKind.Utc).AddTicks(2636));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 13, 14, 13, 4, 710, DateTimeKind.Utc).AddTicks(3141));

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
                columns: new[] { "CreatedAt", "DeletedAt", "DeletedBy", "IsDeleted" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 694, DateTimeKind.Utc).AddTicks(674), null, null, false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DeletedAt", "DeletedBy", "IsDeleted" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 694, DateTimeKind.Utc).AddTicks(1014), null, null, false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "DeletedAt", "DeletedBy", "IsDeleted" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 694, DateTimeKind.Utc).AddTicks(1017), null, null, false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "DeletedAt", "DeletedBy", "IsDeleted" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 694, DateTimeKind.Utc).AddTicks(1019), null, null, false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "DeletedAt", "DeletedBy", "IsDeleted" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 694, DateTimeKind.Utc).AddTicks(1357), null, null, false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "DeletedAt", "DeletedBy", "IsDeleted" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 694, DateTimeKind.Utc).AddTicks(1363), null, null, false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "DeletedAt", "DeletedBy", "IsDeleted" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 694, DateTimeKind.Utc).AddTicks(1365), null, null, false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "DeletedAt", "DeletedBy", "IsDeleted" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 694, DateTimeKind.Utc).AddTicks(1367), null, null, false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "DeletedAt", "DeletedBy", "IsDeleted" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 694, DateTimeKind.Utc).AddTicks(1369), null, null, false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "DeletedAt", "DeletedBy", "IsDeleted" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 694, DateTimeKind.Utc).AddTicks(1371), null, null, false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "DeletedAt", "DeletedBy", "IsDeleted" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 694, DateTimeKind.Utc).AddTicks(1374), null, null, false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "DeletedAt", "DeletedBy", "IsDeleted" },
                values: new object[] { new DateTime(2026, 3, 13, 14, 13, 4, 694, DateTimeKind.Utc).AddTicks(1376), null, null, false });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 233, DateTimeKind.Utc).AddTicks(1266), new DateTime(2026, 2, 13, 18, 8, 17, 233, DateTimeKind.Utc).AddTicks(1568) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 233, DateTimeKind.Utc).AddTicks(1864), new DateTime(2026, 2, 13, 18, 8, 17, 233, DateTimeKind.Utc).AddTicks(1864) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 233, DateTimeKind.Utc).AddTicks(1867), new DateTime(2026, 2, 13, 18, 8, 17, 233, DateTimeKind.Utc).AddTicks(1868) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 233, DateTimeKind.Utc).AddTicks(1871), new DateTime(2026, 2, 13, 18, 8, 17, 233, DateTimeKind.Utc).AddTicks(1871) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 233, DateTimeKind.Utc).AddTicks(1874), new DateTime(2026, 2, 13, 18, 8, 17, 233, DateTimeKind.Utc).AddTicks(1874) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 234, DateTimeKind.Utc).AddTicks(5480), new DateTime(2026, 2, 13, 18, 8, 17, 234, DateTimeKind.Utc).AddTicks(6032) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 234, DateTimeKind.Utc).AddTicks(6590), new DateTime(2026, 2, 13, 18, 8, 17, 234, DateTimeKind.Utc).AddTicks(6591) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 233, DateTimeKind.Utc).AddTicks(7807), new DateTime(2026, 2, 13, 18, 8, 17, 233, DateTimeKind.Utc).AddTicks(6492), new DateTime(2026, 2, 13, 18, 8, 17, 233, DateTimeKind.Utc).AddTicks(8201) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 263, DateTimeKind.Utc).AddTicks(3368));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 263, DateTimeKind.Utc).AddTicks(3682));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 262, DateTimeKind.Utc).AddTicks(6352), new DateTime(2026, 2, 13, 18, 8, 17, 262, DateTimeKind.Utc).AddTicks(6007) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 231, DateTimeKind.Utc).AddTicks(7110));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 231, DateTimeKind.Utc).AddTicks(7533));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 231, DateTimeKind.Utc).AddTicks(7536));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 231, DateTimeKind.Utc).AddTicks(7539));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 231, DateTimeKind.Utc).AddTicks(7954));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 231, DateTimeKind.Utc).AddTicks(7960));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 231, DateTimeKind.Utc).AddTicks(7963));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 231, DateTimeKind.Utc).AddTicks(7966));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 231, DateTimeKind.Utc).AddTicks(7969));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 231, DateTimeKind.Utc).AddTicks(7972));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 231, DateTimeKind.Utc).AddTicks(8001));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 231, DateTimeKind.Utc).AddTicks(8004));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 230, DateTimeKind.Utc).AddTicks(4742));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 230, DateTimeKind.Utc).AddTicks(5063));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 230, DateTimeKind.Utc).AddTicks(5066));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 230, DateTimeKind.Utc).AddTicks(5068));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 230, DateTimeKind.Utc).AddTicks(5070));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 230, DateTimeKind.Utc).AddTicks(5073));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 230, DateTimeKind.Utc).AddTicks(5075));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 230, DateTimeKind.Utc).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 239, DateTimeKind.Utc).AddTicks(92), new DateTime(2026, 2, 13, 18, 8, 17, 238, DateTimeKind.Utc).AddTicks(8277), new DateTime(2026, 8, 13, 18, 8, 17, 238, DateTimeKind.Utc).AddTicks(8602) });

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 229, DateTimeKind.Utc).AddTicks(6131));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 229, DateTimeKind.Utc).AddTicks(6597));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 229, DateTimeKind.Utc).AddTicks(6600));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 229, DateTimeKind.Utc).AddTicks(6602));

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 239, DateTimeKind.Utc).AddTicks(4987));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 241, DateTimeKind.Utc).AddTicks(2108));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 241, DateTimeKind.Utc).AddTicks(2429));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 241, DateTimeKind.Utc).AddTicks(2432));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 241, DateTimeKind.Utc).AddTicks(2434));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 241, DateTimeKind.Utc).AddTicks(2436));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 241, DateTimeKind.Utc).AddTicks(2444));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 241, DateTimeKind.Utc).AddTicks(2446));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 241, DateTimeKind.Utc).AddTicks(2448));

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 242, DateTimeKind.Utc).AddTicks(643), new DateTime(2026, 2, 13, 18, 8, 17, 242, DateTimeKind.Utc).AddTicks(645) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 258, DateTimeKind.Utc).AddTicks(5768), new DateTime(2026, 2, 13, 18, 8, 17, 258, DateTimeKind.Utc).AddTicks(5773) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 258, DateTimeKind.Utc).AddTicks(6573), new DateTime(2026, 2, 13, 18, 8, 17, 258, DateTimeKind.Utc).AddTicks(6574) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 258, DateTimeKind.Utc).AddTicks(7827), new DateTime(2026, 2, 13, 18, 8, 17, 258, DateTimeKind.Utc).AddTicks(7827) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 258, DateTimeKind.Utc).AddTicks(7840), new DateTime(2026, 2, 13, 18, 8, 17, 258, DateTimeKind.Utc).AddTicks(7840) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 258, DateTimeKind.Utc).AddTicks(7859), new DateTime(2026, 2, 13, 18, 8, 17, 258, DateTimeKind.Utc).AddTicks(7859) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 258, DateTimeKind.Utc).AddTicks(7865), new DateTime(2026, 2, 13, 18, 8, 17, 258, DateTimeKind.Utc).AddTicks(7866) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 258, DateTimeKind.Utc).AddTicks(7871), new DateTime(2026, 2, 13, 18, 8, 17, 258, DateTimeKind.Utc).AddTicks(7871) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7370));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7743));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7747));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7775));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7779));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7789));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7792));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7795));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7798));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7802));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7804));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7807));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7810));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7813));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7816));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7823));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7826));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7830));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7833));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7836));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7838));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7894));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7897));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7899));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7902));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7906));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7909));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7912));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7915));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7917));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7920));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7923));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7926));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7931));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7933));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7936));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7939));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7950));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7952));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7955));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7958));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7961));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7963));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7966));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7969));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7972));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7974));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7977));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7980));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7983));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7986));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7991));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7994));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(7997));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8000));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8002));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8005));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8008));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8011));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8013));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8016));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8019));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8022));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8024));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8029));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8031));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8034));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8037));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8039));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8042));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8052));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8344));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8347));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8349));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8353));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8356));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8359));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8362));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8364));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8367));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8370));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8373));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8375));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8378));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8381));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8384));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8386));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8389));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8392));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8394));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8397));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8400));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8402));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8405));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8408));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8411));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8413));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8416));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 261, DateTimeKind.Utc).AddTicks(8419));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 240, DateTimeKind.Utc).AddTicks(6710));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 240, DateTimeKind.Utc).AddTicks(7090));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 240, DateTimeKind.Utc).AddTicks(7093));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 240, DateTimeKind.Utc).AddTicks(7097));

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 236, DateTimeKind.Utc).AddTicks(2334), new DateTime(2026, 2, 13, 18, 8, 17, 236, DateTimeKind.Utc).AddTicks(2637) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 236, DateTimeKind.Utc).AddTicks(3026), new DateTime(2026, 2, 13, 18, 8, 17, 236, DateTimeKind.Utc).AddTicks(3026) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 236, DateTimeKind.Utc).AddTicks(3029), new DateTime(2026, 2, 13, 18, 8, 17, 236, DateTimeKind.Utc).AddTicks(3030) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 236, DateTimeKind.Utc).AddTicks(3033), new DateTime(2026, 2, 13, 18, 8, 17, 236, DateTimeKind.Utc).AddTicks(3033) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 236, DateTimeKind.Utc).AddTicks(3036), new DateTime(2026, 2, 13, 18, 8, 17, 236, DateTimeKind.Utc).AddTicks(3036) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 237, DateTimeKind.Utc).AddTicks(2493), new DateTime(2026, 2, 13, 18, 8, 17, 237, DateTimeKind.Utc).AddTicks(2842) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 237, DateTimeKind.Utc).AddTicks(3238), new DateTime(2026, 2, 13, 18, 8, 17, 237, DateTimeKind.Utc).AddTicks(3239) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 237, DateTimeKind.Utc).AddTicks(3242), new DateTime(2026, 2, 13, 18, 8, 17, 237, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 237, DateTimeKind.Utc).AddTicks(3246), new DateTime(2026, 2, 13, 18, 8, 17, 237, DateTimeKind.Utc).AddTicks(3246) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 237, DateTimeKind.Utc).AddTicks(3278), new DateTime(2026, 2, 13, 18, 8, 17, 237, DateTimeKind.Utc).AddTicks(3278) });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 235, DateTimeKind.Utc).AddTicks(4552));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 235, DateTimeKind.Utc).AddTicks(4872));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 235, DateTimeKind.Utc).AddTicks(4875));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 235, DateTimeKind.Utc).AddTicks(4876));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 235, DateTimeKind.Utc).AddTicks(4878));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 235, DateTimeKind.Utc).AddTicks(4880));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 235, DateTimeKind.Utc).AddTicks(4882));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 235, DateTimeKind.Utc).AddTicks(4884));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 235, DateTimeKind.Utc).AddTicks(4886));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 235, DateTimeKind.Utc).AddTicks(4888));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 235, DateTimeKind.Utc).AddTicks(4890));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 228, DateTimeKind.Utc).AddTicks(2322));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 228, DateTimeKind.Utc).AddTicks(2651));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 228, DateTimeKind.Utc).AddTicks(2653));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 228, DateTimeKind.Utc).AddTicks(2656));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 228, DateTimeKind.Utc).AddTicks(2658));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 228, DateTimeKind.Utc).AddTicks(2660));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 232, DateTimeKind.Utc).AddTicks(3844));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 18, 8, 17, 232, DateTimeKind.Utc).AddTicks(4178));

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 237, DateTimeKind.Utc).AddTicks(9891), new DateTime(2026, 2, 13, 18, 8, 17, 238, DateTimeKind.Utc).AddTicks(187) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 238, DateTimeKind.Utc).AddTicks(480), new DateTime(2026, 2, 13, 18, 8, 17, 238, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 238, DateTimeKind.Utc).AddTicks(484), new DateTime(2026, 2, 13, 18, 8, 17, 238, DateTimeKind.Utc).AddTicks(484) });
        }
    }
}
