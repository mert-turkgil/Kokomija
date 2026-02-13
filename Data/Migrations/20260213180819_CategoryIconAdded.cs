using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kokomija.Data.Migrations
{
    /// <inheritdoc />
    public partial class CategoryIconAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IconImagePath",
                table: "Categories",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

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
                columns: new[] { "CreatedAt", "IconImagePath" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 231, DateTimeKind.Utc).AddTicks(7110), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IconImagePath" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 231, DateTimeKind.Utc).AddTicks(7533), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IconImagePath" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 231, DateTimeKind.Utc).AddTicks(7536), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "IconImagePath" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 231, DateTimeKind.Utc).AddTicks(7539), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "IconImagePath" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 231, DateTimeKind.Utc).AddTicks(7954), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "IconImagePath" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 231, DateTimeKind.Utc).AddTicks(7960), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "IconImagePath" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 231, DateTimeKind.Utc).AddTicks(7963), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "IconImagePath" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 231, DateTimeKind.Utc).AddTicks(7966), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "IconImagePath" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 231, DateTimeKind.Utc).AddTicks(7969), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "IconImagePath" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 231, DateTimeKind.Utc).AddTicks(7972), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "IconImagePath" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 231, DateTimeKind.Utc).AddTicks(8001), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "IconImagePath" },
                values: new object[] { new DateTime(2026, 2, 13, 18, 8, 17, 231, DateTimeKind.Utc).AddTicks(8004), null });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconImagePath",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 16, 57, 55, 13, DateTimeKind.Utc).AddTicks(3204), new DateTime(2026, 2, 13, 16, 57, 55, 13, DateTimeKind.Utc).AddTicks(3509) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 16, 57, 55, 13, DateTimeKind.Utc).AddTicks(3800), new DateTime(2026, 2, 13, 16, 57, 55, 13, DateTimeKind.Utc).AddTicks(3800) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 16, 57, 55, 13, DateTimeKind.Utc).AddTicks(3803), new DateTime(2026, 2, 13, 16, 57, 55, 13, DateTimeKind.Utc).AddTicks(3804) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 16, 57, 55, 13, DateTimeKind.Utc).AddTicks(3806), new DateTime(2026, 2, 13, 16, 57, 55, 13, DateTimeKind.Utc).AddTicks(3807) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 16, 57, 55, 13, DateTimeKind.Utc).AddTicks(3809), new DateTime(2026, 2, 13, 16, 57, 55, 13, DateTimeKind.Utc).AddTicks(3810) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 16, 57, 55, 14, DateTimeKind.Utc).AddTicks(5752), new DateTime(2026, 2, 13, 16, 57, 55, 14, DateTimeKind.Utc).AddTicks(6165) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 16, 57, 55, 14, DateTimeKind.Utc).AddTicks(6499), new DateTime(2026, 2, 13, 16, 57, 55, 14, DateTimeKind.Utc).AddTicks(6499) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 16, 57, 55, 13, DateTimeKind.Utc).AddTicks(8812), new DateTime(2026, 2, 13, 16, 57, 55, 13, DateTimeKind.Utc).AddTicks(7510), new DateTime(2026, 2, 13, 16, 57, 55, 13, DateTimeKind.Utc).AddTicks(9106) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 42, DateTimeKind.Utc).AddTicks(3528));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 42, DateTimeKind.Utc).AddTicks(3842));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 13, 16, 57, 55, 41, DateTimeKind.Utc).AddTicks(6582), new DateTime(2026, 2, 13, 16, 57, 55, 41, DateTimeKind.Utc).AddTicks(6239) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 11, DateTimeKind.Utc).AddTicks(9685));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 12, DateTimeKind.Utc).AddTicks(190));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 12, DateTimeKind.Utc).AddTicks(193));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 12, DateTimeKind.Utc).AddTicks(196));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 12, DateTimeKind.Utc).AddTicks(577));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 12, DateTimeKind.Utc).AddTicks(583));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 12, DateTimeKind.Utc).AddTicks(586));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 12, DateTimeKind.Utc).AddTicks(589));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 12, DateTimeKind.Utc).AddTicks(592));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 12, DateTimeKind.Utc).AddTicks(595));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 12, DateTimeKind.Utc).AddTicks(598));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 12, DateTimeKind.Utc).AddTicks(601));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 10, DateTimeKind.Utc).AddTicks(7719));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 10, DateTimeKind.Utc).AddTicks(8037));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 10, DateTimeKind.Utc).AddTicks(8039));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 10, DateTimeKind.Utc).AddTicks(8041));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 10, DateTimeKind.Utc).AddTicks(8043));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 10, DateTimeKind.Utc).AddTicks(8046));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 10, DateTimeKind.Utc).AddTicks(8048));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 10, DateTimeKind.Utc).AddTicks(8050));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2026, 2, 13, 16, 57, 55, 18, DateTimeKind.Utc).AddTicks(8734), new DateTime(2026, 2, 13, 16, 57, 55, 18, DateTimeKind.Utc).AddTicks(6989), new DateTime(2026, 8, 13, 16, 57, 55, 18, DateTimeKind.Utc).AddTicks(7305) });

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 9, DateTimeKind.Utc).AddTicks(9935));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 10, DateTimeKind.Utc).AddTicks(315));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 10, DateTimeKind.Utc).AddTicks(317));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 10, DateTimeKind.Utc).AddTicks(319));

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 19, DateTimeKind.Utc).AddTicks(3089));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 20, DateTimeKind.Utc).AddTicks(8929));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 20, DateTimeKind.Utc).AddTicks(9257));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 20, DateTimeKind.Utc).AddTicks(9260));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 20, DateTimeKind.Utc).AddTicks(9262));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 20, DateTimeKind.Utc).AddTicks(9265));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 20, DateTimeKind.Utc).AddTicks(9271));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 20, DateTimeKind.Utc).AddTicks(9273));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 20, DateTimeKind.Utc).AddTicks(9275));

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 16, 57, 55, 21, DateTimeKind.Utc).AddTicks(7503), new DateTime(2026, 2, 13, 16, 57, 55, 21, DateTimeKind.Utc).AddTicks(7507) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 16, 57, 55, 37, DateTimeKind.Utc).AddTicks(5543), new DateTime(2026, 2, 13, 16, 57, 55, 37, DateTimeKind.Utc).AddTicks(5550) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 16, 57, 55, 37, DateTimeKind.Utc).AddTicks(6354), new DateTime(2026, 2, 13, 16, 57, 55, 37, DateTimeKind.Utc).AddTicks(6354) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 16, 57, 55, 37, DateTimeKind.Utc).AddTicks(7634), new DateTime(2026, 2, 13, 16, 57, 55, 37, DateTimeKind.Utc).AddTicks(7635) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 16, 57, 55, 37, DateTimeKind.Utc).AddTicks(7648), new DateTime(2026, 2, 13, 16, 57, 55, 37, DateTimeKind.Utc).AddTicks(7649) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 16, 57, 55, 37, DateTimeKind.Utc).AddTicks(7667), new DateTime(2026, 2, 13, 16, 57, 55, 37, DateTimeKind.Utc).AddTicks(7667) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 16, 57, 55, 37, DateTimeKind.Utc).AddTicks(7672), new DateTime(2026, 2, 13, 16, 57, 55, 37, DateTimeKind.Utc).AddTicks(7672) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 16, 57, 55, 37, DateTimeKind.Utc).AddTicks(7678), new DateTime(2026, 2, 13, 16, 57, 55, 37, DateTimeKind.Utc).AddTicks(7678) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8061));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8435));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8440));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8446));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8449));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8484));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8487));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8490));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8493));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8498));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8501));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8503));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8506));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8509));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8511));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8514));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8517));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8521));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8524));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8526));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8529));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8532));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8534));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8537));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8540));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8543));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8547));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8550));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8552));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8555));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8558));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8561));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8563));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8568));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8571));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8574));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8577));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8580));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8583));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8599));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8602));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8605));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8608));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8610));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8613));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8616));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8619));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8622));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8624));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8627));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8631));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8633));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8636));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8639));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8642));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8644));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8647));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8650));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8653));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8655));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8658));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8661));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8664));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8666));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8669));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8674));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8676));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8679));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8682));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8685));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8687));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8690));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8693));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8701));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8704));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8707));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8710));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8713));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8716));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8719));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8721));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8724));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8727));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8729));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8732));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8735));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8738));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8740));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8743));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8746));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8748));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8751));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8754));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8757));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8759));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8762));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8765));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8768));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8770));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 40, DateTimeKind.Utc).AddTicks(8773));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 20, DateTimeKind.Utc).AddTicks(3687));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 20, DateTimeKind.Utc).AddTicks(4054));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 20, DateTimeKind.Utc).AddTicks(4058));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 20, DateTimeKind.Utc).AddTicks(4061));

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 16, 57, 55, 16, DateTimeKind.Utc).AddTicks(2098), new DateTime(2026, 2, 13, 16, 57, 55, 16, DateTimeKind.Utc).AddTicks(2408) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 16, 57, 55, 16, DateTimeKind.Utc).AddTicks(2709), new DateTime(2026, 2, 13, 16, 57, 55, 16, DateTimeKind.Utc).AddTicks(2709) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 16, 57, 55, 16, DateTimeKind.Utc).AddTicks(2713), new DateTime(2026, 2, 13, 16, 57, 55, 16, DateTimeKind.Utc).AddTicks(2714) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 16, 57, 55, 16, DateTimeKind.Utc).AddTicks(2717), new DateTime(2026, 2, 13, 16, 57, 55, 16, DateTimeKind.Utc).AddTicks(2718) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 16, 57, 55, 16, DateTimeKind.Utc).AddTicks(2720), new DateTime(2026, 2, 13, 16, 57, 55, 16, DateTimeKind.Utc).AddTicks(2721) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 16, 57, 55, 17, DateTimeKind.Utc).AddTicks(1892), new DateTime(2026, 2, 13, 16, 57, 55, 17, DateTimeKind.Utc).AddTicks(2188) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 16, 57, 55, 17, DateTimeKind.Utc).AddTicks(2481), new DateTime(2026, 2, 13, 16, 57, 55, 17, DateTimeKind.Utc).AddTicks(2481) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 16, 57, 55, 17, DateTimeKind.Utc).AddTicks(2484), new DateTime(2026, 2, 13, 16, 57, 55, 17, DateTimeKind.Utc).AddTicks(2484) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 16, 57, 55, 17, DateTimeKind.Utc).AddTicks(2487), new DateTime(2026, 2, 13, 16, 57, 55, 17, DateTimeKind.Utc).AddTicks(2488) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 16, 57, 55, 17, DateTimeKind.Utc).AddTicks(2491), new DateTime(2026, 2, 13, 16, 57, 55, 17, DateTimeKind.Utc).AddTicks(2492) });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 15, DateTimeKind.Utc).AddTicks(4026));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 15, DateTimeKind.Utc).AddTicks(4330));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 15, DateTimeKind.Utc).AddTicks(4333));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 15, DateTimeKind.Utc).AddTicks(4334));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 15, DateTimeKind.Utc).AddTicks(4336));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 15, DateTimeKind.Utc).AddTicks(4339));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 15, DateTimeKind.Utc).AddTicks(4341));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 15, DateTimeKind.Utc).AddTicks(4343));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 15, DateTimeKind.Utc).AddTicks(4344));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 15, DateTimeKind.Utc).AddTicks(4346));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 15, DateTimeKind.Utc).AddTicks(4348));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 8, DateTimeKind.Utc).AddTicks(6989));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 8, DateTimeKind.Utc).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 8, DateTimeKind.Utc).AddTicks(7316));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 8, DateTimeKind.Utc).AddTicks(7318));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 8, DateTimeKind.Utc).AddTicks(7321));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 8, DateTimeKind.Utc).AddTicks(7323));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 12, DateTimeKind.Utc).AddTicks(5984));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 13, 16, 57, 55, 12, DateTimeKind.Utc).AddTicks(6286));

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 16, 57, 55, 17, DateTimeKind.Utc).AddTicks(8842), new DateTime(2026, 2, 13, 16, 57, 55, 17, DateTimeKind.Utc).AddTicks(9140) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 16, 57, 55, 17, DateTimeKind.Utc).AddTicks(9430), new DateTime(2026, 2, 13, 16, 57, 55, 17, DateTimeKind.Utc).AddTicks(9430) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 13, 16, 57, 55, 17, DateTimeKind.Utc).AddTicks(9433), new DateTime(2026, 2, 13, 16, 57, 55, 17, DateTimeKind.Utc).AddTicks(9434) });
        }
    }
}
