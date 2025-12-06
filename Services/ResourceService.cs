using System.Collections.Concurrent;
using System.Globalization;
using System.Xml.Linq;
using Microsoft.Extensions.Localization;
using Kokomija.Resources.SharedResources;

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
    /// Dynamic resource management service with live XML-based reload (no compilation needed)
    /// </summary>
    public class ResourceService : IResourceService, IDisposable
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<ResourceService> _logger;
        private readonly ConcurrentDictionary<string, string> _resourceCache;
        private readonly ConcurrentDictionary<string, DateTime> _fileCache;
        private FileSystemWatcher? _fileWatcher;
        private readonly Timer _debounceTimer;
        private readonly object _lock = new();
        private volatile bool _needsReload = false;
        private readonly string _resourcePath;

        public ResourceService(
            IStringLocalizer<SharedResources> localizer,
            IWebHostEnvironment environment,
            ILogger<ResourceService> logger)
        {
            _localizer = localizer;
            _environment = environment;
            _logger = logger;
            _resourceCache = new ConcurrentDictionary<string, string>();
            _fileCache = new ConcurrentDictionary<string, DateTime>();
            _resourcePath = Path.Combine(environment.ContentRootPath, "Resources");

            _debounceTimer = new Timer(OnDebounceTimerElapsed, null, Timeout.Infinite, Timeout.Infinite);

            InitializeFileWatcher();
            _logger.LogInformation("[ResourceService] Initialized with live XML reading from: {Path}", _resourcePath);
        }

        /// <summary>
        /// Initialize file system watcher for live reload
        /// </summary>
        private void InitializeFileWatcher()
        {
            try
            {
                if (!Directory.Exists(_resourcePath))
                {
                    Directory.CreateDirectory(_resourcePath);
                }

                _fileWatcher = new FileSystemWatcher(_resourcePath, "*.resx")
                {
                    NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.CreationTime,
                    EnableRaisingEvents = true,
                    IncludeSubdirectories = true
                };

                _fileWatcher.Changed += OnResourceFileChanged;
                _fileWatcher.Created += OnResourceFileChanged;
                _fileWatcher.Deleted += OnResourceFileChanged;

                _logger.LogInformation("[ResourceService] File watcher initialized at: {Path}", _resourcePath);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[ResourceService] Failed to initialize file watcher");
            }
        }

        /// <summary>
        /// Handle resource file changes for live reload
        /// </summary>
        private void OnResourceFileChanged(object sender, FileSystemEventArgs e)
        {
            lock (_lock)
            {
                _needsReload = true;
                _debounceTimer.Change(500, Timeout.Infinite);
            }
            _logger.LogInformation("[ResourceService] File change detected: {FileName}", e.Name);
        }

        private void OnDebounceTimerElapsed(object? state)
        {
            if (_needsReload)
            {
                ReloadResources();
                _needsReload = false;
            }
        }

        /// <summary>
        /// Get localized string by key and culture - reads directly from .resx XML
        /// </summary>
        public string GetString(string key, CultureInfo? culture = null)
        {
            try
            {
                culture ??= CultureInfo.CurrentCulture;
                string cacheKey = $"{key}_{culture.Name}";

                _logger.LogDebug("[ResourceService] GetString(key={Key}, culture={Culture})", key, culture.Name);

                // Find all possible .resx files for this culture
                var resxFiles = FindResxFilesForCulture(culture.Name);
                
                _logger.LogDebug("[ResourceService] Found {Count} .resx files for culture {Culture}", resxFiles.Count, culture.Name);

                foreach (var resxPath in resxFiles)
                {
                    if (!File.Exists(resxPath))
                        continue;

                    // Check if file has been modified since we last cached it
                    var lastWriteTime = File.GetLastWriteTimeUtc(resxPath);
                    var fileCacheKey = $"{resxPath}_{culture.Name}";

                    if (_fileCache.TryGetValue(fileCacheKey, out var cachedTime))
                    {
                        if (lastWriteTime > cachedTime)
                        {
                            // File was modified, clear cache for this file
                            InvalidateFileCache(resxPath, culture.Name);
                            _fileCache[fileCacheKey] = lastWriteTime;
                            _logger.LogInformation("[ResourceService] File modified, cache invalidated: {File}", resxPath);
                        }
                    }
                    else
                    {
                        _fileCache[fileCacheKey] = lastWriteTime;
                    }

                    // Try to get from cache
                    if (_resourceCache.TryGetValue(cacheKey, out var cachedValue))
                    {
                        _logger.LogDebug("[ResourceService] Cache hit for {Key}: {Value}", cacheKey, cachedValue);
                        return cachedValue;
                    }

                    // Load from XML file with fresh read
                    try
                    {
                        using (var stream = new FileStream(resxPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            var xDocument = XDocument.Load(stream);
                            var dataElement = xDocument.Root?.Elements("data")
                                .FirstOrDefault(x => x.Attribute("name")?.Value == key);

                            if (dataElement != null)
                            {
                                var value = dataElement.Element("value")?.Value ?? key;
                                _resourceCache[cacheKey] = value;
                                return value;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning(ex, "[ResourceService] Error reading from {File}", resxPath);
                    }
                }

                _logger.LogDebug("[ResourceService] Key {Key} not found in XML files, falling back to compiled localizer", key);

                // Fallback to compiled localizer
                var localizedString = _localizer[key];
                return localizedString.ResourceNotFound ? key : localizedString.Value;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "❌ [ResourceService] Error getting string for key: {Key}, culture: {Culture}", key, culture?.Name);
                return key;
            }
        }

        private List<string> FindResxFilesForCulture(string cultureName)
        {
            var files = new List<string>();
            
            // Get all subdirectories in Resources folder
            var resourceFolders = Directory.GetDirectories(_resourcePath, "*Resources", SearchOption.TopDirectoryOnly);
            
            foreach (var folder in resourceFolders)
            {
                var folderName = Path.GetFileName(folder);
                var resxFile = Path.Combine(folder, $"{folderName}.{cultureName}.resx");
                if (File.Exists(resxFile))
                {
                    files.Add(resxFile);
                }
            }

            return files;
        }

        private void InvalidateFileCache(string filePath, string cultureName)
        {
            // Remove all cache entries that came from this file
            var fileName = Path.GetFileNameWithoutExtension(Path.GetFileNameWithoutExtension(filePath)); // Remove .culture.resx
            var keysToRemove = _resourceCache.Keys
                .Where(k => k.EndsWith($"_{cultureName}"))
                .ToList();

            foreach (var key in keysToRemove)
            {
                _resourceCache.TryRemove(key, out _);
            }

            _logger.LogDebug("[ResourceService] Cache invalidated for file: {File}", filePath);
        }

        /// <summary>
        /// Get all localized strings for a specific culture
        /// </summary>
        public Dictionary<string, string> GetAllStrings(CultureInfo culture)
        {
            var result = new Dictionary<string, string>();
            var resxFiles = FindResxFilesForCulture(culture.Name);

            foreach (var resxPath in resxFiles)
            {
                try
                {
                    if (!File.Exists(resxPath))
                        continue;

                    using (var stream = new FileStream(resxPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        var xDocument = XDocument.Load(stream);
                        var dataElements = xDocument.Root?.Elements("data");

                        if (dataElements != null)
                        {
                            foreach (var element in dataElements)
                            {
                                var key = element.Attribute("name")?.Value;
                                var value = element.Element("value")?.Value;

                                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                                {
                                    result[key] = value;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "[ResourceService] Error reading all strings from {File}", resxPath);
                }
            }

            return result;
        }

        /// <summary>
        /// Add or update a resource
        /// </summary>
        public async Task<bool> AddOrUpdateResourceAsync(string key, string value, CultureInfo culture)
        {
            try
            {
                _logger.LogInformation("Add/Update resource not implemented in live XML mode: {Key} for culture: {Culture}", key, culture.Name);
                // This method would need to write to .resx XML files
                // For now, use TranslationManagementService for updates
                return await Task.FromResult(false);
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
                _logger.LogInformation("Delete resource not implemented in live XML mode: {Key} for culture: {Culture}", key, culture.Name);
                // This method would need to modify .resx XML files
                return await Task.FromResult(false);
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
            _logger.LogInformation("[ResourceService] Clearing all caches at {Time}", DateTime.Now);
            _resourceCache.Clear();
            _fileCache.Clear();
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
                new CultureInfo("en-US")
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
            _fileWatcher?.Dispose();
            _debounceTimer?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
