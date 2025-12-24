using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kokomija.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDeveloperCommissionRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeveloperCommissionRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeveloperId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CurrentRate = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    RequestedRate = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ReviewedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AdminResponse = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ReviewedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdminNotified = table.Column<bool>(type: "bit", nullable: false),
                    DeveloperNotified = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperCommissionRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeveloperCommissionRequests_AspNetUsers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperCommissionRequests_AspNetUsers_ReviewedById",
                        column: x => x.ReviewedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 15, DateTimeKind.Utc).AddTicks(2174), new DateTime(2025, 12, 19, 16, 7, 56, 15, DateTimeKind.Utc).AddTicks(2485) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 15, DateTimeKind.Utc).AddTicks(2784), new DateTime(2025, 12, 19, 16, 7, 56, 15, DateTimeKind.Utc).AddTicks(2785) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 15, DateTimeKind.Utc).AddTicks(2787), new DateTime(2025, 12, 19, 16, 7, 56, 15, DateTimeKind.Utc).AddTicks(2788) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 15, DateTimeKind.Utc).AddTicks(2791), new DateTime(2025, 12, 19, 16, 7, 56, 15, DateTimeKind.Utc).AddTicks(2791) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 15, DateTimeKind.Utc).AddTicks(2794), new DateTime(2025, 12, 19, 16, 7, 56, 15, DateTimeKind.Utc).AddTicks(2794) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 16, DateTimeKind.Utc).AddTicks(5679), new DateTime(2025, 12, 19, 16, 7, 56, 16, DateTimeKind.Utc).AddTicks(5988) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 16, DateTimeKind.Utc).AddTicks(6370), new DateTime(2025, 12, 19, 16, 7, 56, 16, DateTimeKind.Utc).AddTicks(6371) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 15, DateTimeKind.Utc).AddTicks(8607), new DateTime(2025, 12, 19, 16, 7, 56, 15, DateTimeKind.Utc).AddTicks(7258), new DateTime(2025, 12, 19, 16, 7, 56, 15, DateTimeKind.Utc).AddTicks(8906) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 28, DateTimeKind.Utc).AddTicks(2335));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 28, DateTimeKind.Utc).AddTicks(2641));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 27, DateTimeKind.Utc).AddTicks(6031), new DateTime(2025, 12, 19, 16, 7, 56, 27, DateTimeKind.Utc).AddTicks(5689) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 13, DateTimeKind.Utc).AddTicks(4787));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 13, DateTimeKind.Utc).AddTicks(5103));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 13, DateTimeKind.Utc).AddTicks(5106));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 13, DateTimeKind.Utc).AddTicks(5109));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 13, DateTimeKind.Utc).AddTicks(5437));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 13, DateTimeKind.Utc).AddTicks(5444));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 13, DateTimeKind.Utc).AddTicks(5446));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 13, DateTimeKind.Utc).AddTicks(5449));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 13, DateTimeKind.Utc).AddTicks(5452));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 13, DateTimeKind.Utc).AddTicks(5455));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 13, DateTimeKind.Utc).AddTicks(5459));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 13, DateTimeKind.Utc).AddTicks(5461));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 12, DateTimeKind.Utc).AddTicks(1691));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 12, DateTimeKind.Utc).AddTicks(2012));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 12, DateTimeKind.Utc).AddTicks(2014));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 12, DateTimeKind.Utc).AddTicks(2016));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 12, DateTimeKind.Utc).AddTicks(2018));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 12, DateTimeKind.Utc).AddTicks(2020));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 12, DateTimeKind.Utc).AddTicks(2023));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 12, DateTimeKind.Utc).AddTicks(2025));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 22, DateTimeKind.Utc).AddTicks(5375), new DateTime(2025, 12, 19, 16, 7, 56, 22, DateTimeKind.Utc).AddTicks(3360), new DateTime(2026, 6, 19, 16, 7, 56, 22, DateTimeKind.Utc).AddTicks(3743) });

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 23, DateTimeKind.Utc).AddTicks(835));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7356));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7735));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7739));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7742));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7745));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7757));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7760));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7763));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7768));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7811));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7814));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7816));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7818));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7821));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7823));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7825));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7830));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7833));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7836));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7838));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7841));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7843));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7845));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 25, DateTimeKind.Utc).AddTicks(7847));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 26, DateTimeKind.Utc).AddTicks(8170));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 26, DateTimeKind.Utc).AddTicks(8504));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 26, DateTimeKind.Utc).AddTicks(8506));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 26, DateTimeKind.Utc).AddTicks(8508));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 26, DateTimeKind.Utc).AddTicks(8510));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 26, DateTimeKind.Utc).AddTicks(8517));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 26, DateTimeKind.Utc).AddTicks(8520));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 26, DateTimeKind.Utc).AddTicks(8521));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 26, DateTimeKind.Utc).AddTicks(8523));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 26, DateTimeKind.Utc).AddTicks(8526));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 26, DateTimeKind.Utc).AddTicks(8530));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 26, DateTimeKind.Utc).AddTicks(8532));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 26, DateTimeKind.Utc).AddTicks(8534));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 26, DateTimeKind.Utc).AddTicks(8550));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 26, DateTimeKind.Utc).AddTicks(8552));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 24, DateTimeKind.Utc).AddTicks(5154));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 24, DateTimeKind.Utc).AddTicks(5565));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 24, DateTimeKind.Utc).AddTicks(5572));

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 18, DateTimeKind.Utc).AddTicks(7395), new DateTime(2025, 12, 19, 16, 7, 56, 18, DateTimeKind.Utc).AddTicks(7838) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 18, DateTimeKind.Utc).AddTicks(8268), new DateTime(2025, 12, 19, 16, 7, 56, 18, DateTimeKind.Utc).AddTicks(8269) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 18, DateTimeKind.Utc).AddTicks(8273), new DateTime(2025, 12, 19, 16, 7, 56, 18, DateTimeKind.Utc).AddTicks(8273) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 18, DateTimeKind.Utc).AddTicks(8334), new DateTime(2025, 12, 19, 16, 7, 56, 18, DateTimeKind.Utc).AddTicks(8334) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 18, DateTimeKind.Utc).AddTicks(8339), new DateTime(2025, 12, 19, 16, 7, 56, 18, DateTimeKind.Utc).AddTicks(8339) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 20, DateTimeKind.Utc).AddTicks(5326), new DateTime(2025, 12, 19, 16, 7, 56, 20, DateTimeKind.Utc).AddTicks(5697) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 20, DateTimeKind.Utc).AddTicks(6017), new DateTime(2025, 12, 19, 16, 7, 56, 20, DateTimeKind.Utc).AddTicks(6018) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 20, DateTimeKind.Utc).AddTicks(6020), new DateTime(2025, 12, 19, 16, 7, 56, 20, DateTimeKind.Utc).AddTicks(6021) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 20, DateTimeKind.Utc).AddTicks(6025), new DateTime(2025, 12, 19, 16, 7, 56, 20, DateTimeKind.Utc).AddTicks(6025) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 20, DateTimeKind.Utc).AddTicks(6029), new DateTime(2025, 12, 19, 16, 7, 56, 20, DateTimeKind.Utc).AddTicks(6029) });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 17, DateTimeKind.Utc).AddTicks(5505));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 17, DateTimeKind.Utc).AddTicks(5815));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 17, DateTimeKind.Utc).AddTicks(5817));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 17, DateTimeKind.Utc).AddTicks(5819));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 17, DateTimeKind.Utc).AddTicks(5820));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 17, DateTimeKind.Utc).AddTicks(5822));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 17, DateTimeKind.Utc).AddTicks(5824));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 17, DateTimeKind.Utc).AddTicks(5826));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 17, DateTimeKind.Utc).AddTicks(5828));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 17, DateTimeKind.Utc).AddTicks(5830));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 17, DateTimeKind.Utc).AddTicks(5832));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 10, DateTimeKind.Utc).AddTicks(6085));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 10, DateTimeKind.Utc).AddTicks(6423));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 10, DateTimeKind.Utc).AddTicks(6425));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 10, DateTimeKind.Utc).AddTicks(6427));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 10, DateTimeKind.Utc).AddTicks(6430));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 10, DateTimeKind.Utc).AddTicks(6432));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 14, DateTimeKind.Utc).AddTicks(2417));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 19, 16, 7, 56, 14, DateTimeKind.Utc).AddTicks(2796));

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 21, DateTimeKind.Utc).AddTicks(3598), new DateTime(2025, 12, 19, 16, 7, 56, 21, DateTimeKind.Utc).AddTicks(3901) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 21, DateTimeKind.Utc).AddTicks(4203), new DateTime(2025, 12, 19, 16, 7, 56, 21, DateTimeKind.Utc).AddTicks(4204) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 19, 16, 7, 56, 21, DateTimeKind.Utc).AddTicks(4207), new DateTime(2025, 12, 19, 16, 7, 56, 21, DateTimeKind.Utc).AddTicks(4207) });

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperCommissionRequests_DeveloperId",
                table: "DeveloperCommissionRequests",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperCommissionRequests_ReviewedById",
                table: "DeveloperCommissionRequests",
                column: "ReviewedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeveloperCommissionRequests");

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 509, DateTimeKind.Utc).AddTicks(5856), new DateTime(2025, 12, 7, 13, 15, 1, 509, DateTimeKind.Utc).AddTicks(6175) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 509, DateTimeKind.Utc).AddTicks(6494), new DateTime(2025, 12, 7, 13, 15, 1, 509, DateTimeKind.Utc).AddTicks(6495) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 509, DateTimeKind.Utc).AddTicks(6498), new DateTime(2025, 12, 7, 13, 15, 1, 509, DateTimeKind.Utc).AddTicks(6499) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 509, DateTimeKind.Utc).AddTicks(6501), new DateTime(2025, 12, 7, 13, 15, 1, 509, DateTimeKind.Utc).AddTicks(6502) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 509, DateTimeKind.Utc).AddTicks(6505), new DateTime(2025, 12, 7, 13, 15, 1, 509, DateTimeKind.Utc).AddTicks(6506) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 511, DateTimeKind.Utc).AddTicks(6155), new DateTime(2025, 12, 7, 13, 15, 1, 511, DateTimeKind.Utc).AddTicks(8876) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 512, DateTimeKind.Utc).AddTicks(123), new DateTime(2025, 12, 7, 13, 15, 1, 512, DateTimeKind.Utc).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 510, DateTimeKind.Utc).AddTicks(2039), new DateTime(2025, 12, 7, 13, 15, 1, 510, DateTimeKind.Utc).AddTicks(587), new DateTime(2025, 12, 7, 13, 15, 1, 510, DateTimeKind.Utc).AddTicks(2357) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 528, DateTimeKind.Utc).AddTicks(9369));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 528, DateTimeKind.Utc).AddTicks(9783));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 525, DateTimeKind.Utc).AddTicks(4840), new DateTime(2025, 12, 7, 13, 15, 1, 525, DateTimeKind.Utc).AddTicks(4465) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 507, DateTimeKind.Utc).AddTicks(9061));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 507, DateTimeKind.Utc).AddTicks(9546));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 507, DateTimeKind.Utc).AddTicks(9550));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 507, DateTimeKind.Utc).AddTicks(9597));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 508, DateTimeKind.Utc).AddTicks(66));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 508, DateTimeKind.Utc).AddTicks(73));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 508, DateTimeKind.Utc).AddTicks(78));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 508, DateTimeKind.Utc).AddTicks(81));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 508, DateTimeKind.Utc).AddTicks(86));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 508, DateTimeKind.Utc).AddTicks(89));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 508, DateTimeKind.Utc).AddTicks(94));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 508, DateTimeKind.Utc).AddTicks(99));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 504, DateTimeKind.Utc).AddTicks(6457));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 504, DateTimeKind.Utc).AddTicks(6915));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 504, DateTimeKind.Utc).AddTicks(6921));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 504, DateTimeKind.Utc).AddTicks(6924));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 504, DateTimeKind.Utc).AddTicks(6927));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 504, DateTimeKind.Utc).AddTicks(6931));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 504, DateTimeKind.Utc).AddTicks(6934));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 504, DateTimeKind.Utc).AddTicks(6937));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 519, DateTimeKind.Utc).AddTicks(6935), new DateTime(2025, 12, 7, 13, 15, 1, 519, DateTimeKind.Utc).AddTicks(4879), new DateTime(2026, 6, 7, 13, 15, 1, 519, DateTimeKind.Utc).AddTicks(5275) });

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 520, DateTimeKind.Utc).AddTicks(2248));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2183));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2612));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2620));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2625));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2629));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2678));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2682));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2686));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2691));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2697));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2701));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2753));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2757));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2761));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2765));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2768));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2775));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2781));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2785));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2789));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2793));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2797));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2800));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 523, DateTimeKind.Utc).AddTicks(2804));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 524, DateTimeKind.Utc).AddTicks(5798));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 524, DateTimeKind.Utc).AddTicks(6287));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 524, DateTimeKind.Utc).AddTicks(6291));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 524, DateTimeKind.Utc).AddTicks(6293));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 524, DateTimeKind.Utc).AddTicks(6296));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 524, DateTimeKind.Utc).AddTicks(6305));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 524, DateTimeKind.Utc).AddTicks(6309));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 524, DateTimeKind.Utc).AddTicks(6312));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 524, DateTimeKind.Utc).AddTicks(6315));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 524, DateTimeKind.Utc).AddTicks(6320));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 524, DateTimeKind.Utc).AddTicks(6326));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 524, DateTimeKind.Utc).AddTicks(6329));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 524, DateTimeKind.Utc).AddTicks(6333));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 524, DateTimeKind.Utc).AddTicks(6336));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 524, DateTimeKind.Utc).AddTicks(6339));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 522, DateTimeKind.Utc).AddTicks(822));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 522, DateTimeKind.Utc).AddTicks(1437));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 522, DateTimeKind.Utc).AddTicks(1444));

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 514, DateTimeKind.Utc).AddTicks(1199), new DateTime(2025, 12, 7, 13, 15, 1, 514, DateTimeKind.Utc).AddTicks(1517) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 514, DateTimeKind.Utc).AddTicks(1865), new DateTime(2025, 12, 7, 13, 15, 1, 514, DateTimeKind.Utc).AddTicks(1865) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 514, DateTimeKind.Utc).AddTicks(1869), new DateTime(2025, 12, 7, 13, 15, 1, 514, DateTimeKind.Utc).AddTicks(1869) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 514, DateTimeKind.Utc).AddTicks(1872), new DateTime(2025, 12, 7, 13, 15, 1, 514, DateTimeKind.Utc).AddTicks(1873) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 514, DateTimeKind.Utc).AddTicks(1876), new DateTime(2025, 12, 7, 13, 15, 1, 514, DateTimeKind.Utc).AddTicks(1876) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 515, DateTimeKind.Utc).AddTicks(4474), new DateTime(2025, 12, 7, 13, 15, 1, 515, DateTimeKind.Utc).AddTicks(4841) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 515, DateTimeKind.Utc).AddTicks(5202), new DateTime(2025, 12, 7, 13, 15, 1, 515, DateTimeKind.Utc).AddTicks(5202) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 515, DateTimeKind.Utc).AddTicks(5206), new DateTime(2025, 12, 7, 13, 15, 1, 515, DateTimeKind.Utc).AddTicks(5207) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 515, DateTimeKind.Utc).AddTicks(5210), new DateTime(2025, 12, 7, 13, 15, 1, 515, DateTimeKind.Utc).AddTicks(5211) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 515, DateTimeKind.Utc).AddTicks(5215), new DateTime(2025, 12, 7, 13, 15, 1, 515, DateTimeKind.Utc).AddTicks(5216) });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 513, DateTimeKind.Utc).AddTicks(1192));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 513, DateTimeKind.Utc).AddTicks(1545));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 513, DateTimeKind.Utc).AddTicks(1548));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 513, DateTimeKind.Utc).AddTicks(1551));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 513, DateTimeKind.Utc).AddTicks(1553));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 513, DateTimeKind.Utc).AddTicks(1555));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 513, DateTimeKind.Utc).AddTicks(1557));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 513, DateTimeKind.Utc).AddTicks(1559));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 513, DateTimeKind.Utc).AddTicks(1561));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 513, DateTimeKind.Utc).AddTicks(1563));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 513, DateTimeKind.Utc).AddTicks(1565));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 502, DateTimeKind.Utc).AddTicks(4420));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 502, DateTimeKind.Utc).AddTicks(5198));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 502, DateTimeKind.Utc).AddTicks(5200));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 502, DateTimeKind.Utc).AddTicks(5203));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 502, DateTimeKind.Utc).AddTicks(5206));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 502, DateTimeKind.Utc).AddTicks(5208));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 508, DateTimeKind.Utc).AddTicks(8013));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 7, 13, 15, 1, 508, DateTimeKind.Utc).AddTicks(8341));

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 518, DateTimeKind.Utc).AddTicks(2590), new DateTime(2025, 12, 7, 13, 15, 1, 518, DateTimeKind.Utc).AddTicks(2964) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 518, DateTimeKind.Utc).AddTicks(3359), new DateTime(2025, 12, 7, 13, 15, 1, 518, DateTimeKind.Utc).AddTicks(3359) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 13, 15, 1, 518, DateTimeKind.Utc).AddTicks(3363), new DateTime(2025, 12, 7, 13, 15, 1, 518, DateTimeKind.Utc).AddTicks(3364) });
        }
    }
}
