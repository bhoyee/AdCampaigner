namespace AdCampaigner.Models.ApplicationUser
{
    public class UserActivityLog
    {
        public int Id { get; set; }
        public string UserId { get; set; } // User performing the activity
        public string ActivityType { get; set; } // Type of activity (e.g., Login, Logout, CampaignCreation, ProfileUpdate, etc.)
        public DateTime Timestamp { get; set; } // Timestamp of the activity
        public string Details { get; set; } // Additional details about the activity

        // You can add more properties as needed
    }
}
