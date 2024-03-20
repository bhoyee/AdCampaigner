using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdCampaigner.Interfaces;
using AdCampaigner.Models.PerformanceAnalytics;

namespace AdCampaigner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceAnalyticsController : ControllerBase
    {
        private readonly IPerformanceAnalytics _analyticsService;

        public PerformanceAnalyticsController(IPerformanceAnalytics analyticsService)
        {
            _analyticsService = analyticsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PerformanceAnalytics>>> GetPerformanceAnalytics()
        {
            var analytics = await _analyticsService.GetAllPerformanceAnalyticsAsync();
            return Ok(analytics);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PerformanceAnalytics>> GetPerformanceAnalytics(int id)
        {
            var analytics = await _analyticsService.GetPerformanceAnalyticsByIdAsync(id);
            if (analytics == null)
            {
                return NotFound();
            }
            return Ok(analytics);
        }

        [HttpPost]
        public async Task<ActionResult<PerformanceAnalytics>> CreatePerformanceAnalytics(PerformanceAnalytics analytics)
        {
            await _analyticsService.CreatePerformanceAnalyticsAsync(analytics);
            return CreatedAtAction(nameof(GetPerformanceAnalytics), new { id = analytics.Id }, analytics);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerformanceAnalytics(int id, PerformanceAnalytics analytics)
        {
            if (id != analytics.Id)
            {
                return BadRequest();
            }
            await _analyticsService.UpdatePerformanceAnalyticsAsync(id, analytics);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerformanceAnalytics(int id)
        {
            await _analyticsService.DeletePerformanceAnalyticsAsync(id);
            return NoContent();
        }
    }
}
