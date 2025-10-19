using Kokomija.Data.Abstract;
using Kokomija.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
            var product = await _unitOfWork.Products.GetByIdAsync(productId);
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

            var viewModel = new ProductCardViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                BasePrice = product.Price,
                DiscountedPrice = null, // TODO: Add discount logic
                MainImageUrl = primaryImage?.ImageUrl ?? "/img/logo_black.png",
                Images = images,
                IsNew = (DateTime.UtcNow - product.CreatedAt).TotalDays <= 30,
                IsOnSale = false, // TODO: Add sale logic
                StockQuantity = totalStock,
                HasStock = hasStock,
                Colors = colors,
                Sizes = sizes,
                CategoryId = product.CategoryId
            };

            return View(viewModel);
        }
    }
}
