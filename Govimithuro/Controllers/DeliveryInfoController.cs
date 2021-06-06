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
    public class DeliveryInfoController : ControllerBase
    {
        private readonly GovimithuroDbContext _context;

        public DeliveryInfoController(GovimithuroDbContext context)
        {
            _context = context;
        }


        //============================================================================================================
        // GET: api/DeliveryInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryInfo>>> GetDeliveryInfoTable()
        {
            return await _context.DeliveryInfoTable.ToListAsync();
        }


        //============================================================================================================
        // GET: api/DeliveryInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryInfo>> GetDeliveryInfo(int id)
        {
            var order = await _context.DeliveryInfoTable.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }


        //============================================================================================================
        // PUT: api/DeliveryInfo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeliveryInfo(int id, DeliveryInfo order)
        {
            if (id != order.DeliveryId)
            {
                return BadRequest();
            }



            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryInfoExists(id))
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



        //============================================================================================================
        // POST: api/DeliveryInfo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DeliveryInfo>> PostDeliveryInfo(DeliveryInfo order)
        {
            string FEmail = order.FarmerEmail;
            string CEmail = order.CustomerEmail;
            var FarmerUser =  _context.UserTable.FirstOrDefault(e => e.Email == order.FarmerEmail);
            var CustomerUser =  _context.UserTable.FirstOrDefault(e => e.Email == order.CustomerEmail);
            var duplicateDeliver = _context.DeliveryInfoTable.FirstOrDefault(e => e.OrderId == order.OrderId);

            if(duplicateDeliver != null)
            {
                return StatusCode(409);
            }

            if (FarmerUser == null)
            {
                return NotFound();
            }
            if (CustomerUser == null)
            {
                return NotFound();
            }
           
          
            DeliveryInfo k = new DeliveryInfo
            {
                FarmerName = FarmerUser.FirstName,
                FarmerEmail = order.FarmerEmail,
                FarmerPhone = FarmerUser.Phone,
                FarmerAddress = FarmerUser.Address,
                CustomerName = CustomerUser.FirstName,
                CustomerEmail = order.CustomerEmail,
                CustomerPhone = CustomerUser.Phone,
                CustomerAddress = CustomerUser.Address,

                OrderId = order.OrderId,
                ProductName = order.ProductName,
                BoughtDate = order.BoughtDate,              
                Quantity = order.Quantity,
                Accepted = "yes"
            };
               
            _context.DeliveryInfoTable.Add(k);
            await _context.SaveChangesAsync();

            return StatusCode(200);
        }


        //============================================================================================================
        // DELETE: api/DeliveryInfo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeliveryInfo>> DeleteDeliveryInfo(int id)
        {
            var order = await _context.DeliveryInfoTable.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.DeliveryInfoTable.Remove(order);
            await _context.SaveChangesAsync();

            return order;
        }

        private bool DeliveryInfoExists(int id)
        {
            return _context.DeliveryInfoTable.Any(e => e.DeliveryId == id);
        }
    }
}
