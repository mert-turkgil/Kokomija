using Kokomija.Entity;
using Microsoft.AspNetCore.Identity;

namespace Kokomija.Data
{
    public static class IdentitySeeder
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            var roles = new[] { "Root", "Admin", "Customer", "Manager", "VIPBronze", "VIPSilver", "VIPGold", "VIPPlatinum" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        public static async Task SeedRootUserAsync(
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration,
            Services.IStripeCustomerService stripeCustomerService)
        {
            var rootEmail = configuration["RootUser:Email"];
            var rootPassword = configuration["RootUser:Password"];
            var rootFirstName = configuration["RootUser:FirstName"];
            var rootLastName = configuration["RootUser:LastName"];

            if (string.IsNullOrEmpty(rootEmail) || string.IsNullOrEmpty(rootPassword))
            {
                throw new InvalidOperationException("Root user credentials are not configured in appsettings.");
            }

            // Check if root already exists
            var existingRoot = await userManager.FindByEmailAsync(rootEmail);
            if (existingRoot != null)
            {
                return; // Root already exists
            }

            // Create root user
            var rootUser = new ApplicationUser
            {
                UserName = rootEmail,
                Email = rootEmail,
                EmailConfirmed = true,
                FirstName = rootFirstName ?? "Root",
                LastName = rootLastName ?? "Administrator",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            var result = await userManager.CreateAsync(rootUser, rootPassword);

            if (result.Succeeded)
            {
                // Add to Root role
                await userManager.AddToRoleAsync(rootUser, "Root");

                // Create Stripe customer for root
                try
                {
                    var stripeCustomerId = await stripeCustomerService.CreateCustomerAsync(rootUser);
                    rootUser.StripeCustomerId = stripeCustomerId;
                    await userManager.UpdateAsync(rootUser);
                }
                catch (Exception ex)
                {
                    // Log but don't fail - root can still be created without Stripe
                    Console.WriteLine($"Warning: Failed to create Stripe customer for root: {ex.Message}");
                }
            }
            else
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException($"Failed to create root user: {errors}");
            }
        }

        public static async Task SeedAdminUserAsync(
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration,
            Services.IStripeCustomerService stripeCustomerService)
        {
            var adminEmail = configuration["AdminUser:Email"];
            var adminPassword = configuration["AdminUser:Password"];
            var adminFirstName = configuration["AdminUser:FirstName"];
            var adminLastName = configuration["AdminUser:LastName"];

            if (string.IsNullOrEmpty(adminEmail) || string.IsNullOrEmpty(adminPassword))
            {
                throw new InvalidOperationException("Admin user credentials are not configured in appsettings.");
            }

            // Check if admin already exists
            var existingAdmin = await userManager.FindByEmailAsync(adminEmail);
            if (existingAdmin != null)
            {
                return; // Admin already exists
            }

            // Create admin user
            var adminUser = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true,
                FirstName = adminFirstName ?? "Admin",
                LastName = adminLastName ?? "User",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            var result = await userManager.CreateAsync(adminUser, adminPassword);

            if (result.Succeeded)
            {
                // Add to Admin role
                await userManager.AddToRoleAsync(adminUser, "Admin");

                // Create Stripe customer for admin
                try
                {
                    var stripeCustomerId = await stripeCustomerService.CreateCustomerAsync(adminUser);
                    adminUser.StripeCustomerId = stripeCustomerId;
                    await userManager.UpdateAsync(adminUser);
                }
                catch (Exception ex)
                {
                    // Log but don't fail - admin can still be created without Stripe
                    Console.WriteLine($"Warning: Failed to create Stripe customer for admin: {ex.Message}");
                }
            }
            else
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException($"Failed to create admin user: {errors}");
            }
        }

        public static async Task EnsureDatabaseSeededAsync(
            IServiceProvider serviceProvider,
            IConfiguration configuration)
        {
            using var scope = serviceProvider.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                var stripeCustomerService = services.GetRequiredService<Services.IStripeCustomerService>();

                // Seed roles
                await SeedRolesAsync(roleManager);

                // Seed root user (highest privilege)
                await SeedRootUserAsync(userManager, configuration, stripeCustomerService);

                // Seed admin user
                await SeedAdminUserAsync(userManager, configuration, stripeCustomerService);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }
    }
}
