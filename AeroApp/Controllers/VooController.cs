using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AeroApp.Model;
using AeroApp.DTO;

namespace AeroApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VooController : ControllerBase
    {
        private readonly AeroContext _context;

        public VooController(AeroContext context)
        {
            _context = context;
        }

        // GET: api/Voo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voo>>> GetVoos()
        {
            return await _context.Voos.ToListAsync();
        }

        // GET: api/Voo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Voo>> GetVoo(int id)
        {
            var voo = await _context.Voos.FindAsync(id);

            if (voo == null)
            {
                return NotFound();
            }

            return voo;
        }

        // PUT: api/Voo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoo(int id, Voo voo)
        {
            if (id != voo.Id)
            {
                return BadRequest();
            }

            _context.Entry(voo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VooExists(id))
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

        // POST: api/Voo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Voo>> PostVoo(VooDTO vooDTO)
        {
            var voomodel = new Voo();
            voomodel.Id = vooDTO.Id;
            voomodel.LocalOrigemId = vooDTO.IdOrigem;
            voomodel.LocalDestinoId = vooDTO.IdDestino;
            voomodel.DataIda = vooDTO.DataIda;
            voomodel.DataVolta = vooDTO.DataVolta;

            _context.Voos.Add(voomodel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVoo", new { id = voomodel.Id }, voomodel);
        }

        // DELETE: api/Voo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Voo>> DeleteVoo(int id)
        {
            var voo = await _context.Voos.FindAsync(id);
            if (voo == null)
            {
                return NotFound();
            }

            _context.Voos.Remove(voo);
            await _context.SaveChangesAsync();

            return voo;
        }

        private bool VooExists(int id)
        {
            return _context.Voos.Any(e => e.Id == id);
        }
    }
}
