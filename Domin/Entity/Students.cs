using Domin.Entity.identity;
using Domin.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class Students : AppUser
    {
        //public override int Id { get; set; }
        //public override int Id { get; set; }
        public string StdPhNum { get; set; }
        public GuardianType GuardianType { get; set; }
        [MinLength(11)]
        [MaxLength(11)]
        public string GuardianPhNum { get; set; }
        public SchoolYear SchoolYear { get; set; }
        public DateTime DateOfBirth { get; set; }
      
        public ICollection<Enrollment> enrollments { get; set; } = new List<Enrollment>();
        public ICollection<ExamSubmission> examSubmissions { get; set; } = new List<ExamSubmission>();
        public ICollection<Progress> Progresses { get; set; } = new List<Progress>();
        public ICollection<Message> Messages { get; set; } = new List<Message>();
        public ICollection<LessonPurchase> LessonPurchases { get; set; } = new List<LessonPurchase>();

        
    }
}
