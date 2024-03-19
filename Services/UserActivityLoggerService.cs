using AdCampaigner.Interfaces;
using AdCampaigner.Models.ApplicationUser;

namespace AdCampaigner.Services
{
    public class UserActivityLoggerService : IUserActivityLogger
    {
        // Implementation of IUserActivityLogger interface
        public void LogActivity(string userId, string activityType, string details)
        {
            // Persist the log entry to the database or log file
            // Example: Save the log to a database table
            var logEntry = new UserActivityLog
            {
                UserId = userId,
                ActivityType = activityType,
                Timestamp = DateTime.UtcNow,
                Details = details
            };

            // Save logEntry to the database using Entity Framework Core or any other ORM
            // Example: dbContext.UserActivityLogs.Add(logEntry);
        }
    }
}
