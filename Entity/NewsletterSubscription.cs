using System.ComponentModel.DataAnnotations;

namespace Kokomija.Entity;

public class NewsletterSubscription
{
    [Key]
    public int Id { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(255)]
    public string Email { get; set; } = string.Empty;

    public string? UserId { get; set; } // Optional - links to user if authenticated

    [Required]
    public bool IsActive { get; set; } = true;

    [Required]
    public bool ReceiveNewProductNotifications { get; set; } = true;

    [Required]
    public bool ReceiveDiscountNotifications { get; set; } = true;

    [Required]
    public bool ReceiveWishlistNotifications { get; set; } = true;

    [Required]
    public DateTime SubscribedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UnsubscribedAt { get; set; }

    [MaxLength(100)]
    public string? UnsubscribeToken { get; set; }
    
    // Email confirmation
    [MaxLength(100)]
    public string? ConfirmationToken { get; set; }
    
    public DateTime? ConfirmationTokenExpiry { get; set; }
    
    public DateTime? ConfirmedAt { get; set; }
    
    [MaxLength(50)]
    public string? Source { get; set; } // "Registration", "Footer", "Popup", etc.

    // Navigation property
    public ApplicationUser? User { get; set; }
}
