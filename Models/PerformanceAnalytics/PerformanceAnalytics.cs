using AdCampaigner.Models.Campaigns;

namespace AdCampaigner.Models.PerformanceAnalytics
{
    public class PerformanceAnalytics
    {
        public int Id { get; set; }

        // Performance metrics properties
        // E.g., impressions, clicks, conversions, ROI
        public int Clicks { get; set; }
        public int Impressions { get; set; }
        public int Conversions { get; set; }
        public decimal ROI { get; set; }

        // Foreign key
        public int CampaignId { get; set; }
        public Campaign Campaign { get; set; }
    }
}
