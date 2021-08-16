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
        private readonly AmirBarzegarContext _context;

        public BuildingsController(AmirBarzegarContext context)
        {
            _context = context;
        }
         [HttpGet]
        public async Task<ActionResult<IEnumerable<Buildings>>> GetBatteries()
        {
            return await _context.Buildings.ToListAsync();
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

       [HttpGet("{email}")]
        public async Task<ActionResult<List<Buildings>>> getBuildingsByEmail(string email)
        {
        // var findBuildings = from building in _context.Buildings
        //                     join customer in _context.Customers on building.CustomerId equals customer.Id
        //                     where email == customer.EmailOfTheCompany
        //                     select building;

          var findBuildings = await _context.Buildings.FromSqlInterpolated(
                $@"SELECT *
                FROM buildings WHERE customer_id =
                (SELECT Id 
                FROM customers WHERE EmailOfTheCompany = {email})")
                .AsNoTracking()
                .ToListAsync(); 

        //var findBuildings = await _context.Buildings.FromSqlRaw("SELECT * FROM buildings WHERE customer_id = (SELECT Id FROM customers WHERE EmailOfTheCompany = {email})", email).AsNoTracking().ToListAsync();

        return findBuildings;
        }
    }

}