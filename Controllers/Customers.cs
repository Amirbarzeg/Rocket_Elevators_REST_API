using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket_Elevators_REST_API.Models;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly AmirBarzegarContext _context;

        public CustomersController(AmirBarzegarContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customers>>> Getcustomers()
        {
            return await _context.Customers.ToListAsync();
        }


        //GET: api/Customers/email
        [HttpGet("{email}")]
        public async Task<ActionResult<IEnumerable<Customers>>> GetcustomersEmail(string email)
        
        {
            var customer = await _context.Customers.Where(e=>e.EmailOfTheCompany == email).ToListAsync();

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }


        //GET: api/Customers/FullInfo/email
        [HttpGet("FullInfo/{email}")]
        public async Task<ActionResult<Customers>> GetCustomer(string email)
        {
            
            var customer = await _context.Customers.Include("Buildings.Batteries.Columns.Elevators")
                                                    .Where(c => c.EmailOfTheCompany == email)
                                                    .FirstOrDefaultAsync();                     

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }        

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(long id, Customers customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        //--------------------------------------------------- Update Customer ---------------------------------------------------------------\\       

        // PUT: api/Customers/email
        [HttpPut]
        public async Task<ActionResult<Customers>> PutCustomer(Customers customer)
        {
            var customerToUpdate = await _context.Customers
                                                .Where(c => c.EmailOfTheCompany == customer.EmailOfTheCompany)
                                                .FirstOrDefaultAsync(); 

            if (customerToUpdate == null)
            {
                return NotFound();
            }

            customerToUpdate.CompanyName = customer. CompanyName ;
            customerToUpdate.NameOfContact = customer.NameOfContact;
            customerToUpdate.CompanyContactPhone = customer.CompanyContactPhone;
            customerToUpdate.EmailOfTheCompany = customer.EmailOfTheCompany;
            customerToUpdate.CompanyDescription = customer.CompanyDescription;
            customerToUpdate.CompanyDescription = customer.CompanyDescription;
            customerToUpdate.TechAuhtorityPhone = customer.TechAuhtorityPhone;
            customerToUpdate.TechManagerServiceEmail = customer.TechManagerServiceEmail;

            await _context.SaveChangesAsync();

            return NoContent();
        } 

        private bool CustomerExists(long id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}