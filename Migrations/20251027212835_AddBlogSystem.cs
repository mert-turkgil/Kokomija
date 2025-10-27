using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kokomija.Migrations
{
    /// <inheritdoc />
    public partial class AddBlogSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 27, 21, 28, 33, 581, DateTimeKind.Utc).AddTicks(5874), new DateTime(2025, 10, 27, 21, 28, 33, 581, DateTimeKind.Utc).AddTicks(6196) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 27, 21, 28, 33, 581, DateTimeKind.Utc).AddTicks(6597), new DateTime(2025, 10, 27, 21, 28, 33, 581, DateTimeKind.Utc).AddTicks(6597) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 27, 21, 28, 33, 581, DateTimeKind.Utc).AddTicks(6600), new DateTime(2025, 10, 27, 21, 28, 33, 581, DateTimeKind.Utc).AddTicks(6601) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 27, 21, 28, 33, 581, DateTimeKind.Utc).AddTicks(6604), new DateTime(2025, 10, 27, 21, 28, 33, 581, DateTimeKind.Utc).AddTicks(6604) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 27, 21, 28, 33, 581, DateTimeKind.Utc).AddTicks(6642), new DateTime(2025, 10, 27, 21, 28, 33, 581, DateTimeKind.Utc).AddTicks(6642) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 27, 21, 28, 33, 590, DateTimeKind.Utc).AddTicks(9330), new DateTime(2025, 10, 27, 21, 28, 33, 590, DateTimeKind.Utc).AddTicks(8649) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 27, 21, 28, 33, 590, DateTimeKind.Utc).AddTicks(9876), new DateTime(2025, 10, 27, 21, 28, 33, 590, DateTimeKind.Utc).AddTicks(9875) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 27, 21, 28, 33, 590, DateTimeKind.Utc).AddTicks(9881), new DateTime(2025, 10, 27, 21, 28, 33, 590, DateTimeKind.Utc).AddTicks(9880) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 27, 21, 28, 33, 590, DateTimeKind.Utc).AddTicks(9885), new DateTime(2025, 10, 27, 21, 28, 33, 590, DateTimeKind.Utc).AddTicks(9884) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 27, 21, 28, 33, 590, DateTimeKind.Utc).AddTicks(9889), new DateTime(2025, 10, 27, 21, 28, 33, 590, DateTimeKind.Utc).AddTicks(9888) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 579, DateTimeKind.Utc).AddTicks(7140));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 579, DateTimeKind.Utc).AddTicks(7480));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 579, DateTimeKind.Utc).AddTicks(7483));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 579, DateTimeKind.Utc).AddTicks(7486));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 579, DateTimeKind.Utc).AddTicks(7930));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 579, DateTimeKind.Utc).AddTicks(7937));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 579, DateTimeKind.Utc).AddTicks(7940));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 579, DateTimeKind.Utc).AddTicks(7943));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 579, DateTimeKind.Utc).AddTicks(7947));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 579, DateTimeKind.Utc).AddTicks(7950));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 579, DateTimeKind.Utc).AddTicks(7988));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 579, DateTimeKind.Utc).AddTicks(7992));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 577, DateTimeKind.Utc).AddTicks(6417));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 577, DateTimeKind.Utc).AddTicks(7012));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 577, DateTimeKind.Utc).AddTicks(7017));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 577, DateTimeKind.Utc).AddTicks(7020));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 577, DateTimeKind.Utc).AddTicks(7024));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 577, DateTimeKind.Utc).AddTicks(7026));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 577, DateTimeKind.Utc).AddTicks(7029));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 577, DateTimeKind.Utc).AddTicks(7033));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3327));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3668));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3671));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3675));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3685));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3689));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3692));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3695));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3700));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3703));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3706));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3710));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3713));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3716));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3720));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3723));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3727));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3731));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3734));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3737));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3740));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3744));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3747));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3750));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3753));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3757));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3765));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3768));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3772));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3775));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3778));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3782));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3787));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3790));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3793));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3797));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3800));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3803));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3807));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3810));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3827));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3831));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3834));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 585, DateTimeKind.Utc).AddTicks(3837));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7217));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7679));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7684));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7689));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7693));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7706));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7710));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7714));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7718));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7723));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7727));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7731));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7755));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7760));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7764));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7768));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7772));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7777));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7781));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7785));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7789));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7792));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7828));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7832));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7866));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7871));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7875));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7878));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7892));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7897));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7901));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7905));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7909));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7915));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7919));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7923));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7927));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7931));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7944));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7948));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7952));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7956));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7960));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7964));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7968));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7972));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7976));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7980));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7984));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7988));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7992));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7995));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(7999));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8034));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8039));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8043));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8047));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8051));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8055));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8059));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8062));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8074));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8078));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8082));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8086));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8092));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8096));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8100));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8104));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8107));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8111));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8115));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8119));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8123));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8126));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8130));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8136));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8140));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8143));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8147));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8150));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8156));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8160));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8163));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8175));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8178));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8185));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8189));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8193));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8197));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8201));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8204));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8208));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8212));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8216));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8220));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8224));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8228));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8233));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8237));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8240));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8244));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8250));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8254));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8258));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8262));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8266));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8270));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8273));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8277));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8281));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8285));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8291));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8295));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8299));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8303));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8307));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8311));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8315));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8327));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8331));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8335));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8339));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 124,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8343));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 125,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8350));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 126,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8354));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 127,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8358));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 128,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8362));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 129,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8366));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 130,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8372));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 131,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8376));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 132,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 133,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8385));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 134,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8389));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 135,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8393));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 136,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 589, DateTimeKind.Utc).AddTicks(8396));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 584, DateTimeKind.Utc).AddTicks(7089));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 584, DateTimeKind.Utc).AddTicks(7455));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 584, DateTimeKind.Utc).AddTicks(7458));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 584, DateTimeKind.Utc).AddTicks(7462));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 584, DateTimeKind.Utc).AddTicks(7465));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 584, DateTimeKind.Utc).AddTicks(7469));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 584, DateTimeKind.Utc).AddTicks(7472));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 584, DateTimeKind.Utc).AddTicks(7476));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 584, DateTimeKind.Utc).AddTicks(7479));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 584, DateTimeKind.Utc).AddTicks(7482));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 584, DateTimeKind.Utc).AddTicks(7486));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 584, DateTimeKind.Utc).AddTicks(7489));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 584, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 584, DateTimeKind.Utc).AddTicks(7496));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 584, DateTimeKind.Utc).AddTicks(7499));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 582, DateTimeKind.Utc).AddTicks(8718));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 582, DateTimeKind.Utc).AddTicks(9057));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 582, DateTimeKind.Utc).AddTicks(9060));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 582, DateTimeKind.Utc).AddTicks(9062));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 582, DateTimeKind.Utc).AddTicks(9064));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 582, DateTimeKind.Utc).AddTicks(9067));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 582, DateTimeKind.Utc).AddTicks(9069));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 582, DateTimeKind.Utc).AddTicks(9071));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 575, DateTimeKind.Utc).AddTicks(944));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 575, DateTimeKind.Utc).AddTicks(1293));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 575, DateTimeKind.Utc).AddTicks(1296));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 575, DateTimeKind.Utc).AddTicks(1299));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 575, DateTimeKind.Utc).AddTicks(1301));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 575, DateTimeKind.Utc).AddTicks(1304));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 580, DateTimeKind.Utc).AddTicks(5729));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 580, DateTimeKind.Utc).AddTicks(6072));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 580, DateTimeKind.Utc).AddTicks(6075));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 21, 28, 33, 580, DateTimeKind.Utc).AddTicks(6077));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 27, 18, 3, 55, 465, DateTimeKind.Utc).AddTicks(1655), new DateTime(2025, 10, 27, 18, 3, 55, 465, DateTimeKind.Utc).AddTicks(1974) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 27, 18, 3, 55, 465, DateTimeKind.Utc).AddTicks(2362), new DateTime(2025, 10, 27, 18, 3, 55, 465, DateTimeKind.Utc).AddTicks(2363) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 27, 18, 3, 55, 465, DateTimeKind.Utc).AddTicks(2366), new DateTime(2025, 10, 27, 18, 3, 55, 465, DateTimeKind.Utc).AddTicks(2366) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 27, 18, 3, 55, 465, DateTimeKind.Utc).AddTicks(2369), new DateTime(2025, 10, 27, 18, 3, 55, 465, DateTimeKind.Utc).AddTicks(2369) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 27, 18, 3, 55, 465, DateTimeKind.Utc).AddTicks(2372), new DateTime(2025, 10, 27, 18, 3, 55, 465, DateTimeKind.Utc).AddTicks(2373) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 27, 18, 3, 55, 476, DateTimeKind.Utc).AddTicks(1472), new DateTime(2025, 10, 27, 18, 3, 55, 476, DateTimeKind.Utc).AddTicks(789) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 27, 18, 3, 55, 476, DateTimeKind.Utc).AddTicks(1905), new DateTime(2025, 10, 27, 18, 3, 55, 476, DateTimeKind.Utc).AddTicks(1904) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 27, 18, 3, 55, 476, DateTimeKind.Utc).AddTicks(1909), new DateTime(2025, 10, 27, 18, 3, 55, 476, DateTimeKind.Utc).AddTicks(1908) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 27, 18, 3, 55, 476, DateTimeKind.Utc).AddTicks(1913), new DateTime(2025, 10, 27, 18, 3, 55, 476, DateTimeKind.Utc).AddTicks(1912) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 27, 18, 3, 55, 476, DateTimeKind.Utc).AddTicks(1917), new DateTime(2025, 10, 27, 18, 3, 55, 476, DateTimeKind.Utc).AddTicks(1917) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 463, DateTimeKind.Utc).AddTicks(3558));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 463, DateTimeKind.Utc).AddTicks(3954));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 463, DateTimeKind.Utc).AddTicks(3957));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 463, DateTimeKind.Utc).AddTicks(3960));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 463, DateTimeKind.Utc).AddTicks(4312));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 463, DateTimeKind.Utc).AddTicks(4318));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 463, DateTimeKind.Utc).AddTicks(4321));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 463, DateTimeKind.Utc).AddTicks(4324));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 463, DateTimeKind.Utc).AddTicks(4328));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 463, DateTimeKind.Utc).AddTicks(4331));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 463, DateTimeKind.Utc).AddTicks(4334));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 463, DateTimeKind.Utc).AddTicks(4337));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 461, DateTimeKind.Utc).AddTicks(2806));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 461, DateTimeKind.Utc).AddTicks(3345));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 461, DateTimeKind.Utc).AddTicks(3348));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 461, DateTimeKind.Utc).AddTicks(3351));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 461, DateTimeKind.Utc).AddTicks(3401));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 461, DateTimeKind.Utc).AddTicks(3405));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 461, DateTimeKind.Utc).AddTicks(3408));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 461, DateTimeKind.Utc).AddTicks(3411));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1498));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1905));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1910));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1913));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1916));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1931));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1935));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1938));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1941));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1946));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1949));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1952));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1955));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1959));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1962));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1965));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1968));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1972));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1976));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1979));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1982));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1985));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1989));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1992));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1995));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(1998));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2001));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2046));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2049));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2053));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2056));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2059));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2062));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2068));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2071));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2074));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2077));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2080));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2087));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2090));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2093));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2097));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2100));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 469, DateTimeKind.Utc).AddTicks(2103));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(7780));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8310));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8315));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8323));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8329));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8347));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8351));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8355));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8360));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8368));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8372));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8415));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8448));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8453));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8457));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8462));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8466));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8473));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8478));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8482));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8487));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8492));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8497));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8501));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8545));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8551));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8555));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8559));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8579));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8584));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8590));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8595));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8600));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8606));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8610));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8615));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8619));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8623));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8638));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8642));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8657));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8661));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8665));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8668));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8672));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8676));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8680));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8683));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8687));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8691));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8695));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8698));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8702));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8729));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8733));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8738));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8741));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8745));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8749));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8753));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8757));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8768));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8772));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8776));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8780));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8785));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8789));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8793));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8796));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8800));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8816));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8820));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8824));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8828));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8832));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8836));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8843));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8847));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8850));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8854));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8857));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8863));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8866));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8870));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8873));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8877));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8883));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8887));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8891));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8895));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8899));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8903));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8906));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8910));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8914));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8918));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8921));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8925));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8931));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8934));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8938));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8941));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8948));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8952));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8956));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8960));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8971));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8975));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8979));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8983));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8987));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8991));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(8998));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9002));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9006));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9010));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9014));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9018));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9022));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9025));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9029));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9033));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9037));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 124,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9040));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 125,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9047));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 126,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9051));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 127,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9055));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 128,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9059));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 129,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9063));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 130,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9069));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 131,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9073));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 132,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9077));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 133,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9091));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 134,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9095));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 135,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9099));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 136,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 474, DateTimeKind.Utc).AddTicks(9102));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 468, DateTimeKind.Utc).AddTicks(3172));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 468, DateTimeKind.Utc).AddTicks(3792));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 468, DateTimeKind.Utc).AddTicks(3795));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 468, DateTimeKind.Utc).AddTicks(3798));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 468, DateTimeKind.Utc).AddTicks(3802));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 468, DateTimeKind.Utc).AddTicks(3857));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 468, DateTimeKind.Utc).AddTicks(3860));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 468, DateTimeKind.Utc).AddTicks(3864));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 468, DateTimeKind.Utc).AddTicks(3867));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 468, DateTimeKind.Utc).AddTicks(3870));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 468, DateTimeKind.Utc).AddTicks(3874));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 468, DateTimeKind.Utc).AddTicks(3877));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 468, DateTimeKind.Utc).AddTicks(3880));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 468, DateTimeKind.Utc).AddTicks(3884));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 468, DateTimeKind.Utc).AddTicks(3887));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 466, DateTimeKind.Utc).AddTicks(235));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 466, DateTimeKind.Utc).AddTicks(588));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 466, DateTimeKind.Utc).AddTicks(591));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 466, DateTimeKind.Utc).AddTicks(593));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 466, DateTimeKind.Utc).AddTicks(595));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 466, DateTimeKind.Utc).AddTicks(597));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 466, DateTimeKind.Utc).AddTicks(599));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 466, DateTimeKind.Utc).AddTicks(601));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 458, DateTimeKind.Utc).AddTicks(9124));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 458, DateTimeKind.Utc).AddTicks(9721));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 458, DateTimeKind.Utc).AddTicks(9724));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 458, DateTimeKind.Utc).AddTicks(9727));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 458, DateTimeKind.Utc).AddTicks(9730));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 458, DateTimeKind.Utc).AddTicks(9733));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 464, DateTimeKind.Utc).AddTicks(3142));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 464, DateTimeKind.Utc).AddTicks(3471));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 464, DateTimeKind.Utc).AddTicks(3473));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 18, 3, 55, 464, DateTimeKind.Utc).AddTicks(3476));
        }
    }
}
