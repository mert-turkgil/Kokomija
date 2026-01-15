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

    public AdminProductController(
        IUnitOfWork unitOfWork,
        ILogger<AdminProductController> logger,
        IProductImageService productImageService,
        ILocalizationService localizationService,
        IStripeService stripeService)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _productImageService = productImageService;
        _localizationService = localizationService;
        _stripeService = stripeService;
    }

    /// <summary>
    /// GET: Product Management page
    /// </summary>
    public async Task<IActionResult> Index()
    {
        _logger.LogInformation("Admin accessed product management");

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
                StripePriceId = product.StripePriceId
            });
        }

        var productsArray = productsList.ToList();

        var viewModel = new ProductManagementViewModel
        {
            Products = productDtos.OrderByDescending(p => p.CreatedAt).ToList(),
            TotalProducts = productsArray.Count,
            ActiveProducts = productsArray.Count(p => p.IsActive),
            InactiveProducts = productsArray.Count(p => !p.IsActive),
            OutOfStockProducts = productDtos.Count(p => p.TotalStock == 0),
            TotalInventoryValue = productDtos.Sum(p => p.Price * p.TotalStock)
        };

        ViewData["Title"] = "Product Management";
        return View(viewModel);
    }

    /// <summary>
    /// GET: Create new product
    /// </summary>
    public async Task<IActionResult> Create()
    {
        var categories = await _unitOfWork.Repository<Category>()
            .GetAllAsync(c => c.Translations!);
        var sizes = await _unitOfWork.Sizes.GetAllAsync();
        var colors = await _unitOfWork.Colors.GetAllAsync();
        var packQuantities = await _unitOfWork.Repository<PackQuantity>().GetAllAsync();
        var productGroups = await _unitOfWork.Repository<ProductGroup>().GetAllAsync();
        var activeCoupons = await _unitOfWork.Repository<Coupon>()
            .FindAsync(c => c.IsActive && 
                           (!c.ValidUntil.HasValue || c.ValidUntil >= DateTime.UtcNow));

        var model = new ProductCreateDto
        {
            Categories = new SelectList(categories, "Id", "Name"),
            AvailableSizes = sizes.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name }).ToList(),
            AvailableColors = colors.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList()
        };

        ViewBag.Categories = categories.Where(c => c.IsActive).OrderBy(c => c.DisplayOrder).ToList();
        ViewBag.ProductGroups = productGroups.ToList();
        ViewBag.Coupons = activeCoupons.ToList();
        ViewBag.AvailablePackQuantities = packQuantities.OrderBy(p => p.DisplayOrder).ToList();

        return View(model);
    }

    /// <summary>
    /// POST: Create new product
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductCreateDto model)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                // Reload dropdowns
                var categories = await _unitOfWork.Categories.GetAllAsync();
                var sizes = await _unitOfWork.Sizes.GetAllAsync();
                var colors = await _unitOfWork.Colors.GetAllAsync();
                
                model.Categories = new SelectList(categories, "Id", "Name", model.CategoryId);
                model.AvailableSizes = sizes.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name }).ToList();
                model.AvailableColors = colors.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
                
                return View(model);
            }

            // Create Stripe product
            var stripeProductService = new Stripe.ProductService();
            var stripeProduct = await stripeProductService.CreateAsync(new Stripe.ProductCreateOptions
            {
                Name = model.Name,
                Description = model.Description,
                Active = model.IsActive,
                Metadata = new Dictionary<string, string>
                {
                    { "category_id", model.CategoryId.ToString() },
                    { "pack_size", model.PackSize.ToString() }
                }
            });

            // Create Stripe price (base price)
            var stripePriceService = new Stripe.PriceService();
            var stripePrice = await stripePriceService.CreateAsync(new Stripe.PriceCreateOptions
            {
                Product = stripeProduct.Id,
                UnitAmount = (long)(model.BasePrice * 100), // Convert to cents
                Currency = "try",
                Active = true
            });

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
                StripeTaxCode = "txcd_99999999", // General product tax code
                IsActive = model.IsActive,
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
                    }
                }
                await _unitOfWork.SaveChangesAsync();
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
                    // Create Stripe price for this variant
                    var variantStripePrice = await stripePriceService.CreateAsync(new Stripe.PriceCreateOptions
                    {
                        Product = stripeProduct.Id,
                        UnitAmount = (long)(variantDto.Price * 100),
                        Currency = "try",
                        Active = true,
                        Metadata = new Dictionary<string, string>
                        {
                            { "size_id", variantDto.SizeId?.ToString() ?? "" },
                            { "color_id", variantDto.ColorId?.ToString() ?? "" },
                            { "sku", variantDto.SKU }
                        }
                    });

                    var variant = new ProductVariant
                    {
                        ProductId = product.Id,
                        SizeId = variantDto.SizeId,
                        ColorId = variantDto.ColorId,
                        SKU = variantDto.SKU,
                        Price = variantDto.Price,
                        StockQuantity = variantDto.StockQuantity,
                        StripePriceId = variantStripePrice.Id,
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
            
            TempData["Success"] = $"Product '{product.Name}' created successfully!";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating product");
            TempData["Error"] = "Error creating product. Please try again.";
            
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
            
            return View(model);
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

            // Update Stripe product
            var stripeProductService = new Stripe.ProductService();
            await stripeProductService.UpdateAsync(product.StripeProductId, new Stripe.ProductUpdateOptions
            {
                Name = model.Name,
                Description = model.Description,
                Active = model.IsActive
            });

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
                    Currency = "try",
                    Active = true
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
                            existingVariant.Price = variantDto.Price;
                            existingVariant.StockQuantity = variantDto.StockQuantity;
                            existingVariant.UpdatedAt = DateTime.UtcNow;
                            _unitOfWork.Repository<ProductVariant>().Update(existingVariant);
                        }
                    }
                    else
                    {
                        // Create new variant with Stripe price
                        var stripePriceService = new Stripe.PriceService();
                        var stripePriceOptions = new Stripe.PriceCreateOptions
                        {
                            Product = product.StripeProductId,
                            UnitAmount = (long)(variantDto.Price * 100),
                            Currency = "pln",
                            Active = true
                        };
                        var stripePrice = await stripePriceService.CreateAsync(stripePriceOptions);
                        
                        var newVariant = new ProductVariant
                        {
                            ProductId = product.Id,
                            SizeId = variantDto.SizeId,
                            ColorId = variantDto.ColorId,
                            SKU = variantDto.SKU,
                            Price = variantDto.Price,
                            StockQuantity = variantDto.StockQuantity,
                            StripePriceId = stripePrice.Id,
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
                
                // Remove from Stripe
                if (!string.IsNullOrEmpty(product.StripeProductId))
                {
                    try 
                    {
                        await _stripeService.DeleteStripeProductAsync(product.StripeProductId);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning(ex, "Error deleting Stripe product {StripeId}", product.StripeProductId);
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
