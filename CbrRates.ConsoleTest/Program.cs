using System;
using CbrRates.CbrIntegration;
using CbrRates.DataContract;

namespace CbrRates.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new CbrService();
            var result = service.GetRateDynamics(new GetRateDynamicsRequest
            {
                CurrencyId = "R01235",
                StartDate = new DateTime(2016, 11, 1),
                EndDate = new DateTime(2016, 11, 23)
            });
        }
    }
}
