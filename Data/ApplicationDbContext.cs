using Microsoft.EntityFrameworkCore;
using AdCampaigner.Models.ApplicationUser;
using AdCampaigner.Models.Budget;
using AdCampaigner.Models.Campaigns;
using AdCampaigner.Models.PerformanceAnalytics;
using AdCampaigner.Models.Setting;
using AdCampaigner.Models.TargetingOptions;
using AdCampaigner.Models.JoinTables;
using Microsoft.AspNetCore.Identity;

namespace AdCampaigner.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<TargetingOptions> TargetingOptions { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<PerformanceAnalytics> PerformanceAnalytics { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<UserActivityLog> UserActivityLogs { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ignore IdentityUserRole<string> entity
            modelBuilder.Ignore<IdentityUserRole<string>>();

            modelBuilder.Entity<Campaign>()
                .HasMany(c => c.Targets)
                .WithOne(to => to.Campaign)
                .HasForeignKey(to => to.CampaignId);

            modelBuilder.Entity<Campaign>()
                .HasMany(c => c.Budgets)
                .WithOne(b => b.Campaign)
                .HasForeignKey(b => b.CampaignId);

            modelBuilder.Entity<Campaign>()
                .HasMany(c => c.Analytics)
                .WithOne(pa => pa.Campaign)
                .HasForeignKey(pa => pa.CampaignId);

            // Add additional configurations for other relationships

            // Configure many-to-many relationship between ApplicationUser and Campaign
            modelBuilder.Entity<UserCampaign>()
                .HasKey(uc => new { uc.UserId, uc.CampaignId });

            modelBuilder.Entity<UserCampaign>()
                .HasOne(uc => uc.ApplicationUser)
                .WithMany(u => u.UserCampaigns)
                .HasForeignKey(uc => uc.UserId);

            modelBuilder.Entity<UserCampaign>()
                .HasOne(uc => uc.Campaign)
                .WithMany(c => c.UserCampaigns)
                .HasForeignKey(uc => uc.CampaignId);

            modelBuilder.Entity<UserCampaign>()
                .ToTable("UserCampaigns"); // Adjust table name if needed

            // Specify column types for TotalBudget property
            modelBuilder.Entity<Campaign>()
                .Property(c => c.TotalBudget)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Budget>()
                .Property(b => b.TotalBudget)
                .HasColumnType("decimal(18, 2)");
        }
    }
}
