using AdCampaigner.Models.Campaigns;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdCampaigner.Models.JoinTables
{
    public class UserCampaign
    {
        [ForeignKey("AdCampaigner.Models.ApplicationUser.ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser.ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("AdCampaigner.Models.Campaigns.Campaign")]
        public int CampaignId { get; set; }
        public Campaign Campaign { get; set; }
    }
}
