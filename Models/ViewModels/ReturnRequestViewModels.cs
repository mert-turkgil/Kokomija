using System.ComponentModel.DataAnnotations;
using Kokomija.Entity;
using Microsoft.AspNetCore.Http;

namespace Kokomija.Models.ViewModels.ReturnRequest
{
    /// <summary>
    /// DTO for creating a return request
    /// </summary>
    public class CreateReturnRequestDto
    {
        [Required(ErrorMessage = "Order ID is required")]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Please select an item to return")]
        public int OrderItemId { get; set; }

        [Required(ErrorMessage = "Please select a reason for return")]
        [MaxLength(200)]
        public string Reason { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please provide a detailed description")]
        [MaxLength(2000)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Requested amount is required")]
        [Range(0.01, 999999.99, ErrorMessage = "Amount must be greater than 0")]
        public decimal RequestedAmount { get; set; }

        public List<IFormFile>? Images { get; set; }
    }

    /// <summary>
    /// DTO for displaying return request details
    /// </summary>
    public class ReturnRequestDetailsDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public int OrderItemId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string? ProductImageUrl { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal RequestedAmount { get; set; }
        public ReturnRequestStatus Status { get; set; }
        public DateTime RequestedAt { get; set; }
        public DateTime? ReviewedAt { get; set; }
        public string? ReviewerName { get; set; }
        public string? ReviewNotes { get; set; }
        public string? StripeRefundId { get; set; }
        public decimal? RefundedAmount { get; set; }
        public DateTime? RefundedAt { get; set; }
        public List<string> ImageUrls { get; set; } = new();
        public List<ReturnStatusHistoryDto> StatusHistory { get; set; } = new();
    }

    /// <summary>
    /// DTO for return request list item
    /// </summary>
    public class ReturnRequestListDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string? ProductImageUrl { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public decimal RequestedAmount { get; set; }
        public ReturnRequestStatus Status { get; set; }
        public DateTime RequestedAt { get; set; }
        public bool HasImages { get; set; }
    }

    /// <summary>
    /// DTO for status history entry
    /// </summary>
    public class ReturnStatusHistoryDto
    {
        public int Id { get; set; }
        public ReturnRequestStatus Status { get; set; }
        public string? Notes { get; set; }
        public string ChangedBy { get; set; } = string.Empty;
        public DateTime ChangedAt { get; set; }
    }

    /// <summary>
    /// DTO for admin review action
    /// </summary>
    public class ReviewReturnRequestDto
    {
        [Required]
        public int ReturnRequestId { get; set; }

        [Required]
        public bool Approve { get; set; }

        [Range(0.01, 999999.99, ErrorMessage = "Refund amount must be greater than 0")]
        public decimal? RefundAmount { get; set; }

        [MaxLength(1000)]
        public string? ReviewNotes { get; set; }

        [MaxLength(500)]
        public string? CustomerMessage { get; set; }
    }

    /// <summary>
    /// ViewModel for return requests page
    /// </summary>
    public class ReturnRequestsViewModel
    {
        public List<ReturnRequestListDto> ReturnRequests { get; set; } = new();
        public int TotalCount { get; set; }
        public int PendingCount { get; set; }
        public int ApprovedCount { get; set; }
        public int RejectedCount { get; set; }
        public int CompletedCount { get; set; }
        public decimal TotalRefundedAmount { get; set; }
    }

    /// <summary>
    /// ViewModel for customer's return requests
    /// </summary>
    public class MyReturnsViewModel
    {
        public List<ReturnRequestDetailsDto> ReturnRequests { get; set; } = new();
        public List<OrderItemDto> EligibleItems { get; set; } = new();
    }

    /// <summary>
    /// DTO for eligible order items
    /// </summary>
    public class OrderItemDto
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public int OrderItemId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string? ProductImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public DateTime OrderDate { get; set; }
        public bool CanReturn { get; set; }
        public string? CannotReturnReason { get; set; }
    }
}
