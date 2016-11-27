using System;
using CbrRates.DataContract;
using CbrRates.Framework.BusinessLogic;

namespace CbrRates.BusinessLogic
{
    public class GetRatesDynamicsHandler : BusinessHandlerBase
    {
        private readonly ICbrService _cbrService;

        public GetRatesDynamicsHandler(ICbrService cbrService)
        {
            if (cbrService == null) throw new ArgumentNullException(nameof(cbrService));
            _cbrService = cbrService;
        }

        public GetRateDynamicsResponse Handle(GetRateDynamicsRequest request)
        {
            return _cbrService.GetRateDynamics(request);
        }
    }
}
