using Kokomija.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kokomija.Data.Providers
{
    /// <summary>
    /// SQL Server Database Provider (Current Default)
    /// Package: Microsoft.EntityFrameworkCore.SqlServer
    /// </summary>
    public class SqlServerProvider : IDatabaseProvider
    {
        public string ProviderName => "SqlServer";

        public string GetConnectionString(IConfiguration configuration)
        {
            return configuration.GetConnectionString("DefaultConnection") 
                ?? throw new InvalidOperationException("DefaultConnection not found in configuration");
        }

        public void ConfigureDbContext(DbContextOptionsBuilder options, string connectionString)
        {
            options.UseSqlServer(connectionString, sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 3,
                    maxRetryDelay: TimeSpan.FromSeconds(5),
                    errorNumbersToAdd: null);
                sqlOptions.CommandTimeout(30);
            });
        }
    }

    /* 
     * POSTGRESQL PROVIDER
     * 
     * To enable PostgreSQL support:
     * 1. Install package: dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 9.0.0
     * 2. Add using: using Npgsql.EntityFrameworkCore.PostgreSQL;
     * 3. Uncomment this class
     * 4. Update appsettings.json: "Database": { "Provider": "PostgreSQL" }
     * 
    public class PostgreSqlProvider : IDatabaseProvider
    {
        public string ProviderName => "PostgreSQL";

        public string GetConnectionString(IConfiguration configuration)
        {
            return configuration.GetConnectionString("PostgreSQLConnection") 
                ?? throw new InvalidOperationException("PostgreSQLConnection not found in configuration");
        }

        public void ConfigureDbContext(DbContextOptionsBuilder options, string connectionString)
        {
            options.UseNpgsql(connectionString, npgsqlOptions =>
            {
                npgsqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 3,
                    maxRetryDelay: TimeSpan.FromSeconds(5),
                    errorCodesToAdd: null);
                npgsqlOptions.CommandTimeout(30);
            });
        }
    }
    */

    /* 
     * MYSQL PROVIDER
     * 
     * To enable MySQL support:
     * 1. Install package: dotnet add package Pomelo.EntityFrameworkCore.MySql --version 9.0.0
     * 2. Add using: using Pomelo.EntityFrameworkCore.MySql;
     * 3. Uncomment this class
     * 4. Update appsettings.json: "Database": { "Provider": "MySQL" }
     * 
    public class MySqlProvider : IDatabaseProvider
    {
        public string ProviderName => "MySQL";

        public string GetConnectionString(IConfiguration configuration)
        {
            return configuration.GetConnectionString("MySQLConnection") 
                ?? throw new InvalidOperationException("MySQLConnection not found in configuration");
        }

        public void ConfigureDbContext(DbContextOptionsBuilder options, string connectionString)
        {
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), mySqlOptions =>
            {
                mySqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 3,
                    maxRetryDelay: TimeSpan.FromSeconds(5),
                    errorNumbersToAdd: null);
                mySqlOptions.CommandTimeout(30);
            });
        }
    }
    */

    /* 
     * SQLITE PROVIDER
     * 
     * To enable SQLite support:
     * 1. Install package: dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 9.0.0
     * 2. Add using: using Microsoft.EntityFrameworkCore;
     * 3. Uncomment this class
     * 4. Update appsettings.json: "Database": { "Provider": "SQLite" }
     * 
    public class SqliteProvider : IDatabaseProvider
    {
        public string ProviderName => "SQLite";

        public string GetConnectionString(IConfiguration configuration)
        {
            return configuration.GetConnectionString("SQLiteConnection") 
                ?? "Data Source=kokomija.db";
        }

        public void ConfigureDbContext(DbContextOptionsBuilder options, string connectionString)
        {
            options.UseSqlite(connectionString);
        }
    }
    */
}
