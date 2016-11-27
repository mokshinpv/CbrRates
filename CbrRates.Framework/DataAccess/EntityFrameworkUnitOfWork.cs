using System.Data.Entity;
using System.Transactions;
using CbrRates.Framework.Common;

namespace CbrRates.Framework.DataAccess
{
    public class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        private readonly IDependencyResolver _dependencyResolver;
        private readonly TransactionOptions _transactionOptions;
        private TransactionScope _transactionScope;

        public EntityFrameworkUnitOfWork(IDependencyResolver dependencyResolver, DbContext context, IsolationLevel level)
        {
            _dependencyResolver = dependencyResolver;
            _transactionOptions = new TransactionOptions { IsolationLevel = level };
            DbContext = context;
        }

        public DbContext DbContext { get; }

        void IUnitOfWork.Commit()
        {
            DbContext.SaveChanges();
            _transactionScope?.Complete();
        }

        public void BeginTransaction()
        {
            _transactionScope = new TransactionScope(TransactionScopeOption.RequiresNew, _transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
        }

        public T GetRepository<T>() where T : class, IRepository
        {
            var repo = _dependencyResolver.Get<T>();
            repo.SetUnitOfWork(this);
            return repo;
        }

        public void Dispose()
        {
            DbContext.Dispose();
            _transactionScope?.Dispose();
        }
    }
}
