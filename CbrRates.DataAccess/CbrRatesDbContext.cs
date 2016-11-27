using System.Data.Entity;
using CbrRates.DataAccess.Models;

namespace CbrRates.DataAccess
{
    public class CbrRatesDbContext : DbContext
    {
        public CbrRatesDbContext(string configuration)
			: base(configuration)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RateRecord>().ToTable(nameof(RateRecord));
            modelBuilder.Entity<RateRecord>().HasKey(r => r.Id);
            modelBuilder.Entity<RateRecord>().Property(r => r.CurrencyId).IsRequired().IsFixedLength().HasMaxLength(6);

            base.OnModelCreating(modelBuilder);
        }
    }
}
