using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kokomija.Migrations
{
    /// <inheritdoc />
    public partial class AddProductReviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(2,1)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    IsVerifiedPurchase = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AdminReply = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    AdminReplyBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AdminReplyAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReviews_AspNetUsers_AdminReplyBy",
                        column: x => x.AdminReplyBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductReviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductReviews_Products_ProductId",
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
                values: new object[] { new DateTime(2025, 11, 13, 18, 6, 40, 394, DateTimeKind.Utc).AddTicks(5088), new DateTime(2025, 11, 13, 18, 6, 40, 394, DateTimeKind.Utc).AddTicks(5418) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 13, 18, 6, 40, 394, DateTimeKind.Utc).AddTicks(5738), new DateTime(2025, 11, 13, 18, 6, 40, 394, DateTimeKind.Utc).AddTicks(5739) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 13, 18, 6, 40, 394, DateTimeKind.Utc).AddTicks(5742), new DateTime(2025, 11, 13, 18, 6, 40, 394, DateTimeKind.Utc).AddTicks(5742) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 13, 18, 6, 40, 394, DateTimeKind.Utc).AddTicks(5745), new DateTime(2025, 11, 13, 18, 6, 40, 394, DateTimeKind.Utc).AddTicks(5746) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 13, 18, 6, 40, 394, DateTimeKind.Utc).AddTicks(5748), new DateTime(2025, 11, 13, 18, 6, 40, 394, DateTimeKind.Utc).AddTicks(5749) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 13, 18, 6, 40, 401, DateTimeKind.Utc).AddTicks(5494), new DateTime(2025, 11, 13, 18, 6, 40, 401, DateTimeKind.Utc).AddTicks(4929) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 13, 18, 6, 40, 401, DateTimeKind.Utc).AddTicks(5828), new DateTime(2025, 11, 13, 18, 6, 40, 401, DateTimeKind.Utc).AddTicks(5827) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 13, 18, 6, 40, 401, DateTimeKind.Utc).AddTicks(5832), new DateTime(2025, 11, 13, 18, 6, 40, 401, DateTimeKind.Utc).AddTicks(5831) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 13, 18, 6, 40, 401, DateTimeKind.Utc).AddTicks(5835), new DateTime(2025, 11, 13, 18, 6, 40, 401, DateTimeKind.Utc).AddTicks(5834) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 13, 18, 6, 40, 401, DateTimeKind.Utc).AddTicks(5838), new DateTime(2025, 11, 13, 18, 6, 40, 401, DateTimeKind.Utc).AddTicks(5838) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 391, DateTimeKind.Utc).AddTicks(9890));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 392, DateTimeKind.Utc).AddTicks(366));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 392, DateTimeKind.Utc).AddTicks(369));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 392, DateTimeKind.Utc).AddTicks(373));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 392, DateTimeKind.Utc).AddTicks(1027));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 392, DateTimeKind.Utc).AddTicks(1039));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 392, DateTimeKind.Utc).AddTicks(1043));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 392, DateTimeKind.Utc).AddTicks(1053));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 392, DateTimeKind.Utc).AddTicks(1056));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 392, DateTimeKind.Utc).AddTicks(1061));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 392, DateTimeKind.Utc).AddTicks(1065));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 392, DateTimeKind.Utc).AddTicks(1069));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 390, DateTimeKind.Utc).AddTicks(6239));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 390, DateTimeKind.Utc).AddTicks(6660));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 390, DateTimeKind.Utc).AddTicks(6662));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 390, DateTimeKind.Utc).AddTicks(6665));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 390, DateTimeKind.Utc).AddTicks(6668));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 390, DateTimeKind.Utc).AddTicks(6670));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 390, DateTimeKind.Utc).AddTicks(6673));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 390, DateTimeKind.Utc).AddTicks(6675));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7266));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7721));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7724));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7728));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7731));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7746));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7749));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7752));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7757));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7763));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7766));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7769));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7772));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7775));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7778));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7781));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7786));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7791));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7794));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7797));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7800));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7803));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7806));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 397, DateTimeKind.Utc).AddTicks(7809));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 400, DateTimeKind.Utc).AddTicks(844));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 400, DateTimeKind.Utc).AddTicks(1491));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 400, DateTimeKind.Utc).AddTicks(1494));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 400, DateTimeKind.Utc).AddTicks(1497));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 400, DateTimeKind.Utc).AddTicks(1500));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 400, DateTimeKind.Utc).AddTicks(1524));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 400, DateTimeKind.Utc).AddTicks(1527));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 400, DateTimeKind.Utc).AddTicks(1533));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 400, DateTimeKind.Utc).AddTicks(1540));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 400, DateTimeKind.Utc).AddTicks(1546));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 400, DateTimeKind.Utc).AddTicks(1551));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 400, DateTimeKind.Utc).AddTicks(1556));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 400, DateTimeKind.Utc).AddTicks(1559));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 400, DateTimeKind.Utc).AddTicks(1562));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 400, DateTimeKind.Utc).AddTicks(1564));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 396, DateTimeKind.Utc).AddTicks(6091));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 396, DateTimeKind.Utc).AddTicks(6423));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 396, DateTimeKind.Utc).AddTicks(6427));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 395, DateTimeKind.Utc).AddTicks(4727));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 395, DateTimeKind.Utc).AddTicks(5190));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 395, DateTimeKind.Utc).AddTicks(5192));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 395, DateTimeKind.Utc).AddTicks(5194));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 395, DateTimeKind.Utc).AddTicks(5196));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 395, DateTimeKind.Utc).AddTicks(5198));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 395, DateTimeKind.Utc).AddTicks(5201));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 395, DateTimeKind.Utc).AddTicks(5203));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 388, DateTimeKind.Utc).AddTicks(8557));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 388, DateTimeKind.Utc).AddTicks(8911));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 388, DateTimeKind.Utc).AddTicks(8913));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 388, DateTimeKind.Utc).AddTicks(8915));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 388, DateTimeKind.Utc).AddTicks(8918));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 388, DateTimeKind.Utc).AddTicks(8920));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 393, DateTimeKind.Utc).AddTicks(4818));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 393, DateTimeKind.Utc).AddTicks(5174));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 393, DateTimeKind.Utc).AddTicks(5177));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 18, 6, 40, 393, DateTimeKind.Utc).AddTicks(5179));

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_AdminReplyBy",
                table: "ProductReviews",
                column: "AdminReplyBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_CreatedAt",
                table: "ProductReviews",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_IsVerifiedPurchase",
                table: "ProductReviews",
                column: "IsVerifiedPurchase");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_IsVisible",
                table: "ProductReviews",
                column: "IsVisible");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ProductId",
                table: "ProductReviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ProductId_IsVisible_CreatedAt",
                table: "ProductReviews",
                columns: new[] { "ProductId", "IsVisible", "CreatedAt" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_UserId",
                table: "ProductReviews",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductReviews");

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 13, 17, 24, 50, 267, DateTimeKind.Utc).AddTicks(4886), new DateTime(2025, 11, 13, 17, 24, 50, 267, DateTimeKind.Utc).AddTicks(5222) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 13, 17, 24, 50, 267, DateTimeKind.Utc).AddTicks(5694), new DateTime(2025, 11, 13, 17, 24, 50, 267, DateTimeKind.Utc).AddTicks(5695) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 13, 17, 24, 50, 267, DateTimeKind.Utc).AddTicks(5698), new DateTime(2025, 11, 13, 17, 24, 50, 267, DateTimeKind.Utc).AddTicks(5699) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 13, 17, 24, 50, 267, DateTimeKind.Utc).AddTicks(5702), new DateTime(2025, 11, 13, 17, 24, 50, 267, DateTimeKind.Utc).AddTicks(5702) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 13, 17, 24, 50, 267, DateTimeKind.Utc).AddTicks(5705), new DateTime(2025, 11, 13, 17, 24, 50, 267, DateTimeKind.Utc).AddTicks(5706) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 13, 17, 24, 50, 279, DateTimeKind.Utc).AddTicks(1622), new DateTime(2025, 11, 13, 17, 24, 50, 279, DateTimeKind.Utc).AddTicks(840) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 13, 17, 24, 50, 279, DateTimeKind.Utc).AddTicks(2102), new DateTime(2025, 11, 13, 17, 24, 50, 279, DateTimeKind.Utc).AddTicks(2101) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 13, 17, 24, 50, 279, DateTimeKind.Utc).AddTicks(2107), new DateTime(2025, 11, 13, 17, 24, 50, 279, DateTimeKind.Utc).AddTicks(2107) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 13, 17, 24, 50, 279, DateTimeKind.Utc).AddTicks(2113), new DateTime(2025, 11, 13, 17, 24, 50, 279, DateTimeKind.Utc).AddTicks(2112) });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 13, 17, 24, 50, 279, DateTimeKind.Utc).AddTicks(2117), new DateTime(2025, 11, 13, 17, 24, 50, 279, DateTimeKind.Utc).AddTicks(2116) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 265, DateTimeKind.Utc).AddTicks(2498));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 265, DateTimeKind.Utc).AddTicks(4065));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 265, DateTimeKind.Utc).AddTicks(4068));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 265, DateTimeKind.Utc).AddTicks(4073));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 265, DateTimeKind.Utc).AddTicks(5227));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 265, DateTimeKind.Utc).AddTicks(5239));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 265, DateTimeKind.Utc).AddTicks(5242));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 265, DateTimeKind.Utc).AddTicks(5246));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 265, DateTimeKind.Utc).AddTicks(5249));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 265, DateTimeKind.Utc).AddTicks(5252));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 265, DateTimeKind.Utc).AddTicks(5255));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 265, DateTimeKind.Utc).AddTicks(5258));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 263, DateTimeKind.Utc).AddTicks(2269));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 263, DateTimeKind.Utc).AddTicks(2604));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 263, DateTimeKind.Utc).AddTicks(2607));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 263, DateTimeKind.Utc).AddTicks(2609));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 263, DateTimeKind.Utc).AddTicks(2612));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 263, DateTimeKind.Utc).AddTicks(2614));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 263, DateTimeKind.Utc).AddTicks(2617));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 263, DateTimeKind.Utc).AddTicks(2619));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 272, DateTimeKind.Utc).AddTicks(6204));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 272, DateTimeKind.Utc).AddTicks(7846));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 272, DateTimeKind.Utc).AddTicks(7851));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 272, DateTimeKind.Utc).AddTicks(7857));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 272, DateTimeKind.Utc).AddTicks(7861));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 272, DateTimeKind.Utc).AddTicks(7879));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 272, DateTimeKind.Utc).AddTicks(7883));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 272, DateTimeKind.Utc).AddTicks(7887));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 272, DateTimeKind.Utc).AddTicks(7896));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 272, DateTimeKind.Utc).AddTicks(7902));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 272, DateTimeKind.Utc).AddTicks(7905));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 272, DateTimeKind.Utc).AddTicks(7909));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 272, DateTimeKind.Utc).AddTicks(7913));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 272, DateTimeKind.Utc).AddTicks(7917));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 272, DateTimeKind.Utc).AddTicks(7920));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 272, DateTimeKind.Utc).AddTicks(7924));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 272, DateTimeKind.Utc).AddTicks(7930));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 272, DateTimeKind.Utc).AddTicks(7973));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 272, DateTimeKind.Utc).AddTicks(7977));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 272, DateTimeKind.Utc).AddTicks(7981));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 272, DateTimeKind.Utc).AddTicks(7985));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 272, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 272, DateTimeKind.Utc).AddTicks(7992));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 272, DateTimeKind.Utc).AddTicks(7996));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 276, DateTimeKind.Utc).AddTicks(260));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 276, DateTimeKind.Utc).AddTicks(4752));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 276, DateTimeKind.Utc).AddTicks(4756));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 276, DateTimeKind.Utc).AddTicks(4762));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 276, DateTimeKind.Utc).AddTicks(4765));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 276, DateTimeKind.Utc).AddTicks(4788));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 276, DateTimeKind.Utc).AddTicks(4792));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 276, DateTimeKind.Utc).AddTicks(4795));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 276, DateTimeKind.Utc).AddTicks(4798));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 276, DateTimeKind.Utc).AddTicks(4803));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 276, DateTimeKind.Utc).AddTicks(4807));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 276, DateTimeKind.Utc).AddTicks(4811));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 276, DateTimeKind.Utc).AddTicks(4818));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 276, DateTimeKind.Utc).AddTicks(4821));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 276, DateTimeKind.Utc).AddTicks(4823));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 269, DateTimeKind.Utc).AddTicks(6817));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 269, DateTimeKind.Utc).AddTicks(7436));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 269, DateTimeKind.Utc).AddTicks(7444));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 268, DateTimeKind.Utc).AddTicks(4600));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 268, DateTimeKind.Utc).AddTicks(4972));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 268, DateTimeKind.Utc).AddTicks(4974));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 268, DateTimeKind.Utc).AddTicks(4976));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 268, DateTimeKind.Utc).AddTicks(4978));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 268, DateTimeKind.Utc).AddTicks(4980));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 268, DateTimeKind.Utc).AddTicks(4982));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 268, DateTimeKind.Utc).AddTicks(4985));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 261, DateTimeKind.Utc).AddTicks(4055));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 261, DateTimeKind.Utc).AddTicks(4417));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 261, DateTimeKind.Utc).AddTicks(4420));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 261, DateTimeKind.Utc).AddTicks(4422));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 261, DateTimeKind.Utc).AddTicks(4424));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 261, DateTimeKind.Utc).AddTicks(4427));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 266, DateTimeKind.Utc).AddTicks(4947));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 266, DateTimeKind.Utc).AddTicks(5277));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 266, DateTimeKind.Utc).AddTicks(5279));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 13, 17, 24, 50, 266, DateTimeKind.Utc).AddTicks(5282));
        }
    }
}
