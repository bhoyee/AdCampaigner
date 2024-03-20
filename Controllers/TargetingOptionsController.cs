using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdCampaigner.Interfaces;
using AdCampaigner.Models.TargetingOptions;

namespace AdCampaigner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TargetingOptionsController : ControllerBase
    {
        private readonly ITargetingOptions _targetingOptionsService;

        public TargetingOptionsController(ITargetingOptions targetingOptionsService)
        {
            _targetingOptionsService = targetingOptionsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TargetingOptions>>> GetTargetingOptions()
        {
            var targetingOptions = await _targetingOptionsService.GetAllTargetingOptionsAsync();
            return Ok(targetingOptions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TargetingOptions>> GetTargetingOptions(int id)
        {
            var targetingOptions = await _targetingOptionsService.GetTargetingOptionsByIdAsync(id);
            if (targetingOptions == null)
            {
                return NotFound();
            }
            return Ok(targetingOptions);
        }

        [HttpPost]
        public async Task<ActionResult<TargetingOptions>> CreateTargetingOptions(TargetingOptions targetingOptions)
        {
            await _targetingOptionsService.CreateTargetingOptionsAsync(targetingOptions);
            return CreatedAtAction(nameof(GetTargetingOptions), new { id = targetingOptions.Id }, targetingOptions);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTargetingOptions(int id, TargetingOptions targetingOptions)
        {
            if (id != targetingOptions.Id)
            {
                return BadRequest();
            }
            await _targetingOptionsService.UpdateTargetingOptionsAsync(id, targetingOptions);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTargetingOptions(int id)
        {
            await _targetingOptionsService.DeleteTargetingOptionsAsync(id);
            return NoContent();
        }
    }
}
