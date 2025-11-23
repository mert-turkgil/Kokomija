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
        private readonly IStringLocalizerFactory _factory;
        private Dictionary<string, IStringLocalizer> _localizers = null!;
        private readonly IResourceService _resourceService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<LocalizationService> _logger;
        private static DateTime _lastCacheInvalidation = DateTime.MinValue;
        private IStringLocalizer _sharedLocalizer = null!;

        public LocalizationService(
            IStringLocalizerFactory factory,
            IResourceService resourceService,
            IHttpContextAccessor httpContextAccessor,
            ILogger<LocalizationService> logger)
        {
            _factory = factory;
            _resourceService = resourceService;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;

            InitializeLocalizers();
        }

        private void InitializeLocalizers()
        {
            // Create localizer for SharedResources (backward compatibility)
            _sharedLocalizer = _factory.Create(typeof(SharedResources));
            
            // Create localizers for each resource file
            _localizers = new Dictionary<string, IStringLocalizer>(StringComparer.OrdinalIgnoreCase)
            {
                ["Carousel"] = _factory.Create(typeof(CarouselResources)),
                ["Home"] = _factory.Create(typeof(HomeResources)),
                ["Product"] = _factory.Create(typeof(ProductResources)),
                ["Account"] = _factory.Create(typeof(AccountResources)),
                ["Navigation"] = _factory.Create(typeof(NavigationResources)),
                ["Common"] = _factory.Create(typeof(CommonResources)),
                ["Footer"] = _factory.Create(typeof(FooterResources)),
                ["FAQ"] = _factory.Create(typeof(FAQResources)),
                ["Wishlist"] = _factory.Create(typeof(WishlistResources)),
                ["Review"] = _factory.Create(typeof(ReviewResources)),
                ["Cookie"] = _factory.Create(typeof(CookieResources)),
                ["Cart"] = _factory.Create(typeof(CartResources)),
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
            
            // Force recreation of all localizers to pick up new resource values
            InitializeLocalizers();
            
            // Clear ResourceManager internal caches using reflection
            ClearResourceManagerCaches();
            
            _logger.LogInformation("Localization cache invalidated and localizers recreated at {Time}", _lastCacheInvalidation);
        }

        private void ClearResourceManagerCaches()
        {
            try
            {
                // Get all resource types
                var resourceTypes = new[]
                {
                    typeof(SharedResources),
                    typeof(CarouselResources),
                    typeof(HomeResources),
                    typeof(ProductResources),
                    typeof(AccountResources),
                    typeof(NavigationResources),
                    typeof(CommonResources),
                    typeof(FooterResources),
                    typeof(FAQResources),
                    typeof(WishlistResources),
                    typeof(ReviewResources),
                    typeof(CookieResources),
                    typeof(CartResources)
                };

                foreach (var resourceType in resourceTypes)
                {
                    try
                    {
                        // Access the internal ResourceManager field and clear its cache
                        var resourceManagerField = resourceType.GetField("resourceMan", 
                            BindingFlags.NonPublic | BindingFlags.Static);
                        
                        if (resourceManagerField != null)
                        {
                            var resourceManager = resourceManagerField.GetValue(null) as System.Resources.ResourceManager;
                            if (resourceManager != null)
                            {
                                // Use reflection to access and clear the internal cache
                                var resourceSetsField = typeof(System.Resources.ResourceManager)
                                    .GetField("_resourceSets", BindingFlags.NonPublic | BindingFlags.Instance);
                                
                                if (resourceSetsField != null)
                                {
                                    var resourceSets = resourceSetsField.GetValue(resourceManager);
                                    if (resourceSets != null)
                                    {
                                        var clearMethod = resourceSets.GetType().GetMethod("Clear");
                                        clearMethod?.Invoke(resourceSets, null);
                                        _logger.LogDebug("Cleared ResourceManager cache for {ResourceType}", resourceType.Name);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning(ex, "Failed to clear ResourceManager cache for {ResourceType}", resourceType.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error clearing ResourceManager caches");
            }
        }

        public string this[string key] => GetString(key);
    }
}
