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
    public class LocacoesController : ControllerBase
    {
        private readonly ApiContext _context;

        public LocacoesController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Locacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Locacao>>> GetLocacoes()
        {
            return await _context.Locacoes.ToListAsync();
        }

        // GET: api/Locacoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Locacao>> GetLocacao(int id)
        {
            var locacao = await _context.Locacoes.FindAsync(id);

            if (locacao == null)
            {
                return NotFound();
            }

            return locacao;
        }

        // PUT: api/Locacoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocacao(int id, Locacao locacao)
        {
            if (id != locacao.Id)
            {
                return BadRequest();
            }

            _context.Entry(locacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocacaoExists(id))
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

        // POST: api/Locacoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Locacao>> PostLocacao(Locacao locacao)
        {
            _context.Locacoes.Add(locacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocacao", new { id = locacao.Id }, locacao);
        }

        // DELETE: api/Locacoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocacao(int id)
        {
            var locacao = await _context.Locacoes.FindAsync(id);
            if (locacao == null)
            {
                return NotFound();
            }

            _context.Locacoes.Remove(locacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocacaoExists(int id)
        {
            return _context.Locacoes.Any(e => e.Id == id);
        }

        [HttpPost("Alugar")]
        public async Task<IActionResult> RegistrarLocacao(LocacaoModel alugar)
        {

            var user = await _context.Clientes.Include(f => f.Perfil)
                            .FirstOrDefaultAsync(f => f.Id == alugar.ClienteId);

            if (user == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            var diariaCarro = await _context.Veiculos.Where(c => c.Placa == alugar.VeiculoPlaca).Select(c => c.PrecoDiaria).FirstOrDefaultAsync();
            var valorTotal = diariaCarro * alugar.QtdDias;

            var locacao = new Locacao
            {
                Descricao = string.Empty,
                DataLocacao = alugar.DataLocacao,
                QtdDias = alugar.QtdDias,
                Preco = valorTotal,
                ClienteId = alugar.ClienteId,
                VeiculoPlaca = alugar.VeiculoPlaca,
            };

            _context.Locacoes.Add(locacao);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
