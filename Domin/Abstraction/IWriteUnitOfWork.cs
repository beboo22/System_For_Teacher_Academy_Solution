using Domin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Abstraction
{
    public interface IWriteUnitOfWork:IDisposable
    {
        Task BeginTransiaction();
        Task CommitAsync();
        Task RollbackAsync();
        Task SaveChangesAsync();
        IWriteGenericRepo<T> GetWriteGenericRepo<T>() where T : BaseEntity;
    }
}
