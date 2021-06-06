using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Govimithuro.Models;
using Microsoft.AspNetCore.Authorization;

namespace Govimithuro.Controllers
{
    //Authorized for Administrator only

    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly GovimithuroDbContext _context;

        public UserController(GovimithuroDbContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUserTable()
        {
            return await _context.UserTable.ToListAsync();
        }




        //// GET: api/User/email
        //[HttpGet("{email}")]
        //public async Task<ActionResult<User>> GetUser(int id)
        //{
        //    var user = await _context.UserTable.FindAsync(id);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return user;
        //}



        // DELETE: api/User/email


        //Authorized for Administrator only

       
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(string id)
        {
            var user = await _context.UserTable.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.UserTable.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(string email)
        {
            return _context.UserTable.Any(e => e.Email == email);
        }
    }
}
