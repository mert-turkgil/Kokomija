namespace Kokomija.Services;

/// <summary>
/// Service for automatic text translation between languages
/// </summary>
public interface IAutoTranslationService
{
    /// <summary>
    /// Translate text from source language to target language
    /// </summary>
    /// <param name="text">Text to translate</param>
    /// <param name="sourceLanguage">Source language code (e.g., "en", "pl")</param>
    /// <param name="targetLanguage">Target language code (e.g., "en", "pl")</param>
    /// <returns>Translated text</returns>
    Task<TranslationResult> TranslateAsync(string text, string sourceLanguage, string targetLanguage);
    
    /// <summary>
    /// Translate multiple texts at once
    /// </summary>
    Task<List<TranslationResult>> TranslateBatchAsync(List<string> texts, string sourceLanguage, string targetLanguage);
}

public class TranslationResult
{
    public bool Success { get; set; }
    public string OriginalText { get; set; } = string.Empty;
    public string TranslatedText { get; set; } = string.Empty;
    public string? ErrorMessage { get; set; }
    public string SourceLanguage { get; set; } = string.Empty;
    public string TargetLanguage { get; set; } = string.Empty;
}
