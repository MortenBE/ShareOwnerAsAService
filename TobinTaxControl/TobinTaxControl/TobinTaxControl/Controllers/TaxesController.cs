using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TobinTaxControl.Data;
using TobinTaxControl.Models;

namespace TobinTaxControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxesController : ControllerBase
    {
        private readonly TobinTaxDbContext _context;

        public TaxesController(TobinTaxDbContext context)
        {
            _context = context;
        }

        // GET: api/Taxes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tax>>> GetTax()
        {
            return await _context.Tax.ToListAsync();
        }

        // GET: api/Taxes/SpecificTrader
        [HttpGet]
        [Route("/SpecificTrader/{traderId}")]
        public async Task<ActionResult<IEnumerable<Tax>>> GetTaxesForSpecificTrader(int traderId)
        {
            return await _context.Tax.Where(t => t.TraderId == traderId).ToListAsync();
        }

        // GET: api/Taxes/SpecificShare
        [HttpGet]
        [Route("/SpecificShare/{shareId}")]
        public async Task<ActionResult<IEnumerable<Tax>>> GetTaxesForSpecificShare(int shareId)
        {
            return await _context.Tax.Where(t => t.ShareId == shareId).ToListAsync();
        }

        // GET: api/Taxes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tax>> GetTax(int id)
        {
            var tax = await _context.Tax.FindAsync(id);

            if (tax == null)
            {
                return NotFound();
            }

            return tax;
        }

        // PUT: api/Taxes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTax(int id, Tax tax)
        {
            if (id != tax.Id)
            {
                return BadRequest();
            }

            _context.Entry(tax).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaxExists(id))
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

        // POST: api/Taxes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tax>> PostTax(Tax tax)
        {
            _context.Tax.Add(tax);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTax", new { id = tax.Id }, tax);
        }

        // DELETE: api/Taxes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTax(int id)
        {
            var tax = await _context.Tax.FindAsync(id);
            if (tax == null)
            {
                return NotFound();
            }

            _context.Tax.Remove(tax);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaxExists(int id)
        {
            return _context.Tax.Any(e => e.Id == id);
        }
    }
}
