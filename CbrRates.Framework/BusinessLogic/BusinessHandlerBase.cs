using CbrRates.Framework.DataAccess;

namespace CbrRates.Framework.BusinessLogic
{
    public class BusinessHandlerBase
    {
        private BusinessHandlerContext _context;

        internal void InitializeContext(BusinessHandlerContext context)
        {
            _context = context;
        }

        public virtual void CommitTransaction()
        {
            _context.CommitTransaction();
        }

        public IBusinessHandlerWrapper<T> GetProcessor<T>() where T : BusinessHandlerBase
        {
            return _context.GetProcessor<T>();
        }

        public T GetRepository<T>() where T : class, IRepository
        {
            return _context.GetRepository<T>();
        }
    }
}
