using Kokomija.Entity;

namespace Kokomija.Models.ViewModels.Checkout
{
    public class CheckoutViewModel
    {
        public List<CheckoutItemViewModel> Items { get; set; } = new();
        public ShippingAddressViewModel ShippingAddress { get; set; } = new();
        public decimal Subtotal { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal Tax { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public bool HasCoupon { get; set; }
        public string? CouponCode { get; set; }
        public string? StripePublishableKey { get; set; }
        public string? StripeCustomerId { get; set; }
        public string? UserEmail { get; set; }
        public string? UserFirstName { get; set; }
        public string? UserLastName { get; set; }
        public string? UserPhone { get; set; }
        public List<SavedPaymentMethodViewModel> SavedPaymentMethods { get; set; } = new();
        public bool IsGuest { get; set; }
        public decimal FreeShippingThreshold { get; set; } = 100m;
        public bool QualifiesForFreeShipping { get; set; }
        public List<ShippingOptionViewModel> ShippingOptions { get; set; } = new();
        public string SelectedShippingOption { get; set; } = "standard";
    }

    public class CheckoutItemViewModel
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int VariantId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductImage { get; set; } = string.Empty;
        public string ColorName { get; set; } = string.Empty;
        public string SizeName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Subtotal { get; set; }
        public string? StripePriceId { get; set; }
    }

    public class ShippingAddressViewModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string AddressLine1 { get; set; } = string.Empty;
        public string? AddressLine2 { get; set; }
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } = "PL"; // Default to Poland
    }

    public class SavedPaymentMethodViewModel
    {
        public string PaymentMethodId { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty; // visa, mastercard, amex
        public string Last4 { get; set; } = string.Empty;
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }
        public bool IsDefault { get; set; }
    }

    public class ShippingOptionViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public string DeliveryTime { get; set; } = string.Empty;
        public bool IsDefault { get; set; }
    }

    public class ProcessPaymentRequest
    {
        public string PaymentMethodId { get; set; } = string.Empty;
        public ShippingAddressViewModel ShippingAddress { get; set; } = new();
        public bool SavePaymentMethod { get; set; }
    }

    public class CreateCheckoutSessionRequest
    {
        public string ShippingOption { get; set; } = "standard";
    }
}
