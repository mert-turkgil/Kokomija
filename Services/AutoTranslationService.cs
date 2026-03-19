using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;

namespace Kokomija.Services;

/// <summary>
/// Auto-translation service using DeepL API as primary (auto-detect source language).
/// Falls back to MyMemory API if DeepL key is missing or quota exceeded.
/// Falls back to basic dictionary if both APIs fail.
/// </summary>
public class AutoTranslationService : IAutoTranslationService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<AutoTranslationService> _logger;
    private readonly IConfiguration _configuration;
    
    private const string DeepLApiUrl = "https://api-free.deepl.com/v2/translate";
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
        
        // Try DeepL first
        var deepLKey = _configuration["DeepL:ApiKey"];
        if (!string.IsNullOrEmpty(deepLKey))
        {
            var deepLResult = await TranslateWithDeepLAsync(text, targetLang, deepLKey);
            if (deepLResult != null)
                return deepLResult;
        }
        
        // Fallback to MyMemory
        var myMemoryResult = await TranslateWithMyMemoryAsync(text, sourceLang, targetLang);
        if (myMemoryResult != null)
            return myMemoryResult;
        
        // Final fallback: dictionary
        return await FallbackTranslateAsync(text, sourceLang, targetLang);
    }
    
    public async Task<List<TranslationResult>> TranslateBatchAsync(List<string> texts, string sourceLanguage, string targetLanguage)
    {
        var results = new List<TranslationResult>();
        
        foreach (var text in texts)
        {
            var result = await TranslateAsync(text, sourceLanguage, targetLanguage);
            results.Add(result);
            
            await Task.Delay(50);
        }
        
        return results;
    }

    #region DeepL

    private async Task<TranslationResult?> TranslateWithDeepLAsync(string text, string targetLang, string apiKey)
    {
        try
        {
            var client = _httpClientFactory.CreateClient();
            client.Timeout = TimeSpan.FromSeconds(15);

            // DeepL uses uppercase language codes: EN, PL, DE, etc.
            // For English target, DeepL requires EN-US or EN-GB
            var deepLTarget = targetLang.ToUpper() switch
            {
                "EN" => "EN-US",
                _ => targetLang.ToUpper()
            };

            var formData = new List<KeyValuePair<string, string>>
            {
                new("auth_key", apiKey),
                new("text", text),
                new("target_lang", deepLTarget)
                // No source_lang — DeepL auto-detects
            };

            var content = new FormUrlEncodedContent(formData);
            var response = await client.PostAsync(DeepLApiUrl, content);
            
            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                _logger.LogWarning("DeepL API key is invalid or unauthorized");
                return null;
            }
            
            if (response.StatusCode == (System.Net.HttpStatusCode)456 ||
                response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
            {
                _logger.LogWarning("DeepL API quota exceeded, falling back to MyMemory");
                return null;
            }
            
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<DeepLResponse>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                
                if (result?.Translations != null && result.Translations.Count > 0)
                {
                    var translation = result.Translations[0];
                    var detectedSource = translation.DetectedSourceLanguage?.ToLower() ?? "auto";
                    
                    _logger.LogInformation("DeepL translated from {Source} to {Target}", detectedSource, targetLang);
                    
                    return new TranslationResult
                    {
                        Success = true,
                        OriginalText = text,
                        TranslatedText = translation.Text,
                        SourceLanguage = detectedSource,
                        TargetLanguage = targetLang
                    };
                }
            }
            
            _logger.LogWarning("DeepL API returned {Status}", response.StatusCode);
            return null;
        }
        catch (TaskCanceledException)
        {
            _logger.LogWarning("DeepL translation request timed out");
            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error translating with DeepL API");
            return null;
        }
    }

    #endregion

    #region MyMemory Fallback

    private async Task<TranslationResult?> TranslateWithMyMemoryAsync(string text, string sourceLang, string targetLang)
    {
        try
        {
            var client = _httpClientFactory.CreateClient();
            client.Timeout = TimeSpan.FromSeconds(10);
            
            var langpair = $"{sourceLang}|{targetLang}";
            var encodedText = Uri.EscapeDataString(text);
            var requestUrl = $"{MyMemoryApiUrl}?q={encodedText}&langpair={langpair}";
            
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
                    
                    if (translatedText.Contains("MYMEMORY WARNING"))
                    {
                        _logger.LogWarning("MyMemory API rate limit warning");
                        return null;
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
            
            _logger.LogWarning("MyMemory API returned {Status}", response.StatusCode);
            return null;
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Error translating with MyMemory API");
            return null;
        }
    }

    #endregion

    #region Dictionary Fallback
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

    #endregion
}

// DeepL API Response DTOs
internal class DeepLResponse
{
    public List<DeepLTranslation> Translations { get; set; } = new();
}

internal class DeepLTranslation
{
    public string Text { get; set; } = string.Empty;
    public string? DetectedSourceLanguage { get; set; }
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
