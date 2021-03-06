using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShareService.Models;

namespace ShareService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShareController : ControllerBase
    {
        private readonly ShareDbContext _context;

        public ShareController(ShareDbContext context)
        {
            _context = context;
        }

        // GET: api/Share
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShareServiceModel>>> GetShareServiceModel()
        {
            return await _context.ShareServiceModel.ToListAsync();
        }

        // GET: api/Share/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShareServiceModel>> GetShareServiceModel(Guid id)
        {
            var shareServiceModel = await _context.ShareServiceModel.FindAsync(id);

            if (shareServiceModel == null)
            {
                return NotFound();
            }

            return shareServiceModel;
        }
        
        [HttpPut]
        public async Task<IActionResult> ChangeShareOwner(ShareServiceModel shareServiceModel)
        {
            using (_context)
            {
                var share = await _context.ShareServiceModel.FindAsync(shareServiceModel.ShareId);

                if (share == null)
                {
                    return NotFound();
                }

                share.TraderId = shareServiceModel.TraderId;

                await _context.SaveChangesAsync();
            }
            return NoContent();
        }

        // POST: api/Share
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShareServiceModel>> PostShareServiceModel(ShareServiceModel shareServiceModel)
        {
            _context.ShareServiceModel.Add(shareServiceModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShareServiceModel", new { id = shareServiceModel.ShareId }, shareServiceModel);
        }

        // DELETE: api/Share/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShareServiceModel(Guid id)
        {
            var shareServiceModel = await _context.ShareServiceModel.FindAsync(id);
            if (shareServiceModel == null)
            {
                return NotFound();
            }

            _context.ShareServiceModel.Remove(shareServiceModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShareServiceModelExists(Guid id)
        {
            return _context.ShareServiceModel.Any(e => e.ShareId == id);
        }
    }
}
