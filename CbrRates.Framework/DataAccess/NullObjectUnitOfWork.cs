namespace CbrRates.Framework.DataAccess
{
    public class NullObjectUnitOfWork : IUnitOfWork
    {
        public void Dispose()
        {
            
        }

        public T GetRepository<T>() where T : class, IRepository
        {
            throw new System.NotImplementedException();
        }

        public void Commit()
        {
            
        }

        public void BeginTransaction()
        {
            
        }
    }
}
