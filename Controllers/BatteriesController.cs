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
    public class BatteriesController : ControllerBase
    {
        private readonly AmirBarzegarContext _context;

        public BatteriesController(AmirBarzegarContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Batteries>>> GetBatteries()
        {
            return await _context.Batteries.ToListAsync();
        }

        //Get: api/Batteries/id       
        //Info for battery *id= battery you want info on, for example: 1*
        [HttpGet("{id}")]
        public async Task<ActionResult<Batteries>> GetBattery(long id)
        {
            var battery = await _context.Batteries.FindAsync(id);

            if (battery == null)
            {
                return NotFound();
            }

            return battery;
        }

        //Get: api/Batteries/id/status
        //Info on status of battery *id= battery you want info on, for example: 1*
        [HttpGet("{id}/status")]
        public async Task<ActionResult<string>> GetBatteryStatus(long id)
        {
            var battery = await _context.Batteries.FindAsync(id);

            if (battery == null)
            {
                return NotFound();
            }

            return battery.Status;
        }

        //Put: api/Batteries/id?status=s
        //Change the status of battery *id= battery you want to change, s= what status to put, for example 1?status=on*
        [HttpPut("{id}")]
        public async Task<ActionResult<Batteries>> PutBatteries(long id, string status)
        {
            if (status != null)
            {
                Batteries battery = await _context.Batteries.FindAsync(id);
                if (battery == null) return NotFound();

                battery.Status = status;

                _context.Batteries.Update(battery);
                _context.SaveChanges();

            };

            return await _context.Batteries.FindAsync(id);
        }
    }
}