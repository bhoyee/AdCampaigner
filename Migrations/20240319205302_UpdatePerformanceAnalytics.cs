using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdCampaigner.Migrations
{
    public partial class UpdatePerformanceAnalytics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Demographics",
                table: "TargetingOptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GeographicLocation",
                table: "TargetingOptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Interests",
                table: "TargetingOptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Clicks",
                table: "PerformanceAnalytics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Conversions",
                table: "PerformanceAnalytics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Impressions",
                table: "PerformanceAnalytics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ROI",
                table: "PerformanceAnalytics",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Demographics",
                table: "TargetingOptions");

            migrationBuilder.DropColumn(
                name: "GeographicLocation",
                table: "TargetingOptions");

            migrationBuilder.DropColumn(
                name: "Interests",
                table: "TargetingOptions");

            migrationBuilder.DropColumn(
                name: "Clicks",
                table: "PerformanceAnalytics");

            migrationBuilder.DropColumn(
                name: "Conversions",
                table: "PerformanceAnalytics");

            migrationBuilder.DropColumn(
                name: "Impressions",
                table: "PerformanceAnalytics");

            migrationBuilder.DropColumn(
                name: "ROI",
                table: "PerformanceAnalytics");
        }
    }
}
