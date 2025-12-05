using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity
{
    public enum ReturnRequestStatus
    {
        Pending,
        UnderReview,
        Approved,
        Rejected,
        Completed,
        Cancelled
    }

    public class ReturnRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;

        [Required]
        public int OrderItemId { get; set; }

        [ForeignKey(nameof(OrderItemId))]
        public OrderItem OrderItem { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        public string Reason { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal RequestedAmount { get; set; }

        [Required]
        public ReturnRequestStatus Status { get; set; } = ReturnRequestStatus.Pending;

        [Required]
        public DateTime RequestedAt { get; set; } = DateTime.UtcNow;

        public DateTime? ReviewedAt { get; set; }

        public string? ReviewedBy { get; set; }

        [ForeignKey(nameof(ReviewedBy))]
        public ApplicationUser? Reviewer { get; set; }

        public string? ReviewNotes { get; set; }

        [MaxLength(100)]
        public string? StripeRefundId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? RefundedAmount { get; set; }

        public DateTime? RefundedAt { get; set; }

        public ICollection<ReturnRequestImage> Images { get; set; } = new List<ReturnRequestImage>();
        public ICollection<ReturnStatusHistory> StatusHistory { get; set; } = new List<ReturnStatusHistory>();
    }
}
