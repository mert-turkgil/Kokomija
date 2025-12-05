using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kokomija.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderManagementSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "ProductTranslations",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ProductTranslations",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalDeveloperCommission",
                table: "AdminEarnings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "CommissionSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeveloperCommissionRate = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    PlatformCommissionRate = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    StripeCommissionRate = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    StripeFixedFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinimumPayoutAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayoutFrequency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AutoPayoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommissionSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommissionSettings_AspNetUsers_LastModifiedBy",
                        column: x => x.LastModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperEarnings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    GrossAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StripeProcessingFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeveloperCommission = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EarnedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PayoutStatus = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PayoutId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PayoutDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperEarnings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeveloperEarnings_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReturnRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    OrderItemId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequestedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReviewedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReviewedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ReviewNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StripeRefundId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RefundedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RefundedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReturnRequests_AspNetUsers_ReviewedBy",
                        column: x => x.ReviewedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReturnRequests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReturnRequests_OrderItems_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReturnRequests_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShippingProviders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ApiKey = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ApiSecret = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WebhookUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TrackingUrlTemplate = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SupportedCountries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimatedDeliveryDays = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingProviders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteBlockLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlockedBy = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlockedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UnblockedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UnblockedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteBlockLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiteBlockLogs_AspNetUsers_BlockedBy",
                        column: x => x.BlockedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SiteBlockLogs_AspNetUsers_UnblockedBy",
                        column: x => x.UnblockedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaxRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    StateCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    StripeTaxRateId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    ReturnRequestId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    StripePaymentIntentId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StripeRefundId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StripePayoutId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FailureReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentTransactions_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentTransactions_ReturnRequests_ReturnRequestId",
                        column: x => x.ReturnRequestId,
                        principalTable: "ReturnRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReturnRequestImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReturnRequestId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnRequestImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReturnRequestImages_ReturnRequests_ReturnRequestId",
                        column: x => x.ReturnRequestId,
                        principalTable: "ReturnRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReturnStatusHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReturnRequestId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChangedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnStatusHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReturnStatusHistories_AspNetUsers_ChangedBy",
                        column: x => x.ChangedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReturnStatusHistories_ReturnRequests_ReturnRequestId",
                        column: x => x.ReturnRequestId,
                        principalTable: "ReturnRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShippingRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShippingProviderId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PricePerKg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PricePerKm = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FreeShippingThreshold = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MinDeliveryDays = table.Column<int>(type: "int", nullable: false),
                    MaxDeliveryDays = table.Column<int>(type: "int", nullable: false),
                    StripeShippingRateId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingRates_ShippingProviders_ShippingProviderId",
                        column: x => x.ShippingProviderId,
                        principalTable: "ShippingProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderShipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ShippingProviderId = table.Column<int>(type: "int", nullable: false),
                    ShippingRateId = table.Column<int>(type: "int", nullable: false),
                    TrackingNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EstimatedDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShippingCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ShippedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveredAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderShipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderShipments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderShipments_ShippingProviders_ShippingProviderId",
                        column: x => x.ShippingProviderId,
                        principalTable: "ShippingProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderShipments_ShippingRates_ShippingRateId",
                        column: x => x.ShippingRateId,
                        principalTable: "ShippingRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentTrackingEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderShipmentId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentTrackingEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipmentTrackingEvents_OrderShipments_OrderShipmentId",
                        column: x => x.OrderShipmentId,
                        principalTable: "OrderShipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 36, 32, 117, DateTimeKind.Utc).AddTicks(4073), new DateTime(2025, 12, 5, 14, 36, 32, 117, DateTimeKind.Utc).AddTicks(4567) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 36, 32, 117, DateTimeKind.Utc).AddTicks(5023), new DateTime(2025, 12, 5, 14, 36, 32, 117, DateTimeKind.Utc).AddTicks(5023) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 36, 32, 117, DateTimeKind.Utc).AddTicks(5027), new DateTime(2025, 12, 5, 14, 36, 32, 117, DateTimeKind.Utc).AddTicks(5027) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 36, 32, 117, DateTimeKind.Utc).AddTicks(5031), new DateTime(2025, 12, 5, 14, 36, 32, 117, DateTimeKind.Utc).AddTicks(5032) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 36, 32, 117, DateTimeKind.Utc).AddTicks(5035), new DateTime(2025, 12, 5, 14, 36, 32, 117, DateTimeKind.Utc).AddTicks(5036) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 36, 32, 121, DateTimeKind.Utc).AddTicks(5076), new DateTime(2025, 12, 5, 14, 36, 32, 121, DateTimeKind.Utc).AddTicks(5515) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 36, 32, 121, DateTimeKind.Utc).AddTicks(6008), new DateTime(2025, 12, 5, 14, 36, 32, 121, DateTimeKind.Utc).AddTicks(6008) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 36, 32, 120, DateTimeKind.Utc).AddTicks(3433), new DateTime(2025, 12, 5, 14, 36, 32, 118, DateTimeKind.Utc).AddTicks(4194), new DateTime(2025, 12, 5, 14, 36, 32, 120, DateTimeKind.Utc).AddTicks(4015) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 136, DateTimeKind.Utc).AddTicks(4280));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 136, DateTimeKind.Utc).AddTicks(4742));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 36, 32, 135, DateTimeKind.Utc).AddTicks(2935), new DateTime(2025, 12, 5, 14, 36, 32, 135, DateTimeKind.Utc).AddTicks(2430) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 115, DateTimeKind.Utc).AddTicks(442));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 115, DateTimeKind.Utc).AddTicks(1015));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 115, DateTimeKind.Utc).AddTicks(1022));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 115, DateTimeKind.Utc).AddTicks(1026));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 115, DateTimeKind.Utc).AddTicks(1788));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 115, DateTimeKind.Utc).AddTicks(1798));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 115, DateTimeKind.Utc).AddTicks(1804));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 115, DateTimeKind.Utc).AddTicks(1807));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 115, DateTimeKind.Utc).AddTicks(1812));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 115, DateTimeKind.Utc).AddTicks(1816));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 115, DateTimeKind.Utc).AddTicks(1820));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 115, DateTimeKind.Utc).AddTicks(1824));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 112, DateTimeKind.Utc).AddTicks(3804));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 112, DateTimeKind.Utc).AddTicks(4339));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 112, DateTimeKind.Utc).AddTicks(4342));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 112, DateTimeKind.Utc).AddTicks(4345));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 112, DateTimeKind.Utc).AddTicks(4348));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 112, DateTimeKind.Utc).AddTicks(4351));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 112, DateTimeKind.Utc).AddTicks(4395));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 112, DateTimeKind.Utc).AddTicks(4398));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2025, 12, 5, 14, 36, 32, 127, DateTimeKind.Utc).AddTicks(3215), new DateTime(2025, 12, 5, 14, 36, 32, 127, DateTimeKind.Utc).AddTicks(228), new DateTime(2026, 6, 5, 14, 36, 32, 127, DateTimeKind.Utc).AddTicks(791) });

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 128, DateTimeKind.Utc).AddTicks(8088));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7253));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7638));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7642));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7646));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7649));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7665));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7669));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7672));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7677));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7681));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7685));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7688));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7691));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7695));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7698));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7701));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7706));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7747));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7751));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7757));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7761));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7764));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 131, DateTimeKind.Utc).AddTicks(7767));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 133, DateTimeKind.Utc).AddTicks(757));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 133, DateTimeKind.Utc).AddTicks(4700));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 133, DateTimeKind.Utc).AddTicks(4708));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 133, DateTimeKind.Utc).AddTicks(4712));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 133, DateTimeKind.Utc).AddTicks(4715));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 133, DateTimeKind.Utc).AddTicks(4739));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 133, DateTimeKind.Utc).AddTicks(4742));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 133, DateTimeKind.Utc).AddTicks(4745));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 133, DateTimeKind.Utc).AddTicks(4747));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 133, DateTimeKind.Utc).AddTicks(4752));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 133, DateTimeKind.Utc).AddTicks(4766));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 133, DateTimeKind.Utc).AddTicks(4769));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 133, DateTimeKind.Utc).AddTicks(4772));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 133, DateTimeKind.Utc).AddTicks(4774));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 133, DateTimeKind.Utc).AddTicks(4777));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 130, DateTimeKind.Utc).AddTicks(5701));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 130, DateTimeKind.Utc).AddTicks(6303));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 130, DateTimeKind.Utc).AddTicks(6310));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 122, DateTimeKind.Utc).AddTicks(6538));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 122, DateTimeKind.Utc).AddTicks(7023));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 122, DateTimeKind.Utc).AddTicks(7025));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 122, DateTimeKind.Utc).AddTicks(7027));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 122, DateTimeKind.Utc).AddTicks(7029));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 122, DateTimeKind.Utc).AddTicks(7031));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 122, DateTimeKind.Utc).AddTicks(7033));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 122, DateTimeKind.Utc).AddTicks(7035));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 122, DateTimeKind.Utc).AddTicks(7037));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 122, DateTimeKind.Utc).AddTicks(7039));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 122, DateTimeKind.Utc).AddTicks(7041));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 110, DateTimeKind.Utc).AddTicks(1135));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 110, DateTimeKind.Utc).AddTicks(1700));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 110, DateTimeKind.Utc).AddTicks(1703));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 110, DateTimeKind.Utc).AddTicks(1706));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 110, DateTimeKind.Utc).AddTicks(1709));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 110, DateTimeKind.Utc).AddTicks(1711));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 116, DateTimeKind.Utc).AddTicks(1897));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 5, 14, 36, 32, 116, DateTimeKind.Utc).AddTicks(2245));

            migrationBuilder.CreateIndex(
                name: "IX_CommissionSettings_LastModifiedBy",
                table: "CommissionSettings",
                column: "LastModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperEarnings_EarnedAt",
                table: "DeveloperEarnings",
                column: "EarnedAt");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperEarnings_OrderId",
                table: "DeveloperEarnings",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperEarnings_PayoutStatus",
                table: "DeveloperEarnings",
                column: "PayoutStatus");

            migrationBuilder.CreateIndex(
                name: "IX_OrderShipments_OrderId",
                table: "OrderShipments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderShipments_ShippingProviderId",
                table: "OrderShipments",
                column: "ShippingProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderShipments_ShippingRateId",
                table: "OrderShipments",
                column: "ShippingRateId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderShipments_Status",
                table: "OrderShipments",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_OrderShipments_TrackingNumber",
                table: "OrderShipments",
                column: "TrackingNumber");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransactions_CreatedAt",
                table: "PaymentTransactions",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransactions_OrderId",
                table: "PaymentTransactions",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransactions_ReturnRequestId",
                table: "PaymentTransactions",
                column: "ReturnRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransactions_Status",
                table: "PaymentTransactions",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTransactions_Type",
                table: "PaymentTransactions",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnRequestImages_ReturnRequestId",
                table: "ReturnRequestImages",
                column: "ReturnRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnRequests_OrderId",
                table: "ReturnRequests",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnRequests_OrderItemId",
                table: "ReturnRequests",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnRequests_RequestedAt",
                table: "ReturnRequests",
                column: "RequestedAt");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnRequests_ReviewedBy",
                table: "ReturnRequests",
                column: "ReviewedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnRequests_Status",
                table: "ReturnRequests",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnRequests_UserId",
                table: "ReturnRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnStatusHistories_ChangedBy",
                table: "ReturnStatusHistories",
                column: "ChangedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnStatusHistories_ReturnRequestId",
                table: "ReturnStatusHistories",
                column: "ReturnRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentTrackingEvents_OrderShipmentId",
                table: "ShipmentTrackingEvents",
                column: "OrderShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingProviders_Code",
                table: "ShippingProviders",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShippingRates_IsActive",
                table: "ShippingRates",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingRates_ShippingProviderId",
                table: "ShippingRates",
                column: "ShippingProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteBlockLogs_BlockedAt",
                table: "SiteBlockLogs",
                column: "BlockedAt");

            migrationBuilder.CreateIndex(
                name: "IX_SiteBlockLogs_BlockedBy",
                table: "SiteBlockLogs",
                column: "BlockedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SiteBlockLogs_IsActive",
                table: "SiteBlockLogs",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_SiteBlockLogs_UnblockedBy",
                table: "SiteBlockLogs",
                column: "UnblockedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TaxRates_CountryCode",
                table: "TaxRates",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_TaxRates_CountryCode_StateCode",
                table: "TaxRates",
                columns: new[] { "CountryCode", "StateCode" });

            migrationBuilder.CreateIndex(
                name: "IX_TaxRates_IsActive",
                table: "TaxRates",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_TaxRates_IsDefault",
                table: "TaxRates",
                column: "IsDefault");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommissionSettings");

            migrationBuilder.DropTable(
                name: "DeveloperEarnings");

            migrationBuilder.DropTable(
                name: "PaymentTransactions");

            migrationBuilder.DropTable(
                name: "ReturnRequestImages");

            migrationBuilder.DropTable(
                name: "ReturnStatusHistories");

            migrationBuilder.DropTable(
                name: "ShipmentTrackingEvents");

            migrationBuilder.DropTable(
                name: "SiteBlockLogs");

            migrationBuilder.DropTable(
                name: "TaxRates");

            migrationBuilder.DropTable(
                name: "ReturnRequests");

            migrationBuilder.DropTable(
                name: "OrderShipments");

            migrationBuilder.DropTable(
                name: "ShippingRates");

            migrationBuilder.DropTable(
                name: "ShippingProviders");

            migrationBuilder.DropColumn(
                name: "TotalDeveloperCommission",
                table: "AdminEarnings");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "ProductTranslations",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ProductTranslations",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 4, 21, 24, 54, 281, DateTimeKind.Utc).AddTicks(4005), new DateTime(2025, 12, 4, 21, 24, 54, 281, DateTimeKind.Utc).AddTicks(4308) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 4, 21, 24, 54, 281, DateTimeKind.Utc).AddTicks(4604), new DateTime(2025, 12, 4, 21, 24, 54, 281, DateTimeKind.Utc).AddTicks(4605) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 4, 21, 24, 54, 281, DateTimeKind.Utc).AddTicks(4607), new DateTime(2025, 12, 4, 21, 24, 54, 281, DateTimeKind.Utc).AddTicks(4608) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 4, 21, 24, 54, 281, DateTimeKind.Utc).AddTicks(4611), new DateTime(2025, 12, 4, 21, 24, 54, 281, DateTimeKind.Utc).AddTicks(4611) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 4, 21, 24, 54, 281, DateTimeKind.Utc).AddTicks(4614), new DateTime(2025, 12, 4, 21, 24, 54, 281, DateTimeKind.Utc).AddTicks(4614) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 4, 21, 24, 54, 282, DateTimeKind.Utc).AddTicks(7376), new DateTime(2025, 12, 4, 21, 24, 54, 282, DateTimeKind.Utc).AddTicks(7655) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 4, 21, 24, 54, 282, DateTimeKind.Utc).AddTicks(7932), new DateTime(2025, 12, 4, 21, 24, 54, 282, DateTimeKind.Utc).AddTicks(7933) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 4, 21, 24, 54, 282, DateTimeKind.Utc).AddTicks(135), new DateTime(2025, 12, 4, 21, 24, 54, 281, DateTimeKind.Utc).AddTicks(8807), new DateTime(2025, 12, 4, 21, 24, 54, 282, DateTimeKind.Utc).AddTicks(434) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 290, DateTimeKind.Utc).AddTicks(1617));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 290, DateTimeKind.Utc).AddTicks(1928));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2025, 12, 4, 21, 24, 54, 289, DateTimeKind.Utc).AddTicks(4535), new DateTime(2025, 12, 4, 21, 24, 54, 289, DateTimeKind.Utc).AddTicks(4170) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 278, DateTimeKind.Utc).AddTicks(6233));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 278, DateTimeKind.Utc).AddTicks(6965));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 278, DateTimeKind.Utc).AddTicks(6969));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 278, DateTimeKind.Utc).AddTicks(6973));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 278, DateTimeKind.Utc).AddTicks(7581));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 278, DateTimeKind.Utc).AddTicks(7590));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 278, DateTimeKind.Utc).AddTicks(7595));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 278, DateTimeKind.Utc).AddTicks(7599));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 278, DateTimeKind.Utc).AddTicks(7604));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 278, DateTimeKind.Utc).AddTicks(7609));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 278, DateTimeKind.Utc).AddTicks(7613));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 278, DateTimeKind.Utc).AddTicks(7618));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 277, DateTimeKind.Utc).AddTicks(3495));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 277, DateTimeKind.Utc).AddTicks(3814));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 277, DateTimeKind.Utc).AddTicks(3816));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 277, DateTimeKind.Utc).AddTicks(3818));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 277, DateTimeKind.Utc).AddTicks(3820));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 277, DateTimeKind.Utc).AddTicks(3823));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 277, DateTimeKind.Utc).AddTicks(3825));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 277, DateTimeKind.Utc).AddTicks(3827));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2025, 12, 4, 21, 24, 54, 285, DateTimeKind.Utc).AddTicks(3482), new DateTime(2025, 12, 4, 21, 24, 54, 285, DateTimeKind.Utc).AddTicks(1408), new DateTime(2026, 6, 4, 21, 24, 54, 285, DateTimeKind.Utc).AddTicks(1805) });

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 285, DateTimeKind.Utc).AddTicks(8422));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(4970));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5300));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5303));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5306));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5308));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5319));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5322));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5324));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5328));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5332));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5335));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5337));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5339));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5341));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5344));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5346));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5350));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5354));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5357));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5359));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5414));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5416));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5419));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 287, DateTimeKind.Utc).AddTicks(5421));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 288, DateTimeKind.Utc).AddTicks(4368));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 288, DateTimeKind.Utc).AddTicks(4700));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 288, DateTimeKind.Utc).AddTicks(4703));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 288, DateTimeKind.Utc).AddTicks(4706));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 288, DateTimeKind.Utc).AddTicks(4709));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 288, DateTimeKind.Utc).AddTicks(4718));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 288, DateTimeKind.Utc).AddTicks(4723));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 288, DateTimeKind.Utc).AddTicks(4726));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 288, DateTimeKind.Utc).AddTicks(4729));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 288, DateTimeKind.Utc).AddTicks(4734));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 288, DateTimeKind.Utc).AddTicks(4739));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 288, DateTimeKind.Utc).AddTicks(4742));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 288, DateTimeKind.Utc).AddTicks(4745));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 288, DateTimeKind.Utc).AddTicks(4749));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 288, DateTimeKind.Utc).AddTicks(4752));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 286, DateTimeKind.Utc).AddTicks(7957));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 286, DateTimeKind.Utc).AddTicks(8256));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 286, DateTimeKind.Utc).AddTicks(8260));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 284, DateTimeKind.Utc).AddTicks(380));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 284, DateTimeKind.Utc).AddTicks(767));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 284, DateTimeKind.Utc).AddTicks(770));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 284, DateTimeKind.Utc).AddTicks(772));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 284, DateTimeKind.Utc).AddTicks(775));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 284, DateTimeKind.Utc).AddTicks(778));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 284, DateTimeKind.Utc).AddTicks(779));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 284, DateTimeKind.Utc).AddTicks(782));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 284, DateTimeKind.Utc).AddTicks(784));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 284, DateTimeKind.Utc).AddTicks(786));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 284, DateTimeKind.Utc).AddTicks(788));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 275, DateTimeKind.Utc).AddTicks(8230));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 275, DateTimeKind.Utc).AddTicks(8560));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 275, DateTimeKind.Utc).AddTicks(8562));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 275, DateTimeKind.Utc).AddTicks(8564));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 275, DateTimeKind.Utc).AddTicks(8566));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 275, DateTimeKind.Utc).AddTicks(8568));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 280, DateTimeKind.Utc).AddTicks(5993));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 12, 4, 21, 24, 54, 280, DateTimeKind.Utc).AddTicks(6369));
        }
    }
}
