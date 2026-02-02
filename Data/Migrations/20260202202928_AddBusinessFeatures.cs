using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kokomija.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddBusinessFeatures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BusinessPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessStripePriceId",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailableForBusiness",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsBusinessOnly",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MinBusinessQuantity",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BusinessProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NIP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    REGON = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    KRS = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    VATStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ResidenceAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WorkingAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RegistrationLegalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    IsBusinessModeActive = table.Column<bool>(type: "bit", nullable: false),
                    VerifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastVerificationAttempt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VerificationAttempts = table.Column<int>(type: "int", nullable: false),
                    GovernmentRequestId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RawApiResponse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessProfiles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NIPVerificationLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NIP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IPAddress = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    WasSuccessful = table.Column<bool>(type: "bit", nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ResponseCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AttemptedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NIPVerificationLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NIPVerificationLogs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                columns: new[] { "BusinessPrice", "BusinessStripePriceId", "CreatedAt", "IsAvailableForBusiness", "IsBusinessOnly", "MinBusinessQuantity" },
                values: new object[] { null, null, new DateTime(2026, 2, 2, 20, 29, 25, 467, DateTimeKind.Utc).AddTicks(3180), true, false, 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BusinessPrice", "BusinessStripePriceId", "CreatedAt", "IsAvailableForBusiness", "IsBusinessOnly", "MinBusinessQuantity" },
                values: new object[] { null, null, new DateTime(2026, 2, 2, 20, 29, 25, 467, DateTimeKind.Utc).AddTicks(3576), true, false, 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BusinessPrice", "BusinessStripePriceId", "CreatedAt", "IsAvailableForBusiness", "IsBusinessOnly", "MinBusinessQuantity" },
                values: new object[] { null, null, new DateTime(2026, 2, 2, 20, 29, 25, 467, DateTimeKind.Utc).AddTicks(3581), true, false, 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BusinessPrice", "BusinessStripePriceId", "CreatedAt", "IsAvailableForBusiness", "IsBusinessOnly", "MinBusinessQuantity" },
                values: new object[] { null, null, new DateTime(2026, 2, 2, 20, 29, 25, 467, DateTimeKind.Utc).AddTicks(3585), true, false, 0 });

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

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProfiles_NIP",
                table: "BusinessProfiles",
                column: "NIP");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProfiles_UserId",
                table: "BusinessProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NIPVerificationLogs_AttemptedAt",
                table: "NIPVerificationLogs",
                column: "AttemptedAt");

            migrationBuilder.CreateIndex(
                name: "IX_NIPVerificationLogs_UserId_AttemptedAt",
                table: "NIPVerificationLogs",
                columns: new[] { "UserId", "AttemptedAt" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessProfiles");

            migrationBuilder.DropTable(
                name: "NIPVerificationLogs");

            migrationBuilder.DropColumn(
                name: "BusinessPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BusinessStripePriceId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsAvailableForBusiness",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsBusinessOnly",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MinBusinessQuantity",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 323, DateTimeKind.Utc).AddTicks(3138), new DateTime(2026, 2, 1, 12, 26, 32, 323, DateTimeKind.Utc).AddTicks(3472) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 323, DateTimeKind.Utc).AddTicks(3799), new DateTime(2026, 2, 1, 12, 26, 32, 323, DateTimeKind.Utc).AddTicks(3800) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 323, DateTimeKind.Utc).AddTicks(3803), new DateTime(2026, 2, 1, 12, 26, 32, 323, DateTimeKind.Utc).AddTicks(3803) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 323, DateTimeKind.Utc).AddTicks(3806), new DateTime(2026, 2, 1, 12, 26, 32, 323, DateTimeKind.Utc).AddTicks(3807) });

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 323, DateTimeKind.Utc).AddTicks(3809), new DateTime(2026, 2, 1, 12, 26, 32, 323, DateTimeKind.Utc).AddTicks(3810) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 324, DateTimeKind.Utc).AddTicks(8056), new DateTime(2026, 2, 1, 12, 26, 32, 324, DateTimeKind.Utc).AddTicks(8378) });

            migrationBuilder.UpdateData(
                table: "BlogTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 324, DateTimeKind.Utc).AddTicks(8696), new DateTime(2026, 2, 1, 12, 26, 32, 324, DateTimeKind.Utc).AddTicks(8697) });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 324, DateTimeKind.Utc).AddTicks(527), new DateTime(2026, 2, 1, 12, 26, 32, 323, DateTimeKind.Utc).AddTicks(8628), new DateTime(2026, 2, 1, 12, 26, 32, 324, DateTimeKind.Utc).AddTicks(889) });

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 363, DateTimeKind.Utc).AddTicks(966));

            migrationBuilder.UpdateData(
                table: "CarouselSlideTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 363, DateTimeKind.Utc).AddTicks(1473));

            migrationBuilder.UpdateData(
                table: "CarouselSlides",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartDate" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 362, DateTimeKind.Utc).AddTicks(2203), new DateTime(2026, 2, 1, 12, 26, 32, 362, DateTimeKind.Utc).AddTicks(1824) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 320, DateTimeKind.Utc).AddTicks(9484));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 320, DateTimeKind.Utc).AddTicks(9865));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 320, DateTimeKind.Utc).AddTicks(9869));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 320, DateTimeKind.Utc).AddTicks(9872));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 321, DateTimeKind.Utc).AddTicks(221));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 321, DateTimeKind.Utc).AddTicks(226));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 321, DateTimeKind.Utc).AddTicks(230));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 321, DateTimeKind.Utc).AddTicks(233));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 321, DateTimeKind.Utc).AddTicks(237));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 321, DateTimeKind.Utc).AddTicks(240));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 321, DateTimeKind.Utc).AddTicks(243));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 321, DateTimeKind.Utc).AddTicks(246));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 319, DateTimeKind.Utc).AddTicks(3671));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 319, DateTimeKind.Utc).AddTicks(4113));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 319, DateTimeKind.Utc).AddTicks(4116));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 319, DateTimeKind.Utc).AddTicks(4118));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 319, DateTimeKind.Utc).AddTicks(4121));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 319, DateTimeKind.Utc).AddTicks(4123));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 319, DateTimeKind.Utc).AddTicks(4126));

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 319, DateTimeKind.Utc).AddTicks(4128));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ValidFrom", "ValidUntil" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 330, DateTimeKind.Utc).AddTicks(5643), new DateTime(2026, 2, 1, 12, 26, 32, 330, DateTimeKind.Utc).AddTicks(3813), new DateTime(2026, 8, 1, 12, 26, 32, 330, DateTimeKind.Utc).AddTicks(4169) });

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 318, DateTimeKind.Utc).AddTicks(1148));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 318, DateTimeKind.Utc).AddTicks(1621));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 318, DateTimeKind.Utc).AddTicks(1625));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 318, DateTimeKind.Utc).AddTicks(1627));

            migrationBuilder.UpdateData(
                table: "PackQuantities",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 318, DateTimeKind.Utc).AddTicks(1630));

            migrationBuilder.UpdateData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 331, DateTimeKind.Utc).AddTicks(1000));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 334, DateTimeKind.Utc).AddTicks(8551));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 334, DateTimeKind.Utc).AddTicks(9902));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 334, DateTimeKind.Utc).AddTicks(9908));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 334, DateTimeKind.Utc).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 334, DateTimeKind.Utc).AddTicks(9913));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 334, DateTimeKind.Utc).AddTicks(9929));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 334, DateTimeKind.Utc).AddTicks(9931));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 334, DateTimeKind.Utc).AddTicks(9934));

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 336, DateTimeKind.Utc).AddTicks(1298), new DateTime(2026, 2, 1, 12, 26, 32, 336, DateTimeKind.Utc).AddTicks(1302) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 357, DateTimeKind.Utc).AddTicks(1386), new DateTime(2026, 2, 1, 12, 26, 32, 357, DateTimeKind.Utc).AddTicks(1391) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 357, DateTimeKind.Utc).AddTicks(2245), new DateTime(2026, 2, 1, 12, 26, 32, 357, DateTimeKind.Utc).AddTicks(2246) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 357, DateTimeKind.Utc).AddTicks(4197), new DateTime(2026, 2, 1, 12, 26, 32, 357, DateTimeKind.Utc).AddTicks(4198) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 357, DateTimeKind.Utc).AddTicks(4217), new DateTime(2026, 2, 1, 12, 26, 32, 357, DateTimeKind.Utc).AddTicks(4218) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 357, DateTimeKind.Utc).AddTicks(4236), new DateTime(2026, 2, 1, 12, 26, 32, 357, DateTimeKind.Utc).AddTicks(4237) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 357, DateTimeKind.Utc).AddTicks(4242), new DateTime(2026, 2, 1, 12, 26, 32, 357, DateTimeKind.Utc).AddTicks(4243) });

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 357, DateTimeKind.Utc).AddTicks(4248), new DateTime(2026, 2, 1, 12, 26, 32, 357, DateTimeKind.Utc).AddTicks(4248) });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1441));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1873));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1877));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1881));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1885));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1897));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1900));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1904));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1907));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1941));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1945));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1948));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1952));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1955));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1958));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1962));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1965));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1970));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1974));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1977));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1981));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1984));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1987));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1991));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1994));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(1998));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2002));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2005));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2012));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2016));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2019));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2023));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2028));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2032));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2035));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2039));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2042));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2046));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2049));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2053));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2056));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2059));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2063));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2077));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2082));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2085));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2089));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2095));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2099));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2103));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2106));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2110));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2113));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2117));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2120));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2124));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2127));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2131));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2134));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2138));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2141));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2144));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2148));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2154));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2157));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2160));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2164));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2167));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2171));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2178));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2181));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2184));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2188));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2191));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2195));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2202));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2220));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2224));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2227));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2231));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2234));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2241));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2244));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2248));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2251));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 91,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2255));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 92,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2258));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 93,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2261));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 94,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2265));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 95,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2268));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 96,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2272));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 97,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2276));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 98,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2279));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 99,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2282));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 361, DateTimeKind.Utc).AddTicks(2286));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 333, DateTimeKind.Utc).AddTicks(4460));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 333, DateTimeKind.Utc).AddTicks(4985));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 333, DateTimeKind.Utc).AddTicks(5001));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 333, DateTimeKind.Utc).AddTicks(5013));

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 326, DateTimeKind.Utc).AddTicks(8261), new DateTime(2026, 2, 1, 12, 26, 32, 326, DateTimeKind.Utc).AddTicks(8603) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 326, DateTimeKind.Utc).AddTicks(8931), new DateTime(2026, 2, 1, 12, 26, 32, 326, DateTimeKind.Utc).AddTicks(8932) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 326, DateTimeKind.Utc).AddTicks(8934), new DateTime(2026, 2, 1, 12, 26, 32, 326, DateTimeKind.Utc).AddTicks(8935) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 326, DateTimeKind.Utc).AddTicks(8938), new DateTime(2026, 2, 1, 12, 26, 32, 326, DateTimeKind.Utc).AddTicks(8938) });

            migrationBuilder.UpdateData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 326, DateTimeKind.Utc).AddTicks(8942), new DateTime(2026, 2, 1, 12, 26, 32, 326, DateTimeKind.Utc).AddTicks(8942) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 328, DateTimeKind.Utc).AddTicks(361), new DateTime(2026, 2, 1, 12, 26, 32, 328, DateTimeKind.Utc).AddTicks(675) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 328, DateTimeKind.Utc).AddTicks(991), new DateTime(2026, 2, 1, 12, 26, 32, 328, DateTimeKind.Utc).AddTicks(992) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 328, DateTimeKind.Utc).AddTicks(995), new DateTime(2026, 2, 1, 12, 26, 32, 328, DateTimeKind.Utc).AddTicks(995) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 328, DateTimeKind.Utc).AddTicks(998), new DateTime(2026, 2, 1, 12, 26, 32, 328, DateTimeKind.Utc).AddTicks(998) });

            migrationBuilder.UpdateData(
                table: "ShippingRates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 328, DateTimeKind.Utc).AddTicks(1002), new DateTime(2026, 2, 1, 12, 26, 32, 328, DateTimeKind.Utc).AddTicks(1002) });

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 325, DateTimeKind.Utc).AddTicks(8059));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 325, DateTimeKind.Utc).AddTicks(8398));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 325, DateTimeKind.Utc).AddTicks(8400));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 325, DateTimeKind.Utc).AddTicks(8402));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 325, DateTimeKind.Utc).AddTicks(8405));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 325, DateTimeKind.Utc).AddTicks(8407));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 325, DateTimeKind.Utc).AddTicks(8409));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 325, DateTimeKind.Utc).AddTicks(8411));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 325, DateTimeKind.Utc).AddTicks(8413));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 325, DateTimeKind.Utc).AddTicks(8415));

            migrationBuilder.UpdateData(
                table: "SiteSettings",
                keyColumn: "Id",
                keyValue: 11,
                column: "UpdatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 325, DateTimeKind.Utc).AddTicks(8418));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 315, DateTimeKind.Utc).AddTicks(5984));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 315, DateTimeKind.Utc).AddTicks(6864));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 315, DateTimeKind.Utc).AddTicks(6866));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 315, DateTimeKind.Utc).AddTicks(6869));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 315, DateTimeKind.Utc).AddTicks(6871));

            migrationBuilder.UpdateData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 315, DateTimeKind.Utc).AddTicks(6873));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 322, DateTimeKind.Utc).AddTicks(3182));

            migrationBuilder.UpdateData(
                table: "SupportedLanguages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 12, 26, 32, 322, DateTimeKind.Utc).AddTicks(3695));

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 329, DateTimeKind.Utc).AddTicks(901), new DateTime(2026, 2, 1, 12, 26, 32, 329, DateTimeKind.Utc).AddTicks(1388) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 329, DateTimeKind.Utc).AddTicks(1878), new DateTime(2026, 2, 1, 12, 26, 32, 329, DateTimeKind.Utc).AddTicks(1879) });

            migrationBuilder.UpdateData(
                table: "TaxRates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 2, 1, 12, 26, 32, 329, DateTimeKind.Utc).AddTicks(1882), new DateTime(2026, 2, 1, 12, 26, 32, 329, DateTimeKind.Utc).AddTicks(1883) });
        }
    }
}
