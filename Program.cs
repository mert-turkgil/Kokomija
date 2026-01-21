using Kokomija.Data;
using Kokomija.Data.Abstract;
using Kokomija.Data.Concrete;
using Kokomija.Data.Providers;
using Kokomija.Entity;
using Kokomija.Middleware;
using Kokomija.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Stripe;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add HttpContextAccessor for localization service
builder.Services.AddHttpContextAccessor();

// Configure Database with Provider Pattern
var databaseProvider = GetDatabaseProvider(builder.Configuration);
var connectionString = databaseProvider.GetConnectionString(builder.Configuration);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    databaseProvider.ConfigureDbContext(options, connectionString));

// CRITICAL: Configure DataProtection to persist keys
// Without this, OAuth correlation cookies become invalid after app restart
var keysFolder = Path.Combine(builder.Environment.ContentRootPath, "DataProtection-Keys");
builder.Services.AddDataProtection()
    .SetApplicationName("Kokomija")
    .PersistKeysToFileSystem(new DirectoryInfo(keysFolder));

// Configure Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    // Password settings
    options.Password.RequireDigit = builder.Configuration.GetValue<bool>("Identity:Password:RequireDigit");
    options.Password.RequiredLength = builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
    options.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
    options.Password.RequireUppercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
    options.Password.RequireLowercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");

    // Lockout settings
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(builder.Configuration.GetValue<int>("Identity:Lockout:DefaultLockoutTimeSpan"));
    options.Lockout.MaxFailedAccessAttempts = builder.Configuration.GetValue<int>("Identity:Lockout:MaxFailedAccessAttempts");
    options.Lockout.AllowedForNewUsers = builder.Configuration.GetValue<bool>("Identity:Lockout:AllowedForNewUsers");

    // User settings
    options.User.RequireUniqueEmail = true;
    
    // SignIn settings
    options.SignIn.RequireConfirmedEmail = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedEmail", false);
    options.SignIn.RequireConfirmedPhoneNumber = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedPhoneNumber", false);
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// Configure External Authentication Providers (Google, Facebook, Apple)
var authBuilder = builder.Services.AddAuthentication();

// Google Authentication
var googleClientId = builder.Configuration["Authentication:Google:ClientId"];
var googleClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
if (!string.IsNullOrEmpty(googleClientId) && !string.IsNullOrEmpty(googleClientSecret))
{
    authBuilder.AddGoogle(googleOptions =>
    {
        googleOptions.ClientId = googleClientId;
        googleOptions.ClientSecret = googleClientSecret;
        googleOptions.CallbackPath = "/signin-google";
        googleOptions.SaveTokens = true;
        
        // IMPORTANT: Set CorrelationCookie options for production (fixes cookie correlation issues)
        // SameSite.Lax is required for OAuth redirects - None doesn't work reliably
        googleOptions.CorrelationCookie.SecurePolicy = builder.Environment.IsDevelopment() 
            ? CookieSecurePolicy.SameAsRequest 
            : CookieSecurePolicy.Always;
        googleOptions.CorrelationCookie.SameSite = SameSiteMode.Lax; // Must be Lax for OAuth to work
        googleOptions.CorrelationCookie.HttpOnly = true;
        googleOptions.CorrelationCookie.IsEssential = true; // Bypass cookie consent for auth
        
        // Request email, profile and birthday scopes
        googleOptions.Scope.Add("email");
        googleOptions.Scope.Add("profile");
        googleOptions.Scope.Add("https://www.googleapis.com/auth/user.birthday.read");
        
        // Map birthday claim
        googleOptions.ClaimActions.MapJsonKey("urn:google:birthday", "birthday");
        
        // OAuth Events with enhanced error logging
        googleOptions.Events.OnRemoteFailure = context =>
        {
            var logger = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>()
                .CreateLogger("GoogleAuth");
            
            logger.LogError(context.Failure, "Google OAuth remote failure: {Message}. Request path: {Path}",
                context.Failure?.Message ?? "Unknown error",
                context.Request.Path);
            
            // Log correlation cookie info for debugging
            var correlationCookie = context.Request.Cookies
                .FirstOrDefault(c => c.Key.StartsWith(".AspNetCore.Correlation"));
            logger.LogWarning("Correlation cookie present: {Present}, All cookies: {Cookies}", 
                !string.IsNullOrEmpty(correlationCookie.Key),
                string.Join(", ", context.Request.Cookies.Keys));
            
            context.Response.Redirect($"/Account/Login?error={Uri.EscapeDataString(context.Failure?.Message ?? "Authentication failed")}");
            context.HandleResponse();
            return Task.CompletedTask;
        };
        
        // Force account selection even if user is already logged in (for logout support)
        googleOptions.Events.OnRedirectToAuthorizationEndpoint = context =>
        {
            context.Response.Redirect(context.RedirectUri + "&prompt=select_account");
            return Task.CompletedTask;
        };
    });
}

// Facebook Authentication
var facebookAppId = builder.Configuration["Authentication:Facebook:AppId"];
var facebookAppSecret = builder.Configuration["Authentication:Facebook:AppSecret"];
if (!string.IsNullOrEmpty(facebookAppId) && !string.IsNullOrEmpty(facebookAppSecret))
{
    authBuilder.AddFacebook(facebookOptions =>
    {
        facebookOptions.AppId = facebookAppId;
        facebookOptions.AppSecret = facebookAppSecret;
        facebookOptions.CallbackPath = "/signin-facebook";
        facebookOptions.SaveTokens = true;
        
        // Request email, public_profile and birthday permissions
        facebookOptions.Scope.Add("email");
        facebookOptions.Scope.Add("public_profile");
        facebookOptions.Scope.Add("user_birthday");
        
        // Map fields
        facebookOptions.Fields.Add("name");
        facebookOptions.Fields.Add("email");
        facebookOptions.Fields.Add("picture");
        facebookOptions.Fields.Add("birthday");
        
        // Map birthday claim
        facebookOptions.ClaimActions.MapJsonKey(ClaimTypes.DateOfBirth, "birthday");
        
        // Force re-authentication even if user is already logged in (for logout support)
        facebookOptions.Events.OnRedirectToAuthorizationEndpoint = context =>
        {
            context.Response.Redirect(context.RedirectUri + "&auth_type=reauthenticate");
            return Task.CompletedTask;
        };
    });
}

// Apple Authentication (only add if all credentials are present)
var appleClientId = builder.Configuration["Authentication:Apple:ClientId"];
var appleTeamId = builder.Configuration["Authentication:Apple:TeamId"];
var appleKeyId = builder.Configuration["Authentication:Apple:KeyId"];
var applePrivateKey = builder.Configuration["Authentication:Apple:PrivateKey"];

if (!string.IsNullOrEmpty(appleClientId) && !string.IsNullOrEmpty(appleTeamId) && 
    !string.IsNullOrEmpty(appleKeyId) && !string.IsNullOrEmpty(applePrivateKey))
{
    authBuilder.AddApple(appleOptions =>
    {
        appleOptions.ClientId = appleClientId;
        appleOptions.TeamId = appleTeamId;
        appleOptions.KeyId = appleKeyId;
        appleOptions.CallbackPath = "/signin-apple";
        appleOptions.SaveTokens = true;
        appleOptions.GenerateClientSecret = true;
        
        // Configure private key
        appleOptions.PrivateKey = (keyId, cancellationToken) =>
        {
            return Task.FromResult<ReadOnlyMemory<char>>(applePrivateKey.AsMemory());
        };
    });
}

// Configure External Authentication Cookie (required for OAuth state preservation)
builder.Services.ConfigureExternalCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.Name = "Kokomija.External";
    options.Cookie.SecurePolicy = builder.Environment.IsDevelopment() 
        ? CookieSecurePolicy.SameAsRequest 
        : CookieSecurePolicy.Always;
    // IMPORTANT: SameSite.Lax is required for OAuth redirects to work properly
    // SameSite.None causes correlation failures because the cookie isn't sent back
    options.Cookie.SameSite = SameSiteMode.Lax;
    options.Cookie.IsEssential = true; // Always essential for authentication
});

// Configure Cookie settings
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
    options.SlidingExpiration = true;
    options.Cookie.HttpOnly = true;
    options.Cookie.Name = "Kokomija.Auth";
    // Match the request protocol - works with both HTTP and HTTPS transparently
    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    options.Cookie.SameSite = SameSiteMode.Strict;
    options.Cookie.IsEssential = true;
    
    // Handle authentication timeout gracefully
    options.Events.OnRedirectToLogin = context =>
    {
        // Preserve the original URL as return URL
        var returnUrl = context.Request.Path + context.Request.QueryString;
        context.Response.Redirect($"/Account/Login?ReturnUrl={Uri.EscapeDataString(returnUrl)}");
        return Task.CompletedTask;
    };
    
    options.Events.OnRedirectToAccessDenied = context =>
    {
        var returnUrl = context.Request.Path + context.Request.QueryString;
        context.Response.Redirect($"/Account/AccessDenied?ReturnUrl={Uri.EscapeDataString(returnUrl)}");
        return Task.CompletedTask;
    };
});

// Configure Localization
var supportedCultures = builder.Configuration.GetSection("Localization:SupportedCultures").Get<string[]>() 
    ?? new[] { "pl-PL", "en-US" };
var defaultCulture = builder.Configuration.GetValue<string>("Localization:DefaultCulture") ?? "en-US";

builder.Services.AddLocalization();
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(defaultCulture);
    options.SupportedCultures = supportedCultures.Select(c => new System.Globalization.CultureInfo(c)).ToList();
    options.SupportedUICultures = supportedCultures.Select(c => new System.Globalization.CultureInfo(c)).ToList();
    options.FallBackToParentCultures = true;
    options.FallBackToParentUICultures = true;
    
    // Clear default providers and add in order of priority:
    // 1. Query string (?culture=pl-PL)
    // 2. Cookie (user's saved preference)
    // 3. Geo/Language detection (Polish for Poland, English for others)
    options.RequestCultureProviders.Clear();
    options.RequestCultureProviders.Add(new Microsoft.AspNetCore.Localization.QueryStringRequestCultureProvider());
    options.RequestCultureProviders.Add(new Microsoft.AspNetCore.Localization.CookieRequestCultureProvider());
    options.RequestCultureProviders.Add(new Kokomija.Services.GeoLocationCultureProvider());
});

// Register Unit of Work (provides all repositories)
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Configure Stripe
StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];
builder.Services.AddScoped<IStripeService, StripeService>();
builder.Services.AddScoped<IStripeCustomerService, StripeCustomerService>();
builder.Services.AddScoped<IStripeProductSeeder, StripeProductSeeder>();
builder.Services.AddScoped<IStripePayoutService, StripePayoutService>();
builder.Services.AddScoped<IPriceHistoryService, PriceHistoryService>();
builder.Services.AddScoped<IShippingRateSyncService, ShippingRateSyncService>();

// Register Cookie Consent Service
builder.Services.AddScoped<ICookieConsentService, CookieConsentService>();

// Register Email Service (SMTP)
builder.Services.AddScoped<IEmailService, EmailService>();

// Register Return Request Service
builder.Services.AddScoped<IReturnRequestService, ReturnRequestService>();

// Register Shipping Service
builder.Services.AddScoped<IShippingService, ShippingService>();

// Register Carrier API Service
builder.Services.AddScoped<ICarrierApiService, CarrierApiService>();

// Register Tax Service
builder.Services.AddScoped<ITaxService, Kokomija.Services.TaxService>();

// Register Wishlist Notification Service
builder.Services.AddScoped<IWishlistNotificationService, WishlistNotificationService>();

// Register Localized URL Service
builder.Services.AddScoped<ILocalizedUrlService, LocalizedUrlService>();

// Add background services
builder.Services.AddHostedService<Kokomija.BackgroundServices.WishlistNotificationWorker>();
builder.Services.AddHostedService<Kokomija.BackgroundServices.TempFileCleanupWorker>();
builder.Services.AddHostedService<Kokomija.BackgroundServices.EarningsReportWorker>();
builder.Services.AddHostedService<Kokomija.BackgroundServices.AutomaticPayoutWorker>();

// Register Cloudflare Turnstile Service
builder.Services.AddHttpClient(); // Required for TurnstileService
builder.Services.AddScoped<ITurnstileService, TurnstileService>();

// Register Resource Service (Dynamic translations with live reload)
builder.Services.AddSingleton<IResourceService, ResourceService>();

// Register Admin Commission Service
builder.Services.AddScoped<IAdminCommissionService, AdminCommissionService>();

// Register Site Control Service (Emergency closure)
builder.Services.AddScoped<ISiteControlService, SiteControlService>();

// Register Email Command Service (Email-based admin commands)
builder.Services.AddScoped<IEmailCommandService, EmailCommandService>();

// Register Carousel Service (Homepage and category carousels)
builder.Services.AddScoped<ICarouselService, CarouselService>();
builder.Services.AddScoped<ICarouselImageService, CarouselImageService>();

// Register Blog Image Service (Blog image upload and management)
builder.Services.AddScoped<IBlogImageService, BlogImageService>();
builder.Services.AddSingleton<ICKEditorImageTrackingService, CKEditorImageTrackingService>();

// Register Category Image Service (Category image upload and management)
builder.Services.AddScoped<ICategoryImageService, CategoryImageService>();

// Register Product Image Service (Product image upload and management)
builder.Services.AddScoped<IProductImageService, ProductImageService>();

// Register Localization Service (Translation wrapper with logging)
builder.Services.AddScoped<ILocalizationService, LocalizationService>();

// Register Translation Management Service (Live resx editor)
builder.Services.AddScoped<ITranslationManagementService, TranslationManagementService>();

// Add session support (required for cart, emergency access, etc.)
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true; // GDPR: Session cookies are essential
    options.Cookie.Name = "Kokomija.Session";
    // Use HTTPS in production, allow HTTP in development for OAuth testing
    options.Cookie.SecurePolicy = builder.Environment.IsDevelopment() 
        ? CookieSecurePolicy.SameAsRequest 
        : CookieSecurePolicy.Always;
    options.Cookie.SameSite = SameSiteMode.Lax;
});

// Configure Cookie Policy Options (enforce secure cookies)
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.Lax;
    options.CheckConsentNeeded = context => false;
});

var app = builder.Build();

// Seed database with roles and admin user
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();
    
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        
        // Apply pending migrations
        if (context.Database.GetPendingMigrations().Any())
        {
            logger.LogInformation("Applying pending migrations...");
            context.Database.Migrate();
        }
        
        // Seed Identity data (roles and admin user)
        logger.LogInformation("Seeding Identity data...");
        await IdentitySeeder.EnsureDatabaseSeededAsync(services, builder.Configuration);
        logger.LogInformation("Database seeding completed successfully.");
        
        // Seed Stripe configuration (tax, shipping, coupons)
        logger.LogInformation("Seeding Stripe configuration...");
        var stripeSeeder = services.GetRequiredService<IStripeProductSeeder>();
        await stripeSeeder.SeedStripeConfigurationAsync();
        logger.LogInformation("Stripe configuration seeding completed successfully.");
        
        // Seed Stripe products
        logger.LogInformation("Seeding Stripe products...");
        await stripeSeeder.SeedProductsToStripeAsync();
        logger.LogInformation("Stripe product seeding completed successfully.");
        
        // Seed demo financial data (only in development, can be removed via admin panel)
        if (builder.Environment.IsDevelopment())
        {
        }
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while migrating or seeding the database.");
        // Don't throw in production, just log the error
        if (builder.Environment.IsDevelopment())
        {
            throw;
        }
    }
}

// Configure the HTTP request pipeline.

// CRITICAL: ForwardedHeaders must come FIRST in the pipeline
// This is essential for OAuth callbacks behind IIS/reverse proxy
// It allows the app to correctly determine the original scheme (HTTPS) and host
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto | ForwardedHeaders.XForwardedHost,
    // Trust all proxies in production (IIS, load balancers, etc.)
    // For more security, configure KnownProxies/KnownNetworks in production
});

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseHttpsRedirection();
}

// Serve static files (needed for runtime-uploaded images like blog images)
app.UseStaticFiles();

// Enable cookie policy (required for secure cookies in production HTTPS)
app.UseCookiePolicy();

// Add security headers
app.UseSecurityHeaders();

// Add localization support
var localizationOptions = app.Services.GetRequiredService<Microsoft.Extensions.Options.IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(localizationOptions.Value);

// Add localized URL redirection (redirects / to /en/home or /pl/strona-glowna based on culture)
app.UseLocalizedUrls();

// Add session before routing
app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// IMPORTANT: Site Closure Middleware must run AFTER authentication
// so it can check if user is Admin/Root
app.UseMiddleware<SiteClosureCheckMiddleware>();

// Add Site Closure Middleware (Email-based reopening)
app.UseMiddleware<SiteClosureMiddleware>();

app.MapStaticAssets();

// SEO-friendly localized routes for key pages
// Polish routes
app.MapControllerRoute(
    name: "pl-home",
    pattern: "pl/strona-glowna",
    defaults: new { controller = "Home", action = "Index", culture = "pl" });

app.MapControllerRoute(
    name: "pl-login",
    pattern: "pl/logowanie",
    defaults: new { controller = "Account", action = "Login", culture = "pl" });

app.MapControllerRoute(
    name: "pl-register",
    pattern: "pl/rejestracja",
    defaults: new { controller = "Account", action = "Register", culture = "pl" });

app.MapControllerRoute(
    name: "pl-products",
    pattern: "pl/produkty/{id?}",
    defaults: new { controller = "Product", action = "Index", culture = "pl" });

// English routes
app.MapControllerRoute(
    name: "en-home",
    pattern: "en/home",
    defaults: new { controller = "Home", action = "Index", culture = "en" });

app.MapControllerRoute(
    name: "en-login",
    pattern: "en/login",
    defaults: new { controller = "Account", action = "Login", culture = "en" });

app.MapControllerRoute(
    name: "en-register",
    pattern: "en/sign-up",
    defaults: new { controller = "Account", action = "Register", culture = "en" });

app.MapControllerRoute(
    name: "en-products",
    pattern: "en/products/{id?}",
    defaults: new { controller = "Product", action = "Index", culture = "en" });

// Turkish routes
app.MapControllerRoute(
    name: "tr-home",
    pattern: "tr/anasayfa",
    defaults: new { controller = "Home", action = "Index", culture = "tr" });

app.MapControllerRoute(
    name: "tr-login",
    pattern: "tr/giris",
    defaults: new { controller = "Account", action = "Login", culture = "tr" });

app.MapControllerRoute(
    name: "tr-register",
    pattern: "tr/kayit-ol",
    defaults: new { controller = "Account", action = "Register", culture = "tr" });

app.MapControllerRoute(
    name: "tr-products",
    pattern: "tr/urunler/{id?}",
    defaults: new { controller = "Product", action = "Index", culture = "tr" });

// Default route (fallback)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Sync shipping rates with Stripe on startup
using (var scope = app.Services.CreateScope())
{
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    try
    {
        logger.LogInformation("Syncing shipping rates with Stripe on startup...");
        var shippingRateSyncService = scope.ServiceProvider.GetRequiredService<IShippingRateSyncService>();
        await shippingRateSyncService.SyncAllShippingRatesAsync();
        logger.LogInformation("Shipping rates sync completed successfully");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Failed to sync shipping rates with Stripe on startup");
        // Don't fail the app startup if shipping sync fails
    }
}

app.Run();

// Database Provider Factory Method
static IDatabaseProvider GetDatabaseProvider(IConfiguration configuration)
{
    var providerName = configuration.GetValue<string>("Database:Provider") ?? "SqlServer";

    return providerName.ToLowerInvariant() switch
    {
        "sqlserver" => new SqlServerProvider(),
        // Uncomment after installing and enabling the respective provider in DatabaseProviders.cs
        // "postgresql" or "postgres" => new PostgreSqlProvider(),
        // "mysql" => new MySqlProvider(),
        // "sqlite" => new SqliteProvider(),
        _ => throw new NotSupportedException(
            $"Database provider '{providerName}' is not supported or not enabled. " +
            $"Currently enabled: SqlServer. " +
            $"To enable other providers, see Data/Providers/DatabaseProviders.cs")
    };
}
