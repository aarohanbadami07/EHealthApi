using System;
using System.Collections.Generic;

#nullable disable

namespace PracticeAPI_Project.Models
{
    public partial class Product
    {
        public Product()
        {
            CartItems = new HashSet<CartItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public int Price { get; set; }
        public int? Quantity { get; set; }
        public string ImageUrl { get; set; }
        public string Uses { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
