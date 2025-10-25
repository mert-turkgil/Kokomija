using System.Globalization;
using System.Reflection;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using Kokomija.Resources;

namespace Kokomija.Services
{
    public class LocalizationService : ILocalizationService
    {
        private readonly IStringLocalizer _localizer;
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

            var type = typeof(SharedResources);

            // Ensure Assembly.FullName is not null
            var assemblyFullName = type.Assembly.FullName 
                ?? throw new InvalidOperationException("Assembly FullName cannot be null.");

            var assemblyName = new AssemblyName(assemblyFullName);

            // Ensure AssemblyName.Name is not null
            var location = assemblyName.Name 
                ?? throw new InvalidOperationException("Assembly name cannot be null.");

            _localizer = factory.Create(nameof(SharedResources), location);
        }

        public string GetString(string key)
        {
            try
            {
                var localizedString = GetKey(key);
                
                // Debug logging
                _logger.LogDebug("Localization - Key: {Key}, Value: {Value}, ResourceNotFound: {ResourceNotFound}", 
                    key, localizedString.Value, localizedString.ResourceNotFound);
                
                if (localizedString.ResourceNotFound)
                {
                    _logger.LogWarning("Translation not found for key: {Key}", key);
                }
                
                return localizedString.Value;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting localization for key: {Key}", key);
                return key; // Fallback to key name
            }
        }

        public LocalizedString GetKey(string key)
        {
            // Get current culture
            var currentCulture = _httpContextAccessor.HttpContext?.Features
                .Get<IRequestCultureFeature>()?.RequestCulture.Culture.Name 
                ?? CultureInfo.CurrentCulture.Name;

            try
            {
                // Try to get from ResourceService first (this checks file modification times)
                var resourceValue = _resourceService.GetString(key, new CultureInfo(currentCulture));
                
                // If ResourceService returns the actual value (not the key), use it
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
            return _localizer[key];
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
