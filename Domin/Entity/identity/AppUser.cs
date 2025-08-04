using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity.identity
{
    public class AppUser : IdentityUser<int>
    {
        [MinLength(14)]
        [MaxLength(14)]
        public string SSN { get; set; } = null!;
        public string Region { get; set; } = null!;
        public string City { get; set; } = null!;
        public int BuildingNumber { get; set; }
        public string Address { get; set; } = null!;
        public string FName { get; set; }=null!;
        public string LName { get; set; } = null!;

    }
}
