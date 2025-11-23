using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kokomija.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryTranslations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Categories",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Categories",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Categories",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CultureCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: true),
                    MetaKeywords = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryTranslations_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 21, 20, 48, 22, 394, DateTimeKind.Utc).AddTicks(592), new DateTime(2025, 11, 21, 20, 48, 22, 394, DateTimeKind.Utc).AddTicks(954) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 21, 20, 48, 22, 394, DateTimeKind.Utc).AddTicks(1271), new DateTime(2025, 11, 21, 20, 48, 22, 394, DateTimeKind.Utc).AddTicks(1271) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 21, 20, 48, 22, 394, DateTimeKind.Utc).AddTicks(1274), new DateTime(2025, 11, 21, 20, 48, 22, 394, DateTimeKind.Utc).AddTicks(1275) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 21, 20, 48, 22, 394, DateTimeKind.Utc).AddTicks(1277), new DateTime(2025, 11, 21, 20, 48, 22, 394, DateTimeKind.Utc).AddTicks(1278) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 21, 20, 48, 22, 394, DateTimeKind.Utc).AddTicks(1280), new DateTime(2025, 11, 21, 20, 48, 22, 394, DateTimeKind.Utc).AddTicks(1281) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ImageAlt", "RouteParameters", "Subtitle" },
                values: new object[] { new DateTime(2025, 11, 21, 20, 48, 22, 401, DateTimeKind.Utc).AddTicks(2824), "Kokomija Spring 2025 Fashion Collection - Premium Women's and Men's Underwear", null, "Discover the latest trends in women's and men's fashion" });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ImageAlt", "RouteParameters", "Subtitle" },
                values: new object[] { new DateTime(2025, 11, 21, 20, 48, 22, 401, DateTimeKind.Utc).AddTicks(3138), "Kokomija Kolekcja Wiosna 2025 - Wysokiej Jakości Bielizna Damska i Męska", null, "Odkryj najnowsze trendy w modzie damskiej i męskiej" });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 21, 20, 48, 22, 400, DateTimeKind.Utc).AddTicks(6002), new DateTime(2025, 11, 21, 20, 48, 22, 400, DateTimeKind.Utc).AddTicks(5658) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 11, 21, 20, 48, 22, 391, DateTimeKind.Utc).AddTicks(9189), null, null, null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 11, 21, 20, 48, 22, 391, DateTimeKind.Utc).AddTicks(9802), null, null, null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 11, 21, 20, 48, 22, 391, DateTimeKind.Utc).AddTicks(9804), null, null, null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 11, 21, 20, 48, 22, 391, DateTimeKind.Utc).AddTicks(9807), null, null, null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 11, 21, 20, 48, 22, 392, DateTimeKind.Utc).AddTicks(454), null, null, null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 11, 21, 20, 48, 22, 392, DateTimeKind.Utc).AddTicks(461), null, null, null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 11, 21, 20, 48, 22, 392, DateTimeKind.Utc).AddTicks(464), null, null, null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 11, 21, 20, 48, 22, 392, DateTimeKind.Utc).AddTicks(467), null, null, null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 11, 21, 20, 48, 22, 392, DateTimeKind.Utc).AddTicks(470), null, null, null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 11, 21, 20, 48, 22, 392, DateTimeKind.Utc).AddTicks(473), null, null, null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 11, 21, 20, 48, 22, 392, DateTimeKind.Utc).AddTicks(476), null, null, null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new DateTime(2025, 11, 21, 20, 48, 22, 392, DateTimeKind.Utc).AddTicks(479), null, null, null });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 390, DateTimeKind.Utc).AddTicks(3018));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 390, DateTimeKind.Utc).AddTicks(3553));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 390, DateTimeKind.Utc).AddTicks(3557));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 390, DateTimeKind.Utc).AddTicks(3560));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 390, DateTimeKind.Utc).AddTicks(3563));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 390, DateTimeKind.Utc).AddTicks(3566));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 390, DateTimeKind.Utc).AddTicks(3568));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 390, DateTimeKind.Utc).AddTicks(3570));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2025, 11, 21, 20, 48, 22, 396, DateTimeKind.Utc).AddTicks(1375), new DateTime(2025, 11, 21, 20, 48, 22, 395, DateTimeKind.Utc).AddTicks(9501), new DateTime(2026, 5, 21, 20, 48, 22, 395, DateTimeKind.Utc).AddTicks(9974) });

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 396, DateTimeKind.Utc).AddTicks(6115));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 398, DateTimeKind.Utc).AddTicks(5708));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 398, DateTimeKind.Utc).AddTicks(6269));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 398, DateTimeKind.Utc).AddTicks(6276));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 398, DateTimeKind.Utc).AddTicks(6282));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 398, DateTimeKind.Utc).AddTicks(6287));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 398, DateTimeKind.Utc).AddTicks(6305));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 398, DateTimeKind.Utc).AddTicks(6312));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 398, DateTimeKind.Utc).AddTicks(6315));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 398, DateTimeKind.Utc).AddTicks(6322));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 398, DateTimeKind.Utc).AddTicks(6331));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 398, DateTimeKind.Utc).AddTicks(6334));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 398, DateTimeKind.Utc).AddTicks(6340));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 398, DateTimeKind.Utc).AddTicks(6344));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 398, DateTimeKind.Utc).AddTicks(6347));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 398, DateTimeKind.Utc).AddTicks(6352));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 398, DateTimeKind.Utc).AddTicks(6515));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 398, DateTimeKind.Utc).AddTicks(6522));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 398, DateTimeKind.Utc).AddTicks(6529));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 398, DateTimeKind.Utc).AddTicks(6533));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 398, DateTimeKind.Utc).AddTicks(6536));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 398, DateTimeKind.Utc).AddTicks(6540));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 398, DateTimeKind.Utc).AddTicks(6544));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 398, DateTimeKind.Utc).AddTicks(6548));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 398, DateTimeKind.Utc).AddTicks(6552));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 399, DateTimeKind.Utc).AddTicks(8186));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 399, DateTimeKind.Utc).AddTicks(8523));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 399, DateTimeKind.Utc).AddTicks(8526));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 399, DateTimeKind.Utc).AddTicks(8528));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 399, DateTimeKind.Utc).AddTicks(8530));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 399, DateTimeKind.Utc).AddTicks(8538));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 399, DateTimeKind.Utc).AddTicks(8540));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 399, DateTimeKind.Utc).AddTicks(8542));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 399, DateTimeKind.Utc).AddTicks(8544));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 399, DateTimeKind.Utc).AddTicks(8547));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 399, DateTimeKind.Utc).AddTicks(8551));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 399, DateTimeKind.Utc).AddTicks(8553));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 399, DateTimeKind.Utc).AddTicks(8555));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 399, DateTimeKind.Utc).AddTicks(8557));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 399, DateTimeKind.Utc).AddTicks(8559));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 397, DateTimeKind.Utc).AddTicks(6268));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 397, DateTimeKind.Utc).AddTicks(6881));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 397, DateTimeKind.Utc).AddTicks(6886));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 395, DateTimeKind.Utc).AddTicks(469));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 395, DateTimeKind.Utc).AddTicks(829));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 395, DateTimeKind.Utc).AddTicks(831));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 395, DateTimeKind.Utc).AddTicks(909));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 395, DateTimeKind.Utc).AddTicks(911));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 395, DateTimeKind.Utc).AddTicks(913));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 395, DateTimeKind.Utc).AddTicks(915));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 395, DateTimeKind.Utc).AddTicks(917));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 395, DateTimeKind.Utc).AddTicks(919));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 395, DateTimeKind.Utc).AddTicks(921));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 395, DateTimeKind.Utc).AddTicks(923));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 388, DateTimeKind.Utc).AddTicks(906));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 388, DateTimeKind.Utc).AddTicks(1275));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 388, DateTimeKind.Utc).AddTicks(1439));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 388, DateTimeKind.Utc).AddTicks(1442));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 388, DateTimeKind.Utc).AddTicks(1444));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 388, DateTimeKind.Utc).AddTicks(1446));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 392, DateTimeKind.Utc).AddTicks(9449));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 20, 48, 22, 392, DateTimeKind.Utc).AddTicks(9778));

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTranslations_CategoryId_CultureCode",
                table: "CategoryTranslations",
                columns: new[] { "CategoryId", "CultureCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTranslations_Slug_CultureCode",
                table: "CategoryTranslations",
                columns: new[] { "Slug", "CultureCode" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryTranslations");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Categories",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 21, 16, 51, 22, 368, DateTimeKind.Utc).AddTicks(9578), new DateTime(2025, 11, 21, 16, 51, 22, 369, DateTimeKind.Utc).AddTicks(149) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 21, 16, 51, 22, 369, DateTimeKind.Utc).AddTicks(619), new DateTime(2025, 11, 21, 16, 51, 22, 369, DateTimeKind.Utc).AddTicks(620) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 21, 16, 51, 22, 369, DateTimeKind.Utc).AddTicks(630), new DateTime(2025, 11, 21, 16, 51, 22, 369, DateTimeKind.Utc).AddTicks(634) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 21, 16, 51, 22, 369, DateTimeKind.Utc).AddTicks(637), new DateTime(2025, 11, 21, 16, 51, 22, 369, DateTimeKind.Utc).AddTicks(637) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 11, 21, 16, 51, 22, 369, DateTimeKind.Utc).AddTicks(644), new DateTime(2025, 11, 21, 16, 51, 22, 369, DateTimeKind.Utc).AddTicks(645) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ImageAlt", "RouteParameters", "Subtitle" },
                values: new object[] { new DateTime(2025, 11, 21, 16, 51, 22, 410, DateTimeKind.Utc).AddTicks(7979), "New Spring 2025 Collection - Premium women's fashion", "{\"category\":\"women\"}", "Discover the latest trends in women's fashion" });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ImageAlt", "RouteParameters", "Subtitle" },
                values: new object[] { new DateTime(2025, 11, 21, 16, 51, 22, 410, DateTimeKind.Utc).AddTicks(8350), "Nowa Kolekcja Wiosna 2025 - Wysokiej jakości moda damska", "{\"category\":\"damskie\"}", "Odkryj najnowsze trendy w modzie damskiej" });

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 11, 21, 16, 51, 22, 409, DateTimeKind.Utc).AddTicks(1674), new DateTime(2025, 11, 21, 16, 51, 22, 409, DateTimeKind.Utc).AddTicks(1102) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 365, DateTimeKind.Utc).AddTicks(2494));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 365, DateTimeKind.Utc).AddTicks(3048));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 365, DateTimeKind.Utc).AddTicks(3052));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 365, DateTimeKind.Utc).AddTicks(3058));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 365, DateTimeKind.Utc).AddTicks(3571));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 365, DateTimeKind.Utc).AddTicks(3579));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 365, DateTimeKind.Utc).AddTicks(3582));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 365, DateTimeKind.Utc).AddTicks(3585));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 365, DateTimeKind.Utc).AddTicks(3589));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 365, DateTimeKind.Utc).AddTicks(3593));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 365, DateTimeKind.Utc).AddTicks(3599));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 365, DateTimeKind.Utc).AddTicks(3603));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 328, DateTimeKind.Utc).AddTicks(4867));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 328, DateTimeKind.Utc).AddTicks(5936));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 328, DateTimeKind.Utc).AddTicks(5939));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 328, DateTimeKind.Utc).AddTicks(5944));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 328, DateTimeKind.Utc).AddTicks(5949));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 328, DateTimeKind.Utc).AddTicks(5953));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 328, DateTimeKind.Utc).AddTicks(5956));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 328, DateTimeKind.Utc).AddTicks(5960));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2025, 11, 21, 16, 51, 22, 388, DateTimeKind.Utc).AddTicks(7003), new DateTime(2025, 11, 21, 16, 51, 22, 385, DateTimeKind.Utc).AddTicks(803), new DateTime(2026, 5, 21, 16, 51, 22, 385, DateTimeKind.Utc).AddTicks(1859) });

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 393, DateTimeKind.Utc).AddTicks(8484));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 403, DateTimeKind.Utc).AddTicks(9115));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 403, DateTimeKind.Utc).AddTicks(9729));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 403, DateTimeKind.Utc).AddTicks(9735));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 403, DateTimeKind.Utc).AddTicks(9740));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 403, DateTimeKind.Utc).AddTicks(9746));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 403, DateTimeKind.Utc).AddTicks(9768));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 403, DateTimeKind.Utc).AddTicks(9771));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 403, DateTimeKind.Utc).AddTicks(9775));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 403, DateTimeKind.Utc).AddTicks(9782));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 403, DateTimeKind.Utc).AddTicks(9790));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 403, DateTimeKind.Utc).AddTicks(9796));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 403, DateTimeKind.Utc).AddTicks(9800));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 403, DateTimeKind.Utc).AddTicks(9804));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 403, DateTimeKind.Utc).AddTicks(9944));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 403, DateTimeKind.Utc).AddTicks(9950));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 403, DateTimeKind.Utc).AddTicks(9956));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 403, DateTimeKind.Utc).AddTicks(9962));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 403, DateTimeKind.Utc).AddTicks(9970));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 403, DateTimeKind.Utc).AddTicks(9976));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 403, DateTimeKind.Utc).AddTicks(9981));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 403, DateTimeKind.Utc).AddTicks(9985));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 403, DateTimeKind.Utc).AddTicks(9989));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 403, DateTimeKind.Utc).AddTicks(9994));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 404, DateTimeKind.Utc).AddTicks(1));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 407, DateTimeKind.Utc).AddTicks(5380));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 407, DateTimeKind.Utc).AddTicks(5900));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 407, DateTimeKind.Utc).AddTicks(5905));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 407, DateTimeKind.Utc).AddTicks(5909));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 407, DateTimeKind.Utc).AddTicks(5912));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 407, DateTimeKind.Utc).AddTicks(5930));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 407, DateTimeKind.Utc).AddTicks(5934));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 407, DateTimeKind.Utc).AddTicks(5937));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 407, DateTimeKind.Utc).AddTicks(5940));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 407, DateTimeKind.Utc).AddTicks(5945));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 407, DateTimeKind.Utc).AddTicks(5950));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 407, DateTimeKind.Utc).AddTicks(5953));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 407, DateTimeKind.Utc).AddTicks(5956));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 407, DateTimeKind.Utc).AddTicks(5959));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 407, DateTimeKind.Utc).AddTicks(5963));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 399, DateTimeKind.Utc).AddTicks(3237));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 399, DateTimeKind.Utc).AddTicks(3827));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 399, DateTimeKind.Utc).AddTicks(3836));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 374, DateTimeKind.Utc).AddTicks(6198));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 374, DateTimeKind.Utc).AddTicks(7907));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 374, DateTimeKind.Utc).AddTicks(7910));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 374, DateTimeKind.Utc).AddTicks(7915));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 374, DateTimeKind.Utc).AddTicks(7918));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 374, DateTimeKind.Utc).AddTicks(7920));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 374, DateTimeKind.Utc).AddTicks(7924));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 374, DateTimeKind.Utc).AddTicks(7926));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 374, DateTimeKind.Utc).AddTicks(7930));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 374, DateTimeKind.Utc).AddTicks(7937));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 374, DateTimeKind.Utc).AddTicks(7940));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 319, DateTimeKind.Utc).AddTicks(581));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 319, DateTimeKind.Utc).AddTicks(5709));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 319, DateTimeKind.Utc).AddTicks(5714));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 319, DateTimeKind.Utc).AddTicks(5717));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 319, DateTimeKind.Utc).AddTicks(5719));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 319, DateTimeKind.Utc).AddTicks(5722));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 366, DateTimeKind.Utc).AddTicks(7742));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 11, 21, 16, 51, 22, 366, DateTimeKind.Utc).AddTicks(8231));
        }
    }
}
