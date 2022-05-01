using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeAPI_Project.Models;

namespace PracticeAPI_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ABCHealthCareContext _context;

        public ProductsController(ABCHealthCareContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        [Route("GetAllMedicine")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllMedicine(bool IsAdminUser)
        {
            if (IsAdminUser)
            {
                return await _context.Products.ToListAsync();
            }
            return this.BadRequest(new { error = "invalid_grant", error_description = "Invalid Credentials" });
        }

        // GET: api/Products/5
        [HttpGet]
        [Route("GetMedicineById")]
        public async Task<ActionResult<Product>> GetMedicineById(int id, bool IsAdminUser)
        {
            if (IsAdminUser)
            {
                var product = await _context.Products.FindAsync(id);

                if (product == null)
                {
                    return NotFound();
                }

                return product;
            }
            return this.BadRequest(new { error = "invalid_grant", error_description = "Invalid Credentials" });
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("UpdateMedicine")]
        public async Task<IActionResult> UpdateMedicine(int id, Product product, bool IsAdminUser)
        {
            
            if ((id != product.Id)||(IsAdminUser == false))
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("AddMedicine")]
        public async Task<ActionResult<Product>> AddMedicine(Product product, bool IsAdminUser)
        {
            if (IsAdminUser)
            {
                _context.Products.Add(product);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (ProductExists(product.Id))
                    {
                        return Conflict();
                    }
                    else
                    {
                        throw;
                    }
                }

                return CreatedAtAction("GetProduct", new { id = product.Id }, product);
            }
            return this.BadRequest(new { error = "invalid_grant", error_description = "Invalid Credentials" });
        }

        //// DELETE: api/Products/5
        //[HttpDelete]
        //[Route("DeleteMedicineById")]
        //public async Task<IActionResult> DeleteMedicineById(int id, bool IsAdminUser)
        //{
        //    if (IsAdminUser)
        //    {
        //        var product = await _context.Products.FindAsync(id);
        //        if (product == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.Products.Remove(product);
        //        await _context.SaveChangesAsync();

        //        return NoContent();
        //    }

        //    return this.BadRequest(new { error = "invalid_grant", error_description = "Invalid Credentials" });
        //}

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }



    }
}
