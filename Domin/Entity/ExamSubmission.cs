using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class ExamSubmission : BaseEntity
    {
        public DateTime SubmittedAt { get; set; }
        public string Feedback { get; set; } = null!;
        public int MarksObtained { get; set; }
        public ICollection<Answer> Answer { get; set; } = null!;
        public int ExId { get; set; }
        [ForeignKey("ExId")]
        public Exam exam { get; set; }
        public int studentId { get; set; }
        [ForeignKey("studentId")]
        public Students student { get; set; }
    }
}
