
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizerController : ControllerBase
    {
        private readonly SearchEventContext _context;

        public OrganizerController(SearchEventContext context)
        {
            _context = context;
            if (_context.Organizers.Count() == 0)
            {
                _context.Organizers.Add(new Organizer { Name = "No Name Two", 
                    Site = "https://stackoverflow.com/questions/58006152/net-core-3-not-having-referenceloophandling-in-addjsonoptions", PlaceId = 2 });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Organizer> GetAll()
        {
            return _context.Organizers.Include(p => p.EventsOrganizers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrganizer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blog = await _context.Organizers.SingleOrDefaultAsync(m => m.Id == id);

            if (blog == null)
            {
                return NotFound();
            }

            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Organizer organizer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Organizers.Add(organizer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrganizer", new { id = organizer.Id }, organizer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Organizer organizer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _context.Organizers.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            item.Name = organizer.Name;
            item.Site = organizer.Site;
            item.PlaceId = organizer.PlaceId;

            _context.Organizers.Update(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _context.Organizers.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _context.Organizers.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
