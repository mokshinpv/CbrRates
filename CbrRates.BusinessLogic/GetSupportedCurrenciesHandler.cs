using System.Collections.Generic;
using CbrRates.DataContract;

namespace CbrRates.BusinessLogic
{
    public class GetSupportedCurrenciesHandler
    {
        private static readonly List<Currency> Currencies = new List<Currency>
        {
            new Currency
            {
                Id =  "R01235",
                CountryName = "США"
            },
            new Currency
            {
                Id =  "R01820",
                CountryName = "Япония"
            },
            new Currency
            {
                Id =  "R01375",
                CountryName = "Китай"
            }
        };

        public List<Currency> Handle()
        {
            return new List<Currency>(Currencies);
        }
    }
}
