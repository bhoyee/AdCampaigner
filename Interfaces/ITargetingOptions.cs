using System.Collections.Generic;
using System.Threading.Tasks;
using AdCampaigner.Models.TargetingOptions;

namespace AdCampaigner.Interfaces
{
    public interface ITargetingOptions
    {
        Task<IEnumerable<TargetingOptions>> GetAllTargetingOptionsAsync();
        Task<TargetingOptions> GetTargetingOptionsByIdAsync(int id);
        Task CreateTargetingOptionsAsync(TargetingOptions targetingOptions);
        Task UpdateTargetingOptionsAsync(int id, TargetingOptions targetingOptions);
        Task DeleteTargetingOptionsAsync(int id);
    }
}
