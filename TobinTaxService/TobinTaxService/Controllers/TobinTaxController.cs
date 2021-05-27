using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TobinTaxService.Models;

namespace TobinTaxService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TobinTaxController : ControllerBase
    {
        private readonly TobinTaxDbContext _context;       

        public TobinTaxController(TobinTaxDbContext context)
        {
            _context = context;
        }

        // GET: api/TobinTax
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TobinTaxModel>>> GetTobinTaxModel()
        {
            return await _context.TobinTaxModel.ToListAsync();
        }

        // GET: api/TobinTax/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TobinTaxModel>> GetTobinTaxModel(Guid id)
        {
            var tobinTaxModel = await _context.TobinTaxModel.FindAsync(id);

            if (tobinTaxModel == null)
            {
                return NotFound();
            }

            return tobinTaxModel;
        }

        // PUT: api/TobinTax/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTobinTaxModel(Guid id, TobinTaxModel tobinTaxModel)
        {
            if (id != tobinTaxModel.TaxId)
            {
                return BadRequest();
            }

            _context.Entry(tobinTaxModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TobinTaxModelExists(id))
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

        // POST: api/TobinTax
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TobinTaxModel>> PostTobinTaxModel(TobinTaxModel tobinTaxModel)
        {
            _context.TobinTaxModel.Add(tobinTaxModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTobinTaxModel", new { id = tobinTaxModel.TaxId }, tobinTaxModel);
        }

        // DELETE: api/TobinTax/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTobinTaxModel(Guid id)
        {
            var tobinTaxModel = await _context.TobinTaxModel.FindAsync(id);
            if (tobinTaxModel == null)
            {
                return NotFound();
            }

            _context.TobinTaxModel.Remove(tobinTaxModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TobinTaxModelExists(Guid id)
        {
            return _context.TobinTaxModel.Any(e => e.TaxId == id);
        }
    }
}
