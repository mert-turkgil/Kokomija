# Database Provider Setup Guide

## Current Configuration
- **Provider:** Microsoft SQL Server
- **Package:** Microsoft.EntityFrameworkCore.SqlServer (9.0.0)

## Switching to Another Database

### 1. PostgreSQL

#### Step 1: Install NuGet Package
```bash
dotnet remove package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 9.0.0
```

#### Step 2: Update appsettings.json
```json
{
  "Database": {
    "Provider": "PostgreSQL"
  },
  "ConnectionStrings": {
    "PostgreSQLConnection": "Host=localhost;Port=5432;Database=KokomijaDb;Username=postgres;Password=yourpassword"
  }
}
```

#### Step 3: Add Using Statement (Already included in providers)
The `PostgreSqlProvider` class automatically uses `Npgsql.EntityFrameworkCore.PostgreSQL`.

---

### 2. MySQL / MariaDB

#### Step 1: Install NuGet Package
```bash
dotnet remove package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 9.0.0
```

#### Step 2: Update appsettings.json
```json
{
  "Database": {
    "Provider": "MySQL"
  },
  "ConnectionStrings": {
    "MySQLConnection": "Server=localhost;Port=3306;Database=KokomijaDb;User=root;Password=yourpassword;"
  }
}
```

---

### 3. SQLite (For Development/Testing)

#### Step 1: Install NuGet Package
```bash
dotnet remove package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 9.0.0
```

#### Step 2: Update appsettings.json
```json
{
  "Database": {
    "Provider": "SQLite"
  },
  "ConnectionStrings": {
    "SQLiteConnection": "Data Source=kokomija.db"
  }
}
```

---

## Migration Process

### After Switching Database Provider:

1. **Delete existing migrations** (if any):
   ```bash
   Remove-Item -Path ".\Migrations" -Recurse -Force
   ```

2. **Create new migration for the new database**:
   ```bash
   dotnet ef migrations add InitialCreate
   ```

3. **Apply migration**:
   ```bash
   dotnet ef database update
   ```

---

## Database-Specific Notes

### SQL Server
- **Best for:** Windows servers, Azure SQL Database
- **Pros:** Excellent tooling, Azure integration, full-text search
- **Cons:** Windows licensing costs, less portable

### PostgreSQL
- **Best for:** High-performance, advanced features, open-source
- **Pros:** Free, JSONB support, advanced indexing, arrays
- **Cons:** Slightly more complex setup on Windows

### MySQL
- **Best for:** High read performance, web applications
- **Pros:** Free, widely supported hosting, fast reads
- **Cons:** Limited transaction features compared to PostgreSQL

### SQLite
- **Best for:** Development, testing, small deployments
- **Pros:** Zero configuration, serverless, portable
- **Cons:** Not suitable for production with multiple users

---

## Connection String Examples

### SQL Server (Local)
```
Server=(localdb)\\mssqllocaldb;Database=KokomijaDb;Trusted_Connection=True;MultipleActiveResultSets=true
```

### SQL Server (Remote with Username/Password)
```
Server=your-server.database.windows.net;Database=KokomijaDb;User Id=yourusername;Password=yourpassword;Encrypt=True;TrustServerCertificate=False;
```

### PostgreSQL
```
Host=localhost;Port=5432;Database=KokomijaDb;Username=postgres;Password=yourpassword;SSL Mode=Prefer;Trust Server Certificate=true
```

### MySQL
```
Server=localhost;Port=3306;Database=KokomijaDb;User=root;Password=yourpassword;SslMode=Preferred;
```

### SQLite
```
Data Source=kokomija.db;Cache=Shared
```

---

## Troubleshooting

### Issue: "No database provider has been configured"
**Solution:** Make sure the correct NuGet package is installed and the provider name in appsettings.json matches exactly (case-insensitive).

### Issue: Connection string errors
**Solution:** Verify the connection string format for your specific database provider. Each provider has slightly different syntax.

### Issue: Migration errors when switching
**Solution:** Delete old migrations and create new ones for the target database. Different databases have different data types and features.

---

## Current Implementation Details

The database provider pattern is implemented in:
- `Data/Abstract/IDatabaseProvider.cs` - Interface
- `Data/Providers/DatabaseProviders.cs` - Implementations for all providers
- `Program.cs` - Provider selection logic based on configuration

**No code changes needed** when switching databases - only:
1. Update NuGet packages
2. Change appsettings.json configuration
3. Create new migrations
