using System;
using System.Transactions;
using CbrRates.Framework.DataAccess;

namespace CbrRates.Framework.BusinessLogic
{
    public class BusinessHandlerWrapper<THandler> : IBusinessHandlerWrapper<THandler> where THandler : BusinessHandlerBase
    {
        private readonly THandler _handler;
        private readonly BusinessHandlerContext _parentContext;
        private readonly IBusinessHandlerFactory _requestHandlerProcessor;
        private readonly UnitOfWorkFactory _unitOfWorkFactory;
        private HandlerBehaviourType _handlerBehaviourType;
        private IsolationLevel _isolationLevel;

        internal BusinessHandlerWrapper(THandler handler, UnitOfWorkFactory unitOfWorkFactory, IBusinessHandlerFactory requestHandlerProcessor)
        {
            _handler = handler;
            _unitOfWorkFactory = unitOfWorkFactory;
            _requestHandlerProcessor = requestHandlerProcessor;

            _handlerBehaviourType = HandlerBehaviourType.RequiresNewTransaction;
            _isolationLevel = IsolationLevel.ReadCommitted;
        }

        internal BusinessHandlerWrapper(THandler handler, UnitOfWorkFactory unitOfWorkFactory, IBusinessHandlerFactory requestHandlerProcessor, BusinessHandlerContext parentContext)
        {
            _handler = handler;
            _unitOfWorkFactory = unitOfWorkFactory;
            _requestHandlerProcessor = requestHandlerProcessor;
            _parentContext = parentContext;

            _handlerBehaviourType = HandlerBehaviourType.RunsInParentTransaction;
        }

        public TResult Process<TResult>(Func<THandler, TResult> func)
        {
            if (_handlerBehaviourType == HandlerBehaviourType.RunsInParentTransaction)
                return ProcessInternalInParentScope(func);

            return ProcessInternalNewScope(func);
        }

        public void Process(Action<THandler> func)
        {
            Process(h =>
            {
                func(h);
                return 0;
            });
        }

        private TResult ProcessInternalNewScope<TResult>(Func<THandler, TResult> func)
        {
            IUnitOfWork unitOfWork = null;
            try
            {
                unitOfWork = _unitOfWorkFactory.CreateUnitOfWork(_isolationLevel, _handlerBehaviourType);
                unitOfWork.BeginTransaction();

                _handler.InitializeContext(new BusinessHandlerContext(_requestHandlerProcessor, unitOfWork, _handlerBehaviourType));

                var result = func(_handler);
                
                return result;
            }
            finally
            {
                unitOfWork?.Dispose();
            }
        }

        private TResult ProcessInternalInParentScope<TResult>(Func<THandler, TResult> func)
        {
            _handler.InitializeContext(new BusinessHandlerContext(_requestHandlerProcessor, _parentContext.CurrentUnitOfWork,
                _handlerBehaviourType));

            var result = func(_handler);
            
            return result;
        }
    }
}
