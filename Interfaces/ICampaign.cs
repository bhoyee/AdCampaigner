using AdCampaigner.Models.Campaigns;

namespace AdCampaigner.Interfaces
{
    public interface ICampaign
    {
        Campaign GetById(int id);
        IEnumerable<Campaign> GetAll();
        void Create(Campaign campaign);
        void Update(Campaign campaign);
        void Delete(int id);
    }
}
