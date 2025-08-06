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
    internal class WriteStdRepo : WriteGenericRepo<StudentEntity>, IWriteStdRepo
    {
        WriteSystemDbContext _context;

        public WriteStdRepo(WriteSystemDbContext context):base(context)
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

        

      

    }
}
