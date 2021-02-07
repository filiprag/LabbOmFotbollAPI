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
            try
            {
                return await _context.Arenas.ToListAsync();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw null;
            }
        }

        // GET: api/Arenas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Arena>> GetArena(int id)
        {
            try
            {
                var arena = await _context.Arenas.FindAsync(id);

                if (arena == null)
                {
                    return NotFound();
                }

                return arena;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw null;
            }

        }
        // Dena funktion är ej implenterad & används ej
        // PUT: api/Arenas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArena(int id, Arena arena)
        {
            try
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
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw null;
            }
        }

        // Dena funktion är ej implenterad & används ej
        // POST: api/Arenas
        [HttpPost]
        public async Task<ActionResult<Arena>> PostArena(Arena arena)
        {
            try
            {

                _context.Arenas.Add(arena);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetArena", new { id = arena.Id }, arena);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw null;
            }
        }

        // Dena funktion är ej implenterad & används ej
        // DELETE: api/Arenas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArena(int id)
        {
            try
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
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw null;
            }
        }

        private bool ArenaExists(int id)
        {
            return _context.Arenas.Any(e => e.Id == id);
        }
    }
}
