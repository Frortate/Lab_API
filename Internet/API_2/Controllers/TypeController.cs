
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly SearchEventContext _context;

        public TypeController(SearchEventContext context)
        {
            _context = context;
            if (_context.Types.Count() == 0)
            {
                _context.Types.Add(new Type { Name = "*****" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Type> GetAll()
        {
            return _context.Types.Include(p => p.Events);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blog = await _context.Types.SingleOrDefaultAsync(m => m.Id == id);

            if (blog == null)
            {
                return NotFound();
            }

            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Type type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Types.Add(type);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetType", new { id = type.Id }, type);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Type type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _context.Types.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            item.Name = type.Name;
            _context.Types.Update(item);
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
            var item = _context.Types.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _context.Types.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
