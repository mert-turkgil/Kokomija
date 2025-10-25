using Microsoft.Extensions.Localization;

namespace Kokomija.Services
{
    public interface ILocalizationService
    {
        /// <summary>
        /// Get localized string by key (returns string value)
        /// </summary>
        string GetString(string key);
        
        /// <summary>
        /// Get localized string by key (returns LocalizedString with metadata)
        /// </summary>
        LocalizedString GetKey(string key);
        
        /// <summary>
        /// Invalidate the localization cache and reload resources
        /// </summary>
        void InvalidateCache();
        
        /// <summary>
        /// Indexer for convenient access to localized strings
        /// </summary>
        string this[string key] { get; }
    }
}
