using Domin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Abstraction
{
    public interface IReadUnitOfWork : IDisposable
    {

        IReadGenericRepo<T> GetReadGenericRepo<T>() where T : BaseEntity;

    }
}
