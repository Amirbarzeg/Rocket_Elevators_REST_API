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

    public class LeadsController : ControllerBase
    {
        private readonly lukagasicContext _context;

        public LeadsController(lukagasicContext context)
        {
            _context = context;
        }

        // [HttpGet("RecentLeads")]
        // public async Task<ActionResult<List<Leads>>> LastThirtyDays()
        // {
        //     var customer = await _context.Customers
        //         .Where
        //         .ToListAsync();
        //     var lead = await _context.Leads
        //         .Where(lead => lead.Email == customer.EmailOfTheCompany)
        //         .ToListAsync();

        //     var newLeads = lead.Where(lead => lead.CreatedAt >= DateTime.Today.AddDays(-30)).ToList();
        //                                 //   1986                   2/25/21
        //     if (newLeads == null)
        //     {
        //         return NotFound();
        //     }

        //     return newLeads;
        // }

       
    }

}