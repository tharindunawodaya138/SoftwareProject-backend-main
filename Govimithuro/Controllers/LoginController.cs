using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Govimithuro.Models;

namespace Govimithuro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly GovimithuroDbContext _context;

        //-------------------
        public readonly IConfiguration _config;
        //------------------

        public LoginController(IConfiguration config, GovimithuroDbContext context)
        {
            _context = context;
        }



        // GET: api/Login
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Login>>> GetLoginTable()
        {
            return await _context.LoginTable.ToListAsync();
        }

        // GET: api/Login/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Login>> GetLogin(int id)
        {
            var login = await _context.LoginTable.FindAsync(id);

            if (login == null)
            {
                return NotFound();
            }
            return login;
        }







    }
}
    
            
            
            
 
