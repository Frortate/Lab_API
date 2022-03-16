
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgeController : ControllerBase
    {
        private readonly SearchEventContext _context;

        public AgeController(SearchEventContext context)
        {
            _context = context;
            if (_context.Ages.Count() == 0)
            {
                _context.Ages.Add(new Age { Age1 = 21 });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Age> GetAll()
        {
            return _context.Ages.Include(p => p.Events);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAge([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var age = await _context.Ages.SingleOrDefaultAsync(m => m.Id == id);

            if (age == null)
            {
                return NotFound();
            }

            return Ok(age);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Age age)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Ages.Add(age);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAge", new { id = age.Id }, age);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Age age)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _context.Ages.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            item.Age1 = age.Age1;
            _context.Ages.Update(item);
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
            var item = _context.Ages.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _context.Ages.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
