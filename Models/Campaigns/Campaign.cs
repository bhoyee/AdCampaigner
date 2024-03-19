using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AdCampaigner.Models.TargetingOptions;
using AdCampaigner.Models.Budget;
namespace AdCampaigner.Models.Campaigns
{
    public class Campaign
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Budget { get; set; }

        [Required]
        public CampaignStatus Status { get; set; }

        // Navigation properties
        public string UserId { get; set; }
        public ICollection<ApplicationUser.ApplicationUser> User { get; set; }
        public ICollection<TargetingOptions.TargetingOptions> TargetingOptions { get; set; }
        public ICollection<Budget.Budget> CampaignBudget { get; set; }
        public ICollection<PerformanceAnalytics.PerformanceAnalytics> PerformanceAnalytics { get; set; }
    }

    public enum CampaignStatus
    {
        Pending,
        Active,
        Completed,
        Cancelled
    }
}
