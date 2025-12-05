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
                    MetaDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCategories", x => x.Id);
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
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
                    UnsubscribeToken = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
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
                    DeliveredAt = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NameKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
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
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeaturedImage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
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

            migrationBuilder.InsertData(
                table: "BlogCategories",
                columns: new[] { "Id", "CreatedAt", "Description", "DisplayOrder", "IconUrl", "IsActive", "Language", "MetaDescription", "Name", "Slug", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 12, 4, 9, 17, 28, 774, DateTimeKind.Utc).AddTicks(3735), "Porady dotyczące zakupów i stylizacji", 1, null, true, "pl", "Porady zakupowe i stylizacyjne dla klientów Kokomija", "Porady", "porady", new DateTime(2025, 12, 4, 9, 17, 28, 774, DateTimeKind.Utc).AddTicks(4050) },
                    { 2, new DateTime(2025, 12, 4, 9, 17, 28, 774, DateTimeKind.Utc).AddTicks(4361), "Najnowsze produkty i kolekcje", 2, null, true, "pl", "Najnowsze produkty i kolekcje w Kokomija", "Nowości", "nowosci", new DateTime(2025, 12, 4, 9, 17, 28, 774, DateTimeKind.Utc).AddTicks(4362) },
                    { 3, new DateTime(2025, 12, 4, 9, 17, 28, 774, DateTimeKind.Utc).AddTicks(4364), "Najnowsze trendy w modzie", 3, null, true, "pl", "Najnowsze trendy w modzie i stylizacji", "Trendy", "trendy", new DateTime(2025, 12, 4, 9, 17, 28, 774, DateTimeKind.Utc).AddTicks(4365) },
                    { 4, new DateTime(2025, 12, 4, 9, 17, 28, 774, DateTimeKind.Utc).AddTicks(4368), "Inspiracje stylizacyjne i lookbooki", 4, null, true, "pl", "Inspiracje stylizacyjne i lookbooki od Kokomija", "Inspiracje", "inspiracje", new DateTime(2025, 12, 4, 9, 17, 28, 774, DateTimeKind.Utc).AddTicks(4368) },
                    { 5, new DateTime(2025, 12, 4, 9, 17, 28, 774, DateTimeKind.Utc).AddTicks(4371), "Informacje o marce Kokomija", 5, null, true, "pl", "Informacje o marce Kokomija i naszej misji", "O marce", "o-marce", new DateTime(2025, 12, 4, 9, 17, 28, 774, DateTimeKind.Utc).AddTicks(4372) }
                });

            migrationBuilder.InsertData(
                table: "CarouselSlides",
                columns: new[] { "Id", "AnimationType", "BackgroundColor", "ButtonClass", "ButtonText", "CategoryId", "CreatedAt", "CreatedBy", "CustomCssClass", "DeletedAt", "DeletedBy", "DisplayOrder", "Duration", "EndDate", "ImageAlt", "ImagePath", "IsActive", "LinkUrl", "Location", "MobileImagePath", "RouteName", "RouteParameters", "StartDate", "Subtitle", "TabletImagePath", "TextAlign", "TextColor", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, "fade", null, "btn-primary", "Carousel_ShopNow", null, new DateTime(2025, 12, 4, 9, 17, 28, 781, DateTimeKind.Utc).AddTicks(5484), null, null, null, null, 1, 5000, null, "New Spring 2025 Collection", "/img/Carousel/1.jpg", true, null, "Home", "/img/Carousel/3.jpg", null, null, new DateTime(2025, 12, 4, 9, 17, 28, 781, DateTimeKind.Utc).AddTicks(5144), "Carousel_NewCollection_Subtitle", "/img/Carousel/2.jpg", "center", null, "Carousel_NewCollection", null, null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "DisplayOrder", "IconCssClass", "ImageUrl", "IsActive", "Name", "NameKey", "ParentCategoryId", "ShowInNavbar", "Slug", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 12, 4, 9, 17, 28, 772, DateTimeKind.Utc).AddTicks(9367), null, "Odzież damska", 1, "fas fa-female", "categories/women.jpg", true, "Damskie", "Category_Women", null, true, "damskie", null, null },
                    { 2, new DateTime(2025, 12, 4, 9, 17, 28, 772, DateTimeKind.Utc).AddTicks(9695), null, "Odzież męska", 2, "fas fa-male", "categories/men.jpg", true, "Męskie", "Category_Men", null, true, "meskie", null, null },
                    { 3, new DateTime(2025, 12, 4, 9, 17, 28, 772, DateTimeKind.Utc).AddTicks(9698), null, "Kurtki i płaszcze", 3, "fas fa-wind", "categories/outerwear.jpg", true, "Odzież Wierzchnia", "Category_Outerwear", null, true, "odziez-wierzchnia", null, null },
                    { 4, new DateTime(2025, 12, 4, 9, 17, 28, 772, DateTimeKind.Utc).AddTicks(9701), null, "Dodatki i akcesoria", 4, "fas fa-shopping-bag", "categories/accessories.jpg", true, "Akcesoria", "Category_Accessories", null, true, "akcesoria", null, null }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "CreatedAt", "DisplayName", "DisplayOrder", "HexCode", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 12, 4, 9, 17, 28, 771, DateTimeKind.Utc).AddTicks(4742), "Black", 1, "#000000", true, "Black" },
                    { 2, new DateTime(2025, 12, 4, 9, 17, 28, 771, DateTimeKind.Utc).AddTicks(5078), "White", 2, "#FFFFFF", true, "White" },
                    { 3, new DateTime(2025, 12, 4, 9, 17, 28, 771, DateTimeKind.Utc).AddTicks(5080), "Red", 3, "#FF0000", true, "Red" },
                    { 4, new DateTime(2025, 12, 4, 9, 17, 28, 771, DateTimeKind.Utc).AddTicks(5082), "Blue", 4, "#0000FF", true, "Blue" },
                    { 5, new DateTime(2025, 12, 4, 9, 17, 28, 771, DateTimeKind.Utc).AddTicks(5085), "Green", 5, "#00FF00", true, "Green" },
                    { 6, new DateTime(2025, 12, 4, 9, 17, 28, 771, DateTimeKind.Utc).AddTicks(5087), "Yellow", 6, "#FFFF00", true, "Yellow" },
                    { 7, new DateTime(2025, 12, 4, 9, 17, 28, 771, DateTimeKind.Utc).AddTicks(5090), "Navy Blue", 7, "#000080", true, "Navy" },
                    { 8, new DateTime(2025, 12, 4, 9, 17, 28, 771, DateTimeKind.Utc).AddTicks(5092), "Gray", 8, "#808080", true, "Gray" }
                });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "Code", "CreatedAt", "Description", "DiscountType", "DiscountValue", "IsActive", "MaximumDiscountAmount", "MinimumOrderAmount", "StripeCouponId", "StripePromotionCodeId", "UpdatedAt", "UsageLimit", "UsageLimitPerUser", "ValidFrom", "ValidUntil" },
                values: new object[] { 1, "WELCOME10", new DateTime(2025, 12, 4, 9, 17, 28, 777, DateTimeKind.Utc).AddTicks(319), "10% off your first order", "percentage", 10.00m, true, 50.00m, 50.00m, "", "", null, 1000, 1, new DateTime(2025, 12, 4, 9, 17, 28, 776, DateTimeKind.Utc).AddTicks(8367), new DateTime(2026, 6, 4, 9, 17, 28, 776, DateTimeKind.Utc).AddTicks(8847) });

            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "Id", "CreatedAt", "Description", "DescriptionKey", "Name", "NameKey", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 12, 4, 9, 17, 28, 777, DateTimeKind.Utc).AddTicks(4584), "High-quality women's cotton briefs in various pack sizes", "ProductGroup_WomenBriefs_Description", "Women's Cotton Briefs Pack Collection", "ProductGroup_WomenBriefs_Name", null });

            migrationBuilder.InsertData(
                table: "SiteSettings",
                columns: new[] { "Id", "Category", "DataType", "Description", "Key", "UpdatedAt", "UpdatedBy", "Value" },
                values: new object[,]
                {
                    { 1, "Security", "string", "Super admin email for site control and emergency commands", "SuperAdminEmail", new DateTime(2025, 12, 4, 9, 17, 28, 775, DateTimeKind.Utc).AddTicks(4712), null, "admin@kokomija.com" },
                    { 2, "Commission", "decimal", "Platform commission rate per product sale (decimal, e.g., 0.01 = 1%)", "PlatformCommissionRate", new DateTime(2025, 12, 4, 9, 17, 28, 775, DateTimeKind.Utc).AddTicks(5723), null, "0.01" },
                    { 3, "Commission", "decimal", "Stripe processing fee rate (decimal, e.g., 0.014 = 1.4%)", "StripeProcessingFeeRate", new DateTime(2025, 12, 4, 9, 17, 28, 775, DateTimeKind.Utc).AddTicks(5725), null, "0.014" },
                    { 4, "Commission", "decimal", "Stripe fixed fee per transaction in PLN", "StripeFixedFee", new DateTime(2025, 12, 4, 9, 17, 28, 775, DateTimeKind.Utc).AddTicks(5727), null, "1.00" },
                    { 5, "Maintenance", "boolean", "Is site currently closed for maintenance", "SiteClosureEnabled", new DateTime(2025, 12, 4, 9, 17, 28, 775, DateTimeKind.Utc).AddTicks(5729), null, "false" },
                    { 6, "Maintenance", "string", "Message displayed when site is closed", "SiteClosureMessage", new DateTime(2025, 12, 4, 9, 17, 28, 775, DateTimeKind.Utc).AddTicks(5731), null, "Przepraszamy, serwis jest tymczasowo niedostępny z powodu konserwacji." },
                    { 7, "Maintenance", "integer", "Automatically reopen site after X days of closure", "AutoReopenAfterDays", new DateTime(2025, 12, 4, 9, 17, 28, 775, DateTimeKind.Utc).AddTicks(5732), null, "30" },
                    { 8, "Maintenance", "boolean", "Send daily confirmation emails during site closure", "DailyConfirmationEmailEnabled", new DateTime(2025, 12, 4, 9, 17, 28, 775, DateTimeKind.Utc).AddTicks(5734), null, "true" },
                    { 9, "Tax", "decimal", "Tax rate (VAT) applied to orders (decimal, e.g., 0.23 = 23%)", "TaxRate", new DateTime(2025, 12, 4, 9, 17, 28, 775, DateTimeKind.Utc).AddTicks(5736), null, "0.23" },
                    { 10, "Shipping", "decimal", "Standard shipping cost in PLN", "ShippingRate", new DateTime(2025, 12, 4, 9, 17, 28, 775, DateTimeKind.Utc).AddTicks(5738), null, "15.00" },
                    { 11, "Shipping", "decimal", "Minimum order value for free shipping in PLN", "FreeShippingThreshold", new DateTime(2025, 12, 4, 9, 17, 28, 775, DateTimeKind.Utc).AddTicks(5740), null, "200.00" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "CreatedAt", "DisplayName", "DisplayOrder", "IsActive", "Name", "Region" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 12, 4, 9, 17, 28, 769, DateTimeKind.Utc).AddTicks(3341), "Extra Small", 1, true, "XS", null },
                    { 2, new DateTime(2025, 12, 4, 9, 17, 28, 769, DateTimeKind.Utc).AddTicks(3682), "Small", 2, true, "S", null },
                    { 3, new DateTime(2025, 12, 4, 9, 17, 28, 769, DateTimeKind.Utc).AddTicks(3684), "Medium", 3, true, "M", null },
                    { 4, new DateTime(2025, 12, 4, 9, 17, 28, 769, DateTimeKind.Utc).AddTicks(3686), "Large", 4, true, "L", null },
                    { 5, new DateTime(2025, 12, 4, 9, 17, 28, 769, DateTimeKind.Utc).AddTicks(3689), "Extra Large", 5, true, "XL", null },
                    { 6, new DateTime(2025, 12, 4, 9, 17, 28, 769, DateTimeKind.Utc).AddTicks(3691), "2X Large", 6, true, "XXL", null }
                });

            migrationBuilder.InsertData(
                table: "SupportedLanguages",
                columns: new[] { "Id", "CreatedAt", "CultureCode", "DisplayName", "DisplayOrder", "FlagIcon", "IsDefault", "IsEnabled", "NativeName", "TwoLetterIsoCode" },
                values: new object[] { 1, new DateTime(2025, 12, 4, 9, 17, 28, 773, DateTimeKind.Utc).AddTicks(5939), "pl-PL", "Polski", 1, "🇵🇱", true, true, "Polski", "pl" });

            migrationBuilder.InsertData(
                table: "SupportedLanguages",
                columns: new[] { "Id", "CreatedAt", "CultureCode", "DisplayName", "DisplayOrder", "FlagIcon", "NativeName", "TwoLetterIsoCode" },
                values: new object[] { 2, new DateTime(2025, 12, 4, 9, 17, 28, 773, DateTimeKind.Utc).AddTicks(6324), "en-US", "English", 2, "🇺🇸", "English", "en" });

            migrationBuilder.InsertData(
                table: "CarouselSlideTranslations",
                columns: new[] { "Id", "ActionName", "AreaName", "ButtonText", "CarouselSlideId", "ControllerName", "CreatedAt", "CultureCode", "ImageAlt", "LinkUrl", "RouteParameters", "Subtitle", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Index", null, "Shop Now", 1, "Product", new DateTime(2025, 12, 4, 9, 17, 28, 782, DateTimeKind.Utc).AddTicks(2311), "en-US", "Kokomija Spring 2025 Fashion Collection - Premium Women's and Men's Underwear", null, null, "Discover the latest trends in women's and men's fashion", "New Spring 2025 Collection", null },
                    { 2, "Index", null, "Kup Teraz", 1, "Product", new DateTime(2025, 12, 4, 9, 17, 28, 782, DateTimeKind.Utc).AddTicks(2611), "pl-PL", "Kokomija Kolekcja Wiosna 2025 - Wysokiej Jakości Bielizna Damska i Męska", null, null, "Odkryj najnowsze trendy w modzie damskiej i męskiej", "Nowa Kolekcja Wiosna 2025", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "DisplayOrder", "IconCssClass", "ImageUrl", "IsActive", "Name", "NameKey", "ParentCategoryId", "ShowInNavbar", "Slug", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 5, new DateTime(2025, 12, 4, 9, 17, 28, 773, DateTimeKind.Utc).AddTicks(30), null, "Eleganckie sukienki damskie", 1, "fas fa-tshirt", null, true, "Sukienki", "Category_Dresses", 1, true, "damskie-sukienki", null, null },
                    { 6, new DateTime(2025, 12, 4, 9, 17, 28, 773, DateTimeKind.Utc).AddTicks(36), null, "Modne spódnice", 2, "fas fa-tshirt", null, true, "Spódnice", "Category_Skirts", 1, true, "damskie-spodnice", null, null },
                    { 7, new DateTime(2025, 12, 4, 9, 17, 28, 773, DateTimeKind.Utc).AddTicks(108), null, "Eleganckie bluzki damskie", 3, "fas fa-tshirt", null, true, "Bluzki", "Category_Blouses", 1, true, "damskie-bluzki", null, null },
                    { 8, new DateTime(2025, 12, 4, 9, 17, 28, 773, DateTimeKind.Utc).AddTicks(112), null, "Spodnie damskie", 4, "fas fa-tshirt", null, true, "Spodnie", "Category_WomenPants", 1, true, "damskie-spodnie", null, null },
                    { 9, new DateTime(2025, 12, 4, 9, 17, 28, 773, DateTimeKind.Utc).AddTicks(115), null, "Eleganckie koszule męskie", 1, "fas fa-tshirt", null, true, "Koszule", "Category_Shirts", 2, true, "meskie-koszule", null, null },
                    { 10, new DateTime(2025, 12, 4, 9, 17, 28, 773, DateTimeKind.Utc).AddTicks(119), null, "Spodnie męskie", 2, "fas fa-tshirt", null, true, "Spodnie", "Category_MenPants", 2, true, "meskie-spodnie", null, null },
                    { 11, new DateTime(2025, 12, 4, 9, 17, 28, 773, DateTimeKind.Utc).AddTicks(122), null, "Koszulki męskie", 3, "fas fa-tshirt", null, true, "T-Shirty", "Category_TShirts", 2, true, "meskie-tshirty", null, null },
                    { 12, new DateTime(2025, 12, 4, 9, 17, 28, 773, DateTimeKind.Utc).AddTicks(125), null, "Bluzy męskie", 4, "fas fa-tshirt", null, true, "Bluzy", "Category_Sweatshirts", 2, true, "meskie-bluzy", null, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "DescriptionKey", "IsActive", "Name", "NameKey", "PackSize", "Price", "ProductGroupId", "StripePriceId", "StripeProductId", "StripeTaxCode", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 12, 4, 9, 17, 28, 778, DateTimeKind.Utc).AddTicks(4651), "Wysokiej jakości majtki damskie bawełniane w zestawie 5 sztuk. Wygodne, przewiewne i trwałe. Idealny wybór na co dzień. Dostępne w różnych kolorach i rozmiarach.", "Product_WomenBriefs5Pack_Description", true, "Majtki damskie bawełniane wysokie - 5 pak", "Product_WomenBriefs5Pack_Name", 5, 49.75m, 1, "", "", "txcd_30011000", null },
                    { 2, 1, new DateTime(2025, 12, 4, 9, 17, 28, 778, DateTimeKind.Utc).AddTicks(4955), "Wysokiej jakości majtki damskie bawełniane w zestawie 6 sztuk. Wygodne, przewiewne i trwałe. Idealny wybór na co dzień. Dostępne w różnych kolorach i rozmiarach.", "Product_WomenBriefs6Pack_Description", true, "Majtki damskie bawełniane wysokie - 6 pak", "Product_WomenBriefs6Pack_Name", 6, 59.70m, 1, "", "", "txcd_30011000", null },
                    { 3, 1, new DateTime(2025, 12, 4, 9, 17, 28, 778, DateTimeKind.Utc).AddTicks(4959), "Wysokiej jakości majtki damskie bawełniane w zestawie 8 sztuk. Wygodne, przewiewne i trwałe. Najlepszy wybór wartościowy! Dostępne w różnych kolorach i rozmiarach.", "Product_WomenBriefs8Pack_Description", true, "Majtki damskie bawełniane wysokie - 8 pak", "Product_WomenBriefs8Pack_Name", 8, 79.60m, 1, "", "", "txcd_30011000", null }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "IsPrimary", "ProductId" },
                values: new object[] { 1, "Majtki damskie bawełniane 5-pak - zdjęcie 1", null, new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1345), 1, "products/briefs-5pack/image-1.jpg", true, 1 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 2, "Majtki damskie bawełniane 5-pak - zdjęcie 2", null, new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1670), 2, "products/briefs-5pack/image-2.jpg", 1 },
                    { 3, "Majtki damskie bawełniane 5-pak - zdjęcie 3", null, new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1673), 3, "products/briefs-5pack/image-3.jpg", 1 },
                    { 4, "Majtki damskie bawełniane 5-pak - zdjęcie 4", null, new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1747), 4, "products/briefs-5pack/image-4.jpg", 1 },
                    { 5, "Majtki damskie bawełniane 5-pak - zdjęcie 5", null, new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1749), 5, "products/briefs-5pack/image-5.jpg", 1 },
                    { 6, "Majtki damskie bawełniane 5-pak - zdjęcie 6", null, new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1759), 6, "products/briefs-5pack/image-6.jpg", 1 },
                    { 7, "Majtki damskie bawełniane 5-pak - zdjęcie 7", null, new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1761), 7, "products/briefs-5pack/image-7.jpg", 1 },
                    { 8, "Majtki damskie bawełniane 5-pak - zdjęcie 8", null, new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1764), 8, "products/briefs-5pack/image-8.jpg", 1 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "IsPrimary", "ProductId" },
                values: new object[] { 9, "Majtki damskie bawełniane 6-pak - zdjęcie 1", null, new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1768), 1, "products/briefs-6pack/image-1.jpg", true, 2 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 10, "Majtki damskie bawełniane 6-pak - zdjęcie 2", null, new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1772), 2, "products/briefs-6pack/image-2.jpg", 2 },
                    { 11, "Majtki damskie bawełniane 6-pak - zdjęcie 3", null, new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1774), 3, "products/briefs-6pack/image-3.jpg", 2 },
                    { 12, "Majtki damskie bawełniane 6-pak - zdjęcie 4", null, new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1777), 4, "products/briefs-6pack/image-4.jpg", 2 },
                    { 13, "Majtki damskie bawełniane 6-pak - zdjęcie 5", null, new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1779), 5, "products/briefs-6pack/image-5.jpg", 2 },
                    { 14, "Majtki damskie bawełniane 6-pak - zdjęcie 6", null, new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1781), 6, "products/briefs-6pack/image-6.jpg", 2 },
                    { 15, "Majtki damskie bawełniane 6-pak - zdjęcie 7", null, new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1784), 7, "products/briefs-6pack/image-7.jpg", 2 },
                    { 16, "Majtki damskie bawełniane 6-pak - zdjęcie 8", null, new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1786), 8, "products/briefs-6pack/image-8.jpg", 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "IsPrimary", "ProductId" },
                values: new object[] { 17, "Majtki damskie bawełniane 8-pak - zdjęcie 1", null, new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1791), 1, "products/briefs-8pack/image-1.jpg", true, 3 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "AltText", "ColorId", "CreatedAt", "DisplayOrder", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 18, "Majtki damskie bawełniane 8-pak - zdjęcie 2", null, new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1795), 2, "products/briefs-8pack/image-2.jpg", 3 },
                    { 19, "Majtki damskie bawełniane 8-pak - zdjęcie 3", null, new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1798), 3, "products/briefs-8pack/image-3.jpg", 3 },
                    { 20, "Majtki damskie bawełniane 8-pak - zdjęcie 4", null, new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1801), 4, "products/briefs-8pack/image-4.jpg", 3 },
                    { 21, "Majtki damskie bawełniane 8-pak - zdjęcie 5", null, new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1803), 5, "products/briefs-8pack/image-5.jpg", 3 },
                    { 22, "Majtki damskie bawełniane 8-pak - zdjęcie 6", null, new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1806), 6, "products/briefs-8pack/image-6.jpg", 3 },
                    { 23, "Majtki damskie bawełniane 8-pak - zdjęcie 7", null, new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1808), 7, "products/briefs-8pack/image-7.jpg", 3 },
                    { 24, "Majtki damskie bawełniane 8-pak - zdjęcie 8", null, new DateTime(2025, 12, 4, 9, 17, 28, 779, DateTimeKind.Utc).AddTicks(1810), 8, "products/briefs-8pack/image-8.jpg", 3 }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "Id", "ColorId", "CreatedAt", "IsActive", "Price", "ProductId", "SKU", "SizeId", "StockQuantity", "StripePriceId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 8, new DateTime(2025, 12, 4, 9, 17, 28, 780, DateTimeKind.Utc).AddTicks(6155), true, 49.75m, 1, "BRIEFS-5PK-S2", 2, 100, "", null },
                    { 2, 8, new DateTime(2025, 12, 4, 9, 17, 28, 780, DateTimeKind.Utc).AddTicks(6697), true, 49.75m, 1, "BRIEFS-5PK-S3", 3, 100, "", null },
                    { 3, 8, new DateTime(2025, 12, 4, 9, 17, 28, 780, DateTimeKind.Utc).AddTicks(6701), true, 49.75m, 1, "BRIEFS-5PK-S4", 4, 100, "", null },
                    { 4, 8, new DateTime(2025, 12, 4, 9, 17, 28, 780, DateTimeKind.Utc).AddTicks(6704), true, 49.75m, 1, "BRIEFS-5PK-S5", 5, 100, "", null },
                    { 5, 8, new DateTime(2025, 12, 4, 9, 17, 28, 780, DateTimeKind.Utc).AddTicks(6843), true, 49.75m, 1, "BRIEFS-5PK-S6", 6, 100, "", null },
                    { 6, 8, new DateTime(2025, 12, 4, 9, 17, 28, 780, DateTimeKind.Utc).AddTicks(6865), true, 59.70m, 2, "BRIEFS-6PK-S2", 2, 100, "", null },
                    { 7, 8, new DateTime(2025, 12, 4, 9, 17, 28, 780, DateTimeKind.Utc).AddTicks(6868), true, 59.70m, 2, "BRIEFS-6PK-S3", 3, 100, "", null },
                    { 8, 8, new DateTime(2025, 12, 4, 9, 17, 28, 780, DateTimeKind.Utc).AddTicks(6871), true, 59.70m, 2, "BRIEFS-6PK-S4", 4, 100, "", null },
                    { 9, 8, new DateTime(2025, 12, 4, 9, 17, 28, 780, DateTimeKind.Utc).AddTicks(6873), true, 59.70m, 2, "BRIEFS-6PK-S5", 5, 100, "", null },
                    { 10, 8, new DateTime(2025, 12, 4, 9, 17, 28, 780, DateTimeKind.Utc).AddTicks(6877), true, 59.70m, 2, "BRIEFS-6PK-S6", 6, 100, "", null },
                    { 11, 8, new DateTime(2025, 12, 4, 9, 17, 28, 780, DateTimeKind.Utc).AddTicks(6882), true, 79.60m, 3, "BRIEFS-8PK-S2", 2, 100, "", null },
                    { 12, 8, new DateTime(2025, 12, 4, 9, 17, 28, 780, DateTimeKind.Utc).AddTicks(6885), true, 79.60m, 3, "BRIEFS-8PK-S3", 3, 100, "", null },
                    { 13, 8, new DateTime(2025, 12, 4, 9, 17, 28, 780, DateTimeKind.Utc).AddTicks(6888), true, 79.60m, 3, "BRIEFS-8PK-S4", 4, 100, "", null },
                    { 14, 8, new DateTime(2025, 12, 4, 9, 17, 28, 780, DateTimeKind.Utc).AddTicks(6890), true, 79.60m, 3, "BRIEFS-8PK-S5", 5, 100, "", null },
                    { 15, 8, new DateTime(2025, 12, 4, 9, 17, 28, 780, DateTimeKind.Utc).AddTicks(6893), true, 79.60m, 3, "BRIEFS-8PK-S6", 6, 100, "", null }
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
                name: "IX_Coupons_Code",
                table: "Coupons",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_IsActive",
                table: "Coupons",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_StripeCouponId",
                table: "Coupons",
                column: "StripeCouponId");

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
                name: "CouponUsages");

            migrationBuilder.DropTable(
                name: "EmailCommands");

            migrationBuilder.DropTable(
                name: "NewsletterSubscriptions");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

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
                name: "SiteClosures");

            migrationBuilder.DropTable(
                name: "SiteSettings");

            migrationBuilder.DropTable(
                name: "SupportedLanguages");

            migrationBuilder.DropTable(
                name: "WishlistNotifications");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "CarouselSlides");

            migrationBuilder.DropTable(
                name: "Wishlists");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductVariants");

            migrationBuilder.DropTable(
                name: "BlogCategories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ProductGroups");
        }
    }
}
