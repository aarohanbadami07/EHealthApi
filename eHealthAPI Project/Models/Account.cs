using System;
using System.Collections.Generic;

#nullable disable

namespace PracticeAPI_Project.Models
{
    public partial class Account
    {
        public int Id { get; set; }
        public int AccNumber { get; set; }
        public int? Amount { get; set; }
        public string Email { get; set; }
    }
}
