namespace Kokomija.Models.ViewModels.Cart
{
    public class CartIndexViewModel
    {
        public IEnumerable<CartItemViewModel> Items { get; set; } = new List<CartItemViewModel>();
        public decimal Subtotal { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal DiscountAmount { get; set; } // Total discount (VIP + Coupon)
        public decimal VipDiscountAmount { get; set; } // VIP discount only
        public decimal CouponDiscountAmount { get; set; } // Coupon discount only
        public decimal TaxAmount { get; set; }
        public decimal Total { get; set; }
        public string? AppliedCouponCode { get; set; }
        public decimal? CouponDiscountPercentage { get; set; }
        public string VipTier { get; set; } = "None";
        public decimal VipDiscountPercentage { get; set; }
        public bool HasFreeShipping { get; set; }
        public decimal FreeShippingThreshold { get; set; }
        public decimal RemainingForFreeShipping { get; set; }
        public IEnumerable<string> AvailableCoupons { get; set; } = new List<string>();
    }
    
    public class CartItemViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string? ProductImage { get; set; }
        public string ProductSlug { get; set; } = string.Empty;
        public int? ColorId { get; set; }
        public string? ColorName { get; set; }
        public string? ColorHex { get; set; }
        public int? SizeId { get; set; }
        public string? SizeName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int StockQuantity { get; set; }
        public bool IsInStock { get; set; }
        public int MaxQuantity { get; set; }
        public int PackSize { get; set; } = 1;
        public int TotalItems => PackSize * Quantity; // Total individual items across all packs
    }
    
    public class ApplyCouponRequest
    {
        public string CouponCode { get; set; } = string.Empty;
    }
}
