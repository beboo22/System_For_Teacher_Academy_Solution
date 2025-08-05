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
    internal class WriteGenericRepo<T> : IWriteGenericRepo<T> where T : BaseEntity
    {
        WriteSystemDbContext _context;

        public WriteGenericRepo(WriteSystemDbContext context)
        {
            _context = context;
        }

        public async virtual Task AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
            }
            await _context.Set<T>().AddAsync(entity);
        }

        public void DeleteAsync(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
            }
            else
            {
                throw new KeyNotFoundException($"Entity with ID {id} not found.");
            }
        }

        public virtual async Task<bool> ExistsAsync(int id)
        {
            var exists = await _context.Set<T>().AnyAsync(e => e.ID == id);
            return exists;
        }
        public virtual void UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
            }
            var existingEntity = _context.Set<T>().Find(entity.ID);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);//
            }
            else
            {
                throw new KeyNotFoundException($"Entity with ID {entity.ID} not found.");
            }
        }
    }
}
