using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeAPI_Project.Models
{
    public class UserValidation
    {
        public int UserId { get; set; }
        public bool? IsValidUser { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
