using AdCampaigner.Models.Campaigns;

namespace AdCampaigner.Models.PerformanceAnalytics
{
    public class PerformanceAnalytics
    {
        public int Id { get; set; }

        // Performance metrics properties
        // E.g., impressions, clicks, conversions, ROI

        // Foreign key
        public int CampaignId { get; set; }
        public Campaign Campaign { get; set; }
    }
}
