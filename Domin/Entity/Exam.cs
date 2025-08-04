using Domin.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class Exam : BaseEntity
    {
        public string Type { get; set; }=null!; 
        public string Title { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public SchoolYear SchoolYear { get; set; }
        public DateTime ClickStart { get; set; }
        public int Duration { get; set; }
        public int TotalMarks { get; set; }
       
        public int CrsId { get; set; }
        [ForeignKey("CrsId")]
        public Course Courses { get; set; }

        public List<Question> ExamQuestions { get; set; } = new List<Question>();
        public List<ExamSubmission> examSubmissions { get; set; } = new List<ExamSubmission>();




    }
}
