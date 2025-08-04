using Domin.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class LessonPurchase : BaseEntity
    {
        public PaymentStatus PaymentStatus { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime AccessExpireDate { get; set; }
        public int StdId { get; set; }
        [ForeignKey("StdId")]
        public Students student { get; set; }
        public int LessonId { get; set; }
        [ForeignKey("LessonId")]
        public  Lesson lesson { get; set; }
    }
}
