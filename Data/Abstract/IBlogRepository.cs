using Kokomija.Entity;

namespace Kokomija.Data.Abstract
{
    public interface IBlogRepository : IRepository<Blog>
    {
        Task<IEnumerable<Blog>> GetPublishedBlogsAsync();
        Task<IEnumerable<Blog>> GetBlogsByCategoryAsync(int categoryId);
        Task<IEnumerable<Blog>> GetBlogsByTagAsync(string tag);
        Task<IEnumerable<Blog>> SearchBlogsAsync(string query);
        Task<Blog?> GetBySlugAsync(string slug);
        Task IncrementViewsAsync(int blogId);
        Task<IEnumerable<Blog>> GetRelatedBlogsAsync(int blogId, int count = 3);
        Task<IEnumerable<Blog>> GetRecentBlogsAsync(int count = 5);
        Task<Dictionary<string, int>> GetPopularTagsAsync(int count = 10);
    }
}
