using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class Course : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string SchoolYear { get; set; }
        public ICollection<Exam> exams { get; set; } = new List<Exam>();
        public ICollection<Enrollment> enrollments { get; set; } = new List<Enrollment>();
        public ICollection<Lesson> lessons { get; set; } = new List<Lesson>();
    }
}
