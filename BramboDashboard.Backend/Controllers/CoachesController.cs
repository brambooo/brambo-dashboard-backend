using System.Collections.Generic;
using BramboDashboard.Backend.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BramboDashboard.Backend.API.Controllers
{
    [Route("api/[controller]")]
    public class CoachesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "coach 1", "coach 2" };
        }

        // GET api/coaches/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public IActionResult Post([FromBody] Coach coach)
        {
          // Validate
//          _coachService.Add(coach);
          return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
