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

        public object GetRatesDynamics(string currencyId)
        {
            //TODO
            return new object();
        }
    }
}