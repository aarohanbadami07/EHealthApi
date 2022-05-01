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
    public class CartsController : ControllerBase
    {
        private readonly ABCHealthCareContext _context;

        public CartsController(ABCHealthCareContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        [Route("GetByUserID")]
        public ActionResult<Cart> GetByUserID(int id)
        {
            var cart = _context.Carts.FirstOrDefault(x => x.UserId.Equals(id));
            if (cart == null)
            {
                return NotFound();
            }

            return cart;
        }

        // POST: api/Carts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<CartItem>> Add(CartItem cartitem)
        {
            _context.CartItems.Add(cartitem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CartItemExists(cartitem.CartId)) 
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCart", new { id = cartitem.CartId }, cartitem);
        }

               // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("PlaceOrder")]
        public async Task<ActionResult<Order>> PlaceOrder(Order order)
        {
            _context.Orders.Add(order);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrderExists(order.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }
        private bool CartExists(int id)
        {
            return _context.Carts.Any(e => e.CartId == id);
        }
        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
        private bool CartItemExists(int cartId)
        {
            return _context.CartItems.Any(e => e.CartId == cartId);
        }

    }
}
