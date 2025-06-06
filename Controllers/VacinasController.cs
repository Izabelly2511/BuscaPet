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
    public class VacinasController : ControllerBase
    {
        private readonly BuscaPetContext _context;

        public VacinasController(BuscaPetContext context)
        {
            _context = context;
        }

        // GET: api/Vacinas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vacina>>> GetVacinas()
        {
            return await _context.Vacinas.ToListAsync();
        }

        // GET: api/Vacinas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vacina>> GetVacina(int id)
        {
            var vacina = await _context.Vacinas.FindAsync(id);

            if (vacina == null)
            {
                return NotFound();
            }

            return vacina;
        }

        // PUT: api/Vacinas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVacina(int id, Vacina vacina)
        {
            if (id != vacina.VacinaId)
            {
                return BadRequest();
            }

            _context.Entry(vacina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VacinaExists(id))
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

        // POST: api/Vacinas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vacina>> PostVacina(Vacina vacina)
        {
            _context.Vacinas.Add(vacina);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVacina", new { id = vacina.VacinaId }, vacina);
        }

        // DELETE: api/Vacinas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVacina(int id)
        {
            var vacina = await _context.Vacinas.FindAsync(id);
            if (vacina == null)
            {
                return NotFound();
            }

            _context.Vacinas.Remove(vacina);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VacinaExists(int id)
        {
            return _context.Vacinas.Any(e => e.VacinaId == id);
        }
    }
}
