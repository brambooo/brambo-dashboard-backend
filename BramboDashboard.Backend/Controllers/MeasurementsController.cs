using System;
using System.Linq;
using System.Threading.Tasks;
using BramboDashboard.Backend.API.Models;
using BramboDashboard.Backend.API.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BramboDashboard.Backend.API.Controllers
{
  [Produces("application/json")]
  [Route("api/measurements")]
  public class MeasurementsController : Controller
  {
    private readonly IMeasurementService _weightService;

    public MeasurementsController(IMeasurementService measurementService)
    {
      _weightService = measurementService;
    }

    [HttpGet("{clientId}")]
    public async Task<IActionResult> GetMeasurementAsync(int clientId)
    {
      var weights = await _weightService.GetMeasurementsAsync(clientId);

      if (!weights.Any())
      {
        return NotFound();
      }

      return Ok(weights);
    }

    [HttpGet("{clientId}/periods/{date}")]
    public async Task<IActionResult> GetMeasurementForDateAsync(int clientId, DateTime date)
    {
      var measurement = await _weightService.GetMeasurementForDateAsync(clientId, date);
      return Ok(measurement);
    }

    [HttpGet("{clientId}/periods/{startDate}/{endDate}")]
    public async Task<IActionResult> GetMeasurementForDateAsync(int clientId, DateTime startDate, DateTime endDate)
    {
      var measurements = await _weightService.GetMeasurementForPeriodAsync(clientId, startDate, endDate);
      return Ok(measurements);
    }

    [HttpPost]
    [Route("{clientId}")]
    public async Task<IActionResult> RegisterMeasurementAsync(int clientId, [FromBody] RegisterMeasurement measurement)
    {
      // TODO: check client exists - if not return NotFound()
      await _weightService.RegisterMeasurementAsync(clientId, measurement);
      return Ok();
    }
  }
}