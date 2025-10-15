using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kokomija.Data.Abstract
{
    /// <summary>
    /// Database provider abstraction for future database changes
    /// Supports: SQL Server (current), PostgreSQL, MySQL, SQLite
    /// </summary>
    public interface IDatabaseProvider
    {
        string ProviderName { get; }
        string GetConnectionString(IConfiguration configuration);
        void ConfigureDbContext(DbContextOptionsBuilder options, string connectionString);
    }
}
