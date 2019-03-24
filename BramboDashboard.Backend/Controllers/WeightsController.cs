using System.Linq;
using System.Threading.Tasks;
using BramboDashboard.Backend.API.Models;
using BramboDashboard.Backend.API.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BramboDashboard.Backend.API.Controllers
{
    [Produces("application/json")]
    [Route("api/weights")]
    public class WeightController : Controller
    {
      private readonly IWeightService _weightService;

      public WeightController(IWeightService weightService)
      {
        _weightService = weightService;
      }

      [HttpGet("{clientId}")]
      public async Task<IActionResult> GetWeights(int clientId)
      {
        var weights = await _weightService.GetWeights(clientId);

        if (!weights.Any())
        {
          return NotFound();
        }

        return Ok();
      }

      [HttpPost]
      public async Task<IActionResult> RegisterWeight(int clientId, [FromBody] Weight weight)
      {
        // TODO: check client exists - if not return NotFound()

        await _weightService.RegisterWeight(clientId, weight);
        return Ok();
      }
  }
}