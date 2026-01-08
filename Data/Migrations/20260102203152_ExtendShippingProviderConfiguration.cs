using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kokomija.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendShippingProviderConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApiAccountNumber",
                table: "ShippingProviders",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApiBaseUrl",
                table: "ShippingProviders",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApiVersion",
                table: "ShippingProviders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthHeaderName",
                table: "ShippingProviders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthenticationType",
                table: "ShippingProviders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LabelApiEndpoint",
                table: "ShippingProviders",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastApiCallAt",
                table: "ShippingProviders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LastApiCallSuccess",
                table: "ShippingProviders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastApiError",
                table: "ShippingProviders",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OAuthAccessToken",
                table: "ShippingProviders",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OAuthTokenExpiry",
                table: "ShippingProviders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OAuthTokenUrl",
                table: "ShippingProviders",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "ShippingProviders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RatesApiEndpoint",
                table: "ShippingProviders",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SandboxApiBaseUrl",
                table: "ShippingProviders",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShipmentApiEndpoint",
                table: "ShippingProviders",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SupportsInsurance",
                table: "ShippingProviders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SupportsLabelGeneration",
                table: "ShippingProviders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SupportsPickupScheduling",
                table: "ShippingProviders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SupportsRateCalculation",
                table: "ShippingProviders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SupportsTracking",
                table: "ShippingProviders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SupportsWebhooks",
                table: "ShippingProviders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TrackingApiEndpoint",
                table: "ShippingProviders",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UseSandbox",
                table: "ShippingProviders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "WebhookSecret",
                table: "ShippingProviders",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 300, DateTimeKind.Utc).AddTicks(9082), new DateTime(2026, 1, 2, 20, 31, 49, 301, DateTimeKind.Utc).AddTicks(4687) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 301, DateTimeKind.Utc).AddTicks(6066), new DateTime(2026, 1, 2, 20, 31, 49, 301, DateTimeKind.Utc).AddTicks(6067) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 301, DateTimeKind.Utc).AddTicks(6071), new DateTime(2026, 1, 2, 20, 31, 49, 301, DateTimeKind.Utc).AddTicks(6072) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 301, DateTimeKind.Utc).AddTicks(6078), new DateTime(2026, 1, 2, 20, 31, 49, 301, DateTimeKind.Utc).AddTicks(6078) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 301, DateTimeKind.Utc).AddTicks(6082), new DateTime(2026, 1, 2, 20, 31, 49, 301, DateTimeKind.Utc).AddTicks(6083) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 304, DateTimeKind.Utc).AddTicks(7137), new DateTime(2026, 1, 2, 20, 31, 49, 304, DateTimeKind.Utc).AddTicks(9569) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 305, DateTimeKind.Utc).AddTicks(689), new DateTime(2026, 1, 2, 20, 31, 49, 305, DateTimeKind.Utc).AddTicks(690) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 303, DateTimeKind.Utc).AddTicks(4540), new DateTime(2026, 1, 2, 20, 31, 49, 303, DateTimeKind.Utc).AddTicks(1893), new DateTime(2026, 1, 2, 20, 31, 49, 303, DateTimeKind.Utc).AddTicks(5050) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 323, DateTimeKind.Utc).AddTicks(7091));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 323, DateTimeKind.Utc).AddTicks(7414));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 322, DateTimeKind.Utc).AddTicks(9394), new DateTime(2026, 1, 2, 20, 31, 49, 322, DateTimeKind.Utc).AddTicks(9008) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 296, DateTimeKind.Utc).AddTicks(7058));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 296, DateTimeKind.Utc).AddTicks(7661));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 296, DateTimeKind.Utc).AddTicks(7667));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 296, DateTimeKind.Utc).AddTicks(7671));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 296, DateTimeKind.Utc).AddTicks(9640));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 296, DateTimeKind.Utc).AddTicks(9693));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 296, DateTimeKind.Utc).AddTicks(9700));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 296, DateTimeKind.Utc).AddTicks(9710));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 296, DateTimeKind.Utc).AddTicks(9714));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 296, DateTimeKind.Utc).AddTicks(9718));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 296, DateTimeKind.Utc).AddTicks(9722));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 296, DateTimeKind.Utc).AddTicks(9728));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 293, DateTimeKind.Utc).AddTicks(7490));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 293, DateTimeKind.Utc).AddTicks(7820));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 293, DateTimeKind.Utc).AddTicks(7823));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 293, DateTimeKind.Utc).AddTicks(7826));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 293, DateTimeKind.Utc).AddTicks(7860));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 293, DateTimeKind.Utc).AddTicks(7863));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 293, DateTimeKind.Utc).AddTicks(7865));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 293, DateTimeKind.Utc).AddTicks(7868));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 314, DateTimeKind.Utc).AddTicks(606), new DateTime(2026, 1, 2, 20, 31, 49, 313, DateTimeKind.Utc).AddTicks(7980), new DateTime(2026, 7, 2, 20, 31, 49, 313, DateTimeKind.Utc).AddTicks(8484) });

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 316, DateTimeKind.Utc).AddTicks(1354));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(1899));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2303));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2341));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2346));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2350));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2368));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2372));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2376));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2382));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2397));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2401));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2405));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2409));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2412));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2451));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2457));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2463));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2469));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2474));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2478));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2482));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2486));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2490));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 319, DateTimeKind.Utc).AddTicks(2494));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 321, DateTimeKind.Utc).AddTicks(5728));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 321, DateTimeKind.Utc).AddTicks(6239));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 321, DateTimeKind.Utc).AddTicks(6244));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 321, DateTimeKind.Utc).AddTicks(6288));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 321, DateTimeKind.Utc).AddTicks(6292));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 321, DateTimeKind.Utc).AddTicks(6325));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 321, DateTimeKind.Utc).AddTicks(6328));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 321, DateTimeKind.Utc).AddTicks(6331));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 321, DateTimeKind.Utc).AddTicks(6334));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 321, DateTimeKind.Utc).AddTicks(6339));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 321, DateTimeKind.Utc).AddTicks(6345));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 321, DateTimeKind.Utc).AddTicks(6349));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 321, DateTimeKind.Utc).AddTicks(6353));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 321, DateTimeKind.Utc).AddTicks(6357));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 321, DateTimeKind.Utc).AddTicks(6360));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 318, DateTimeKind.Utc).AddTicks(488));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 318, DateTimeKind.Utc).AddTicks(943));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 318, DateTimeKind.Utc).AddTicks(949));

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApiAccountNumber", "ApiBaseUrl", "ApiVersion", "AuthHeaderName", "AuthenticationType", "CreatedAt", "LabelApiEndpoint", "LastApiCallAt", "LastApiCallSuccess", "LastApiError", "OAuthAccessToken", "OAuthTokenExpiry", "OAuthTokenUrl", "Priority", "RatesApiEndpoint", "SandboxApiBaseUrl", "ShipmentApiEndpoint", "SupportsInsurance", "SupportsLabelGeneration", "SupportsPickupScheduling", "SupportsRateCalculation", "SupportsTracking", "SupportsWebhooks", "TrackingApiEndpoint", "UpdatedAt", "UseSandbox", "WebhookSecret" },
                values: new object[] { null, null, null, null, "ApiKey", new DateTime(2026, 1, 2, 20, 31, 49, 308, DateTimeKind.Utc).AddTicks(4535), null, null, true, null, null, null, null, 100, null, null, null, false, true, false, true, true, false, null, new DateTime(2026, 1, 2, 20, 31, 49, 308, DateTimeKind.Utc).AddTicks(4869), false, null });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ApiAccountNumber", "ApiBaseUrl", "ApiVersion", "AuthHeaderName", "AuthenticationType", "CreatedAt", "LabelApiEndpoint", "LastApiCallAt", "LastApiCallSuccess", "LastApiError", "OAuthAccessToken", "OAuthTokenExpiry", "OAuthTokenUrl", "Priority", "RatesApiEndpoint", "SandboxApiBaseUrl", "ShipmentApiEndpoint", "SupportsInsurance", "SupportsLabelGeneration", "SupportsPickupScheduling", "SupportsRateCalculation", "SupportsTracking", "SupportsWebhooks", "TrackingApiEndpoint", "UpdatedAt", "UseSandbox", "WebhookSecret" },
                values: new object[] { null, null, null, null, "ApiKey", new DateTime(2026, 1, 2, 20, 31, 49, 308, DateTimeKind.Utc).AddTicks(5187), null, null, true, null, null, null, null, 100, null, null, null, false, true, false, true, true, false, null, new DateTime(2026, 1, 2, 20, 31, 49, 308, DateTimeKind.Utc).AddTicks(5188), false, null });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ApiAccountNumber", "ApiBaseUrl", "ApiVersion", "AuthHeaderName", "AuthenticationType", "CreatedAt", "LabelApiEndpoint", "LastApiCallAt", "LastApiCallSuccess", "LastApiError", "OAuthAccessToken", "OAuthTokenExpiry", "OAuthTokenUrl", "Priority", "RatesApiEndpoint", "SandboxApiBaseUrl", "ShipmentApiEndpoint", "SupportsInsurance", "SupportsLabelGeneration", "SupportsPickupScheduling", "SupportsRateCalculation", "SupportsTracking", "SupportsWebhooks", "TrackingApiEndpoint", "UpdatedAt", "UseSandbox", "WebhookSecret" },
                values: new object[] { null, null, null, null, "ApiKey", new DateTime(2026, 1, 2, 20, 31, 49, 308, DateTimeKind.Utc).AddTicks(5192), null, null, true, null, null, null, null, 100, null, null, null, false, true, false, true, true, false, null, new DateTime(2026, 1, 2, 20, 31, 49, 308, DateTimeKind.Utc).AddTicks(5193), false, null });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ApiAccountNumber", "ApiBaseUrl", "ApiVersion", "AuthHeaderName", "AuthenticationType", "CreatedAt", "LabelApiEndpoint", "LastApiCallAt", "LastApiCallSuccess", "LastApiError", "OAuthAccessToken", "OAuthTokenExpiry", "OAuthTokenUrl", "Priority", "RatesApiEndpoint", "SandboxApiBaseUrl", "ShipmentApiEndpoint", "SupportsInsurance", "SupportsLabelGeneration", "SupportsPickupScheduling", "SupportsRateCalculation", "SupportsTracking", "SupportsWebhooks", "TrackingApiEndpoint", "UpdatedAt", "UseSandbox", "WebhookSecret" },
                values: new object[] { null, null, null, null, "ApiKey", new DateTime(2026, 1, 2, 20, 31, 49, 308, DateTimeKind.Utc).AddTicks(5197), null, null, true, null, null, null, null, 100, null, null, null, false, true, false, true, true, false, null, new DateTime(2026, 1, 2, 20, 31, 49, 308, DateTimeKind.Utc).AddTicks(5197), false, null });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ApiAccountNumber", "ApiBaseUrl", "ApiVersion", "AuthHeaderName", "AuthenticationType", "CreatedAt", "LabelApiEndpoint", "LastApiCallAt", "LastApiCallSuccess", "LastApiError", "OAuthAccessToken", "OAuthTokenExpiry", "OAuthTokenUrl", "Priority", "RatesApiEndpoint", "SandboxApiBaseUrl", "ShipmentApiEndpoint", "SupportsInsurance", "SupportsLabelGeneration", "SupportsPickupScheduling", "SupportsRateCalculation", "SupportsTracking", "SupportsWebhooks", "TrackingApiEndpoint", "UpdatedAt", "UseSandbox", "WebhookSecret" },
                values: new object[] { null, null, null, null, "ApiKey", new DateTime(2026, 1, 2, 20, 31, 49, 308, DateTimeKind.Utc).AddTicks(5200), null, null, true, null, null, null, null, 100, null, null, null, false, true, false, true, true, false, null, new DateTime(2026, 1, 2, 20, 31, 49, 308, DateTimeKind.Utc).AddTicks(5201), false, null });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 311, DateTimeKind.Utc).AddTicks(2527), new DateTime(2026, 1, 2, 20, 31, 49, 311, DateTimeKind.Utc).AddTicks(3045) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 311, DateTimeKind.Utc).AddTicks(3545), new DateTime(2026, 1, 2, 20, 31, 49, 311, DateTimeKind.Utc).AddTicks(3546) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 311, DateTimeKind.Utc).AddTicks(3550), new DateTime(2026, 1, 2, 20, 31, 49, 311, DateTimeKind.Utc).AddTicks(3551) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 311, DateTimeKind.Utc).AddTicks(3555), new DateTime(2026, 1, 2, 20, 31, 49, 311, DateTimeKind.Utc).AddTicks(3556) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 311, DateTimeKind.Utc).AddTicks(3562), new DateTime(2026, 1, 2, 20, 31, 49, 311, DateTimeKind.Utc).AddTicks(3562) });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 307, DateTimeKind.Utc).AddTicks(4618));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 307, DateTimeKind.Utc).AddTicks(4956));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 307, DateTimeKind.Utc).AddTicks(4958));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 307, DateTimeKind.Utc).AddTicks(4960));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 307, DateTimeKind.Utc).AddTicks(4962));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 307, DateTimeKind.Utc).AddTicks(4965));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 307, DateTimeKind.Utc).AddTicks(4967));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 307, DateTimeKind.Utc).AddTicks(4969));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 307, DateTimeKind.Utc).AddTicks(4971));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 307, DateTimeKind.Utc).AddTicks(4973));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 307, DateTimeKind.Utc).AddTicks(4976));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 291, DateTimeKind.Utc).AddTicks(4127));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 291, DateTimeKind.Utc).AddTicks(4598));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 291, DateTimeKind.Utc).AddTicks(4601));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 291, DateTimeKind.Utc).AddTicks(4603));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 291, DateTimeKind.Utc).AddTicks(4606));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 291, DateTimeKind.Utc).AddTicks(4609));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 299, DateTimeKind.Utc).AddTicks(2657));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 20, 31, 49, 299, DateTimeKind.Utc).AddTicks(3445));

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 312, DateTimeKind.Utc).AddTicks(5318), new DateTime(2026, 1, 2, 20, 31, 49, 312, DateTimeKind.Utc).AddTicks(5692) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 312, DateTimeKind.Utc).AddTicks(6119), new DateTime(2026, 1, 2, 20, 31, 49, 312, DateTimeKind.Utc).AddTicks(6120) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 20, 31, 49, 312, DateTimeKind.Utc).AddTicks(6123), new DateTime(2026, 1, 2, 20, 31, 49, 312, DateTimeKind.Utc).AddTicks(6124) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApiAccountNumber",
                table: "ShippingProviders");

            migrationBuilder.DropColumn(
                name: "ApiBaseUrl",
                table: "ShippingProviders");

            migrationBuilder.DropColumn(
                name: "ApiVersion",
                table: "ShippingProviders");

            migrationBuilder.DropColumn(
                name: "AuthHeaderName",
                table: "ShippingProviders");

            migrationBuilder.DropColumn(
                name: "AuthenticationType",
                table: "ShippingProviders");

            migrationBuilder.DropColumn(
                name: "LabelApiEndpoint",
                table: "ShippingProviders");

            migrationBuilder.DropColumn(
                name: "LastApiCallAt",
                table: "ShippingProviders");

            migrationBuilder.DropColumn(
                name: "LastApiCallSuccess",
                table: "ShippingProviders");

            migrationBuilder.DropColumn(
                name: "LastApiError",
                table: "ShippingProviders");

            migrationBuilder.DropColumn(
                name: "OAuthAccessToken",
                table: "ShippingProviders");

            migrationBuilder.DropColumn(
                name: "OAuthTokenExpiry",
                table: "ShippingProviders");

            migrationBuilder.DropColumn(
                name: "OAuthTokenUrl",
                table: "ShippingProviders");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "ShippingProviders");

            migrationBuilder.DropColumn(
                name: "RatesApiEndpoint",
                table: "ShippingProviders");

            migrationBuilder.DropColumn(
                name: "SandboxApiBaseUrl",
                table: "ShippingProviders");

            migrationBuilder.DropColumn(
                name: "ShipmentApiEndpoint",
                table: "ShippingProviders");

            migrationBuilder.DropColumn(
                name: "SupportsInsurance",
                table: "ShippingProviders");

            migrationBuilder.DropColumn(
                name: "SupportsLabelGeneration",
                table: "ShippingProviders");

            migrationBuilder.DropColumn(
                name: "SupportsPickupScheduling",
                table: "ShippingProviders");

            migrationBuilder.DropColumn(
                name: "SupportsRateCalculation",
                table: "ShippingProviders");

            migrationBuilder.DropColumn(
                name: "SupportsTracking",
                table: "ShippingProviders");

            migrationBuilder.DropColumn(
                name: "SupportsWebhooks",
                table: "ShippingProviders");

            migrationBuilder.DropColumn(
                name: "TrackingApiEndpoint",
                table: "ShippingProviders");

            migrationBuilder.DropColumn(
                name: "UseSandbox",
                table: "ShippingProviders");

            migrationBuilder.DropColumn(
                name: "WebhookSecret",
                table: "ShippingProviders");

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 18, 6, 55, 482, DateTimeKind.Utc).AddTicks(2415), new DateTime(2026, 1, 2, 18, 6, 55, 482, DateTimeKind.Utc).AddTicks(3305) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 18, 6, 55, 482, DateTimeKind.Utc).AddTicks(3843), new DateTime(2026, 1, 2, 18, 6, 55, 482, DateTimeKind.Utc).AddTicks(3844) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 18, 6, 55, 482, DateTimeKind.Utc).AddTicks(3924), new DateTime(2026, 1, 2, 18, 6, 55, 482, DateTimeKind.Utc).AddTicks(3927) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 18, 6, 55, 482, DateTimeKind.Utc).AddTicks(3934), new DateTime(2026, 1, 2, 18, 6, 55, 482, DateTimeKind.Utc).AddTicks(3939) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 18, 6, 55, 482, DateTimeKind.Utc).AddTicks(3943), new DateTime(2026, 1, 2, 18, 6, 55, 482, DateTimeKind.Utc).AddTicks(3945) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 18, 6, 55, 487, DateTimeKind.Utc).AddTicks(4476), new DateTime(2026, 1, 2, 18, 6, 55, 487, DateTimeKind.Utc).AddTicks(4806) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 18, 6, 55, 487, DateTimeKind.Utc).AddTicks(5133), new DateTime(2026, 1, 2, 18, 6, 55, 487, DateTimeKind.Utc).AddTicks(5133) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 18, 6, 55, 483, DateTimeKind.Utc).AddTicks(7189), new DateTime(2026, 1, 2, 18, 6, 55, 483, DateTimeKind.Utc).AddTicks(4824), new DateTime(2026, 1, 2, 18, 6, 55, 483, DateTimeKind.Utc).AddTicks(7721) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 507, DateTimeKind.Utc).AddTicks(3738));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 507, DateTimeKind.Utc).AddTicks(4258));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 2, 18, 6, 55, 504, DateTimeKind.Utc).AddTicks(1622), new DateTime(2026, 1, 2, 18, 6, 55, 504, DateTimeKind.Utc).AddTicks(1017) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 478, DateTimeKind.Utc).AddTicks(5156));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 478, DateTimeKind.Utc).AddTicks(5494));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 478, DateTimeKind.Utc).AddTicks(5498));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 478, DateTimeKind.Utc).AddTicks(5501));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 478, DateTimeKind.Utc).AddTicks(5847));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 478, DateTimeKind.Utc).AddTicks(5853));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 478, DateTimeKind.Utc).AddTicks(5856));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 478, DateTimeKind.Utc).AddTicks(5860));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 478, DateTimeKind.Utc).AddTicks(5863));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 478, DateTimeKind.Utc).AddTicks(5867));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 478, DateTimeKind.Utc).AddTicks(5870));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 478, DateTimeKind.Utc).AddTicks(5910));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 476, DateTimeKind.Utc).AddTicks(9401));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 476, DateTimeKind.Utc).AddTicks(9959));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 476, DateTimeKind.Utc).AddTicks(9962));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 476, DateTimeKind.Utc).AddTicks(9974));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 476, DateTimeKind.Utc).AddTicks(9984));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 476, DateTimeKind.Utc).AddTicks(9986));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 476, DateTimeKind.Utc).AddTicks(9989));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 476, DateTimeKind.Utc).AddTicks(9991));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2026, 1, 2, 18, 6, 55, 494, DateTimeKind.Utc).AddTicks(4408), new DateTime(2026, 1, 2, 18, 6, 55, 493, DateTimeKind.Utc).AddTicks(9987), new DateTime(2026, 7, 2, 18, 6, 55, 494, DateTimeKind.Utc).AddTicks(1137) });

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 495, DateTimeKind.Utc).AddTicks(8647));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 498, DateTimeKind.Utc).AddTicks(8122));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 498, DateTimeKind.Utc).AddTicks(8659));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 498, DateTimeKind.Utc).AddTicks(8667));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 498, DateTimeKind.Utc).AddTicks(8672));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 498, DateTimeKind.Utc).AddTicks(8677));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 498, DateTimeKind.Utc).AddTicks(8701));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 498, DateTimeKind.Utc).AddTicks(8706));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 498, DateTimeKind.Utc).AddTicks(8728));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 498, DateTimeKind.Utc).AddTicks(8758));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 498, DateTimeKind.Utc).AddTicks(8765));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 498, DateTimeKind.Utc).AddTicks(8771));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 498, DateTimeKind.Utc).AddTicks(8775));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 498, DateTimeKind.Utc).AddTicks(8780));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 498, DateTimeKind.Utc).AddTicks(8790));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 498, DateTimeKind.Utc).AddTicks(8798));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 498, DateTimeKind.Utc).AddTicks(8803));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 498, DateTimeKind.Utc).AddTicks(8810));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 498, DateTimeKind.Utc).AddTicks(8862));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 498, DateTimeKind.Utc).AddTicks(8869));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 498, DateTimeKind.Utc).AddTicks(8874));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 498, DateTimeKind.Utc).AddTicks(8879));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 498, DateTimeKind.Utc).AddTicks(8888));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 498, DateTimeKind.Utc).AddTicks(8894));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 498, DateTimeKind.Utc).AddTicks(8898));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 502, DateTimeKind.Utc).AddTicks(7001));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 502, DateTimeKind.Utc).AddTicks(7485));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 502, DateTimeKind.Utc).AddTicks(7490));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 502, DateTimeKind.Utc).AddTicks(7493));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 502, DateTimeKind.Utc).AddTicks(7497));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 502, DateTimeKind.Utc).AddTicks(7517));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 502, DateTimeKind.Utc).AddTicks(7521));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 502, DateTimeKind.Utc).AddTicks(7525));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 502, DateTimeKind.Utc).AddTicks(7528));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 502, DateTimeKind.Utc).AddTicks(7533));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 502, DateTimeKind.Utc).AddTicks(7538));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 502, DateTimeKind.Utc).AddTicks(7543));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 502, DateTimeKind.Utc).AddTicks(7546));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 502, DateTimeKind.Utc).AddTicks(7549));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 502, DateTimeKind.Utc).AddTicks(7553));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 497, DateTimeKind.Utc).AddTicks(4493));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 497, DateTimeKind.Utc).AddTicks(4920));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 497, DateTimeKind.Utc).AddTicks(4927));

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 18, 6, 55, 489, DateTimeKind.Utc).AddTicks(5025), new DateTime(2026, 1, 2, 18, 6, 55, 489, DateTimeKind.Utc).AddTicks(5595) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 18, 6, 55, 489, DateTimeKind.Utc).AddTicks(6244), new DateTime(2026, 1, 2, 18, 6, 55, 489, DateTimeKind.Utc).AddTicks(6245) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 18, 6, 55, 489, DateTimeKind.Utc).AddTicks(6249), new DateTime(2026, 1, 2, 18, 6, 55, 489, DateTimeKind.Utc).AddTicks(6250) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 18, 6, 55, 489, DateTimeKind.Utc).AddTicks(6255), new DateTime(2026, 1, 2, 18, 6, 55, 489, DateTimeKind.Utc).AddTicks(6256) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 18, 6, 55, 489, DateTimeKind.Utc).AddTicks(6259), new DateTime(2026, 1, 2, 18, 6, 55, 489, DateTimeKind.Utc).AddTicks(6260) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 18, 6, 55, 491, DateTimeKind.Utc).AddTicks(9598), new DateTime(2026, 1, 2, 18, 6, 55, 492, DateTimeKind.Utc).AddTicks(23) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 18, 6, 55, 492, DateTimeKind.Utc).AddTicks(503), new DateTime(2026, 1, 2, 18, 6, 55, 492, DateTimeKind.Utc).AddTicks(503) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 18, 6, 55, 492, DateTimeKind.Utc).AddTicks(508), new DateTime(2026, 1, 2, 18, 6, 55, 492, DateTimeKind.Utc).AddTicks(509) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 18, 6, 55, 492, DateTimeKind.Utc).AddTicks(512), new DateTime(2026, 1, 2, 18, 6, 55, 492, DateTimeKind.Utc).AddTicks(513) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 18, 6, 55, 492, DateTimeKind.Utc).AddTicks(517), new DateTime(2026, 1, 2, 18, 6, 55, 492, DateTimeKind.Utc).AddTicks(517) });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 488, DateTimeKind.Utc).AddTicks(5642));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 488, DateTimeKind.Utc).AddTicks(5962));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 488, DateTimeKind.Utc).AddTicks(5964));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 488, DateTimeKind.Utc).AddTicks(5966));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 488, DateTimeKind.Utc).AddTicks(5969));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 488, DateTimeKind.Utc).AddTicks(5971));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 488, DateTimeKind.Utc).AddTicks(5973));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 488, DateTimeKind.Utc).AddTicks(5975));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 488, DateTimeKind.Utc).AddTicks(5977));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 488, DateTimeKind.Utc).AddTicks(5979));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 488, DateTimeKind.Utc).AddTicks(5982));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 472, DateTimeKind.Utc).AddTicks(5284));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 472, DateTimeKind.Utc).AddTicks(5888));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 472, DateTimeKind.Utc).AddTicks(5892));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 472, DateTimeKind.Utc).AddTicks(5896));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 472, DateTimeKind.Utc).AddTicks(5900));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 472, DateTimeKind.Utc).AddTicks(5903));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 479, DateTimeKind.Utc).AddTicks(7965));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 2, 18, 6, 55, 479, DateTimeKind.Utc).AddTicks(8546));

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 18, 6, 55, 493, DateTimeKind.Utc).AddTicks(1), new DateTime(2026, 1, 2, 18, 6, 55, 493, DateTimeKind.Utc).AddTicks(339) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 18, 6, 55, 493, DateTimeKind.Utc).AddTicks(655), new DateTime(2026, 1, 2, 18, 6, 55, 493, DateTimeKind.Utc).AddTicks(656) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 1, 2, 18, 6, 55, 493, DateTimeKind.Utc).AddTicks(659), new DateTime(2026, 1, 2, 18, 6, 55, 493, DateTimeKind.Utc).AddTicks(660) });
        }
    }
}
