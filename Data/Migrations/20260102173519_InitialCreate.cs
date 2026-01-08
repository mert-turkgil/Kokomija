using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kokomija.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminEarnings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeriodType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "all-time"),
                    PeriodStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalOrders = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    TotalProductsSold = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    TotalSalesRevenue = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    TotalPlatformCommission = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    TotalStripeFees = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    TotalDeveloperCommission = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDeductions = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    NetRevenue = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    AverageOrderValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    AverageCommissionPerOrder = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    CurrentCommissionRate = table.Column<decimal>(type: "decimal(5,4)", nullable: false, defaultValue: 0.01m),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, defaultValue: "PLN"),
                    LastCalculatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminEarnings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StripeCustomerId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DefaultPaymentMethodId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLoginAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    VipTier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalSpent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NameKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ShowInNavbar = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IconCssClass = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HexCode = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailCommands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommandType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SenderEmail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommandParameters = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "pending"),
                    IsAuthorized = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AuthorizationToken = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TokenExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsExecuted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ExecutionResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceivedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ExecutedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConfirmationIp = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailCommands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NameKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DescriptionKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroups", x => x.Id);
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
                name: "SiteClosures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Reason = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ClosedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ClosedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ScheduledReopenAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReopenConfirmationToken = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TokenExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AllowPasswordAccess = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    EmergencyPasswordHash = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ReopenedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReopenedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ReopenMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DaysClosed = table.Column<int>(type: "int", nullable: true),
                    ConfirmationEmailsSent = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    LastConfirmationEmailAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteClosures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "General"),
                    DataType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "string"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupportedLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CultureCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NativeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FlagIcon = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    TwoLetterIsoCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportedLanguages", x => x.Id);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "NewsletterSubscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ReceiveNewProductNotifications = table.Column<bool>(type: "bit", nullable: false),
                    ReceiveDiscountNotifications = table.Column<bool>(type: "bit", nullable: false),
                    ReceiveWishlistNotifications = table.Column<bool>(type: "bit", nullable: false),
                    SubscribedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UnsubscribedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UnsubscribeToken = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ConfirmationToken = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ConfirmationTokenExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConfirmedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsletterSubscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsletterSubscriptions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StripePaymentMethodId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CardBrand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Last4 = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    ExpMonth = table.Column<int>(type: "int", nullable: true),
                    ExpYear = table.Column<int>(type: "int", nullable: true),
                    CardholderName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BillingPostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BillingCountry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Nickname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUsedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentMethods_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "BlogCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IconUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Language = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, defaultValue: "pl"),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogCategories_Categories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CarouselSlides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TabletImagePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MobileImagePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ImageAlt = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    LinkUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RouteName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RouteParameters = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ButtonText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ButtonClass = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, defaultValue: "btn-primary"),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "home"),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    BackgroundColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TextColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TextAlign = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "center"),
                    AnimationType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: "fade"),
                    Duration = table.Column<int>(type: "int", nullable: false, defaultValue: 5000),
                    CustomCssClass = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarouselSlides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarouselSlides_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

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

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StripeProductId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StripePriceId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StripeTaxCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PackSize = table.Column<int>(type: "int", nullable: false),
                    ProductGroupId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Products_ProductGroups_ProductGroupId",
                        column: x => x.ProductGroupId,
                        principalTable: "ProductGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                name: "CarouselSlideTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarouselSlideId = table.Column<int>(type: "int", nullable: false),
                    CultureCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ButtonText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LinkUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ControllerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ActionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AreaName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RouteParameters = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ImageAlt = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarouselSlideTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarouselSlideTranslations_CarouselSlides_CarouselSlideId",
                        column: x => x.CarouselSlideId,
                        principalTable: "CarouselSlides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeaturedImage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Views = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    AllowComments = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Blogs_BlogCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "BlogCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Blogs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    SizeId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Carts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DiscountType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "percentage"),
                    DiscountValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinimumOrderAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaximumDiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UsageLimit = table.Column<int>(type: "int", nullable: true),
                    UsageCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    UsageLimitPerUser = table.Column<int>(type: "int", nullable: true),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidUntil = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    StripeCouponId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StripePromotionCodeId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coupons_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Coupons_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Coupons_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductColors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductColors_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductColors_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AltText = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPriceHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OldPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NewPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ChangedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChangedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPriceHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPriceHistories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "ProductSizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSizes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSizes_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CultureCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MetaKeywords = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTranslations_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    SKU = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    StripePriceId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVariants_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ProductVariants_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVariants_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

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

            migrationBuilder.CreateTable(
                name: "BlogTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    CultureCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Excerpt = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: true),
                    MetaKeywords = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogTranslations_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StripePaymentIntentId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StripeChargeId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StripeCheckoutSessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    TaxRate = table.Column<decimal>(type: "decimal(5,4)", nullable: false, defaultValue: 0m),
                    CommissionAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CommissionRate = table.Column<decimal>(type: "decimal(5,4)", nullable: false, defaultValue: 0.015m),
                    CouponId = table.Column<int>(type: "int", nullable: true),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    ShippingCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubtotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CustomerPhone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ShippingAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ShippingCity = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ShippingState = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ShippingPostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ShippingCountry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BillingAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BillingCity = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BillingState = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BillingPostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BillingCountry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OrderStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "pending"),
                    PaymentStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "pending"),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SessionStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CustomerCountry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaidAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShippedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveredAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDemoOrder = table.Column<bool>(type: "bit", nullable: false),
                    StripeRefundId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RefundedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RefundedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RefundReason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Orders_Coupons_CouponId",
                        column: x => x.CouponId,
                        principalTable: "Coupons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "WishlistNotifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WishlistId = table.Column<int>(type: "int", nullable: false),
                    NotificationType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    OldPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NewPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CouponCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    EmailSent = table.Column<bool>(type: "bit", nullable: false),
                    EmailSentAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishlistNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WishlistNotifications_Wishlists_WishlistId",
                        column: x => x.WishlistId,
                        principalTable: "Wishlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CouponUsages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CouponId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UsedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponUsages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CouponUsages_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CouponUsages_Coupons_CouponId",
                        column: x => x.CouponId,
                        principalTable: "Coupons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CouponUsages_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
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
                    StripePayoutId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
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
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductVariantId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Size = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_ProductVariants_ProductVariantId",
                        column: x => x.ProductVariantId,
                        principalTable: "ProductVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "AdminCommissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    OrderItemId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlatformCommissionRate = table.Column<decimal>(type: "decimal(5,4)", nullable: false, defaultValue: 0.01m),
                    PlatformCommissionAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StripeProcessingFeeRate = table.Column<decimal>(type: "decimal(5,4)", nullable: false, defaultValue: 0.014m),
                    StripeFixedFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 1.00m),
                    TotalStripeFees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDeductions = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, defaultValue: "PLN"),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "pending"),
                    CalculatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    PaidAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminCommissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminCommissions_OrderItems_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AdminCommissions_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdminCommissions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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

            migrationBuilder.InsertData(
                table: "BlogCategories",
                columns: new[] { "Id", "CreatedAt", "Description", "DisplayOrder", "IconUrl", "IsActive", "Language", "MetaDescription", "Name", "ProductCategoryId", "Slug", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 2, 17, 35, 18, 823, DateTimeKind.Utc).AddTicks(7349), "Porady dotyczące zakupów i stylizacji", 1, null, true, "pl", "Porady zakupowe i stylizacyjne dla klientów Kokomija", "Porady", null, "porady", new DateTime(2026, 1, 2, 17, 35, 18, 823, DateTimeKind.Utc).AddTicks(7651) },
                    { 2, new DateTime(2026, 1, 2, 17, 35, 18, 823, DateTimeKind.Utc).AddTicks(7947), "Najnowsze produkty i kolekcje", 2, null, true, "pl", "Najnowsze produkty i kolekcje w Kokomija", "Nowości", null, "nowosci", new DateTime(2026, 1, 2, 17, 35, 18, 823, DateTimeKind.Utc).AddTicks(7948) },
                    { 3, new DateTime(2026, 1, 2, 17, 35, 18, 823, DateTimeKind.Utc).AddTicks(7951), "Najnowsze trendy w modzie", 3, null, true, "pl", "Najnowsze trendy w modzie i stylizacji", "Trendy", null, "trendy", new DateTime(2026, 1, 2, 17, 35, 18, 823, DateTimeKind.Utc).AddTicks(7951) },
                    { 4, new DateTime(2026, 1, 2, 17, 35, 18, 823, DateTimeKind.Utc).AddTicks(7954), "Inspiracje stylizacyjne i lookbooki", 4, null, true, "pl", "Inspiracje stylizacyjne i lookbooki od Kokomija", "Inspiracje", null, "inspiracje", new DateTime(2026, 1, 2, 17, 35, 18, 823, DateTimeKind.Utc).AddTicks(7954) },
                    { 5, new DateTime(2026, 1, 2, 17, 35, 18, 823, DateTimeKind.Utc).AddTicks(7957), "Informacje o marce Kokomija", 5, null, true, "pl", "Informacje o marce Kokomija i naszej misji", "O marce", null, "o-marce", new DateTime(2026, 1, 2, 17, 35, 18, 823, DateTimeKind.Utc).AddTicks(7957) }
                });

            migrationBuilder.InsertData(
                table: "CarouselSlides",
                columns: new[] { "Id", "AnimationType", "BackgroundColor", "ButtonClass", "ButtonText", "CategoryId", "CreatedAt", "CreatedBy", "CustomCssClass", "DeletedAt", "DeletedBy", "DisplayOrder", "Duration", "EndDate", "ImageAlt", "ImagePath", "IsActive", "LinkUrl", "Location", "MobileImagePath", "RouteName", "RouteParameters", "StartDate", "Subtitle", "TabletImagePath", "TextAlign", "TextColor", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, "fade", null, "btn-primary", "Carousel_ShopNow", null, new DateTime(2026, 1, 2, 17, 35, 18, 833, DateTimeKind.Utc).AddTicks(1491), null, null, null, null, 1, 5000, null, "New Spring 2025 Collection", "/img/Carousel/1.jpg", true, null, "Home", "/img/Carousel/3.jpg", null, null, new DateTime(2026, 1, 2, 17, 35, 18, 833, DateTimeKind.Utc).AddTicks(1160), "Carousel_NewCollection_Subtitle", "/img/Carousel/2.jpg", "center", null, "Carousel_NewCollection", null, null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "DisplayOrder", "IconCssClass", "ImageUrl", "IsActive", "Name", "NameKey", "ParentCategoryId", "ShowInNavbar", "Slug", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 2, 17, 35, 18, 822, DateTimeKind.Utc).AddTicks(3914), null, "Odzież damska", 1, "fas fa-female", "categories/women.jpg", true, "Damskie", "Category_Women", null, true, "damskie", null, null },
                    { 2, new DateTime(2026, 1, 2, 17, 35, 18, 822, DateTimeKind.Utc).AddTicks(4225), null, "Odzież męska", 2, "fas fa-male", "categories/men.jpg", true, "Męskie", "Category_Men", null, true, "meskie", null, null },
                    { 3, new DateTime(2026, 1, 2, 17, 35, 18, 822, DateTimeKind.Utc).AddTicks(4228), null, "Kurtki i płaszcze", 3, "fas fa-wind", "categories/outerwear.jpg", true, "Odzież Wierzchnia", "Category_Outerwear", null, true, "odziez-wierzchnia", null, null },
                    { 4, new DateTime(2026, 1, 2, 17, 35, 18, 822, DateTimeKind.Utc).AddTicks(4231), null, "Dodatki i akcesoria", 4, "fas fa-shopping-bag", "categories/accessories.jpg", true, "Akcesoria", "Category_Accessories", null, true, "akcesoria", null, null }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "CreatedAt", "DisplayName", "DisplayOrder", "HexCode", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 2, 17, 35, 18, 821, DateTimeKind.Utc).AddTicks(1147), "Black", 1, "#000000", true, "Black" },
                    { 2, new DateTime(2026, 1, 2, 17, 35, 18, 821, DateTimeKind.Utc).AddTicks(1494), "White", 2, "#FFFFFF", true, "White" },
                    { 3, new DateTime(2026, 1, 2, 17, 35, 18, 821, DateTimeKind.Utc).AddTicks(1497), "Red", 3, "#FF0000", true, "Red" },
                    { 4, new DateTime(2026, 1, 2, 17, 35, 18, 821, DateTimeKind.Utc).AddTicks(1499), "Blue", 4, "#0000FF", true, "Blue" },
                    { 5, new DateTime(2026, 1, 2, 17, 35, 18, 821, DateTimeKind.Utc).AddTicks(1501), "Green", 5, "#00FF00", true, "Green" },
                    { 6, new DateTime(2026, 1, 2, 17, 35, 18, 821, DateTimeKind.Utc).AddTicks(1504), "Yellow", 6, "#FFFF00", true, "Yellow" },
                    { 7, new DateTime(2026, 1, 2, 17, 35, 18, 821, DateTimeKind.Utc).AddTicks(1506), "Navy Blue", 7, "#000080", true, "Navy" },
                    { 8, new DateTime(2026, 1, 2, 17, 35, 18, 821, DateTimeKind.Utc).AddTicks(1508), "Gray", 8, "#808080", true, "Gray" }
                });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "CategoryId", "Code", "CreatedAt", "Description", "DiscountType", "DiscountValue", "IsActive", "MaximumDiscountAmount", "MinimumOrderAmount", "ProductId", "StripeCouponId", "StripePromotionCodeId", "UpdatedAt", "UsageLimit", "UsageLimitPerUser", "UserId", "ValidFrom", "ValidUntil" },
                values: new object[] { 1, null, "WELCOME10", new DateTime(2026, 1, 2, 17, 35, 18, 829, DateTimeKind.Utc).AddTicks(3071), "10% off your first order", "percentage", 10.00m, true, 50.00m, 50.00m, null, "", "", null, 1000, 1, null, new DateTime(2026, 1, 2, 17, 35, 18, 829, DateTimeKind.Utc).AddTicks(1438), new DateTime(2026, 7, 2, 17, 35, 18, 829, DateTimeKind.Utc).AddTicks(1752) });

            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "Id", "CreatedAt", "Description", "DescriptionKey", "Name", "NameKey", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2026, 1, 2, 17, 35, 18, 829, DateTimeKind.Utc).AddTicks(7942), "High-quality women's cotton briefs in various pack sizes", "ProductGroup_WomenBriefs_Description", "Women's Cotton Briefs Pack Collection", "ProductGroup_WomenBriefs_Name", null });

            migrationBuilder.InsertData(
                table: "ShippingProviders",
                columns: new[] { "Id", "ApiKey", "ApiSecret", "Code", "CreatedAt", "EstimatedDeliveryDays", "IsActive", "LogoUrl", "Name", "SupportedCountries", "TrackingUrlTemplate", "UpdatedAt", "WebhookUrl" },
                values: new object[,]
                {
                    { 1, null, null, "inpost", new DateTime(2026, 1, 2, 17, 35, 18, 826, DateTimeKind.Utc).AddTicks(5629), 2, true, null, "InPost", "[\"PL\"]", "https://inpost.pl/sledzenie-przesylek?number={trackingNumber}", new DateTime(2026, 1, 2, 17, 35, 18, 826, DateTimeKind.Utc).AddTicks(5939), null },
                    { 2, null, null, "dhl", new DateTime(2026, 1, 2, 17, 35, 18, 826, DateTimeKind.Utc).AddTicks(6238), 3, true, null, "DHL", "[\"PL\",\"DE\",\"US\",\"GB\"]", "https://www.dhl.com/en/express/tracking.html?AWB={trackingNumber}", new DateTime(2026, 1, 2, 17, 35, 18, 826, DateTimeKind.Utc).AddTicks(6239), null },
                    { 3, null, null, "ups", new DateTime(2026, 1, 2, 17, 35, 18, 826, DateTimeKind.Utc).AddTicks(6242), 3, true, null, "UPS", "[\"PL\",\"DE\",\"US\",\"GB\"]", "https://www.ups.com/track?tracknum={trackingNumber}", new DateTime(2026, 1, 2, 17, 35, 18, 826, DateTimeKind.Utc).AddTicks(6242), null },
                    { 4, null, null, "fedex", new DateTime(2026, 1, 2, 17, 35, 18, 826, DateTimeKind.Utc).AddTicks(6245), 3, true, null, "FedEx", "[\"PL\",\"DE\",\"US\",\"GB\"]", "https://www.fedex.com/fedextrack/?trknbr={trackingNumber}", new DateTime(2026, 1, 2, 17, 35, 18, 826, DateTimeKind.Utc).AddTicks(6245), null },
                    { 5, null, null, "poczta_polska", new DateTime(2026, 1, 2, 17, 35, 18, 826, DateTimeKind.Utc).AddTicks(6248), 5, true, null, "Poczta Polska", "[\"PL\"]", "https://emonitoring.poczta-polska.pl/?numer={trackingNumber}", new DateTime(2026, 1, 2, 17, 35, 18, 826, DateTimeKind.Utc).AddTicks(6248), null }
                });

            migrationBuilder.InsertData(
                table: "SiteSettings",
                columns: new[] { "Id", "Category", "DataType", "Description", "Key", "UpdatedAt", "UpdatedBy", "Value" },
                values: new object[,]
                {
                    { 1, "Security", "string", "Super admin email for site control and emergency commands", "SuperAdminEmail", new DateTime(2026, 1, 2, 17, 35, 18, 825, DateTimeKind.Utc).AddTicks(8282), null, "admin@kokomija.com" },
                    { 2, "Commission", "decimal", "Platform commission rate per product sale (decimal, e.g., 0.01 = 1%)", "PlatformCommissionRate", new DateTime(2026, 1, 2, 17, 35, 18, 825, DateTimeKind.Utc).AddTicks(8589), null, "0.01" },
                    { 3, "Commission", "decimal", "Stripe processing fee rate (decimal, e.g., 0.014 = 1.4%)", "StripeProcessingFeeRate", new DateTime(2026, 1, 2, 17, 35, 18, 825, DateTimeKind.Utc).AddTicks(8591), null, "0.014" },
                    { 4, "Commission", "decimal", "Stripe fixed fee per transaction in PLN", "StripeFixedFee", new DateTime(2026, 1, 2, 17, 35, 18, 825, DateTimeKind.Utc).AddTicks(8593), null, "1.00" },
                    { 5, "Maintenance", "boolean", "Is site currently closed for maintenance", "SiteClosureEnabled", new DateTime(2026, 1, 2, 17, 35, 18, 825, DateTimeKind.Utc).AddTicks(8595), null, "false" },
                    { 6, "Maintenance", "string", "Message displayed when site is closed", "SiteClosureMessage", new DateTime(2026, 1, 2, 17, 35, 18, 825, DateTimeKind.Utc).AddTicks(8596), null, "Przepraszamy, serwis jest tymczasowo niedostępny z powodu konserwacji." },
                    { 7, "Maintenance", "integer", "Automatically reopen site after X days of closure", "AutoReopenAfterDays", new DateTime(2026, 1, 2, 17, 35, 18, 825, DateTimeKind.Utc).AddTicks(8629), null, "30" },
                    { 8, "Maintenance", "boolean", "Send daily confirmation emails during site closure", "DailyConfirmationEmailEnabled", new DateTime(2026, 1, 2, 17, 35, 18, 825, DateTimeKind.Utc).AddTicks(8631), null, "true" },
                    { 9, "Tax", "decimal", "Tax rate (VAT) applied to orders (decimal, e.g., 0.23 = 23%)", "TaxRate", new DateTime(2026, 1, 2, 17, 35, 18, 825, DateTimeKind.Utc).AddTicks(8633), null, "0.23" },
                    { 10, "Shipping", "decimal", "Standard shipping cost in PLN", "ShippingRate", new DateTime(2026, 1, 2, 17, 35, 18, 825, DateTimeKind.Utc).AddTicks(8635), null, "15.00" },
                    { 11, "Shipping", "decimal", "Minimum order value for free shipping in PLN", "FreeShippingThreshold", new DateTime(2026, 1, 2, 17, 35, 18, 825, DateTimeKind.Utc).AddTicks(8637), null, "200.00" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "CreatedAt", "DisplayName", "DisplayOrder", "IsActive", "Name", "Region" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 2, 17, 35, 18, 819, DateTimeKind.Utc).AddTicks(4642), "Extra Small", 1, true, "XS", null },
                    { 2, new DateTime(2026, 1, 2, 17, 35, 18, 819, DateTimeKind.Utc).AddTicks(4964), "Small", 2, true, "S", null },
                    { 3, new DateTime(2026, 1, 2, 17, 35, 18, 819, DateTimeKind.Utc).AddTicks(4966), "Medium", 3, true, "M", null },
                    { 4, new DateTime(2026, 1, 2, 17, 35, 18, 819, DateTimeKind.Utc).AddTicks(4969), "Large", 4, true, "L", null },
                    { 5, new DateTime(2026, 1, 2, 17, 35, 18, 819, DateTimeKind.Utc).AddTicks(4971), "Extra Large", 5, true, "XL", null },
                    { 6, new DateTime(2026, 1, 2, 17, 35, 18, 819, DateTimeKind.Utc).AddTicks(4973), "2X Large", 6, true, "XXL", null }
                });

            migrationBuilder.InsertData(
                table: "SupportedLanguages",
                columns: new[] { "Id", "CreatedAt", "CultureCode", "DisplayName", "DisplayOrder", "FlagIcon", "IsDefault", "IsEnabled", "NativeName", "TwoLetterIsoCode" },
                values: new object[] { 1, new DateTime(2026, 1, 2, 17, 35, 18, 823, DateTimeKind.Utc).AddTicks(381), "pl-PL", "Polski", 1, "🇵🇱", true, true, "Polski", "pl" });

            migrationBuilder.InsertData(
                table: "SupportedLanguages",
                columns: new[] { "Id", "CreatedAt", "CultureCode", "DisplayName", "DisplayOrder", "FlagIcon", "NativeName", "TwoLetterIsoCode" },
                values: new object[] { 2, new DateTime(2026, 1, 2, 17, 35, 18, 823, DateTimeKind.Utc).AddTicks(690), "en-US", "English", 2, "🇺🇸", "English", "en" });

            migrationBuilder.InsertData(
                table: "TaxRates",
                columns: new[] { "Id", "CountryCode", "CreatedAt", "Description", "IsActive", "IsDefault", "Name", "Rate", "StateCode", "StripeTaxRateId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "PL", new DateTime(2026, 1, 2, 17, 35, 18, 828, DateTimeKind.Utc).AddTicks(2982), "Standard VAT rate for Poland", true, true, "VAT 23% (Poland)", 23.00m, null, "txr_placeholder_pl_23", new DateTime(2026, 1, 2, 17, 35, 18, 828, DateTimeKind.Utc).AddTicks(3276) },
                    { 2, "PL", new DateTime(2026, 1, 2, 17, 35, 18, 828, DateTimeKind.Utc).AddTicks(3570), "Reduced VAT rate for specific products", true, false, "VAT 8% (Poland - Reduced)", 8.00m, null, "txr_placeholder_pl_8", new DateTime(2026, 1, 2, 17, 35, 18, 828, DateTimeKind.Utc).AddTicks(3570) },
                    { 3, "PL", new DateTime(2026, 1, 2, 17, 35, 18, 828, DateTimeKind.Utc).AddTicks(3573), "Super reduced VAT rate", false, false, "VAT 5% (Poland - Super Reduced)", 5.00m, null, "txr_placeholder_pl_5", new DateTime(2026, 1, 2, 17, 35, 18, 828, DateTimeKind.Utc).AddTicks(3573) }
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "AllowComments", "AuthorId", "CategoryId", "CreatedAt", "FeaturedImage", "IsPublished", "ProductId", "PublishedDate", "UpdatedAt" },
                values: new object[] { 1, true, null, 3, new DateTime(2026, 1, 2, 17, 35, 18, 824, DateTimeKind.Utc).AddTicks(3266), "/img/Blog/fashion-trends-2025.jpg", true, null, new DateTime(2026, 1, 2, 17, 35, 18, 824, DateTimeKind.Utc).AddTicks(1962), new DateTime(2026, 1, 2, 17, 35, 18, 824, DateTimeKind.Utc).AddTicks(3559) });

            migrationBuilder.InsertData(
                table: "CarouselSlideTranslations",
                columns: new[] { "Id", "ActionName", "AreaName", "ButtonText", "CarouselSlideId", "ControllerName", "CreatedAt", "CultureCode", "ImageAlt", "LinkUrl", "RouteParameters", "Subtitle", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Index", null, "Shop Now", 1, "Product", new DateTime(2026, 1, 2, 17, 35, 18, 833, DateTimeKind.Utc).AddTicks(7833), "en-US", "Kokomija Spring 2025 Fashion Collection - Premium Women's and Men's Underwear", null, null, "Discover the latest trends in women's and men's fashion", "New Spring 2025 Collection", null },
                    { 2, "Index", null, "Kup Teraz", 1, "Product", new DateTime(2026, 1, 2, 17, 35, 18, 833, DateTimeKind.Utc).AddTicks(8140), "pl-PL", "Kokomija Kolekcja Wiosna 2025 - Wysokiej Jakości Bielizna Damska i Męska", null, null, "Odkryj najnowsze trendy w modzie damskiej i męskiej", "Nowa Kolekcja Wiosna 2025", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "DisplayOrder", "IconCssClass", "ImageUrl", "IsActive", "Name", "NameKey", "ParentCategoryId", "ShowInNavbar", "Slug", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 5, new DateTime(2026, 1, 2, 17, 35, 18, 822, DateTimeKind.Utc).AddTicks(4550), null, "Eleganckie sukienki damskie", 1, "fas fa-tshirt", null, true, "Sukienki", "Category_Dresses", 1, true, "damskie-sukienki", null, null },
                    { 6, new DateTime(2026, 1, 2, 17, 35, 18, 822, DateTimeKind.Utc).AddTicks(4556), null, "Modne spódnice", 2, "fas fa-tshirt", null, true, "Spódnice", "Category_Skirts", 1, true, "damskie-spodnice", null, null },
                    { 7, new DateTime(2026, 1, 2, 17, 35, 18, 822, DateTimeKind.Utc).AddTicks(4559), null, "Eleganckie bluzki damskie", 3, "fas fa-tshirt", null, true, "Bluzki", "Category_Blouses", 1, true, "damskie-bluzki", null, null },
                    { 8, new DateTime(2026, 1, 2, 17, 35, 18, 822, DateTimeKind.Utc).AddTicks(4562), null, "Spodnie damskie", 4, "fas fa-tshirt", null, true, "Spodnie", "Category_WomenPants", 1, true, "damskie-spodnie", null, null },
                    { 9, new DateTime(2026, 1, 2, 17, 35, 18, 822, DateTimeKind.Utc).AddTicks(4564), null, "Eleganckie koszule męskie", 1, "fas fa-tshirt", null, true, "Koszule", "Category_Shirts", 2, true, "meskie-koszule", null, null },
                    { 10, new DateTime(2026, 1, 2, 17, 35, 18, 822, DateTimeKind.Utc).AddTicks(4567), null, "Spodnie męskie", 2, "fas fa-tshirt", null, true, "Spodnie", "Category_MenPants", 2, true, "meskie-spodnie", null, null },
                    { 11, new DateTime(2026, 1, 2, 17, 35, 18, 822, DateTimeKind.Utc).AddTicks(4570), null, "Koszulki męskie", 3, "fas fa-tshirt", null, true, "T-Shirty", "Category_TShirts", 2, true, "meskie-tshirty", null, null },
                    { 12, new DateTime(2026, 1, 2, 17, 35, 18, 822, DateTimeKind.Utc).AddTicks(4573), null, "Bluzy męskie", 4, "fas fa-tshirt", null, true, "Bluzy", "Category_Sweatshirts", 2, true, "meskie-bluzy", null, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "IsActive", "Name", "PackSize", "Price", "ProductGroupId", "StripePriceId", "StripeProductId", "StripeTaxCode", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 1, 2, 17, 35, 18, 830, DateTimeKind.Utc).AddTicks(7267), "Wysokiej jakości majtki damskie bawełniane w zestawie 5 sztuk. Wygodne, przewiewne i trwałe. Idealny wybór na co dzień. Dostępne w różnych kolorach i rozmiarach.", true, "Majtki damskie bawełniane wysokie - 5 pak", 5, 49.75m, 1, "", "", "txcd_30011000", null },
                    { 2, 1, new DateTime(2026, 1, 2, 17, 35, 18, 830, DateTimeKind.Utc).AddTicks(7568), "Wysokiej jakości majtki damskie bawełniane w zestawie 6 sztuk. Wygodne, przewiewne i trwałe. Idealny wybór na co dzień. Dostępne w różnych kolorach i rozmiarach.", true, "Majtki damskie bawełniane wysokie - 6 pak", 6, 59.70m, 1, "", "", "txcd_30011000", null },
                    { 3, 1, new DateTime(2026, 1, 2, 17, 35, 18, 830, DateTimeKind.Utc).AddTicks(7571), "Wysokiej jakości majtki damskie bawełniane w zestawie 8 sztuk. Wygodne, przewiewne i trwałe. Najlepszy wybór wartościowy! Dostępne w różnych kolorach i rozmiarach.", true, "Majtki damskie bawełniane wysokie - 8 pak", 8, 79.60m, 1, "", "", "txcd_30011000", null }
                });

            migrationBuilder.InsertData(
                table: "ShippingRates",
                columns: new[] { "Id", "BasePrice", "CountryCode", "CreatedAt", "Description", "FreeShippingThreshold", "IsActive", "MaxDeliveryDays", "MinDeliveryDays", "Name", "PricePerKg", "PricePerKm", "ShippingProviderId", "StripeShippingRateId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 9.99m, "PL", new DateTime(2026, 1, 2, 17, 35, 18, 827, DateTimeKind.Utc).AddTicks(6159), "Delivery to InPost parcel locker", 100.00m, true, 2, 1, "InPost Paczkomat", null, null, 1, null, new DateTime(2026, 1, 2, 17, 35, 18, 827, DateTimeKind.Utc).AddTicks(6462) },
                    { 2, 14.99m, "PL", new DateTime(2026, 1, 2, 17, 35, 18, 827, DateTimeKind.Utc).AddTicks(6761), "Home delivery by InPost courier", 150.00m, true, 2, 1, "InPost Courier", null, null, 1, null, new DateTime(2026, 1, 2, 17, 35, 18, 827, DateTimeKind.Utc).AddTicks(6761) },
                    { 3, 29.99m, null, new DateTime(2026, 1, 2, 17, 35, 18, 827, DateTimeKind.Utc).AddTicks(6764), "Standard international delivery", null, true, 5, 3, "DHL Standard", null, null, 2, null, new DateTime(2026, 1, 2, 17, 35, 18, 827, DateTimeKind.Utc).AddTicks(6764) },
                    { 4, 49.99m, null, new DateTime(2026, 1, 2, 17, 35, 18, 827, DateTimeKind.Utc).AddTicks(6767), "Express international delivery", null, true, 2, 1, "DHL Express", null, null, 2, null, new DateTime(2026, 1, 2, 17, 35, 18, 827, DateTimeKind.Utc).AddTicks(6768) },
                    { 5, 12.99m, "PL", new DateTime(2026, 1, 2, 17, 35, 18, 827, DateTimeKind.Utc).AddTicks(6771), "Standard postal delivery", 120.00m, true, 5, 3, "Poczta Polska Standard", null, null, 5, null, new DateTime(2026, 1, 2, 17, 35, 18, 827, DateTimeKind.Utc).AddTicks(6772) }
                });

            migrationBuilder.InsertData(
                table: "BlogTranslations",
                columns: new[] { "Id", "BlogId", "Content", "CreatedAt", "CultureCode", "Excerpt", "MetaDescription", "MetaKeywords", "Slug", "Tags", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, "<p>Discover the hottest fashion trends that will dominate 2025. From sustainable fabrics to bold colors, we present everything you need to know to stay stylish.</p><p>This season brings a return to classics with a modern twist - oversized blazers, midi skirts, and minimalist accessories are the must-haves in every wardrobe.</p><p><strong>Key trends:</strong></p><ul><li>Sustainable and eco-friendly materials</li><li>Bold color combinations</li><li>Oversized silhouettes</li><li>Minimalist accessories</li><li>Vintage revival</li></ul><p>Stay tuned for more fashion tips and style inspiration on our blog!</p>", new DateTime(2026, 1, 2, 17, 35, 18, 825, DateTimeKind.Utc).AddTicks(214), "en-US", "Discover the hottest fashion trends that will dominate 2025. From sustainable fabrics to bold colors.", "Discover the hottest fashion trends for 2025 - sustainable materials, bold colors, and timeless style.", "fashion,trends,2025,style,clothing,sustainable fashion", "fashion-trends-2025", "fashion,trends,2025,style", "Fashion Trends for 2025", new DateTime(2026, 1, 2, 17, 35, 18, 825, DateTimeKind.Utc).AddTicks(519) },
                    { 2, 1, "<p>Odkryj najgorętsze trendy modowe, które zdominują rok 2025. Od zrównoważonych materiałów po odważne kolory, prezentujemy wszystko, co musisz wiedzieć, aby być na czasie.</p><p>Ten sezon przynosi powrót do klasyki z nowoczesnym akcentem - oversize'owe marynarki, midi spódnice i minimalistyczna biżuteria to must-have w każdej garderobie.</p><p><strong>Kluczowe trendy:</strong></p><ul><li>Zrównoważone i ekologiczne materiały</li><li>Odważne kombinacje kolorów</li><li>Oversize'owe sylwetki</li><li>Minimalistyczne akcesoria</li><li>Powrót vintage</li></ul><p>Bądź na bieżąco z naszymi poradami modowymi i inspiracjami stylistycznymi na blogu!</p>", new DateTime(2026, 1, 2, 17, 35, 18, 825, DateTimeKind.Utc).AddTicks(845), "pl-PL", "Odkryj najgorętsze trendy modowe, które zdominują rok 2025. Od zrównoważonych materiałów po odważne kolory.", "Odkryj najgorętsze trendy modowe na rok 2025 - zrównoważone materiały, odważne kolory i ponadczasowy styl.", "moda,trendy,2025,styl,odzież,zrównoważona moda", "trendy-modowe-2025", "moda,trendy,2025,styl", "Trendy Modowe na 2025", new DateTime(2026, 1, 2, 17, 35, 18, 825, DateTimeKind.Utc).AddTicks(846) }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "IsPrimary", "ProductId" },
                values: new object[] { 1, "Majtki damskie bawełniane 5-pak - zdjęcie 1", null, new DateTime(2026, 1, 2, 17, 35, 18, 831, DateTimeKind.Utc).AddTicks(4339), 1, "products/briefs-5pack/image-1.jpg", true, 1 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 2, "Majtki damskie bawełniane 5-pak - zdjęcie 2", null, new DateTime(2026, 1, 2, 17, 35, 18, 831, DateTimeKind.Utc).AddTicks(4676), 2, "products/briefs-5pack/image-2.jpg", 1 },
                    { 3, "Majtki damskie bawełniane 5-pak - zdjęcie 3", null, new DateTime(2026, 1, 2, 17, 35, 18, 831, DateTimeKind.Utc).AddTicks(4679), 3, "products/briefs-5pack/image-3.jpg", 1 },
                    { 4, "Majtki damskie bawełniane 5-pak - zdjęcie 4", null, new DateTime(2026, 1, 2, 17, 35, 18, 831, DateTimeKind.Utc).AddTicks(4712), 4, "products/briefs-5pack/image-4.jpg", 1 },
                    { 5, "Majtki damskie bawełniane 5-pak - zdjęcie 5", null, new DateTime(2026, 1, 2, 17, 35, 18, 831, DateTimeKind.Utc).AddTicks(4715), 5, "products/briefs-5pack/image-5.jpg", 1 },
                    { 6, "Majtki damskie bawełniane 5-pak - zdjęcie 6", null, new DateTime(2026, 1, 2, 17, 35, 18, 831, DateTimeKind.Utc).AddTicks(4722), 6, "products/briefs-5pack/image-6.jpg", 1 },
                    { 7, "Majtki damskie bawełniane 5-pak - zdjęcie 7", null, new DateTime(2026, 1, 2, 17, 35, 18, 831, DateTimeKind.Utc).AddTicks(4724), 7, "products/briefs-5pack/image-7.jpg", 1 },
                    { 8, "Majtki damskie bawełniane 5-pak - zdjęcie 8", null, new DateTime(2026, 1, 2, 17, 35, 18, 831, DateTimeKind.Utc).AddTicks(4727), 8, "products/briefs-5pack/image-8.jpg", 1 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "IsPrimary", "ProductId" },
                values: new object[] { 9, "Majtki damskie bawełniane 6-pak - zdjęcie 1", null, new DateTime(2026, 1, 2, 17, 35, 18, 831, DateTimeKind.Utc).AddTicks(4731), 1, "products/briefs-6pack/image-1.jpg", true, 2 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 10, "Majtki damskie bawełniane 6-pak - zdjęcie 2", null, new DateTime(2026, 1, 2, 17, 35, 18, 831, DateTimeKind.Utc).AddTicks(4735), 2, "products/briefs-6pack/image-2.jpg", 2 },
                    { 11, "Majtki damskie bawełniane 6-pak - zdjęcie 3", null, new DateTime(2026, 1, 2, 17, 35, 18, 831, DateTimeKind.Utc).AddTicks(4737), 3, "products/briefs-6pack/image-3.jpg", 2 },
                    { 12, "Majtki damskie bawełniane 6-pak - zdjęcie 4", null, new DateTime(2026, 1, 2, 17, 35, 18, 831, DateTimeKind.Utc).AddTicks(4739), 4, "products/briefs-6pack/image-4.jpg", 2 },
                    { 13, "Majtki damskie bawełniane 6-pak - zdjęcie 5", null, new DateTime(2026, 1, 2, 17, 35, 18, 831, DateTimeKind.Utc).AddTicks(4741), 5, "products/briefs-6pack/image-5.jpg", 2 },
                    { 14, "Majtki damskie bawełniane 6-pak - zdjęcie 6", null, new DateTime(2026, 1, 2, 17, 35, 18, 831, DateTimeKind.Utc).AddTicks(4744), 6, "products/briefs-6pack/image-6.jpg", 2 },
                    { 15, "Majtki damskie bawełniane 6-pak - zdjęcie 7", null, new DateTime(2026, 1, 2, 17, 35, 18, 831, DateTimeKind.Utc).AddTicks(4746), 7, "products/briefs-6pack/image-7.jpg", 2 },
                    { 16, "Majtki damskie bawełniane 6-pak - zdjęcie 8", null, new DateTime(2026, 1, 2, 17, 35, 18, 831, DateTimeKind.Utc).AddTicks(4748), 8, "products/briefs-6pack/image-8.jpg", 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "IsPrimary", "ProductId" },
                values: new object[] { 17, "Majtki damskie bawełniane 8-pak - zdjęcie 1", null, new DateTime(2026, 1, 2, 17, 35, 18, 831, DateTimeKind.Utc).AddTicks(4753), 1, "products/briefs-8pack/image-1.jpg", true, 3 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 18, "Majtki damskie bawełniane 8-pak - zdjęcie 2", null, new DateTime(2026, 1, 2, 17, 35, 18, 831, DateTimeKind.Utc).AddTicks(4757), 2, "products/briefs-8pack/image-2.jpg", 3 },
                    { 19, "Majtki damskie bawełniane 8-pak - zdjęcie 3", null, new DateTime(2026, 1, 2, 17, 35, 18, 831, DateTimeKind.Utc).AddTicks(4760), 3, "products/briefs-8pack/image-3.jpg", 3 },
                    { 20, "Majtki damskie bawełniane 8-pak - zdjęcie 4", null, new DateTime(2026, 1, 2, 17, 35, 18, 831, DateTimeKind.Utc).AddTicks(4762), 4, "products/briefs-8pack/image-4.jpg", 3 },
                    { 21, "Majtki damskie bawełniane 8-pak - zdjęcie 5", null, new DateTime(2026, 1, 2, 17, 35, 18, 831, DateTimeKind.Utc).AddTicks(4765), 5, "products/briefs-8pack/image-5.jpg", 3 },
                    { 22, "Majtki damskie bawełniane 8-pak - zdjęcie 6", null, new DateTime(2026, 1, 2, 17, 35, 18, 831, DateTimeKind.Utc).AddTicks(4767), 6, "products/briefs-8pack/image-6.jpg", 3 },
                    { 23, "Majtki damskie bawełniane 8-pak - zdjęcie 7", null, new DateTime(2026, 1, 2, 17, 35, 18, 831, DateTimeKind.Utc).AddTicks(4770), 7, "products/briefs-8pack/image-7.jpg", 3 },
                    { 24, "Majtki damskie bawełniane 8-pak - zdjęcie 8", null, new DateTime(2026, 1, 2, 17, 35, 18, 831, DateTimeKind.Utc).AddTicks(4772), 8, "products/briefs-8pack/image-8.jpg", 3 }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "Id", "ColorId", "CreatedAt", "IsActive", "Price", "ProductId", "SKU", "SizeId", "StockQuantity", "StripePriceId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 8, new DateTime(2026, 1, 2, 17, 35, 18, 832, DateTimeKind.Utc).AddTicks(4133), true, 49.75m, 1, "BRIEFS-5PK-S2", 2, 100, "", null },
                    { 2, 8, new DateTime(2026, 1, 2, 17, 35, 18, 832, DateTimeKind.Utc).AddTicks(4466), true, 49.75m, 1, "BRIEFS-5PK-S3", 3, 100, "", null },
                    { 3, 8, new DateTime(2026, 1, 2, 17, 35, 18, 832, DateTimeKind.Utc).AddTicks(4468), true, 49.75m, 1, "BRIEFS-5PK-S4", 4, 100, "", null },
                    { 4, 8, new DateTime(2026, 1, 2, 17, 35, 18, 832, DateTimeKind.Utc).AddTicks(4470), true, 49.75m, 1, "BRIEFS-5PK-S5", 5, 100, "", null },
                    { 5, 8, new DateTime(2026, 1, 2, 17, 35, 18, 832, DateTimeKind.Utc).AddTicks(4472), true, 49.75m, 1, "BRIEFS-5PK-S6", 6, 100, "", null },
                    { 6, 8, new DateTime(2026, 1, 2, 17, 35, 18, 832, DateTimeKind.Utc).AddTicks(4495), true, 59.70m, 2, "BRIEFS-6PK-S2", 2, 100, "", null },
                    { 7, 8, new DateTime(2026, 1, 2, 17, 35, 18, 832, DateTimeKind.Utc).AddTicks(4498), true, 59.70m, 2, "BRIEFS-6PK-S3", 3, 100, "", null },
                    { 8, 8, new DateTime(2026, 1, 2, 17, 35, 18, 832, DateTimeKind.Utc).AddTicks(4499), true, 59.70m, 2, "BRIEFS-6PK-S4", 4, 100, "", null },
                    { 9, 8, new DateTime(2026, 1, 2, 17, 35, 18, 832, DateTimeKind.Utc).AddTicks(4501), true, 59.70m, 2, "BRIEFS-6PK-S5", 5, 100, "", null },
                    { 10, 8, new DateTime(2026, 1, 2, 17, 35, 18, 832, DateTimeKind.Utc).AddTicks(4504), true, 59.70m, 2, "BRIEFS-6PK-S6", 6, 100, "", null },
                    { 11, 8, new DateTime(2026, 1, 2, 17, 35, 18, 832, DateTimeKind.Utc).AddTicks(4509), true, 79.60m, 3, "BRIEFS-8PK-S2", 2, 100, "", null },
                    { 12, 8, new DateTime(2026, 1, 2, 17, 35, 18, 832, DateTimeKind.Utc).AddTicks(4511), true, 79.60m, 3, "BRIEFS-8PK-S3", 3, 100, "", null },
                    { 13, 8, new DateTime(2026, 1, 2, 17, 35, 18, 832, DateTimeKind.Utc).AddTicks(4513), true, 79.60m, 3, "BRIEFS-8PK-S4", 4, 100, "", null },
                    { 14, 8, new DateTime(2026, 1, 2, 17, 35, 18, 832, DateTimeKind.Utc).AddTicks(4515), true, 79.60m, 3, "BRIEFS-8PK-S5", 5, 100, "", null },
                    { 15, 8, new DateTime(2026, 1, 2, 17, 35, 18, 832, DateTimeKind.Utc).AddTicks(4517), true, 79.60m, 3, "BRIEFS-8PK-S6", 6, 100, "", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminCommissions_CalculatedAt",
                table: "AdminCommissions",
                column: "CalculatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_AdminCommissions_OrderId",
                table: "AdminCommissions",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminCommissions_OrderItemId",
                table: "AdminCommissions",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminCommissions_ProductId",
                table: "AdminCommissions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminCommissions_Status",
                table: "AdminCommissions",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_AdminCommissions_Status_CalculatedAt",
                table: "AdminCommissions",
                columns: new[] { "Status", "CalculatedAt" });

            migrationBuilder.CreateIndex(
                name: "IX_AdminEarnings_Period",
                table: "AdminEarnings",
                columns: new[] { "PeriodType", "PeriodStart", "PeriodEnd" });

            migrationBuilder.CreateIndex(
                name: "IX_AdminEarnings_PeriodEnd",
                table: "AdminEarnings",
                column: "PeriodEnd");

            migrationBuilder.CreateIndex(
                name: "IX_AdminEarnings_PeriodStart",
                table: "AdminEarnings",
                column: "PeriodStart");

            migrationBuilder.CreateIndex(
                name: "IX_AdminEarnings_PeriodType",
                table: "AdminEarnings",
                column: "PeriodType");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IsActive",
                table: "AspNetUsers",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StripeCustomerId",
                table: "AspNetUsers",
                column: "StripeCustomerId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BlogCategories_Active_Deleted_Order",
                table: "BlogCategories",
                columns: new[] { "IsActive", "IsDeleted", "DisplayOrder" });

            migrationBuilder.CreateIndex(
                name: "IX_BlogCategories_DisplayOrder",
                table: "BlogCategories",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_BlogCategories_IsActive",
                table: "BlogCategories",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_BlogCategories_IsDeleted",
                table: "BlogCategories",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_BlogCategories_Language",
                table: "BlogCategories",
                column: "Language");

            migrationBuilder.CreateIndex(
                name: "IX_BlogCategories_ProductCategoryId",
                table: "BlogCategories",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogCategories_Slug",
                table: "BlogCategories",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_AuthorId",
                table: "Blogs",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CategoryId",
                table: "Blogs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_IsDeleted",
                table: "Blogs",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_IsPublished",
                table: "Blogs",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_ProductId",
                table: "Blogs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_Published_Deleted_Date",
                table: "Blogs",
                columns: new[] { "IsPublished", "IsDeleted", "PublishedDate" });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_PublishedDate",
                table: "Blogs",
                column: "PublishedDate");

            migrationBuilder.CreateIndex(
                name: "IX_BlogTranslations_BlogId_CultureCode",
                table: "BlogTranslations",
                columns: new[] { "BlogId", "CultureCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlogTranslations_Slug_CultureCode",
                table: "BlogTranslations",
                columns: new[] { "Slug", "CultureCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarouselSlides_CategoryId",
                table: "CarouselSlides",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CarouselSlides_DisplayOrder",
                table: "CarouselSlides",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_CarouselSlides_IsActive",
                table: "CarouselSlides",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_CarouselSlides_IsDeleted",
                table: "CarouselSlides",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CarouselSlides_Location",
                table: "CarouselSlides",
                column: "Location");

            migrationBuilder.CreateIndex(
                name: "IX_CarouselSlides_Location_IsActive_DisplayOrder",
                table: "CarouselSlides",
                columns: new[] { "Location", "IsActive", "DisplayOrder" });

            migrationBuilder.CreateIndex(
                name: "IX_CarouselSlides_StartDate_EndDate",
                table: "CarouselSlides",
                columns: new[] { "StartDate", "EndDate" });

            migrationBuilder.CreateIndex(
                name: "IX_CarouselSlideTranslations_SlideId_Culture",
                table: "CarouselSlideTranslations",
                columns: new[] { "CarouselSlideId", "CultureCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ColorId",
                table: "Carts",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ProductId",
                table: "Carts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_SizeId",
                table: "Carts",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Slug",
                table: "Categories",
                column: "Slug",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Colors_Name",
                table: "Colors",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_CommissionSettings_LastModifiedBy",
                table: "CommissionSettings",
                column: "LastModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_CategoryId",
                table: "Coupons",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_Code",
                table: "Coupons",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_IsActive",
                table: "Coupons",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_ProductId",
                table: "Coupons",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_StripeCouponId",
                table: "Coupons",
                column: "StripeCouponId");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_UserId",
                table: "Coupons",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_ValidFrom",
                table: "Coupons",
                column: "ValidFrom");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_ValidUntil",
                table: "Coupons",
                column: "ValidUntil");

            migrationBuilder.CreateIndex(
                name: "IX_CouponUsages_CouponId",
                table: "CouponUsages",
                column: "CouponId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponUsages_OrderId",
                table: "CouponUsages",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponUsages_UsedAt",
                table: "CouponUsages",
                column: "UsedAt");

            migrationBuilder.CreateIndex(
                name: "IX_CouponUsages_UserId",
                table: "CouponUsages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperCommissionRequests_DeveloperId",
                table: "DeveloperCommissionRequests",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperCommissionRequests_ReviewedById",
                table: "DeveloperCommissionRequests",
                column: "ReviewedById");

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
                name: "IX_EmailCommands_CommandType",
                table: "EmailCommands",
                column: "CommandType");

            migrationBuilder.CreateIndex(
                name: "IX_EmailCommands_IsAuthorized",
                table: "EmailCommands",
                column: "IsAuthorized");

            migrationBuilder.CreateIndex(
                name: "IX_EmailCommands_IsExecuted",
                table: "EmailCommands",
                column: "IsExecuted");

            migrationBuilder.CreateIndex(
                name: "IX_EmailCommands_ReceivedAt",
                table: "EmailCommands",
                column: "ReceivedAt");

            migrationBuilder.CreateIndex(
                name: "IX_EmailCommands_SenderEmail",
                table: "EmailCommands",
                column: "SenderEmail");

            migrationBuilder.CreateIndex(
                name: "IX_EmailCommands_Status",
                table: "EmailCommands",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_EmailCommands_Status_Auth_Received",
                table: "EmailCommands",
                columns: new[] { "Status", "IsAuthorized", "ReceivedAt" });

            migrationBuilder.CreateIndex(
                name: "IX_NewsletterSubscriptions_Email",
                table: "NewsletterSubscriptions",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NewsletterSubscriptions_IsActive",
                table: "NewsletterSubscriptions",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_NewsletterSubscriptions_SubscribedAt",
                table: "NewsletterSubscriptions",
                column: "SubscribedAt");

            migrationBuilder.CreateIndex(
                name: "IX_NewsletterSubscriptions_UserId",
                table: "NewsletterSubscriptions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductVariantId",
                table: "OrderItems",
                column: "ProductVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CouponId",
                table: "Orders",
                column: "CouponId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CreatedAt",
                table: "Orders",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerEmail",
                table: "Orders",
                column: "CustomerEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderNumber",
                table: "Orders",
                column: "OrderNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatus",
                table: "Orders",
                column: "OrderStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingCountry",
                table: "Orders",
                column: "ShippingCountry");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StripeCheckoutSessionId",
                table: "Orders",
                column: "StripeCheckoutSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StripePaymentIntentId",
                table: "Orders",
                column: "StripePaymentIntentId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

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
                name: "IX_PaymentMethods_IsActive",
                table: "PaymentMethods",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_IsDeleted",
                table: "PaymentMethods",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_StripePaymentMethodId",
                table: "PaymentMethods",
                column: "StripePaymentMethodId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_User_Default",
                table: "PaymentMethods",
                columns: new[] { "UserId", "IsDefault" });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_UserId",
                table: "PaymentMethods",
                column: "UserId");

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
                name: "IX_ProductColors_ColorId",
                table: "ProductColors",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductColors_ProductId_ColorId",
                table: "ProductColors",
                columns: new[] { "ProductId", "ColorId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ColorId",
                table: "ProductImages",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPriceHistories_ChangedAt",
                table: "ProductPriceHistories",
                column: "ChangedAt");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPriceHistories_ProductId",
                table: "ProductPriceHistories",
                column: "ProductId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductGroupId",
                table: "Products",
                column: "ProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StripePriceId",
                table: "Products",
                column: "StripePriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StripeProductId",
                table: "Products",
                column: "StripeProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizes_ProductId_SizeId",
                table: "ProductSizes",
                columns: new[] { "ProductId", "SizeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizes_SizeId",
                table: "ProductSizes",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTranslations_ProductId",
                table: "ProductTranslations",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ColorId",
                table: "ProductVariants",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ProductId",
                table: "ProductVariants",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_SizeId",
                table: "ProductVariants",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_SKU",
                table: "ProductVariants",
                column: "SKU",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_StripePriceId",
                table: "ProductVariants",
                column: "StripePriceId");

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
                name: "IX_SiteClosures_ClosedAt",
                table: "SiteClosures",
                column: "ClosedAt");

            migrationBuilder.CreateIndex(
                name: "IX_SiteClosures_IsClosed",
                table: "SiteClosures",
                column: "IsClosed");

            migrationBuilder.CreateIndex(
                name: "IX_SiteClosures_IsClosed_ScheduledReopenAt",
                table: "SiteClosures",
                columns: new[] { "IsClosed", "ScheduledReopenAt" });

            migrationBuilder.CreateIndex(
                name: "IX_SiteClosures_ScheduledReopenAt",
                table: "SiteClosures",
                column: "ScheduledReopenAt");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSettings_Category",
                table: "SiteSettings",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSettings_Key",
                table: "SiteSettings",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_Name",
                table: "Sizes",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_SupportedLanguages_CultureCode",
                table: "SupportedLanguages",
                column: "CultureCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupportedLanguages_TwoLetterIsoCode",
                table: "SupportedLanguages",
                column: "TwoLetterIsoCode");

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

            migrationBuilder.CreateIndex(
                name: "IX_WishlistNotifications_CreatedAt",
                table: "WishlistNotifications",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistNotifications_EmailSent",
                table: "WishlistNotifications",
                column: "EmailSent");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistNotifications_IsRead",
                table: "WishlistNotifications",
                column: "IsRead");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistNotifications_WishlistId",
                table: "WishlistNotifications",
                column: "WishlistId");

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
                name: "AdminCommissions");

            migrationBuilder.DropTable(
                name: "AdminEarnings");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BlogTranslations");

            migrationBuilder.DropTable(
                name: "CarouselSlideTranslations");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "CategoryTranslations");

            migrationBuilder.DropTable(
                name: "CommissionSettings");

            migrationBuilder.DropTable(
                name: "CouponUsages");

            migrationBuilder.DropTable(
                name: "DeveloperCommissionRequests");

            migrationBuilder.DropTable(
                name: "DeveloperEarnings");

            migrationBuilder.DropTable(
                name: "EmailCommands");

            migrationBuilder.DropTable(
                name: "NewsletterSubscriptions");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "PaymentTransactions");

            migrationBuilder.DropTable(
                name: "ProductColors");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductPriceHistories");

            migrationBuilder.DropTable(
                name: "ProductReviews");

            migrationBuilder.DropTable(
                name: "ProductSizes");

            migrationBuilder.DropTable(
                name: "ProductTranslations");

            migrationBuilder.DropTable(
                name: "ReturnRequestImages");

            migrationBuilder.DropTable(
                name: "ReturnStatusHistories");

            migrationBuilder.DropTable(
                name: "ShipmentTrackingEvents");

            migrationBuilder.DropTable(
                name: "SiteBlockLogs");

            migrationBuilder.DropTable(
                name: "SiteClosures");

            migrationBuilder.DropTable(
                name: "SiteSettings");

            migrationBuilder.DropTable(
                name: "SupportedLanguages");

            migrationBuilder.DropTable(
                name: "TaxRates");

            migrationBuilder.DropTable(
                name: "WishlistNotifications");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "CarouselSlides");

            migrationBuilder.DropTable(
                name: "ReturnRequests");

            migrationBuilder.DropTable(
                name: "OrderShipments");

            migrationBuilder.DropTable(
                name: "Wishlists");

            migrationBuilder.DropTable(
                name: "BlogCategories");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ShippingRates");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductVariants");

            migrationBuilder.DropTable(
                name: "ShippingProviders");

            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ProductGroups");
        }
    }
}
