using Domin.Entity;
using Domin.Entity.identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Abstraction
{
    public interface IReadGenericRepo<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAllAsync();
        
    }
}
