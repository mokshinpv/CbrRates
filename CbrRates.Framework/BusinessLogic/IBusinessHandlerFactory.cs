namespace CbrRates.Framework.BusinessLogic
{
    public interface IBusinessHandlerFactory
    {
        IBusinessHandlerWrapper<THandler> Get<THandler>(string resolutionKey = null) where THandler : BusinessHandlerBase;
        IBusinessHandlerWrapper<THandler> Get<THandler>(BusinessHandlerContext parentContext, string resolutionKey = null) where THandler : BusinessHandlerBase;
    }
}
