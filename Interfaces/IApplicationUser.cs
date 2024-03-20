using System.Collections.Generic;
using System.Threading.Tasks;
using AdCampaigner.Models.ApplicationUser;

namespace AdCampaigner.Interfaces
{
    public interface IApplicationUser
    {
        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
        Task<ApplicationUser> GetUserByIdAsync(string id);
        Task CreateUserAsync(ApplicationUser user);
        Task UpdateUserAsync(string id, ApplicationUser user);
        Task DeleteUserAsync(string id);
    }
}
