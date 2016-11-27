using System.Linq;
using CbrRates.DataAccess.Repository;
using CbrRates.DataContract;
using CbrRates.Framework.BusinessLogic;

namespace CbrRates.BusinessLogic
{
    public class GetRatesDynamicsHandler : BusinessHandlerBase
    {
        public GetRateDynamicsResponse Handle(GetRateDynamicsRequest request)
        {
            var rateRecordsRepository = GetRepository<IRateRecordRepository>();

            return new GetRateDynamicsResponse
            {
                CurrencyId = request.CurrencyId,
                Records = rateRecordsRepository.Query()
                    .Where(r => r.CurrencyId == request.CurrencyId && r.Date >= request.StartDate && r.Date <= request.EndDate)
                    .OrderBy(r => r.Date)
                    .Select(r => new GetRateDynamicsRecord
                    {
                        Nominal = r.Nominal,
                        Date = r.Date,
                        Value = r.Value
                    })
                    .ToList()
            };
        }
    }
}
