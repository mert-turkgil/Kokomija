using Kokomija.Data;
using Kokomija.Data.Abstract;
using Kokomija.Data.Concrete;
using Kokomija.Data.Providers;
using Kokomija.Entity;
using Kokomija.Middleware;
using Kokomija.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        
        // Request email and profile scopes
        googleOptions.Scope.Add("email");
        googleOptions.Scope.Add("profile");
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
        
        // Request email and public_profile permissions
        facebookOptions.Scope.Add("email");
        facebookOptions.Scope.Add("public_profile");
        
        // Map fields
        facebookOptions.Fields.Add("name");
        facebookOptions.Fields.Add("email");
        facebookOptions.Fields.Add("picture");
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

// Configure Cookie settings
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
    options.SlidingExpiration = true;
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.SameSite = SameSiteMode.Lax;
    
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
var defaultCulture = builder.Configuration.GetValue<string>("Localization:DefaultCulture") ?? "pl-PL";

builder.Services.AddLocalization();
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(defaultCulture);
    options.SupportedCultures = supportedCultures.Select(c => new System.Globalization.CultureInfo(c)).ToList();
    options.SupportedUICultures = supportedCultures.Select(c => new System.Globalization.CultureInfo(c)).ToList();
    options.FallBackToParentCultures = true;
    options.FallBackToParentUICultures = true;
    
    // Accept language from: Query string, Cookie, Accept-Language header
    options.RequestCultureProviders.Insert(0, new Microsoft.AspNetCore.Localization.QueryStringRequestCultureProvider());
    options.RequestCultureProviders.Insert(1, new Microsoft.AspNetCore.Localization.CookieRequestCultureProvider());
});

// Register Unit of Work (provides all repositories)
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Configure Stripe
StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];
builder.Services.AddScoped<IStripeService, StripeService>();
builder.Services.AddScoped<IStripeCustomerService, StripeCustomerService>();
builder.Services.AddScoped<IStripeProductSeeder, StripeProductSeeder>();
builder.Services.AddScoped<IPriceHistoryService, PriceHistoryService>();

// Register Cookie Consent Service
builder.Services.AddScoped<ICookieConsentService, CookieConsentService>();

// Register Email Service (SMTP)
builder.Services.AddScoped<IEmailService, EmailService>();

// Register Wishlist Notification Service
builder.Services.AddScoped<IWishlistNotificationService, WishlistNotificationService>();

// Add background services
builder.Services.AddHostedService<Kokomija.BackgroundServices.WishlistNotificationWorker>();
builder.Services.AddHostedService<Kokomija.BackgroundServices.TempFileCleanupWorker>();

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

// Register Category Image Service (Category image upload and management)
builder.Services.AddScoped<ICategoryImageService, CategoryImageService>();

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
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.SameSite = SameSiteMode.Lax;
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
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// Add security headers
app.UseSecurityHeaders();

// Add Site Closure Middleware (Emergency maintenance mode)
app.UseMiddleware<SiteClosureMiddleware>();

// Add localization support
var localizationOptions = app.Services.GetRequiredService<Microsoft.Extensions.Options.IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(localizationOptions.Value);

// Add session before routing
app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


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
