using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Govimithuro.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Govimithuro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductChecksController : ControllerBase
    {
        private readonly GovimithuroDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductChecksController(GovimithuroDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: api/ProductChecks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCheck>>> GetProductCheckTable()
        {
            return await _context.ProductCheckTable
                .Select(x => new ProductCheck()
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    Email = x.Email,
                    ReorderLevel = x.ReorderLevel,
                    Quantity = x.Quantity,
                    AvailableQuantity = x.AvailableQuantity,
                    Addresse = x.Addresse,
                    CategoryName = x.CategoryName,
                    ProductDescription = x.ProductDescription,
                    UnitPrice = x.UnitPrice,
                    UnitWeight = x.UnitWeight,
                    ImageName = x.ImageName,
                    ImageSrc = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.ImageName)
                })
                .ToListAsync();
        }

        // GET: api/ProductChecks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCheck>> GetProductCheck(int id)
        {
            var productCheck = await _context.ProductCheckTable.FindAsync(id);

            if (productCheck == null)
            {
                return NotFound();
            }

            return productCheck;
        }

        // PUT: api/ProductChecks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductCheck(int id, ProductCheck productCheck)
        {
            if (id != productCheck.ProductId)
            {
                return BadRequest();
            }

            if (productCheck.ImageFile != null)
            {
                DeleteImage(productCheck.ImageName);
                productCheck.ImageName = await SaveImage(productCheck.ImageFile);
            }
            _context.Entry(productCheck).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductCheckExists(id))
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

        // POST: api/ProductChecks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductCheck>> PostProductCheck([FromForm] ProductCheck productCheck)
        {
            productCheck.ImageName = await SaveImage(productCheck.ImageFile);
            _context.ProductCheckTable.Add(productCheck);
            await _context.SaveChangesAsync();

            return StatusCode(201);
        }


        // DELETE: api/ProductChecks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductCheck>> DeleteProductCheck(int id)
        {
            var productCheck = await _context.ProductCheckTable.FindAsync(id);
            if (productCheck == null)
            {
                return NotFound();
            }

            
            _context.ProductCheckTable.Remove(productCheck);
            await _context.SaveChangesAsync();

            return productCheck;
        }

        private bool ProductCheckExists(int id)
        {
            return _context.ProductCheckTable.Any(e => e.ProductId == id);
        }
        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }

        [NonAction]
        public void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }
    }
}