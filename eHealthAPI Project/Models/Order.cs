using System;
using System.Collections.Generic;

#nullable disable

namespace PracticeAPI_Project.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime? PlacedOn { get; set; }
        public string Email { get; set; }
        public int TotalAmount { get; set; }

        public virtual User User { get; set; }
    }
}
