namespace Kokomija.Models.ViewModels.Cart
{
    public class CartIndexViewModel
    {
        public IEnumerable<CartItemViewModel> Items { get; set; } = new List<CartItemViewModel>();
        public decimal Subtotal { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Total { get; set; }
        public string? AppliedCouponCode { get; set; }
        public decimal? CouponDiscountPercentage { get; set; }
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
    }
    
    public class ApplyCouponRequest
    {
        public string CouponCode { get; set; } = string.Empty;
    }
    
    public class UpdateCartItemRequest
    {
        public int ProductId { get; set; }
        public int? ColorId { get; set; }
        public int? SizeId { get; set; }
        public int Quantity { get; set; }
    }
    
    public class RemoveCartItemRequest
    {
        public int ProductId { get; set; }
        public int? ColorId { get; set; }
        public int? SizeId { get; set; }
    }
}
