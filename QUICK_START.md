# Kokomija - Quick Start Guide

## Prerequisites
- .NET 9.0 SDK installed
- SQL Server or SQL Server LocalDB
- Visual Studio Code or Visual Studio 2022
- Stripe account (for payment testing)

---

## Initial Setup

### 1. Clone/Open Project
```bash
cd C:\Users\mertu\Desktop\Kokomija
```

### 2. Restore Dependencies
```bash
dotnet restore
```

### 3. Configure Settings

#### Update `appsettings.Development.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=KokomijaDb_Dev;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "Stripe": {
    "PublishableKey": "pk_test_YOUR_TEST_KEY",
    "SecretKey": "sk_test_YOUR_TEST_SECRET",
    "WebhookSecret": "whsec_YOUR_WEBHOOK_SECRET"
  },
  "AdminUser": {
    "Email": "admin@kokomija.dev",
    "Password": "DevAdmin@123"
  }
}
```

### 4. Create Database Migration
```bash
dotnet ef migrations add InitialCreate
```

### 5. Apply Migration
```bash
dotnet ef database update
```

This will:
- ✅ Create all database tables
- ✅ Seed roles (Admin, Manager, Customer)
- ✅ Create admin user (admin@kokomija.dev / DevAdmin@123)
- ✅ Seed initial sizes (XS, S, M, L, XL, XXL)
- ✅ Seed initial colors (Black, White, Red, Blue, etc.)
- ✅ Seed sample categories

### 6. Run Application
```bash
dotnet run
```

Visit: `https://localhost:5001`

---

## Default Credentials

### Admin Account (Development)
- **Email:** admin@kokomija.dev
- **Password:** DevAdmin@123

### Admin Account (Production)
- **Email:** admin@kokomija.com
- **Password:** ⚠️ CHANGE THIS IN PRODUCTION!

---

## Testing Stripe Integration

### 1. Get Stripe Test Keys
1. Go to https://dashboard.stripe.com/test/apikeys
2. Copy your **Publishable key** (starts with `pk_test_`)
3. Copy your **Secret key** (starts with `sk_test_`)
4. Add them to `appsettings.Development.json`

### 2. Test Cards
```
Success: 4242 4242 4242 4242
Decline: 4000 0000 0000 0002
Requires Auth: 4000 0025 0000 3155

Any future expiry date
Any 3-digit CVC
Any postal code
```

### 3. Test Coupons
Stripe coupons will be automatically created when you create coupons in your application.

---

## Project Structure

```
Kokomija/
├── Entity/              # Domain models (Product, Order, etc.)
├── Data/
│   ├── Abstract/        # Repository interfaces
│   ├── Concrete/        # Repository implementations
│   ├── Configurations/  # EF Core table configs
│   └── Providers/       # Database abstraction
├── Services/            # Stripe integration
├── Controllers/         # MVC controllers
├── Views/               # Razor views
└── wwwroot/             # Static files
```

---

## Common Tasks

### Add a New Product (via Database)
```sql
INSERT INTO Products (Name, Description, Price, CategoryId, Gender, IsActive, CreatedAt)
VALUES ('Cotton T-Shirt', 'Comfortable cotton t-shirt', 29.99, 1, 2, 1, GETDATE());
```

### Create a Coupon
```sql
INSERT INTO Coupons (Code, DiscountType, DiscountValue, ValidFrom, ValidUntil, IsActive, CurrentUsageCount)
VALUES ('WELCOME10', 'percentage', 10.00, GETDATE(), DATEADD(MONTH, 1, GETDATE()), 1, 0);
```

### Check Orders
```sql
SELECT o.Id, o.OrderDate, o.TotalAmount, o.CommissionAmount, o.Status
FROM Orders o
ORDER BY o.OrderDate DESC;
```

---

## Switching Databases

### To PostgreSQL
1. Install package: `dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 9.0.0`
2. Uncomment `PostgreSqlProvider` in `Data/Providers/DatabaseProviders.cs`
3. Update `appsettings.json`: `"Database": { "Provider": "PostgreSQL" }`
4. Update connection string
5. Delete migrations folder and recreate: `dotnet ef migrations add InitialCreate`

See `DATABASE_MIGRATION_GUIDE.md` for detailed instructions.

---

## Next Development Steps

### 1. Create Account Controller
```bash
# Create new controller
code Controllers/AccountController.cs
```

Implement:
- Register (with Stripe customer creation)
- Login
- Logout
- Profile management

### 2. Create Shopping Controllers
```bash
code Controllers/CartController.cs
code Controllers/CheckoutController.cs
```

Implement:
- Add to cart
- View cart
- Apply coupon
- Checkout with Stripe

### 3. Create Admin Controllers
```bash
code Controllers/Admin/ProductsController.cs
code Controllers/Admin/OrdersController.cs
code Controllers/Admin/CouponsController.cs
```

### 4. Build Views
```bash
code Views/Account/Register.cshtml
code Views/Account/Login.cshtml
code Views/Products/Index.cshtml
code Views/Products/Details.cshtml
code Views/Cart/Index.cshtml
code Views/Checkout/Index.cshtml
```

---

## Troubleshooting

### Database Connection Issues
```bash
# Check SQL Server is running
sqlcmd -S (localdb)\mssqllocaldb -Q "SELECT @@VERSION"

# Recreate database
dotnet ef database drop
dotnet ef database update
```

### Migration Issues
```bash
# Remove last migration
dotnet ef migrations remove

# List migrations
dotnet ef migrations list

# Generate SQL script
dotnet ef migrations script -o migration.sql
```

### Build Errors
```bash
# Clean and rebuild
dotnet clean
dotnet build
```

---

## Important Files

- `appsettings.json` - Base configuration
- `appsettings.Development.json` - Dev overrides
- `appsettings.Production.json` - Production settings
- `Program.cs` - Application startup
- `Data/ApplicationDbContext.cs` - Database context
- `COMPLETE_BACKEND_DOCUMENTATION.md` - Full documentation

---

## API Testing (When Controllers Are Ready)

### Register New User
```http
POST /account/register
Content-Type: application/json

{
  "email": "user@example.com",
  "password": "User@123456",
  "firstName": "John",
  "lastName": "Doe"
}
```

### Create Order with Coupon
```http
POST /checkout
Content-Type: application/json

{
  "items": [
    { "productVariantId": 1, "quantity": 2 }
  ],
  "couponCode": "WELCOME10",
  "shippingAddress": "123 Main St",
  "billingAddress": "123 Main St"
}
```

---

## Security Checklist (Before Production)

- [ ] Change admin password in `appsettings.Production.json`
- [ ] Use production Stripe keys (not test keys)
- [ ] Enable `RequireConfirmedEmail` in Identity settings
- [ ] Set up SSL certificate (HTTPS)
- [ ] Configure CORS policies
- [ ] Set up logging (Serilog, Application Insights)
- [ ] Enable rate limiting
- [ ] Configure firewall rules
- [ ] Set up database backups
- [ ] Review commission rate (currently 1.5%)

---

## Support & Documentation

- **Full Documentation:** `COMPLETE_BACKEND_DOCUMENTATION.md`
- **Database Guide:** `DATABASE_MIGRATION_GUIDE.md`
- **Data Layer:** `DATA_LAYER_COMPLETE.md`
- **Identity System:** `IDENTITY_SYSTEM_COMPLETE.md`

---

## Current Status

✅ **Completed:**
- Entity structure (10+ models)
- Repository pattern with 8 specialized repositories
- Unit of Work pattern
- ASP.NET Core Identity integration
- Stripe payment service
- Coupon/discount system
- Database abstraction layer
- Auto-migration and seeding
- Environment-specific configurations

⏳ **Next Steps:**
- Create Account controllers
- Build shopping flow (Cart, Checkout)
- Admin panel development
- Frontend Razor views
- Email notifications
- Stripe webhook handlers

---

**Happy Coding! 🚀**
