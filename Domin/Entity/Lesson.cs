using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class Lesson : BaseEntity
    {
        public string Description { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string URL { get; set; } = null!;
        public int Duration { get; set; }
        public int Order { get; set; }
        public string ContentUrl { get; set; }
        public int CrsId { get; set; }
        [ForeignKey("CrsId")]
        public Course course { get; set; }
        public decimal Price { get; set; }
        public ICollection<Progress> Progresses { get; set; } = new List<Progress>();
        public ICollection<LessonPurchase> LessonPurchases { get; set; } = new List<LessonPurchase>();

    }
}
