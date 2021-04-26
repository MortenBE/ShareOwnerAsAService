using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShareOwnerAsAService.Data;
using ShareOwnerAsAService.Models;

namespace ShareOwnerAsAService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockOwnersController : ControllerBase
    {
        private readonly StockDbContext _context;

        public StockOwnersController(StockDbContext context)
        {
            _context = context;
        }

        // GET: api/StockOwners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockOwner>>> GetStockOwner()
        {
            return await _context.StockOwner.ToListAsync();
        }

        // GET: api/StockOwners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StockOwner>> GetStockOwner(int id)
        {
            var stockOwner = await _context.StockOwner.FindAsync(id);

            if (stockOwner == null)
            {
                return NotFound();
            }

            return stockOwner;
        }

        // PUT: api/StockOwners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockOwner(int id, StockOwner stockOwner)
        {
            if (id != stockOwner.Id)
            {
                return BadRequest();
            }

            _context.Entry(stockOwner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockOwnerExists(id))
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

        // POST: api/StockOwners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StockOwner>> PostStockOwner(StockOwner stockOwner)
        {
            _context.StockOwner.Add(stockOwner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStockOwner", new { id = stockOwner.Id }, stockOwner);
        }

        // DELETE: api/StockOwners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStockOwner(int id)
        {
            var stockOwner = await _context.StockOwner.FindAsync(id);
            if (stockOwner == null)
            {
                return NotFound();
            }

            _context.StockOwner.Remove(stockOwner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StockOwnerExists(int id)
        {
            return _context.StockOwner.Any(e => e.Id == id);
        }
    }
}
