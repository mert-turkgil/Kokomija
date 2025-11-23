namespace Kokomija.Models.ViewModels.Admin
{
    public class TranslationItemViewModel
    {
        public string ResourceFile { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public string EnglishValue { get; set; } = string.Empty;
        public string PolishValue { get; set; } = string.Empty;
        public string? Comment { get; set; }
    }

    public class TranslationUpdateDto
    {
        public string FileName { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public string CultureCode { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }

    public class TranslationSearchDto
    {
        public string SearchTerm { get; set; } = string.Empty;
        public string? FileName { get; set; }
    }

    public class TranslationCommentUpdateDto
    {
        public string FileName { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public string? Comment { get; set; }
    }
}
