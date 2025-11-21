using System.Globalization;
using System.Reflection;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using Kokomija.Resources.SharedResources;
using Kokomija.Resources.CarouselResources;
using Kokomija.Resources.HomeResources;
using Kokomija.Resources.ProductResources;
using Kokomija.Resources.AccountResources;
using Kokomija.Resources.NavigationResources;
using Kokomija.Resources.CommonResources;
using Kokomija.Resources.FooterResources;
using Kokomija.Resources.FAQResources;
using Kokomija.Resources.WishlistResources;
using Kokomija.Resources.ReviewResources;
using Kokomija.Resources.CookieResources;
using Kokomija.Resources.CartResources;

namespace Kokomija.Services
{
    public class LocalizationService : ILocalizationService
    {
        private readonly IStringLocalizer _sharedLocalizer;
        private readonly Dictionary<string, IStringLocalizer> _localizers;
        private readonly IResourceService _resourceService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<LocalizationService> _logger;
        private static DateTime _lastCacheInvalidation = DateTime.MinValue;

        public LocalizationService(
            IStringLocalizerFactory factory,
            IResourceService resourceService,
            IHttpContextAccessor httpContextAccessor,
            ILogger<LocalizationService> logger)
        {
            _resourceService = resourceService;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;

            // Create localizer for SharedResources (backward compatibility)
            _sharedLocalizer = factory.Create(typeof(SharedResources));
            
            // Create localizers for each resource file
            _localizers = new Dictionary<string, IStringLocalizer>(StringComparer.OrdinalIgnoreCase)
            {
                ["Carousel"] = factory.Create(typeof(CarouselResources)),
                ["Home"] = factory.Create(typeof(HomeResources)),
                ["Product"] = factory.Create(typeof(ProductResources)),
                ["Account"] = factory.Create(typeof(AccountResources)),
                ["Navigation"] = factory.Create(typeof(NavigationResources)),
                ["Common"] = factory.Create(typeof(CommonResources)),
                ["Footer"] = factory.Create(typeof(FooterResources)),
                ["FAQ"] = factory.Create(typeof(FAQResources)),
                ["Wishlist"] = factory.Create(typeof(WishlistResources)),
                ["Review"] = factory.Create(typeof(ReviewResources)),
                ["Cookie"] = factory.Create(typeof(CookieResources)),
                ["Cart"] = factory.Create(typeof(CartResources)),
                ["Shared"] = _sharedLocalizer
            };
        }

        public string GetString(string key)
        {
            return GetString(key, "Shared");
        }

        public string GetString(string key, string resourceName)
        {
            try
            {
                var localizedString = GetKey(key, resourceName);
                
                if (localizedString.ResourceNotFound)
                {
                    _logger.LogWarning("Translation not found for key: {Key} in resource: {Resource}", key, resourceName);
                }
                
                return localizedString.Value;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting localization for key: {Key} in resource: {Resource}", key, resourceName);
                return key;
            }
        }

        public LocalizedString GetKey(string key)
        {
            return GetKey(key, "Shared");
        }

        public LocalizedString GetKey(string key, string resourceName)
        {
            // Get the appropriate localizer
            if (!_localizers.TryGetValue(resourceName, out var localizer))
            {
                _logger.LogWarning("Resource file not found: {Resource}, falling back to Shared", resourceName);
                localizer = _sharedLocalizer;
            }

            // Get current culture
            var currentCulture = _httpContextAccessor.HttpContext?.Features
                .Get<IRequestCultureFeature>()?.RequestCulture.Culture.Name 
                ?? CultureInfo.CurrentCulture.Name;

            try
            {
                // Try to get from ResourceService first (file-based with hot reload)
                var resourceValue = _resourceService.GetString(key, new CultureInfo(currentCulture));
                
                if (!string.IsNullOrEmpty(resourceValue) && !resourceValue.Equals(key, StringComparison.Ordinal))
                {
                    return new LocalizedString(key, resourceValue, false);
                }
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "ResourceService lookup failed for key: {Key}, falling back to standard localizer", key);
            }

            // Fall back to standard localizer
            return localizer[key];
        }

        public void InvalidateCache()
        {
            _lastCacheInvalidation = DateTime.UtcNow;
            _resourceService.ReloadResources();
            _logger.LogInformation("Localization cache invalidated at {Time}", _lastCacheInvalidation);
        }

        public string this[string key] => GetString(key);
    }
}
