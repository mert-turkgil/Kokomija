using System.ComponentModel.DataAnnotations;

namespace Kokomija.Models.ViewModels.Admin
{
    public class UserManagementViewModel
    {
        public List<UserListItemDto> Users { get; set; } = new();
        public int TotalUsers { get; set; }
        public int ActiveUsers { get; set; }
        public int BannedUsers { get; set; }
        public int NewUsersThisMonth { get; set; }
    }

    public class UserListItemDto
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool IsBanned { get; set; }
        public DateTimeOffset? BannedUntil { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLogin { get; set; }
        public int TotalOrders { get; set; }
        public int TotalReviews { get; set; }
        public bool IsRoot { get; set; } = false;
        
        public string FullName => !string.IsNullOrEmpty(FirstName) || !string.IsNullOrEmpty(LastName) 
            ? $"{FirstName} {LastName}".Trim() 
            : Email;
    }

    public class UserEditDto
    {
        public string Id { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        [StringLength(100)]
        public string? FirstName { get; set; }
        
        [StringLength(100)]
        public string? LastName { get; set; }
        
        [Phone]
        public string? PhoneNumber { get; set; }
        
        public bool EmailConfirmed { get; set; }
        public bool IsBanned { get; set; }
        public DateTimeOffset? BannedUntil { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLogin { get; set; }
        
        public List<UserReviewDto> Reviews { get; set; } = new();
    }

    public class UserReviewDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public bool IsVisible { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? AdminReply { get; set; }
        public DateTime? AdminReplyAt { get; set; }
    }
}
