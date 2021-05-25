using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TraderService.Models;

namespace TraderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraderController : ControllerBase
    {
        private readonly TraderDbContext _context;

        public TraderController(TraderDbContext context)
        {
            _context = context;
        }

        // GET: api/Trader
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TraderModel>>> GetTraderModel()
        {
            return await _context.TraderModel.ToListAsync();
        }

        // GET: api/Trader/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TraderModel>> GetTraderModel(Guid id)
        {
            var traderModel = await _context.TraderModel.FindAsync(id);

            if (traderModel == null)
            {
                return NotFound();
            }

            return traderModel;
        }

        // PUT: api/Trader/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTraderModel(Guid id, TraderModel traderModel)
        {
            if (id != traderModel.TraderId)
            {
                return BadRequest();
            }

            _context.Entry(traderModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TraderModelExists(id))
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

        // POST: api/Trader
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TraderModel>> PostTraderModel(TraderModel traderModel)
        {
            _context.TraderModel.Add(traderModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTraderModel", new { id = traderModel.TraderId }, traderModel);
        }

        // DELETE: api/Trader/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraderModel(Guid id)
        {
            var traderModel = await _context.TraderModel.FindAsync(id);
            if (traderModel == null)
            {
                return NotFound();
            }

            _context.TraderModel.Remove(traderModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TraderModelExists(Guid id)
        {
            return _context.TraderModel.Any(e => e.TraderId == id);
        }
    }
}
