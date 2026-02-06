using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;

namespace Kokomija.Services;

/// <summary>
/// Auto-translation service using MyMemory API (free tier: 1000 words/day)
/// Falls back to simple placeholder translation if API fails
/// </summary>
public class AutoTranslationService : IAutoTranslationService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<AutoTranslationService> _logger;
    private readonly IConfiguration _configuration;
    
    // MyMemory API (free, no key required for basic usage)
    private const string MyMemoryApiUrl = "https://api.mymemory.translated.net/get";
    
    public AutoTranslationService(
        IHttpClientFactory httpClientFactory,
        ILogger<AutoTranslationService> logger,
        IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
        _configuration = configuration;
    }
    
    public async Task<TranslationResult> TranslateAsync(string text, string sourceLanguage, string targetLanguage)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return new TranslationResult
            {
                Success = true,
                OriginalText = text,
                TranslatedText = text,
                SourceLanguage = sourceLanguage,
                TargetLanguage = targetLanguage
            };
        }
        
        try
        {
            // Normalize language codes
            var sourceLang = NormalizeLanguageCode(sourceLanguage);
            var targetLang = NormalizeLanguageCode(targetLanguage);
            
            if (sourceLang == targetLang)
            {
                return new TranslationResult
                {
                    Success = true,
                    OriginalText = text,
                    TranslatedText = text,
                    SourceLanguage = sourceLang,
                    TargetLanguage = targetLang
                };
            }
            
            var client = _httpClientFactory.CreateClient();
            client.Timeout = TimeSpan.FromSeconds(10);
            
            // Build the URL with query parameters
            var langpair = $"{sourceLang}|{targetLang}";
            var encodedText = Uri.EscapeDataString(text);
            var requestUrl = $"{MyMemoryApiUrl}?q={encodedText}&langpair={langpair}";
            
            // Add optional email for higher rate limits
            var email = _configuration["Translation:MyMemoryEmail"];
            if (!string.IsNullOrEmpty(email))
            {
                requestUrl += $"&de={Uri.EscapeDataString(email)}";
            }
            
            var response = await client.GetAsync(requestUrl);
            
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<MyMemoryResponse>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                
                if (result?.ResponseStatus == 200 && result.ResponseData?.TranslatedText != null)
                {
                    var translatedText = result.ResponseData.TranslatedText;
                    
                    // Check for rate limit warning
                    if (translatedText.Contains("MYMEMORY WARNING"))
                    {
                        _logger.LogWarning("MyMemory API rate limit warning received");
                        return await FallbackTranslateAsync(text, sourceLang, targetLang);
                    }
                    
                    return new TranslationResult
                    {
                        Success = true,
                        OriginalText = text,
                        TranslatedText = translatedText,
                        SourceLanguage = sourceLang,
                        TargetLanguage = targetLang
                    };
                }
            }
            
            _logger.LogWarning("MyMemory API returned non-success status: {StatusCode}", response.StatusCode);
            return await FallbackTranslateAsync(text, sourceLang, targetLang);
        }
        catch (TaskCanceledException)
        {
            _logger.LogWarning("Translation request timed out");
            return await FallbackTranslateAsync(text, sourceLanguage, targetLanguage);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error translating text with MyMemory API");
            return await FallbackTranslateAsync(text, sourceLanguage, targetLanguage);
        }
    }
    
    public async Task<List<TranslationResult>> TranslateBatchAsync(List<string> texts, string sourceLanguage, string targetLanguage)
    {
        var results = new List<TranslationResult>();
        
        foreach (var text in texts)
        {
            var result = await TranslateAsync(text, sourceLanguage, targetLanguage);
            results.Add(result);
            
            // Add small delay to respect rate limits
            await Task.Delay(100);
        }
        
        return results;
    }
    
    /// <summary>
    /// Fallback translation using basic dictionary-based approach for common e-commerce terms
    /// </summary>
    private Task<TranslationResult> FallbackTranslateAsync(string text, string sourceLang, string targetLang)
    {
        // For now, return the original text with a note that it couldn't be translated
        // In a production environment, you might want to implement a more sophisticated fallback
        _logger.LogInformation("Using fallback translation for text: {Text}", text.Substring(0, Math.Min(50, text.Length)));
        
        var translatedText = text;
        
        // Basic common words translation (English -> Polish)
        if (sourceLang == "en" && targetLang == "pl")
        {
            translatedText = ApplyBasicEnToPlTranslation(text);
        }
        // Basic common words translation (Polish -> English)
        else if (sourceLang == "pl" && targetLang == "en")
        {
            translatedText = ApplyBasicPlToEnTranslation(text);
        }
        
        return Task.FromResult(new TranslationResult
        {
            Success = true, // Mark as success but with fallback
            OriginalText = text,
            TranslatedText = translatedText,
            SourceLanguage = sourceLang,
            TargetLanguage = targetLang,
            ErrorMessage = "Used fallback translation - please verify"
        });
    }
    
    private string ApplyBasicEnToPlTranslation(string text)
    {
        // Common e-commerce term replacements
        var replacements = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "socks", "skarpetki" },
            { "sock", "skarpetka" },
            { "cotton", "bawełna" },
            { "comfortable", "wygodne" },
            { "premium", "premium" },
            { "quality", "jakość" },
            { "high quality", "wysoka jakość" },
            { "pack", "zestaw" },
            { "pair", "para" },
            { "size", "rozmiar" },
            { "color", "kolor" },
            { "black", "czarny" },
            { "white", "biały" },
            { "blue", "niebieski" },
            { "red", "czerwony" },
            { "green", "zielony" },
            { "gray", "szary" },
            { "grey", "szary" },
            { "product", "produkt" },
            { "new", "nowy" },
            { "sale", "wyprzedaż" },
            { "free shipping", "darmowa wysyłka" },
            { "available", "dostępny" },
            { "description", "opis" },
            { "details", "szczegóły" },
            { "material", "materiał" },
            { "soft", "miękki" },
            { "durable", "trwały" },
            { "breathable", "oddychający" }
        };
        
        var result = text;
        foreach (var kvp in replacements.OrderByDescending(x => x.Key.Length))
        {
            result = System.Text.RegularExpressions.Regex.Replace(
                result, 
                $@"\b{System.Text.RegularExpressions.Regex.Escape(kvp.Key)}\b", 
                kvp.Value, 
                System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        }
        
        return result;
    }
    
    private string ApplyBasicPlToEnTranslation(string text)
    {
        // Common e-commerce term replacements (reverse of above)
        var replacements = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "skarpetki", "socks" },
            { "skarpetka", "sock" },
            { "bawełna", "cotton" },
            { "wygodne", "comfortable" },
            { "jakość", "quality" },
            { "wysoka jakość", "high quality" },
            { "zestaw", "pack" },
            { "para", "pair" },
            { "rozmiar", "size" },
            { "kolor", "color" },
            { "czarny", "black" },
            { "biały", "white" },
            { "niebieski", "blue" },
            { "czerwony", "red" },
            { "zielony", "green" },
            { "szary", "gray" },
            { "produkt", "product" },
            { "nowy", "new" },
            { "wyprzedaż", "sale" },
            { "darmowa wysyłka", "free shipping" },
            { "dostępny", "available" },
            { "opis", "description" },
            { "szczegóły", "details" },
            { "materiał", "material" },
            { "miękki", "soft" },
            { "trwały", "durable" },
            { "oddychający", "breathable" }
        };
        
        var result = text;
        foreach (var kvp in replacements.OrderByDescending(x => x.Key.Length))
        {
            result = System.Text.RegularExpressions.Regex.Replace(
                result, 
                $@"\b{System.Text.RegularExpressions.Regex.Escape(kvp.Key)}\b", 
                kvp.Value, 
                System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        }
        
        return result;
    }
    
    private string NormalizeLanguageCode(string languageCode)
    {
        // Normalize language codes to simple 2-letter codes
        return languageCode?.ToLower() switch
        {
            "en-us" or "en-gb" or "english" => "en",
            "pl-pl" or "polish" => "pl",
            _ => languageCode?.ToLower()?.Split('-')[0] ?? "en"
        };
    }
}

// MyMemory API Response DTOs
internal class MyMemoryResponse
{
    public int ResponseStatus { get; set; }
    public MyMemoryResponseData? ResponseData { get; set; }
}

internal class MyMemoryResponseData
{
    public string? TranslatedText { get; set; }
    public double? Match { get; set; }
}
