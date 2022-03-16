
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly SearchEventContext _context;

        public PlaceController(SearchEventContext context)
        {
            _context = context;
            if (_context.Places.Count() == 0)
            {
                _context.Places.Add(new Place { Address = "*******", CityId = 1});
                _context.SaveChanges();
            }
        }
        
        [HttpGet]
        public IEnumerable<Place> GetPlace()
        {
            return _context.Places.Include(p => p.Organizers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blog = await _context.Places.SingleOrDefaultAsync(m => m.Id == id);

            if (blog == null)
            {
                return NotFound();
            }

            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Place place)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Places.Add(place);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlace", new { id = place.Id }, place);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Place place)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _context.Places.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            item.Address = place.Address;
            item.CityId = place.CityId;
            _context.Places.Update(item);
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
            var item = _context.Places.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _context.Places.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
