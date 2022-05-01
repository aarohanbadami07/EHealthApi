using System;
using System.Collections.Generic;

#nullable disable

namespace PracticeAPI_Project.Models
{
    public partial class CartItem
    {
        public int CartItemId { get; set; }
        public int CartId { get; set; }
        public int ProdcutId { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Product Prodcut { get; set; }
    }
}
