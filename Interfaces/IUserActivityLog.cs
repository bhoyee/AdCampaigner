using System.Collections.Generic;
using System.Threading.Tasks;
using AdCampaigner.Models.ApplicationUser;

namespace AdCampaigner.Interfaces
{
    public interface IUserActivityLog
    {
        Task<IEnumerable<UserActivityLog>> GetAllUserActivityLogsAsync();
        Task<UserActivityLog> GetUserActivityLogByIdAsync(int id);
        Task CreateUserActivityLogAsync(UserActivityLog activityLog);
        // Add additional methods as needed
    }
}
