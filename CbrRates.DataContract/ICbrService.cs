namespace CbrRates.DataContract
{
    public interface ICbrService
    {
        GetRateDynamicsResponse GetRateDynamics(GetRateDynamicsRequest request);
    }
}
