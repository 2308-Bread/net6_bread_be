using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using net6_bread_be;
using net6_bread_be.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace net6_bread_be.Controllers
{
    [ApiController] //this has API behaviors
    [Route("[controller]")] //this is defining routes
    public class BreadController : ControllerBase //inherits from controllerbase
    {
        private readonly BreadTrackerContext _context; //holds the db context and can't be modified elsewhere (readonly)

        public BreadController(BreadTrackerContext context) //receives an instance and assigns it
        {
            _context = context; //interacts with database
        }

        // GET: /Bread
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bread>>> GetAllBreads()
        {
            var breads = await _context.Breads.ToListAsync();
            if (!breads.Any())
            {
                return NotFound(); // Or return an empty list with Ok(new List<Bread>()) if that's preferred
            }

            return Ok(breads); // Ensure wrapping the result with Ok()
        }

        // GET: /Bread/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Bread>> GetBreadById(int id)
        {
            var bread = await _context.Breads.FindAsync(id);

            if (bread == null)
            {
                return NotFound();
            }

            return Ok(bread); // Explicitly return an OkObjectResult with the bread item
        }

    }
}
