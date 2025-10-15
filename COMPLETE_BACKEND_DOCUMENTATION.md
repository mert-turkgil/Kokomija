# Kokomija E-Commerce Platform - Complete Backend Documentation

## Project Overview
**Kokomija** is a textile e-commerce platform built with ASP.NET Core 9.0, featuring:
- Commission-based sales (1.5% default, configurable)
- Stripe payment integration
- Coupon/discount system
- ASP.NET Core Identity for user management
- Professional Repository & Unit of Work pattern
- Database abstraction for future migration flexibility

---

## Technology Stack

### Core Framework
- **ASP.NET Core 9.0** - MVC web application
- **Entity Framework Core 9.0** - ORM with SQL Server
- **.NET 9.0** - Runtime

### Key Packages
- `Microsoft.EntityFrameworkCore.SqlServer` (9.0.0) - Database provider
- `Microsoft.AspNetCore.Identity.EntityFrameworkCore` (9.0.0) - Authentication
- `Stripe.net` (45.14.0) - Payment processing
- `Microsoft.EntityFrameworkCore.Tools` (9.0.0) - Migrations

### Patterns & Architecture
- **Repository Pattern** - Data access abstraction
- **Unit of Work Pattern** - Transaction management
- **Dependency Injection** - Service lifetime management
- **Configuration-based settings** - Environment-specific configs

---

## Database Schema

### Identity Tables (ASP.NET Core Identity)
- `AspNetUsers` - User accounts with Stripe customer integration
- `AspNetRoles` - Roles (Admin, Manager, Customer)
- `AspNetUserRoles` - User-role mappings
- `AspNetUserClaims`, `AspNetRoleClaims`, `AspNetUserLogins`, `AspNetUserTokens`

### Business Tables

#### Products & Categories
```
Categories
├── Id (int, PK)
├── Name (string, required)
├── Slug (string, unique)
├── Description (string, optional)
├── ParentCategoryId (int?, nullable for hierarchy)
├── ShowInNavbar (bool)
├── DisplayOrder (int)
└── IsActive (bool)

Products
├── Id (int, PK)
├── Name (string, required)
├── Description (string)
├── Price (decimal 18,2)
├── StripeProductId (string, optional)
├── StripePriceId (string, optional)
├── CategoryId (int, FK)
├── Gender (enum: Male/Female/Unisex)
├── IsActive (bool)
└── CreatedAt (DateTime)

ProductImages
├── Id (int, PK)
├── ProductId (int, FK)
├── ImageUrl (string, required)
├── IsMain (bool)
└── DisplayOrder (int)

Colors
├── Id (int, PK)
├── Name (string, required)
├── HexCode (string, #RRGGBB)
└── IsActive (bool)

Sizes
├── Id (int, PK)
├── Name (string, required, e.g., "XS", "S", "M", "L", "XL")
├── DisplayOrder (int)
└── IsActive (bool)

ProductColors (Many-to-Many)
├── ProductId (int, FK)
└── ColorId (int, FK)

ProductSizes (Many-to-Many)
├── ProductId (int, FK)
└── SizeId (int, FK)

ProductVariants
├── Id (int, PK)
├── ProductId (int, FK)
├── ColorId (int, FK)
├── SizeId (int, FK)
├── SKU (string, unique)
├── StockQuantity (int)
├── PriceAdjustment (decimal 18,2, default 0)
└── IsActive (bool)
```

#### Orders & Payments
```
Orders
├── Id (int, PK)
├── UserId (string, FK to AspNetUsers, nullable for guests)
├── CouponId (int?, FK, nullable)
├── OrderDate (DateTime)
├── SubtotalAmount (decimal 18,2, before discount)
├── DiscountAmount (decimal 18,2, default 0)
├── TotalAmount (decimal 18,2, after discount)
├── CommissionAmount (decimal 18,2, calculated)
├── Status (enum: Pending/Processing/Shipped/Delivered/Cancelled)
├── PaymentStatus (enum: Pending/Completed/Failed/Refunded)
├── StripePaymentIntentId (string, optional)
├── ShippingAddress (string)
├── BillingAddress (string)
└── CustomerEmail (string)

OrderItems
├── Id (int, PK)
├── OrderId (int, FK)
├── ProductVariantId (int, FK)
├── Quantity (int)
├── UnitPrice (decimal 18,2)
└── TotalPrice (decimal 18,2, calculated)
```

#### Coupons & Discounts
```
Coupons
├── Id (int, PK)
├── Code (string, unique, required)
├── Description (string)
├── DiscountType (enum: Percentage/FixedAmount)
├── DiscountValue (decimal 18,2)
├── MinimumOrderAmount (decimal 18,2, nullable)
├── MaximumDiscountAmount (decimal 18,2, nullable)
├── UsageLimit (int?, nullable for unlimited)
├── UsageLimitPerUser (int?, nullable)
├── CurrentUsageCount (int, default 0)
├── ValidFrom (DateTime)
├── ValidUntil (DateTime)
├── StripeCouponId (string, optional)
├── StripePromotionCodeId (string, optional)
└── IsActive (bool)

CouponUsages
├── Id (int, PK)
├── CouponId (int, FK)
├── OrderId (int, FK)
├── UserId (string, FK, nullable)
└── UsedAt (DateTime)
```

---

## Repository Layer

### Interface Hierarchy
```
IRepository<T> (Generic)
├── GetByIdAsync(id)
├── GetAllAsync()
├── AddAsync(entity)
├── UpdateAsync(entity)
├── DeleteAsync(entity)
└── SaveChangesAsync()

Specialized Repositories:
├── IProductRepository : IRepository<Product>
│   └── GetProductsWithDetailsAsync(), GetProductByCategoryAsync()
│
├── ICategoryRepository : IRepository<Category>
│   └── GetCategoriesForNavbarAsync(), GetSubCategoriesAsync()
│
├── IColorRepository : IRepository<Color>
│   └── GetActiveColorsAsync()
│
├── ISizeRepository : IRepository<Size>
│   └── GetActiveSizesAsync()
│
├── IProductVariantRepository : IRepository<ProductVariant>
│   └── GetVariantBySkuAsync(), CheckStockAsync()
│
├── IOrderRepository : IRepository<Order>
│   └── GetOrdersByUserAsync(), GetOrderWithDetailsAsync()
│
├── IUserRepository : IRepository<ApplicationUser>
│   └── GetUserByStripeCustomerIdAsync()
│
└── ICouponRepository : IRepository<Coupon>
    ├── GetActiveByCodeAsync(code)
    ├── ValidateCouponAsync(code, userId, orderAmount)
    ├── CalculateDiscountAsync(coupon, orderAmount)
    ├── IncrementUsageAsync(couponId)
    └── GetUserUsageCountAsync(couponId, userId)
```

### Unit of Work
```csharp
public interface IUnitOfWork : IDisposable
{
    // Specialized Repositories
    IProductRepository Products { get; }
    ICategoryRepository Categories { get; }
    IColorRepository Colors { get; }
    ISizeRepository Sizes { get; }
    IProductVariantRepository ProductVariants { get; }
    IOrderRepository Orders { get; }
    IUserRepository Users { get; }
    ICouponRepository Coupons { get; }
    
    // Generic Repository Access
    IRepository<T> Repository<T>() where T : class;
    
    // Transaction Management
    Task<int> SaveChangesAsync();
    Task<IDbContextTransaction> BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}
```

---

## Services Layer

### Stripe Service
```csharp
public interface IStripeService
{
    // Customer Management
    Task<Customer> CreateCustomerAsync(string email, string name);
    Task<Customer> GetCustomerAsync(string customerId);
    Task<Customer> UpdateCustomerAsync(string customerId, CustomerUpdateOptions options);
    
    // Product & Pricing
    Task<Stripe.Product> CreateProductAsync(string name, string description);
    Task<Price> CreatePriceAsync(string productId, long unitAmount, string currency);
    
    // Payment Processing
    Task<PaymentIntent> CreatePaymentIntentAsync(long amount, string currency, 
        string customerId, decimal commissionRate);
    Task<PaymentIntent> ConfirmPaymentIntentAsync(string paymentIntentId);
    
    // Coupons & Promotions
    Task<Stripe.Coupon> CreateStripeCouponAsync(string couponCode, 
        string discountType, decimal discountValue, DateTime? expiresAt);
    Task<PromotionCode> CreateStripePromotionCodeAsync(string couponId, string code);
    Task<Stripe.Coupon> GetStripeCouponAsync(string couponId);
}
```

---

## Configuration Files

### appsettings.json (Base)
```json
{
  "Database": {
    "Provider": "SqlServer"
  },
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=KokomijaDb;...",
    "PostgreSQLConnection": "...",
    "MySQLConnection": "...",
    "SQLiteConnection": "..."
  },
  "Stripe": {
    "PublishableKey": "pk_test_...",
    "SecretKey": "sk_test_...",
    "WebhookSecret": "whsec_..."
  },
  "Commission": {
    "DefaultRate": 0.015
  },
  "AdminUser": {
    "Email": "admin@kokomija.com",
    "Password": "Admin@123456",
    "FirstName": "Admin",
    "LastName": "Kokomija"
  },
  "Identity": {
    "Password": { "RequiredLength": 8, ... },
    "Lockout": { "MaxFailedAccessAttempts": 5, ... },
    "SignIn": { "RequireConfirmedEmail": false }
  }
}
```

### appsettings.Development.json
- Relaxed password requirements (6 characters)
- Email confirmation disabled
- Development database (KokomijaDb_Dev)
- Test Stripe keys

### appsettings.Production.json
- Strict password requirements (12 characters)
- Email confirmation enabled
- Production database
- Live Stripe keys

---

## Identity System

### Roles
- **Admin** - Full system access
- **Manager** - Product and order management
- **Customer** - Shopping and order tracking

### ApplicationUser (Extended IdentityUser)
```csharp
public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? StripeCustomerId { get; set; }
    public ICollection<Order> Orders { get; set; }
}
```

### Auto-Seeding
On application startup:
1. Apply pending migrations
2. Create roles (Admin, Manager, Customer)
3. Create admin user from configuration
4. Seed initial data (sizes, colors, categories)

---

## Database Abstraction

### Purpose
Allows switching from SQL Server to PostgreSQL, MySQL, or SQLite with minimal code changes.

### How to Switch Database

1. **Install new provider package**
   ```bash
   dotnet remove package Microsoft.EntityFrameworkCore.SqlServer
   dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 9.0.0
   ```

2. **Uncomment provider class** in `Data/Providers/DatabaseProviders.cs`

3. **Update appsettings.json**
   ```json
   {
     "Database": {
       "Provider": "PostgreSQL"
     }
   }
   ```

4. **Create new migrations**
   ```bash
   Remove-Item -Path ".\Migrations" -Recurse -Force
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

**No other code changes required!**

---

## Key Features

### Commission Tracking
- Every order automatically calculates commission based on configurable rate
- `Order.CommissionAmount = Order.TotalAmount * Commission.DefaultRate`
- Rate can be changed via email approval by updating `appsettings.json`

### Coupon System
- **Two discount types**: Percentage or Fixed Amount
- **Usage limits**: Global limit and per-user limit
- **Date validation**: Valid from/until dates
- **Order minimums**: Minimum order amount for eligibility
- **Maximum caps**: Maximum discount for percentage coupons
- **Stripe integration**: Syncs with Stripe Coupon and PromotionCode APIs
- **Usage tracking**: CouponUsage records every redemption

### Product Variants
- Products can have multiple variants (Color + Size combinations)
- Each variant has its own SKU and stock quantity
- Price adjustments per variant (e.g., +$5 for XL size)

### Guest Checkout
- Orders.UserId is nullable
- Guest orders tracked by email address
- Can be converted to user accounts later

---

## API Endpoints (To Be Implemented)

### Public
- `GET /` - Home page
- `GET /products` - Product listing
- `GET /products/{id}` - Product details
- `POST /cart/add` - Add to cart
- `POST /checkout` - Checkout process

### Account
- `POST /account/register` - User registration
- `POST /account/login` - User login
- `GET /account/profile` - User profile
- `GET /account/orders` - Order history

### Admin
- `GET /admin/products` - Manage products
- `GET /admin/orders` - Manage orders
- `GET /admin/coupons` - Manage coupons
- `GET /admin/users` - Manage users

---

## Next Steps

### Immediate (Required for MVP)
1. ✅ Entity structure
2. ✅ Repository pattern
3. ✅ Unit of Work
4. ✅ Identity integration
5. ✅ Stripe service
6. ✅ Coupon system
7. ✅ Database abstraction
8. ⏳ **Create database migration**
9. ⏳ **Account controllers** (Register, Login, Profile)
10. ⏳ **Shopping flow** (Cart, Checkout)

### Short-term
- Admin panel controllers
- Frontend views (Razor pages)
- Email service (order confirmations)
- Stripe webhooks (payment status updates)
- Image upload functionality
- Search and filtering

### Long-term
- Product reviews and ratings
- Wishlist functionality
- Advanced reporting (sales, commissions)
- Multi-language support
- Mobile app API
- Analytics integration

---

## Migration Commands

### Create Initial Migration
```bash
dotnet ef migrations add InitialCreateWithIdentityAndCoupons
```

### Apply Migration
```bash
dotnet ef database update
```

### Remove Last Migration
```bash
dotnet ef migrations remove
```

### Generate SQL Script
```bash
dotnet ef migrations script -o migration.sql
```

---

## Running the Application

### Development
```bash
dotnet run
```

### Production
```bash
dotnet publish -c Release
# Deploy to IIS, Azure, or Linux server
```

---

## File Structure Reference

```
Kokomija/
├── Entity/                          # Domain models
│   ├── ApplicationUser.cs
│   ├── Product.cs, Category.cs
│   ├── Color.cs, Size.cs
│   ├── ProductVariant.cs, ProductImage.cs
│   ├── Order.cs, OrderItem.cs
│   └── Coupon.cs, CouponUsage.cs
│
├── Data/
│   ├── ApplicationDbContext.cs      # EF Core context
│   ├── DbSeeder.cs                  # Data seeding
│   ├── IdentitySeeder.cs            # Identity seeding
│   ├── Abstract/                    # Repository interfaces
│   │   ├── IRepository.cs
│   │   ├── IUnitOfWork.cs
│   │   ├── IDatabaseProvider.cs
│   │   └── I*Repository.cs
│   ├── Concrete/                    # Repository implementations
│   │   ├── Repository.cs
│   │   ├── UnitOfWork.cs
│   │   └── *Repository.cs
│   ├── Configurations/              # EF Core Fluent API configs
│   │   └── *Configuration.cs
│   └── Providers/                   # Database providers
│       └── DatabaseProviders.cs
│
├── Services/
│   └── StripeService.cs            # Stripe integration
│
├── Controllers/
│   ├── HomeController.cs
│   └── ProductController.cs
│
├── Views/
│   ├── Home/, Shared/
│   └── *.cshtml
│
├── wwwroot/                         # Static files
│   ├── css/, js/, lib/
│
├── appsettings.json                 # Configuration
├── appsettings.Development.json
├── appsettings.Production.json
├── Program.cs                       # Application startup
└── Kokomija.csproj                 # Project file
```

---

## Security Considerations

### Implemented
- ✅ Password hashing (ASP.NET Core Identity)
- ✅ Role-based authorization
- ✅ Account lockout after failed attempts
- ✅ HTTPS enforcement
- ✅ Secure cookie settings
- ✅ SQL injection prevention (EF Core)

### To Implement
- ⏳ Email confirmation
- ⏳ Two-factor authentication
- ⏳ CSRF protection
- ⏳ Rate limiting
- ⏳ Input validation
- ⏳ XSS prevention

---

## Additional Documentation

See also:
- `DATABASE_MIGRATION_GUIDE.md` - Database switching guide
- `DATA_LAYER_COMPLETE.md` - Repository pattern details
- `IDENTITY_SYSTEM_COMPLETE.md` - Identity setup details
- `BACKEND_INTEGRATION_COMPLETE.md` - Integration guide

---

**Last Updated:** December 2024
**Version:** 1.0.0
**Status:** Backend Complete, Frontend Pending
