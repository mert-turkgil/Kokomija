using Microsoft.AspNetCore.Localization;

namespace Kokomija.Middleware;

/// <summary>
/// Middleware that redirects users to localized URLs on first visit
/// and ensures culture consistency across page navigation
/// </summary>
public class LocalizedUrlMiddleware
{
    private readonly RequestDelegate _next;
    
    // Pages that have localized routes
    private static readonly Dictionary<string, Dictionary<string, string>> LocalizedRoutes = new()
    {
        { "/", new Dictionary<string, string> 
            { 
                { "pl", "/pl/strona-glowna" }, 
                { "en", "/en/home" }, 
                { "tr", "/tr/anasayfa" } 
            } 
        },
        { "/home", new Dictionary<string, string> 
            { 
                { "pl", "/pl/strona-glowna" }, 
                { "en", "/en/home" }, 
                { "tr", "/tr/anasayfa" } 
            } 
        },
        { "/home/index", new Dictionary<string, string> 
            { 
                { "pl", "/pl/strona-glowna" }, 
                { "en", "/en/home" }, 
                { "tr", "/tr/anasayfa" } 
            } 
        },
        { "/account/login", new Dictionary<string, string> 
            { 
                { "pl", "/pl/logowanie" }, 
                { "en", "/en/login" }, 
                { "tr", "/tr/giris" } 
            } 
        },
        { "/account/register", new Dictionary<string, string> 
            { 
                { "pl", "/pl/rejestracja" }, 
                { "en", "/en/sign-up" }, 
                { "tr", "/tr/kayit-ol" } 
            } 
        },
        { "/product/index", new Dictionary<string, string> 
            { 
                { "pl", "/pl/produkty" }, 
                { "en", "/en/products" }, 
                { "tr", "/tr/urunler" } 
            } 
        },
        { "/product", new Dictionary<string, string> 
            { 
                { "pl", "/pl/produkty" }, 
                { "en", "/en/products" }, 
                { "tr", "/tr/urunler" } 
            } 
        }
    };

    public LocalizedUrlMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var path = context.Request.Path.Value?.ToLowerInvariant() ?? "/";
        var method = context.Request.Method;
        
        // Check if URL has a culture prefix and set the culture accordingly
        var urlCulture = GetCultureFromUrl(path);
        if (urlCulture != null)
        {
            // Set culture based on URL prefix
            SetCultureFromUrl(context, urlCulture);
            await _next(context);
            return;
        }
        
        // Skip for non-GET requests, static files, API calls
        if (method != "GET" || ShouldSkip(path))
        {
            await _next(context);
            return;
        }
        
        // Get the current culture
        var culture = GetCurrentCulture(context);
        
        // Set culture cookie if not already set (remembers the auto-detected language)
        EnsureCultureCookie(context, culture);
        
        // Check if we need to redirect to a localized URL
        var localizedUrl = GetLocalizedUrl(path, culture);
        
        if (localizedUrl != null && !path.Equals(localizedUrl, StringComparison.OrdinalIgnoreCase))
        {
            // Preserve query string
            var queryString = context.Request.QueryString.Value;
            var redirectUrl = localizedUrl + queryString;
            
            context.Response.Redirect(redirectUrl, permanent: false);
            return;
        }
        
        await _next(context);
    }
    
    private string? GetCultureFromUrl(string path)
    {
        if (path.StartsWith("/pl/")) return "pl";
        if (path.StartsWith("/en/")) return "en";
        if (path.StartsWith("/tr/")) return "tr";
        return null;
    }
    
    private void SetCultureFromUrl(HttpContext context, string culture)
    {
        var fullCulture = culture switch
        {
            "pl" => "pl-PL",
            "tr" => "tr-TR",
            _ => "en-US"
        };
        
        // Set the culture for the current request
        var cultureInfo = new System.Globalization.CultureInfo(fullCulture);
        System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
        System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;
        
        // Update the cookie to remember this choice
        context.Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(fullCulture)),
            new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1),
                IsEssential = true,
                Path = "/",
                SameSite = SameSiteMode.Lax
            }
        );
    }
    
    private void EnsureCultureCookie(HttpContext context, string culture)
    {
        var existingCookie = context.Request.Cookies[CookieRequestCultureProvider.DefaultCookieName];
        if (string.IsNullOrEmpty(existingCookie))
        {
            // Set the culture cookie so the choice is remembered
            var fullCulture = culture switch
            {
                "pl" => "pl-PL",
                "tr" => "tr-TR",
                _ => "en-US"
            };
            
            context.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(fullCulture)),
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1),
                    IsEssential = true,
                    Path = "/",
                    SameSite = SameSiteMode.Lax
                }
            );
        }
    }
    
    private bool ShouldSkip(string path)
    {
        // Skip static files
        if (path.StartsWith("/css") || path.StartsWith("/js") || path.StartsWith("/lib") ||
            path.StartsWith("/img") || path.StartsWith("/images") || path.StartsWith("/fonts") ||
            path.StartsWith("/_") || path.StartsWith("/favicon") || path.StartsWith("/robots") ||
            path.StartsWith("/sitemap") || path.Contains("."))
        {
            return true;
        }
        
        // Skip API endpoints
        if (path.StartsWith("/api"))
        {
            return true;
        }
        
        // Skip signin callbacks and external login callbacks
        if (path.StartsWith("/signin-") || path.StartsWith("/account/externallogi"))
        {
            return true;
        }
        
        // Skip already localized URLs
        if (path.StartsWith("/pl/") || path.StartsWith("/en/") || path.StartsWith("/tr/"))
        {
            return true;
        }
        
        return false;
    }
    
    private string GetCurrentCulture(HttpContext context)
    {
        // First check cookie
        var cultureCookie = context.Request.Cookies[CookieRequestCultureProvider.DefaultCookieName];
        if (!string.IsNullOrEmpty(cultureCookie))
        {
            var parsed = CookieRequestCultureProvider.ParseCookieValue(cultureCookie);
            if (parsed != null)
            {
                return parsed.Cultures.FirstOrDefault().Value?.Split('-')[0] ?? "en";
            }
        }
        
        // Then check Accept-Language header for Polish
        var acceptLanguage = context.Request.Headers["Accept-Language"].ToString().ToLowerInvariant();
        if (acceptLanguage.Contains("pl"))
        {
            return "pl";
        }
        
        // Default to English
        return "en";
    }
    
    private string? GetLocalizedUrl(string path, string culture)
    {
        // Normalize path
        var normalizedPath = path.TrimEnd('/');
        if (string.IsNullOrEmpty(normalizedPath))
        {
            normalizedPath = "/";
        }
        
        // Check if this path has a localized version
        if (LocalizedRoutes.TryGetValue(normalizedPath, out var routes))
        {
            if (routes.TryGetValue(culture, out var localizedUrl))
            {
                return localizedUrl;
            }
        }
        
        return null;
    }
}

public static class LocalizedUrlMiddlewareExtensions
{
    public static IApplicationBuilder UseLocalizedUrls(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LocalizedUrlMiddleware>();
    }
}
