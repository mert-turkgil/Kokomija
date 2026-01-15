using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kokomija.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPackQuantityAndSizeGuide : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PackQuantityId",
                table: "ProductVariants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PackQuantities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NameKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackQuantities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SizeGuides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ChartImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SizeDataJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeasurementInstructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeasurementInstructionsKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeGuides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SizeGuides_Products_ProductId",
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
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 689, DateTimeKind.Utc).AddTicks(9406), new DateTime(2026, 1, 14, 15, 42, 44, 689, DateTimeKind.Utc).AddTicks(9724) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 690, DateTimeKind.Utc).AddTicks(30), new DateTime(2026, 1, 14, 15, 42, 44, 690, DateTimeKind.Utc).AddTicks(30) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 690, DateTimeKind.Utc).AddTicks(33), new DateTime(2026, 1, 14, 15, 42, 44, 690, DateTimeKind.Utc).AddTicks(33) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 690, DateTimeKind.Utc).AddTicks(36), new DateTime(2026, 1, 14, 15, 42, 44, 690, DateTimeKind.Utc).AddTicks(36) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 690, DateTimeKind.Utc).AddTicks(39), new DateTime(2026, 1, 14, 15, 42, 44, 690, DateTimeKind.Utc).AddTicks(40) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 691, DateTimeKind.Utc).AddTicks(4159), new DateTime(2026, 1, 14, 15, 42, 44, 691, DateTimeKind.Utc).AddTicks(4489) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 691, DateTimeKind.Utc).AddTicks(4802), new DateTime(2026, 1, 14, 15, 42, 44, 691, DateTimeKind.Utc).AddTicks(4803) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 690, DateTimeKind.Utc).AddTicks(5424), new DateTime(2026, 1, 14, 15, 42, 44, 690, DateTimeKind.Utc).AddTicks(4023), new DateTime(2026, 1, 14, 15, 42, 44, 690, DateTimeKind.Utc).AddTicks(5728) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 701, DateTimeKind.Utc).AddTicks(4571));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 701, DateTimeKind.Utc).AddTicks(4954));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 700, DateTimeKind.Utc).AddTicks(8187), new DateTime(2026, 1, 14, 15, 42, 44, 700, DateTimeKind.Utc).AddTicks(7843) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 688, DateTimeKind.Utc).AddTicks(5076));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 688, DateTimeKind.Utc).AddTicks(5512));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 688, DateTimeKind.Utc).AddTicks(5515));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 688, DateTimeKind.Utc).AddTicks(5518));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 688, DateTimeKind.Utc).AddTicks(5882));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 688, DateTimeKind.Utc).AddTicks(5888));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 688, DateTimeKind.Utc).AddTicks(5891));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 688, DateTimeKind.Utc).AddTicks(5894));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 688, DateTimeKind.Utc).AddTicks(5924));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 688, DateTimeKind.Utc).AddTicks(5927));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 688, DateTimeKind.Utc).AddTicks(5930));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 688, DateTimeKind.Utc).AddTicks(5933));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 687, DateTimeKind.Utc).AddTicks(3182));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 687, DateTimeKind.Utc).AddTicks(3492));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 687, DateTimeKind.Utc).AddTicks(3494));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 687, DateTimeKind.Utc).AddTicks(3497));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 687, DateTimeKind.Utc).AddTicks(3499));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 687, DateTimeKind.Utc).AddTicks(3501));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 687, DateTimeKind.Utc).AddTicks(3503));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 687, DateTimeKind.Utc).AddTicks(3505));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 695, DateTimeKind.Utc).AddTicks(7629), new DateTime(2026, 1, 14, 15, 42, 44, 695, DateTimeKind.Utc).AddTicks(5928), new DateTime(2026, 7, 14, 15, 42, 44, 695, DateTimeKind.Utc).AddTicks(6248) });

            migrationBuilder.InsertData(
                table: "PackQuantities",
                columns: new[] { "Id", "CreatedAt", "DisplayOrder", "IsActive", "Name", "NameKey", "Quantity", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 14, 15, 42, 44, 686, DateTimeKind.Utc).AddTicks(5392), 1, true, "Single", "PackQuantity_Single", 1, null },
                    { 2, new DateTime(2026, 1, 14, 15, 42, 44, 686, DateTimeKind.Utc).AddTicks(5711), 2, true, "5-Pack", "PackQuantity_5Pack", 5, null },
                    { 3, new DateTime(2026, 1, 14, 15, 42, 44, 686, DateTimeKind.Utc).AddTicks(5713), 3, true, "6-Pack", "PackQuantity_6Pack", 6, null },
                    { 4, new DateTime(2026, 1, 14, 15, 42, 44, 686, DateTimeKind.Utc).AddTicks(5715), 4, true, "8-Pack", "PackQuantity_8Pack", 8, null },
                    { 5, new DateTime(2026, 1, 14, 15, 42, 44, 686, DateTimeKind.Utc).AddTicks(5717), 5, true, "10-Pack", "PackQuantity_10Pack", 10, null }
                });

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 696, DateTimeKind.Utc).AddTicks(5324));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 698, DateTimeKind.Utc).AddTicks(3793));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 698, DateTimeKind.Utc).AddTicks(4122));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 698, DateTimeKind.Utc).AddTicks(4127));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 698, DateTimeKind.Utc).AddTicks(4129));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 698, DateTimeKind.Utc).AddTicks(4133));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 698, DateTimeKind.Utc).AddTicks(4143));

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 698, DateTimeKind.Utc).AddTicks(9729), new DateTime(2026, 1, 14, 15, 42, 44, 698, DateTimeKind.Utc).AddTicks(9730) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 699, DateTimeKind.Utc).AddTicks(1981), new DateTime(2026, 1, 14, 15, 42, 44, 699, DateTimeKind.Utc).AddTicks(1982) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 699, DateTimeKind.Utc).AddTicks(1985), new DateTime(2026, 1, 14, 15, 42, 44, 699, DateTimeKind.Utc).AddTicks(1985) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 699, DateTimeKind.Utc).AddTicks(1987), new DateTime(2026, 1, 14, 15, 42, 44, 699, DateTimeKind.Utc).AddTicks(1988) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 699, DateTimeKind.Utc).AddTicks(1989), new DateTime(2026, 1, 14, 15, 42, 44, 699, DateTimeKind.Utc).AddTicks(1990) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 699, DateTimeKind.Utc).AddTicks(1992), new DateTime(2026, 1, 14, 15, 42, 44, 699, DateTimeKind.Utc).AddTicks(1992) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PackQuantityId" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 700, DateTimeKind.Utc).AddTicks(325), null });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PackQuantityId" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 700, DateTimeKind.Utc).AddTicks(848), null });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PackQuantityId" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 700, DateTimeKind.Utc).AddTicks(850), null });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PackQuantityId" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 700, DateTimeKind.Utc).AddTicks(852), null });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "PackQuantityId" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 700, DateTimeKind.Utc).AddTicks(854), null });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "PackQuantityId" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 700, DateTimeKind.Utc).AddTicks(862), null });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "PackQuantityId" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 700, DateTimeKind.Utc).AddTicks(889), null });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "PackQuantityId" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 700, DateTimeKind.Utc).AddTicks(891), null });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "PackQuantityId" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 700, DateTimeKind.Utc).AddTicks(893), null });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "PackQuantityId" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 700, DateTimeKind.Utc).AddTicks(896), null });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "PackQuantityId" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 700, DateTimeKind.Utc).AddTicks(900), null });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "PackQuantityId" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 700, DateTimeKind.Utc).AddTicks(902), null });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "PackQuantityId" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 700, DateTimeKind.Utc).AddTicks(904), null });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "PackQuantityId" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 700, DateTimeKind.Utc).AddTicks(906), null });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "PackQuantityId" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 700, DateTimeKind.Utc).AddTicks(907), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 697, DateTimeKind.Utc).AddTicks(6203));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 697, DateTimeKind.Utc).AddTicks(6509));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 697, DateTimeKind.Utc).AddTicks(6513));

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 693, DateTimeKind.Utc).AddTicks(393), new DateTime(2026, 1, 14, 15, 42, 44, 693, DateTimeKind.Utc).AddTicks(696) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 693, DateTimeKind.Utc).AddTicks(989), new DateTime(2026, 1, 14, 15, 42, 44, 693, DateTimeKind.Utc).AddTicks(989) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 693, DateTimeKind.Utc).AddTicks(992), new DateTime(2026, 1, 14, 15, 42, 44, 693, DateTimeKind.Utc).AddTicks(993) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 693, DateTimeKind.Utc).AddTicks(996), new DateTime(2026, 1, 14, 15, 42, 44, 693, DateTimeKind.Utc).AddTicks(996) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 693, DateTimeKind.Utc).AddTicks(999), new DateTime(2026, 1, 14, 15, 42, 44, 693, DateTimeKind.Utc).AddTicks(999) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 694, DateTimeKind.Utc).AddTicks(175), new DateTime(2026, 1, 14, 15, 42, 44, 694, DateTimeKind.Utc).AddTicks(474) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 694, DateTimeKind.Utc).AddTicks(774), new DateTime(2026, 1, 14, 15, 42, 44, 694, DateTimeKind.Utc).AddTicks(775) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 694, DateTimeKind.Utc).AddTicks(805), new DateTime(2026, 1, 14, 15, 42, 44, 694, DateTimeKind.Utc).AddTicks(805) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 694, DateTimeKind.Utc).AddTicks(808), new DateTime(2026, 1, 14, 15, 42, 44, 694, DateTimeKind.Utc).AddTicks(809) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 694, DateTimeKind.Utc).AddTicks(812), new DateTime(2026, 1, 14, 15, 42, 44, 694, DateTimeKind.Utc).AddTicks(813) });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 692, DateTimeKind.Utc).AddTicks(3060));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 692, DateTimeKind.Utc).AddTicks(3367));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 692, DateTimeKind.Utc).AddTicks(3369));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 692, DateTimeKind.Utc).AddTicks(3371));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 692, DateTimeKind.Utc).AddTicks(3373));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 692, DateTimeKind.Utc).AddTicks(3375));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 692, DateTimeKind.Utc).AddTicks(3377));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 692, DateTimeKind.Utc).AddTicks(3378));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 692, DateTimeKind.Utc).AddTicks(3380));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 692, DateTimeKind.Utc).AddTicks(3382));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 692, DateTimeKind.Utc).AddTicks(3384));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 685, DateTimeKind.Utc).AddTicks(2036));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 685, DateTimeKind.Utc).AddTicks(2567));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 685, DateTimeKind.Utc).AddTicks(2569));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 685, DateTimeKind.Utc).AddTicks(2571));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 685, DateTimeKind.Utc).AddTicks(2573));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 685, DateTimeKind.Utc).AddTicks(2576));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 689, DateTimeKind.Utc).AddTicks(1430));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 14, 15, 42, 44, 689, DateTimeKind.Utc).AddTicks(1739));

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 694, DateTimeKind.Utc).AddTicks(7012), new DateTime(2026, 1, 14, 15, 42, 44, 694, DateTimeKind.Utc).AddTicks(7316) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 694, DateTimeKind.Utc).AddTicks(7613), new DateTime(2026, 1, 14, 15, 42, 44, 694, DateTimeKind.Utc).AddTicks(7613) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 14, 15, 42, 44, 694, DateTimeKind.Utc).AddTicks(7616), new DateTime(2026, 1, 14, 15, 42, 44, 694, DateTimeKind.Utc).AddTicks(7617) });

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_PackQuantityId",
                table: "ProductVariants",
                column: "PackQuantityId");

            migrationBuilder.CreateIndex(
                name: "IX_SizeGuides_ProductId",
                table: "SizeGuides",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariants_PackQuantities_PackQuantityId",
                table: "ProductVariants",
                column: "PackQuantityId",
                principalTable: "PackQuantities",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariants_PackQuantities_PackQuantityId",
                table: "ProductVariants");

            migrationBuilder.DropTable(
                name: "PackQuantities");

            migrationBuilder.DropTable(
                name: "SizeGuides");

            migrationBuilder.DropIndex(
                name: "IX_ProductVariants_PackQuantityId",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "PackQuantityId",
                table: "ProductVariants");

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 64, DateTimeKind.Utc).AddTicks(2272), new DateTime(2026, 1, 9, 13, 2, 32, 64, DateTimeKind.Utc).AddTicks(2659) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 64, DateTimeKind.Utc).AddTicks(3082), new DateTime(2026, 1, 9, 13, 2, 32, 64, DateTimeKind.Utc).AddTicks(3083) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 64, DateTimeKind.Utc).AddTicks(3086), new DateTime(2026, 1, 9, 13, 2, 32, 64, DateTimeKind.Utc).AddTicks(3087) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 64, DateTimeKind.Utc).AddTicks(3090), new DateTime(2026, 1, 9, 13, 2, 32, 64, DateTimeKind.Utc).AddTicks(3091) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 64, DateTimeKind.Utc).AddTicks(3094), new DateTime(2026, 1, 9, 13, 2, 32, 64, DateTimeKind.Utc).AddTicks(3095) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 68, DateTimeKind.Utc).AddTicks(1470), new DateTime(2026, 1, 9, 13, 2, 32, 68, DateTimeKind.Utc).AddTicks(2013) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 68, DateTimeKind.Utc).AddTicks(3937), new DateTime(2026, 1, 9, 13, 2, 32, 68, DateTimeKind.Utc).AddTicks(3941) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 65, DateTimeKind.Utc).AddTicks(2194), new DateTime(2026, 1, 9, 13, 2, 32, 64, DateTimeKind.Utc).AddTicks(9974), new DateTime(2026, 1, 9, 13, 2, 32, 65, DateTimeKind.Utc).AddTicks(2670) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 95, DateTimeKind.Utc).AddTicks(1991));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 95, DateTimeKind.Utc).AddTicks(3319));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 93, DateTimeKind.Utc).AddTicks(2880), new DateTime(2026, 1, 9, 13, 2, 32, 93, DateTimeKind.Utc).AddTicks(2358) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 59, DateTimeKind.Utc).AddTicks(8086));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 59, DateTimeKind.Utc).AddTicks(8532));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 59, DateTimeKind.Utc).AddTicks(8536));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 59, DateTimeKind.Utc).AddTicks(8539));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 59, DateTimeKind.Utc).AddTicks(8997));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 59, DateTimeKind.Utc).AddTicks(9004));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 59, DateTimeKind.Utc).AddTicks(9008));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 59, DateTimeKind.Utc).AddTicks(9012));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 59, DateTimeKind.Utc).AddTicks(9016));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 59, DateTimeKind.Utc).AddTicks(9020));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 59, DateTimeKind.Utc).AddTicks(9068));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 59, DateTimeKind.Utc).AddTicks(9074));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 57, DateTimeKind.Utc).AddTicks(7074));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 57, DateTimeKind.Utc).AddTicks(7621));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 57, DateTimeKind.Utc).AddTicks(7624));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 57, DateTimeKind.Utc).AddTicks(7627));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 57, DateTimeKind.Utc).AddTicks(7631));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 57, DateTimeKind.Utc).AddTicks(7634));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 57, DateTimeKind.Utc).AddTicks(7636));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 57, DateTimeKind.Utc).AddTicks(7639));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 80, DateTimeKind.Utc).AddTicks(122), new DateTime(2026, 1, 9, 13, 2, 32, 79, DateTimeKind.Utc).AddTicks(6163), new DateTime(2026, 7, 9, 13, 2, 32, 79, DateTimeKind.Utc).AddTicks(7541) });

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 81, DateTimeKind.Utc).AddTicks(4519));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 87, DateTimeKind.Utc).AddTicks(4434));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 87, DateTimeKind.Utc).AddTicks(6073));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 87, DateTimeKind.Utc).AddTicks(6080));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 87, DateTimeKind.Utc).AddTicks(6086));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 87, DateTimeKind.Utc).AddTicks(6093));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 87, DateTimeKind.Utc).AddTicks(6116));

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 88, DateTimeKind.Utc).AddTicks(7888), new DateTime(2026, 1, 9, 13, 2, 32, 88, DateTimeKind.Utc).AddTicks(7892) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 89, DateTimeKind.Utc).AddTicks(1060), new DateTime(2026, 1, 9, 13, 2, 32, 89, DateTimeKind.Utc).AddTicks(1061) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 89, DateTimeKind.Utc).AddTicks(1065), new DateTime(2026, 1, 9, 13, 2, 32, 89, DateTimeKind.Utc).AddTicks(1066) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 89, DateTimeKind.Utc).AddTicks(1069), new DateTime(2026, 1, 9, 13, 2, 32, 89, DateTimeKind.Utc).AddTicks(1070) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 89, DateTimeKind.Utc).AddTicks(1073), new DateTime(2026, 1, 9, 13, 2, 32, 89, DateTimeKind.Utc).AddTicks(1073) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 89, DateTimeKind.Utc).AddTicks(1076), new DateTime(2026, 1, 9, 13, 2, 32, 89, DateTimeKind.Utc).AddTicks(1077) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 91, DateTimeKind.Utc).AddTicks(5581));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 91, DateTimeKind.Utc).AddTicks(7999));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 91, DateTimeKind.Utc).AddTicks(8003));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 91, DateTimeKind.Utc).AddTicks(8010));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 91, DateTimeKind.Utc).AddTicks(8014));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 91, DateTimeKind.Utc).AddTicks(8034));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 91, DateTimeKind.Utc).AddTicks(8037));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 91, DateTimeKind.Utc).AddTicks(8042));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 91, DateTimeKind.Utc).AddTicks(8046));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 91, DateTimeKind.Utc).AddTicks(8094));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 91, DateTimeKind.Utc).AddTicks(8101));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 91, DateTimeKind.Utc).AddTicks(8106));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 91, DateTimeKind.Utc).AddTicks(8111));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 91, DateTimeKind.Utc).AddTicks(8115));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 91, DateTimeKind.Utc).AddTicks(8121));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 85, DateTimeKind.Utc).AddTicks(113));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 85, DateTimeKind.Utc).AddTicks(663));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 85, DateTimeKind.Utc).AddTicks(668));

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 73, DateTimeKind.Utc).AddTicks(425), new DateTime(2026, 1, 9, 13, 2, 32, 73, DateTimeKind.Utc).AddTicks(829) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 73, DateTimeKind.Utc).AddTicks(1371), new DateTime(2026, 1, 9, 13, 2, 32, 73, DateTimeKind.Utc).AddTicks(1373) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 73, DateTimeKind.Utc).AddTicks(1376), new DateTime(2026, 1, 9, 13, 2, 32, 73, DateTimeKind.Utc).AddTicks(1377) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 73, DateTimeKind.Utc).AddTicks(1380), new DateTime(2026, 1, 9, 13, 2, 32, 73, DateTimeKind.Utc).AddTicks(1381) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 73, DateTimeKind.Utc).AddTicks(1385), new DateTime(2026, 1, 9, 13, 2, 32, 73, DateTimeKind.Utc).AddTicks(1386) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 75, DateTimeKind.Utc).AddTicks(786), new DateTime(2026, 1, 9, 13, 2, 32, 75, DateTimeKind.Utc).AddTicks(1286) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 75, DateTimeKind.Utc).AddTicks(1724), new DateTime(2026, 1, 9, 13, 2, 32, 75, DateTimeKind.Utc).AddTicks(1725) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 75, DateTimeKind.Utc).AddTicks(1732), new DateTime(2026, 1, 9, 13, 2, 32, 75, DateTimeKind.Utc).AddTicks(1734) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 75, DateTimeKind.Utc).AddTicks(1738), new DateTime(2026, 1, 9, 13, 2, 32, 75, DateTimeKind.Utc).AddTicks(1740) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 75, DateTimeKind.Utc).AddTicks(1799), new DateTime(2026, 1, 9, 13, 2, 32, 75, DateTimeKind.Utc).AddTicks(1801) });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 70, DateTimeKind.Utc).AddTicks(2888));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 71, DateTimeKind.Utc).AddTicks(3131));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 71, DateTimeKind.Utc).AddTicks(3135));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 71, DateTimeKind.Utc).AddTicks(3139));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 71, DateTimeKind.Utc).AddTicks(3142));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 71, DateTimeKind.Utc).AddTicks(3144));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 71, DateTimeKind.Utc).AddTicks(3146));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 71, DateTimeKind.Utc).AddTicks(3148));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 71, DateTimeKind.Utc).AddTicks(3150));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 71, DateTimeKind.Utc).AddTicks(3152));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 71, DateTimeKind.Utc).AddTicks(3155));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 54, DateTimeKind.Utc).AddTicks(6422));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 54, DateTimeKind.Utc).AddTicks(6757));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 54, DateTimeKind.Utc).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 54, DateTimeKind.Utc).AddTicks(6762));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 54, DateTimeKind.Utc).AddTicks(6765));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 54, DateTimeKind.Utc).AddTicks(6767));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 61, DateTimeKind.Utc).AddTicks(6515));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 9, 13, 2, 32, 61, DateTimeKind.Utc).AddTicks(9112));

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 78, DateTimeKind.Utc).AddTicks(100), new DateTime(2026, 1, 9, 13, 2, 32, 78, DateTimeKind.Utc).AddTicks(564) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 78, DateTimeKind.Utc).AddTicks(992), new DateTime(2026, 1, 9, 13, 2, 32, 78, DateTimeKind.Utc).AddTicks(992) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 9, 13, 2, 32, 78, DateTimeKind.Utc).AddTicks(997), new DateTime(2026, 1, 9, 13, 2, 32, 78, DateTimeKind.Utc).AddTicks(997) });
        }
    }
}
