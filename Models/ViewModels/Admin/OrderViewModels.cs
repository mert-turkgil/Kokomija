using Kokomija.Entity;
using System.ComponentModel.DataAnnotations;

namespace Kokomija.Models.ViewModels.Admin
{
    /// <summary>
    /// DTO for toggling blog publish status
    /// </summary>
    public class BlogTogglePublishDto
    {
        [Required]
        public int Id { get; set; }
    }

    /// <summary>
    /// ViewModel for Order Management page with statistics
    /// </summary>
    public class OrderManagementViewModel
    {
        public List<OrderListItemDto> Orders { get; set; } = new();
        public OrderStatisticsDto Statistics { get; set; } = new();
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public int TotalOrders { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalOrders / PageSize);
        public string? SearchQuery { get; set; }
        public string? StatusFilter { get; set; }
        public string? PaymentStatusFilter { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }

    /// <summary>
    /// Order statistics for dashboard
    /// </summary>
    public class OrderStatisticsDto
    {
        public int TotalOrders { get; set; }
        public int PendingOrders { get; set; }
        public int ProcessingOrders { get; set; }
        public int ShippedOrders { get; set; }
        public int DeliveredOrders { get; set; }
        public int CancelledOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TodayRevenue { get; set; }
        public decimal MonthRevenue { get; set; }
        public decimal AverageOrderValue { get; set; }
        public int AwaitingShipment { get; set; }
        public int PendingReturns { get; set; }
    }

    /// <summary>
    /// Order list item for table display
    /// </summary>
    public class OrderListItemDto
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public string Currency { get; set; } = "PLN";
        public string OrderStatus { get; set; } = string.Empty;
        public string PaymentStatus { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int ItemCount { get; set; }
        public bool HasShipment { get; set; }
        public ShipmentStatus? ShipmentStatus { get; set; }
        public string? TrackingNumber { get; set; }
        public bool HasActiveReturn { get; set; }
        public int ActiveReturnCount { get; set; }
        public bool IsDemoOrder { get; set; }
    }

    /// <summary>
    /// Complete order details for admin view
    /// </summary>
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public string StripePaymentIntentId { get; set; } = string.Empty;
        public string? StripeChargeId { get; set; }
        
        // Customer Information
        public string? UserId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string? CustomerPhone { get; set; }
        public string? UserVipTier { get; set; }
        public decimal? UserTotalSpent { get; set; }
        
        // Order Status
        public string OrderStatus { get; set; } = string.Empty;
        public string PaymentStatus { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? PaidAt { get; set; }
        public DateTime? ShippedAt { get; set; }
        public DateTime? DeliveredAt { get; set; }
        
        // Financial Information
        public decimal SubtotalAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TaxRate { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal CommissionAmount { get; set; }
        public decimal CommissionRate { get; set; }
        public string Currency { get; set; } = "PLN";
        
        // Coupon
        public int? CouponId { get; set; }
        public string? CouponCode { get; set; }
        
        // Addresses
        public AddressDto? ShippingAddress { get; set; }
        public AddressDto? BillingAddress { get; set; }
        
        // Order Items
        public List<OrderItemDetailsDto> OrderItems { get; set; } = new();
        
        // Shipment Information
        public OrderShipmentDetailsDto? Shipment { get; set; }
        
        // Return Requests
        public List<ReturnRequestSummaryDto> ReturnRequests { get; set; } = new();
        
        // Developer Earnings
        public DeveloperEarningsDto? DeveloperEarnings { get; set; }
    }

    /// <summary>
    /// Address information
    /// </summary>
    public class AddressDto
    {
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        
        public string FullAddress => 
            $"{Address}, {City}, {State} {PostalCode}, {Country}".Trim(' ', ',');
    }

    /// <summary>
    /// Order item details
    /// </summary>
    public class OrderItemDetailsDto
    {
        public int Id { get; set; }
        public int ProductVariantId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string? ProductImageUrl { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public bool HasActiveReturn { get; set; }
        public ReturnRequestStatus? ReturnStatus { get; set; }
    }

    /// <summary>
    /// Shipment details with tracking
    /// </summary>
    public class OrderShipmentDetailsDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string? TrackingNumber { get; set; }
        public ShipmentStatus Status { get; set; }
        public DateTime? EstimatedDeliveryDate { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal? Weight { get; set; }
        public DateTime? ShippedAt { get; set; }
        public DateTime? DeliveredAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        // Provider Information
        public string ProviderName { get; set; } = string.Empty;
        public string ProviderCode { get; set; } = string.Empty;
        public string? TrackingUrl { get; set; }
        
        // Rate Information
        public string RateName { get; set; } = string.Empty;
        public int MinDeliveryDays { get; set; }
        public int MaxDeliveryDays { get; set; }
        
        // Tracking Events
        public List<ShipmentTrackingEventDto> TrackingEvents { get; set; } = new();
    }

    /// <summary>
    /// Shipment tracking event
    /// </summary>
    public class ShipmentTrackingEventDto
    {
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? Location { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime EventDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    /// <summary>
    /// Return request summary
    /// </summary>
    public class ReturnRequestSummaryDto
    {
        public int Id { get; set; }
        public int OrderItemId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public decimal RequestedAmount { get; set; }
        public ReturnRequestStatus Status { get; set; }
        public DateTime RequestedAt { get; set; }
        public DateTime? ReviewedAt { get; set; }
        public string? ReviewerName { get; set; }
    }

    /// <summary>
    /// Developer earnings for order
    /// </summary>
    public class DeveloperEarningsDto
    {
        public int Id { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal StripeProcessingFee { get; set; }
        public decimal DeveloperCommission { get; set; }
        public decimal NetAmount { get; set; }
        public DateTime EarnedAt { get; set; }
        public PayoutStatus PayoutStatus { get; set; }
        public string? PayoutId { get; set; }
        public DateTime? PayoutDate { get; set; }
    }

    /// <summary>
    /// DTO for updating order status
    /// </summary>
    public class UpdateOrderStatusDto
    {
        [Required]
        public int OrderId { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string OrderStatus { get; set; } = string.Empty;
        
        [MaxLength(500)]
        public string? Notes { get; set; }
    }

    /// <summary>
    /// DTO for creating shipment
    /// </summary>
    public class CreateOrderShipmentDto
    {
        [Required]
        public int OrderId { get; set; }
        
        [Required]
        public int ShippingProviderId { get; set; }
        
        [Required]
        public int ShippingRateId { get; set; }
        
        [MaxLength(100)]
        public string? TrackingNumber { get; set; }
        
        [Range(0.01, 9999.99)]
        public decimal? Weight { get; set; }
        
        public DateTime? EstimatedDeliveryDate { get; set; }
    }

    /// <summary>
    /// DTO for updating tracking number
    /// </summary>
    public class UpdateTrackingNumberDto
    {
        [Required]
        public int ShipmentId { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string TrackingNumber { get; set; } = string.Empty;
    }

    /// <summary>
    /// DTO for adding tracking event
    /// </summary>
    public class AddTrackingEventDto
    {
        [Required]
        public int ShipmentId { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Status { get; set; } = string.Empty;
        
        [MaxLength(200)]
        public string? Location { get; set; }
        
        [Required]
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
        
        public DateTime? EventDate { get; set; }
    }
}
