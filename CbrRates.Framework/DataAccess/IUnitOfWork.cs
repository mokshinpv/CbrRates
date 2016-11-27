using System;

namespace CbrRates.Framework.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        T GetRepository<T>() where T : class, IRepository;
        void Commit();
        void BeginTransaction();
    }
}
