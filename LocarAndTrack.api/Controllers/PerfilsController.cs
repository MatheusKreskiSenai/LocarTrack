﻿using System;
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
    public class PerfilsController : ControllerBase
    {
        private readonly ApiContext _context;

        public PerfilsController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Perfils
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Perfil>>> GetPerfis()
        {
            return await _context.Perfis.ToListAsync();
        }

        // GET: api/Perfils/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Perfil>> GetPerfil(int id)
        {
            var perfil = await _context.Perfis.FindAsync(id);

            if (perfil == null)
            {
                return NotFound();
            }

            return perfil;
        }

        // PUT: api/Perfils/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerfil(int id, Perfil perfil)
        {
            if (id != perfil.Id)
            {
                return BadRequest();
            }

            _context.Entry(perfil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerfilExists(id))
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

        // POST: api/Perfils
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Perfil>> PostPerfil(Perfil perfil)
        {
            _context.Perfis.Add(perfil);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerfil", new { id = perfil.Id }, perfil);
        }

        // DELETE: api/Perfils/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerfil(int id)
        {
            var perfil = await _context.Perfis.FindAsync(id);
            if (perfil == null)
            {
                return NotFound();
            }

            _context.Perfis.Remove(perfil);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PerfilExists(int id)
        {
            return _context.Perfis.Any(e => e.Id == id);
        }
    }
}
