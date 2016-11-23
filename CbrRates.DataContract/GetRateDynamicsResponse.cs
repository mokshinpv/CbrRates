using System.Collections.Generic;

namespace CbrRates.DataContract
{
    public class GetRateDynamicsResponse
    {
        public string CurrencyId { get; set; }

        public List<GetRateDynamicsRecord> Records { get; set; }
    }
}
