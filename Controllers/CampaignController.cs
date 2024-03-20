using AdCampaigner.Interfaces;
using AdCampaigner.Models.Campaigns;
using Microsoft.AspNetCore.Mvc;

namespace AdCampaigner.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampaignController : ControllerBase
    {
        private readonly ICampaign _campaignService;

        public CampaignController(ICampaign campaignService)
        {
            _campaignService = campaignService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var campaign = _campaignService.GetById(id);
            if (campaign == null)
            {
                return NotFound();
            }
            return Ok(campaign);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Campaign campaign)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _campaignService.Create(campaign);
            return CreatedAtAction(nameof(Get), new { id = campaign.Id }, campaign);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Campaign campaign)
        {
            if (id != campaign.Id)
            {
                return BadRequest();
            }
            try
            {
                _campaignService.Update(campaign);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingCampaign = _campaignService.GetById(id);
            if (existingCampaign == null)
            {
                return NotFound();
            }
            _campaignService.Delete(id);
            return NoContent();
        }
    }
}
