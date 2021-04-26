﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DelProjekt1_Disp_Backend.Data;
using DelProjekt1_Disp_Backend.Models;

namespace DelProjekt1_Disp_Backend
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaerktoejskassesController : ControllerBase
    {
        private readonly DelProjekt1_Disp_BackendContext _context;

        public VaerktoejskassesController(DelProjekt1_Disp_BackendContext context)
        {
            _context = context;
        }

        // GET: api/Vaerktoejskasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vaerktoejskasse>>> GetVaerktoejskasse()
        {
            return await _context.Vaerktoejskasse.ToListAsync();
        }

        // GET: api/Vaerktoejskasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vaerktoejskasse>> GetVaerktoejskasse(int id)
        {
            var vaerktoejskasse = await _context.Vaerktoejskasse.FindAsync(id);

            if (vaerktoejskasse == null)
            {
                return NotFound();
            }

            return vaerktoejskasse;
        }

        // PUT: api/Vaerktoejskasses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVaerktoejskasse(int id, Vaerktoejskasse vaerktoejskasse)
        {
            if (id != vaerktoejskasse.VTKId)
            {
                return BadRequest();
            }

            _context.Entry(vaerktoejskasse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VaerktoejskasseExists(id))
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

        // POST: api/Vaerktoejskasses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vaerktoejskasse>> PostVaerktoejskasse(Vaerktoejskasse vaerktoejskasse)
        {
            _context.Vaerktoejskasse.Add(vaerktoejskasse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVaerktoejskasse", new { id = vaerktoejskasse.VTKId }, vaerktoejskasse);
        }

        // DELETE: api/Vaerktoejskasses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVaerktoejskasse(int id)
        {
            var vaerktoejskasse = await _context.Vaerktoejskasse.FindAsync(id);
            if (vaerktoejskasse == null)
            {
                return NotFound();
            }

            _context.Vaerktoejskasse.Remove(vaerktoejskasse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VaerktoejskasseExists(int id)
        {
            return _context.Vaerktoejskasse.Any(e => e.VTKId == id);
        }
    }
}
