using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Govimithuro.Models;
using Microsoft.AspNetCore.Authorization;

namespace Govimithuro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientQueryController : ControllerBase
    {
        private readonly GovimithuroDbContext _context;

        public ClientQueryController(GovimithuroDbContext context)
        {
            _context = context;
        }


        // GET: api/clientquery
        //[Authorize(Roles = "Administrator")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientQuery>>> GetClientQueryTable()
        {
            return await _context.ClientQueryTable.ToListAsync();
        }

        // GET: api/Admin/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientQuery>> GetClientQuery(int id)
        {
            var query = await _context.ClientQueryTable.FindAsync(id);

            if (query == null)
            {
                return NotFound();
            }

            return query;
        }

        // PUT: api/Admin/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientQuery(int id, ClientQuery query)
        {
            if (id != query.QueryId)
            {
                return BadRequest();
            }

            _context.Entry(query).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientQueryExists(id))
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

        // POST: api/Admin
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ClientQuery>> PostClientQuery(ClientQuery query)
        {
            _context.ClientQueryTable.Add(query);
            await _context.SaveChangesAsync();
            var newuser = (CreatedAtAction("GetClientQuery", new { id = query.QueryId }, query));

           if ( newuser != null)
            {
                return Ok("succeeded");
            }
            return BadRequest();
        }

        // DELETE: api/ClientQuery/3
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClientQuery>> DeleteClientQuery(int id)
        {
            var query = await _context.ClientQueryTable.FindAsync(id);
            if (query == null)
            {
                return NotFound();
            }

            _context.ClientQueryTable.Remove(query);
            await _context.SaveChangesAsync();

            return query; ;
        }

        private bool ClientQueryExists(int id)
        {
            return _context.ClientQueryTable.Any(e => e.QueryId == id);
        }
    }
}
