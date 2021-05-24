using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProviderService.Models;

namespace ProviderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly ProviderDbContext _context;

        public ProviderController(ProviderDbContext context)
        {
            _context = context;
        }

        // GET: api/Provider
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProviderModel>>> GetProviderModel()
        {
            return await _context.ProviderModel.ToListAsync();
        }

        // GET: api/Provider/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProviderModel>> GetProviderModel(Guid id)
        {
            var providerModel = await _context.ProviderModel.FindAsync(id);

            if (providerModel == null)
            {
                return NotFound();
            }

            return providerModel;
        }

        // PUT: api/Provider/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProviderModel(Guid id, ProviderModel providerModel)
        {
            if (id != providerModel.ProviderId)
            {
                return BadRequest();
            }

            _context.Entry(providerModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProviderModelExists(id))
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

        // POST: api/Provider
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProviderModel>> PostProviderModel(ProviderModel providerModel)
        {
            _context.ProviderModel.Add(providerModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProviderModel", new { id = providerModel.ProviderId }, providerModel);
        }

        // DELETE: api/Provider/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProviderModel(Guid id)
        {
            var providerModel = await _context.ProviderModel.FindAsync(id);
            if (providerModel == null)
            {
                return NotFound();
            }

            _context.ProviderModel.Remove(providerModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProviderModelExists(Guid id)
        {
            return _context.ProviderModel.Any(e => e.ProviderId == id);
        }
    }
}
