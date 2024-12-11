using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LocarAndTrack.Models;
using LocarAndTrack.api.Data;

namespace LocarAndTrack.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocadorasController : ControllerBase
    {
        private readonly ApiContext _context;

        public LocadorasController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Locadoras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Locadora>>> GetLocadoras()
        {
            return await _context.Locadoras.ToListAsync();
        }

        // GET: api/Locadoras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Locadora>> GetLocadora(int id)
        {
            var locadora = await _context.Locadoras.FindAsync(id);

            if (locadora == null)
            {
                return NotFound();
            }

            return locadora;
        }

        // PUT: api/Locadoras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocadora(int id, Locadora locadora)
        {
            if (id != locadora.Id)
            {
                return BadRequest();
            }

            _context.Entry(locadora).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocadoraExists(id))
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

        // POST: api/Locadoras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Locadora>> PostLocadora(Locadora locadora)
        {
            _context.Locadoras.Add(locadora);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocadora", new { id = locadora.Id }, locadora);
        }

        // DELETE: api/Locadoras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocadora(int id)
        {
            var locadora = await _context.Locadoras.FindAsync(id);
            if (locadora == null)
            {
                return NotFound();
            }

            _context.Locadoras.Remove(locadora);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocadoraExists(int id)
        {
            return _context.Locadoras.Any(e => e.Id == id);
        }
    }
}
