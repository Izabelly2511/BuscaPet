using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BuscaPet.Data;
using BuscaPet.Models;

namespace BuscaPet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlimentacoesController : ControllerBase
    {
        private readonly BuscaPetContext _context;

        public AlimentacoesController(BuscaPetContext context)
        {
            _context = context;
        }

        // GET: api/Alimentacaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alimentacao>>> GetAlimentacoes()
        {
            return await _context.Alimentacoes.ToListAsync();
        }

        // GET: api/Alimentacaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alimentacao>> GetAlimentacao(int id)
        {
            var alimentacao = await _context.Alimentacoes.FindAsync(id);

            if (alimentacao == null)
            {
                return NotFound();
            }

            return alimentacao;
        }

        // PUT: api/Alimentacaos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlimentacao(int id, Alimentacao alimentacao)
        {
            if (id != alimentacao.AlimentacaoId)
            {
                return BadRequest();
            }

            _context.Entry(alimentacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlimentacaoExists(id))
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

        // POST: api/Alimentacaos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Alimentacao>> PostAlimentacao(Alimentacao alimentacao)
        {
            _context.Alimentacoes.Add(alimentacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlimentacao", new { id = alimentacao.AlimentacaoId }, alimentacao);
        }

        // DELETE: api/Alimentacaos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlimentacao(int id)
        {
            var alimentacao = await _context.Alimentacoes.FindAsync(id);
            if (alimentacao == null)
            {
                return NotFound();
            }

            _context.Alimentacoes.Remove(alimentacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlimentacaoExists(int id)
        {
            return _context.Alimentacoes.Any(e => e.AlimentacaoId == id);
        }
    }
}
