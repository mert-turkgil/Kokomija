using Microsoft.AspNetCore.Localization;

namespace Kokomija.Services;

/// <summary>
/// Service to generate localized URLs based on the current culture
/// </summary>
public interface ILocalizedUrlService
{
    string GetHomeUrl();
    string GetLoginUrl();
    string GetRegisterUrl();
    string GetProductsUrl();
    string GetProductUrl(string slug);
    string GetPrivacyUrl();
    string GetBlogUrl();
    string GetBlogPostUrl(string slug);
    string GetLocalizedUrl(string controller, string action, string? id = null);
}

public class LocalizedUrlService : ILocalizedUrlService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public LocalizedUrlService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    private string GetCurrentCulture()
    {
        var context = _httpContextAccessor.HttpContext;
        if (context == null) return "en";
        
        var requestCulture = context.Features.Get<IRequestCultureFeature>();
        return requestCulture?.RequestCulture.Culture.TwoLetterISOLanguageName ?? "en";
    }
    
    public string GetHomeUrl()
    {
        return GetCurrentCulture() switch
        {
            "pl" => "/pl/strona-glowna",
            "tr" => "/tr/anasayfa",
            _ => "/en/home"
        };
    }
    
    public string GetLoginUrl()
    {
        return GetCurrentCulture() switch
        {
            "pl" => "/pl/logowanie",
            "tr" => "/tr/giris",
            _ => "/en/login"
        };
    }
    
    public string GetRegisterUrl()
    {
        return GetCurrentCulture() switch
        {
            "pl" => "/pl/rejestracja",
            "tr" => "/tr/kayit-ol",
            _ => "/en/sign-up"
        };
    }
    
    public string GetProductsUrl()
    {
        return GetCurrentCulture() switch
        {
            "pl" => "/pl/produkty",
            "tr" => "/tr/urunler",
            _ => "/en/products"
        };
    }
    
    public string GetProductUrl(string slug)
    {
        var culture = GetCurrentCulture();
        var productPath = culture switch
        {
            "pl" => "produkt",
            "tr" => "urun",
            _ => "product"
        };
        return $"/{culture}/{productPath}/{slug}";
    }
    
    public string GetPrivacyUrl()
    {
        return GetCurrentCulture() switch
        {
            "pl" => "/pl/polityka-prywatnosci",
            "tr" => "/tr/gizlilik-politikasi",
            _ => "/en/privacy-policy"
        };
    }
    
    public string GetBlogUrl()
    {
        return GetCurrentCulture() switch
        {
            "pl" => "/pl/blog",
            "tr" => "/tr/blog",
            _ => "/en/blog"
        };
    }
    
    public string GetBlogPostUrl(string slug)
    {
        var culture = GetCurrentCulture();
        var blogPath = culture switch
        {
            "pl" => "artykul",
            "tr" => "makale",
            _ => "blog"
        };
        return $"/{culture}/{blogPath}/{slug}";
    }
    
    public string GetLocalizedUrl(string controller, string action, string? id = null)
    {
        var culture = GetCurrentCulture();
        
        // Map controller/action to localized URLs
        var key = $"{controller.ToLower()}/{action.ToLower()}";
        
        var url = (culture, key) switch
        {
            ("pl", "home/index") => "/pl/strona-glowna",
            ("pl", "account/login") => "/pl/logowanie",
            ("pl", "account/register") => "/pl/rejestracja",
            ("pl", "product/index") => "/pl/produkty",
            
            ("tr", "home/index") => "/tr/anasayfa",
            ("tr", "account/login") => "/tr/giris",
            ("tr", "account/register") => "/tr/kayit-ol",
            ("tr", "product/index") => "/tr/urunler",
            
            (_, "home/index") => "/en/home",
            (_, "account/login") => "/en/login",
            (_, "account/register") => "/en/sign-up",
            (_, "product/index") => "/en/products",
            
            // Default fallback to standard routing
            _ => $"/{controller}/{action}"
        };
        
        if (!string.IsNullOrEmpty(id))
        {
            url += $"/{id}";
        }
        
        return url;
    }
}
