using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;

namespace Kokomija.Data.Concrete
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _dbSet
                .Where(p => p.CategoryId == categoryId && p.IsActive)
                .Include(p => p.Category)
                .Include(p => p.Images)
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetActiveProductsAsync()
        {
            return await _dbSet
                .Where(p => p.IsActive)
                .Include(p => p.Category)
                .Include(p => p.Translations)
                .Include(p => p.Images.Where(i => i.IsPrimary))
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsWithImagesAsync()
        {
            return await _dbSet
                .Include(p => p.Images.OrderBy(i => i.DisplayOrder))
                .Include(p => p.Category)
                .Where(p => p.IsActive)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsWithVariantsAsync()
        {
            return await _dbSet
                .Include(p => p.Variants)
                    .ThenInclude(v => v.Size)
                .Include(p => p.Variants)
                    .ThenInclude(v => v.Color)
                .Include(p => p.Category)
                .Where(p => p.IsActive)
                .ToListAsync();
        }

        public async Task<Product?> GetProductWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(p => p.Category)
                .Include(p => p.Images.OrderBy(i => i.DisplayOrder))
                    .ThenInclude(i => i.Color)
                .Include(p => p.Variants)
                    .ThenInclude(v => v.Size)
                .Include(p => p.Variants)
                    .ThenInclude(v => v.Color)
                .Include(p => p.AvailableColors)
                    .ThenInclude(pc => pc.Color)
                .Include(p => p.AvailableSizes)
                    .ThenInclude(ps => ps.Size)
                .Include(p => p.Reviews.Where(r => r.IsVisible).OrderByDescending(r => r.CreatedAt))
                    .ThenInclude(r => r.User)
                .Include(p => p.Reviews.Where(r => r.IsVisible).OrderByDescending(r => r.CreatedAt))
                    .ThenInclude(r => r.AdminUser)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm)
        {
            var lowerSearchTerm = searchTerm.ToLower();
            
            // Get current culture from thread
            var currentCulture = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
            
            // Get all products that are active
            var products = await _dbSet
                .Where(p => p.IsActive)
                .Include(p => p.Category)
                    .ThenInclude(c => c!.Translations)
                .Include(p => p.Translations)
                .Include(p => p.Images.Where(i => i.IsPrimary))
                .ToListAsync();
            
            // Filter by search term in all languages (product name, description, or translations)
            var results = products
                .Where(p => 
                    p.Name.ToLower().Contains(lowerSearchTerm) ||
                    p.Description.ToLower().Contains(lowerSearchTerm) ||
                    p.Translations.Any(t => 
                        t.Name.ToLower().Contains(lowerSearchTerm) ||
                        t.Description.ToLower().Contains(lowerSearchTerm)))
                .ToList();
            
            // Apply culture-specific translations to product names and descriptions
            foreach (var product in results)
            {
                var translation = product.Translations.FirstOrDefault(t => t.CultureCode == currentCulture)
                               ?? product.Translations.FirstOrDefault(t => t.CultureCode == "pl-PL");
                
                if (translation != null)
                {
                    product.Name = translation.Name ?? product.Name;
                    product.Description = translation.Description ?? product.Description;
                    product.Slug = translation.Slug ?? product.Slug;
                }
                
                // Also translate category if it has translations
                if (product.Category?.Translations != null)
                {
                    var categoryTranslation = product.Category.Translations.FirstOrDefault(t => t.CultureCode == currentCulture)
                                           ?? product.Category.Translations.FirstOrDefault(t => t.CultureCode == "pl-PL");
                    
                    if (categoryTranslation != null)
                    {
                        product.Category.Name = categoryTranslation.Name ?? product.Category.Name;
                    }
                }
            }
            
            return results.OrderBy(p => p.Name).ToList();
        }

        public async Task<Product?> GetProductBySlugAsync(string slug, string cultureCode)
        {
            // Normalize slug for comparison - convert Polish characters to ASCII and handle multiple dashes
            var normalizedSlug = NormalizeSlug(slug);
            
            // First try to find by checking all translation slugs
            // Load all products and filter client-side to ensure proper comparison
            var allProducts = await _dbSet
                .Include(p => p.Translations)
                .Include(p => p.Category)
                    .ThenInclude(c => c!.Translations)
                .Include(p => p.Images.OrderBy(i => i.DisplayOrder))
                    .ThenInclude(i => i.Color)
                .Include(p => p.Variants)
                    .ThenInclude(v => v.Size)
                .Include(p => p.Variants)
                    .ThenInclude(v => v.Color)
                .Include(p => p.AvailableColors)
                    .ThenInclude(pc => pc.Color)
                .Include(p => p.AvailableSizes)
                    .ThenInclude(ps => ps.Size)
                .Include(p => p.Reviews.Where(r => r.IsVisible).OrderByDescending(r => r.CreatedAt))
                    .ThenInclude(r => r.User)
                .Include(p => p.Reviews.Where(r => r.IsVisible).OrderByDescending(r => r.CreatedAt))
                    .ThenInclude(r => r.AdminUser)
                .ToListAsync();
            
            // Find product by matching any translation slug (case-insensitive)
            var product = allProducts.FirstOrDefault(p => 
                p.Translations.Any(t => t.Slug != null && 
                    t.Slug.Equals(normalizedSlug, StringComparison.OrdinalIgnoreCase)));
            
            if (product != null)
                return product;
            
            // Fallback: try to find by product slug (default language, case-insensitive)
            return allProducts.FirstOrDefault(p => 
                p.Slug != null && p.Slug.Equals(normalizedSlug, StringComparison.OrdinalIgnoreCase));
        }
        
        /// <summary>
        /// Normalizes a slug by converting Polish/special characters to ASCII equivalents
        /// and handling multiple consecutive dashes
        /// </summary>
        private static string NormalizeSlug(string slug)
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
