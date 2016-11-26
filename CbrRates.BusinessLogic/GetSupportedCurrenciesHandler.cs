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
                CountryName = "США",
                Code = "USD",
                //TODO
                Nominal = 1
            },
            new Currency
            {
                Id =  "R01820",
                CountryName = "Япония",
                Code = "JPY",
                Nominal = 100
            },
            new Currency
            {
                Id =  "R01375",
                CountryName = "Китай",
                Code = "CNY",
                Nominal = 10
            }
        };

        public List<Currency> Handle()
        {
            return new List<Currency>(Currencies);
        }
    }
}
