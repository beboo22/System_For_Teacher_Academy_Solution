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
    internal class ReadGenricRepo<T> : IReadGenericRepo<T> where T : BaseEntity
    {
        ReadSystemDbContext _context;

        public ReadGenricRepo(ReadSystemDbContext context)
        {
            _context = context;
        }

        

        public virtual IQueryable<T> GetAll()
        {
            return  _context.Set<T>().AsQueryable();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with ID {id} not found.");
            }
            return entity;
        }

    }
}
