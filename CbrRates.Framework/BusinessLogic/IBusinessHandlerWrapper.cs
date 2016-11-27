using System;

namespace CbrRates.Framework.BusinessLogic
{
    public interface IBusinessHandlerWrapper<out THandler> where THandler : BusinessHandlerBase
    {
        TResult Process<TResult>(Func<THandler, TResult> func);

        void Process(Action<THandler> func);
    }
}
