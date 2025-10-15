namespace Kokomija.Entity
{
    /// <summary>
    /// Supported languages/cultures for the site
    /// </summary>
    public class SupportedLanguage
    {
        public int Id { get; set; }
        
        /// <summary>
        /// Culture code (e.g., "pl-PL", "en-US", "de-DE")
        /// </summary>
        public string CultureCode { get; set; } = string.Empty;
        
        /// <summary>
        /// Display name (e.g., "Polski", "English", "Deutsch")
        /// </summary>
        public string DisplayName { get; set; } = string.Empty;
        
        /// <summary>
        /// Native name (e.g., "Polski", "English", "Deutsch")
        /// </summary>
        public string NativeName { get; set; } = string.Empty;
        
        /// <summary>
        /// Flag emoji or icon path (e.g., "🇵🇱", "/flags/pl.svg")
        /// </summary>
        public string? FlagIcon { get; set; }
        
        /// <summary>
        /// Is this language enabled for customers?
        /// </summary>
        public bool IsEnabled { get; set; } = false;
        
        /// <summary>
        /// Is this the default language for the site?
        /// </summary>
        public bool IsDefault { get; set; } = false;
        
        /// <summary>
        /// Display order in language selector
        /// </summary>
        public int DisplayOrder { get; set; }
        
        /// <summary>
        /// When was this language added?
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        /// <summary>
        /// Two-letter ISO code (e.g., "pl", "en", "de")
        /// </summary>
        public string TwoLetterIsoCode { get; set; } = string.Empty;
    }

    /// <summary>
    /// Site-wide settings controlled by administrators
    /// </summary>
    public class SiteSetting
    {
        public int Id { get; set; }
        
        /// <summary>
        /// Setting key (e.g., "MaintenanceMode", "DefaultCurrency")
        /// </summary>
        public string Key { get; set; } = string.Empty;
        
        /// <summary>
        /// Setting value
        /// </summary>
        public string Value { get; set; } = string.Empty;
        
        /// <summary>
        /// Setting description for admins
        /// </summary>
        public string? Description { get; set; }
        
        /// <summary>
        /// Setting category for grouping (e.g., "General", "Localization", "Payment")
        /// </summary>
        public string Category { get; set; } = "General";
        
        /// <summary>
        /// Data type (string, boolean, integer, json)
        /// </summary>
        public string DataType { get; set; } = "string";
        
        /// <summary>
        /// Last updated timestamp
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
        /// <summary>
        /// Who updated this setting last
        /// </summary>
        public string? UpdatedBy { get; set; }
    }
}
