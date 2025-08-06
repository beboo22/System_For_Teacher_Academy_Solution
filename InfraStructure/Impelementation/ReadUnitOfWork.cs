using Domin.Abstraction;
using Domin.Entity;
using InfraStructure.Data;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Impelementation
{
    internal class ReadUnitOfWork : IReadUnitOfWork
    {
        ReadSystemDbContext _Rcontext;
        ConcurrentDictionary<Type, object> _repositories;

        public ReadUnitOfWork(ReadSystemDbContext rcontext)
        {
            _Rcontext = rcontext;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IReadGenericRepo<T> GetReadGenericRepo<T>() where T : BaseEntity
        =>(IReadGenericRepo<T>)_repositories.GetOrAdd(typeof(T), _ => new ReadGenricRepo<T>(_Rcontext));
    }
}
