using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class Question:BaseEntity
    {
        public string Text { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Options { get; set; } = null!;
        public int Marks { get; set; }
        public string CorrectAnswer { get; set; } = null!;
        public int Order { get; set; }

        public int ExId { get; set; }
        [ForeignKey("ExId")]
        public Exam Exam  { get; set; }
    }
}
