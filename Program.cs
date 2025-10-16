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
});

// Configure Localization
var supportedCultures = builder.Configuration.GetSection("Localization:SupportedCultures").Get<string[]>() 
    ?? new[] { "pl-PL", "en-US" };
var defaultCulture = builder.Configuration.GetValue<string>("Localization:DefaultCulture") ?? "pl-PL";

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
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

// Register Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Configure Stripe
StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];
builder.Services.AddScoped<IStripeService, StripeService>();

// Register Cookie Consent Service
builder.Services.AddScoped<ICookieConsentService, CookieConsentService>();

// Register Email Service (SMTP)
builder.Services.AddScoped<IEmailService, EmailService>();

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
