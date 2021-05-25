using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RequesterService.Models;

namespace RequesterService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequesterController : ControllerBase
    {
        private readonly RequesterDomain _domain;

        private readonly RequesterDbContext _context;

        public RequesterController(RequesterDbContext context, IHttpClientFactory clientFactory)
        {
            _domain = new RequesterDomain(clientFactory);
            _context = context;
        }

        // GET: api/Requester
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequesterModel>>> GetRequesterModel()
        {
            return await _context.RequesterModel.ToListAsync();
        }

        // GET: api/Requester/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RequesterModel>> GetRequesterModel(Guid id)
        {
            var requesterModel = await _context.RequesterModel.FindAsync(id);

            if (requesterModel == null)
            {
                return NotFound();
            }

            return requesterModel;
        }

        // PUT: api/Requester/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequesterModel(Guid id, RequesterModel requesterModel)
        {
            if (id != requesterModel.RequesterId)
            {
                return BadRequest();
            }

            _context.Entry(requesterModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequesterModelExists(id))
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

        // POST: api/Requester
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RequesterModel>> PostRequesterModel(RequesterModel requesterModel)
        {
            _context.RequesterModel.Add(requesterModel);
            await _context.SaveChangesAsync();

            _domain.notifyRequest(requesterModel);

            return CreatedAtAction("GetRequesterModel", new { id = requesterModel.RequesterId }, requesterModel);
        }

        // DELETE: api/Requester/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequesterModel(Guid id)
        {
            var requesterModel = await _context.RequesterModel.FindAsync(id);
            if (requesterModel == null)
            {
                return NotFound();
            }

            _context.RequesterModel.Remove(requesterModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequesterModelExists(Guid id)
        {
            return _context.RequesterModel.Any(e => e.RequesterId == id);
        }
    }
}
