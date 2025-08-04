using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class Enrollment : BaseEntity
    {
        public DateTime EnrollmentDay { get; set; }
        public int CrsId { get; set; }
        [ForeignKey("CrsId")]
        public Course Course  { get; set; }
        public int StdId { get; set; }
        [ForeignKey("StdId")]
        public Students Student { get; set; }
    }
}
