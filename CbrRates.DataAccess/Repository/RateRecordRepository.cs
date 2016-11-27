using CbrRates.DataAccess.Models;
using CbrRates.Framework.DataAccess;

namespace CbrRates.DataAccess.Repository
{
    public class RateRecordRepository : EntityFrameworkRepositoryBase<RateRecord, long>, IRateRecordRepository
    {
    }
}
