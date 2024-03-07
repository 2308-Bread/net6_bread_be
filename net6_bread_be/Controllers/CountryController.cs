using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using net6_bread_be;
using net6_bread_be.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace net6_bread_be.Controllers
{
    [ApiController] //this has API behaviors
    [Route("[controller]")] //this is defining routes
    public class CountryController : ControllerBase //inherits from controllerbase
    {
        private readonly CountryTrackerContext _context; //holds the db context and can't be modified elsewhere (readonly)

        public CountryController(CountryTrackerContext context) //receives an instance and assigns it
        {
            _context = context; //interacts with database
        }

        // GET: /Country
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetAllCountries()
        {
            var countries = await _context.Countries.ToListAsync();
            if (!countries.Any())
            {
                return NotFound(); // Or return an empty list with Ok(new List<Bread>()) if that's preferred
            }

            return Ok(countries); // Ensure wrapping the result with Ok()
        }

        // GET: /Country/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountryById(int id)
        {
            var country = await _context.Countries.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            return Ok(country); // Explicitly return an OkObjectResult with the bread item
        }

        // GET: /Country/{id}   <-- This method will replace the method above. I'm just work shopping here.
        [HttpGet("/testing/{id}")]
        public async Task<IActionResult> GetCountryAndBreads(int id)
        {
            var country = await _context.Countries.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            var breads = await _context.Breads.Where(b => b.CountryId == id).ToListAsync();

            var result = new
            {
                Country = new
                {
                    country.CountryId,
                    country.Name,
                    country.Description
                },
                Bread = breads.Select(b => new
                {
                    b.BreadId,
                    b.Name,
                    b.Recipe,
                    b.Description
                })
            };
            return Ok(result);
        }
    }
}