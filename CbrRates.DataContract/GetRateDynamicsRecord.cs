using System;

namespace CbrRates.DataContract
{
    public class GetRateDynamicsRecord
    {
        public DateTime Date { get; set; }

        public int Nominal { get; set; }

        public decimal Value { get; set; }
    }
}
