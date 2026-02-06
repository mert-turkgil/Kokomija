using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kokomija.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddBusinessProfileCompanyFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyEmail",
                table: "BusinessProfiles",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPerson",
                table: "BusinessProfiles",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "BusinessProfiles",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 17, 39, 11, 765, DateTimeKind.Utc).AddTicks(375), new DateTime(2026, 2, 6, 17, 39, 11, 765, DateTimeKind.Utc).AddTicks(704) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 17, 39, 11, 765, DateTimeKind.Utc).AddTicks(1026), new DateTime(2026, 2, 6, 17, 39, 11, 765, DateTimeKind.Utc).AddTicks(1027) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 17, 39, 11, 765, DateTimeKind.Utc).AddTicks(1030), new DateTime(2026, 2, 6, 17, 39, 11, 765, DateTimeKind.Utc).AddTicks(1030) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 17, 39, 11, 765, DateTimeKind.Utc).AddTicks(1033), new DateTime(2026, 2, 6, 17, 39, 11, 765, DateTimeKind.Utc).AddTicks(1034) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 17, 39, 11, 765, DateTimeKind.Utc).AddTicks(1036), new DateTime(2026, 2, 6, 17, 39, 11, 765, DateTimeKind.Utc).AddTicks(1037) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 17, 39, 11, 766, DateTimeKind.Utc).AddTicks(4591), new DateTime(2026, 2, 6, 17, 39, 11, 766, DateTimeKind.Utc).AddTicks(4921) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 17, 39, 11, 766, DateTimeKind.Utc).AddTicks(5238), new DateTime(2026, 2, 6, 17, 39, 11, 766, DateTimeKind.Utc).AddTicks(5239) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 17, 39, 11, 765, DateTimeKind.Utc).AddTicks(6934), new DateTime(2026, 2, 6, 17, 39, 11, 765, DateTimeKind.Utc).AddTicks(5518), new DateTime(2026, 2, 6, 17, 39, 11, 765, DateTimeKind.Utc).AddTicks(7250) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 798, DateTimeKind.Utc).AddTicks(6090));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 798, DateTimeKind.Utc).AddTicks(6506));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 6, 17, 39, 11, 797, DateTimeKind.Utc).AddTicks(7090), new DateTime(2026, 2, 6, 17, 39, 11, 797, DateTimeKind.Utc).AddTicks(6635) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 763, DateTimeKind.Utc).AddTicks(4334));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 763, DateTimeKind.Utc).AddTicks(4828));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 763, DateTimeKind.Utc).AddTicks(4832));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 763, DateTimeKind.Utc).AddTicks(4835));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 763, DateTimeKind.Utc).AddTicks(5224));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 763, DateTimeKind.Utc).AddTicks(5232));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 763, DateTimeKind.Utc).AddTicks(5235));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 763, DateTimeKind.Utc).AddTicks(5239));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 763, DateTimeKind.Utc).AddTicks(5242));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 763, DateTimeKind.Utc).AddTicks(5245));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 763, DateTimeKind.Utc).AddTicks(5249));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 763, DateTimeKind.Utc).AddTicks(5252));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 762, DateTimeKind.Utc).AddTicks(560));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 762, DateTimeKind.Utc).AddTicks(900));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 762, DateTimeKind.Utc).AddTicks(902));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 762, DateTimeKind.Utc).AddTicks(905));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 762, DateTimeKind.Utc).AddTicks(907));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 762, DateTimeKind.Utc).AddTicks(910));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 762, DateTimeKind.Utc).AddTicks(912));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 762, DateTimeKind.Utc).AddTicks(915));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2026, 2, 6, 17, 39, 11, 771, DateTimeKind.Utc).AddTicks(2136), new DateTime(2026, 2, 6, 17, 39, 11, 771, DateTimeKind.Utc).AddTicks(327), new DateTime(2026, 8, 6, 17, 39, 11, 771, DateTimeKind.Utc).AddTicks(674) });

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 761, DateTimeKind.Utc).AddTicks(1521));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 761, DateTimeKind.Utc).AddTicks(1855));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 761, DateTimeKind.Utc).AddTicks(1858));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 761, DateTimeKind.Utc).AddTicks(1860));

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 771, DateTimeKind.Utc).AddTicks(6850));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 773, DateTimeKind.Utc).AddTicks(4858));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 773, DateTimeKind.Utc).AddTicks(5230));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 773, DateTimeKind.Utc).AddTicks(5234));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 773, DateTimeKind.Utc).AddTicks(5237));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 773, DateTimeKind.Utc).AddTicks(5239));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 773, DateTimeKind.Utc).AddTicks(5257));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 773, DateTimeKind.Utc).AddTicks(5291));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 773, DateTimeKind.Utc).AddTicks(5294));

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 17, 39, 11, 774, DateTimeKind.Utc).AddTicks(5606), new DateTime(2026, 2, 6, 17, 39, 11, 774, DateTimeKind.Utc).AddTicks(5608) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 17, 39, 11, 792, DateTimeKind.Utc).AddTicks(6778), new DateTime(2026, 2, 6, 17, 39, 11, 792, DateTimeKind.Utc).AddTicks(6782) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 17, 39, 11, 792, DateTimeKind.Utc).AddTicks(7773), new DateTime(2026, 2, 6, 17, 39, 11, 792, DateTimeKind.Utc).AddTicks(7773) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 17, 39, 11, 792, DateTimeKind.Utc).AddTicks(9466), new DateTime(2026, 2, 6, 17, 39, 11, 792, DateTimeKind.Utc).AddTicks(9467) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 17, 39, 11, 792, DateTimeKind.Utc).AddTicks(9487), new DateTime(2026, 2, 6, 17, 39, 11, 792, DateTimeKind.Utc).AddTicks(9487) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 17, 39, 11, 792, DateTimeKind.Utc).AddTicks(9510), new DateTime(2026, 2, 6, 17, 39, 11, 792, DateTimeKind.Utc).AddTicks(9510) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 17, 39, 11, 792, DateTimeKind.Utc).AddTicks(9518), new DateTime(2026, 2, 6, 17, 39, 11, 792, DateTimeKind.Utc).AddTicks(9519) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 17, 39, 11, 792, DateTimeKind.Utc).AddTicks(9526), new DateTime(2026, 2, 6, 17, 39, 11, 792, DateTimeKind.Utc).AddTicks(9527) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6084));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6563));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6570));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6574));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6580));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6593));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6598));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6603));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6607));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6613));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6618));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6622));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6626));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6630));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6634));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6639));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6644));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6650));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6654));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6659));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6663));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6668));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6672));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6677));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6681));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6686));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6726));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6731));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6736));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6740));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6745));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6750));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6754));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6761));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6765));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6770));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6774));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6779));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6783));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6787));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6792));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6796));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6801));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6805));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6810));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6814));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6819));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6823));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6827));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6832));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6837));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6841));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6846));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6850));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6855));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6859));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6864));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6868));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6872));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6877));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6881));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6885));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6889));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6906));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6911));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6917));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6921));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6926));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6930));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6934));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6939));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6943));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6947));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6952));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6956));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6961));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6966));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6970));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6975));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6979));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6984));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6988));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6993));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(6997));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(7002));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(7006));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(7011));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(7015));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(7019));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(7023));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(7028));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(7032));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(7036));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(7041));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(7045));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(7050));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(7054));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(7068));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(7073));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 796, DateTimeKind.Utc).AddTicks(7077));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 772, DateTimeKind.Utc).AddTicks(8453));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 772, DateTimeKind.Utc).AddTicks(8781));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 772, DateTimeKind.Utc).AddTicks(8786));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 772, DateTimeKind.Utc).AddTicks(8791));

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 17, 39, 11, 768, DateTimeKind.Utc).AddTicks(2043), new DateTime(2026, 2, 6, 17, 39, 11, 768, DateTimeKind.Utc).AddTicks(2375) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 17, 39, 11, 768, DateTimeKind.Utc).AddTicks(2720), new DateTime(2026, 2, 6, 17, 39, 11, 768, DateTimeKind.Utc).AddTicks(2721) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 17, 39, 11, 768, DateTimeKind.Utc).AddTicks(2724), new DateTime(2026, 2, 6, 17, 39, 11, 768, DateTimeKind.Utc).AddTicks(2725) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 17, 39, 11, 768, DateTimeKind.Utc).AddTicks(2728), new DateTime(2026, 2, 6, 17, 39, 11, 768, DateTimeKind.Utc).AddTicks(2729) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 17, 39, 11, 768, DateTimeKind.Utc).AddTicks(2732), new DateTime(2026, 2, 6, 17, 39, 11, 768, DateTimeKind.Utc).AddTicks(2732) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 17, 39, 11, 769, DateTimeKind.Utc).AddTicks(3185), new DateTime(2026, 2, 6, 17, 39, 11, 769, DateTimeKind.Utc).AddTicks(3558) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 17, 39, 11, 769, DateTimeKind.Utc).AddTicks(3884), new DateTime(2026, 2, 6, 17, 39, 11, 769, DateTimeKind.Utc).AddTicks(3885) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 17, 39, 11, 769, DateTimeKind.Utc).AddTicks(3888), new DateTime(2026, 2, 6, 17, 39, 11, 769, DateTimeKind.Utc).AddTicks(3889) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 17, 39, 11, 769, DateTimeKind.Utc).AddTicks(3892), new DateTime(2026, 2, 6, 17, 39, 11, 769, DateTimeKind.Utc).AddTicks(3893) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 17, 39, 11, 769, DateTimeKind.Utc).AddTicks(3897), new DateTime(2026, 2, 6, 17, 39, 11, 769, DateTimeKind.Utc).AddTicks(3898) });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 767, DateTimeKind.Utc).AddTicks(3776));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 767, DateTimeKind.Utc).AddTicks(4111));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 767, DateTimeKind.Utc).AddTicks(4113));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 767, DateTimeKind.Utc).AddTicks(4115));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 767, DateTimeKind.Utc).AddTicks(4117));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 767, DateTimeKind.Utc).AddTicks(4120));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 767, DateTimeKind.Utc).AddTicks(4122));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 767, DateTimeKind.Utc).AddTicks(4124));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 767, DateTimeKind.Utc).AddTicks(4126));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 767, DateTimeKind.Utc).AddTicks(4128));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 767, DateTimeKind.Utc).AddTicks(4130));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 759, DateTimeKind.Utc).AddTicks(5802));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 759, DateTimeKind.Utc).AddTicks(6155));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 759, DateTimeKind.Utc).AddTicks(6157));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 759, DateTimeKind.Utc).AddTicks(6160));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 759, DateTimeKind.Utc).AddTicks(6162));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 759, DateTimeKind.Utc).AddTicks(6165));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 764, DateTimeKind.Utc).AddTicks(1334));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 17, 39, 11, 764, DateTimeKind.Utc).AddTicks(1657));

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 17, 39, 11, 770, DateTimeKind.Utc).AddTicks(1187), new DateTime(2026, 2, 6, 17, 39, 11, 770, DateTimeKind.Utc).AddTicks(1550) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 17, 39, 11, 770, DateTimeKind.Utc).AddTicks(1874), new DateTime(2026, 2, 6, 17, 39, 11, 770, DateTimeKind.Utc).AddTicks(1874) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 17, 39, 11, 770, DateTimeKind.Utc).AddTicks(1878), new DateTime(2026, 2, 6, 17, 39, 11, 770, DateTimeKind.Utc).AddTicks(1878) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyEmail",
                table: "BusinessProfiles");

            migrationBuilder.DropColumn(
                name: "ContactPerson",
                table: "BusinessProfiles");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "BusinessProfiles");

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 780, DateTimeKind.Utc).AddTicks(8275), new DateTime(2026, 2, 6, 16, 45, 39, 780, DateTimeKind.Utc).AddTicks(8602) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 780, DateTimeKind.Utc).AddTicks(8921), new DateTime(2026, 2, 6, 16, 45, 39, 780, DateTimeKind.Utc).AddTicks(8922) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 780, DateTimeKind.Utc).AddTicks(8925), new DateTime(2026, 2, 6, 16, 45, 39, 780, DateTimeKind.Utc).AddTicks(8925) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 780, DateTimeKind.Utc).AddTicks(8928), new DateTime(2026, 2, 6, 16, 45, 39, 780, DateTimeKind.Utc).AddTicks(8929) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 780, DateTimeKind.Utc).AddTicks(8932), new DateTime(2026, 2, 6, 16, 45, 39, 780, DateTimeKind.Utc).AddTicks(8932) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 782, DateTimeKind.Utc).AddTicks(6081), new DateTime(2026, 2, 6, 16, 45, 39, 782, DateTimeKind.Utc).AddTicks(6563) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 782, DateTimeKind.Utc).AddTicks(7000), new DateTime(2026, 2, 6, 16, 45, 39, 782, DateTimeKind.Utc).AddTicks(7001) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 781, DateTimeKind.Utc).AddTicks(6387), new DateTime(2026, 2, 6, 16, 45, 39, 781, DateTimeKind.Utc).AddTicks(4614), new DateTime(2026, 2, 6, 16, 45, 39, 781, DateTimeKind.Utc).AddTicks(6792) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 826, DateTimeKind.Utc).AddTicks(6487));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 826, DateTimeKind.Utc).AddTicks(6834));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 825, DateTimeKind.Utc).AddTicks(6922), new DateTime(2026, 2, 6, 16, 45, 39, 825, DateTimeKind.Utc).AddTicks(6491) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 778, DateTimeKind.Utc).AddTicks(2677));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 778, DateTimeKind.Utc).AddTicks(3711));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 778, DateTimeKind.Utc).AddTicks(3715));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 778, DateTimeKind.Utc).AddTicks(3718));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 778, DateTimeKind.Utc).AddTicks(4332));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 778, DateTimeKind.Utc).AddTicks(4349));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 778, DateTimeKind.Utc).AddTicks(4356));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 778, DateTimeKind.Utc).AddTicks(4363));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 778, DateTimeKind.Utc).AddTicks(4367));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 778, DateTimeKind.Utc).AddTicks(4373));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 778, DateTimeKind.Utc).AddTicks(4377));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 778, DateTimeKind.Utc).AddTicks(4381));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 776, DateTimeKind.Utc).AddTicks(3069));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 776, DateTimeKind.Utc).AddTicks(3425));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 776, DateTimeKind.Utc).AddTicks(3428));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 776, DateTimeKind.Utc).AddTicks(3430));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 776, DateTimeKind.Utc).AddTicks(3433));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 776, DateTimeKind.Utc).AddTicks(3468));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 776, DateTimeKind.Utc).AddTicks(3471));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 776, DateTimeKind.Utc).AddTicks(3474));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 789, DateTimeKind.Utc).AddTicks(8066), new DateTime(2026, 2, 6, 16, 45, 39, 789, DateTimeKind.Utc).AddTicks(5856), new DateTime(2026, 8, 6, 16, 45, 39, 789, DateTimeKind.Utc).AddTicks(6245) });

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 774, DateTimeKind.Utc).AddTicks(3631));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 774, DateTimeKind.Utc).AddTicks(4226));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 774, DateTimeKind.Utc).AddTicks(4229));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 774, DateTimeKind.Utc).AddTicks(4232));

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 790, DateTimeKind.Utc).AddTicks(4372));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 792, DateTimeKind.Utc).AddTicks(2930));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 792, DateTimeKind.Utc).AddTicks(3309));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 792, DateTimeKind.Utc).AddTicks(3314));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 792, DateTimeKind.Utc).AddTicks(3318));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 792, DateTimeKind.Utc).AddTicks(3321));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 792, DateTimeKind.Utc).AddTicks(3336));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 792, DateTimeKind.Utc).AddTicks(3339));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 792, DateTimeKind.Utc).AddTicks(3342));

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 794, DateTimeKind.Utc).AddTicks(9488), new DateTime(2026, 2, 6, 16, 45, 39, 794, DateTimeKind.Utc).AddTicks(9492) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 819, DateTimeKind.Utc).AddTicks(3911), new DateTime(2026, 2, 6, 16, 45, 39, 819, DateTimeKind.Utc).AddTicks(3916) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 819, DateTimeKind.Utc).AddTicks(4944), new DateTime(2026, 2, 6, 16, 45, 39, 819, DateTimeKind.Utc).AddTicks(4945) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 819, DateTimeKind.Utc).AddTicks(6730), new DateTime(2026, 2, 6, 16, 45, 39, 819, DateTimeKind.Utc).AddTicks(6731) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 819, DateTimeKind.Utc).AddTicks(6752), new DateTime(2026, 2, 6, 16, 45, 39, 819, DateTimeKind.Utc).AddTicks(6752) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 819, DateTimeKind.Utc).AddTicks(6778), new DateTime(2026, 2, 6, 16, 45, 39, 819, DateTimeKind.Utc).AddTicks(6778) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 819, DateTimeKind.Utc).AddTicks(6790), new DateTime(2026, 2, 6, 16, 45, 39, 819, DateTimeKind.Utc).AddTicks(6790) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 819, DateTimeKind.Utc).AddTicks(6838), new DateTime(2026, 2, 6, 16, 45, 39, 819, DateTimeKind.Utc).AddTicks(6838) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(1867));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2697));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2720));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2728));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2747));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2770));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2781));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2788));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2798));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2818));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2835));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2845));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2855));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2864));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2877));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2887));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2896));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2909));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2920));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2932));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2943));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(2998));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3008));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3014));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3023));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3029));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3049));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3055));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3073));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3080));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3088));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3093));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3102));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3107));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3112));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3118));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3123));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3128));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3133));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3138));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3143));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3148));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3153));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3158));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3167));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3172));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3178));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3183));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3191));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3198));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3205));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3212));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3217));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3223));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3231));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3237));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3247));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3279));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3288));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3294));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3299));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3306));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3311));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3317));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3329));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3339));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3349));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3356));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3365));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3373));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3379));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3385));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3392));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3398));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3406));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3418));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3425));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3435));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3447));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3634));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3640));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3648));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3655));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3661));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3669));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3686));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3694));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3701));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3706));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3712));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3720));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3741));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3750));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3759));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3766));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3773));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3779));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 824, DateTimeKind.Utc).AddTicks(3790));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 791, DateTimeKind.Utc).AddTicks(6873));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 791, DateTimeKind.Utc).AddTicks(7254));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 791, DateTimeKind.Utc).AddTicks(7259));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 791, DateTimeKind.Utc).AddTicks(7263));

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 785, DateTimeKind.Utc).AddTicks(6519), new DateTime(2026, 2, 6, 16, 45, 39, 785, DateTimeKind.Utc).AddTicks(6857) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 785, DateTimeKind.Utc).AddTicks(7180), new DateTime(2026, 2, 6, 16, 45, 39, 785, DateTimeKind.Utc).AddTicks(7181) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 785, DateTimeKind.Utc).AddTicks(7184), new DateTime(2026, 2, 6, 16, 45, 39, 785, DateTimeKind.Utc).AddTicks(7185) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 785, DateTimeKind.Utc).AddTicks(7188), new DateTime(2026, 2, 6, 16, 45, 39, 785, DateTimeKind.Utc).AddTicks(7188) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 785, DateTimeKind.Utc).AddTicks(7191), new DateTime(2026, 2, 6, 16, 45, 39, 785, DateTimeKind.Utc).AddTicks(7192) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 786, DateTimeKind.Utc).AddTicks(8634), new DateTime(2026, 2, 6, 16, 45, 39, 786, DateTimeKind.Utc).AddTicks(8950) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 786, DateTimeKind.Utc).AddTicks(9264), new DateTime(2026, 2, 6, 16, 45, 39, 786, DateTimeKind.Utc).AddTicks(9265) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 786, DateTimeKind.Utc).AddTicks(9268), new DateTime(2026, 2, 6, 16, 45, 39, 786, DateTimeKind.Utc).AddTicks(9269) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 786, DateTimeKind.Utc).AddTicks(9272), new DateTime(2026, 2, 6, 16, 45, 39, 786, DateTimeKind.Utc).AddTicks(9273) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 786, DateTimeKind.Utc).AddTicks(9277), new DateTime(2026, 2, 6, 16, 45, 39, 786, DateTimeKind.Utc).AddTicks(9278) });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 784, DateTimeKind.Utc).AddTicks(4612));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 784, DateTimeKind.Utc).AddTicks(5061));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 784, DateTimeKind.Utc).AddTicks(5063));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 784, DateTimeKind.Utc).AddTicks(5066));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 784, DateTimeKind.Utc).AddTicks(5068));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 784, DateTimeKind.Utc).AddTicks(5071));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 784, DateTimeKind.Utc).AddTicks(5073));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 784, DateTimeKind.Utc).AddTicks(5075));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 784, DateTimeKind.Utc).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 784, DateTimeKind.Utc).AddTicks(5079));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 784, DateTimeKind.Utc).AddTicks(5081));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 771, DateTimeKind.Utc).AddTicks(7543));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 771, DateTimeKind.Utc).AddTicks(8365));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 771, DateTimeKind.Utc).AddTicks(8370));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 771, DateTimeKind.Utc).AddTicks(8373));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 771, DateTimeKind.Utc).AddTicks(8377));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 771, DateTimeKind.Utc).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 779, DateTimeKind.Utc).AddTicks(8652));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 6, 16, 45, 39, 779, DateTimeKind.Utc).AddTicks(9064));

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 787, DateTimeKind.Utc).AddTicks(6843), new DateTime(2026, 2, 6, 16, 45, 39, 787, DateTimeKind.Utc).AddTicks(7291) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 787, DateTimeKind.Utc).AddTicks(7795), new DateTime(2026, 2, 6, 16, 45, 39, 787, DateTimeKind.Utc).AddTicks(7796) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 6, 16, 45, 39, 787, DateTimeKind.Utc).AddTicks(7799), new DateTime(2026, 2, 6, 16, 45, 39, 787, DateTimeKind.Utc).AddTicks(7800) });
        }
    }
}
