using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket_Elevators_REST_API.Models;

namespace Rocket_Elevators_REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class InterventionsController : ControllerBase
    {
        private readonly AmirBarzegarContext _context;

        public InterventionsController(AmirBarzegarContext context)
        {
            _context = context;
        }

        [HttpGet]
    public async Task<ActionResult<IEnumerable<Interventions>>> GetBatteries()
    {
      return await _context.Interventions.ToListAsync();
    }

    [HttpGet("pending")]
    public async Task<ActionResult<List<Interventions>>> Pending()
    {
      var interventions = await _context.Interventions
        .Where(intervention => intervention.StartDate == null && intervention.Status == "Pending")
        .ToListAsync();

      if (interventions == null)
      {
        return NotFound();
      }

      return interventions;
    }


    [HttpPut("{id}/start")]
    public async Task<IActionResult> ChangeInterventionStatus(long id)
    {
      var findIntervention = await _context.Interventions.FindAsync(id);

      if (findIntervention == null)
      {
        return NotFound();
      }

      if (findIntervention.Status == "InProgress")
      {
        ModelState.AddModelError("Status", "This status has been started already.");
      }

      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      findIntervention.Status = "InProgress";
      findIntervention.StartDate = DateTime.Today;
    try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!InterventionExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    [HttpPut("{id}/finish")]
    public async Task<IActionResult> CompleteIntervention(long id)
    {
      var findIntervention = await _context.Interventions.FindAsync(id);

      if (findIntervention == null)
      {
        return NotFound();
      }

      if (findIntervention.Result == "Completed")
      {
        ModelState.AddModelError("Result", "Looks like you didn't change the result.");
      }

      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      findIntervention.Status = "";
      findIntervention.Result = "Completed";
      findIntervention.EndDate = DateTime.Today;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!InterventionExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }
    private bool InterventionExists(long id)
    {
      return _context.Interventions.Any(a => a.Id == id);
    }
  }
}