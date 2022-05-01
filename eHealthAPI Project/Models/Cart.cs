using System;
using System.Collections.Generic;

#nullable disable

namespace PracticeAPI_Project.Models
{
    public partial class Cart
    {
        public Cart()
        {
            CartItems = new HashSet<CartItem>();
        }

        public int CartId { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
