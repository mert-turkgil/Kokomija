using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Kokomija.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Kokomija.Controllers
{
    /// <summary>
    /// Example controller demonstrating Unit of Work pattern usage
    /// This serves as a reference for how to use the data layer
    /// </summary>
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ProductController> _logger;
        private readonly Kokomija.Services.ILocalizationService _localizationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly INIPValidationService _nipValidationService;

        public ProductController(
            IUnitOfWork unitOfWork, 
            ILogger<ProductController> logger,
            Kokomija.Services.ILocalizationService localizationService,
            UserManager<ApplicationUser> userManager,
            INIPValidationService nipValidationService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _localizationService = localizationService;
            _userManager = userManager;
            _nipValidationService = nipValidationService;
        }

        #region Helper Methods

        /// <summary>
        /// Checks if the current user is in business mode
        /// </summary>
        private async Task<bool> IsBusinessModeActiveAsync()
        {
            if (!User.Identity?.IsAuthenticated == true)
                return false;

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return false;

            var profile = await _nipValidationService.GetBusinessProfileAsync(user.Id);
            return profile?.IsBusinessModeActive == true && profile?.IsVerified == true;
        }

        /// <summary>
        /// Filters products based on business mode status
        /// </summary>
        private IEnumerable<Product> FilterProductsForBusinessMode(IEnumerable<Product> products, bool isBusinessMode)
        {
            if (isBusinessMode)
            {
                // Business users see all products that are available for business
                return products.Where(p => !p.IsBusinessOnly || p.IsAvailableForBusiness);
            }
            else
            {
                // Regular users don't see business-only products
                return products.Where(p => !p.IsBusinessOnly);
            }
        }

        #endregion

        // GET: Product
        public async Task<IActionResult> Index()
        {
            try
            {
                // Check if user is in business mode
                var isBusinessMode = await IsBusinessModeActiveAsync();
                ViewBag.IsBusinessMode = isBusinessMode;

                // Get all active products with their primary images
                var products = await _unitOfWork.Products.GetActiveProductsAsync();
                
                // Filter products based on business mode
                var filteredProducts = FilterProductsForBusinessMode(products, isBusinessMode);
                
                return View(filteredProducts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving products");
                return View("Error");
            }
        }

        // GET: /pl/produkt/nazwa-produktu or /en/product/product-name
        // SEO-friendly product URL by localized slug
        [Route("{culture}/produkt/{slug}")]
        [Route("{culture}/product/{slug}")]
        [Route("{culture}/urun/{slug}")]
        public async Task<IActionResult> DetailsBySlug(string culture, string slug)
        {
            try
            {
                // Set culture from URL
                var cultureInfo = new CultureInfo(culture == "pl" ? "pl-PL" : culture == "tr" ? "tr-TR" : "en-US");
                CultureInfo.CurrentCulture = cultureInfo;
                CultureInfo.CurrentUICulture = cultureInfo;
                Thread.CurrentThread.CurrentCulture = cultureInfo;
                Thread.CurrentThread.CurrentUICulture = cultureInfo;

                // Get product by slug (searches all language slugs)
                var product = await _unitOfWork.Products.GetProductBySlugAsync(slug, culture);

                // Handle product not found
                if (product == null)
                {
                    _logger.LogWarning("Product not found for slug: {Slug}, culture: {Culture}", slug, culture);
                    return View("ProductNotFound");
                }

                // Get the correct translation for this culture
                var translation = product.Translations.FirstOrDefault(t => t.CultureCode.StartsWith(culture));
                
                // Canonical URL redirect: if the slug doesn't match the current culture's slug, redirect
                if (translation != null && !string.IsNullOrEmpty(translation.Slug))
                {
                    var normalizedInputSlug = NormalizeSlugForComparison(slug);
                    var normalizedTranslationSlug = translation.Slug.ToLowerInvariant();
                    
                    if (normalizedInputSlug != normalizedTranslationSlug)
                    {
                        // Redirect to the canonical URL with the correct slug for this culture
                        var routeName = culture == "pl" ? "produkt" : culture == "tr" ? "urun" : "product";
                        var canonicalUrl = $"/{culture}/{routeName}/{translation.Slug}";
                        _logger.LogInformation("Redirecting from {OldSlug} to canonical URL: {CanonicalUrl}", slug, canonicalUrl);
                        return RedirectPermanent(canonicalUrl);
                    }
                }

                // Handle inactive/archived/deleted products
                if (!product.IsActive)
                {
                    _logger.LogInformation("Product is inactive: {Slug}, culture: {Culture}", slug, culture);
                    
                    // Check if there are similar active products in the same group
                    if (product.ProductGroupId.HasValue)
                    {
                        var alternativeProducts = await _unitOfWork.Products.FindAsync(p => 
                            p.ProductGroupId == product.ProductGroupId && 
                            p.IsActive && 
                            p.Id != product.Id);
                        
                        if (alternativeProducts.Any())
                        {
                            ViewData["AlternativeProducts"] = alternativeProducts.ToList();
                        }
                    }
                    
                    // Check if there are similar products in the same category
                    else if (product.CategoryId.HasValue)
                    {
                        var categoryProducts = await _unitOfWork.Products.GetProductsByCategoryAsync(product.CategoryId.Value);
                        var alternatives = categoryProducts.Where(p => p.Id != product.Id && p.IsActive).Take(4).ToList();
                        if (alternatives.Any())
                        {
                            ViewData["AlternativeProducts"] = alternatives;
                        }
                    }

                    ViewData["ProductName"] = product.Name;
                    ViewData["CurrentCulture"] = culture;
                    return View("ProductUnavailable");
                }

                // Check stock availability
                var hasStock = product.Variants?.Any(v => v.StockQuantity > 0) ?? true;
                ViewData["HasStock"] = hasStock;

                // Check if user is in business mode for B2B pricing
                var isBusinessMode = await IsBusinessModeActiveAsync();
                ViewData["IsBusinessMode"] = isBusinessMode;
                
                // Check if this is a business-only product and user doesn't have business access
                if (product.IsBusinessOnly && !isBusinessMode)
                {
                    _logger.LogInformation("Product {ProductId} is business-only, user not in business mode", product.Id);
                    return View("ProductBusinessOnly");
                }

                // Load related products
                await LoadRelatedProducts(product);

                // Set page metadata from translation or fallback to product
                ViewData["Title"] = translation?.Name ?? product.Name;
                ViewData["Description"] = translation?.MetaDescription ?? translation?.Description ?? product.Description;
                ViewData["Keywords"] = translation?.MetaKeywords;
                ViewData["CurrentCulture"] = culture;
                ViewData["CurrentTranslation"] = translation;

                return View("Details", product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving product details for slug: {Slug}, culture: {Culture}", slug, culture);
                return View("Error");
            }
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                // Get product with all details (category, images, variants, colors, sizes)
                var product = await _unitOfWork.Products.GetProductWithDetailsAsync(id);

                if (product == null)
                {
                    return View("ProductNotFound");
                }

                // Check if product is unavailable (inactive/archived)
                if (!product.IsActive)
                {
                    // Find alternative products from same group or category
                    List<Kokomija.Entity.Product> alternatives = new List<Kokomija.Entity.Product>();
                    
                    if (product.ProductGroupId.HasValue)
                    {
                        // Get active products from same group
                        alternatives = (await _unitOfWork.Products.FindAsync(p => 
                            p.ProductGroupId == product.ProductGroupId && 
                            p.IsActive && 
                            p.Id != id))
                            .Take(4)
                            .ToList();
                    }
                    
                    // If no group alternatives, try same category
                    if (!alternatives.Any() && product.CategoryId.HasValue)
                    {
                        alternatives = (await _unitOfWork.Products.GetProductsByCategoryAsync(product.CategoryId.Value))
                            .Where(p => p.IsActive && p.Id != id)
                            .Take(4)
                            .ToList();
                    }
                    
                    ViewBag.ProductName = product.Name;
                    ViewBag.AlternativeProducts = alternatives;
                    return View("ProductUnavailable");
                }

                // If product is part of a group, load reviews for ALL products in the group
                if (product.ProductGroupId.HasValue)
                {
                    var groupProductIds = (await _unitOfWork.Products.FindAsync(p => 
                        p.ProductGroupId == product.ProductGroupId && p.IsActive))
                        .Select(p => p.Id)
                        .ToList();
                    
                    // Get all reviews for all products in the group
                    var allGroupReviews = new List<Kokomija.Entity.ProductReview>();
                    foreach (var productId in groupProductIds)
                    {
                        var reviews = await _unitOfWork.ProductReviews.GetProductReviewsAsync(productId, false);
                        allGroupReviews.AddRange(reviews);
                    }
                    
                    // Replace product reviews with combined group reviews
                    product.Reviews = allGroupReviews.OrderByDescending(r => r.CreatedAt).ToList();
                }

                // Get related products based on ProductGroup (different pack sizes)
                List<Kokomija.Entity.Product> relatedProducts;
                if (product.ProductGroupId.HasValue)
                {
                    // Get all products in the same group (different pack sizes)
                    relatedProducts = (await _unitOfWork.Products.FindAsync(p => 
                        p.ProductGroupId == product.ProductGroupId && 
                        p.Id != id && 
                        p.IsActive))
                        .OrderBy(p => p.PackSize)
                        .ToList();
                }
                else if (product.CategoryId.HasValue)
                {
                    // Fallback: Get products from same category
                    var categoryProducts = await _unitOfWork.Products.GetProductsByCategoryAsync(product.CategoryId.Value);
                    relatedProducts = categoryProducts.Where(p => p.Id != id && p.IsActive).ToList();
                }
                else
                {
                    relatedProducts = new List<Kokomija.Entity.Product>();
                }

                // Check if user is in business mode
                var isBusinessMode = await IsBusinessModeActiveAsync();
                ViewBag.IsBusinessMode = isBusinessMode;

                // If product is business-only and user is not in business mode, show unavailable
                if (product.IsBusinessOnly && !isBusinessMode)
                {
                    ViewBag.ProductName = product.Name;
                    ViewBag.IsBusinessOnlyRestricted = true;
                    ViewBag.AlternativeProducts = relatedProducts.Where(p => !p.IsBusinessOnly).Take(4).ToList();
                    return View("ProductUnavailable");
                }

                // Filter related products based on business mode
                relatedProducts = FilterProductsForBusinessMode(relatedProducts, isBusinessMode).ToList();
                ViewBag.RelatedProducts = relatedProducts;

                // Set page metadata
                ViewData["Title"] = product.Name;
                ViewData["Description"] = product.Description;

                return View(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving product details for ID: {ProductId}", id);
                return View("Error");
            }
        }

        // GET: Product/Category/woman-tshirts
        public async Task<IActionResult> Category(string slug)
        {
            try
            {
                // Get category by slug with all products
                var category = await _unitOfWork.Categories.GetCategoryBySlugAsync(slug);

                if (category == null)
                {
                    return NotFound();
                }

                // Check if user is in business mode
                var isBusinessMode = await IsBusinessModeActiveAsync();
                ViewBag.IsBusinessMode = isBusinessMode;

                var products = await _unitOfWork.Products.GetProductsByCategoryAsync(category.Id);
                
                // Filter products based on business mode
                var filteredProducts = FilterProductsForBusinessMode(products, isBusinessMode);
                
                ViewBag.Category = category;
                return View("Index", filteredProducts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving category: {Slug}", slug);
                return View("Error");
            }
        }

        // GET: Product/Search?q=shirt
        public async Task<IActionResult> Search(string q)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(q))
                {
                    return RedirectToAction(nameof(Index));
                }

                // Check if user is in business mode
                var isBusinessMode = await IsBusinessModeActiveAsync();
                ViewBag.IsBusinessMode = isBusinessMode;

                var products = await _unitOfWork.Products.SearchProductsAsync(q);
                
                // Filter products based on business mode
                var filteredProducts = FilterProductsForBusinessMode(products, isBusinessMode);
                
                ViewBag.SearchQuery = q;
                return View("Index", filteredProducts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error searching products with query: {Query}", q);
                return View("Error");
            }
        }

        // Example: Get variants for a product (AJAX endpoint)
        [HttpGet]
        public async Task<IActionResult> GetVariants(int productId)
        {
            try
            {
                var variants = await _unitOfWork.ProductVariants.GetVariantsByProductIdAsync(productId);
                
                var result = variants.Select(v => new
                {
                    id = v.Id,
                    sku = v.SKU,
                    size = v.Size?.Name,
                    color = v.Color?.Name,
                    colorHex = v.Color?.HexCode,
                    price = v.Price,
                    stock = v.StockQuantity,
                    isAvailable = v.StockQuantity > 0
                });

                return Json(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving variants for product ID: {ProductId}", productId);
                return BadRequest();
            }
        }

        // Example: Get available colors for filtering (AJAX endpoint)
        // Returns only colors that are actually used by active products
        [HttpGet]
        public async Task<IActionResult> GetColors()
        {
            try
            {
                // Get distinct color IDs from active product variants
                var usedColorIds = (await _unitOfWork.Repository<Entity.ProductVariant>()
                    .FindAsync(v => v.ColorId.HasValue && v.IsActive, v => v.Product))
                    .Where(v => v.Product.IsActive)
                    .Select(v => v.ColorId!.Value)
                    .Distinct()
                    .ToList();

                // Get only the colors that are actually used
                var colors = await _unitOfWork.Colors.GetActiveColorsAsync();
                var usedColors = colors.Where(c => usedColorIds.Contains(c.Id)).ToList();
                
                var result = usedColors.Select(c => new
                {
                    id = c.Id,
                    name = c.Name,
                    displayName = c.DisplayName,
                    hexCode = c.HexCode
                });

                return Json(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving colors");
                return BadRequest();
            }
        }

        // API: Get specific color by ID
        [HttpGet("api/colors/{id}")]
        public async Task<IActionResult> GetColor(int id)
        {
            try
            {
                var color = await _unitOfWork.Colors.GetByIdAsync(id);
                if (color == null)
                    return NotFound();

                return Json(new { id = color.Id, name = color.DisplayName, hexCode = color.HexCode });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving color {ColorId}", id);
                return BadRequest();
            }
        }

        // Example: Get available sizes for filtering (AJAX endpoint)
        // Returns only sizes that are actually used by active products
        [HttpGet]
        public async Task<IActionResult> GetSizes()
        {
            try
            {
                // Get distinct size IDs from active product variants
                var usedSizeIds = (await _unitOfWork.Repository<Entity.ProductVariant>()
                    .FindAsync(v => v.SizeId.HasValue && v.IsActive, v => v.Product))
                    .Where(v => v.Product.IsActive)
                    .Select(v => v.SizeId!.Value)
                    .Distinct()
                    .ToList();

                // Get only the sizes that are actually used
                var sizes = await _unitOfWork.Sizes.GetActiveSizesAsync();
                var usedSizes = sizes.Where(s => usedSizeIds.Contains(s.Id)).ToList();
                
                var result = usedSizes.Select(s => new
                {
                    id = s.Id,
                    name = s.Name,
                    displayName = s.DisplayName
                });

                return Json(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving sizes");
                return BadRequest();
            }
        }

        // Returns pack quantities that are actually used by active products
        [HttpGet]
        public async Task<IActionResult> GetPackQuantities()
        {
            try
            {
                // Get distinct pack quantity IDs from active product variants
                var usedPackIds = (await _unitOfWork.Repository<Entity.ProductVariant>()
                    .FindAsync(v => v.PackQuantityId.HasValue && v.IsActive, v => v.Product, v => v.PackQuantity!))
                    .Where(v => v.Product is not null && v.Product.IsActive && v.PackQuantity is not null)
                    .Select(v => v.PackQuantityId!.Value)
                    .Distinct()
                    .ToList();

                if (usedPackIds.Count == 0)
                {
                    return Json(new List<object>());
                }

                // Get only the pack quantities that are actually used
                var allPacks = await _unitOfWork.Repository<Entity.PackQuantity>().GetAllAsync();
                var usedPacks = allPacks
                    .Where(p => usedPackIds.Contains(p.Id))
                    .OrderBy(p => p.Quantity)
                    .ToList();

                var result = usedPacks.Select(p => new
                {
                    id = p.Id,
                    name = p.Name ?? string.Empty,
                    quantity = p.Quantity,
                    displayName = $"{p.Quantity}x"
                }).ToList();

                return Json(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving pack quantities");
                return BadRequest();
            }
        }

        // API: Get specific size by ID
        [HttpGet("api/sizes/{id}")]
        public async Task<IActionResult> GetSize(int id)
        {
            try
            {
                var size = await _unitOfWork.Sizes.GetByIdAsync(id);
                if (size == null)
                    return NotFound();

                return Json(new { id = size.Id, name = size.DisplayName });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving size {SizeId}", id);
                return BadRequest();
            }
        }

        // API: Get product by ID with details
        [HttpGet("api/products/{id}")]
        public async Task<IActionResult> GetProductApi(int id)
        {
            try
            {
                var product = await _unitOfWork.Products.GetProductWithDetailsAsync(id);
                if (product == null)
                    return NotFound();

                return Json(new
                {
                    id = product.Id,
                    name = product.Name,
                    price = product.Price,
                    images = product.Images?.Select(img => new { imageUrl = img.ImageUrl }).ToList()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving product {ProductId}", id);
                return BadRequest();
            }
        }

        // Example: Get categories for filtering (AJAX endpoint)
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                #pragma warning disable CS8604 // ToListAsync never returns null
                var categories = await _unitOfWork.Categories.GetAllAsync(c => c.ParentCategory!) ?? Enumerable.Empty<Kokomija.Entity.Category>();
                #pragma warning restore CS8604
                
                if (!categories.Any())
                {
                    return Json(Array.Empty<object>());
                }
                
                // Return ALL categories (both parent and subcategories)
                // This allows the filter sidebar to show the complete category hierarchy
                var result = categories
                    .Where(c => c.IsActive)
                    .OrderBy(c => c.ParentCategoryId.HasValue ? 1 : 0) // Parents first, then children
                    .ThenBy(c => c.ParentCategory != null ? c.ParentCategory.DisplayOrder : c.DisplayOrder)
                    .ThenBy(c => c.DisplayOrder)
                    .Select(c => new
                    {
                        id = c.Id,
                        name = !string.IsNullOrEmpty(c.NameKey) ? _localizationService[c.NameKey] : c.Name,
                        slug = c.Slug,
                        parentId = c.ParentCategoryId,
                        parentName = c.ParentCategory != null && !string.IsNullOrEmpty(c.ParentCategory.NameKey) 
                            ? _localizationService[c.ParentCategory.NameKey] 
                            : (c.ParentCategory?.Name ?? "Other"),
                        isParent = !c.ParentCategoryId.HasValue // Indicates if this is a top-level category
                    })
                    .ToList();

                return Json(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving categories");
                return BadRequest();
            }
        }

        // Helper method to load related products for a product
        private async Task LoadRelatedProducts(Kokomija.Entity.Product product)
        {
            List<Kokomija.Entity.Product> relatedProducts;
            
            // If product is part of a group, load reviews for ALL products in the group
            if (product.ProductGroupId.HasValue)
            {
                var groupProductIds = (await _unitOfWork.Products.FindAsync(p => 
                    p.ProductGroupId == product.ProductGroupId && p.IsActive))
                    .Select(p => p.Id)
                    .ToList();
                
                // Get all reviews for all products in the group
                var allGroupReviews = new List<Kokomija.Entity.ProductReview>();
                foreach (var productId in groupProductIds)
                {
                    var reviews = await _unitOfWork.ProductReviews.GetProductReviewsAsync(productId, false);
                    allGroupReviews.AddRange(reviews);
                }
                
                // Replace product reviews with combined group reviews
                product.Reviews = allGroupReviews.OrderByDescending(r => r.CreatedAt).ToList();

                // Get all products in the same group (different pack sizes)
                relatedProducts = (await _unitOfWork.Products.FindAsync(p => 
                    p.ProductGroupId == product.ProductGroupId && 
                    p.Id != product.Id && 
                    p.IsActive))
                    .OrderBy(p => p.PackSize)
                    .ToList();
            }
            else if (product.CategoryId.HasValue)
            {
                // Fallback: Get products from same category
                var categoryProducts = await _unitOfWork.Products.GetProductsByCategoryAsync(product.CategoryId.Value);
                relatedProducts = categoryProducts.Where(p => p.Id != product.Id && p.IsActive).ToList();
            }
            else
            {
                relatedProducts = new List<Kokomija.Entity.Product>();
            }

            ViewBag.RelatedProducts = relatedProducts;
        }

        // Helper method to generate localized product URL
        public static string GetLocalizedProductUrl(Kokomija.Entity.Product product, string culture)
        {
            // Find translation for the culture
            var translation = product.Translations?.FirstOrDefault(t => t.CultureCode.StartsWith(culture));
            var slug = translation?.Slug ?? product.Slug ?? product.Id.ToString();

            // Get the localized path segment
            var productPath = culture switch
            {
                "pl" => "produkt",
                "tr" => "urun",
                _ => "product"
            };

            return $"/{culture}/{productPath}/{slug}";
        }
        
        /// <summary>
        /// Normalizes a slug for comparison - converts Polish characters to ASCII and handles multiple dashes
        /// </summary>
        private static string NormalizeSlugForComparison(string slug)
        {
            if (string.IsNullOrEmpty(slug))
                return slug;
            
            // URL decode first
            slug = System.Net.WebUtility.UrlDecode(slug);
            
            // Convert to lowercase
            slug = slug.ToLowerInvariant();
            
            // Polish character mappings
            var polishMappings = new Dictionary<char, char>
            {
                {'ą', 'a'}, {'ć', 'c'}, {'ę', 'e'}, {'ł', 'l'}, {'ń', 'n'},
                {'ó', 'o'}, {'ś', 's'}, {'ź', 'z'}, {'ż', 'z'},
                {'Ą', 'a'}, {'Ć', 'c'}, {'Ę', 'e'}, {'Ł', 'l'}, {'Ń', 'n'},
                {'Ó', 'o'}, {'Ś', 's'}, {'Ź', 'z'}, {'Ż', 'z'}
            };
            
            var result = new System.Text.StringBuilder();
            foreach (var c in slug)
            {
                if (polishMappings.TryGetValue(c, out var replacement))
                    result.Append(replacement);
                else
                    result.Append(c);
            }
            
            slug = result.ToString();
            
            // Replace multiple consecutive dashes with single dash
            while (slug.Contains("--"))
            {
                slug = slug.Replace("--", "-");
            }
            
            // Trim dashes from start and end
            slug = slug.Trim('-');
            
            return slug;
        }
    }
}
