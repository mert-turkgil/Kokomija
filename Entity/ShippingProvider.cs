using System.ComponentModel.DataAnnotations;

namespace Kokomija.Entity
{
    public class ShippingProvider
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty; // "UPS", "FedEx", "DHL", "InPost"

        [Required]
        [MaxLength(50)]
        public string Code { get; set; } = string.Empty; // "ups", "fedex", "dhl"

        [Required]
        public bool IsActive { get; set; } = true;

        [MaxLength(500)]
        public string? LogoUrl { get; set; }

        // ==================== API Configuration ====================
        
        [MaxLength(9000)]
        public string? ApiKey { get; set; } // Encrypted - JWT tokens can be long

        [MaxLength(9000)]
        public string? ApiSecret { get; set; } // Encrypted - JWT tokens can be long
        
        [MaxLength(500)]
        public string? ApiAccountNumber { get; set; } // Some carriers need account number
        
        [MaxLength(500)]
        public string? ApiBaseUrl { get; set; } // e.g., "https://api-eu.dhl.com" or "https://api-shipx-pl.easypack24.net"
        
        [MaxLength(100)]
        public string? ApiVersion { get; set; } // API version if needed
        
        public bool UseSandbox { get; set; } = false; // Use sandbox/test environment
        
        [MaxLength(500)]
        public string? SandboxApiBaseUrl { get; set; } // Sandbox API URL

        [MaxLength(500)]
        public string? WebhookUrl { get; set; }
        
        [MaxLength(500)]
        public string? WebhookSecret { get; set; } // For verifying webhook signatures

        [MaxLength(500)]
        public string? TrackingUrlTemplate { get; set; } // e.g., "https://www.ups.com/track?tracknum={trackingNumber}"
        
        [MaxLength(500)]
        public string? TrackingApiEndpoint { get; set; } // API endpoint for tracking: "/track/shipments?trackingNumber={trackingNumber}"
        
        [MaxLength(500)]
        public string? ShipmentApiEndpoint { get; set; } // API endpoint for creating shipments
        
        [MaxLength(500)]
        public string? LabelApiEndpoint { get; set; } // API endpoint for generating labels
        
        [MaxLength(500)]
        public string? RatesApiEndpoint { get; set; } // API endpoint for getting rates

        // ==================== Authentication ====================
        
        [MaxLength(50)]
        public string AuthenticationType { get; set; } = "ApiKey"; // "ApiKey", "OAuth2", "Basic", "Bearer"
        
        [MaxLength(100)]
        public string? AuthHeaderName { get; set; } // Custom header name, e.g., "DHL-API-Key", "Authorization"
        
        [MaxLength(500)]
        public string? OAuthTokenUrl { get; set; } // For OAuth2 authentication
        
        public DateTime? OAuthTokenExpiry { get; set; }
        
        [MaxLength(2000)]
        public string? OAuthAccessToken { get; set; }

        // ==================== Supported Features ====================
        
        public string? SupportedCountries { get; set; } // JSON array of country codes
        
        public bool SupportsTracking { get; set; } = true;
        
        public bool SupportsLabelGeneration { get; set; } = true;
        
        public bool SupportsRateCalculation { get; set; } = true;
        
        public bool SupportsWebhooks { get; set; } = false;
        
        public bool SupportsPickupScheduling { get; set; } = false;
        
        public bool SupportsInsurance { get; set; } = false;

        // ==================== Default Values ====================

        public int EstimatedDeliveryDays { get; set; } = 3;
        
        public int Priority { get; set; } = 100; // Lower = higher priority for sorting

        // ==================== Timestamps ====================

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? LastApiCallAt { get; set; }
        
        public bool LastApiCallSuccess { get; set; } = true;
        
        [MaxLength(500)]
        public string? LastApiError { get; set; }

        // ==================== Navigation Properties ====================

        public ICollection<ShippingRate> ShippingRates { get; set; } = new List<ShippingRate>();
        public ICollection<OrderShipment> Shipments { get; set; } = new List<OrderShipment>();
    }
}
