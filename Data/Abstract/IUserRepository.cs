using Kokomija.Entity;

namespace Kokomija.Data.Abstract
{
    public interface IUserRepository
    {
        Task<ApplicationUser?> GetByIdAsync(string id);
        Task<ApplicationUser?> GetByEmailAsync(string email);
        Task<ApplicationUser?> GetByStripeCustomerIdAsync(string stripeCustomerId);
        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
        Task<IEnumerable<ApplicationUser>> GetActiveUsersAsync();
        Task<IEnumerable<ApplicationUser>> GetUsersByRoleAsync(string roleName);
        Task<bool> IsInRoleAsync(ApplicationUser user, string roleName);
        Task<IList<string>> GetUserRolesAsync(ApplicationUser user);
        Task UpdateLastLoginAsync(string userId);
    }
}
