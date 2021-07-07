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

    public class BuildingsController : ControllerBase
    {
        private readonly lukagasicContext _context;

        public BuildingsController(lukagasicContext context)
        {
            _context = context;
        }

        [HttpGet("InterventionBuildings")]
        public async Task<ActionResult<IEnumerable<Buildings>>> GetInterventionBuildings()
        {

            var findBuildings = from building in _context.Buildings
                                from battery in building.Batteries
                                from column in battery.Columns
                                from elevator in column.Elevators
                                where battery.Status.Equals("Intervention") || column.Status.Equals("Intervention") || elevator.Status.Equals("Intervention")
                                select building;

            var distinctBuildings = (from building in findBuildings
                               select building).Distinct();


        return await distinctBuildings.ToListAsync();
        }

       
    }

}