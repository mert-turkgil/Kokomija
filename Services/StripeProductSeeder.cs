using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace Kokomija.Services
{
    public interface IStripeProductSeeder
    {
        Task SeedProductsToStripeAsync();
    }

    public class StripeProductSeeder : IStripeProductSeeder
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStripeService _stripeService;
        private readonly ILogger<StripeProductSeeder> _logger;

        public StripeProductSeeder(
            IUnitOfWork unitOfWork,
            IStripeService stripeService,
            ILogger<StripeProductSeeder> logger)
        {
            _unitOfWork = unitOfWork;
            _stripeService = stripeService;
            _logger = logger;
        }

        public async Task SeedProductsToStripeAsync()
        {
            try
            {
                _logger.LogInformation("Starting Stripe product seeding...");

                // Get all products and filter those without Stripe IDs
                var allProducts = await _unitOfWork.Products.GetAllAsync();
                var products = allProducts.Where(p => string.IsNullOrEmpty(p.StripeProductId)).ToList();

                if (!products.Any())
                {
                    _logger.LogInformation("No products need Stripe seeding.");
                    return;
                }

                foreach (var product in products)
                {
                    try
                    {
                        _logger.LogInformation($"Creating Stripe product for: {product.Name}");

                        // Create Stripe product
                        var stripeProduct = await _stripeService.CreateProductAsync(product);
                        product.StripeProductId = stripeProduct.Id;

                        // Create a default price for the product (base price)
                        var stripePrice = await _stripeService.CreatePriceAsync(
                            stripeProduct.Id, 
                            product.Price, 
                            "pln"
                        );
                        product.StripePriceId = stripePrice.Id;

                        _logger.LogInformation($"Created Stripe product: {stripeProduct.Id} with price: {stripePrice.Id}");

                        // Now create prices for all variants of this product
                        var allVariants = await _unitOfWork.ProductVariants.GetAllAsync();
                        var variants = allVariants.Where(v => v.ProductId == product.Id).ToList();

                        foreach (var variant in variants)
                        {
                            try
                            {
                                // Load Size and Color for metadata (handle nullable IDs)
                                Size? size = null;
                                Color? color = null;
                                
                                if (variant.SizeId.HasValue)
                                {
                                    size = await _unitOfWork.Sizes.GetByIdAsync(variant.SizeId.Value);
                                }
                                
                                if (variant.ColorId.HasValue)
                                {
                                    color = await _unitOfWork.Colors.GetByIdAsync(variant.ColorId.Value);
                                }

                                // Temporarily assign for metadata
                                variant.Size = size;
                                variant.Color = color;
                                variant.Product = product;

                                var variantPrice = await _stripeService.CreateVariantPriceAsync(variant, "pln");
                                variant.StripePriceId = variantPrice.Id;

                                _logger.LogInformation($"  Created variant price: {variantPrice.Id} for SKU: {variant.SKU}");
                            }
                            catch (Exception ex)
                            {
                                _logger.LogError(ex, $"Failed to create Stripe price for variant SKU: {variant.SKU}");
                            }
                        }

                        await _unitOfWork.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, $"Failed to create Stripe product for: {product.Name}");
                    }
                }

                _logger.LogInformation("Stripe product seeding completed.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during Stripe product seeding");
                throw;
            }
        }
    }
}
