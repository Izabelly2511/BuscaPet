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
    public class PosicoesController : ControllerBase
    {
        private readonly BuscaPetContext _context;

        public PosicoesController(BuscaPetContext context)
        {
            _context = context;
        }

        // GET: api/Posicoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Posicao>>> GetPosicoes()
        {
            return await _context.Posicoes.ToListAsync();
        }

        // GET: api/Posicoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Posicao>> GetPosicao(int id)
        {
            var posicao = await _context.Posicoes.FindAsync(id);

            if (posicao == null)
            {
                return NotFound();
            }

            return posicao;
        }

        // PUT: api/Posicoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosicao(int id, Posicao posicao)
        {
            if (id != posicao.PosicaoId)
            {
                return BadRequest();
            }

            _context.Entry(posicao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosicaoExists(id))
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

        // POST: api/Posicoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Posicao>> PostPosicao(Posicao posicao)
        {
            _context.Posicoes.Add(posicao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPosicao", new { id = posicao.PosicaoId }, posicao);
        }

        // DELETE: api/Posicoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePosicao(int id)
        {
            var posicao = await _context.Posicoes.FindAsync(id);
            if (posicao == null)
            {
                return NotFound();
            }

            _context.Posicoes.Remove(posicao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PosicaoExists(int id)
        {
            return _context.Posicoes.Any(e => e.PosicaoId == id);
        }
    }
}
