using Kokomija.Entity;

namespace Kokomija.Models.ViewModels.Checkout
{
    /// <summary>
    /// ViewModel for checkout success page
    /// </summary>
    public class CheckoutSuccessViewModel
    {
        public string OrderNumber { get; set; } = string.Empty;
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal SubtotalAmount { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string Currency { get; set; } = "PLN";
        public string PaymentStatus { get; set; } = string.Empty;
        public string OrderStatus { get; set; } = string.Empty;
        
        // Customer Info
        public string CustomerEmail { get; set; } = string.Empty;
        public string? CustomerName { get; set; }
        
        // Shipping Address
        public string? ShippingAddress { get; set; }
        public string? ShippingCity { get; set; }
        public string? ShippingState { get; set; }
        public string? ShippingPostalCode { get; set; }
        public string? ShippingCountry { get; set; }
        
        // Order Items
        public List<CheckoutOrderItemViewModel> Items { get; set; } = new();
        
        // VIP Info
        public string? VipTier { get; set; }
        public decimal VipDiscount { get; set; }
        
        // Payment Info (from Stripe)
        public string? PaymentIntentId { get; set; }
        public string? PaymentMethod { get; set; } // card brand info
        public string? Last4 { get; set; } // last 4 digits
        
        // Formatted display properties
        public string FormattedTotal => $"{TotalAmount:N2} {Currency}";
        public string FormattedSubtotal => $"{SubtotalAmount:N2} {Currency}";
        public string FormattedShipping => ShippingCost == 0 ? "Free" : $"{ShippingCost:N2} {Currency}";
        public string FormattedTax => $"{TaxAmount:N2} {Currency}";
        public string FormattedDiscount => DiscountAmount > 0 ? $"-{DiscountAmount:N2} {Currency}" : "";
        
        public string FormattedShippingAddress
        {
            get
            {
                var parts = new List<string>();
                if (!string.IsNullOrEmpty(ShippingAddress)) parts.Add(ShippingAddress);
                if (!string.IsNullOrEmpty(ShippingCity)) parts.Add(ShippingCity);
                if (!string.IsNullOrEmpty(ShippingState)) parts.Add(ShippingState);
                if (!string.IsNullOrEmpty(ShippingPostalCode)) parts.Add(ShippingPostalCode);
                if (!string.IsNullOrEmpty(ShippingCountry)) parts.Add(ShippingCountry);
                return string.Join(", ", parts);
            }
        }
    }
    
    /// <summary>
    /// ViewModel for order items in checkout result
    /// </summary>
    public class CheckoutOrderItemViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string? ProductImage { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int PackSize { get; set; } = 1;
        
        public string FormattedUnitPrice => $"{UnitPrice:N2} PLN";
        public string FormattedTotalPrice => $"{TotalPrice:N2} PLN";
    }
    
    /// <summary>
    /// ViewModel for checkout failure/cancel page
    /// </summary>
    public class CheckoutFailureViewModel
    {
        public string? SessionId { get; set; }
        public string? ErrorMessage { get; set; }
        public string FailureReason { get; set; } = "cancelled"; // cancelled, failed, expired
        public bool WasPaymentAttempted { get; set; }
        public decimal? AttemptedAmount { get; set; }
        public string? Currency { get; set; } = "PLN";
        public DateTime? AttemptedAt { get; set; }
        
        // For retry
        public bool CanRetry { get; set; } = true;
        public int CartItemCount { get; set; }
        
        public string FormattedAmount => AttemptedAmount.HasValue ? $"{AttemptedAmount.Value:N2} {Currency}" : "";
    }
}
