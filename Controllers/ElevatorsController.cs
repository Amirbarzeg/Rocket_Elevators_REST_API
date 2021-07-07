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

    public class ElevatorsController : ControllerBase
    {
        private readonly lukagasicContext _context;

        public ElevatorsController(lukagasicContext context)
        {
            _context = context;
        }

        //Get: api/Elevators/id/status
        //Info on status of elevator *id= elevator you want info on, for example: 1*
        [HttpGet("{id}/status")]
        public async Task<ActionResult<string>> GetElevatorStatus(long id)
        {
            var elevator = await _context.Elevators.FindAsync(id);

            if (elevator == null)
            {
                return NotFound();
            }

            return elevator.Status;
        }

        //Put: api/Elevators/id?status=s
        //Change the status of elevator *id= elevator you want to change, s= what status to put, for example 1?status=on*
        [HttpPut("{id}")]
        public async Task<ActionResult<Elevators>> PutElevators(long id, string status)
        {
            if (status != null)
            {
                Elevators elevator = await _context.Elevators.FindAsync(id);
                if (elevator == null) return NotFound();

                elevator.Status = status;

                _context.Elevators.Update(elevator);
                _context.SaveChanges();

            };

            return await _context.Elevators.FindAsync(id);
        }

        //Get: api/Elevators/NotActive
        //List all the elevators where status is not active. 
        [HttpGet("NotActive")]
        public object GetElevatorsNotActive()
        {
            return _context.Elevators
                  .Where(elevator => elevator.Status != "Active")
                  .Select(elevator => new { elevator.Id, elevator.Status });

        }
    }

}