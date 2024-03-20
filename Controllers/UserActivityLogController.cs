using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdCampaigner.Interfaces;
using AdCampaigner.Models.ApplicationUser;

namespace AdCampaigner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserActivityLogController : ControllerBase
    {
        private readonly IUserActivityLog _userActivityLogService;

        public UserActivityLogController(IUserActivityLog userActivityLogService)
        {
            _userActivityLogService = userActivityLogService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserActivityLog>>> GetUserActivityLogs()
        {
            var activityLogs = await _userActivityLogService.GetAllUserActivityLogsAsync();
            return Ok(activityLogs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserActivityLog>> GetUserActivityLog(int id)
        {
            var activityLog = await _userActivityLogService.GetUserActivityLogByIdAsync(id);
            if (activityLog == null)
            {
                return NotFound();
            }
            return Ok(activityLog);
        }

        [HttpPost]
        public async Task<ActionResult<UserActivityLog>> CreateUserActivityLog(UserActivityLog activityLog)
        {
            await _userActivityLogService.CreateUserActivityLogAsync(activityLog);
            return CreatedAtAction(nameof(GetUserActivityLog), new { id = activityLog.Id }, activityLog);
        }

        // Add additional CRUD endpoints as needed
    }
}
