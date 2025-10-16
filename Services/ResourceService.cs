using System.Collections.Concurrent;
using System.Globalization;
using System.Resources;
using Microsoft.Extensions.Localization;
using Kokomija.Resources;

namespace Kokomija.Services
{
    /// <summary>
    /// Interface for dynamic resource management service
    /// </summary>
    public interface IResourceService
    {
        /// <summary>
        /// Get localized string by key and culture
        /// </summary>
        string GetString(string key, CultureInfo? culture = null);

        /// <summary>
        /// Get all localized strings for a specific culture
        /// </summary>
        Dictionary<string, string> GetAllStrings(CultureInfo culture);

        /// <summary>
        /// Add or update a resource
        /// </summary>
        Task<bool> AddOrUpdateResourceAsync(string key, string value, CultureInfo culture);

        /// <summary>
        /// Delete a resource
        /// </summary>
        Task<bool> DeleteResourceAsync(string key, CultureInfo culture);

        /// <summary>
        /// Reload all resources (live reload feature)
        /// </summary>
        void ReloadResources();

        /// <summary>
        /// Get all supported cultures
        /// </summary>
        List<CultureInfo> GetSupportedCultures();

        /// <summary>
        /// Check if a culture is supported
        /// </summary>
        bool IsCultureSupported(CultureInfo culture);
    }

    /// <summary>
    /// Dynamic resource management service with live reload capability
    /// </summary>
    public class ResourceService : IResourceService, IDisposable
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<ResourceService> _logger;
        private readonly ConcurrentDictionary<string, ResourceManager> _resourceManagers;
        private readonly ConcurrentDictionary<string, Dictionary<string, string>> _resourceCache;
        private FileSystemWatcher? _fileWatcher;
        private readonly object _reloadLock = new object();

        public ResourceService(
            IStringLocalizer<SharedResources> localizer,
            IWebHostEnvironment environment,
            ILogger<ResourceService> logger)
        {
            _localizer = localizer;
            _environment = environment;
            _logger = logger;
            _resourceManagers = new ConcurrentDictionary<string, ResourceManager>();
            _resourceCache = new ConcurrentDictionary<string, Dictionary<string, string>>();

            InitializeFileWatcher();
            LoadAllResources();
        }

        /// <summary>
        /// Initialize file system watcher for live reload
        /// </summary>
        private void InitializeFileWatcher()
        {
            try
            {
                var resourcePath = Path.Combine(_environment.ContentRootPath, "Resources");
                
                if (!Directory.Exists(resourcePath))
                {
                    Directory.CreateDirectory(resourcePath);
                }

                _fileWatcher = new FileSystemWatcher(resourcePath)
                {
                    Filter = "*.resx",
                    NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.CreationTime,
                    EnableRaisingEvents = true
                };

                _fileWatcher.Changed += OnResourceFileChanged;
                _fileWatcher.Created += OnResourceFileChanged;
                _fileWatcher.Deleted += OnResourceFileChanged;

                _logger.LogInformation("Resource file watcher initialized for live reload at: {Path}", resourcePath);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to initialize resource file watcher");
            }
        }

        /// <summary>
        /// Handle resource file changes for live reload
        /// </summary>
        private void OnResourceFileChanged(object sender, FileSystemEventArgs e)
        {
            _logger.LogInformation("Resource file changed: {FileName}, reloading resources...", e.Name);
            
            // Add a small delay to ensure file is fully written
            Task.Delay(500).ContinueWith(_ => ReloadResources());
        }

        /// <summary>
        /// Load all resource files
        /// </summary>
        private void LoadAllResources()
        {
            lock (_reloadLock)
            {
                try
                {
                    _resourceCache.Clear();
                    _resourceManagers.Clear();

                    var supportedCultures = GetSupportedCultures();
                    
                    foreach (var culture in supportedCultures)
                    {
                        LoadCultureResources(culture);
                    }

                    _logger.LogInformation("All resources loaded successfully");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error loading resources");
                }
            }
        }

        /// <summary>
        /// Load resources for a specific culture
        /// </summary>
        private void LoadCultureResources(CultureInfo culture)
        {
            try
            {
                var cultureKey = culture.Name;
                var resources = new Dictionary<string, string>();

                // Get all localized strings from the localizer
                var localizedStrings = _localizer.GetAllStrings(includeParentCultures: false);
                
                foreach (var localizedString in localizedStrings)
                {
                    resources[localizedString.Name] = localizedString.Value;
                }

                _resourceCache.AddOrUpdate(cultureKey, resources, (_, __) => resources);
                
                _logger.LogDebug("Loaded {Count} resources for culture: {Culture}", resources.Count, cultureKey);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading resources for culture: {Culture}", culture.Name);
            }
        }

        /// <summary>
        /// Get localized string by key and culture
        /// </summary>
        public string GetString(string key, CultureInfo? culture = null)
        {
            try
            {
                culture ??= CultureInfo.CurrentCulture;
                var cultureKey = culture.Name;

                // Try to get from cache first
                if (_resourceCache.TryGetValue(cultureKey, out var resources))
                {
                    if (resources.TryGetValue(key, out var value))
                    {
                        return value;
                    }
                }

                // Fallback to localizer
                var localizedString = _localizer[key];
                return localizedString.ResourceNotFound ? key : localizedString.Value;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting string for key: {Key}, culture: {Culture}", key, culture?.Name);
                return key;
            }
        }

        /// <summary>
        /// Get all localized strings for a specific culture
        /// </summary>
        public Dictionary<string, string> GetAllStrings(CultureInfo culture)
        {
            var cultureKey = culture.Name;
            
            if (_resourceCache.TryGetValue(cultureKey, out var resources))
            {
                return new Dictionary<string, string>(resources);
            }

            LoadCultureResources(culture);
            return _resourceCache.TryGetValue(cultureKey, out var newResources) 
                ? new Dictionary<string, string>(newResources) 
                : new Dictionary<string, string>();
        }

        /// <summary>
        /// Add or update a resource
        /// </summary>
        public async Task<bool> AddOrUpdateResourceAsync(string key, string value, CultureInfo culture)
        {
            try
            {
                var cultureKey = culture.Name;
                var resourcePath = Path.Combine(_environment.ContentRootPath, "Resources", $"SharedResources.{cultureKey}.resx");

                // Note: In production, you would use a proper .resx file writer
                // For now, this is a placeholder for the implementation
                // You would need to use System.Resources.ResXResourceWriter for actual implementation

                _logger.LogInformation("Add/Update resource: {Key} = {Value} for culture: {Culture}", key, value, cultureKey);

                // Update cache
                if (_resourceCache.TryGetValue(cultureKey, out var resources))
                {
                    resources[key] = value;
                }
                else
                {
                    _resourceCache[cultureKey] = new Dictionary<string, string> { { key, value } };
                }

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding/updating resource: {Key} for culture: {Culture}", key, culture.Name);
                return false;
            }
        }

        /// <summary>
        /// Delete a resource
        /// </summary>
        public async Task<bool> DeleteResourceAsync(string key, CultureInfo culture)
        {
            try
            {
                var cultureKey = culture.Name;

                // Note: In production, you would use a proper .resx file writer
                _logger.LogInformation("Delete resource: {Key} for culture: {Culture}", key, cultureKey);

                // Update cache
                if (_resourceCache.TryGetValue(cultureKey, out var resources))
                {
                    resources.Remove(key);
                }

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting resource: {Key} for culture: {Culture}", key, culture.Name);
                return false;
            }
        }

        /// <summary>
        /// Reload all resources (live reload feature)
        /// </summary>
        public void ReloadResources()
        {
            _logger.LogInformation("Reloading all resources...");
            LoadAllResources();
        }

        /// <summary>
        /// Get all supported cultures
        /// </summary>
        public List<CultureInfo> GetSupportedCultures()
        {
            // Default supported cultures
            return new List<CultureInfo>
            {
                new CultureInfo("pl-PL"), // Polish (default)
                new CultureInfo("en-US"), // English
                new CultureInfo("de-DE"), // German
                new CultureInfo("fr-FR")  // French
            };
        }

        /// <summary>
        /// Check if a culture is supported
        /// </summary>
        public bool IsCultureSupported(CultureInfo culture)
        {
            var supportedCultures = GetSupportedCultures();
            return supportedCultures.Any(c => c.Name.Equals(culture.Name, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Dispose resources
        /// </summary>
        public void Dispose()
        {
            if (_fileWatcher != null)
            {
                _fileWatcher.Changed -= OnResourceFileChanged;
                _fileWatcher.Created -= OnResourceFileChanged;
                _fileWatcher.Deleted -= OnResourceFileChanged;
                _fileWatcher.Dispose();
            }

            GC.SuppressFinalize(this);
        }
    }
}
