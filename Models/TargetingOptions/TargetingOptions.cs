using AdCampaigner.Models.Campaigns;

namespace AdCampaigner.Models.TargetingOptions
{
    public class TargetingOptions
    {
        public int Id { get; set; }

        // Targeting options properties
        // E.g., demographics, interests, geographic location
        public string Demographics { get; set; }
        public string Interests { get; set; }
        public string GeographicLocation { get; set; }

        // Foreign key
        public int CampaignId { get; set; }
        public Campaign Campaign { get; set; }
    }
}
