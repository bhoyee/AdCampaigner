using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AdCampaigner.Models.TargetingOptions;
using AdCampaigner.Models.Budget;
using AdCampaigner.Models.JoinTables;

namespace AdCampaigner.Models.Campaigns
{
    public class Campaign
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name must not exceed 100 characters")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Start Date is required")]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [FutureDate(ErrorMessage = "Start Date must be in the future")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required")]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DateAfter(nameof(StartDate), ErrorMessage = "End Date must be after Start Date")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Total Budget is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Total Budget must be a non-negative value")]
        public decimal TotalBudget { get; set; }

        [Required(ErrorMessage = "Duration is required")]
        public int Duration { get; set; } // Duration in days, weeks, months, etc.

        [Required(ErrorMessage = "Objectives are required")]
        public string Objectives { get; set; } // Campaign objectives


        [Required(ErrorMessage = "Status is required")]
        public CampaignStatus Status { get; set; }

        // Navigation properties
        public string UserId { get; set; }
        public ICollection<ApplicationUser.ApplicationUser> Users { get; set; }
        public ICollection<TargetingOptions.TargetingOptions> Targets { get; set; }
        public ICollection<Budget.Budget> Budgets { get; set; }
        public ICollection<PerformanceAnalytics.PerformanceAnalytics> Analytics { get; set; }

        public ICollection<UserCampaign> UserCampaigns { get; set; } // Navigation property for UserCampaign join table

    }

    public enum CampaignStatus
    {
        Pending,
        Active,
        Completed,
        Cancelled
    }

    // Custom validation attribute for future date validation
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;
                if (date.Date < DateTime.Now.Date)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }

    // Custom validation attribute for date after validation
    public class DateAfterAttribute : ValidationAttribute
    {
        private readonly string _dateToCompareTo;

        public DateAfterAttribute(string dateToCompareTo)
        {
            _dateToCompareTo = dateToCompareTo;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(_dateToCompareTo);
            if (property == null)
            {
                return new ValidationResult($"Unknown property {_dateToCompareTo}");
            }

            var dateToCompareToValue = (DateTime)property.GetValue(validationContext.ObjectInstance);
            var date = (DateTime)value;

            if (date <= dateToCompareToValue)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
