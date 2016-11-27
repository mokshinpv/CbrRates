using CbrRates.Framework.DataAccess;

namespace CbrRates.Framework.BusinessLogic
{
    public class BusinessHandlerContext
    {
        private readonly IBusinessHandlerFactory _businessHandlerFactory;
        private readonly HandlerBehaviourType _behaviourType;

        public BusinessHandlerContext(IBusinessHandlerFactory businessHandlerFactory, IUnitOfWork currentUnitOfWork, HandlerBehaviourType behaviourType)
        {
            _businessHandlerFactory = businessHandlerFactory;
            _behaviourType = behaviourType;
            CurrentUnitOfWork = currentUnitOfWork;
        }

        internal IUnitOfWork CurrentUnitOfWork { get; }

        public T GetRepository<T>() where T : class, IRepository
        {
            return CurrentUnitOfWork.GetRepository<T>();
        }

        public void CommitTransaction()
        {
            if (_behaviourType != HandlerBehaviourType.RunsInParentTransaction)
            {
                CurrentUnitOfWork.Commit();
            }
        }

        public IBusinessHandlerWrapper<THandler> GetProcessor<THandler>() where THandler : BusinessHandlerBase
        {
            return _businessHandlerFactory.Get<THandler>(this);
        }
    }
}
