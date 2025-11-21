using Microsoft.Extensions.Localization;

namespace Kokomija.Services
{
    public interface ILocalizationService
    {
        /// <summary>
        /// Get localized string by key from SharedResources (returns string value)
        /// </summary>
        string GetString(string key);
        
        /// <summary>
        /// Get localized string by key from specific resource file (returns string value)
        /// </summary>
        /// <param name="key">Translation key</param>
        /// <param name="resourceName">Resource name: Carousel, Home, Product, Account, Navigation, Common</param>
        string GetString(string key, string resourceName);
        
        /// <summary>
        /// Get localized string by key from SharedResources (returns LocalizedString with metadata)
        /// </summary>
        LocalizedString GetKey(string key);
        
        /// <summary>
        /// Get localized string by key from specific resource file (returns LocalizedString with metadata)
        /// </summary>
        /// <param name="key">Translation key</param>
        /// <param name="resourceName">Resource name: Carousel, Home, Product, Account, Navigation, Common</param>
        LocalizedString GetKey(string key, string resourceName);
        
        /// <summary>
        /// Invalidate the localization cache and reload resources
        /// </summary>
        void InvalidateCache();
        
        /// <summary>
        /// Indexer for convenient access to localized strings from SharedResources
        /// </summary>
        string this[string key] { get; }
    }
}

