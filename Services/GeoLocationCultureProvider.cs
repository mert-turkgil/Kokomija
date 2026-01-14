using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace Kokomija.Services;

/// <summary>
/// Custom culture provider that sets Polish for Poland visitors, English for everyone else.
/// Uses Accept-Language header to detect Polish users, defaults to English otherwise.
/// </summary>
public class GeoLocationCultureProvider : RequestCultureProvider
{
    private const string PolishCulture = "pl-PL";
    private const string EnglishCulture = "en-US";
    
    public override Task<ProviderCultureResult?> DetermineProviderCultureResult(HttpContext httpContext)
    {
        // First check if user already has a culture cookie set (they made a choice)
        var cultureCookie = httpContext.Request.Cookies[CookieRequestCultureProvider.DefaultCookieName];
        if (!string.IsNullOrEmpty(cultureCookie))
        {
            // User already has a preference, don't override
            return Task.FromResult<ProviderCultureResult?>(null);
        }
        
        // Check Accept-Language header for Polish language preference
        var acceptLanguageHeader = httpContext.Request.Headers["Accept-Language"].ToString();
        
        if (!string.IsNullOrEmpty(acceptLanguageHeader))
        {
            // Check if Polish is in the Accept-Language header
            var languages = acceptLanguageHeader.ToLowerInvariant();
            
            if (languages.Contains("pl"))
            {
                // Polish user - set Polish culture
                return Task.FromResult<ProviderCultureResult?>(
                    new ProviderCultureResult(PolishCulture, PolishCulture));
            }
        }
        
        // For everyone else (non-Polish), default to English
        return Task.FromResult<ProviderCultureResult?>(
            new ProviderCultureResult(EnglishCulture, EnglishCulture));
    }
}
