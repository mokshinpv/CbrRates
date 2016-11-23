using System;
using System.Globalization;
using System.Linq;
using CbrRates.CbrIntegration.Model;
using CbrRates.DataContract;

namespace CbrRates.CbrIntegration.Extensions
{
    internal static class MappingExtensions
    {
        public static GetRateDynamicsResponse ToDto(this GetRatesDynamicsXmlResponse response)
        {
            return new GetRateDynamicsResponse
            {
                CurrencyId = response.CurrencyId,
                Records = response.Records.Select(r => new GetRateDynamicsRecord
                {
                    Date = DateTime.ParseExact(r.Date, Constants.ResponseDateFormat, CultureInfo.InvariantCulture),
                    Value = decimal.Parse(r.Value),
                    Nominal = r.Nominal
                }).ToList()
            };
        }
    }
}
