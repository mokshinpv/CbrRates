using CbrRates.CbrIntegration;
using CbrRates.DataContract;

namespace CbrRates.BusinessLogic
{
    public class GetRatesDynamicsHandler
    {
        public GetRateDynamicsResponse Handle(GetRateDynamicsRequest request)
        {
            //TODO
            return new CbrService().GetRateDynamics(request);
        }
    }
}
