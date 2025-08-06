using Domin.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Dtos.STD
{
    public class CreateStudentDto
    {
        public string StdPhNum { get; set; }
        public GuardianType GuardianType { get; set; }
        [MinLength(11)]
        [MaxLength(11)]
        public string GuardianPhNum { get; set; }
        public SchoolYear SchoolYear { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
