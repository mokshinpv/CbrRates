namespace CbrRates.DataAccess.Models
{
    public class RateRecord
    {
        public long Id { get; set; }

        public string CurrencyId { get; set; }

        public decimal Value { get; set; }

        public int Nominal { get; set; }
    }
}
