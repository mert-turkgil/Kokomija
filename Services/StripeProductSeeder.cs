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

                // Get all products from database
                var allProducts = await _unitOfWork.Products.GetAllAsync();
                
                // Get all products from Stripe to check for existing products
                var stripeService = new Stripe.ProductService();
                var stripePriceService = new Stripe.PriceService();
                var stripeProducts = await stripeService.ListAsync(new Stripe.ProductListOptions { Limit = 100, Active = true });
                
                // Process all products (both with and without Stripe IDs)
                var products = allProducts.ToList();

                if (!products.Any())
                {
                    _logger.LogInformation("No products to process.");
                    return;
                }

                foreach (var product in products)
                {
                    try
                    {
                        _logger.LogInformation($"Processing product: {product.Name} (Price: {product.Price} PLN)");

                        // If product already has a Stripe ID, verify and update it
                        if (!string.IsNullOrEmpty(product.StripeProductId))
                        {
                            try
                            {
                                var existingProduct = await stripeService.GetAsync(product.StripeProductId);
                                if (existingProduct != null)
                                {
                                    _logger.LogInformation($"Updating existing Stripe product: {product.StripeProductId}");
                                    await _stripeService.UpdateProductAsync(product.StripeProductId, product);
                                    
                                    // Check if price needs updating
                                    var prices = await stripePriceService.ListAsync(new Stripe.PriceListOptions
                                    {
                                        Product = product.StripeProductId,
                                        Active = true,
                                        Limit = 10
                                    });
                                    
                                    var productPriceInGrosze = (long)(product.Price * 100);
                                    var matchingPrice = prices.Data.FirstOrDefault(p => 
                                        p.Currency == "pln" && 
                                        p.UnitAmount == productPriceInGrosze);
                                    
                                    if (matchingPrice != null)
                                    {
                                        product.StripePriceId = matchingPrice.Id;
                                    }
                                    else
                                    {
                                        // Create new price if none matches
                                        var newPrice = await _stripeService.CreatePriceAsync(product.StripeProductId, product.Price, "pln");
                                        product.StripePriceId = newPrice.Id;
                                    }
                                    
                                    await _unitOfWork.SaveChangesAsync();
                                    continue; // Skip to next product
                                }
                            }
                            catch (StripeException ex) when (ex.StripeError?.Type == "invalid_request_error")
                            {
                                _logger.LogWarning($"Stripe product {product.StripeProductId} not found, will create new one");
                                product.StripeProductId = string.Empty; // Clear invalid ID
                            }
                        }

                        // Check if a Stripe product with the same price already exists
                        Stripe.Product? matchingStripeProduct = null;
                        foreach (var stripeProduct in stripeProducts.Data)
                        {
                            // Get prices for this Stripe product
                            var prices = await stripePriceService.ListAsync(new Stripe.PriceListOptions
                            {
                                Product = stripeProduct.Id,
                                Active = true,
                                Limit = 10
                            });

                            // Check if any price matches our product price (convert PLN to grosze)
                            var productPriceInGrosze = (long)(product.Price * 100);
                            var matchingPrice = prices.Data.FirstOrDefault(p => 
                                p.Currency == "pln" && 
                                p.UnitAmount == productPriceInGrosze);

                            if (matchingPrice != null)
                            {
                                matchingStripeProduct = stripeProduct;
                                product.StripeProductId = stripeProduct.Id;
                                product.StripePriceId = matchingPrice.Id;
                                _logger.LogInformation($"Found existing Stripe product: {stripeProduct.Id} with matching price");
                                break;
                            }
                        }

                        // If no matching Stripe product found, create a new one
                        if (matchingStripeProduct == null)
                        {
                            _logger.LogInformation($"Creating new Stripe product for: {product.Name}");

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
                        }
                        else
                        {
                            _logger.LogInformation($"Using existing Stripe product, skipping creation");
                        }

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
