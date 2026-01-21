using Kokomija.Data.Abstract;
using Kokomija.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Kokomija.ViewComponents
{
    public class ProductCardViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductCardViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync(int productId)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(productId, 
                p => p.Images, 
                p => p.Translations, 
                p => p.Variants);
            if (product == null)
                return Content(string.Empty);

            // Get product variants with colors and sizes
            var variants = await _unitOfWork.ProductVariants.GetVariantsByProductIdAsync(productId);
            
            // Get unique colors and sizes from variants
            var colors = variants
                .Where(v => v.Color != null)
                .Select(v => new ColorViewModel
                {
                    Id = v.ColorId!.Value,
                    Name = v.Color!.Name ?? string.Empty,
                    HexCode = v.Color.HexCode ?? "#000000",
                    DisplayName = v.Color.DisplayName ?? v.Color.Name ?? string.Empty
                })
                .GroupBy(c => c.Id)
                .Select(g => g.First())
                .ToList();

            var sizes = variants
                .Where(v => v.Size != null)
                .Select(v => new SizeViewModel
                {
                    Id = v.SizeId!.Value,
                    Name = v.Size!.Name ?? string.Empty,
                    DisplayName = v.Size.DisplayName ?? v.Size.Name ?? string.Empty
                })
                .GroupBy(s => s.Id)
                .Select(g => g.First())
                .OrderBy(s => s.Id)
                .ToList();

            // Get primary image or first image
            var primaryImage = product.Images
                .Where(i => i.IsPrimary)
                .OrderBy(i => i.DisplayOrder)
                .FirstOrDefault() ?? product.Images.FirstOrDefault();

            // Get all images for gallery
            var images = product.Images
                .OrderBy(i => i.DisplayOrder)
                .Select(i => new ProductImageViewModel
                {
                    Id = i.Id,
                    ImageUrl = i.ImageUrl ?? string.Empty,
                    AltText = i.AltText ?? product.Name,
                    IsPrimary = i.IsPrimary,
                    DisplayOrder = i.DisplayOrder
                })
                .ToList();

            // Check stock availability
            var totalStock = variants.Sum(v => v.StockQuantity);
            var hasStock = totalStock > 0;
            
            // Check if user is authenticated - show WELCOME10 discount for non-authenticated users
            var isAuthenticated = User.Identity?.IsAuthenticated == true;
            decimal? discountedPrice = null;
            var isOnSale = false;
            
            if (!isAuthenticated)
            {
                // WELCOME10: 10% off for non-authenticated users
                var welcomeDiscountPercent = 10m;
                discountedPrice = product.Price * (1 - welcomeDiscountPercent / 100);
                isOnSale = true;
            }
            
            // Get localized slug for product URL
            var currentCulture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var translation = product.Translations?.FirstOrDefault(t => t.CultureCode.StartsWith(currentCulture));
            var slug = translation?.Slug ?? product.Slug ?? product.Name.ToLower().Replace(" ", "-");

            var viewModel = new ProductCardViewModel
            {
                Id = product.Id,
                Name = translation?.Name ?? product.Name,
                Slug = slug,
                Description = translation?.Description ?? product.Description,
                BasePrice = product.Price,
                Price = product.Price,
                DiscountedPrice = discountedPrice,
                MainImageUrl = primaryImage?.ImageUrl ?? "/img/logo_black.png",
                Images = images,
                IsNew = (DateTime.UtcNow - product.CreatedAt).TotalDays <= 30,
                IsOnSale = isOnSale,
                StockQuantity = totalStock,
                HasStock = hasStock,
                Colors = colors,
                Sizes = sizes,
                PackSize = product.PackSize,
                CategoryId = product.CategoryId,
                Translations = product.Translations?.Select(t => new ProductTranslationViewModel
                {
                    CultureCode = t.CultureCode,
                    Name = t.Name,
                    Description = t.Description,
                    Slug = t.Slug
                }).ToList() ?? new()
            };
            
            // Pass current culture to view
            ViewData["CurrentCulture"] = currentCulture;

            return View(viewModel);
        }
    }
}
