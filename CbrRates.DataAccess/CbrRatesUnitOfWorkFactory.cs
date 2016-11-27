using System;
using System.Data.Entity;
using System.Transactions;
using CbrRates.Framework.BusinessLogic;
using CbrRates.Framework.Common;
using CbrRates.Framework.DataAccess;

namespace CbrRates.DataAccess
{
    public class CbrRatesUnitOfWorkFactory : UnitOfWorkFactory
    {
        private readonly IDependencyResolver _resolver;

        public CbrRatesUnitOfWorkFactory(IDependencyResolver resolver, string configuration) : base(configuration)
        {
            if (resolver == null) throw new ArgumentNullException(nameof(resolver));
            _resolver = resolver;
        }

        public override IUnitOfWork CreateUnitOfWork(IsolationLevel level, HandlerBehaviourType behaviourType)
        {
            if (behaviourType == HandlerBehaviourType.NonTransactional)
            {
                return new NullObjectUnitOfWork();
            }

            return new EntityFrameworkUnitOfWork(_resolver, GetDbContext(), level);
        }

        private DbContext GetDbContext()
        {
            return new CbrRatesDbContext(Configuration);
        }
    }
}
