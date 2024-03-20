using AdCampaigner.Models.Budget;

namespace AdCampaigner.Interfaces
{
    public interface IBudget
    {
        Task<IEnumerable<Budget>> GetAllBudgetsAsync();
        Task<Budget> GetBudgetByIdAsync(int id);
        Task CreateBudgetAsync(Budget budget);
        Task UpdateBudgetAsync(int id, Budget budget);
        Task DeleteBudgetAsync(int id);
    }
}
