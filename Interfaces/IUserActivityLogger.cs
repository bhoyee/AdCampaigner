namespace AdCampaigner.Interfaces
{
    public interface IUserActivityLogger
    {
        void LogActivity(string userId, string activityType, string details);

    }
}
