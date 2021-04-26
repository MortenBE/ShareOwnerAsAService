using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TraderControl.Data;
using TraderControl.Models;

namespace TraderControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradersController : ControllerBase
    {
        private readonly TraderDbContext _context;

        public TradersController(TraderDbContext context)
        {
            _context = context;
        }

        // GET: api/Traders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trader>>> GetTrader()
        {
            return await _context.Trader.ToListAsync();
        }

        // GET: api/Traders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trader>> GetTrader(int id)
        {
            var trader = await _context.Trader.FindAsync(id);

            if (trader == null)
            {
                return NotFound();
            }

            return trader;
        }

        // PUT: api/Traders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrader(int id, Trader trader)
        {
            if (id != trader.Id)
            {
                return BadRequest();
            }

            _context.Entry(trader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TraderExists(id))
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

        // POST: api/Traders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trader>> PostTrader(Trader trader)
        {
            _context.Trader.Add(trader);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrader", new { id = trader.Id }, trader);
        }

        // DELETE: api/Traders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrader(int id)
        {
            var trader = await _context.Trader.FindAsync(id);
            if (trader == null)
            {
                return NotFound();
            }

            _context.Trader.Remove(trader);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TraderExists(int id)
        {
            return _context.Trader.Any(e => e.Id == id);
        }
    }
}
