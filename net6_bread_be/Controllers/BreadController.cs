using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using net6_bread_be;
using net6_bread_be.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace net6_bread_be.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BreadController : ControllerBase
    {
        private readonly BreadTrackerContext _context;

        public BreadController(BreadTrackerContext context)
        {
            _context = context;
        }

        // GET: /Bread
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bread>>> GetAllBreads()
        {
            return await _context.Breads.ToListAsync();
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

            return bread;
        }

    }
}
