using Kokomija.Data.Abstract;
using Microsoft.AspNetCore.Mvc;

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

        public ProductController(
            IUnitOfWork unitOfWork, 
            ILogger<ProductController> logger,
            Kokomija.Services.ILocalizationService localizationService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _localizationService = localizationService;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            try
            {
                // Get all active products with their primary images
                var products = await _unitOfWork.Products.GetActiveProductsAsync();
                return View(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving products");
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
                    return NotFound();
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

                var products = await _unitOfWork.Products.GetProductsByCategoryAsync(category.Id);
                
                ViewBag.Category = category;
                return View("Index", products);
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

                var products = await _unitOfWork.Products.SearchProductsAsync(q);
                
                ViewBag.SearchQuery = q;
                return View("Index", products);
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
        [HttpGet]
        public async Task<IActionResult> GetColors()
        {
            try
            {
                var colors = await _unitOfWork.Colors.GetActiveColorsAsync();
                
                var result = colors.Select(c => new
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
        [HttpGet]
        public async Task<IActionResult> GetSizes()
        {
            try
            {
                var sizes = await _unitOfWork.Sizes.GetActiveSizesAsync();
                
                var result = sizes.Select(s => new
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
    }
}
