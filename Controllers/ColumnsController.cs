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

    public class ColumnsController : ControllerBase
    {
        private readonly AmirBarzegarContext _context;

        public ColumnsController(AmirBarzegarContext context)
        {
            _context = context;
        }

        //Get: api/Columns/id/status
        //Info on status of column *id= column you want info on, for example: 1*
        [HttpGet("{id}/status")]
        public async Task<ActionResult<string>> GetColumnStatus(long id)
        {
            var column = await _context.Columns.FindAsync(id);

            if (column == null)
            {
                return NotFound();
            }

            return column.Status;
        }

        //Put: api/Columns/id?status=s
        //Change the status of column *id= column you want to change, s= what status to put, for example 1?status=on*
        [HttpPut("{id}")]
        public async Task<ActionResult<Columns>> PutColumns(long id, string status)
        {
            if (status != null)
            {
                Columns column = await _context.Columns.FindAsync(id);
                if (column == null) return NotFound();

                column.Status = status;

                _context.Columns.Update(column);
                _context.SaveChanges();

            };

            return await _context.Columns.FindAsync(id);
        }
    }

}