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
                
                // Only show subcategories (actual product categories like Shorts, T-Shirts)
                // Filter out parent categories (Male, Female) by checking if they have a ParentCategoryId
                var result = categories
                    .Where(c => c.ParentCategoryId.HasValue && c.IsActive)
                    .OrderBy(c => c.ParentCategory != null ? c.ParentCategory.DisplayOrder : 0)
                    .ThenBy(c => c.DisplayOrder)
                    .Select(c => new
                    {
                        id = c.Id,
                        name = !string.IsNullOrEmpty(c.NameKey) ? _localizationService[c.NameKey] : c.Name,
                        slug = c.Slug,
                        parentId = c.ParentCategoryId,
                        parentName = c.ParentCategory != null && !string.IsNullOrEmpty(c.ParentCategory.NameKey) 
                            ? _localizationService[c.ParentCategory.NameKey] 
                            : (c.ParentCategory?.Name ?? "Other")
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
