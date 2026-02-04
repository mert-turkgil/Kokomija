using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Kokomija.Models.ViewModels.Admin;
using Kokomija.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Kokomija.Controllers;

[Authorize(Roles = "Root,Admin")]
public class AdminUserController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<AdminUserController> _logger;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IStripeService _stripeService;
    private readonly INIPValidationService _nipValidationService;

    public AdminUserController(
        IUnitOfWork unitOfWork,
        ILogger<AdminUserController> logger,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IStripeService stripeService,
        INIPValidationService nipValidationService)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _userManager = userManager;
        _roleManager = roleManager;
        _stripeService = stripeService;
        _nipValidationService = nipValidationService;
    }

    /// <summary>
    /// GET: User Management page
    /// </summary>
    public async Task<IActionResult> Index()
    {
        _logger.LogInformation("Admin accessed user management");

        var users = await _userManager.Users.ToListAsync();
        var totalUsers = users.Count;
        var activeUsers = users.Count(u => !u.LockoutEnd.HasValue || u.LockoutEnd <= DateTimeOffset.UtcNow);
        var bannedUsers = users.Count(u => u.LockoutEnd.HasValue && u.LockoutEnd > DateTimeOffset.UtcNow);

        // Get all orders and reviews for counting
        var allOrders = await _unitOfWork.Orders.GetAllAsync();
        var allReviews = await _unitOfWork.Repository<ProductReview>().GetAllAsync();

        // Get all business profiles
        var businessProfiles = await _unitOfWork.Repository<BusinessProfile>().GetAllAsync();

        // Get current user to check if Root
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var currentUser = await _userManager.FindByIdAsync(currentUserId!);
        var isCurrentUserRoot = currentUser != null && await _userManager.IsInRoleAsync(currentUser, "Root");
        ViewBag.IsCurrentUserRoot = isCurrentUserRoot;

        // Get all available roles for the role management dropdown
        var allRoles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
        ViewBag.AllRoles = allRoles;

        // Build user list with role information
        var userDtos = new List<UserListItemDto>();
        foreach (var u in users)
        {
            var userRoles = await _userManager.GetRolesAsync(u);
            var isRoot = userRoles.Contains("Root");
            var businessProfile = businessProfiles.FirstOrDefault(bp => bp.UserId == u.Id);

            userDtos.Add(new UserListItemDto
            {
                Id = u.Id,
                Email = u.Email ?? "",
                FirstName = u.FirstName,
                LastName = u.LastName,
                PhoneNumber = u.PhoneNumber,
                EmailConfirmed = u.EmailConfirmed,
                IsBanned = u.LockoutEnd.HasValue && u.LockoutEnd > DateTimeOffset.UtcNow,
                BannedUntil = u.LockoutEnd,
                CreatedAt = u.CreatedAt,
                LastLogin = u.LastLoginAt,
                TotalOrders = allOrders.Count(o => o.UserId == u.Id),
                TotalReviews = allReviews.Count(r => r.UserId == u.Id),
                IsRoot = isRoot,
                Roles = userRoles.ToList(),
                HasBusinessProfile = businessProfile != null,
                IsBusinessVerified = businessProfile?.IsVerified ?? false,
                CompanyName = businessProfile?.CompanyName
            });
        }

        var viewModel = new UserManagementViewModel
        {
            Users = userDtos.OrderByDescending(u => u.CreatedAt).ToList(),
            TotalUsers = totalUsers,
            ActiveUsers = activeUsers,
            BannedUsers = bannedUsers,
            NewUsersThisMonth = users.Count(u => u.CreatedAt >= DateTime.UtcNow.AddMonths(-1))
        };

        ViewData["Title"] = "User Management";
        return View(viewModel);
    }

    /// <summary>
    /// GET: Edit user
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            TempData["Error"] = "User not found";
            return RedirectToAction(nameof(Index));
        }

        // Check if editing user is Root and current user is not Root
        var isUserRoot = await _userManager.IsInRoleAsync(user, "Root");
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var currentUser = await _userManager.FindByIdAsync(currentUserId!);
        var isCurrentUserRoot = currentUser != null && await _userManager.IsInRoleAsync(currentUser, "Root");

        if (isUserRoot && !isCurrentUserRoot)
        {
            TempData["Error"] = "Only Root users can edit Root accounts";
            return RedirectToAction(nameof(Index));
        }

        ViewBag.IsUserRoot = isUserRoot;
        ViewBag.IsCurrentUserRoot = isCurrentUserRoot;

        // Get user's reviews
        var reviews = await _unitOfWork.Repository<ProductReview>()
            .FindAsync(r => r.UserId == id);

        // Get user's orders
        var orders = await _unitOfWork.Orders.GetOrdersByUserIdAsync(id);

        // Get user's wishlist
        var wishlist = await _unitOfWork.Repository<Wishlist>()
            .FindAsync(w => w.UserId == id, w => w.Product);

        // Get used coupons

        var usedCoupons = await _unitOfWork.Repository<CouponUsage>()
            .FindAsync(cu => cu.UserId == id, cu => cu.Coupon, cu => cu.Coupon.Product!, cu => cu.Coupon.Category!);
        var usedCouponDtos = usedCoupons
            .GroupBy(cu => cu.CouponId)
            .Select(g => new UserCouponDto
            {
                Id = g.First().Coupon!.Id,
                Code = g.First().Coupon!.Code,
                Description = g.First().Coupon.Description,
                DiscountType = g.First().Coupon.DiscountType,
                DiscountValue = g.First().Coupon.DiscountValue,
                MinimumOrderAmount = g.First().Coupon.MinimumOrderAmount,
                MaximumDiscountAmount = g.First().Coupon.MaximumDiscountAmount,
                ValidFrom = g.First().Coupon.ValidFrom,
                ValidUntil = g.First().Coupon.ValidUntil,
                IsActive = g.First().Coupon.IsActive,
                UsageLimit = g.First().Coupon.UsageLimit,
                UsageCount = g.First().Coupon.UsageCount,
                UsageLimitPerUser = g.First().Coupon.UsageLimitPerUser,
                UserUsageCount = g.Count(),
                LastUsedAt = g.Max(cu => cu.UsedAt),
                IsUserSpecific = g.First().Coupon.UserId != null,
                RestrictedToProduct = g.First().Coupon.Product?.Name ?? null,
                RestrictedToCategory = g.First().Coupon.Category?.Name ?? null
            })
            .OrderByDescending(c => c.LastUsedAt)
            .ToList();

        // Get available coupons (general + user-specific for this user)
        var now = DateTime.UtcNow;

        var allActiveCoupons = await _unitOfWork.Repository<Coupon>()
            .FindAsync(c => c.IsActive && 
                           (!c.ValidFrom.HasValue || c.ValidFrom <= now) &&
                           (!c.ValidUntil.HasValue || c.ValidUntil >= now) &&
                           (!c.UsageLimit.HasValue || c.UsageCount < c.UsageLimit) &&
                           (c.UserId == null || c.UserId == id), // Include general coupons or user-specific ones
                       c => c.Product!, c => c.Category!);


        var availableCouponDtos = new List<UserCouponDto>();
        foreach (var coupon in allActiveCoupons)
        {
            var userUsageCount = usedCoupons.Count(cu => cu.CouponId == coupon.Id);
            var canUse = !coupon.UsageLimitPerUser.HasValue || userUsageCount < coupon.UsageLimitPerUser.Value;
            
            if (canUse)
            {
                availableCouponDtos.Add(new UserCouponDto
                {
                    Id = coupon.Id,
                    Code = coupon.Code,
                    Description = coupon.Description,
                    DiscountType = coupon.DiscountType,
                    DiscountValue = coupon.DiscountValue,
                    MinimumOrderAmount = coupon.MinimumOrderAmount,
                    MaximumDiscountAmount = coupon.MaximumDiscountAmount,
                    ValidFrom = coupon.ValidFrom,
                    ValidUntil = coupon.ValidUntil,
                    IsActive = coupon.IsActive,
                    UsageLimit = coupon.UsageLimit,
                    UsageCount = coupon.UsageCount,
                    UsageLimitPerUser = coupon.UsageLimitPerUser,
                    UserUsageCount = userUsageCount,
                    IsUserSpecific = coupon.UserId != null,
                    RestrictedToProduct = coupon.Product?.Name ?? null,
                    RestrictedToCategory = coupon.Category?.Name ?? null
                });
            }
        }

        // Get business profile
        var businessProfile = await _nipValidationService.GetBusinessProfileAsync(id);
        
        // Get user roles
        var userRoles = await _userManager.GetRolesAsync(user);
        var allRoles = _roleManager.Roles.Select(r => r.Name!).ToList();
        
        // Filter available roles - non-Root users cannot see or assign Root role
        var availableRoles = allRoles.Where(r => !userRoles.Contains(r));
        if (!isCurrentUserRoot)
        {
            availableRoles = availableRoles.Where(r => r != "Root");
        }

        var viewModel = new UserEditDto
        {
            Id = user.Id,
            Email = user.Email ?? "",
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            EmailConfirmed = user.EmailConfirmed,
            IsBanned = user.LockoutEnd.HasValue && user.LockoutEnd > DateTimeOffset.UtcNow,
            BannedUntil = user.LockoutEnd,
            CreatedAt = user.CreatedAt,
            LastLogin = user.LastLoginAt,
            BusinessProfile = businessProfile != null ? new UserBusinessProfileDto
            {
                Id = businessProfile.Id,
                NIP = businessProfile.NIP,
                CompanyName = businessProfile.CompanyName,
                REGON = businessProfile.REGON,
                KRS = businessProfile.KRS,
                VATStatus = businessProfile.VATStatus,
                ResidenceAddress = businessProfile.ResidenceAddress,
                WorkingAddress = businessProfile.WorkingAddress,
                RegistrationLegalDate = businessProfile.RegistrationLegalDate,
                IsVerified = businessProfile.IsVerified,
                IsBusinessModeActive = businessProfile.IsBusinessModeActive,
                VerifiedAt = businessProfile.VerifiedAt,
                CreatedAt = businessProfile.CreatedAt
            } : null,
            AssignedRoles = userRoles.ToList(),
            AvailableRoles = availableRoles.ToList(),
            Reviews = reviews.Select(r => new UserReviewDto
            {
                Id = r.Id,
                ProductId = r.ProductId,
                ProductName = r.Product?.Name ?? "Unknown Product",
                Rating = r.Rating,
                Comment = r.Comment,
                IsVisible = r.IsVisible,
                CreatedAt = r.CreatedAt,
                AdminReply = r.AdminReply,
                AdminReplyAt = r.AdminReplyAt
            }).OrderByDescending(r => r.CreatedAt).ToList(),
            Orders = orders.Select(o => new UserOrderDto
            {
                Id = o.Id,
                OrderNumber = o.OrderNumber,
                TotalAmount = o.TotalAmount,
                OrderStatus = o.OrderStatus,
                PaymentStatus = o.PaymentStatus,
                CreatedAt = o.CreatedAt,
                ItemCount = o.OrderItems?.Count ?? 0,
                CouponCode = o.Coupon?.Code,
                DiscountAmount = o.DiscountAmount
            }).OrderByDescending(o => o.CreatedAt).ToList(),
            Wishlist = wishlist.Select(w => new UserWishlistDto
            {
                Id = w.Id,
                ProductId = w.ProductId,
                ProductName = w.Product?.Name ?? "Unknown Product",
                Price = w.Product?.Price ?? 0,
                FeaturedImage = w.Product?.Images?.FirstOrDefault(i => i.IsPrimary)?.ImageUrl,
                IsActive = w.Product?.IsActive ?? false,
                InStock = (w.Product?.Variants?.Sum(v => v.StockQuantity) ?? 0) > 0,
                AddedAt = w.AddedAt
            }).OrderByDescending(w => w.AddedAt).ToList(),
            UsedCoupons = usedCouponDtos,
            AvailableCoupons = availableCouponDtos.OrderBy(c => c.ValidUntil).ToList()
        };

        // Load products and categories for coupon creation
        var allProducts = await _unitOfWork.Products.GetAllAsync();
        var allCategories = await _unitOfWork.Repository<Category>()
            .GetAllAsync(c => c.Translations!);
        ViewBag.Products = allProducts.Where(p => p.IsActive).OrderBy(p => p.Name).ToList();
        ViewBag.Categories = allCategories.Where(c => c.IsActive).OrderBy(c => c.DisplayOrder).ToList();

        ViewData["Title"] = $"Edit User: {user.Email}";
        return View(viewModel);
    }

    /// <summary>
    /// POST: Create user-specific coupon
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CreateUserCoupon([FromBody] CreateUserCouponDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Invalid coupon data" });
            }

            // Verify user exists
            var user = await _userManager.FindByIdAsync(dto.UserId);
            if (user == null)
            {
                return Json(new { success = false, message = "User not found" });
            }

            // Check if coupon code already exists
            var existingCoupon = (await _unitOfWork.Repository<Coupon>()
                .FindAsync(c => c.Code.ToLower() == dto.Code.ToLower())).FirstOrDefault();
            if (existingCoupon != null)
            {
                return Json(new { success = false, message = "Coupon code already exists" });
            }

            // Create the coupon
            var coupon = new Coupon
            {
                Code = dto.Code.ToUpper(),
                Description = dto.Description,
                DiscountType = dto.DiscountType,
                DiscountValue = dto.DiscountValue,
                MinimumOrderAmount = dto.MinimumOrderAmount,
                MaximumDiscountAmount = dto.MaximumDiscountAmount,
                ValidFrom = dto.ValidFrom,
                ValidUntil = dto.ValidUntil,
                UsageLimit = dto.UsageLimit,
                UsageLimitPerUser = dto.UsageLimitPerUser,
                UserId = dto.UserId, // User-specific
                ProductId = dto.ProductId, // Optional product restriction
                CategoryId = dto.CategoryId, // Optional category restriction
                IsActive = true,
                UsageCount = 0,
                CreatedAt = DateTime.UtcNow
            };

            await _unitOfWork.Repository<Coupon>().AddAsync(coupon);
            await _unitOfWork.SaveChangesAsync();

            // Create coupon in Stripe
            try
            {
                var stripeCoupon = await _stripeService.CreateStripeCouponAsync(coupon);
                var stripePromoCode = await _stripeService.CreateStripePromotionCodeAsync(stripeCoupon.Id, coupon.Code);
                
                // Update coupon with Stripe IDs
                coupon.StripeCouponId = stripeCoupon.Id;
                coupon.StripePromotionCodeId = stripePromoCode.Id;
                _unitOfWork.Repository<Coupon>().Update(coupon);
                await _unitOfWork.SaveChangesAsync();
                
                _logger.LogInformation("User-specific coupon created in Stripe: {Code} (StripeCouponId: {StripeCouponId}, PromoCodeId: {PromoCodeId})", 
                    coupon.Code, stripeCoupon.Id, stripePromoCode.Id);
            }
            catch (Exception stripeEx)
            {
                _logger.LogError(stripeEx, "Error creating coupon in Stripe, but local coupon was saved: {Code}", coupon.Code);
            }

            _logger.LogInformation("User-specific coupon created: {Code} for user {UserId}", coupon.Code, dto.UserId);
            
            return Json(new { 
                success = true, 
                message = "Coupon created successfully",
                couponCode = coupon.Code
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating user coupon");
            return Json(new { success = false, message = "Error creating coupon" });
        }
    }

    /// <summary>
    /// POST: Update user
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UserEditDto model)
    {
        if (!ModelState.IsValid)
        {
            TempData["Error"] = "Invalid data";
            return View(model);
        }

        try
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                TempData["Error"] = "User not found";
                return RedirectToAction(nameof(Index));
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.PhoneNumber;
            user.EmailConfirmed = model.EmailConfirmed;

            var result = await _userManager.UpdateAsync(user);
            
            if (result.Succeeded)
            {
                _logger.LogInformation("User updated: {UserId}", user.Id);
                TempData["Success"] = "User updated successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["Error"] = string.Join(", ", result.Errors.Select(e => e.Description));
                return View(model);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating user {UserId}", model.Id);
            TempData["Error"] = "Error updating user";
            return View(model);
        }
    }

    /// <summary>
    /// POST: Ban user
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Ban(string id, int days)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return Json(new { success = false, message = "User not found" });
            }

            // Protect Root users from being banned
            var isRoot = await _userManager.IsInRoleAsync(user, "Root");
            if (isRoot)
            {
                return Json(new { success = false, message = "Root users cannot be banned" });
            }

            // Ban user for specified days
            user.LockoutEnd = DateTimeOffset.UtcNow.AddDays(days);
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                _logger.LogInformation("User banned: {UserId} for {Days} days", id, days);
                return Json(new { success = true, message = $"User banned for {days} days" });
            }
            else
            {
                return Json(new { success = false, message = string.Join(", ", result.Errors.Select(e => e.Description)) });
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error banning user {UserId}", id);
            return Json(new { success = false, message = "Error banning user" });
        }
    }

    /// <summary>
    /// POST: Unban user
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Unban(string id)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return Json(new { success = false, message = "User not found" });
            }

            user.LockoutEnd = null;
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                _logger.LogInformation("User unbanned: {UserId}", id);
                return Json(new { success = true, message = "User unbanned successfully" });
            }
            else
            {
                return Json(new { success = false, message = string.Join(", ", result.Errors.Select(e => e.Description)) });
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error unbanning user {UserId}", id);
            return Json(new { success = false, message = "Error unbanning user" });
        }
    }

    /// <summary>
    /// POST: Delete user
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return Json(new { success = false, message = "User not found" });
            }

            // Protect Root users from being deleted
            var isRoot = await _userManager.IsInRoleAsync(user, "Root");
            if (isRoot)
            {
                return Json(new { success = false, message = "Root users cannot be deleted" });
            }

            var result = await _userManager.DeleteAsync(user);
            
            if (result.Succeeded)
            {
                _logger.LogInformation("User deleted: {UserId}", id);
                return Json(new { success = true, message = "User deleted successfully" });
            }
            else
            {
                return Json(new { success = false, message = string.Join(", ", result.Errors.Select(e => e.Description)) });
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting user {UserId}", id);
            return Json(new { success = false, message = "Error deleting user" });
        }
    }

    /// <summary>
    /// POST: Get banned users for DataTables (server-side processing)
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> GetBannedUsers()
    {
        try
        {
            // DataTables parameters
            var draw = int.Parse(Request.Form["draw"].FirstOrDefault() ?? "1");
            var start = int.Parse(Request.Form["start"].FirstOrDefault() ?? "0");
            var length = int.Parse(Request.Form["length"].FirstOrDefault() ?? "25");
            var searchValue = Request.Form["search[value]"].FirstOrDefault() ?? "";
            var sortColumnIndex = int.Parse(Request.Form["order[0][column]"].FirstOrDefault() ?? "2");
            var sortDirection = Request.Form["order[0][dir]"].FirstOrDefault() ?? "asc";

            // Get all banned users
            var now = DateTimeOffset.UtcNow;
            var bannedUsersQuery = _userManager.Users
                .Where(u => u.LockoutEnd.HasValue && u.LockoutEnd > now)
                .AsQueryable();

            // Apply search filter
            if (!string.IsNullOrEmpty(searchValue))
            {
                bannedUsersQuery = bannedUsersQuery.Where(u =>
                    (u.FirstName + " " + u.LastName).Contains(searchValue) ||
                    u.Email!.Contains(searchValue));
            }

            // Get total count before pagination
            var totalRecords = await bannedUsersQuery.CountAsync();

            // Apply sorting
            bannedUsersQuery = sortColumnIndex switch
            {
                0 => sortDirection == "asc" 
                    ? bannedUsersQuery.OrderBy(u => u.FirstName).ThenBy(u => u.LastName)
                    : bannedUsersQuery.OrderByDescending(u => u.FirstName).ThenByDescending(u => u.LastName),
                1 => sortDirection == "asc" 
                    ? bannedUsersQuery.OrderBy(u => u.Email)
                    : bannedUsersQuery.OrderByDescending(u => u.Email),
                2 => sortDirection == "asc"
                    ? bannedUsersQuery.OrderBy(u => u.LockoutEnd)
                    : bannedUsersQuery.OrderByDescending(u => u.LockoutEnd),
                3 => sortDirection == "asc"
                    ? bannedUsersQuery.OrderBy(u => u.CreatedAt)
                    : bannedUsersQuery.OrderByDescending(u => u.CreatedAt),
                _ => bannedUsersQuery.OrderBy(u => u.LockoutEnd)
            };

            // Apply pagination
            var bannedUsers = await bannedUsersQuery
                .Skip(start)
                .Take(length)
                .ToListAsync();

            // Get order counts for each user
            var userIds = bannedUsers.Select(u => u.Id).ToList();
            var orders = await _unitOfWork.Orders.GetAllAsync();
            var orderCounts = orders?
                .Where(o => userIds.Contains(o.UserId!))
                .GroupBy(o => o.UserId!)
                .ToDictionary(g => g.Key, g => g.Count())
                ?? new Dictionary<string, int>();

            // Check for Root role
            var rootUserIds = new List<string>();
            foreach (var user in bannedUsers)
            {
                if (await _userManager.IsInRoleAsync(user, "Root"))
                {
                    rootUserIds.Add(user.Id);
                }
            }

            // Format data for DataTables
            var data = bannedUsers.Select(u => new
            {
                id = u.Id,
                fullName = $"{u.FirstName} {u.LastName}",
                email = u.Email,
                bannedUntil = u.LockoutEnd?.DateTime,
                bannedAt = u.CreatedAt, // You might want to track actual ban date separately
                banReason = u.LockoutEnd.HasValue && (u.LockoutEnd.Value - now).TotalDays > 3650 
                    ? "Permanent ban" 
                    : null, // You might want to store ban reasons separately
                totalOrders = orderCounts.TryGetValue(u.Id, out var cnt) ? cnt : 0,
                emailConfirmed = u.EmailConfirmed,
                isRoot = rootUserIds.Contains(u.Id)
            }).ToList();

            return Json(new
            {
                draw = draw,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
                data = data
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading banned users");
            return Json(new
            {
                draw = 1,
                recordsTotal = 0,
                recordsFiltered = 0,
                data = new List<object>(),
                error = "Error loading banned users"
            });
        }
    }

    /// <summary>
    /// POST: Update review visibility
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ReviewToggleVisibility(int id)
    {
        try
        {
            var review = await _unitOfWork.Repository<ProductReview>().GetByIdAsync(id);
            if (review == null)
            {
                return Json(new { success = false, message = "Review not found" });
            }

            review.IsVisible = !review.IsVisible;
            review.UpdatedAt = DateTime.UtcNow;
            
            _unitOfWork.Repository<ProductReview>().Update(review);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Review visibility toggled: {ReviewId} to {IsVisible}", id, review.IsVisible);
            return Json(new { success = true, isVisible = review.IsVisible });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error toggling review visibility {ReviewId}", id);
            return Json(new { success = false, message = "Error updating review" });
        }
    }

    /// <summary>
    /// POST: Edit review content
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ReviewEdit(int id, string comment)
    {
        try
        {
            var review = await _unitOfWork.Repository<ProductReview>().GetByIdAsync(id);
            if (review == null)
            {
                return Json(new { success = false, message = "Review not found" });
            }

            review.Comment = comment;
            review.UpdatedAt = DateTime.UtcNow;
            
            _unitOfWork.Repository<ProductReview>().Update(review);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Review edited: {ReviewId}", id);
            return Json(new { success = true, message = "Review updated successfully" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error editing review {ReviewId}", id);
            return Json(new { success = false, message = "Error updating review" });
        }
    }

    /// <summary>
    /// POST: Delete review
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ReviewDelete(int id)
    {
        try
        {
            var review = await _unitOfWork.Repository<ProductReview>().GetByIdAsync(id);
            if (review == null)
            {
                return Json(new { success = false, message = "Review not found" });
            }

            _unitOfWork.Repository<ProductReview>().Remove(review);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Review deleted: {ReviewId}", id);
            return Json(new { success = true, message = "Review deleted successfully" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting review {ReviewId}", id);
            return Json(new { success = false, message = "Error deleting review" });
        }
    }

    /// <summary>
    /// POST: Update user coupon
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> UpdateUserCoupon([FromBody] UpdateUserCouponDto dto)
    {
        try
        {
            var coupon = await _unitOfWork.Repository<Coupon>().GetByIdAsync(dto.Id);
            if (coupon == null)
            {
                return Json(new { success = false, message = "Coupon not found" });
            }

            // Update local coupon fields
            coupon.Description = dto.Description;
            coupon.ValidUntil = dto.ValidUntil;
            coupon.UsageLimit = dto.UsageLimit;
            coupon.UsageLimitPerUser = dto.UsageLimitPerUser;
            coupon.MinimumOrderAmount = dto.MinimumOrderAmount;
            coupon.MaximumDiscountAmount = dto.MaximumDiscountAmount;
            coupon.IsActive = dto.IsActive;
            coupon.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.Repository<Coupon>().Update(coupon);
            await _unitOfWork.SaveChangesAsync();

            // Note: Stripe coupons are mostly immutable (can't change discount amount/type)
            // However, we can update the promotion code active status
            if (!string.IsNullOrEmpty(coupon.StripePromotionCodeId))
            {
                try
                {
                    var promoCodeService = new Stripe.PromotionCodeService();
                    await promoCodeService.UpdateAsync(coupon.StripePromotionCodeId, new Stripe.PromotionCodeUpdateOptions
                    {
                        Active = dto.IsActive,
                        Metadata = new Dictionary<string, string>
                        {
                            { "updated_at", DateTime.UtcNow.ToString("O") },
                            { "description", dto.Description ?? "" }
                        }
                    });
                    _logger.LogInformation("Stripe promotion code updated: {PromoCodeId}", coupon.StripePromotionCodeId);
                }
                catch (Exception stripeEx)
                {
                    _logger.LogWarning(stripeEx, "Could not update Stripe promotion code {PromoCodeId}, but local coupon was updated", coupon.StripePromotionCodeId);
                }
            }

            _logger.LogInformation("User coupon updated: {CouponId} - {Code}", coupon.Id, coupon.Code);
            
            return Json(new { success = true, message = "Coupon updated successfully" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating coupon {CouponId}", dto.Id);
            return Json(new { success = false, message = "Error updating coupon" });
        }
    }

    /// <summary>
    /// POST: Delete user coupon
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> DeleteUserCoupon(int id)
    {
        try
        {
            var coupon = await _unitOfWork.Repository<Coupon>().GetByIdAsync(id);
            if (coupon == null)
            {
                return Json(new { success = false, message = "Coupon not found" });
            }

            // Delete from Stripe first
            if (!string.IsNullOrEmpty(coupon.StripeCouponId))
            {
                try
                {
                    await _stripeService.DeleteStripeCouponAsync(coupon.StripeCouponId);
                    _logger.LogInformation("Stripe coupon deleted: {StripeCouponId}", coupon.StripeCouponId);
                }
                catch (Exception stripeEx)
                {
                    _logger.LogWarning(stripeEx, "Could not delete Stripe coupon {StripeCouponId}, proceeding with local deletion", coupon.StripeCouponId);
                }
            }

            // Delete from local database
            _unitOfWork.Repository<Coupon>().Remove(coupon);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("User coupon deleted: {CouponId} - {Code}", id, coupon.Code);
            
            return Json(new { success = true, message = "Coupon deleted successfully" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting coupon {CouponId}", id);
            return Json(new { success = false, message = "Error deleting coupon" });
        }
    }

    /// <summary>
    /// POST: Toggle user coupon active status
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> ToggleUserCoupon(int id)
    {
        try
        {
            var coupon = await _unitOfWork.Repository<Coupon>().GetByIdAsync(id);
            if (coupon == null)
            {
                return Json(new { success = false, message = "Coupon not found" });
            }

            coupon.IsActive = !coupon.IsActive;
            coupon.UpdatedAt = DateTime.UtcNow;
            
            _unitOfWork.Repository<Coupon>().Update(coupon);
            await _unitOfWork.SaveChangesAsync();

            // Sync with Stripe - update promotion code active status
            if (!string.IsNullOrEmpty(coupon.StripePromotionCodeId))
            {
                try
                {
                    var promoCodeService = new Stripe.PromotionCodeService();
                    await promoCodeService.UpdateAsync(coupon.StripePromotionCodeId, new Stripe.PromotionCodeUpdateOptions
                    {
                        Active = coupon.IsActive
                    });
                    _logger.LogInformation("Stripe promotion code toggled: {PromoCodeId} to {IsActive}", coupon.StripePromotionCodeId, coupon.IsActive);
                }
                catch (Exception stripeEx)
                {
                    _logger.LogWarning(stripeEx, "Could not toggle Stripe promotion code {PromoCodeId}", coupon.StripePromotionCodeId);
                }
            }

            _logger.LogInformation("User coupon toggled: {CouponId} to {IsActive}", id, coupon.IsActive);
            
            return Json(new { success = true, isActive = coupon.IsActive, message = coupon.IsActive ? "Coupon activated" : "Coupon deactivated" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error toggling coupon {CouponId}", id);
            return Json(new { success = false, message = "Error toggling coupon status" });
        }
    }

    /// <summary>
    /// GET: Get coupon details for editing
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetUserCoupon(int id)
    {
        try
        {
            var coupon = await _unitOfWork.Repository<Coupon>().FirstOrDefaultAsync(
                c => c.Id == id,
                c => c.Product!,
                c => c.Category!
            );
            
            if (coupon == null)
            {
                return Json(new { success = false, message = "Coupon not found" });
            }

            return Json(new { 
                success = true, 
                coupon = new
                {
                    coupon.Id,
                    coupon.Code,
                    coupon.Description,
                    coupon.DiscountType,
                    coupon.DiscountValue,
                    coupon.MinimumOrderAmount,
                    coupon.MaximumDiscountAmount,
                    coupon.ValidFrom,
                    coupon.ValidUntil,
                    coupon.UsageLimit,
                    coupon.UsageCount,
                    coupon.UsageLimitPerUser,
                    coupon.IsActive,
                    coupon.UserId,
                    coupon.ProductId,
                    ProductName = coupon.Product?.Name,
                    coupon.CategoryId,
                    CategoryName = coupon.Category?.Name,
                    coupon.StripeCouponId,
                    coupon.StripePromotionCodeId,
                    coupon.CreatedAt,
                    coupon.UpdatedAt
                }
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting coupon {CouponId}", id);
            return Json(new { success = false, message = "Error loading coupon" });
        }
    }

    #region Role Management

    /// <summary>
    /// GET: Get all available roles
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetRoles()
    {
        var roles = await _roleManager.Roles.ToListAsync();
        var roleList = roles.Select(r => new { r.Id, r.Name }).OrderBy(r => r.Name).ToList();
        return Json(new { success = true, roles = roleList });
    }

    /// <summary>
    /// GET: Get user's current roles
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetUserRoles(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return Json(new { success = false, message = "User not found" });

        var userRoles = await _userManager.GetRolesAsync(user);
        return Json(new { success = true, roles = userRoles });
    }

    /// <summary>
    /// POST: Add role to user
    /// </summary>
    [HttpPost]
    [Authorize(Roles = "Root")]
    public async Task<IActionResult> AddRole([FromBody] UserRoleDto dto)
    {
        try
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(dto.UserId) || string.IsNullOrWhiteSpace(dto.RoleName))
                return Json(new { success = false, message = "User ID and role name are required" });

            var user = await _userManager.FindByIdAsync(dto.UserId);
            if (user == null)
                return Json(new { success = false, message = "User not found" });

            // Check if role exists
            if (!await _roleManager.RoleExistsAsync(dto.RoleName))
                return Json(new { success = false, message = "Role does not exist" });

            // Prevent adding Root role unless current user is Root
            if (dto.RoleName == "Root")
            {
                var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var currentUser = await _userManager.FindByIdAsync(currentUserId!);
                if (currentUser == null || !await _userManager.IsInRoleAsync(currentUser, "Root"))
                    return Json(new { success = false, message = "Only Root users can assign the Root role" });
            }

            // Check if user already has the role
            if (await _userManager.IsInRoleAsync(user, dto.RoleName))
                return Json(new { success = false, message = "User already has this role" });

            var result = await _userManager.AddToRoleAsync(user, dto.RoleName);
            if (result.Succeeded)
            {
                _logger.LogInformation("Role {Role} added to user {UserId}", dto.RoleName, dto.UserId);
                return Json(new { success = true, message = $"Role '{dto.RoleName}' added successfully" });
            }

            return Json(new { success = false, message = string.Join(", ", result.Errors.Select(e => e.Description)) });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding role {Role} to user {UserId}", dto.RoleName, dto.UserId);
            return Json(new { success = false, message = "Error adding role" });
        }
    }

    /// <summary>
    /// POST: Remove role from user
    /// </summary>
    [HttpPost]
    [Authorize(Roles = "Root")]
    public async Task<IActionResult> RemoveRole([FromBody] UserRoleDto dto)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(dto.UserId) || string.IsNullOrWhiteSpace(dto.RoleName))
                return Json(new { success = false, message = "User ID and role name are required" });

            var user = await _userManager.FindByIdAsync(dto.UserId);
            if (user == null)
                return Json(new { success = false, message = "User not found" });

            // Prevent removing Root from yourself
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (dto.RoleName == "Root" && dto.UserId == currentUserId)
                return Json(new { success = false, message = "Cannot remove Root role from yourself" });

            // Prevent removing the last Root user
            if (dto.RoleName == "Root")
            {
                var rootUsers = await _userManager.GetUsersInRoleAsync("Root");
                if (rootUsers.Count <= 1)
                    return Json(new { success = false, message = "Cannot remove the last Root user" });
            }

            if (!await _userManager.IsInRoleAsync(user, dto.RoleName))
                return Json(new { success = false, message = "User does not have this role" });

            var result = await _userManager.RemoveFromRoleAsync(user, dto.RoleName);
            if (result.Succeeded)
            {
                _logger.LogInformation("Role {Role} removed from user {UserId}", dto.RoleName, dto.UserId);
                return Json(new { success = true, message = $"Role '{dto.RoleName}' removed successfully" });
            }

            return Json(new { success = false, message = string.Join(", ", result.Errors.Select(e => e.Description)) });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error removing role {Role} from user {UserId}", dto.RoleName, dto.UserId);
            return Json(new { success = false, message = "Error removing role" });
        }
    }

    #endregion

    #region Business Profile Management

    /// <summary>
    /// GET: Get user's business profile
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetBusinessProfile(string userId)
    {
        try
        {
            var profile = await _nipValidationService.GetBusinessProfileAsync(userId);
            if (profile == null)
                return Json(new { success = true, hasProfile = false });

            return Json(new
            {
                success = true,
                hasProfile = true,
                profile = new
                {
                    profile.Id,
                    profile.NIP,
                    profile.CompanyName,
                    profile.REGON,
                    profile.KRS,
                    profile.VATStatus,
                    profile.ResidenceAddress,
                    profile.WorkingAddress,
                    profile.RegistrationLegalDate,
                    profile.IsVerified,
                    profile.IsBusinessModeActive,
                    profile.VerifiedAt,
                    profile.CreatedAt
                }
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting business profile for user {UserId}", userId);
            return Json(new { success = false, message = "Error loading business profile" });
        }
    }

    /// <summary>
    /// POST: Toggle business mode for a user
    /// </summary>
    [HttpPost]
    [Authorize(Roles = "Root,Admin")]
    public async Task<IActionResult> ToggleBusinessMode([FromBody] UserIdDto dto)
    {
        try
        {
            var profile = await _nipValidationService.GetBusinessProfileAsync(dto.UserId);
            if (profile == null)
                return Json(new { success = false, message = "Business profile not found" });

            profile.IsBusinessModeActive = !profile.IsBusinessModeActive;
            profile.UpdatedAt = DateTime.UtcNow;
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Business mode toggled for user {UserId}: {IsActive}", 
                dto.UserId, profile.IsBusinessModeActive);

            return Json(new { success = true, isActive = profile.IsBusinessModeActive });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error toggling business mode for user {UserId}", dto.UserId);
            return Json(new { success = false, message = "Error toggling business mode" });
        }
    }

    /// <summary>
    /// POST: Manually verify business profile (admin override)
    /// </summary>
    [HttpPost]
    [Authorize(Roles = "Root,Admin")]
    public async Task<IActionResult> VerifyBusinessProfile([FromBody] UserIdDto dto)
    {
        try
        {
            var profile = await _nipValidationService.GetBusinessProfileAsync(dto.UserId);
            if (profile == null)
                return Json(new { success = false, message = "Business profile not found" });

            profile.IsVerified = true;
            profile.VerifiedAt = DateTime.UtcNow;
            profile.UpdatedAt = DateTime.UtcNow;
            await _unitOfWork.SaveChangesAsync();

            // Also add Business role if not already assigned
            var user = await _userManager.FindByIdAsync(dto.UserId);
            if (user != null && !await _userManager.IsInRoleAsync(user, "Business"))
            {
                await _userManager.AddToRoleAsync(user, "Business");
            }

            _logger.LogInformation("Business profile manually verified for user {UserId}", dto.UserId);
            return Json(new { success = true, message = "Business profile verified successfully" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error verifying business profile for user {UserId}", dto.UserId);
            return Json(new { success = false, message = "Error verifying business profile" });
        }
    }

    /// <summary>
    /// POST: Revoke business profile verification
    /// </summary>
    [HttpPost]
    [Authorize(Roles = "Root,Admin")]
    public async Task<IActionResult> UnverifyBusinessProfile([FromBody] UserIdDto dto)
    {
        try
        {
            var profile = await _nipValidationService.GetBusinessProfileAsync(dto.UserId);
            if (profile == null)
                return Json(new { success = false, message = "Business profile not found" });

            profile.IsVerified = false;
            profile.IsBusinessModeActive = false;
            profile.UpdatedAt = DateTime.UtcNow;
            await _unitOfWork.SaveChangesAsync();

            // Remove Business role
            var user = await _userManager.FindByIdAsync(dto.UserId);
            if (user != null && await _userManager.IsInRoleAsync(user, "Business"))
            {
                await _userManager.RemoveFromRoleAsync(user, "Business");
            }

            _logger.LogInformation("Business profile verification revoked for user {UserId}", dto.UserId);
            return Json(new { success = true, message = "Business profile verification revoked" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error unverifying business profile for user {UserId}", dto.UserId);
            return Json(new { success = false, message = "Error revoking verification" });
        }
    }

    /// <summary>
    /// POST: Delete business profile entirely
    /// </summary>
    [HttpPost]
    [Authorize(Roles = "Root,Admin")]
    public async Task<IActionResult> DeleteBusinessProfile([FromBody] UserIdDto dto)
    {
        try
        {
            var profile = await _nipValidationService.GetBusinessProfileAsync(dto.UserId);
            if (profile == null)
                return Json(new { success = false, message = "Business profile not found" });

            _unitOfWork.Repository<BusinessProfile>().Remove(profile);
            await _unitOfWork.SaveChangesAsync();

            // Remove Business role
            var user = await _userManager.FindByIdAsync(dto.UserId);
            if (user != null && await _userManager.IsInRoleAsync(user, "Business"))
            {
                await _userManager.RemoveFromRoleAsync(user, "Business");
            }

            _logger.LogInformation("Business profile deleted for user {UserId}", dto.UserId);
            return Json(new { success = true, message = "Business profile deleted" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting business profile for user {UserId}", dto.UserId);
            return Json(new { success = false, message = "Error deleting business profile" });
        }
    }

    /// <summary>
    /// POST: Manually verify/unverify business profile (admin override)
    /// </summary>
    [HttpPost]
    [Authorize(Roles = "Root,Admin")]
    public async Task<IActionResult> ToggleBusinessVerification([FromBody] ToggleBusinessVerificationDto dto)
    {
        try
        {
            var profile = await _nipValidationService.GetBusinessProfileAsync(dto.UserId);
            if (profile == null)
                return Json(new { success = false, message = "Business profile not found" });

            profile.IsVerified = dto.IsVerified;
            profile.UpdatedAt = DateTime.UtcNow;

            if (dto.IsVerified && !profile.VerifiedAt.HasValue)
            {
                profile.VerifiedAt = DateTime.UtcNow;
            }

            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Business profile verification toggled for user {UserId}: {IsVerified}", 
                dto.UserId, dto.IsVerified);

            return Json(new { success = true, message = dto.IsVerified ? "Profile verified" : "Verification removed" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error toggling business verification for user {UserId}", dto.UserId);
            return Json(new { success = false, message = "Error updating business verification" });
        }
    }

    /// <summary>
    /// GET: Get NIP verification logs for a user
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetNIPVerificationLogs(string userId)
    {
        try
        {
            var logs = await _unitOfWork.Repository<NIPVerificationLog>()
                .FindAsync(l => l.UserId == userId);

            var logDtos = logs.OrderByDescending(l => l.AttemptedAt).Select(l => new
            {
                l.Id,
                l.NIP,
                l.WasSuccessful,
                l.ErrorMessage,
                l.ResponseCode,
                l.IPAddress,
                l.AttemptedAt
            }).ToList();

            return Json(new { success = true, logs = logDtos });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting NIP verification logs for user {UserId}", userId);
            return Json(new { success = false, message = "Error loading verification logs" });
        }
    }

    #endregion
}

/// <summary>
/// DTO for user role operations
/// </summary>
public class UserRoleDto
{
    public string UserId { get; set; } = string.Empty;
    public string RoleName { get; set; } = string.Empty;
}

/// <summary>
/// Simple DTO for operations requiring only user ID
/// </summary>
public class UserIdDto
{
    public string UserId { get; set; } = string.Empty;
}

/// <summary>
/// DTO for toggling business verification
/// </summary>
public class ToggleBusinessVerificationDto
{
    public string UserId { get; set; } = string.Empty;
    public bool IsVerified { get; set; }
}

/// <summary>
/// DTO for updating user coupon
/// </summary>
public class UpdateUserCouponDto
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public DateTime? ValidUntil { get; set; }
    public int? UsageLimit { get; set; }
    public int? UsageLimitPerUser { get; set; }
    public decimal? MinimumOrderAmount { get; set; }
    public decimal? MaximumDiscountAmount { get; set; }
    public bool IsActive { get; set; } = true;
}
