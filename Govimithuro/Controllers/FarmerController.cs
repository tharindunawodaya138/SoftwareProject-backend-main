using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Govimithuro.Models;

namespace Govimithuro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmerController : ControllerBase
    {
        private readonly GovimithuroDbContext _context;

        public FarmerController(GovimithuroDbContext context)
        {
            _context = context;
        }

        // GET: api/Farmer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Farmer>>> GetFarmerTable()
        {
            return await _context.FarmerTable.ToListAsync();
        }

        // GET: api/Farmer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Farmer>> GetFarmer(int id)
        {
            var farmer = await _context.FarmerTable.FindAsync(id);

            if (farmer == null)
            {
                return NotFound();
            }

            return farmer;
        }

        // PUT: api/Farmer/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFarmer(int id, Farmer farmer)
        {
            if (id != farmer.FarmerID)
            {
                return BadRequest();
            }

            _context.Entry(farmer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FarmerExists(id))
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

        // POST: api/Farmer
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Farmer>> PostFarmer(Farmer farmer)
        {
            _context.FarmerTable.Add(farmer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFarmer", new { id = farmer.FarmerID }, farmer);
        }

        // DELETE: api/Farmer/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Farmer>> DeleteFarmer(int id)
        {
            var farmer = await _context.FarmerTable.FindAsync(id);
            if (farmer == null)
            {
                return NotFound();
            }

            _context.FarmerTable.Remove(farmer);
            await _context.SaveChangesAsync();

            return farmer;
        }

        private bool FarmerExists(int id)
        {
            return _context.FarmerTable.Any(e => e.FarmerID == id);
        }
    }
}
