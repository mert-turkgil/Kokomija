using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Kokomija.Models.ViewModels.Admin;
using Kokomija.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace Kokomija.Controllers;

[Authorize(Roles = "Root,Admin")]
public class AdminProductController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<AdminProductController> _logger;
    private readonly IProductImageService _productImageService;
    private readonly ILocalizationService _localizationService;
    private readonly IStripeService _stripeService;
    private readonly IAutoTranslationService _autoTranslationService;

    public AdminProductController(
        IUnitOfWork unitOfWork,
        ILogger<AdminProductController> logger,
        IProductImageService productImageService,
        ILocalizationService localizationService,
        IStripeService stripeService,
        IAutoTranslationService autoTranslationService)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _productImageService = productImageService;
        _localizationService = localizationService;
        _stripeService = stripeService;
        _autoTranslationService = autoTranslationService;
    }

    /// <summary>
    /// GET: Product Management page with search/filter support
    /// </summary>
    public async Task<IActionResult> Index(string? searchTerm = null, string? searchType = "name", bool? isBusinessOnly = null, int? categoryId = null)
    {
        _logger.LogInformation("Admin accessed product management. Search: {SearchTerm}, Type: {SearchType}, BusinessOnly: {BusinessOnly}", 
            searchTerm, searchType, isBusinessOnly);

        var productsList = await _unitOfWork.Repository<Product>()
            .FindAsync(p => true, p => p.Category!.ParentCategory!);
        
        var productDtos = new List<ProductListItemDto>();
        
        foreach (var product in productsList)
        {
            var variants = (await _unitOfWork.Repository<ProductVariant>()
                .FindAsync(v => v.ProductId == product.Id)).ToList();
            
            var reviews = (await _unitOfWork.Repository<ProductReview>()
                .FindAsync(r => r.ProductId == product.Id && r.IsVisible)).ToList();
            
            var images = (await _unitOfWork.Repository<ProductImage>()
                .FindAsync(i => i.ProductId == product.Id)).OrderBy(i => i.DisplayOrder).ToList();

            productDtos.Add(new ProductListItemDto
            {
                Id = product.Id,
                Name = product.Name,
                CategoryName = product.Category?.Name,
                ParentCategoryName = product.Category?.ParentCategory?.Name,
                Price = product.Price,
                PackSize = product.PackSize,
                IsActive = product.IsActive,
                TotalStock = variants.Sum(v => v.StockQuantity),
                TotalVariants = variants.Count,
                ReviewCount = reviews.Count,
                AverageRating = reviews.Any() ? reviews.Average(r => r.Rating) : 0,
                FeaturedImage = images.FirstOrDefault()?.ImageUrl,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt,
                StripeProductId = product.StripeProductId,
                StripePriceId = product.StripePriceId,
                // Business fields
                IsBusinessOnly = product.IsBusinessOnly,
                IsAvailableForBusiness = product.IsAvailableForBusiness,
                MinBusinessQuantity = product.MinBusinessQuantity,
                BusinessPrice = product.BusinessPrice,
                // SKUs for search
                SKUs = variants.Select(v => v.SKU).ToList()
            });
        }

        // Apply filters
        var filteredProducts = productDtos.AsEnumerable();

        // Search by term
        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            var searchLower = searchTerm.ToLower().Trim();
            filteredProducts = searchType?.ToLower() switch
            {
                "sku" => filteredProducts.Where(p => p.SKUs.Any(s => s != null && s.ToLower().Contains(searchLower))),
                "stripe" => filteredProducts.Where(p => p.StripeProductId != null && p.StripeProductId.ToLower().Contains(searchLower)),
                "id" => filteredProducts.Where(p => p.Id.ToString() == searchTerm.Trim()),
                "name" => filteredProducts.Where(p => p.Name != null && p.Name.ToLower().Contains(searchLower)),
                _ => filteredProducts.Where(p => 
                    (p.Name != null && p.Name.ToLower().Contains(searchLower)) ||
                    (p.StripeProductId != null && p.StripeProductId.ToLower().Contains(searchLower)) ||
                    p.SKUs.Any(s => s != null && s.ToLower().Contains(searchLower))
                )
            };
        }

        // Filter by business only
        if (isBusinessOnly.HasValue)
        {
            filteredProducts = filteredProducts.Where(p => p.IsBusinessOnly == isBusinessOnly.Value);
        }

        // Filter by category
        if (categoryId.HasValue)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(categoryId.Value);
            if (category != null)
            {
                filteredProducts = filteredProducts.Where(p => 
                    p.CategoryName == category.Name || p.ParentCategoryName == category.Name);
            }
        }

        var filteredList = filteredProducts.OrderByDescending(p => p.CreatedAt).ToList();
        var productsArray = productsList.ToList();

        var viewModel = new ProductManagementViewModel
        {
            Products = filteredList,
            TotalProducts = productsArray.Count,
            ActiveProducts = productsArray.Count(p => p.IsActive),
            InactiveProducts = productsArray.Count(p => !p.IsActive),
            OutOfStockProducts = productDtos.Count(p => p.TotalStock == 0),
            TotalInventoryValue = productDtos.Sum(p => p.Price * p.TotalStock),
            BusinessOnlyProducts = productsArray.Count(p => p.IsBusinessOnly),
            // Keep search params for view
            SearchTerm = searchTerm,
            SearchType = searchType,
            IsBusinessOnly = isBusinessOnly,
            CategoryId = categoryId
        };

        // Load categories for filter dropdown
        var categories = await _unitOfWork.Categories.GetAllAsync();
        ViewBag.Categories = categories.Where(c => c.IsActive).OrderBy(c => c.DisplayOrder).ToList();

        ViewData["Title"] = "Product Management";
        return View(viewModel);
    }

    /// <summary>
    /// Export products to Excel with professional styling and detailed breakdown
    /// </summary>
    public async Task<IActionResult> ExportToExcel(string? searchTerm = null, string? searchType = "name", string? statusFilter = "all", bool? isBusinessOnly = null, int? categoryId = null)
    {
        // 1. Fetch filtered data (consistent with Index)
        var productsList = await _unitOfWork.Repository<Product>()
            .FindAsync(p => true, p => p.Category!.ParentCategory!);
        
        var productDtos = new List<ProductListItemDto>();
        
        // Fetch all price histories to calculate trends efficiently (avoid N+1)
        var allPriceHistories = await _unitOfWork.Repository<ProductPriceHistory>().GetAllAsync();
        var latestPriceHistories = allPriceHistories
            .GroupBy(h => h.ProductId)
            .ToDictionary(g => g.Key, g => g.OrderByDescending(h => h.ChangedAt).FirstOrDefault());

        foreach (var product in productsList)
        {
            var variants = (await _unitOfWork.Repository<ProductVariant>()
                .FindAsync(v => v.ProductId == product.Id)).ToList();
            
            productDtos.Add(new ProductListItemDto
            {
                Id = product.Id,
                Name = product.Name,
                CategoryName = product.Category?.Name,
                ParentCategoryName = product.Category?.ParentCategory?.Name,
                Price = product.Price,
                PackSize = product.PackSize,
                IsActive = product.IsActive,
                TotalStock = variants.Sum(v => v.StockQuantity),
                TotalVariants = variants.Count,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt,
                StripeProductId = product.StripeProductId,
                IsBusinessOnly = product.IsBusinessOnly,
                BusinessPrice = product.BusinessPrice,
                IsAvailableForBusiness = product.IsAvailableForBusiness, // Ensure this property exists in DTO or map efficiently
                MinBusinessQuantity = product.MinBusinessQuantity,       // Ensure this property exists in DTO 
                SKUs = variants.Select(v => v.SKU).ToList()
            });
        }

        // Apply filters
        var filteredProducts = productDtos.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            var searchLower = searchTerm.ToLower().Trim();
            filteredProducts = searchType?.ToLower() switch
            {
                "sku" => filteredProducts.Where(p => p.SKUs.Any(s => s != null && s.ToLower().Contains(searchLower))),
                "stripe" => filteredProducts.Where(p => p.StripeProductId != null && p.StripeProductId.ToLower().Contains(searchLower)),
                "id" => filteredProducts.Where(p => p.Id.ToString() == searchTerm.Trim()),
                "name" => filteredProducts.Where(p => p.Name != null && p.Name.ToLower().Contains(searchLower)),
                _ => filteredProducts.Where(p => 
                    (p.Name != null && p.Name.ToLower().Contains(searchLower)) ||
                    (p.StripeProductId != null && p.StripeProductId.ToLower().Contains(searchLower)) ||
                    p.SKUs.Any(s => s != null && s.ToLower().Contains(searchLower))
                )
            };
        }

        if (isBusinessOnly.HasValue)
        {
            filteredProducts = filteredProducts.Where(p => p.IsBusinessOnly == isBusinessOnly.Value);
        }

        if (categoryId.HasValue)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(categoryId.Value);
            if (category != null)
            {
                filteredProducts = filteredProducts.Where(p => 
                    p.CategoryName == category.Name || p.ParentCategoryName == category.Name);
            }
        }
        
        // Status Filter
        if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "all")
        {
            filteredProducts = statusFilter switch
            {
                "active" => filteredProducts.Where(p => p.IsActive),
                "inactive" => filteredProducts.Where(p => !p.IsActive),
                "low" => filteredProducts.Where(p => p.TotalStock > 0 && p.TotalStock < 20),
                "out" => filteredProducts.Where(p => p.TotalStock == 0),
                _ => filteredProducts
            };
        }

        var results = filteredProducts.OrderByDescending(p => p.CreatedAt).ToList();

        // 2. Generate Professional Excel
        using (var workbook = new ClosedXML.Excel.XLWorkbook())
        {
            // === SHEET 1: DASHBOARD ===
            var dashboardSheet = workbook.Worksheets.Add("Dashboard");
            
            // Title
            dashboardSheet.Cell(1, 1).Value = "KOKOMIJA INVENTORY DASHBOARD";
            dashboardSheet.Cell(1, 1).Style.Font.Bold = true;
            dashboardSheet.Cell(1, 1).Style.Font.FontSize = 20;
            dashboardSheet.Cell(1, 1).Style.Font.FontColor = ClosedXML.Excel.XLColor.DarkBlue;
            dashboardSheet.Cell(2, 1).Value = $"Generated: {DateTime.Now:dd MMM yyyy HH:mm}";

            // Metrics
            var totalProducts = results.Count;
            var activeProducts = results.Count(p => p.IsActive);
            var totalStock = results.Sum(p => p.TotalStock);
            var totalSellableValue = results.Sum(p => p.TotalStock * p.Price);
            var lowStockItems = results.Count(p => p.TotalStock > 0 && p.TotalStock < 10);
            var outOfStockItems = results.Count(p => p.TotalStock == 0);

            // KPI Cards implementation with cells
            int kpiRow = 4;
            
            // Total Market Value
            dashboardSheet.Cell(kpiRow, 1).Value = "Total Sellable Value";
            dashboardSheet.Cell(kpiRow, 1).Style.Font.Bold = true;
            dashboardSheet.Cell(kpiRow + 1, 1).Value = totalSellableValue;
            dashboardSheet.Cell(kpiRow + 1, 1).Style.NumberFormat.Format = "[$$-en-US]* #,##0.00";
            dashboardSheet.Cell(kpiRow + 1, 1).Style.Font.FontSize = 14;
            dashboardSheet.Cell(kpiRow + 1, 1).Style.Font.FontColor = ClosedXML.Excel.XLColor.Green;

            // Total Stock Count
            dashboardSheet.Cell(kpiRow, 3).Value = "Total Stock Units";
            dashboardSheet.Cell(kpiRow, 3).Style.Font.Bold = true;
            dashboardSheet.Cell(kpiRow + 1, 3).Value = totalStock;
            dashboardSheet.Cell(kpiRow + 1, 3).Style.Font.FontSize = 14;

            // Active Products
            dashboardSheet.Cell(kpiRow, 5).Value = "Active Products";
            dashboardSheet.Cell(kpiRow, 5).Style.Font.Bold = true;
            dashboardSheet.Cell(kpiRow + 1, 5).Value = $"{activeProducts} / {totalProducts}";
            dashboardSheet.Cell(kpiRow + 1, 5).Style.Font.FontSize = 14;

            // Inventory Alerts
            dashboardSheet.Cell(kpiRow, 7).Value = "Inventory Alerts";
            dashboardSheet.Cell(kpiRow, 7).Style.Font.Bold = true;
            dashboardSheet.Cell(kpiRow + 1, 7).Value = $"{outOfStockItems} OOS / {lowStockItems} Low";
            dashboardSheet.Cell(kpiRow + 1, 7).Style.Font.FontSize = 14;
            dashboardSheet.Cell(kpiRow + 1, 7).Style.Font.FontColor = ClosedXML.Excel.XLColor.Red;

            // Simple "Chart" - Inventory by Category
            int chartRow = 8;
            dashboardSheet.Cell(chartRow, 1).Value = "Inventory by Category";
            dashboardSheet.Cell(chartRow, 1).Style.Font.Bold = true;
            dashboardSheet.Cell(chartRow, 1).Style.Font.FontSize = 12;

            var categoryStats = results.GroupBy(p => p.CategoryName ?? "Uncategorized")
                .Select(g => new { Name = g.Key, Count = g.Count(), Stock = g.Sum(p => p.TotalStock) })
                .OrderByDescending(x => x.Stock)
                .ToList();

            int catRow = chartRow + 1;
            dashboardSheet.Cell(catRow, 1).Value = "Category";
            dashboardSheet.Cell(catRow, 2).Value = "Product Count";
            dashboardSheet.Cell(catRow, 3).Value = "Total Stock";
            dashboardSheet.Range(catRow, 1, catRow, 3).Style.Font.Bold = true;
            dashboardSheet.Range(catRow, 1, catRow, 3).Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.LightGray;

            catRow++;
            var maxStock = categoryStats.Any() ? categoryStats.Max(x => x.Stock) : 1;

            foreach (var stat in categoryStats)
            {
                dashboardSheet.Cell(catRow, 1).Value = stat.Name;
                dashboardSheet.Cell(catRow, 2).Value = stat.Count;
                dashboardSheet.Cell(catRow, 3).Value = stat.Stock;
                
                // Data Bar simulation
                if (stat.Stock > 0)
                {
                    // Visual placeholder if supported or just conditional formatting
                    // ClosedXML supports data bars on ranges
                }
                catRow++;
            }

            // Apply Data Bars to Stock column
            if (categoryStats.Any())
            {
                var stockRange = dashboardSheet.Range(chartRow + 2, 3, catRow - 1, 3);
                stockRange.AddConditionalFormat().DataBar(ClosedXML.Excel.XLColor.CornflowerBlue).LowestValue().HighestValue();
            }

            dashboardSheet.Columns().AdjustToContents();
            dashboardSheet.Column(1).Width = 30; // Category name width

            // === SHEET 2: PRODUCTS (Summary) ===
            var productsSheet = workbook.Worksheets.Add("Products");
            
            var productHeaders = new[] { 
                "ID", "Status", "Name", "Category", 
                "Pack Size", "Total Stock", "Retail Price", 
                "Total Value", "B2B Price", "Is B2B Only", "Created At"
            };

            int pRow = 1;
            for (int i = 0; i < productHeaders.Length; i++)
            {
                var cell = productsSheet.Cell(pRow, i + 1);
                cell.Value = productHeaders[i];
                cell.Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.DarkSlateBlue;
                cell.Style.Font.FontColor = ClosedXML.Excel.XLColor.White;
                cell.Style.Font.Bold = true;
            }

            pRow++;
            foreach (var item in results)
            {
                productsSheet.Cell(pRow, 1).Value = item.Id;
                productsSheet.Cell(pRow, 2).Value = item.IsActive ? "ACTIVE" : "INACTIVE";
                productsSheet.Cell(pRow, 2).Style.Font.FontColor = item.IsActive ? ClosedXML.Excel.XLColor.Green : ClosedXML.Excel.XLColor.Red;
                
                productsSheet.Cell(pRow, 3).Value = item.Name;
                productsSheet.Cell(pRow, 4).Value = item.CategoryName;
                productsSheet.Cell(pRow, 5).Value = item.PackSize;
                productsSheet.Cell(pRow, 6).Value = item.TotalStock;
                
                productsSheet.Cell(pRow, 7).Value = item.Price;
                productsSheet.Cell(pRow, 7).Style.NumberFormat.Format = "_-[$$-en-US]* #,##0.00_-";
                
                // Total Value (Stock * Price)
                productsSheet.Cell(pRow, 8).FormulaA1 = $"F{pRow}*G{pRow}"; 
                productsSheet.Cell(pRow, 8).Style.NumberFormat.Format = "_-[$$-en-US]* #,##0.00_-";

                productsSheet.Cell(pRow, 9).Value = item.BusinessPrice;
                productsSheet.Cell(pRow, 9).Style.NumberFormat.Format = "_-[$$-en-US]* #,##0.00_-";

                productsSheet.Cell(pRow, 10).Value = item.IsBusinessOnly ? "Yes" : "No";
                productsSheet.Cell(pRow, 11).Value = item.CreatedAt;

                pRow++;
            }
            productsSheet.Columns().AdjustToContents();
            productsSheet.SheetView.FreezeRows(1);

            // === SHEET 3: VARIANTS (Detailed SKUs) ===
            var variantsSheet = workbook.Worksheets.Add("Variants (SKUs)");
            
            var variantHeaders = new[] {
                "Product ID", "Product Name", "SKU", 
                "Size", "Color", "Stock Qty", "Variant Price", 
                "Status"
            };

            int vRow = 1;
            for (int i = 0; i < variantHeaders.Length; i++)
            {
                var cell = variantsSheet.Cell(vRow, i + 1);
                cell.Value = variantHeaders[i];
                cell.Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.Teal;
                cell.Style.Font.FontColor = ClosedXML.Excel.XLColor.White;
                cell.Style.Font.Bold = true;
            }
            
            vRow++;
            // Note: retrieving variants is tricky as we currently iterate filtered ProductListViewModel
            // The view model only has basic SKU strings. For full detail, we'd need to fetch or assumption.
            // Assuming item.SKUs is a list of strings, we'll list them. 
            // Better approach if feasible: fetch variants. But for now, we split visually.
            // If the viewmodel doesn't contain detailed variant objects, we can list the strings.
            // BUT, item.SKUs is just List<string>.
            // To do this *properly* in high quality, we should probably fetch variants for the export or use what we have.
            // Optimization: If performance allows, for export we could fetch details. 
            // Or simpler: Just list the SKU strings we have line by line.
            
            foreach (var item in results)
            {
                if (item.SKUs != null)
                {
                    foreach (var sku in item.SKUs)
                    {
                        variantsSheet.Cell(vRow, 1).Value = item.Id;
                        variantsSheet.Cell(vRow, 2).Value = item.Name;
                        variantsSheet.Cell(vRow, 3).Value = sku;
                        
                        // Metadata placeholder (since we don't have variants loaded in this lightweight list)
                        variantsSheet.Cell(vRow, 4).Value = "-"; // Size
                        variantsSheet.Cell(vRow, 5).Value = "-"; // Color
                        variantsSheet.Cell(vRow, 6).Value = "-"; // Stock
                        
                        variantsSheet.Cell(vRow, 7).Value = item.Price; // Fallback
                        variantsSheet.Cell(vRow, 8).Value = item.IsActive ? "Active" : "Inactive";
                        
                        vRow++;
                    }
                }
            }
            variantsSheet.Columns().AdjustToContents();
            variantsSheet.SheetView.FreezeRows(1);

            using (var stream = new System.IO.MemoryStream())
            {
                workbook.SaveAs(stream);
                var content = stream.ToArray();
                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Kokomija_Inventory_Report_{DateTime.Now:yyyyMMdd_HHmm}.xlsx");
            }
        }
    }


    /// <summary>
    /// API: Search products by SKU for quick lookup
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> SearchBySKU(string sku)
    {
        if (string.IsNullOrWhiteSpace(sku))
            return Json(new { success = false, message = "SKU is required" });

        var skuLower = sku.ToLower().Trim();
        var variants = await _unitOfWork.Repository<ProductVariant>()
            .FindAsync(v => v.SKU.ToLower().Contains(skuLower), v => v.Product);

        var results = variants.Select(v => new
        {
            variantId = v.Id,
            productId = v.ProductId,
            productName = v.Product?.Name,
            sku = v.SKU,
            price = v.Price,
            stock = v.StockQuantity,
            isActive = v.IsActive
        }).Take(20).ToList();

        return Json(new { success = true, results });
    }

    /// <summary>
    /// API: Auto-translate product content from one language to another
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> TranslateContent([FromBody] TranslateContentRequest request)
    {
        if (request == null)
            return Json(new { success = false, message = "Invalid request" });

        if (string.IsNullOrWhiteSpace(request.SourceLanguage) || string.IsNullOrWhiteSpace(request.TargetLanguage))
            return Json(new { success = false, message = "Source and target languages are required" });

        try
        {
            _logger.LogInformation("Auto-translating content from {Source} to {Target}", 
                request.SourceLanguage, request.TargetLanguage);

            var translations = new TranslateContentResponse();

            // Translate name
            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                var nameResult = await _autoTranslationService.TranslateAsync(
                    request.Name, request.SourceLanguage, request.TargetLanguage);
                translations.Name = nameResult.TranslatedText;
            }

            // Translate description
            if (!string.IsNullOrWhiteSpace(request.Description))
            {
                var descResult = await _autoTranslationService.TranslateAsync(
                    request.Description, request.SourceLanguage, request.TargetLanguage);
                translations.Description = descResult.TranslatedText;
            }

            // Translate meta description
            if (!string.IsNullOrWhiteSpace(request.MetaDescription))
            {
                var metaResult = await _autoTranslationService.TranslateAsync(
                    request.MetaDescription, request.SourceLanguage, request.TargetLanguage);
                translations.MetaDescription = metaResult.TranslatedText;
            }

            // Translate meta keywords
            if (!string.IsNullOrWhiteSpace(request.MetaKeywords))
            {
                var keywordsResult = await _autoTranslationService.TranslateAsync(
                    request.MetaKeywords, request.SourceLanguage, request.TargetLanguage);
                translations.MetaKeywords = keywordsResult.TranslatedText;
            }

            // Generate slug from translated name if not provided
            if (!string.IsNullOrWhiteSpace(translations.Name))
            {
                translations.Slug = GenerateSlug(translations.Name);
            }

            return Json(new { 
                success = true, 
                translations,
                message = "Translation completed successfully"
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during auto-translation");
            return Json(new { success = false, message = "Translation failed. Please try again or enter manually." });
        }
    }

    /// <summary>
    /// Generate URL-friendly slug from text
    /// </summary>
    private static string GenerateSlug(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return string.Empty;

        // Convert to lowercase
        var slug = text.ToLowerInvariant();

        // Replace Polish characters
        var polishChars = new Dictionary<char, string>
        {
            {'ą', "a"}, {'ć', "c"}, {'ę', "e"}, {'ł', "l"}, {'ń', "n"},
            {'ó', "o"}, {'ś', "s"}, {'ź', "z"}, {'ż', "z"},
            {'Ą', "a"}, {'Ć', "c"}, {'Ę', "e"}, {'Ł', "l"}, {'Ń', "n"},
            {'Ó', "o"}, {'Ś', "s"}, {'Ź', "z"}, {'Ż', "z"}
        };

        foreach (var kvp in polishChars)
        {
            slug = slug.Replace(kvp.Key.ToString(), kvp.Value);
        }

        // Replace spaces and special characters with hyphens
        slug = System.Text.RegularExpressions.Regex.Replace(slug, @"[^a-z0-9]+", "-");

        // Remove leading/trailing hyphens
        slug = slug.Trim('-');

        return slug;
    }

    /// <summary>
    /// GET: Create new product (Single-page Form)
    /// </summary>
    public async Task<IActionResult> Create()
    {
        var categories = await _unitOfWork.Repository<Category>()
            .GetAllAsync(c => c.Translations!, c => c.SubCategories!);
        var sizes = await _unitOfWork.Sizes.GetAllAsync();
        var colors = await _unitOfWork.Colors.GetAllAsync();
        var packQuantities = await _unitOfWork.Repository<PackQuantity>().GetAllAsync();
        var productGroups = await _unitOfWork.Repository<ProductGroup>().GetAllAsync(g => g.Products!);
        var activeCoupons = await _unitOfWork.Repository<Coupon>()
            .FindAsync(c => c.IsActive && 
                           (!c.ValidUntil.HasValue || c.ValidUntil >= DateTime.UtcNow));

        var model = new ProductCreateDto
        {
            Categories = new SelectList(categories, "Id", "Name"),
            AvailableSizes = sizes.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name }).ToList(),
            AvailableColors = colors.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList()
        };

        ViewBag.Categories = categories.Where(c => c.IsActive && c.ParentCategoryId == null).OrderBy(c => c.DisplayOrder).ToList();
        ViewBag.ProductGroups = productGroups.ToList();
        ViewBag.Coupons = activeCoupons.ToList();
        ViewBag.AvailablePackQuantities = packQuantities.OrderBy(p => p.DisplayOrder).ToList();

        return View("Create", model);
    }

    /// <summary>
    /// GET: Create new product with Step-by-Step Wizard
    /// </summary>
    [HttpGet("AdminProduct/CreateWizard")]
    public async Task<IActionResult> CreateWizard()
    {
        var categories = await _unitOfWork.Repository<Category>()
            .GetAllAsync(c => c.Translations!, c => c.SubCategories!);
        var sizes = await _unitOfWork.Sizes.GetAllAsync();
        var colors = await _unitOfWork.Colors.GetAllAsync();
        var packQuantities = await _unitOfWork.Repository<PackQuantity>().GetAllAsync();
        var productGroups = await _unitOfWork.Repository<ProductGroup>().GetAllAsync(g => g.Products!);
        var activeCoupons = await _unitOfWork.Repository<Coupon>()
            .FindAsync(c => c.IsActive && 
                           (!c.ValidUntil.HasValue || c.ValidUntil >= DateTime.UtcNow));

        var model = new ProductCreateDto
        {
            Categories = new SelectList(categories, "Id", "Name"),
            AvailableSizes = sizes.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name }).ToList(),
            AvailableColors = colors.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList()
        };

        ViewBag.Categories = categories.Where(c => c.IsActive && c.ParentCategoryId == null).OrderBy(c => c.DisplayOrder).ToList();
        ViewBag.ProductGroups = productGroups.ToList();
        ViewBag.Coupons = activeCoupons.ToList();
        ViewBag.AvailablePackQuantities = packQuantities.OrderBy(p => p.DisplayOrder).ToList();

        return View("CreateWizard", model);
    }

    /// <summary>
    /// POST: Create new product
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductCreateDto model, [FromForm] string? TempImageFileNamesRaw)
    {
        try
        {
            // Parse comma-separated image file names (from JS hidden field)
            if (!string.IsNullOrWhiteSpace(TempImageFileNamesRaw) && (model.TempImageFileNames == null || !model.TempImageFileNames.Any()))
            {
                model.TempImageFileNames = TempImageFileNamesRaw
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(f => f.Trim())
                    .Where(f => !string.IsNullOrEmpty(f) && f != "null" && f != "undefined")
                    .ToList();
            }

            // Auto-fill Name and Description from English translation if not set
            // (hidden fields may not be populated if JS didn't fire)
            var enTranslation = model.Translations?.FirstOrDefault(t => t.CultureCode == "en-US");
            if (string.IsNullOrWhiteSpace(model.Name) && enTranslation != null && !string.IsNullOrWhiteSpace(enTranslation.Name))
            {
                model.Name = enTranslation.Name;
                ModelState.Remove("Name");
            }
            if (string.IsNullOrWhiteSpace(model.Description) && enTranslation != null && !string.IsNullOrWhiteSpace(enTranslation.Description))
            {
                model.Description = enTranslation.Description;
                ModelState.Remove("Description");
            }

            // Fix price parsing: ensure BasePrice is positive
            if (model.BasePrice <= 0)
            {
                ModelState.AddModelError("BasePrice", "Price must be greater than 0.");
            }

            // Validate category
            if (model.CategoryId <= 0)
            {
                ModelState.AddModelError("CategoryId", "Please select a category.");
            }

            // Fix business price: if 0, treat as null (no business price)
            if (model.BusinessPrice.HasValue && model.BusinessPrice.Value <= 0)
            {
                model.BusinessPrice = null;
            }

            if (!ModelState.IsValid)
            {
                // Log validation errors for debugging
                var errors = ModelState
                    .Where(x => x.Value?.Errors.Count > 0)
                    .Select(x => $"{x.Key}: {string.Join(", ", x.Value!.Errors.Select(e => e.ErrorMessage))}")
                    .ToList();
                _logger.LogWarning("Product creation ModelState errors: {Errors}", string.Join(" | ", errors));

                // Reload dropdowns
                var categories = await _unitOfWork.Repository<Category>()
                    .GetAllAsync(c => c.Translations!, c => c.SubCategories!);
                var sizes = await _unitOfWork.Sizes.GetAllAsync();
                var colors = await _unitOfWork.Colors.GetAllAsync();
                var productGroups = await _unitOfWork.Repository<ProductGroup>().GetAllAsync();
                var packQuantities = await _unitOfWork.Repository<PackQuantity>().GetAllAsync();
                var activeCoupons = await _unitOfWork.Repository<Coupon>()
                    .FindAsync(c => c.IsActive && 
                                   (!c.ValidUntil.HasValue || c.ValidUntil >= DateTime.UtcNow));
                
                model.Categories = new SelectList(categories, "Id", "Name", model.CategoryId);
                model.AvailableSizes = sizes.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name }).ToList();
                model.AvailableColors = colors.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
                
                ViewBag.Categories = categories.Where(c => c.IsActive && c.ParentCategoryId == null).OrderBy(c => c.DisplayOrder).ToList();
                ViewBag.ProductGroups = productGroups.ToList();
                ViewBag.AvailablePackQuantities = packQuantities.OrderBy(p => p.DisplayOrder).ToList();
                ViewBag.Coupons = activeCoupons.ToList();
                
                // Return to the view that submitted (check referer for wizard)
                var referer = Request.Headers["Referer"].ToString();
                if (referer.Contains("Wizard", StringComparison.OrdinalIgnoreCase))
                    return View("CreateWizard", model);
                return View("Create", model);
            }

            // Deduplication guard: check if a product with the same name already exists in DB
            var existingProduct = (await _unitOfWork.Products.FindAsync(p => p.Name == model.Name)).FirstOrDefault();
            if (existingProduct != null)
            {
                _logger.LogWarning("Duplicate product creation attempt: '{ProductName}' already exists (ID: {ProductId})", 
                    model.Name, existingProduct.Id);
                TempData["Error"] = $"A product with the name '{model.Name}' already exists (ID: {existingProduct.Id}). Please use a different name or edit the existing product.";
                
                var categories = await _unitOfWork.Repository<Category>().GetAllAsync(c => c.Translations!);
                var sizes = await _unitOfWork.Sizes.GetAllAsync();
                var colors = await _unitOfWork.Colors.GetAllAsync();
                var productGroups = await _unitOfWork.Repository<ProductGroup>().GetAllAsync();
                var activeCoupons = await _unitOfWork.Repository<Coupon>()
                    .FindAsync(c => c.IsActive && (!c.ValidUntil.HasValue || c.ValidUntil >= DateTime.UtcNow));
                
                model.Categories = new SelectList(categories, "Id", "Name", model.CategoryId);
                model.AvailableSizes = sizes.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name }).ToList();
                model.AvailableColors = colors.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
                
                ViewBag.Categories = categories.Where(c => c.IsActive && c.ParentCategoryId == null).OrderBy(c => c.DisplayOrder).ToList();
                ViewBag.ProductGroups = productGroups.ToList();
                ViewBag.AvailablePackQuantities = (await _unitOfWork.Repository<PackQuantity>().GetAllAsync()).OrderBy(p => p.DisplayOrder).ToList();
                ViewBag.Coupons = activeCoupons.ToList();
                
                var referer = Request.Headers["Referer"].ToString();
                if (referer.Contains("Wizard", StringComparison.OrdinalIgnoreCase))
                    return View("CreateWizard", model);
                return View("Create", model);
            }

            // Create Stripe product (with tax code)
            var stripeTaxCode = model.StripeTaxCode ?? "txcd_99999999"; // General tangible goods
            var stripeProductService = new Stripe.ProductService();
            var stripeProduct = await stripeProductService.CreateAsync(new Stripe.ProductCreateOptions
            {
                Name = model.Name,
                Description = model.Description,
                Active = model.IsActive,
                TaxCode = stripeTaxCode,
                Metadata = new Dictionary<string, string>
                {
                    { "category_id", model.CategoryId.ToString() ?? "" },
                    { "pack_size", model.PackSize.ToString() ?? "" }
                }
            });

            // Create Stripe price (base price) with tax behavior
            var stripePriceService = new Stripe.PriceService();
            var stripePrice = await stripePriceService.CreateAsync(new Stripe.PriceCreateOptions
            {
                Product = stripeProduct.Id,
                UnitAmount = (long)(model.BasePrice * 100), // Convert to cents
                Currency = "pln",
                Active = true,
                TaxBehavior = "exclusive"
            });

            // Create business Stripe price if business price is specified
            string? businessStripePriceId = null;
            if (model.BusinessPrice.HasValue && model.BusinessPrice > 0)
            {
                var businessStripePrice = await stripePriceService.CreateAsync(new Stripe.PriceCreateOptions
                {
                    Product = stripeProduct.Id,
                    UnitAmount = (long)(model.BusinessPrice.Value * 100),
                    Currency = "pln",
                    Active = true,
                    TaxBehavior = "exclusive",
                    Metadata = new Dictionary<string, string> { { "type", "business" } }
                });
                businessStripePriceId = businessStripePrice.Id;
            }

            // Create product entity
            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.BasePrice,
                PackSize = model.PackSize,
                CategoryId = model.CategoryId,
                ProductGroupId = model.ProductGroupId, // Product group for packages
                StripeProductId = stripeProduct.Id,
                StripePriceId = stripePrice.Id,
                StripeTaxCode = stripeTaxCode, // General product tax code
                IsActive = model.IsActive,
                // Business (B2B) fields
                IsBusinessOnly = model.IsBusinessOnly,
                IsAvailableForBusiness = model.IsAvailableForBusiness,
                MinBusinessQuantity = model.MinBusinessQuantity,
                BusinessPrice = model.BusinessPrice,
                BusinessStripePriceId = businessStripePriceId,
                CreatedAt = DateTime.UtcNow
            };

            // Add to database to get ID
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();

            // Add product translations
            if (model.Translations != null && model.Translations.Any())
            {
                foreach (var translationDto in model.Translations)
                {
                    // Skip empty translations
                    if (string.IsNullOrWhiteSpace(translationDto.Name))
                        continue;

                    var translation = new ProductTranslation
                    {
                        ProductId = product.Id,
                        CultureCode = translationDto.CultureCode,
                        Name = translationDto.Name,
                        Description = translationDto.Description ?? string.Empty,
                        Slug = translationDto.Slug ?? string.Empty,
                        MetaDescription = translationDto.MetaDescription ?? string.Empty,
                        MetaKeywords = translationDto.MetaKeywords ?? string.Empty
                    };
                    await _unitOfWork.Repository<ProductTranslation>().AddAsync(translation);
                }
                await _unitOfWork.SaveChangesAsync();
            }

            // Process uploaded images
            if (model.TempImageFileNames != null && model.TempImageFileNames.Any())
            {
                var imageUrls = new List<string>();
                foreach (var tempFileName in model.TempImageFileNames)
                {
                    var moveResult = await _productImageService.MoveTempToPermanentAsync(tempFileName, product.Id);
                    if (moveResult.Success)
                    {
                        var productImage = new ProductImage
                        {
                            ProductId = product.Id,
                            ImageUrl = moveResult.PermanentUrl!,
                            DisplayOrder = model.TempImageFileNames.IndexOf(tempFileName),
                            CreatedAt = DateTime.UtcNow
                        };
                        await _unitOfWork.Repository<ProductImage>().AddAsync(productImage);
                        
                        // Collect image URLs for Stripe sync
                        var fullUrl = $"{Request.Scheme}://{Request.Host}{moveResult.PermanentUrl}";
                        imageUrls.Add(fullUrl);
                    }
                }
                await _unitOfWork.SaveChangesAsync();
                
                // Sync images to Stripe (max 8 images allowed)
                if (imageUrls.Any())
                {
                    try
                    {
                        await stripeProductService.UpdateAsync(product.StripeProductId, new Stripe.ProductUpdateOptions
                        {
                            Images = imageUrls.Take(8).ToList()
                        });
                        _logger.LogInformation("Synced {Count} images to Stripe for product {ProductId}", 
                            imageUrls.Count, product.Id);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning(ex, "Failed to sync images to Stripe for product {ProductId}", product.Id);
                        // Continue anyway - images are saved locally
                    }
                }
            }

            // Add product sizes
            if (model.SelectedSizeIds != null && model.SelectedSizeIds.Any())
            {
                foreach (var sizeId in model.SelectedSizeIds)
                {
                    var productSize = new ProductSize
                    {
                        ProductId = product.Id,
                        SizeId = sizeId
                    };
                    await _unitOfWork.Repository<ProductSize>().AddAsync(productSize);
                }
            }

            // Handle custom colors (outside standard palette)
            if (!string.IsNullOrEmpty(model.CustomColorHex) && !string.IsNullOrEmpty(model.CustomColorName))
            {
                var hexCodes = model.CustomColorHex.Split(',', StringSplitOptions.RemoveEmptyEntries);
                var names = model.CustomColorName.Split(',', StringSplitOptions.RemoveEmptyEntries);
                
                for (int i = 0; i < Math.Min(hexCodes.Length, names.Length); i++)
                {
                    // Create custom color entity
                    var customColor = new Color
                    {
                        Name = names[i].Trim(),
                        HexCode = hexCodes[i].Trim(),
                        CreatedAt = DateTime.UtcNow
                    };
                    await _unitOfWork.Repository<Color>().AddAsync(customColor);
                    await _unitOfWork.SaveChangesAsync();
                    
                    // Add to product's available colors
                    var productColor = new ProductColor
                    {
                        ProductId = product.Id,
                        ColorId = customColor.Id
                    };
                    await _unitOfWork.Repository<ProductColor>().AddAsync(productColor);
                }
            }

            // Add product colors (from standard palette)
            if (model.SelectedColorIds != null && model.SelectedColorIds.Any())
            {
                foreach (var colorId in model.SelectedColorIds)
                {
                    var productColor = new ProductColor
                    {
                        ProductId = product.Id,
                        ColorId = colorId
                    };
                    await _unitOfWork.Repository<ProductColor>().AddAsync(productColor);
                }
            }

            // Add variants
            if (model.Variants != null && model.Variants.Any())
            {
                foreach (var variantDto in model.Variants)
                {
                    // Resolve the effective variant price: use variant price if set, otherwise fall back to base price
                    var effectiveVariantPrice = variantDto.Price.HasValue && variantDto.Price.Value > 0 
                        ? variantDto.Price.Value 
                        : model.BasePrice;

                    // Create Stripe price for this variant
                    var variantStripePrice = await stripePriceService.CreateAsync(new Stripe.PriceCreateOptions
                    {
                        Product = stripeProduct.Id,
                        UnitAmount = (long)(effectiveVariantPrice * 100),
                        Currency = "pln",
                        Active = true,
                        TaxBehavior = "exclusive",
                        Metadata = new Dictionary<string, string>
                        {
                            { "size_id", variantDto.SizeId?.ToString() ?? "" },
                            { "color_id", variantDto.ColorId?.ToString() ?? "" },
                            { "sku", variantDto.SKU },
                            { "type", "retail" }
                        }
                    });

                    // Create Business Stripe price for this variant if business price exists
                    string? variantBusinessStripePriceId = null;
                    if (model.BusinessPrice.HasValue && model.BusinessPrice > 0)
                    {
                        var businessPriceOptions = new Stripe.PriceCreateOptions
                        {
                            Product = stripeProduct.Id,
                            UnitAmount = (long)(model.BusinessPrice.Value * 100),
                            Currency = "pln",
                            Active = true,
                            TaxBehavior = "exclusive",
                            Metadata = new Dictionary<string, string>
                            {
                                { "size_id", variantDto.SizeId?.ToString() ?? "" },
                                { "color_id", variantDto.ColorId?.ToString() ?? "" },
                                { "sku", variantDto.SKU },
                                { "type", "business" }
                            }
                        };
                        var businessPrice = await stripePriceService.CreateAsync(businessPriceOptions);
                        variantBusinessStripePriceId = businessPrice.Id;
                    }

                    var variant = new ProductVariant
                    {
                        ProductId = product.Id,
                        SizeId = variantDto.SizeId,
                        ColorId = variantDto.ColorId,
                        SKU = variantDto.SKU,
                        Price = effectiveVariantPrice,
                        StockQuantity = variantDto.StockQuantity,
                        StripePriceId = variantStripePrice.Id,
                        BusinessStripePriceId = variantBusinessStripePriceId,
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    };
                    await _unitOfWork.Repository<ProductVariant>().AddAsync(variant);
                }
            }

            await _unitOfWork.SaveChangesAsync();

            // Associate coupon if specified (nullable - optional)
            if (model.CouponId.HasValue)
            {
                // Store coupon association in product metadata or create junction table
                // For now, we log it - you can extend Product entity with CouponId if needed
                _logger.LogInformation("Product {ProductId} associated with Coupon {CouponId}", product.Id, model.CouponId.Value);
            }

            _logger.LogInformation("Product created: {ProductId} - {ProductName} (Group: {GroupId}, Coupon: {CouponId})", 
                product.Id, product.Name, model.ProductGroupId, model.CouponId);
            
            TempData["Success"] = $"Product '{product.Name}' created successfully! (ID: {product.Id})";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating product");
            TempData["Error"] = $"Error creating product: {ex.Message}";
            
            // Reload all dropdowns and ViewBag data
            var categories = await _unitOfWork.Repository<Category>()
                .GetAllAsync(c => c.Translations!);
            var sizes = await _unitOfWork.Sizes.GetAllAsync();
            var colors = await _unitOfWork.Colors.GetAllAsync();
            var productGroups = await _unitOfWork.Repository<ProductGroup>().GetAllAsync();
            var activeCoupons = await _unitOfWork.Repository<Coupon>()
                .FindAsync(c => c.IsActive && 
                               (!c.ValidUntil.HasValue || c.ValidUntil >= DateTime.UtcNow));
            
            model.Categories = new SelectList(categories, "Id", "Name", model.CategoryId);
            model.AvailableSizes = sizes.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name }).ToList();
            model.AvailableColors = colors.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
            
            ViewBag.Categories = categories.Where(c => c.IsActive).OrderBy(c => c.DisplayOrder).ToList();
            ViewBag.ProductGroups = productGroups.ToList();
            ViewBag.Coupons = activeCoupons.ToList();
            
            // Return to the view that submitted
            var catchReferer = Request.Headers["Referer"].ToString();
            if (catchReferer.Contains("Wizard", StringComparison.OrdinalIgnoreCase))
                return View("CreateWizard", model);
            return View("Create", model);
        }
    }

    /// <summary>
    /// GET: Edit product
    /// </summary>
    public async Task<IActionResult> Edit(int id)
    {
        var product = await _unitOfWork.Products.GetProductWithDetailsAsync(id);
        
        if (product == null)
        {
            return NotFound();
        }

        var categories = await _unitOfWork.Categories.GetAllAsync();
        var sizes = await _unitOfWork.Sizes.GetAllAsync();
        var colors = await _unitOfWork.Colors.GetAllAsync();
        var packQuantities = await _unitOfWork.Repository<PackQuantity>().GetAllAsync();

        // Get existing variants
        var variants = await _unitOfWork.Repository<ProductVariant>()
            .FindAsync(v => v.ProductId == id, v => v.Size!, v => v.Color!, v => v.PackQuantity!);

        // Get existing reviews with user info
        var reviews = (await _unitOfWork.Repository<ProductReview>()
            .FindAsync(r => r.ProductId == id, r => r.User!))
            .OrderByDescending(r => r.CreatedAt)
            .ToList();

        // Get translations
        var translations = await _unitOfWork.Repository<ProductTranslation>()
            .FindAsync(t => t.ProductId == id);

        // Get price history
        var priceHistory = await _unitOfWork.Repository<ProductPriceHistory>()
            .FindAsync(h => h.ProductId == id);

        var model = new ProductUpdateDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Translations = translations.Select(t => new ProductTranslationDto
            {
                Id = t.Id,
                CultureCode = t.CultureCode,
                Name = t.Name,
                Description = t.Description,
                Slug = t.Slug,
                MetaDescription = t.MetaDescription,
                MetaKeywords = t.MetaKeywords
            }).ToList(),
            Price = product.Price,
            PackSize = product.PackSize,
            CategoryId = product.CategoryId,
            ProductGroupId = product.ProductGroupId,
            StripeTaxCode = product.StripeTaxCode,
            IsActive = product.IsActive,
            StripeProductId = product.StripeProductId,
            StripePriceId = product.StripePriceId,
            // B2B Fields
            IsBusinessOnly = product.IsBusinessOnly,
            IsAvailableForBusiness = product.IsAvailableForBusiness,
            MinBusinessQuantity = product.MinBusinessQuantity,
            BusinessPrice = product.BusinessPrice,
            ExistingImageUrls = product.Images.OrderBy(i => i.DisplayOrder).Select(i => i.ImageUrl).ToList(),
            Variants = variants.Select(v => new ProductVariantDto
            {
                Id = v.Id,
                ColorId = v.ColorId,
                ColorName = v.Color?.Name,
                SizeId = v.SizeId,
                SizeName = v.Size?.Name,
                PackQuantityId = v.PackQuantityId,
                PackQuantityName = v.PackQuantity?.Name,
                SKU = v.SKU,
                Price = v.Price,
                StockQuantity = v.StockQuantity
            }).ToList(),
            Reviews = reviews.Select(r => new ProductReviewManagementDto
            {
                Id = r.Id,
                UserId = r.UserId,
                UserName = r.User?.UserName ?? "Unknown",
                UserEmail = r.User?.Email ?? "",
                Rating = r.Rating,
                Comment = r.Comment,
                IsVisible = r.IsVisible,
                IsVerifiedPurchase = r.IsVerifiedPurchase,
                AdminReply = r.AdminReply,
                CreatedAt = r.CreatedAt,
                UpdatedAt = r.UpdatedAt,
                UserIsBanned = r.User?.LockoutEnd > DateTimeOffset.UtcNow
            }).ToList(),
            PriceHistory = priceHistory.Select(h => new ProductPriceHistoryDto
            {
                Id = h.Id,
                OldPrice = h.OldPrice,
                NewPrice = h.NewPrice,
                Reason = h.Reason,
                ChangedAt = h.ChangedAt,
                ChangedBy = h.ChangedBy
            }).ToList()
        };

        // Populate dropdowns
        var categoriesWithTranslations = await _unitOfWork.Repository<Category>().GetAllAsync(c => c.Translations!);
        var productGroups = await _unitOfWork.Repository<ProductGroup>().GetAllAsync();
        var activeCoupons = await _unitOfWork.Repository<Coupon>().FindAsync(
            c => c.IsActive && (!c.ValidUntil.HasValue || c.ValidUntil >= DateTime.UtcNow)
        );

        ViewBag.Categories = categoriesWithTranslations.Where(c => c.IsActive).OrderBy(c => c.DisplayOrder).ToList();
        ViewBag.ProductGroups = productGroups.ToList();
        ViewBag.Coupons = activeCoupons.ToList();
        ViewBag.AvailableSizes = sizes.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name }).ToList();
        ViewBag.AvailableColors = colors.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
        ViewBag.AvailablePackQuantities = packQuantities.OrderBy(p => p.DisplayOrder).ToList();

        // Get product specific coupons
        var productCoupons = await _unitOfWork.Repository<Coupon>()
            .FindAsync(c => c.ProductId == id);
        ViewBag.ProductCoupons = productCoupons.OrderByDescending(c => c.CreatedAt).ToList();

        return View(model);
    }

    /// <summary>
    /// POST: Edit product
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ProductUpdateDto model)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                // Reload data
                var categories = await _unitOfWork.Categories.GetAllAsync();
                var sizes = await _unitOfWork.Sizes.GetAllAsync();
                var colors = await _unitOfWork.Colors.GetAllAsync();
                
                ViewBag.Categories = new SelectList(categories, "Id", "Name", model.CategoryId);
                ViewBag.AvailableSizes = sizes.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name }).ToList();
                ViewBag.AvailableColors = colors.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
                
                return View(model);
            }

            var product = await _unitOfWork.Products.GetByIdAsync(model.Id);
            if (product == null)
            {
                return NotFound();
            }

            // Track price change for history
            bool priceChanged = product.Price != model.Price;
            decimal oldPrice = product.Price;

            // Update product
            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.PackSize = model.PackSize;
            product.CategoryId = model.CategoryId;
            product.ProductGroupId = model.ProductGroupId;
            product.StripeTaxCode = model.StripeTaxCode;
            product.IsActive = model.IsActive;
            product.UpdatedAt = DateTime.UtcNow;
            
            // Update B2B fields
            product.IsBusinessOnly = model.IsBusinessOnly;
            product.IsAvailableForBusiness = model.IsAvailableForBusiness;
            product.MinBusinessQuantity = model.MinBusinessQuantity;
            product.BusinessPrice = model.BusinessPrice;

            // Update Stripe product (sync name, description, active status, and tax code)
            var stripeProductService = new Stripe.ProductService();
            var stripeUpdateOptions = new Stripe.ProductUpdateOptions
            {
                Name = model.Name,
                Description = model.Description,
                Active = model.IsActive,
                Metadata = new Dictionary<string, string>
                {
                    { "category_id", model.CategoryId.ToString()??"" },
                    { "pack_size", model.PackSize.ToString() ?? "" }
                }
            };
            // Sync tax code if changed
            if (!string.IsNullOrEmpty(model.StripeTaxCode))
            {
                stripeUpdateOptions.TaxCode = model.StripeTaxCode;
            }
            await stripeProductService.UpdateAsync(product.StripeProductId, stripeUpdateOptions);

            // If base price changed, create new Stripe price and update
            if (priceChanged)
            {
                var stripePriceService = new Stripe.PriceService();
                
                // Deactivate old price
                await stripePriceService.UpdateAsync(product.StripePriceId, new Stripe.PriceUpdateOptions
                {
                    Active = false
                });

                // Create new price
                var newStripePrice = await stripePriceService.CreateAsync(new Stripe.PriceCreateOptions
                {
                    Product = product.StripeProductId,
                    UnitAmount = (long)(model.Price * 100),
                    Currency = "pln",
                    Active = true,
                    TaxBehavior = "exclusive"
                });

                product.StripePriceId = newStripePrice.Id;

                // Log price change
                await _unitOfWork.Repository<ProductPriceHistory>().AddAsync(new ProductPriceHistory
                {
                    ProductId = product.Id,
                    OldPrice = oldPrice,
                    NewPrice = model.Price,
                    Reason = "Manual Update",
                    ChangedBy = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    ChangedAt = DateTime.UtcNow
                });
            }

            // Sync Business Price changes to Variants
            // If Business Price changed, or if it was just added, we need to ensure all variants have this price in Stripe
            // Sync Business Price changes to Variants
            // Only update if Business Price actually changed
            if (product.BusinessPrice != model.BusinessPrice)
            {
                 var allVariants = await _unitOfWork.Repository<ProductVariant>().FindAsync(v => v.ProductId == product.Id);
                 var stripePriceService = new Stripe.PriceService();
                 
                 foreach (var variant in allVariants)
                 {
                     if (model.BusinessPrice.HasValue && model.BusinessPrice > 0)
                     {
                         // Create or Replace Business Price
                         // Note: We can't easily "update" a price amount in Stripe, we create a new one.
                         // For simplicity in this iteration, we'll create a new one if it doesn't exist or if we want to force update.
                         // Ideally we should check if the existing BusinessStripePriceId matches the amount, but here we'll just create new.
                         
                         var businessPriceOptions = new Stripe.PriceCreateOptions
                         {
                             Product = product.StripeProductId,
                             UnitAmount = (long)(model.BusinessPrice.Value * 100),
                             Currency = "pln",
                             Active = true,
                             TaxBehavior = "exclusive",
                             Metadata = new Dictionary<string, string> 
                             { 
                                 { "sku", variant.SKU },
                                 { "type", "business" },
                                 { "size_id", variant.SizeId?.ToString() ?? "" },
                                 { "color_id", variant.ColorId?.ToString() ?? "" }
                             }
                         };
                         
                         // If there was an old business price, we might want to archive it, but Stripe allows multiple active prices.
                         // To keep it clean, if we store it, we could try to deactivate it.
                         if (!string.IsNullOrEmpty(variant.BusinessStripePriceId)) 
                         {
                             try { await stripePriceService.UpdateAsync(variant.BusinessStripePriceId, new Stripe.PriceUpdateOptions { Active = false }); } catch {}
                         }

                         var newBusinessPrice = await stripePriceService.CreateAsync(businessPriceOptions);
                         variant.BusinessStripePriceId = newBusinessPrice.Id;
                         _unitOfWork.Repository<ProductVariant>().Update(variant);
                     }
                     else
                     {
                         // Business price removed
                         if (!string.IsNullOrEmpty(variant.BusinessStripePriceId))
                         {
                             try { await stripePriceService.UpdateAsync(variant.BusinessStripePriceId, new Stripe.PriceUpdateOptions { Active = false }); } catch {}
                             variant.BusinessStripePriceId = null;
                             _unitOfWork.Repository<ProductVariant>().Update(variant);
                         }
                     }
                 }
            }

            _unitOfWork.Products.Update(product);

            // Update translations
            if (model.Translations != null && model.Translations.Any())
            {
                // Get existing translations
                var existingTranslations = await _unitOfWork.Repository<ProductTranslation>()
                    .FindAsync(t => t.ProductId == product.Id);
                
                foreach (var translationDto in model.Translations)
                {
                    // Skip empty translations
                    if (string.IsNullOrWhiteSpace(translationDto.Name))
                        continue;

                    var existingTranslation = existingTranslations
                        .FirstOrDefault(t => t.CultureCode == translationDto.CultureCode);

                    if (existingTranslation != null)
                    {
                        // Update existing translation
                        existingTranslation.Name = translationDto.Name;
                        existingTranslation.Description = translationDto.Description ?? string.Empty;
                        existingTranslation.Slug = translationDto.Slug ?? string.Empty;
                        existingTranslation.MetaDescription = translationDto.MetaDescription ?? string.Empty;
                        existingTranslation.MetaKeywords = translationDto.MetaKeywords ?? string.Empty;
                        _unitOfWork.Repository<ProductTranslation>().Update(existingTranslation);
                    }
                    else
                    {
                        // Create new translation
                        var newTranslation = new ProductTranslation
                        {
                            ProductId = product.Id,
                            CultureCode = translationDto.CultureCode,
                            Name = translationDto.Name,
                            Description = translationDto.Description ?? string.Empty,
                            Slug = translationDto.Slug ?? string.Empty,
                            MetaDescription = translationDto.MetaDescription ?? string.Empty,
                            MetaKeywords = translationDto.MetaKeywords ?? string.Empty
                        };
                        await _unitOfWork.Repository<ProductTranslation>().AddAsync(newTranslation);
                    }
                }
            }

            // Handle variant updates
            if (model.Variants != null && model.Variants.Any())
            {
                // Get existing variants
                var existingVariants = await _unitOfWork.Repository<ProductVariant>()
                    .FindAsync(v => v.ProductId == product.Id);
                var existingVariantIds = existingVariants.Select(v => v.Id).ToList();
                var submittedVariantIds = model.Variants.Where(v => v.Id.HasValue).Select(v => v.Id!.Value).ToList();
                
                // Delete variants that were removed
                var variantsToDelete = existingVariants.Where(v => !submittedVariantIds.Contains(v.Id)).ToList();
                foreach (var variantToDelete in variantsToDelete)
                {
                    _unitOfWork.Repository<ProductVariant>().Remove(variantToDelete);
                    _logger.LogInformation("Deleted variant {VariantId} from product {ProductId}", variantToDelete.Id, product.Id);
                }
                
                // Update or create variants
                foreach (var variantDto in model.Variants)
                {
                    if (variantDto.Id.HasValue && variantDto.Id > 0)
                    {
                        // Update existing variant
                        var existingVariant = existingVariants.FirstOrDefault(v => v.Id == variantDto.Id);
                        if (existingVariant != null)
                        {
                            existingVariant.SizeId = variantDto.SizeId;
                            existingVariant.ColorId = variantDto.ColorId;
                            existingVariant.SKU = variantDto.SKU;
                            existingVariant.StockQuantity = variantDto.StockQuantity;
                            existingVariant.UpdatedAt = DateTime.UtcNow;

                            // Update Stripe Price if changed
                            if (existingVariant.Price != variantDto.Price)
                            {
                                var stripePriceService = new Stripe.PriceService();
                                // Deactivate old
                                if (!string.IsNullOrEmpty(existingVariant.StripePriceId))
                                {
                                    try { await stripePriceService.UpdateAsync(existingVariant.StripePriceId, new Stripe.PriceUpdateOptions { Active = false }); } catch {}
                                }
                                
                                // Create new
                                var editEffectivePrice = variantDto.Price.HasValue && variantDto.Price.Value > 0 
                                    ? variantDto.Price.Value : product.Price;
                                var newPrice = await stripePriceService.CreateAsync(new Stripe.PriceCreateOptions
                                {
                                    Product = product.StripeProductId,
                                    UnitAmount = (long)(editEffectivePrice * 100),
                                    Currency = "pln",
                                    Active = true,
                                    TaxBehavior = "exclusive",
                                    Metadata = new Dictionary<string, string>
                                    { 
                                        { "sku", variantDto.SKU },
                                        { "type", "retail" }
                                    }
                                });
                                existingVariant.StripePriceId = newPrice.Id;
                                existingVariant.Price = editEffectivePrice;
                            }
                            
                            _unitOfWork.Repository<ProductVariant>().Update(existingVariant);
                        }
                    }
                    else
                    {
                        // Create new variant with Stripe price
                        var stripePriceService = new Stripe.PriceService();
                        var newEffectivePrice = variantDto.Price.HasValue && variantDto.Price.Value > 0 
                            ? variantDto.Price.Value : product.Price;
                        var stripePriceOptions = new Stripe.PriceCreateOptions
                        {
                            Product = product.StripeProductId,
                            UnitAmount = (long)(newEffectivePrice * 100),
                            Currency = "pln",
                            Active = true,
                            TaxBehavior = "exclusive",
                            Metadata = new Dictionary<string, string>
                            { 
                                { "sku", variantDto.SKU },
                                { "type", "retail" }
                            }
                        };
                        var stripePrice = await stripePriceService.CreateAsync(stripePriceOptions);
                        
                        // Create Business Price if applicable
                        string? variantBusinessStripePriceId = null;
                        if (product.BusinessPrice.HasValue && product.BusinessPrice > 0)
                        {
                            var businessPriceOptions = new Stripe.PriceCreateOptions
                            {
                                Product = product.StripeProductId,
                                UnitAmount = (long)(product.BusinessPrice.Value * 100),
                                Currency = "pln",
                                Active = true,
                                TaxBehavior = "exclusive",
                                Metadata = new Dictionary<string, string> 
                                { 
                                    { "sku", variantDto.SKU },
                                    { "type", "business" }
                                }
                            };
                            var businessPrice = await stripePriceService.CreateAsync(businessPriceOptions);
                            variantBusinessStripePriceId = businessPrice.Id;
                        }

                        var newVariant = new ProductVariant
                        {
                            ProductId = product.Id,
                            SizeId = variantDto.SizeId,
                            ColorId = variantDto.ColorId,
                            SKU = variantDto.SKU,
                            Price = newEffectivePrice,
                            StockQuantity = variantDto.StockQuantity,
                            StripePriceId = stripePrice.Id,
                            BusinessStripePriceId = variantBusinessStripePriceId,
                            IsActive = true,
                            CreatedAt = DateTime.UtcNow
                        };
                        await _unitOfWork.Repository<ProductVariant>().AddAsync(newVariant);
                        _logger.LogInformation("Created new variant for product {ProductId}: SKU={SKU}", product.Id, variantDto.SKU);
                    }
                }
            }

            // Handle image deletions
            if (model.ImagesToDelete != null && model.ImagesToDelete.Any())
            {
                var imagesToDelete = await _unitOfWork.Repository<ProductImage>()
                    .FindAsync(img => model.ImagesToDelete.Contains(img.ImageUrl));
                
                foreach (var img in imagesToDelete)
                {
                    await _productImageService.DeleteProductImageAsync(img.ImageUrl);
                    _unitOfWork.Repository<ProductImage>().Remove(img);
                }
            }

            // Handle new image uploads
            if (model.NewImageTempFileNames != null && model.NewImageTempFileNames.Any())
            {
                var currentMaxOrder = product.Images.Any() ? product.Images.Max(i => i.DisplayOrder) : 0;
                
                foreach (var tempFileName in model.NewImageTempFileNames)
                {
                    var moveResult = await _productImageService.MoveTempToPermanentAsync(tempFileName, product.Id);
                    if (moveResult.Success)
                    {
                        var productImage = new ProductImage
                        {
                            ProductId = product.Id,
                            ImageUrl = moveResult.PermanentUrl!,
                            DisplayOrder = ++currentMaxOrder,
                            CreatedAt = DateTime.UtcNow
                        };
                        await _unitOfWork.Repository<ProductImage>().AddAsync(productImage);
                    }
                }
            }

            await _unitOfWork.SaveChangesAsync();

            // Sync all images to Stripe (after deletions and additions)
            try
            {
                var allImages = await _unitOfWork.Repository<ProductImage>()
                    .FindAsync(img => img.ProductId == product.Id);
                var imageUrls = allImages
                    .OrderBy(i => i.DisplayOrder)
                    .Select(i => $"{Request.Scheme}://{Request.Host}{i.ImageUrl}")
                    .Take(8) // Stripe limit
                    .ToList();
                
                await stripeProductService.UpdateAsync(product.StripeProductId, new Stripe.ProductUpdateOptions
                {
                    Images = imageUrls
                });
                _logger.LogInformation("Synced {Count} images to Stripe for product {ProductId}", imageUrls.Count, product.Id);
            }
            catch (Exception imgEx)
            {
                _logger.LogWarning(imgEx, "Failed to sync images to Stripe for product {ProductId}", product.Id);
                // Continue - images are saved locally
            }

            _logger.LogInformation("Product updated: {ProductId} - {ProductName}", product.Id, product.Name);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating product {ProductId}", model.Id);
            ModelState.AddModelError("", "Error updating product. Please try again.");
            
            // Reload data
            var categories = await _unitOfWork.Categories.GetAllAsync();
            var sizes = await _unitOfWork.Sizes.GetAllAsync();
            var colors = await _unitOfWork.Colors.GetAllAsync();
            
            ViewBag.Categories = new SelectList(categories, "Id", "Name", model.CategoryId);
            ViewBag.AvailableSizes = sizes.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name }).ToList();
            ViewBag.AvailableColors = colors.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
            
            return View(model);
        }
    }

    /// <summary>
    /// POST: Delete product
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var product = await _unitOfWork.Products.GetProductWithDetailsAsync(id);
            
            if (product == null)
            {
                return Json(new { success = false, message = "Product not found" });
            }

            // Check if product has any sales
            var variantIds = (await _unitOfWork.Repository<ProductVariant>()
                .FindAsync(v => v.ProductId == id))
                .Select(v => v.Id)
                .ToList();
                
            var hasSales = await _unitOfWork.Repository<OrderItem>()
                .AnyAsync(oi => variantIds.Contains(oi.ProductVariantId));

            if (hasSales)
            {
                // Archive logic
                product.IsActive = false;
                _unitOfWork.Products.Update(product);
                await _unitOfWork.SaveChangesAsync();

                // Archive in Stripe
                if (!string.IsNullOrEmpty(product.StripeProductId))
                {
                    try
                    {
                        await _stripeService.ArchiveStripeProductAsync(product.StripeProductId);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning(ex, "Error archiving Stripe product {StripeId}", product.StripeProductId);
                    }
                }

                return Json(new { success = true, message = "Product archived because it has sales." });
            }
            else
            {
                // Delete logic
                
                // Deactivate all Stripe prices first (required before deleting product)
                if (!string.IsNullOrEmpty(product.StripeProductId))
                {
                    try
                    {
                        var stripePriceService = new Stripe.PriceService();
                        
                        // Deactivate base price
                        if (!string.IsNullOrEmpty(product.StripePriceId))
                        {
                            try { await stripePriceService.UpdateAsync(product.StripePriceId, new Stripe.PriceUpdateOptions { Active = false }); } catch { }
                        }
                        
                        // Deactivate business price
                        if (!string.IsNullOrEmpty(product.BusinessStripePriceId))
                        {
                            try { await stripePriceService.UpdateAsync(product.BusinessStripePriceId, new Stripe.PriceUpdateOptions { Active = false }); } catch { }
                        }
                        
                        // Deactivate all variant prices
                        var variants = await _unitOfWork.Repository<ProductVariant>().FindAsync(v => v.ProductId == product.Id);
                        foreach (var variant in variants)
                        {
                            if (!string.IsNullOrEmpty(variant.StripePriceId))
                            {
                                try { await stripePriceService.UpdateAsync(variant.StripePriceId, new Stripe.PriceUpdateOptions { Active = false }); } catch { }
                            }
                            if (!string.IsNullOrEmpty(variant.BusinessStripePriceId))
                            {
                                try { await stripePriceService.UpdateAsync(variant.BusinessStripePriceId, new Stripe.PriceUpdateOptions { Active = false }); } catch { }
                            }
                        }
                        
                        // Now delete the product from Stripe
                        await _stripeService.DeleteStripeProductAsync(product.StripeProductId);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning(ex, "Error cleaning up Stripe product {StripeId}, will archive instead", product.StripeProductId);
                        // If delete fails, at least archive it
                        try { await _stripeService.ArchiveStripeProductAsync(product.StripeProductId); } catch { }
                    }
                }

                // Remove from carts
                var cartItems = await _unitOfWork.Repository<Cart>().FindAsync(c => c.ProductId == product.Id);
                _unitOfWork.Repository<Cart>().RemoveRange(cartItems);

                // Remove from wishlists
                var wishlistItems = await _unitOfWork.Repository<Wishlist>().FindAsync(w => w.ProductId == product.Id);
                _unitOfWork.Repository<Wishlist>().RemoveRange(wishlistItems);

                // Delete images
                foreach (var image in product.Images)
                {
                    await _productImageService.DeleteProductImageAsync(image.ImageUrl);
                }

                _unitOfWork.Products.Remove(product);
                await _unitOfWork.SaveChangesAsync();

                return Json(new { success = true, message = "Product deleted successfully." });
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting product {ProductId}", id);
            return Json(new { success = false, message = "Error deleting product" });
        }
    }

    /// <summary>
    /// POST: Upload product image to temp folder (AJAX)
    /// </summary>
    [HttpPost]
    [IgnoreAntiforgeryToken] // Allow AJAX FormData upload
    public async Task<IActionResult> UploadImage(IFormFile file)
    {
        var result = await _productImageService.UploadToTempAsync(file);
        
        if (result.Success)
        {
            return Json(new { success = true, tempFileName = result.TempFileName, tempUrl = result.TempUrl });
        }
        
        return Json(new { success = false, message = result.Message });
    }

    /// <summary>
    /// POST: Cancel product image upload (AJAX)
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CancelUpload([FromBody] ProductImageCancelDto model)
    {
        try
        {
            await _productImageService.CancelUploadAsync(model.TempFileNames.ToArray());
            return Json(new { success = true });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error canceling product upload");
            return Json(new { success = false });
        }
    }

    /// <summary>
    /// POST: Toggle product active status (AJAX)
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> ToggleActive([FromForm] int id)
    {
        try
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            
            if (product == null)
            {
                return Json(new { success = false, message = "Product not found" });
            }

            product.IsActive = !product.IsActive;
            product.UpdatedAt = DateTime.UtcNow;
            
            // Update or archive Stripe product
            var stripeProductService = new Stripe.ProductService();
            
            if (!product.IsActive)
            {
                // Archive (deactivate) in Stripe when making inactive
                await stripeProductService.UpdateAsync(product.StripeProductId, new Stripe.ProductUpdateOptions
                {
                    Active = false
                });

                // Deactivate all variant prices
                var variants = await _unitOfWork.Repository<ProductVariant>()
                    .FindAsync(v => v.ProductId == product.Id);
                
                var stripePriceService = new Stripe.PriceService();
                foreach (var variant in variants)
                {
                    if (!string.IsNullOrEmpty(variant.StripePriceId))
                    {
                        await stripePriceService.UpdateAsync(variant.StripePriceId, new Stripe.PriceUpdateOptions
                        {
                            Active = false
                        });
                    }
                }

                // Deactivate base price
                if (!string.IsNullOrEmpty(product.StripePriceId))
                {
                    await stripePriceService.UpdateAsync(product.StripePriceId, new Stripe.PriceUpdateOptions
                    {
                        Active = false
                    });
                }

                // Remove from all carts
                var cartItems = await _unitOfWork.Repository<Cart>()
                    .FindAsync(c => c.ProductId == product.Id);
                
                foreach (var cartItem in cartItems)
                {
                    _unitOfWork.Repository<Cart>().Remove(cartItem);
                }
            }
            else
            {
                // Reactivate in Stripe
                await stripeProductService.UpdateAsync(product.StripeProductId, new Stripe.ProductUpdateOptions
                {
                    Active = true
                });

                // Reactivate prices
                var stripePriceService = new Stripe.PriceService();
                if (!string.IsNullOrEmpty(product.StripePriceId))
                {
                    await stripePriceService.UpdateAsync(product.StripePriceId, new Stripe.PriceUpdateOptions
                    {
                        Active = true
                    });
                }

                var variants = await _unitOfWork.Repository<ProductVariant>()
                    .FindAsync(v => v.ProductId == product.Id);
                
                foreach (var variant in variants)
                {
                    if (!string.IsNullOrEmpty(variant.StripePriceId))
                    {
                        await stripePriceService.UpdateAsync(variant.StripePriceId, new Stripe.PriceUpdateOptions
                        {
                            Active = true
                        });
                    }
                }
            }
            
            _unitOfWork.Products.Update(product);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Product {ProductId} {Action}. Carts cleared: {CartsCleared}", 
                product.Id, 
                product.IsActive ? "activated" : "deactivated",
                !product.IsActive);

            return Json(new { success = true, isActive = product.IsActive });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error toggling product status {ProductId}", id);
            return Json(new { success = false, message = $"Error updating status: {ex.Message}" });
        }
    }

    /// <summary>
    /// POST: Create coupon for product
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CreateCoupon([FromBody] ProductCouponCreateDto model)
    {
        try
        {
            var product = await _unitOfWork.Products.GetByIdAsync(model.ProductId);
            if (product == null) return Json(new { success = false, message = "Product not found" });

            var coupon = new Coupon
            {
                Code = model.Code,
                DiscountType = model.DiscountType,
                DiscountValue = model.DiscountValue,
                ProductId = model.ProductId,
                ValidUntil = model.ValidUntil,
                UsageLimit = model.UsageLimit,
                IsActive = true
            };

            // Create in Stripe
            if (!string.IsNullOrEmpty(product.StripeProductId))
            {
                try 
                {
                    var stripeCoupon = await _stripeService.CreateProductCouponAsync(coupon, product.StripeProductId);
                    coupon.StripeCouponId = stripeCoupon.Id;
                    
                    // Create promotion code
                    var promoCode = await _stripeService.CreateStripePromotionCodeAsync(stripeCoupon.Id, model.Code);
                    coupon.StripePromotionCodeId = promoCode.Id;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Stripe error creating coupon");
                    return Json(new { success = false, message = "Stripe Error: " + ex.Message });
                }
            }

            await _unitOfWork.Repository<Coupon>().AddAsync(coupon);
            await _unitOfWork.SaveChangesAsync();

            return Json(new { success = true, coupon });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating coupon for product {ProductId}", model.ProductId);
            return Json(new { success = false, message = ex.Message });
        }
    }

    /// <summary>
    /// POST: Delete coupon
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> DeleteCoupon(int id)
    {
        try
        {
            var coupon = await _unitOfWork.Repository<Coupon>().GetByIdAsync(id);
            if (coupon == null) return Json(new { success = false, message = "Coupon not found" });

            // Delete from Stripe
            if (!string.IsNullOrEmpty(coupon.StripeCouponId))
            {
                try
                {
                    await _stripeService.DeleteStripeCouponAsync(coupon.StripeCouponId);
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Error deleting Stripe coupon {StripeId}", coupon.StripeCouponId);
                }
            }

            _unitOfWork.Repository<Coupon>().Remove(coupon);
            await _unitOfWork.SaveChangesAsync();

            return Json(new { success = true });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting coupon {CouponId}", id);
            return Json(new { success = false, message = ex.Message });
        }
    }

    /// <summary>
    /// POST: Toggle coupon active status (syncs with Stripe)
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> ToggleCoupon(int id)
    {
        try
        {
            var coupon = await _unitOfWork.Repository<Coupon>().GetByIdAsync(id);
            if (coupon == null) return Json(new { success = false, message = "Coupon not found" });

            coupon.IsActive = !coupon.IsActive;
            coupon.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.Repository<Coupon>().Update(coupon);
            await _unitOfWork.SaveChangesAsync();

            // Sync with Stripe PromotionCode
            if (!string.IsNullOrEmpty(coupon.StripePromotionCodeId))
            {
                try
                {
                    await _stripeService.UpdateStripePromotionCodeAsync(coupon.StripePromotionCodeId, coupon.IsActive);
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Error syncing coupon status with Stripe. PromotionCodeId: {PromoId}", coupon.StripePromotionCodeId);
                }
            }

            return Json(new { success = true, isActive = coupon.IsActive });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error toggling coupon {CouponId}", id);
            return Json(new { success = false, message = ex.Message });
        }
    }

    /// <summary>
    /// POST: Update coupon (syncs with Stripe PromotionCode active status)
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> UpdateCoupon([FromBody] ProductCouponUpdateDto model)
    {
        try
        {
            var coupon = await _unitOfWork.Repository<Coupon>().GetByIdAsync(model.Id);
            if (coupon == null) return Json(new { success = false, message = "Coupon not found" });

            // Track if active status changed for Stripe sync
            var activeStatusChanged = coupon.IsActive != model.IsActive;
            
            // Note: Stripe coupons are mostly immutable. To change discount, you need to delete and recreate.
            // We can only update local fields like ValidUntil, UsageLimit, Description, IsActive
            coupon.ValidUntil = model.ValidUntil;
            coupon.UsageLimit = model.UsageLimit;
            coupon.UsageLimitPerUser = model.UsageLimitPerUser;
            coupon.MinimumOrderAmount = model.MinimumOrderAmount;
            coupon.MaximumDiscountAmount = model.MaximumDiscountAmount;
            coupon.Description = model.Description;
            coupon.IsActive = model.IsActive;
            coupon.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.Repository<Coupon>().Update(coupon);
            await _unitOfWork.SaveChangesAsync();

            // Sync active status with Stripe PromotionCode
            if (activeStatusChanged && !string.IsNullOrEmpty(coupon.StripePromotionCodeId))
            {
                try
                {
                    await _stripeService.UpdateStripePromotionCodeAsync(coupon.StripePromotionCodeId, coupon.IsActive);
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Error syncing coupon status with Stripe. PromotionCodeId: {PromoId}", coupon.StripePromotionCodeId);
                }
            }

            return Json(new { success = true });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating coupon {CouponId}", model.Id);
            return Json(new { success = false, message = ex.Message });
        }
    }

    /// <summary>
    /// GET: Get single coupon details (AJAX)
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetCoupon(int id)
    {
        try
        {
            var coupon = await _unitOfWork.Repository<Coupon>().GetByIdAsync(id);
            if (coupon == null) return Json(new { success = false, message = "Coupon not found" });

            return Json(new { 
                success = true, 
                coupon = new {
                    coupon.Id,
                    coupon.Code,
                    coupon.DiscountType,
                    coupon.DiscountValue,
                    coupon.Description,
                    coupon.MinimumOrderAmount,
                    coupon.MaximumDiscountAmount,
                    coupon.ValidUntil,
                    coupon.UsageLimit,
                    coupon.UsageLimitPerUser,
                    coupon.UsageCount,
                    coupon.IsActive,
                    coupon.StripeCouponId,
                    coupon.StripePromotionCodeId
                }
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting coupon {CouponId}", id);
            return Json(new { success = false, message = ex.Message });
        }
    }

    /// <summary>
    /// GET: Get coupons for product (AJAX)
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetProductCoupons(int productId)
    {
        try
        {
            var coupons = await _unitOfWork.Repository<Coupon>()
                .FindAsync(c => c.ProductId == productId);

            var result = coupons.OrderByDescending(c => c.CreatedAt).Select(c => new
            {
                c.Id,
                c.Code,
                c.DiscountType,
                c.DiscountValue,
                c.ValidUntil,
                c.UsageLimit,
                c.UsageCount,
                c.IsActive,
                c.Description,
                c.StripeCouponId,
                c.CreatedAt
            });

            return Json(new { success = true, coupons = result });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting coupons for product {ProductId}", productId);
            return Json(new { success = false, message = ex.Message });
        }
    }
}

public class ProductCouponCreateDto
{
    public int ProductId { get; set; }
    public string Code { get; set; } = string.Empty;
    public string DiscountType { get; set; } = "percentage";
    public decimal DiscountValue { get; set; }
    public DateTime? ValidUntil { get; set; }
    public int? UsageLimit { get; set; }
}

public class ProductCouponUpdateDto
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public DateTime? ValidUntil { get; set; }
    public int? UsageLimit { get; set; }
    public int? UsageLimitPerUser { get; set; }
    public decimal? MinimumOrderAmount { get; set; }
    public decimal? MaximumDiscountAmount { get; set; }
    public bool IsActive { get; set; } = true;
}
