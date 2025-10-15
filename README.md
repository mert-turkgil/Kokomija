# Kokomija Data Layer Architecture

## 📁 Project Structure

```
Data/
├── Abstract/                    # Repository interfaces (contracts)
│   ├── IRepository.cs          # Generic repository interface
│   ├── IProductRepository.cs   # Product-specific operations
│   ├── ICategoryRepository.cs  # Category-specific operations
│   ├── IColorRepository.cs     # Color-specific operations
│   ├── ISizeRepository.cs      # Size-specific operations
│   ├── IProductVariantRepository.cs
│   ├── IOrderRepository.cs
│   └── IUnitOfWork.cs          # Unit of Work pattern
│
├── Concrete/                    # Repository implementations
│   ├── Repository.cs           # Generic repository base
│   ├── ProductRepository.cs
│   ├── CategoryRepository.cs
│   ├── ColorRepository.cs
│   ├── SizeRepository.cs
│   ├── ProductVariantRepository.cs
│   ├── OrderRepository.cs
│   └── UnitOfWork.cs           # Unit of Work implementation
│
├── Configurations/              # EF Core entity configurations
│   ├── ProductConfiguration.cs
│   ├── CategoryConfiguration.cs
│   ├── ColorConfiguration.cs
│   ├── SizeConfiguration.cs
│   ├── ProductVariantConfiguration.cs
│   ├── ProductImageConfiguration.cs
│   ├── ProductColorConfiguration.cs
│   ├── ProductSizeConfiguration.cs
│   ├── OrderConfiguration.cs
│   └── OrderItemConfiguration.cs
│
├── ApplicationDbContext.cs      # EF Core DbContext
└── DbSeeder.cs                  # Seed data extension methods
```

## 🎯 Design Patterns Used

### 1. Repository Pattern
Abstracts data access logic and provides a collection-like interface for accessing domain objects.

### 2. Unit of Work Pattern
Maintains a list of objects affected by a business transaction and coordinates the writing out of changes and the resolution of concurrency problems.

### 3. Dependency Injection
All repositories and DbContext are registered as services and injected where needed.

## 🔧 Usage Examples

### Basic Usage with Unit of Work

```csharp
public class ProductController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        // Get all active products with images
        var products = await _unitOfWork.Products.GetActiveProductsAsync();
        return View(products);
    }

    public async Task<IActionResult> Details(int id)
    {
        // Get product with all details (category, images, variants, etc.)
        var product = await _unitOfWork.Products.GetProductWithDetailsAsync(id);
        
        if (product == null)
            return NotFound();
            
        return View(product);
    }
}
```

### Creating a Product with Transaction

```csharp
public async Task<IActionResult> Create(ProductViewModel model)
{
    try
    {
        await _unitOfWork.BeginTransactionAsync();

        // Create product in Stripe first
        var stripeProduct = await _stripeService.CreateProductAsync(model);

        // Create product entity
        var product = new Product
        {
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            StripeProductId = stripeProduct.Id,
            CategoryId = model.CategoryId
        };

        await _unitOfWork.Products.AddAsync(product);
        await _unitOfWork.SaveChangesAsync();

        // Create base price in Stripe
        var stripePrice = await _stripeService.CreatePriceAsync(stripeProduct.Id, product.Price);
        product.StripePriceId = stripePrice.Id;
        
        // Add product colors
        foreach (var colorId in model.ColorIds)
        {
            await _unitOfWork.Repository<ProductColor>().AddAsync(new ProductColor
            {
                ProductId = product.Id,
                ColorId = colorId
            });
        }

        // Add product sizes
        foreach (var sizeId in model.SizeIds)
        {
            await _unitOfWork.Repository<ProductSize>().AddAsync(new ProductSize
            {
                ProductId = product.Id,
                SizeId = sizeId
            });
        }

        // Create variants
        foreach (var variantModel in model.Variants)
        {
            var variant = new ProductVariant
            {
                ProductId = product.Id,
                SizeId = variantModel.SizeId,
                ColorId = variantModel.ColorId,
                SKU = variantModel.SKU,
                Price = variantModel.Price,
                StockQuantity = variantModel.StockQuantity
            };

            var variantPrice = await _stripeService.CreateVariantPriceAsync(variant);
            variant.StripePriceId = variantPrice.Id;

            await _unitOfWork.ProductVariants.AddAsync(variant);
        }

        await _unitOfWork.CommitTransactionAsync();
        
        return RedirectToAction(nameof(Details), new { id = product.Id });
    }
    catch (Exception ex)
    {
        await _unitOfWork.RollbackTransactionAsync();
        ModelState.AddModelError("", $"Error creating product: {ex.Message}");
        return View(model);
    }
}
```

### Complex Query with Includes

```csharp
public async Task<IActionResult> CategoryProducts(string slug)
{
    // Get category by slug with subcategories and products
    var category = await _unitOfWork.Categories.GetCategoryBySlugAsync(slug);
    
    if (category == null)
        return NotFound();

    // Get all products in this category with images
    var products = await _unitOfWork.Products.GetProductsByCategoryAsync(category.Id);
    
    var viewModel = new CategoryViewModel
    {
        Category = category,
        Products = products
    };

    return View(viewModel);
}
```

### Generic Repository Usage

```csharp
// For entities without specific repository
var productImages = await _unitOfWork.Repository<ProductImage>()
    .FindAsync(
        pi => pi.ProductId == productId,
        pi => pi.Color  // Include related color
    );

// Simple add
var newImage = new ProductImage
{
    ProductId = productId,
    ImageUrl = imageUrl,
    DisplayOrder = 1,
    IsPrimary = true
};
await _unitOfWork.Repository<ProductImage>().AddAsync(newImage);
await _unitOfWork.SaveChangesAsync();
```

### Order Processing with Commission

```csharp
public async Task<IActionResult> CreateOrder(CheckoutViewModel model)
{
    try
    {
        await _unitOfWork.BeginTransactionAsync();

        // Calculate totals
        var orderTotal = model.Items.Sum(i => i.Price * i.Quantity);
        var commissionRate = _configuration.GetValue<decimal>("Commission:DefaultRate");
        var commissionAmount = orderTotal * commissionRate;

        // Create Stripe payment intent
        var paymentIntent = await _stripeService.CreatePaymentIntentAsync(
            orderTotal,
            metadata: new Dictionary<string, string>
            {
                { "customer_email", model.Email },
                { "commission_rate", commissionRate.ToString() }
            }
        );

        // Create order
        var order = new Order
        {
            OrderNumber = GenerateOrderNumber(),
            StripePaymentIntentId = paymentIntent.Id,
            TotalAmount = orderTotal,
            CommissionAmount = commissionAmount,
            CommissionRate = commissionRate,
            CustomerEmail = model.Email,
            CustomerName = model.Name
        };

        await _unitOfWork.Orders.AddAsync(order);
        await _unitOfWork.SaveChangesAsync();

        // Create order items
        foreach (var item in model.Items)
        {
            var variant = await _unitOfWork.ProductVariants
                .GetByIdAsync(item.VariantId, v => v.Product, v => v.Size, v => v.Color);

            var orderItem = new OrderItem
            {
                OrderId = order.Id,
                ProductVariantId = variant.Id,
                ProductName = variant.Product.Name,
                Size = variant.Size?.Name,
                Color = variant.Color?.Name,
                Quantity = item.Quantity,
                UnitPrice = variant.Price,
                TotalPrice = variant.Price * item.Quantity
            };

            await _unitOfWork.Repository<OrderItem>().AddAsync(orderItem);

            // Update stock
            variant.StockQuantity -= item.Quantity;
            _unitOfWork.ProductVariants.Update(variant);
        }

        await _unitOfWork.CommitTransactionAsync();

        return Ok(new { clientSecret = paymentIntent.ClientSecret });
    }
    catch (Exception ex)
    {
        await _unitOfWork.RollbackTransactionAsync();
        return BadRequest(new { error = ex.Message });
    }
}
```

### Navbar Categories

```csharp
// Get hierarchical categories for navbar (cached recommended)
var navbarCategories = await _unitOfWork.Categories.GetNavbarCategoriesAsync();

// Result structure:
// Woman
//   ├── T-Shirts
//   ├── Pants
//   └── Dresses
// Man
//   ├── T-Shirts
//   ├── Pants
//   └── Shirts
```

### Search Products

```csharp
public async Task<IActionResult> Search(string query)
{
    var products = await _unitOfWork.Products.SearchProductsAsync(query);
    return View(products);
}
```

## 🗄️ Database Migration

### Create Migration
```powershell
dotnet ef migrations add InitialCreate
```

### Update Database
```powershell
dotnet ef database update
```

### Remove Last Migration
```powershell
dotnet ef migrations remove
```

## 📊 Seeded Data

### Sizes
- XS, S, M, L, XL, XXL

### Colors
- Black (#000000)
- White (#FFFFFF)
- Red (#FF0000)
- Blue (#0000FF)
- Green (#00FF00)
- Yellow (#FFFF00)
- Navy (#000080)
- Gray (#808080)

### Categories
- **Woman**
  - T-Shirts
  - Pants
  - Dresses
- **Man**
  - T-Shirts
  - Pants
  - Shirts

## 🎨 Key Features

### 1. Clean Separation of Concerns
- Abstract interfaces define contracts
- Concrete implementations provide functionality
- Configurations separate from DbContext

### 2. Type Safety
- Strongly typed repositories
- Compile-time checking
- IntelliSense support

### 3. Flexibility
- Generic repository for any entity
- Specialized repositories for complex queries
- Easy to extend with new methods

### 4. Transaction Support
- BeginTransaction, Commit, Rollback
- Ensures data consistency
- All-or-nothing operations

### 5. Include Support
- Eager loading with lambda expressions
- Prevents N+1 query problems
- Better performance

## 🔒 Best Practices

1. **Always use Unit of Work** - Don't inject individual repositories
2. **Use transactions for multi-step operations** - Ensure consistency
3. **Dispose properly** - Unit of Work implements IDisposable
4. **Use specific repository methods** - They're optimized for common scenarios
5. **Avoid lazy loading** - Use explicit includes instead
6. **Cache frequently accessed data** - Like categories for navbar

## 🚀 Next Steps

1. Create Controllers for CRUD operations
2. Implement ViewModels for data transfer
3. Add AutoMapper for entity-to-ViewModel mapping
4. Implement caching strategy
5. Add logging and error handling middleware
6. Create admin panel for data management
