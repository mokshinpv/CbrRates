using CbrRates.CbrIntegration;
using CbrRates.DataAccess;
using CbrRates.DataAccess.Repository;
using CbrRates.DataContract;
using CbrRates.Framework.BusinessLogic;
using CbrRates.Framework.Common;
using CbrRates.Framework.DataAccess;
using Ninject;
using Ninject.Modules;

namespace CbrRates.Bootstrap
{
    public class CbrRatesDefaultModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IDependencyResolver>().To<NinjectDependencyResolver>();

            Kernel.Bind<UnitOfWorkFactory>()
                .ToMethod(context => new CbrRatesUnitOfWorkFactory(context.Kernel.Get<IDependencyResolver>(), "CbrRatesDbConnection")).InSingletonScope();

            ((CbrRatesUnitOfWorkFactory)Kernel.Get<UnitOfWorkFactory>()).InitDataBase();
            
            Kernel.Bind<IBusinessHandlerFactory>().To<BusinessHandlerFactory>();
            Kernel.Bind<ICbrService>().To<CbrService>();

            Kernel.Bind<IRateRecordRepository>().To<RateRecordRepository>();
        }
    }
}
