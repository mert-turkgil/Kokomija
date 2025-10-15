using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

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

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? LastLoginAt { get; set; }

        public bool IsActive { get; set; } = true;

        // Navigation properties for orders
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
