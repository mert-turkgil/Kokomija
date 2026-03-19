namespace Kokomija.Models.ViewModels
{
    public class CouponCardViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string DiscountType { get; set; } = "percentage";
        public decimal DiscountValue { get; set; }
        public string CouponType { get; set; } = "general";
        public decimal? MinimumOrderAmount { get; set; }
        public decimal? MaximumDiscountAmount { get; set; }
        public DateTime? ValidUntil { get; set; }
        public bool IsNew { get; set; }
        public string? CategoryName { get; set; }
        public string? ProductName { get; set; }
    }
}
