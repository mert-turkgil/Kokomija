using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;

namespace Kokomija.Data.Concrete
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        private new readonly ApplicationDbContext _context;

        public BlogRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Blog>> GetPublishedBlogsAsync()
        {
            return await _context.Blogs
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Where(b => b.IsPublished && !b.IsDeleted && b.PublishedDate <= DateTime.UtcNow)
                .OrderByDescending(b => b.PublishedDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Blog>> GetBlogsByCategoryAsync(int categoryId)
        {
            return await _context.Blogs
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Where(b => b.IsPublished && !b.IsDeleted && b.CategoryId == categoryId)
                .OrderByDescending(b => b.PublishedDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Blog>> GetBlogsByTagAsync(string tag)
        {
            return await _context.Blogs
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Where(b => b.IsPublished && !b.IsDeleted && b.Tags != null && b.Tags.Contains(tag))
                .OrderByDescending(b => b.PublishedDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Blog>> SearchBlogsAsync(string query)
        {
            var lowerQuery = query.ToLower();
            return await _context.Blogs
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Where(b => b.IsPublished && !b.IsDeleted &&
                    (b.Title.ToLower().Contains(lowerQuery) ||
                     b.Content.ToLower().Contains(lowerQuery) ||
                     (b.Excerpt != null && b.Excerpt.ToLower().Contains(lowerQuery)) ||
                     (b.Tags != null && b.Tags.ToLower().Contains(lowerQuery))))
                .OrderByDescending(b => b.PublishedDate)
                .ToListAsync();
        }

        public async Task<Blog?> GetBySlugAsync(string slug)
        {
            return await _context.Blogs
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Product)
                .FirstOrDefaultAsync(b => b.Slug == slug && b.IsPublished && !b.IsDeleted);
        }

        public async Task IncrementViewsAsync(int blogId)
        {
            var blog = await _context.Blogs.FindAsync(blogId);
            if (blog != null)
            {
                blog.Views++;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Blog>> GetRelatedBlogsAsync(int blogId, int count = 3)
        {
            var blog = await _context.Blogs.FindAsync(blogId);
            if (blog == null) return Enumerable.Empty<Blog>();

            // Get blogs from the same category or with overlapping tags
            var relatedBlogs = await _context.Blogs
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Where(b => b.IsPublished && !b.IsDeleted && b.Id != blogId &&
                    b.CategoryId == blog.CategoryId)
                .OrderByDescending(b => b.PublishedDate)
                .Take(count)
                .ToListAsync();

            // If we don't have enough from the same category, add some by tags
            if (relatedBlogs.Count < count && !string.IsNullOrEmpty(blog.Tags))
            {
                var blogTags = blog.Tags.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(t => t.Trim()).ToList();
                var additionalBlogs = await _context.Blogs
                    .Include(b => b.Author)
                    .Include(b => b.Category)
                    .Where(b => b.IsPublished && !b.IsDeleted && b.Id != blogId &&
                        b.CategoryId != blog.CategoryId &&
                        b.Tags != null)
                    .ToListAsync();

                var tagMatches = additionalBlogs
                    .Where(b => b.Tags!.Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Any(t => blogTags.Contains(t.Trim())))
                    .OrderByDescending(b => b.PublishedDate)
                    .Take(count - relatedBlogs.Count);

                relatedBlogs.AddRange(tagMatches);
            }

            return relatedBlogs.Take(count);
        }

        public async Task<IEnumerable<Blog>> GetRecentBlogsAsync(int count = 5)
        {
            return await _context.Blogs
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Where(b => b.IsPublished && !b.IsDeleted)
                .OrderByDescending(b => b.PublishedDate)
                .Take(count)
                .ToListAsync();
        }

        public async Task<Dictionary<string, int>> GetPopularTagsAsync(int count = 10)
        {
            var blogs = await _context.Blogs
                .Where(b => b.IsPublished && !b.IsDeleted && b.Tags != null)
                .Select(b => b.Tags)
                .ToListAsync();

            var tagCounts = new Dictionary<string, int>();
            foreach (var tags in blogs)
            {
                if (string.IsNullOrEmpty(tags)) continue;
                
                foreach (var tag in tags.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    var trimmedTag = tag.Trim();
                    if (tagCounts.ContainsKey(trimmedTag))
                        tagCounts[trimmedTag]++;
                    else
                        tagCounts[trimmedTag] = 1;
                }
            }

            return tagCounts
                .OrderByDescending(kv => kv.Value)
                .Take(count)
                .ToDictionary(kv => kv.Key, kv => kv.Value);
        }
    }
}
