using System;
using System.Threading.Tasks;
using BramboDashboard.Backend.API.Exceptions;
using BramboDashboard.Backend.API.Models;
using BramboDashboard.Backend.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace BramboDashboard.Backend.API.Controllers
{
  [Route("api/clients")]
  public class ClientsController : Controller
  {
    private readonly IClientService _clientService;

    public ClientsController(IClientService clientService)
    {
      _clientService = clientService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddUserViewModel model)
    {
      // Validate
      if (!ModelState.IsValid)
      {
        return BadRequest("Required fields are empty.");
      }

      await _clientService.Add(model);
      return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      // Validate
      if (!ModelState.IsValid)
      {
        return BadRequest("User id is required.");
      }
      try
      {
        var user = await _clientService.Get(id);
        return Ok(user);
      }
      catch (Exception e)
      {
        return BadRequest(e is UserNotFoundException ? "User with given ID cannot be found." : "Something went wrong.");
      }
    }

    [HttpGet]
    [Route("Users/{id}/Weights/{weight}/")]
    public async Task<IActionResult> UserRegisterWeight(int id, decimal weight)
    {
      // Validate
      if (!ModelState.IsValid)
      {
        return BadRequest("Required fields are empty.");
      }

      try
      {
        await _clientService.RegisterWeight(id, weight);
      }
      catch (Exception e)
      {
        // TODO: Log exception
        return BadRequest(e is UserNotFoundException ? "User with given ID cannot be found." : "Something went wrong.");
      }
      return Ok();
    }
  }
}