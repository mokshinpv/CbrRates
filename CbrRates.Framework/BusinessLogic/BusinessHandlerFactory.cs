using System;
using CbrRates.Framework.Common;
using CbrRates.Framework.DataAccess;

namespace CbrRates.Framework.BusinessLogic
{
    public class BusinessHandlerFactory : IBusinessHandlerFactory
    {
        private readonly IDependencyResolver _dependencyResolver;
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        public BusinessHandlerFactory(IDependencyResolver dependencyResolver, UnitOfWorkFactory unitOfWorkFactory)
        {
            _dependencyResolver = dependencyResolver;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        #region IRequestHandlerProcessor Members

        public IBusinessHandlerWrapper<THandler> Get<THandler>(string resolutionKey = null) where THandler : BusinessHandlerBase
        {
            var handler = ResolveHandler(typeof(THandler), resolutionKey);
            return new BusinessHandlerWrapper<THandler>((THandler)handler, _unitOfWorkFactory, this);
        }

        public IBusinessHandlerWrapper<THandler> Get<THandler>(BusinessHandlerContext handlerContext, string resolutionKey = null)
            where THandler : BusinessHandlerBase
        {
            var handler = ResolveHandler(typeof(THandler), resolutionKey);
            return new BusinessHandlerWrapper<THandler>((THandler)handler, _unitOfWorkFactory, this, handlerContext);
        }

        private object ResolveHandler(Type type, string resolutionKey)
        {
            return _dependencyResolver.Get(type, resolutionKey);
        }
        #endregion
    }
}
