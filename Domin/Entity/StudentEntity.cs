using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class StudentEntity:BaseEntity
    {
        Students _student;

        public StudentEntity(Students student)
        {
            _student = student;
        }
        public override int ID { get => _student.Id; set => _student.Id = value; }
        public Students Students => _student;
    }
}
