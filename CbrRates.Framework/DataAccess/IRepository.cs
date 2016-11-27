using System;
using System.Linq;

namespace CbrRates.Framework.DataAccess
{
    public interface IRepository
    {
        void SetUnitOfWork(IUnitOfWork unitOfWork);
    }

    public interface IRepository<TEntity, TKey> : IRepository
        where TEntity : class, IEntityKey<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        void Insert(TEntity obj);
        void Delete(TEntity obj);
        void Update(TEntity obj);
        TEntity Find(TKey key);
        IQueryable<TEntity> Query();
        TEntity[] SelectAll();
    }
}
