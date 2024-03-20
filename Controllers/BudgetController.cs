using AdCampaigner.Interfaces;
using AdCampaigner.Models.Budget;
using Microsoft.AspNetCore.Mvc;

namespace AdCampaigner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly IBudget _budgetService;

        public BudgetController(IBudget budgetService)
        {
            _budgetService = budgetService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Budget>>> GetBudgets()
        {
            var budgets = await _budgetService.GetAllBudgetsAsync();
            return Ok(budgets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Budget>> GetBudget(int id)
        {
            var budget = await _budgetService.GetBudgetByIdAsync(id);
            if (budget == null)
            {
                return NotFound();
            }
            return Ok(budget);
        }

        [HttpPost]
        public async Task<ActionResult<AdCampaigner.Models.Budget.Budget>> CreateBudget(AdCampaigner.Models.Budget.Budget budget)
        {
            await _budgetService.CreateBudgetAsync(budget);
            return CreatedAtAction(nameof(GetBudget), new { id = budget.Id }, budget);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBudget(int id, AdCampaigner.Models.Budget.Budget budget)
        {
            if (id != budget.Id)
            {
                return BadRequest();
            }
            await _budgetService.UpdateBudgetAsync(id, budget);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBudget(int id)
        {
            await _budgetService.DeleteBudgetAsync(id);
            return NoContent();
        }
    }
}
