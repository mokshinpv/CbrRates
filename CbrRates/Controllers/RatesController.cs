using System;
using System.Collections.Generic;
using System.Web.Http;
using CbrRates.BusinessLogic;
using CbrRates.DataContract;
using CbrRates.Framework.BusinessLogic;

namespace CbrRates.Controllers
{
    public class RatesController : ApiController
    {
        private readonly IBusinessHandlerFactory _handlerFactory;

        public RatesController(IBusinessHandlerFactory handlerFactory)
        {
            if (handlerFactory == null) throw new ArgumentNullException(nameof(handlerFactory));
            _handlerFactory = handlerFactory;
        }

        public IEnumerable<Currency> GetSupportedCurrencies()
        {
            return _handlerFactory.Get<GetSupportedCurrenciesHandler>().Process(h => h.Handle());
        }

        public GetRateDynamicsResponse GetRatesDynamics(string currencyId)
        {
            //TODO hardcode
            return _handlerFactory.Get<GetRatesDynamicsHandler>().Process(h => h.Handle(new GetRateDynamicsRequest
            {
                StartDate = new DateTime(2016, 8, 11),
                EndDate = DateTime.Today,
                CurrencyId = currencyId
            }));
        }
    }
}