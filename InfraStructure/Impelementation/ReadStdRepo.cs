using Domin.Abstraction;
using Domin.Entity;
using InfraStructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Impelementation
{
    internal class ReadStdRepo : ReadGenricRepo<StudentEntity>,IReadStdRepo
    {
        private readonly ReadSystemDbContext _context;
        public ReadStdRepo(ReadSystemDbContext context):base(context) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public override IQueryable<StudentEntity> GetAll()
        {
            var students = _context.students;
            return students.Select(s => new StudentEntity(s)).AsQueryable();
        }
        public override async Task<StudentEntity> GetByIdAsync(int id)
        {
            var student = await _context.students.FindAsync(id);
            if (student == null)
            {
                throw new KeyNotFoundException($"Student with ID {id} not found.");
            }
            return new StudentEntity(student);
        }

        public async Task<IEnumerable<Course>> GetEnrollmentCoursesForStudent(int studentId)
        {
            var courses = _context.enrollments
                .Where(e => e.StdId == studentId)
                .Include(e => e.Course)
                .Select(e => e.Course);

            return await courses.ToListAsync();
        }

        public async Task<IEnumerable<ExamSubmission>> GetExamSubmissionForStudent(int studentId)
        {
            var submissions = _context.examSubmissions
                .Where(es => es.studentId == studentId)
                .Include(es => es.exam)
                .Include(es => es.student);

            return await submissions.ToListAsync();
        }

        public async Task<IEnumerable<Lesson>> GetLessonPurchasesForStudent(int studentId)
        {
            var lessons = _context.lessonPurchases
                .Where(lp => lp.StdId == studentId)
                .Include(lp => lp.lesson)
                .Select(lp => lp.lesson);
            return await lessons.ToListAsync();
        }

        public async Task<IEnumerable<Progress>> GetTrakingProgressOfLessonForStudent(int studentId)
        {
            var lessons = _context.progresses
                .Where(p => p.StudentId == studentId)
                .Include(p => p.lesson);
            return await lessons.ToListAsync();
        }
    }
}
