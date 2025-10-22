using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kokomija.Migrations
{
    /// <inheritdoc />
    public partial class AddWishlistTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wishlists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wishlists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wishlists_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 22, 15, 15, 18, 32, DateTimeKind.Utc).AddTicks(3802), new DateTime(2025, 10, 22, 15, 15, 18, 32, DateTimeKind.Utc).AddTicks(4360) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 22, 15, 15, 18, 32, DateTimeKind.Utc).AddTicks(5470), new DateTime(2025, 10, 22, 15, 15, 18, 32, DateTimeKind.Utc).AddTicks(5470) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 22, 15, 15, 18, 32, DateTimeKind.Utc).AddTicks(5474), new DateTime(2025, 10, 22, 15, 15, 18, 32, DateTimeKind.Utc).AddTicks(5474) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 22, 15, 15, 18, 32, DateTimeKind.Utc).AddTicks(5478), new DateTime(2025, 10, 22, 15, 15, 18, 32, DateTimeKind.Utc).AddTicks(5479) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 22, 15, 15, 18, 32, DateTimeKind.Utc).AddTicks(5482), new DateTime(2025, 10, 22, 15, 15, 18, 32, DateTimeKind.Utc).AddTicks(5482) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 22, 15, 15, 18, 41, DateTimeKind.Utc).AddTicks(8338), new DateTime(2025, 10, 22, 15, 15, 18, 41, DateTimeKind.Utc).AddTicks(6195) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 22, 15, 15, 18, 43, DateTimeKind.Utc).AddTicks(4584), new DateTime(2025, 10, 22, 15, 15, 18, 43, DateTimeKind.Utc).AddTicks(4581) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 22, 15, 15, 18, 43, DateTimeKind.Utc).AddTicks(4590), new DateTime(2025, 10, 22, 15, 15, 18, 43, DateTimeKind.Utc).AddTicks(4589) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 22, 15, 15, 18, 43, DateTimeKind.Utc).AddTicks(4593), new DateTime(2025, 10, 22, 15, 15, 18, 43, DateTimeKind.Utc).AddTicks(4592) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 22, 15, 15, 18, 43, DateTimeKind.Utc).AddTicks(4596), new DateTime(2025, 10, 22, 15, 15, 18, 43, DateTimeKind.Utc).AddTicks(4596) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 30, DateTimeKind.Utc).AddTicks(3472));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 30, DateTimeKind.Utc).AddTicks(3816));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 30, DateTimeKind.Utc).AddTicks(3850));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 30, DateTimeKind.Utc).AddTicks(3853));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 30, DateTimeKind.Utc).AddTicks(4200));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 30, DateTimeKind.Utc).AddTicks(4205));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 30, DateTimeKind.Utc).AddTicks(4208));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 30, DateTimeKind.Utc).AddTicks(4211));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 30, DateTimeKind.Utc).AddTicks(4215));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 30, DateTimeKind.Utc).AddTicks(4218));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 30, DateTimeKind.Utc).AddTicks(4221));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 30, DateTimeKind.Utc).AddTicks(4224));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 29, DateTimeKind.Utc).AddTicks(1163));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 29, DateTimeKind.Utc).AddTicks(1510));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 29, DateTimeKind.Utc).AddTicks(1513));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 29, DateTimeKind.Utc).AddTicks(1516));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 29, DateTimeKind.Utc).AddTicks(1518));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 29, DateTimeKind.Utc).AddTicks(1521));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 29, DateTimeKind.Utc).AddTicks(1523));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 29, DateTimeKind.Utc).AddTicks(1526));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(297));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(661));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(665));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(668));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(672));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(684));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(687));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(691));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(695));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(698));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(702));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(705));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(708));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(711));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(715));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(718));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(723));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(726));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(729));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(733));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(736));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(739));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(742));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(746));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(749));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(752));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(758));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(762));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(765));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(769));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(772));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(775));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(798));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(802));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(805));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(808));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(812));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(815));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(818));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(821));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(825));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(828));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(831));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 36, DateTimeKind.Utc).AddTicks(835));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(1553));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(1918));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(1923));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(1927));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(1931));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(1944));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(1948));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(1952));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(1956));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(1961));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(1964));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(1968));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(1993));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(1997));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2001));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2005));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2008));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2045));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2048));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2052));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2056));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2059));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2063));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2067));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2106));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2110));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2114));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2118));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2131));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2135));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2139));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2143));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2147));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2152));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2156));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2160));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2164));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2167));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2181));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2186));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2189));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2194));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2197));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2201));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2206));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2209));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2213));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2230));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2234));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2242));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2246));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2250));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2262));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2267));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2271));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2276));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2280));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2285));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2289));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2293));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2322));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2327));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2331));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2338));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2342));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2346));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2351));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2355));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2359));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2363));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2367));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2372));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2376));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2380));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2387));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2399));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2403));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2407));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2411));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2417));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2421));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2425));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2429));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2433));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2440));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2445));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2449));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2453));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2457));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2462));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2466));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2470));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2474));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2478));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2482));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2486));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2493));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2497));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2500));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2504));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2511));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2516));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2520));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2524));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2528));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2532));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2537));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2541));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2545));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2549));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2557));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2570));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2574));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2579));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2583));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2587));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2591));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2595));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2599));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2604));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2608));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 124,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2612));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 125,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2619));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 126,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2624));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 127,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2628));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 128,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2633));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 129,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2637));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 130,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2643));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 131,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2648));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 132,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2652));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 133,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2659));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 134,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2663));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 135,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2667));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 136,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 40, DateTimeKind.Utc).AddTicks(2670));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 35, DateTimeKind.Utc).AddTicks(3667));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 35, DateTimeKind.Utc).AddTicks(4056));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 35, DateTimeKind.Utc).AddTicks(4059));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 35, DateTimeKind.Utc).AddTicks(4063));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 35, DateTimeKind.Utc).AddTicks(4066));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 35, DateTimeKind.Utc).AddTicks(4070));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 35, DateTimeKind.Utc).AddTicks(4073));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 35, DateTimeKind.Utc).AddTicks(4076));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 35, DateTimeKind.Utc).AddTicks(4080));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 35, DateTimeKind.Utc).AddTicks(4083));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 35, DateTimeKind.Utc).AddTicks(4086));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 35, DateTimeKind.Utc).AddTicks(4123));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 35, DateTimeKind.Utc).AddTicks(4126));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 35, DateTimeKind.Utc).AddTicks(4130));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 35, DateTimeKind.Utc).AddTicks(4133));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 33, DateTimeKind.Utc).AddTicks(5878));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 33, DateTimeKind.Utc).AddTicks(6321));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 33, DateTimeKind.Utc).AddTicks(6323));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 33, DateTimeKind.Utc).AddTicks(6325));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 33, DateTimeKind.Utc).AddTicks(6327));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 33, DateTimeKind.Utc).AddTicks(6329));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 33, DateTimeKind.Utc).AddTicks(6331));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 33, DateTimeKind.Utc).AddTicks(6333));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 26, DateTimeKind.Utc).AddTicks(6857));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 26, DateTimeKind.Utc).AddTicks(7385));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 26, DateTimeKind.Utc).AddTicks(7388));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 26, DateTimeKind.Utc).AddTicks(7391));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 26, DateTimeKind.Utc).AddTicks(7393));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 26, DateTimeKind.Utc).AddTicks(7396));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 31, DateTimeKind.Utc).AddTicks(1850));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 31, DateTimeKind.Utc).AddTicks(2196));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 31, DateTimeKind.Utc).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 22, 15, 15, 18, 31, DateTimeKind.Utc).AddTicks(2201));

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_ProductId",
                table: "Wishlists",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_UserId",
                table: "Wishlists",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wishlists");

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 18, 18, 8, 2, 576, DateTimeKind.Utc).AddTicks(4851), new DateTime(2025, 10, 18, 18, 8, 2, 576, DateTimeKind.Utc).AddTicks(5171) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 18, 18, 8, 2, 576, DateTimeKind.Utc).AddTicks(5486), new DateTime(2025, 10, 18, 18, 8, 2, 576, DateTimeKind.Utc).AddTicks(5487) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 18, 18, 8, 2, 576, DateTimeKind.Utc).AddTicks(5490), new DateTime(2025, 10, 18, 18, 8, 2, 576, DateTimeKind.Utc).AddTicks(5491) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 18, 18, 8, 2, 576, DateTimeKind.Utc).AddTicks(5493), new DateTime(2025, 10, 18, 18, 8, 2, 576, DateTimeKind.Utc).AddTicks(5494) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 10, 18, 18, 8, 2, 576, DateTimeKind.Utc).AddTicks(5497), new DateTime(2025, 10, 18, 18, 8, 2, 576, DateTimeKind.Utc).AddTicks(5497) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 18, 18, 8, 2, 586, DateTimeKind.Utc).AddTicks(6295), new DateTime(2025, 10, 18, 18, 8, 2, 586, DateTimeKind.Utc).AddTicks(5701) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 18, 18, 8, 2, 586, DateTimeKind.Utc).AddTicks(6633), new DateTime(2025, 10, 18, 18, 8, 2, 586, DateTimeKind.Utc).AddTicks(6632) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 18, 18, 8, 2, 586, DateTimeKind.Utc).AddTicks(6636), new DateTime(2025, 10, 18, 18, 8, 2, 586, DateTimeKind.Utc).AddTicks(6636) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 18, 18, 8, 2, 586, DateTimeKind.Utc).AddTicks(6639), new DateTime(2025, 10, 18, 18, 8, 2, 586, DateTimeKind.Utc).AddTicks(6639) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 10, 18, 18, 8, 2, 586, DateTimeKind.Utc).AddTicks(6643), new DateTime(2025, 10, 18, 18, 8, 2, 586, DateTimeKind.Utc).AddTicks(6642) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 574, DateTimeKind.Utc).AddTicks(6412));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 574, DateTimeKind.Utc).AddTicks(7153));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 574, DateTimeKind.Utc).AddTicks(7160));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 574, DateTimeKind.Utc).AddTicks(7163));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 574, DateTimeKind.Utc).AddTicks(7774));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 574, DateTimeKind.Utc).AddTicks(7782));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 574, DateTimeKind.Utc).AddTicks(7785));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 574, DateTimeKind.Utc).AddTicks(7788));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 574, DateTimeKind.Utc).AddTicks(7790));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 574, DateTimeKind.Utc).AddTicks(7793));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 574, DateTimeKind.Utc).AddTicks(7796));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 574, DateTimeKind.Utc).AddTicks(7799));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 572, DateTimeKind.Utc).AddTicks(8895));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 572, DateTimeKind.Utc).AddTicks(9240));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 572, DateTimeKind.Utc).AddTicks(9242));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 572, DateTimeKind.Utc).AddTicks(9245));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 572, DateTimeKind.Utc).AddTicks(9247));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 572, DateTimeKind.Utc).AddTicks(9250));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 572, DateTimeKind.Utc).AddTicks(9252));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 572, DateTimeKind.Utc).AddTicks(9255));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8150));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8599));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8604));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8609));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8613));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8622));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8626));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8630));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8634));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8640));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8644));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8648));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8652));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8657));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8660));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8664));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8672));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8677));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8681));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8684));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8688));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8712));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8716));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8725));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8729));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8737));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8742));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8752));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8756));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8759));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8762));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8766));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8770));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8808));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8812));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8815));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8820));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8824));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8828));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8832));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8835));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8839));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8843));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8847));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(8851));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3325));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3706));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3711));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3715));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3719));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3733));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3736));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3740));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3744));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3749));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3752));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3756));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3781));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3786));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3822));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3826));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3830));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3839));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3843));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3846));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3850));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3854));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3895));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3899));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3903));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3907));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3921));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3925));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3929));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3933));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3937));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3942));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3946));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3950));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3953));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3957));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3970));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3975));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3979));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3983));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3986));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(3990));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4012));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4016));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4020));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4023));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4027));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4031));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4034));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4038));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4050));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4054));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4058));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4061));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4065));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4069));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4073));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4077));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4100));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4105));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4108));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4112));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4118));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4122));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4126));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4130));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4133));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4137));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4141));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4149));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4163));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4167));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4174));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4177));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4181));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4184));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4187));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4193));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4197));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4201));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4204));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4207));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4214));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4218));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4222));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4226));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4230));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4234));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4238));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4241));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4245));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4249));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4253));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4257));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4263));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4267));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4270));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 102,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4273));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 103,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4280));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 104,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4284));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 105,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4288));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 106,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4292));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 107,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4296));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 108,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4299));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 109,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4303));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 110,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4307));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 111,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4319));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 112,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4323));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 113,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4330));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 114,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4334));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 115,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4338));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 116,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4342));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 117,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4345));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 118,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4349));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 119,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4353));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 120,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4357));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 121,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4360));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 122,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4364));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 123,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4368));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 124,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4371));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 125,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4378));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 126,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4382));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 127,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4386));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 128,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4390));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 129,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4394));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 130,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4400));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 131,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4404));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 132,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4407));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 133,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4413));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 134,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4417));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 135,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4420));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 136,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 585, DateTimeKind.Utc).AddTicks(4423));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(447));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(879));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(916));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(919));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(923));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(926));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(930));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(933));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(936));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(939));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(943));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(946));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(949));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(953));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 580, DateTimeKind.Utc).AddTicks(956));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 577, DateTimeKind.Utc).AddTicks(5142));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 577, DateTimeKind.Utc).AddTicks(5665));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 577, DateTimeKind.Utc).AddTicks(5668));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 577, DateTimeKind.Utc).AddTicks(5670));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 577, DateTimeKind.Utc).AddTicks(5673));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 577, DateTimeKind.Utc).AddTicks(5675));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 577, DateTimeKind.Utc).AddTicks(5677));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 577, DateTimeKind.Utc).AddTicks(5680));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 570, DateTimeKind.Utc).AddTicks(7207));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 570, DateTimeKind.Utc).AddTicks(7577));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 570, DateTimeKind.Utc).AddTicks(7580));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 570, DateTimeKind.Utc).AddTicks(7582));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 570, DateTimeKind.Utc).AddTicks(7585));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 570, DateTimeKind.Utc).AddTicks(7620));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 575, DateTimeKind.Utc).AddTicks(6236));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 575, DateTimeKind.Utc).AddTicks(6570));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 575, DateTimeKind.Utc).AddTicks(6573));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 10, 18, 18, 8, 2, 575, DateTimeKind.Utc).AddTicks(6576));
        }
    }
}
