using AdCampaigner.Models.Campaigns;

namespace AdCampaigner.Models.Budget
{
    public class Budget
    {
        public int Id { get; set; }
        public decimal TotalBudget { get; set; }

        // Additional properties for budget allocation
        // E.g., allocated amounts for specific purposes (channels)

        // Foreign key
        public int CampaignId { get; set; }
        public Campaign Campaign { get; set; }
    }
}
