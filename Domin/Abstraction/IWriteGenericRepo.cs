using Domin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Abstraction
{
    public interface IWriteGenericRepo<T> where T : BaseEntity
    {
        Task AddAsync(T entity);
        void UpdateAsync(T entity);
        void DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
