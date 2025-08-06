using Domin.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Dtos.STD
{
    public class GetStudentDto
    {
        public string SSN { get; set; } = null!;
        public string FName { get; set; } = null!;
        public string LName { get; set; } = null!;
        public string Region { get; set; } = null!;
        public string City { get; set; } = null!;
        public int BuildingNumber { get; set; }
        public string Address { get; set; } = null!;
        public string StdPhNum { get; set; }
        public GuardianType GuardianType { get; set; }
        public string GuardianPhNum { get; set; }
        public SchoolYear SchoolYear { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
