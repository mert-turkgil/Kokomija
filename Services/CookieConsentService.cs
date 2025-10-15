using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Kokomija.Services
{
    /// <summary>
    /// Cookie consent categories for GDPR/EU compliance
    /// </summary>
    public enum CookieCategory
    {
        Essential,      // Required for site functionality (authentication, cart)
        Analytics,      // Google Analytics, usage tracking
        Marketing,      // Advertising, retargeting
        Preferences     // User preferences, language settings
    }

    /// <summary>
    /// User's cookie consent preferences
    /// </summary>
    public class CookieConsent
    {
        public bool Essential { get; set; } = true; // Always true
        public bool Analytics { get; set; } = false;
        public bool Marketing { get; set; } = false;
        public bool Preferences { get; set; } = true; // Usually true for language
        public DateTime ConsentDate { get; set; }
        public string ConsentVersion { get; set; } = "1.0";
    }

    public interface ICookieConsentService
    {
        CookieConsent GetConsent(HttpContext context);
        void SaveConsent(HttpContext context, CookieConsent consent);
        bool HasConsent(HttpContext context);
        bool IsCategoryAllowed(HttpContext context, CookieCategory category);
        void RevokeConsent(HttpContext context);
    }

    public class CookieConsentService : ICookieConsentService
    {
        private const string ConsentCookieName = "kokomija_cookie_consent";
        private const int ConsentDurationDays = 365; // Store consent for 1 year

        public CookieConsent GetConsent(HttpContext context)
        {
            if (context.Request.Cookies.TryGetValue(ConsentCookieName, out var consentJson))
            {
                try
                {
                    return JsonSerializer.Deserialize<CookieConsent>(consentJson) ?? new CookieConsent();
                }
                catch
                {
                    return new CookieConsent();
                }
            }

            return new CookieConsent();
        }

        public void SaveConsent(HttpContext context, CookieConsent consent)
        {
            consent.ConsentDate = DateTime.UtcNow;
            var consentJson = JsonSerializer.Serialize(consent);

            var cookieOptions = new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(ConsentDurationDays),
                HttpOnly = true,
                Secure = true, // HTTPS only
                SameSite = SameSiteMode.Lax,
                IsEssential = true, // This cookie is essential for consent tracking
                Path = "/"
            };

            context.Response.Cookies.Append(ConsentCookieName, consentJson, cookieOptions);
        }

        public bool HasConsent(HttpContext context)
        {
            return context.Request.Cookies.ContainsKey(ConsentCookieName);
        }

        public bool IsCategoryAllowed(HttpContext context, CookieCategory category)
        {
            var consent = GetConsent(context);

            return category switch
            {
                CookieCategory.Essential => true, // Always allowed
                CookieCategory.Analytics => consent.Analytics,
                CookieCategory.Marketing => consent.Marketing,
                CookieCategory.Preferences => consent.Preferences,
                _ => false
            };
        }

        public void RevokeConsent(HttpContext context)
        {
            context.Response.Cookies.Delete(ConsentCookieName);
        }
    }
}
