using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class Progress : BaseEntity
    {
        public string Status { get; set; }
        public DateTime LastWatched { get; set; }
        public int LessonId { get; set; }
        [ForeignKey("LessonId")]
        public Lesson lesson { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Students Student { get; set; }
    }
}
