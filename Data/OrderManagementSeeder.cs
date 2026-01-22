using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;

namespace Kokomija.Data
{
    public static class OrderManagementSeeder
    {
        public static void SeedShippingProviders(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShippingProvider>().HasData(
                // InPost - 2 variants
                new ShippingProvider
                {
                    Id = 1,
                    Name = "InPost Paczkomat",
                    Code = "inpost_paczkomat",
                    IsActive = true,
                    TrackingUrlTemplate = "https://inpost.pl/sledzenie-przesylek?number={trackingNumber}",
                    SupportedCountries = "[\"PL\"]",
                    EstimatedDeliveryDays = 2,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new ShippingProvider
                {
                    Id = 2,
                    Name = "InPost Kurier",
                    Code = "inpost_courier",
                    IsActive = true,
                    TrackingUrlTemplate = "https://inpost.pl/sledzenie-przesylek?number={trackingNumber}",
                    SupportedCountries = "[\"PL\"]",
                    EstimatedDeliveryDays = 1,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                // DHL - 2 variants
                new ShippingProvider
                {
                    Id = 3,
                    Name = "DHL Express",
                    Code = "dhl_express",
                    IsActive = true,
                    TrackingUrlTemplate = "https://www.dhl.com/en/express/tracking.html?AWB={trackingNumber}",
                    SupportedCountries = "[\"PL\",\"DE\",\"US\",\"GB\",\"FR\",\"IT\"]",
                    EstimatedDeliveryDays = 2,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new ShippingProvider
                {
                    Id = 4,
                    Name = "DHL Standard",
                    Code = "dhl_standard",
                    IsActive = true,
                    TrackingUrlTemplate = "https://www.dhl.com/en/express/tracking.html?AWB={trackingNumber}",
                    SupportedCountries = "[\"PL\",\"DE\",\"US\",\"GB\",\"FR\",\"IT\"]",
                    EstimatedDeliveryDays = 4,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                // Poczta Polska - 1 variant
                new ShippingProvider
                {
                    Id = 5,
                    Name = "Poczta Polska",
                    Code = "poczta_polska",
                    IsActive = true,
                    TrackingUrlTemplate = "https://emonitoring.poczta-polska.pl/?numer={trackingNumber}",
                    SupportedCountries = "[\"PL\"]",
                    EstimatedDeliveryDays = 5,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );
        }

        public static void SeedShippingRates(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShippingRate>().HasData(
                // InPost Paczkomat rates
                new ShippingRate
                {
                    Id = 1,
                    ShippingProviderId = 1,
                    Name = "InPost Paczkomat",
                    Description = "Delivery to InPost parcel locker",
                    BasePrice = 9.99m,
                    FreeShippingThreshold = 100.00m,
                    MinDeliveryDays = 1,
                    MaxDeliveryDays = 2,
                    IsActive = true,
                    CountryCode = "PL",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                // InPost Kurier rates
                new ShippingRate
                {
                    Id = 2,
                    ShippingProviderId = 2,
                    Name = "InPost Kurier",
                    Description = "Home delivery by InPost courier",
                    BasePrice = 14.99m,
                    FreeShippingThreshold = 150.00m,
                    MinDeliveryDays = 1,
                    MaxDeliveryDays = 2,
                    IsActive = true,
                    CountryCode = "PL",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                // DHL Express rates
                new ShippingRate
                {
                    Id = 3,
                    ShippingProviderId = 3,
                    Name = "DHL Express",
                    Description = "Express international delivery",
                    BasePrice = 49.99m,
                    MinDeliveryDays = 1,
                    MaxDeliveryDays = 2,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                // DHL Standard rates
                new ShippingRate
                {
                    Id = 4,
                    ShippingProviderId = 4,
                    Name = "DHL Standard",
                    Description = "Standard international delivery",
                    BasePrice = 29.99m,
                    MinDeliveryDays = 3,
                    MaxDeliveryDays = 5,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                // Poczta Polska rates
                new ShippingRate
                {
                    Id = 5,
                    ShippingProviderId = 5,
                    Name = "Poczta Polska Standard",
                    Description = "Standard postal delivery",
                    BasePrice = 12.99m,
                    FreeShippingThreshold = 120.00m,
                    MinDeliveryDays = 3,
                    MaxDeliveryDays = 5,
                    IsActive = true,
                    CountryCode = "PL",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );
        }

        public static void SeedTaxRates(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaxRate>().HasData(
                new TaxRate
                {
                    Id = 1,
                    Name = "VAT 23% (Poland)",
                    CountryCode = "PL",
                    Rate = 23.00m,
                    StripeTaxRateId = "txr_placeholder_pl_23", // Will be updated with real Stripe ID
                    IsActive = true,
                    IsDefault = true,
                    Description = "Standard VAT rate for Poland",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new TaxRate
                {
                    Id = 2,
                    Name = "VAT 8% (Poland - Reduced)",
                    CountryCode = "PL",
                    Rate = 8.00m,
                    StripeTaxRateId = "txr_placeholder_pl_8",
                    IsActive = true,
                    IsDefault = false,
                    Description = "Reduced VAT rate for specific products",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new TaxRate
                {
                    Id = 3,
                    Name = "VAT 5% (Poland - Super Reduced)",
                    CountryCode = "PL",
                    Rate = 5.00m,
                    StripeTaxRateId = "txr_placeholder_pl_5",
                    IsActive = false,
                    IsDefault = false,
                    Description = "Super reduced VAT rate",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );
        }
    }
}
