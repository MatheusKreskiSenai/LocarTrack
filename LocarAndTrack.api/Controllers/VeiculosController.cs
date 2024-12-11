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
    public class VeiculosController : ControllerBase
    {
        private readonly ApiContext _context;

        public VeiculosController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Veiculos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetVeiculos()
        {
            return await _context.Veiculos.ToListAsync();
        }

        // GET: api/Veiculos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Veiculo>> GetVeiculo(string id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);

            if (veiculo == null)
            {
                return NotFound();
            }

            return veiculo;
        }

        // PUT: api/Veiculos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVeiculo(string id, Veiculo veiculo)
        {
            if (id != veiculo.Placa)
            {
                return BadRequest();
            }

            _context.Entry(veiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeiculoExists(id))
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

        // POST: api/Veiculos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Veiculo>> PostVeiculo(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VeiculoExists(veiculo.Placa))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVeiculo", new { id = veiculo.Placa }, veiculo);
        }

        // DELETE: api/Veiculos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVeiculo(string id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo == null)
            {
                return NotFound();
            }

            _context.Veiculos.Remove(veiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VeiculoExists(string id)
        {
            return _context.Veiculos.Any(e => e.Placa == id);
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> BuscarVeiculos([FromQuery] string? marca, [FromQuery] string? tipo)
        {
            var query = _context.Veiculos.AsQueryable();

            if (!string.IsNullOrEmpty(marca))
            {
                query = query.Where(v => v.Marca.Contains(marca));
            }

            if (!string.IsNullOrEmpty(tipo))
            {
                query = query.Where(v => v.Tipo.Contains(tipo));
            }

            var veiculos = await query
                .Include(v => v.Locadora)
                .ToListAsync();

            var resultado = veiculos.Select(v => new
            {
                v.Placa,
                v.Marca,
                v.Tipo,
                v.PrecoDiaria,
                v.N_Passageiros,
                Locadora = v.Locadora != null ? v.Locadora.Nome : "Não Informada",
                v.UrlCarroImage
            });

            return Ok(resultado);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImagem(IFormFile imagem, int veiculoId)
        {
            if (imagem == null || imagem.Length == 0)
                return BadRequest("Nenhuma imagem foi enviada.");

            var veiculo = await _context.Veiculos.FindAsync(veiculoId);
            if (veiculo == null)
                return NotFound("Veículo não encontrado.");

            var pastaImagens = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens");
            if (!Directory.Exists(pastaImagens))
                Directory.CreateDirectory(pastaImagens);

            var nomeArquivo = $"{Guid.NewGuid()}_{imagem.FileName}";
            var caminhoCompleto = Path.Combine(pastaImagens, nomeArquivo);

            using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                await imagem.CopyToAsync(stream);
            }

            veiculo.UrlCarroImage = $"/imagens/{nomeArquivo}";
            _context.Veiculos.Update(veiculo);
            await _context.SaveChangesAsync();

            return Ok("Imagem salva com sucesso.");
        }


    }
}
