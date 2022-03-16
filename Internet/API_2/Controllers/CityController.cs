
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly SearchEventContext _context;

        public CityController(SearchEventContext context)
        {
            _context = context;
            if (_context.Cities.Count() == 0)
            {
                _context.Cities.Add(new City { Name = "Красноярск" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<City> GetAll()
        {
            return _context.Cities.Include(p => p.Places);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blog = await _context.Cities.SingleOrDefaultAsync(m => m.Id == id);

            if (blog == null)
            {
                return NotFound();
            }

            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Cities.Add(city);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCity", new { id = city.Id }, city);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _context.Cities.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            item.Name = city.Name;
            _context.Cities.Update(item);
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
            var item = _context.Cities.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _context.Cities.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
