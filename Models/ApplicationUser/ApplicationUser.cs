using AdCampaigner.Models.Campaigns;
using AdCampaigner.Models.JoinTables;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace AdCampaigner.Models.ApplicationUser
{
    public class ApplicationUser : IdentityUser<string>
    {
        // Additional properties
        public string FullName { get; set; } // User's full name
        public bool IsActive { get; set; } // Flag to indicate if the user account is active
        public DateTime LastLogin { get; set; } // Timestamp of the user's last login

        // Navigation properties
        public virtual ICollection<IdentityUserRole<string>> Roles { get; } = new List<IdentityUserRole<string>>(); // User roles
        public virtual ICollection<UserCampaign> UserCampaigns { get; set; } // Collection of user campaigns
        public virtual ICollection<Campaign> Campaigns { get; set; } // Collection of campaigns associated with the user

        // You can add more properties as needed for user management
    }
}
