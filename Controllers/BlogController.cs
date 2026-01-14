using Kokomija.Data.Abstract;
using Kokomija.Models.ViewModels.Blog;
using Kokomija.Services;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Kokomija.Controllers
{
    public class BlogController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BlogController> _logger;
        private readonly ILocalizationService _localizationService;

        public BlogController(
            IUnitOfWork unitOfWork,
            ILogger<BlogController> logger,
            ILocalizationService localizationService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _localizationService = localizationService;
        }

        // GET: /Blog
        public async Task<IActionResult> Index(int? categoryId, string? tag, string? search, int page = 1)
        {
            try
            {
                const int pageSize = 9;
                
                // Get filtered blogs
                IEnumerable<Entity.Blog> blogs;
                
                if (categoryId.HasValue)
                {
                    blogs = await _unitOfWork.Blogs.GetBlogsByCategoryAsync(categoryId.Value);
                }
                else if (!string.IsNullOrWhiteSpace(tag))
                {
                    blogs = await _unitOfWork.Blogs.GetBlogsByTagAsync(tag);
                }
                else if (!string.IsNullOrWhiteSpace(search))
                {
                    blogs = await _unitOfWork.Blogs.SearchBlogsAsync(search);
                }
                else
                {
                    blogs = await _unitOfWork.Blogs.GetPublishedBlogsAsync();
                }

                // Pagination
                var totalPosts = blogs.Count();
                var totalPages = (int)Math.Ceiling(totalPosts / (double)pageSize);
                var paginatedBlogs = blogs.Skip((page - 1) * pageSize).Take(pageSize);

                // Get sidebar data
                var categories = await _unitOfWork.BlogCategories.GetActiveCategoriesAsync();
                var categoryCounts = await _unitOfWork.BlogCategories.GetCategoryPostCountsAsync();
                var recentPosts = await _unitOfWork.Blogs.GetRecentBlogsAsync(5);
                var popularTags = await _unitOfWork.Blogs.GetPopularTagsAsync(15);

                var viewModel = new BlogIndexViewModel
                {
                    Posts = paginatedBlogs.Select(b => MapToBlogPostViewModel(b)),
                    Categories = categories,
                    RecentPosts = recentPosts.Select(b => MapToBlogPostViewModel(b)),
                    PopularTags = popularTags.Select(kv => new TagViewModel { Name = kv.Key, Count = kv.Value }),
                    SelectedCategoryId = categoryId,
                    SelectedTag = tag,
                    SearchQuery = search,
                    CurrentPage = page,
                    TotalPages = totalPages,
                    PageSize = pageSize,
                    TotalPosts = totalPosts
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading blog index");
                return View("Error");
            }
        }

        // GET: /Blog/Post/{slug} - Localized blog post URLs
        [Route("Blog/Post/{slug}")]
        [Route("{culture}/blog/{slug}")]
        [Route("{culture}/artykul/{slug}")]
        [Route("{culture}/makale/{slug}")]
        public async Task<IActionResult> Details(string slug, string? culture = null)
        {
            try
            {
                // Set culture if provided
                if (!string.IsNullOrEmpty(culture))
                {
                    var cultureCode = culture switch
                    {
                        "pl" => "pl-PL",
                        "tr" => "tr-TR",
                        _ => "en-US"
                    };
                    var cultureInfo = new CultureInfo(cultureCode);
                    CultureInfo.CurrentCulture = cultureInfo;
                    CultureInfo.CurrentUICulture = cultureInfo;
                }

                var blog = await _unitOfWork.Blogs.GetBySlugAsync(slug);
                
                if (blog == null)
                {
                    return NotFound();
                }

                // Get translation for current culture
                var currentCulture = CultureInfo.CurrentCulture.Name;
                var translation = blog.Translations?.FirstOrDefault(t => t.CultureCode == currentCulture)
                                ?? blog.Translations?.FirstOrDefault(t => t.CultureCode == "pl-PL");

                if (translation == null)
                {
                    return NotFound();
                }

                // Increment views
                await _unitOfWork.Blogs.IncrementViewsAsync(blog.Id);

                // Get related posts
                var relatedPosts = await _unitOfWork.Blogs.GetRelatedBlogsAsync(blog.Id, 3);

                // Generate localized canonical URL
                var currentCultureShort = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
                var blogPathSegment = currentCultureShort switch
                {
                    "pl" => "artykul",
                    "tr" => "makale",
                    _ => "blog"
                };
                var canonicalUrl = $"{Request.Scheme}://{Request.Host}/{currentCultureShort}/{blogPathSegment}/{translation.Slug}";

                var viewModel = new BlogDetailsViewModel
                {
                    Id = blog.Id,
                    Title = translation.Title,
                    Slug = translation.Slug,
                    Content = translation.Content,
                    FeaturedImage = blog.FeaturedImage,
                    AuthorName = blog.Author?.UserName ?? "Unknown",
                    CategoryName = blog.Category?.Name ?? "",
                    CategoryId = blog.CategoryId,
                    PublishedDate = blog.PublishedDate,
                    UpdatedAt = blog.UpdatedAt,
                    Views = blog.Views,
                    Tags = translation.Tags?.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(t => t.Trim()).ToList() ?? new List<string>(),
                    ReadingTimeMinutes = CalculateReadingTime(translation.Content),
                    RelatedPosts = relatedPosts.Select(b => MapToBlogPostViewModel(b)),
                    RelatedProduct = blog.Product,
                    MetaDescription = translation.MetaDescription ?? translation.Excerpt ?? "",
                    MetaKeywords = translation.MetaKeywords ?? "",
                    CanonicalUrl = canonicalUrl
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading blog post: {Slug}", slug);
                return View("Error");
            }
        }

        // GET: /Blog/Category/{slug}
        [Route("Blog/Category/{slug}")]
        public async Task<IActionResult> Category(string slug, int page = 1)
        {
            try
            {
                var category = await _unitOfWork.BlogCategories.GetBySlugAsync(slug);
                
                if (category == null)
                {
                    return NotFound();
                }

                return RedirectToAction("Index", new { categoryId = category.Id, page });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading category: {Slug}", slug);
                return View("Error");
            }
        }

        // GET: /Blog/Tag/{tag}
        [Route("Blog/Tag/{tag}")]
        public IActionResult Tag(string tag, int page = 1)
        {
            return RedirectToAction("Index", new { tag, page });
        }

        // GET: /Blog/Search?q={query}
        [Route("Blog/Search")]
        public IActionResult Search(string q, int page = 1)
        {
            return RedirectToAction("Index", new { search = q, page });
        }

        // Helper methods
        private BlogPostViewModel MapToBlogPostViewModel(Entity.Blog blog)
        {
            var currentCulture = CultureInfo.CurrentCulture.Name;
            var translation = blog.Translations?.FirstOrDefault(t => t.CultureCode == currentCulture)
                            ?? blog.Translations?.FirstOrDefault(t => t.CultureCode == "pl-PL");

            if (translation == null)
            {
                return new BlogPostViewModel { Id = blog.Id };
            }

            var excerpt = translation.Excerpt;
            if (string.IsNullOrEmpty(excerpt) && !string.IsNullOrEmpty(translation.Content))
            {
                var strippedContent = StripHtml(translation.Content);
                excerpt = strippedContent.Length > 200 
                    ? strippedContent.Substring(0, 200) + "..." 
                    : strippedContent;
            }

            return new BlogPostViewModel
            {
                Id = blog.Id,
                Title = translation.Title,
                Slug = translation.Slug,
                Excerpt = excerpt ?? "",
                FeaturedImage = blog.FeaturedImage,
                AuthorName = blog.Author?.UserName ?? "Unknown",
                CategoryName = blog.Category?.Name ?? "",
                CategoryId = blog.CategoryId,
                PublishedDate = blog.PublishedDate,
                Views = blog.Views,
                Tags = translation.Tags?.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(t => t.Trim()).ToList() ?? new List<string>(),
                ReadingTimeMinutes = CalculateReadingTime(translation.Content)
            };
        }

        private int CalculateReadingTime(string content)
        {
            const int wordsPerMinute = 200;
            var text = StripHtml(content);
            var wordCount = text.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
            return Math.Max(1, (int)Math.Ceiling(wordCount / (double)wordsPerMinute));
        }

        private string StripHtml(string html)
        {
            if (string.IsNullOrWhiteSpace(html))
                return string.Empty;

            return Regex.Replace(html, "<.*?>", string.Empty);
        }
    }
}
