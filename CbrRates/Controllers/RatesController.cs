using System;
using System.Collections.Generic;
using System.Web.Http;
using CbrRates.BusinessLogic;
using CbrRates.DataContract;

namespace CbrRates.Controllers
{
    public class RatesController : ApiController
    {
        public IEnumerable<Currency> GetSupportedCurrencies()
        {
            return new GetSupportedCurrenciesHandler().Handle();
        }

        public GetRateDynamicsResponse GetRatesDynamics(string currencyId)
        {
            //TODO hardcode
            return new GetRatesDynamicsHandler().Handle(new GetRateDynamicsRequest
            {
                StartDate = new DateTime(2016, 8, 11),
                EndDate = DateTime.Today,
                CurrencyId = currencyId
            });
        }
    }
}