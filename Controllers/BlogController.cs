using Kokomija.Data.Abstract;
using Kokomija.Models.ViewModels.Blog;
using Kokomija.Services;
using Microsoft.AspNetCore.Mvc;
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

        // GET: /Blog/Post/{slug}
        [Route("Blog/Post/{slug}")]
        public async Task<IActionResult> Details(string slug)
        {
            try
            {
                var blog = await _unitOfWork.Blogs.GetBySlugAsync(slug);
                
                if (blog == null)
                {
                    return NotFound();
                }

                // Increment views
                await _unitOfWork.Blogs.IncrementViewsAsync(blog.Id);

                // Get related posts
                var relatedPosts = await _unitOfWork.Blogs.GetRelatedBlogsAsync(blog.Id, 3);

                var viewModel = new BlogDetailsViewModel
                {
                    Id = blog.Id,
                    Title = blog.Title,
                    Slug = blog.Slug,
                    Content = blog.Content,
                    FeaturedImage = blog.FeaturedImage,
                    AuthorName = blog.Author?.UserName ?? "Unknown",
                    CategoryName = blog.Category?.Name ?? "",
                    CategoryId = blog.CategoryId,
                    PublishedDate = blog.PublishedDate,
                    UpdatedAt = blog.UpdatedAt,
                    Views = blog.Views,
                    Tags = blog.Tags?.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(t => t.Trim()).ToList() ?? new List<string>(),
                    ReadingTimeMinutes = CalculateReadingTime(blog.Content),
                    RelatedPosts = relatedPosts.Select(b => MapToBlogPostViewModel(b)),
                    RelatedProduct = blog.Product,
                    MetaDescription = blog.MetaDescription ?? blog.Excerpt ?? "",
                    MetaKeywords = blog.MetaKeywords ?? "",
                    CanonicalUrl = Url.Action("Details", "Blog", new { slug = blog.Slug }, Request.Scheme) ?? ""
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
        public async Task<IActionResult> Tag(string tag, int page = 1)
        {
            return RedirectToAction("Index", new { tag, page });
        }

        // GET: /Blog/Search?q={query}
        [Route("Blog/Search")]
        public async Task<IActionResult> Search(string q, int page = 1)
        {
            return RedirectToAction("Index", new { search = q, page });
        }

        // Helper methods
        private BlogPostViewModel MapToBlogPostViewModel(Entity.Blog blog)
        {
            return new BlogPostViewModel
            {
                Id = blog.Id,
                Title = blog.Title,
                Slug = blog.Slug,
                Excerpt = blog.Excerpt ?? StripHtml(blog.Content).Substring(0, Math.Min(200, blog.Content.Length)) + "...",
                FeaturedImage = blog.FeaturedImage,
                AuthorName = blog.Author?.UserName ?? "Unknown",
                CategoryName = blog.Category?.Name ?? "",
                CategoryId = blog.CategoryId,
                PublishedDate = blog.PublishedDate,
                Views = blog.Views,
                Tags = blog.Tags?.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(t => t.Trim()).ToList() ?? new List<string>(),
                ReadingTimeMinutes = CalculateReadingTime(blog.Content)
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
