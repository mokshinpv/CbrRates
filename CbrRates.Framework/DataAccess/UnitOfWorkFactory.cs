using System.Transactions;
using CbrRates.Framework.BusinessLogic;

namespace CbrRates.Framework.DataAccess
{
    public abstract class UnitOfWorkFactory
    {
        protected readonly string Configuration;

        protected UnitOfWorkFactory(string configuration)
        {
            Configuration = configuration;
        }

        public abstract IUnitOfWork CreateUnitOfWork(IsolationLevel level, HandlerBehaviourType behaviourType);
    }
}
