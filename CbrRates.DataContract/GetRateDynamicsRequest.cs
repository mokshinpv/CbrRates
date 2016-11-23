using System;

namespace CbrRates.DataContract
{
    public class GetRateDynamicsRequest
    {
        public string CurrencyId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
