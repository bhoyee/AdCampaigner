using System.Collections.Generic;
using System.Threading.Tasks;
using AdCampaigner.Models.PerformanceAnalytics;

namespace AdCampaigner.Interfaces
{
    public interface IPerformanceAnalytics
    {
        Task<IEnumerable<PerformanceAnalytics>> GetAllPerformanceAnalyticsAsync();
        Task<PerformanceAnalytics> GetPerformanceAnalyticsByIdAsync(int id);
        Task CreatePerformanceAnalyticsAsync(PerformanceAnalytics analytics);
        Task UpdatePerformanceAnalyticsAsync(int id, PerformanceAnalytics analytics);
        Task DeletePerformanceAnalyticsAsync(int id);
    }
}
