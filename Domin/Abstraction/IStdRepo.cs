using Domin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Abstraction
{
    public interface IStdRepo : IGenericRepo<StudentEntity>
    {
        Task<IEnumerable<Lesson>> GetLessonPurchasesForStudent(int studentId);
        Task<IEnumerable<Course>> GetEnrollmentCoursesForStudent(int studentId);
        Task<IEnumerable<Progress>> GetTrakingProgressOfLessonForStudent(int studentId);
        Task<IEnumerable<ExamSubmission>> GetExamSubmissionForStudent(int studentId);

    }
}
