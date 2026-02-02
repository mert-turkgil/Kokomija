using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(100)]
        public string? FirstName { get; set; }

        [MaxLength(100)]
        public string? LastName { get; set; }

        [MaxLength(100)]
        public string? StripeCustomerId { get; set; }

        [MaxLength(100)]
        public string? DefaultPaymentMethodId { get; set; }

        // Birthday for special coupons
        public DateTime? Birthday { get; set; }
        
        // Default Shipping Address
        [MaxLength(255)]
        public string? DefaultAddress { get; set; }
        
        [MaxLength(100)]
        public string? DefaultCity { get; set; }
        
        [MaxLength(20)]
        public string? DefaultPostalCode { get; set; }
        
        [MaxLength(100)]
        public string? DefaultCountry { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? LastLoginAt { get; set; }

        public bool IsActive { get; set; } = true;

        // VIP Status (based on total spending)
        public string VipTier { get; set; } = "None"; // None, Bronze, Silver, Gold, Platinum
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalSpent { get; set; } = 0;

        // Business profile for B2B customers
        public BusinessProfile? BusinessProfile { get; set; }

        // Navigation properties for orders
        public ICollection<Order> Orders { get; set; } = new List<Order>();

        // Navigation properties for saved payment methods
        public ICollection<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();

        // Navigation for NIP verification logs
        public ICollection<NIPVerificationLog> NIPVerificationLogs { get; set; } = new List<NIPVerificationLog>();
    }
}
