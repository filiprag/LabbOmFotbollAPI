using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LabbOmFotbollAPI.Model;

namespace LabbOmFotbollAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArenasController : ControllerBase
    {
        private readonly ArenaDbModel _context;

        public ArenasController(ArenaDbModel context)
        {
            _context = context;
        }

        // GET: api/Arenas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Arena>>> GetArenas()
        {
            return await _context.Arenas.ToListAsync();
        }

        // GET: api/Arenas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Arena>> GetArena(int id)
        {
            var arena = await _context.Arenas.FindAsync(id);

            if (arena == null)
            {
                return NotFound();
            }

            return arena;
        }

        // PUT: api/Arenas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArena(int id, Arena arena)
        {
            if (id != arena.Id)
            {
                return BadRequest();
            }

            _context.Entry(arena).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArenaExists(id))
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

        // POST: api/Arenas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Arena>> PostArena(Arena arena)
        {
            _context.Arenas.Add(arena);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArena", new { id = arena.Id }, arena);
        }

        // DELETE: api/Arenas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArena(int id)
        {
            var arena = await _context.Arenas.FindAsync(id);
            if (arena == null)
            {
                return NotFound();
            }

            _context.Arenas.Remove(arena);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArenaExists(int id)
        {
            return _context.Arenas.Any(e => e.Id == id);
        }
    }
}
