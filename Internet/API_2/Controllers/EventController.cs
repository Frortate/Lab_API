
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly SearchEventContext _context;

        public EventController(SearchEventContext context)
        {
            _context = context;
            if (_context.Events.Count() == 0)
            {
                _context.Events.Add(new Event { Title = "No Name", Description = "Что-то о фильме No Name", 
                    Site = "https://metanit.com/sharp/entityframeworkcore/1.3.php", IsNew = false, TypeId = 3, CategoryId = 2,
                    AgeId = 1});
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Event> GetAll()
        {
            return _context.Events.Include(p => p.EventsOrganizers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blog = await _context.Events.SingleOrDefaultAsync(m => m.Id == id);

            if (blog == null)
            {
                return NotFound();
            }

            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Event evnt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Events.Add(evnt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvent", new { id = evnt.Id }, evnt);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Event evnt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _context.Events.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            item.Title = evnt.Title;
            item.Description = evnt.Description;
            item.Site = evnt.Site;
            item.Poster = evnt.Poster;
            item.IsNew = evnt.IsNew;
            item.TypeId = evnt.TypeId;
            item.CategoryId = evnt.CategoryId;
            item.AgeId = evnt.AgeId;
            

            _context.Events.Update(item);
            
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
            var item = _context.Events.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _context.Events.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
