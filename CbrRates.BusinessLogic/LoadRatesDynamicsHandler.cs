using System;
using CbrRates.DataAccess.Models;
using CbrRates.DataAccess.Repository;
using CbrRates.DataContract;
using CbrRates.Framework.BusinessLogic;

namespace CbrRates.BusinessLogic
{
    public class LoadRatesDynamicsHandler : BusinessHandlerBase
    {
        private readonly ICbrService _cbrService;

        public LoadRatesDynamicsHandler(ICbrService cbrService)
        {
            if (cbrService == null) throw new ArgumentNullException(nameof(cbrService));
            _cbrService = cbrService;
        }

        public void Handle(DateTime dateFrom)
        {
            //TODO utc
            var dateTo = DateTime.Today;
            var rateRecordRepository = GetRepository<IRateRecordRepository>();
            var currencies = GetProcessor<GetSupportedCurrenciesHandler>().Process(h => h.Handle());

            foreach (var currency in currencies)
            {
                var rates = _cbrService.GetRateDynamics(new GetRateDynamicsRequest
                {
                    CurrencyId = currency.Id,
                    StartDate = dateFrom,
                    EndDate = dateTo                    
                });

                foreach (var rate in rates.Records)
                {
                    rateRecordRepository.Insert(new RateRecord
                    {
                        CurrencyId = rates.CurrencyId,
                        Nominal = rate.Nominal,
                        Value = rate.Value,
                        //TODO utc?
                        Date = rate.Date
                    });
                }
            }
            
            CommitTransaction();
        }
    }
}
