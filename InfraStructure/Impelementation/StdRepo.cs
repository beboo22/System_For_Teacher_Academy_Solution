using Domin.Abstraction;
using Domin.Entity;
using InfraStructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Impelementation
{
    internal class StdRepo : ReadGenricRepo<StudentEntity>, IStdRepo
    {
        SystemDbContext _context;

        public StdRepo(SystemDbContext context):base(context)
        {
            _context = context;
        }


        public async override Task AddAsync(StudentEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
            }
            await _context.students.AddAsync(entity.Students);
        }
        public override void UpdateAsync(StudentEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
            }
            var student = _context.students.Find(entity.Students.Id);
            if (student != null)
            {
                _context.students.Update(entity.Students);
            }
            else
            {
                throw new KeyNotFoundException($"Student with ID {entity.Students.Id} not found.");
            }
        }

        public async override Task<bool> ExistsAsync(int id)
        {
            var exists = await _context.students.AnyAsync(s => s.Id == id);
            return exists;
        }

        public override IQueryable<StudentEntity> GetAllAsync()
        {
            var students = _context.students.ToList();
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
