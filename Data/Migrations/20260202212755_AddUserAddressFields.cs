using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kokomija.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAddressFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DefaultAddress",
                table: "AspNetUsers",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DefaultCity",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DefaultCountry",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DefaultPostalCode",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 984, DateTimeKind.Utc).AddTicks(8100), new DateTime(2026, 2, 2, 21, 27, 50, 984, DateTimeKind.Utc).AddTicks(8437) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 984, DateTimeKind.Utc).AddTicks(8755), new DateTime(2026, 2, 2, 21, 27, 50, 984, DateTimeKind.Utc).AddTicks(8756) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 984, DateTimeKind.Utc).AddTicks(8758), new DateTime(2026, 2, 2, 21, 27, 50, 984, DateTimeKind.Utc).AddTicks(8759) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 984, DateTimeKind.Utc).AddTicks(8762), new DateTime(2026, 2, 2, 21, 27, 50, 984, DateTimeKind.Utc).AddTicks(8762) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 984, DateTimeKind.Utc).AddTicks(8765), new DateTime(2026, 2, 2, 21, 27, 50, 984, DateTimeKind.Utc).AddTicks(8766) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 986, DateTimeKind.Utc).AddTicks(4303), new DateTime(2026, 2, 2, 21, 27, 50, 986, DateTimeKind.Utc).AddTicks(4982) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 986, DateTimeKind.Utc).AddTicks(5433), new DateTime(2026, 2, 2, 21, 27, 50, 986, DateTimeKind.Utc).AddTicks(5433) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 985, DateTimeKind.Utc).AddTicks(5864), new DateTime(2026, 2, 2, 21, 27, 50, 985, DateTimeKind.Utc).AddTicks(4450), new DateTime(2026, 2, 2, 21, 27, 50, 985, DateTimeKind.Utc).AddTicks(6178) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 40, DateTimeKind.Utc).AddTicks(380));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 40, DateTimeKind.Utc).AddTicks(1088));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 37, DateTimeKind.Utc).AddTicks(1627), new DateTime(2026, 2, 2, 21, 27, 51, 37, DateTimeKind.Utc).AddTicks(541) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 982, DateTimeKind.Utc).AddTicks(3082));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 982, DateTimeKind.Utc).AddTicks(3816));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 982, DateTimeKind.Utc).AddTicks(3832));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 982, DateTimeKind.Utc).AddTicks(3836));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 982, DateTimeKind.Utc).AddTicks(4483));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 982, DateTimeKind.Utc).AddTicks(4499));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 982, DateTimeKind.Utc).AddTicks(4503));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 982, DateTimeKind.Utc).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 982, DateTimeKind.Utc).AddTicks(4516));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 982, DateTimeKind.Utc).AddTicks(4519));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 982, DateTimeKind.Utc).AddTicks(4530));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 982, DateTimeKind.Utc).AddTicks(4534));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 979, DateTimeKind.Utc).AddTicks(7800));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 979, DateTimeKind.Utc).AddTicks(8267));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 979, DateTimeKind.Utc).AddTicks(8272));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 979, DateTimeKind.Utc).AddTicks(8276));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 979, DateTimeKind.Utc).AddTicks(8279));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 979, DateTimeKind.Utc).AddTicks(8283));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 979, DateTimeKind.Utc).AddTicks(8287));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 979, DateTimeKind.Utc).AddTicks(8291));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 993, DateTimeKind.Utc).AddTicks(2746), new DateTime(2026, 2, 2, 21, 27, 50, 993, DateTimeKind.Utc).AddTicks(99), new DateTime(2026, 8, 2, 21, 27, 50, 993, DateTimeKind.Utc).AddTicks(491) });

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 978, DateTimeKind.Utc).AddTicks(1042));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 978, DateTimeKind.Utc).AddTicks(1893));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 978, DateTimeKind.Utc).AddTicks(1897));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 978, DateTimeKind.Utc).AddTicks(1904));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 978, DateTimeKind.Utc).AddTicks(1910));

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 994, DateTimeKind.Utc).AddTicks(3060));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 998, DateTimeKind.Utc).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 998, DateTimeKind.Utc).AddTicks(7312));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 998, DateTimeKind.Utc).AddTicks(7316));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 998, DateTimeKind.Utc).AddTicks(7319));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 998, DateTimeKind.Utc).AddTicks(7321));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 998, DateTimeKind.Utc).AddTicks(7340));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 998, DateTimeKind.Utc).AddTicks(7343));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 998, DateTimeKind.Utc).AddTicks(7346));

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 0, DateTimeKind.Utc).AddTicks(6553), new DateTime(2026, 2, 2, 21, 27, 51, 0, DateTimeKind.Utc).AddTicks(6559) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 27, DateTimeKind.Utc).AddTicks(9825), new DateTime(2026, 2, 2, 21, 27, 51, 27, DateTimeKind.Utc).AddTicks(9834) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 28, DateTimeKind.Utc).AddTicks(1803), new DateTime(2026, 2, 2, 21, 27, 51, 28, DateTimeKind.Utc).AddTicks(1806) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 28, DateTimeKind.Utc).AddTicks(6544), new DateTime(2026, 2, 2, 21, 27, 51, 28, DateTimeKind.Utc).AddTicks(6553) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 28, DateTimeKind.Utc).AddTicks(6600), new DateTime(2026, 2, 2, 21, 27, 51, 28, DateTimeKind.Utc).AddTicks(6601) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 28, DateTimeKind.Utc).AddTicks(6688), new DateTime(2026, 2, 2, 21, 27, 51, 28, DateTimeKind.Utc).AddTicks(6689) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 28, DateTimeKind.Utc).AddTicks(6701), new DateTime(2026, 2, 2, 21, 27, 51, 28, DateTimeKind.Utc).AddTicks(6701) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 51, 28, DateTimeKind.Utc).AddTicks(6708), new DateTime(2026, 2, 2, 21, 27, 51, 28, DateTimeKind.Utc).AddTicks(6708) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9038));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9762));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9770));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9775));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9780));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9798));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9802));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9806));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9810));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9817));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9821));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9825));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9829));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9833));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9837));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9841));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9890));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9896));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9901));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9905));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9914));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9918));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9922));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9926));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9930));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9937));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9941));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9945));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9949));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9953));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9957));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9961));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9966));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9972));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9976));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9981));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9988));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9991));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 34, DateTimeKind.Utc).AddTicks(9995));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(5));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(9));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(13));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(17));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(21));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(25));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(30));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(34));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(38));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(42));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(47));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(51));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(70));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(75));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(80));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(84));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(97));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(101));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(105));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(109));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(113));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(118));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(121));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(125));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(130));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(138));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(142));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(146));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(150));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(154));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(159));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(163));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(167));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(172));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(176));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(181));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(185));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(189));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(194));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(198));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(203));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(207));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(211));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(215));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(219));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(225));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(228));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(234));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(257));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(264));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(269));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(274));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(278));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(283));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(287));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(291));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(296));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(300));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(305));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 51, 35, DateTimeKind.Utc).AddTicks(309));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 997, DateTimeKind.Utc).AddTicks(2901));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 997, DateTimeKind.Utc).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 997, DateTimeKind.Utc).AddTicks(3768));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 997, DateTimeKind.Utc).AddTicks(3773));

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 989, DateTimeKind.Utc).AddTicks(1341), new DateTime(2026, 2, 2, 21, 27, 50, 989, DateTimeKind.Utc).AddTicks(1694) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 989, DateTimeKind.Utc).AddTicks(2014), new DateTime(2026, 2, 2, 21, 27, 50, 989, DateTimeKind.Utc).AddTicks(2015) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 989, DateTimeKind.Utc).AddTicks(2018), new DateTime(2026, 2, 2, 21, 27, 50, 989, DateTimeKind.Utc).AddTicks(2018) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 989, DateTimeKind.Utc).AddTicks(2022), new DateTime(2026, 2, 2, 21, 27, 50, 989, DateTimeKind.Utc).AddTicks(2022) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 989, DateTimeKind.Utc).AddTicks(2026), new DateTime(2026, 2, 2, 21, 27, 50, 989, DateTimeKind.Utc).AddTicks(2026) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 990, DateTimeKind.Utc).AddTicks(5880), new DateTime(2026, 2, 2, 21, 27, 50, 990, DateTimeKind.Utc).AddTicks(6212) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 990, DateTimeKind.Utc).AddTicks(6544), new DateTime(2026, 2, 2, 21, 27, 50, 990, DateTimeKind.Utc).AddTicks(6545) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 990, DateTimeKind.Utc).AddTicks(6548), new DateTime(2026, 2, 2, 21, 27, 50, 990, DateTimeKind.Utc).AddTicks(6549) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 990, DateTimeKind.Utc).AddTicks(6552), new DateTime(2026, 2, 2, 21, 27, 50, 990, DateTimeKind.Utc).AddTicks(6553) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 990, DateTimeKind.Utc).AddTicks(6557), new DateTime(2026, 2, 2, 21, 27, 50, 990, DateTimeKind.Utc).AddTicks(6557) });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 988, DateTimeKind.Utc).AddTicks(287));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 988, DateTimeKind.Utc).AddTicks(758));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 988, DateTimeKind.Utc).AddTicks(760));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 988, DateTimeKind.Utc).AddTicks(763));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 988, DateTimeKind.Utc).AddTicks(765));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 988, DateTimeKind.Utc).AddTicks(767));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 988, DateTimeKind.Utc).AddTicks(769));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 988, DateTimeKind.Utc).AddTicks(771));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 988, DateTimeKind.Utc).AddTicks(773));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 988, DateTimeKind.Utc).AddTicks(775));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 988, DateTimeKind.Utc).AddTicks(778));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 974, DateTimeKind.Utc).AddTicks(8903));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 974, DateTimeKind.Utc).AddTicks(9509));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 974, DateTimeKind.Utc).AddTicks(9517));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 974, DateTimeKind.Utc).AddTicks(9520));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 974, DateTimeKind.Utc).AddTicks(9525));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 974, DateTimeKind.Utc).AddTicks(9533));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 983, DateTimeKind.Utc).AddTicks(3373));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 21, 27, 50, 983, DateTimeKind.Utc).AddTicks(3980));

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 991, DateTimeKind.Utc).AddTicks(5510), new DateTime(2026, 2, 2, 21, 27, 50, 991, DateTimeKind.Utc).AddTicks(5822) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 991, DateTimeKind.Utc).AddTicks(6137), new DateTime(2026, 2, 2, 21, 27, 50, 991, DateTimeKind.Utc).AddTicks(6138) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 21, 27, 50, 991, DateTimeKind.Utc).AddTicks(6141), new DateTime(2026, 2, 2, 21, 27, 50, 991, DateTimeKind.Utc).AddTicks(6141) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultAddress",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DefaultCity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DefaultCountry",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DefaultPostalCode",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 20, 29, 25, 456, DateTimeKind.Utc).AddTicks(5468), new DateTime(2026, 2, 2, 20, 29, 25, 456, DateTimeKind.Utc).AddTicks(5996) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 20, 29, 25, 456, DateTimeKind.Utc).AddTicks(6524), new DateTime(2026, 2, 2, 20, 29, 25, 456, DateTimeKind.Utc).AddTicks(6524) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 20, 29, 25, 456, DateTimeKind.Utc).AddTicks(6527), new DateTime(2026, 2, 2, 20, 29, 25, 456, DateTimeKind.Utc).AddTicks(6528) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 20, 29, 25, 456, DateTimeKind.Utc).AddTicks(6531), new DateTime(2026, 2, 2, 20, 29, 25, 456, DateTimeKind.Utc).AddTicks(6531) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 20, 29, 25, 456, DateTimeKind.Utc).AddTicks(6534), new DateTime(2026, 2, 2, 20, 29, 25, 456, DateTimeKind.Utc).AddTicks(6535) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 20, 29, 25, 459, DateTimeKind.Utc).AddTicks(38), new DateTime(2026, 2, 2, 20, 29, 25, 459, DateTimeKind.Utc).AddTicks(632) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 20, 29, 25, 459, DateTimeKind.Utc).AddTicks(1201), new DateTime(2026, 2, 2, 20, 29, 25, 459, DateTimeKind.Utc).AddTicks(1202) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 20, 29, 25, 457, DateTimeKind.Utc).AddTicks(6464), new DateTime(2026, 2, 2, 20, 29, 25, 457, DateTimeKind.Utc).AddTicks(4032), new DateTime(2026, 2, 2, 20, 29, 25, 457, DateTimeKind.Utc).AddTicks(7016) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 498, DateTimeKind.Utc).AddTicks(1134));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 498, DateTimeKind.Utc).AddTicks(1500));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 2, 20, 29, 25, 497, DateTimeKind.Utc).AddTicks(814), new DateTime(2026, 2, 2, 20, 29, 25, 497, DateTimeKind.Utc).AddTicks(56) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 454, DateTimeKind.Utc).AddTicks(3372));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 454, DateTimeKind.Utc).AddTicks(3713));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 454, DateTimeKind.Utc).AddTicks(3717));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 454, DateTimeKind.Utc).AddTicks(3720));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 454, DateTimeKind.Utc).AddTicks(4119));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 454, DateTimeKind.Utc).AddTicks(4127));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 454, DateTimeKind.Utc).AddTicks(4131));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 454, DateTimeKind.Utc).AddTicks(4136));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 454, DateTimeKind.Utc).AddTicks(4139));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 454, DateTimeKind.Utc).AddTicks(4143));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 454, DateTimeKind.Utc).AddTicks(4146));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 454, DateTimeKind.Utc).AddTicks(4150));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 452, DateTimeKind.Utc).AddTicks(5228));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 452, DateTimeKind.Utc).AddTicks(5788));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 452, DateTimeKind.Utc).AddTicks(5790));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 452, DateTimeKind.Utc).AddTicks(5793));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 452, DateTimeKind.Utc).AddTicks(5797));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 452, DateTimeKind.Utc).AddTicks(5800));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 452, DateTimeKind.Utc).AddTicks(5803));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 452, DateTimeKind.Utc).AddTicks(5806));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2026, 2, 2, 20, 29, 25, 465, DateTimeKind.Utc).AddTicks(2712), new DateTime(2026, 2, 2, 20, 29, 25, 465, DateTimeKind.Utc).AddTicks(67), new DateTime(2026, 8, 2, 20, 29, 25, 465, DateTimeKind.Utc).AddTicks(558) });

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 451, DateTimeKind.Utc).AddTicks(1894));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 451, DateTimeKind.Utc).AddTicks(2210));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 451, DateTimeKind.Utc).AddTicks(2246));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 451, DateTimeKind.Utc).AddTicks(2248));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 451, DateTimeKind.Utc).AddTicks(2250));

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 465, DateTimeKind.Utc).AddTicks(8684));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 467, DateTimeKind.Utc).AddTicks(9839));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 468, DateTimeKind.Utc).AddTicks(377));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 468, DateTimeKind.Utc).AddTicks(380));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 468, DateTimeKind.Utc).AddTicks(383));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 468, DateTimeKind.Utc).AddTicks(386));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 468, DateTimeKind.Utc).AddTicks(399));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 468, DateTimeKind.Utc).AddTicks(401));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 468, DateTimeKind.Utc).AddTicks(404));

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 20, 29, 25, 469, DateTimeKind.Utc).AddTicks(99), new DateTime(2026, 2, 2, 20, 29, 25, 469, DateTimeKind.Utc).AddTicks(102) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 20, 29, 25, 490, DateTimeKind.Utc).AddTicks(1679), new DateTime(2026, 2, 2, 20, 29, 25, 490, DateTimeKind.Utc).AddTicks(1685) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 20, 29, 25, 490, DateTimeKind.Utc).AddTicks(2521), new DateTime(2026, 2, 2, 20, 29, 25, 490, DateTimeKind.Utc).AddTicks(2522) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 20, 29, 25, 490, DateTimeKind.Utc).AddTicks(3980), new DateTime(2026, 2, 2, 20, 29, 25, 490, DateTimeKind.Utc).AddTicks(3981) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 20, 29, 25, 490, DateTimeKind.Utc).AddTicks(3997), new DateTime(2026, 2, 2, 20, 29, 25, 490, DateTimeKind.Utc).AddTicks(3997) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 20, 29, 25, 490, DateTimeKind.Utc).AddTicks(4042), new DateTime(2026, 2, 2, 20, 29, 25, 490, DateTimeKind.Utc).AddTicks(4042) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 20, 29, 25, 490, DateTimeKind.Utc).AddTicks(4049), new DateTime(2026, 2, 2, 20, 29, 25, 490, DateTimeKind.Utc).AddTicks(4050) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 20, 29, 25, 490, DateTimeKind.Utc).AddTicks(4055), new DateTime(2026, 2, 2, 20, 29, 25, 490, DateTimeKind.Utc).AddTicks(4055) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(5488));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6004));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6009));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6013));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6017));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6033));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6037));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6041));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6045));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6050));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6053));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6057));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6061));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6064));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6068));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6071));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6114));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6119));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6122));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6125));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6129));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6132));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6136));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6139));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6143));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6148));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6151));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6155));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6158));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6162));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6165));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6168));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6172));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6177));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6181));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6184));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6188));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6191));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6195));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6198));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6202));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6206));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6209));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6213));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6216));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6220));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6223));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6227));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6230));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6234));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6238));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6241));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6245));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6261));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6264));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6268));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6271));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6275));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6278));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6282));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6285));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6289));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6292));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6296));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6299));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6305));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6308));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6312));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6315));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6319));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6322));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6326));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6329));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6333));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6336));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6340));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6343));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6347));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6350));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6354));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6358));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6361));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6365));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6368));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6372));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6375));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6379));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6382));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6386));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6403));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6406));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6410));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6413));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6417));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6420));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6424));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6427));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6431));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6434));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 495, DateTimeKind.Utc).AddTicks(6438));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 467, DateTimeKind.Utc).AddTicks(3180));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 467, DateTimeKind.Utc).AddTicks(3576));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 467, DateTimeKind.Utc).AddTicks(3581));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 467, DateTimeKind.Utc).AddTicks(3585));

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 20, 29, 25, 461, DateTimeKind.Utc).AddTicks(4016), new DateTime(2026, 2, 2, 20, 29, 25, 461, DateTimeKind.Utc).AddTicks(4355) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 20, 29, 25, 461, DateTimeKind.Utc).AddTicks(4858), new DateTime(2026, 2, 2, 20, 29, 25, 461, DateTimeKind.Utc).AddTicks(4859) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 20, 29, 25, 461, DateTimeKind.Utc).AddTicks(4864), new DateTime(2026, 2, 2, 20, 29, 25, 461, DateTimeKind.Utc).AddTicks(4865) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 20, 29, 25, 461, DateTimeKind.Utc).AddTicks(4868), new DateTime(2026, 2, 2, 20, 29, 25, 461, DateTimeKind.Utc).AddTicks(4869) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 20, 29, 25, 461, DateTimeKind.Utc).AddTicks(4872), new DateTime(2026, 2, 2, 20, 29, 25, 461, DateTimeKind.Utc).AddTicks(4872) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 20, 29, 25, 462, DateTimeKind.Utc).AddTicks(8722), new DateTime(2026, 2, 2, 20, 29, 25, 462, DateTimeKind.Utc).AddTicks(9034) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 20, 29, 25, 462, DateTimeKind.Utc).AddTicks(9355), new DateTime(2026, 2, 2, 20, 29, 25, 462, DateTimeKind.Utc).AddTicks(9356) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 20, 29, 25, 462, DateTimeKind.Utc).AddTicks(9359), new DateTime(2026, 2, 2, 20, 29, 25, 462, DateTimeKind.Utc).AddTicks(9360) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 20, 29, 25, 462, DateTimeKind.Utc).AddTicks(9363), new DateTime(2026, 2, 2, 20, 29, 25, 462, DateTimeKind.Utc).AddTicks(9364) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 20, 29, 25, 462, DateTimeKind.Utc).AddTicks(9368), new DateTime(2026, 2, 2, 20, 29, 25, 462, DateTimeKind.Utc).AddTicks(9368) });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 460, DateTimeKind.Utc).AddTicks(3414));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 460, DateTimeKind.Utc).AddTicks(3789));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 460, DateTimeKind.Utc).AddTicks(3791));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 460, DateTimeKind.Utc).AddTicks(3793));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 460, DateTimeKind.Utc).AddTicks(3795));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 460, DateTimeKind.Utc).AddTicks(3797));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 460, DateTimeKind.Utc).AddTicks(3799));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 460, DateTimeKind.Utc).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 460, DateTimeKind.Utc).AddTicks(3804));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 460, DateTimeKind.Utc).AddTicks(3806));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 460, DateTimeKind.Utc).AddTicks(3808));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 449, DateTimeKind.Utc).AddTicks(7712));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 449, DateTimeKind.Utc).AddTicks(8037));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 449, DateTimeKind.Utc).AddTicks(8039));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 449, DateTimeKind.Utc).AddTicks(8041));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 449, DateTimeKind.Utc).AddTicks(8043));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 449, DateTimeKind.Utc).AddTicks(8045));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 455, DateTimeKind.Utc).AddTicks(2197));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 20, 29, 25, 455, DateTimeKind.Utc).AddTicks(2655));

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 20, 29, 25, 463, DateTimeKind.Utc).AddTicks(7775), new DateTime(2026, 2, 2, 20, 29, 25, 463, DateTimeKind.Utc).AddTicks(8089) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 20, 29, 25, 463, DateTimeKind.Utc).AddTicks(8397), new DateTime(2026, 2, 2, 20, 29, 25, 463, DateTimeKind.Utc).AddTicks(8398) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 2, 20, 29, 25, 463, DateTimeKind.Utc).AddTicks(8401), new DateTime(2026, 2, 2, 20, 29, 25, 463, DateTimeKind.Utc).AddTicks(8401) });
        }
    }
}
