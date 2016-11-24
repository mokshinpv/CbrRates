using System.Data.Entity;

namespace CbrRates.DataAccess
{
    internal class CbrRatesDbInitializer : DropCreateDatabaseIfModelChanges<CbrRatesDbContext>
    {
    }
}
