using System;
using CbrRates.Framework.DataAccess;

namespace CbrRates.DataAccess.Models
{
    public class RateRecord : IEntityKey<long>
    {
        public long Id { get; set; }

        public string CurrencyId { get; set; }

        public decimal Value { get; set; }

        public int Nominal { get; set; }

        public DateTime Date { get; set; }
    }
}
