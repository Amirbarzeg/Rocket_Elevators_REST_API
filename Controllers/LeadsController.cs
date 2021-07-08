using System;
using System.Data;
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

        [HttpGet("RecentLeads")]
        public async Task<ActionResult<List<Leads>>> RecentLeads30()
        {
            // var findLeads = from lead in _context.Leads
            //                 join customer in _context.Customers on lead.Email equals customer.EmailOfTheCompany
            //                 where lead.CreatedAt >= DateTime.Today.AddDays(-30)
            //                 select lead;

            // var findLeads = (from lead in _context.Leads join customer in _context.Customers on lead.Email equals customer.EmailOfTheCompany 
            //                 where lead.CreatedAt >= DbFunctions.DateDiffDay(DateTime.Today,-30) select lead)
            //                 .AsNoTracking()
            //                 .ToListAsync();

            var findLeads = await _context.Leads.FromSqlInterpolated(
                $@"SELECT DISTINCT l.*
                FROM leads l WHERE email NOT IN
                (SELECT EmailOfTheCompany 
                FROM customers) AND created_at >= DATE_SUB(NOW(), INTERVAL 30 DAY)")
                .AsNoTracking()
                .ToListAsync();    

            
            if (findLeads == null)
            {
                return NotFound();
            }

            return findLeads;
        }

       
    }

}