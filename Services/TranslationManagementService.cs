using System.Xml.Linq;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Localization;

namespace Kokomija.Services
{
    public interface ITranslationManagementService
    {
        Task<List<TranslationFileInfo>> GetAllTranslationFilesAsync();
        Task<List<TranslationKeyInfo>> GetTranslationsByFileAsync(string fileName);
        Task<List<TranslationKeyInfo>> SearchTranslationsAsync(string searchTerm, string? fileName = null);
        Task<bool> UpdateTranslationAsync(string fileName, string key, string cultureCode, string value);
        Task<bool> UpdateCommentAsync(string fileName, string key, string comment);
        List<string> GetResourceCategories();
    }

    public class TranslationFileInfo
    {
        public string FileName { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public int KeyCount { get; set; }
        public DateTime? LastModified { get; set; }
    }

    public class TranslationKeyInfo
    {
        public string Key { get; set; } = string.Empty;
        public string EnglishValue { get; set; } = string.Empty;
        public string PolishValue { get; set; } = string.Empty;
        public string? Comment { get; set; }
        public string ResourceFile { get; set; } = string.Empty;
    }

    public class TranslationManagementService : ITranslationManagementService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IMemoryCache _cache;
        private readonly ILogger<TranslationManagementService> _logger;
        private readonly ILocalizationService _localizationService;
        private readonly string _resourcesPath;

        public TranslationManagementService(
            IWebHostEnvironment environment,
            IMemoryCache cache,
            ILogger<TranslationManagementService> logger,
            ILocalizationService localizationService)
        {
            _environment = environment;
            _cache = cache;
            _logger = logger;
            _localizationService = localizationService;
            _resourcesPath = Path.Combine(_environment.ContentRootPath, "Resources");
        }

        public List<string> GetResourceCategories()
        {
            if (!Directory.Exists(_resourcesPath))
                return new List<string>();

            return Directory.GetDirectories(_resourcesPath)
                .Select(d => Path.GetFileName(d))
                .Where(d => d.EndsWith("Resources"))
                .OrderBy(d => d)
                .ToList();
        }

        public async Task<List<TranslationFileInfo>> GetAllTranslationFilesAsync()
        {
            var files = new List<TranslationFileInfo>();
            var categories = GetResourceCategories();

            foreach (var category in categories)
            {
                var categoryFolder = Path.Combine(_resourcesPath, category);
                var enFile = Path.Combine(categoryFolder, $"{category}.en-US.resx");

                if (File.Exists(enFile))
                {
                    var translations = await ParseResxFileWithCommentsAsync(enFile);
                    var fileInfo = File.Exists(enFile) ? new FileInfo(enFile) : null;

                    files.Add(new TranslationFileInfo
                    {
                        FileName = category,
                        DisplayName = category.Replace("Resources", " "),
                        KeyCount = translations.Count,
                        LastModified = fileInfo?.LastWriteTime
                    });
                }
            }

            return files.OrderBy(f => f.DisplayName).ToList();
        }

        public async Task<List<TranslationKeyInfo>> GetTranslationsByFileAsync(string fileName)
        {
            var categoryFolder = Path.Combine(_resourcesPath, fileName);
            var enFile = Path.Combine(categoryFolder, $"{fileName}.en-US.resx");
            var plFile = Path.Combine(categoryFolder, $"{fileName}.pl-PL.resx");

            var enTranslations = File.Exists(enFile) ? await ParseResxFileWithCommentsAsync(enFile) : new Dictionary<string, (string value, string? comment)>();
            var plTranslations = File.Exists(plFile) ? await ParseResxFileWithCommentsAsync(plFile) : new Dictionary<string, (string value, string? comment)>();

            var allKeys = enTranslations.Keys.Union(plTranslations.Keys).Distinct().OrderBy(k => k);

            var result = new List<TranslationKeyInfo>();
            foreach (var key in allKeys)
            {
                result.Add(new TranslationKeyInfo
                {
                    Key = key,
                    EnglishValue = enTranslations.ContainsKey(key) ? enTranslations[key].value : "",
                    PolishValue = plTranslations.ContainsKey(key) ? plTranslations[key].value : "",
                    Comment = enTranslations.ContainsKey(key) ? enTranslations[key].comment : plTranslations.ContainsKey(key) ? plTranslations[key].comment : null,
                    ResourceFile = fileName
                });
            }

            return result;
        }

        public async Task<List<TranslationKeyInfo>> SearchTranslationsAsync(string searchTerm, string? fileName = null)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return new List<TranslationKeyInfo>();

            var filesToSearch = string.IsNullOrEmpty(fileName) 
                ? GetResourceCategories() 
                : new List<string> { fileName };

            var results = new List<TranslationKeyInfo>();

            foreach (var file in filesToSearch)
            {
                var translations = await GetTranslationsByFileAsync(file);
                
                var matches = translations.Where(t =>
                    t.Key.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    t.EnglishValue.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    t.PolishValue.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    (t.Comment != null && t.Comment.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                );

                results.AddRange(matches);
            }

            return results;
        }

        public async Task<bool> UpdateTranslationAsync(string fileName, string key, string cultureCode, string value)
        {
            try
            {
                var categoryFolder = Path.Combine(_resourcesPath, fileName);
                var resxFile = Path.Combine(categoryFolder, $"{fileName}.{cultureCode}.resx");

                if (!File.Exists(resxFile))
                {
                    _logger.LogWarning("Resource file not found: {ResxFile}", resxFile);
                    return false;
                }

                // Load the XML document
                var doc = await Task.Run(() => XDocument.Load(resxFile));
                var dataElement = doc.Descendants("data")
                    .FirstOrDefault(e => e.Attribute("name")?.Value == key);

                if (dataElement == null)
                {
                    _logger.LogWarning("Translation key not found: {Key} in {File}", key, resxFile);
                    return false;
                }

                // Update the value
                var valueElement = dataElement.Element("value");
                if (valueElement != null)
                {
                    valueElement.Value = value;
                }
                else
                {
                    dataElement.Add(new XElement("value", value));
                }

                // Save the file
                await Task.Run(() => doc.Save(resxFile));

                // Invalidate the resource cache for this category and culture
                InvalidateResourceCache(fileName, cultureCode);
                
                // Add a small delay to ensure file watcher has time to process
                await Task.Delay(100);

                _logger.LogInformation("Translation updated: {Category}.{Key} ({Culture})", fileName, key, cultureCode);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating translation: {Category}.{Key} ({Culture})", fileName, key, cultureCode);
                return false;
            }
        }

        private async Task<Dictionary<string, (string value, string? comment)>> ParseResxFileWithCommentsAsync(string filePath)
        {
            var translations = new Dictionary<string, (string value, string? comment)>();

            try
            {
                var doc = await Task.Run(() => XDocument.Load(filePath));
                var dataElements = doc.Descendants("data");

                foreach (var element in dataElements)
                {
                    var name = element.Attribute("name")?.Value;
                    var value = element.Element("value")?.Value;
                    var comment = element.Element("comment")?.Value;

                    if (!string.IsNullOrEmpty(name) && value != null)
                    {
                        translations[name] = (value, comment);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error parsing resx file: {FilePath}", filePath);
            }

            return translations;
        }

        public async Task<bool> UpdateCommentAsync(string fileName, string key, string comment)
        {
            try
            {
                // Update comment in both en-US and pl-PL files
                var categoryFolder = Path.Combine(_resourcesPath, fileName);
                var enFile = Path.Combine(categoryFolder, $"{fileName}.en-US.resx");
                var plFile = Path.Combine(categoryFolder, $"{fileName}.pl-PL.resx");

                bool success = true;

                // Update en-US file
                if (File.Exists(enFile))
                {
                    success &= await UpdateCommentInFileAsync(enFile, key, comment);
                }

                // Update pl-PL file
                if (File.Exists(plFile))
                {
                    success &= await UpdateCommentInFileAsync(plFile, key, comment);
                }

                if (success)
                {
                    // Invalidate cache after comment update
                    InvalidateResourceCache(fileName, "en-US");
                    InvalidateResourceCache(fileName, "pl-PL");
                    
                    // Add a small delay to ensure file watcher has time to process
                    await Task.Delay(100);
                    
                    _logger.LogInformation("Comment updated for key: {Key} in {FileName}", key, fileName);
                }

                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating comment: {FileName}.{Key}", fileName, key);
                return false;
            }
        }

        private async Task<bool> UpdateCommentInFileAsync(string filePath, string key, string comment)
        {
            try
            {
                var doc = await Task.Run(() => XDocument.Load(filePath));
                var dataElement = doc.Descendants("data")
                    .FirstOrDefault(e => e.Attribute("name")?.Value == key);

                if (dataElement == null)
                {
                    return false;
                }

                // Remove existing comment if present
                var existingComment = dataElement.Element("comment");
                existingComment?.Remove();

                // Add new comment if not empty
                if (!string.IsNullOrWhiteSpace(comment))
                {
                    dataElement.Add(new XElement("comment", comment));
                }

                await Task.Run(() => doc.Save(filePath));
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating comment in file: {FilePath}", filePath);
                return false;
            }
        }

        private void InvalidateResourceCache(string category, string cultureCode)
        {
            // Clear memory cache entries for this resource
            var cacheKey = $"ResourceManager_{category}_{cultureCode}";
            _cache.Remove(cacheKey);
            
            // Invalidate LocalizationService cache to force reload from disk
            _localizationService.InvalidateCache();
            
            _logger.LogInformation("Invalidated resource cache for {Category} ({Culture}) - cache will reload from disk", category, cultureCode);
        }
    }
}
