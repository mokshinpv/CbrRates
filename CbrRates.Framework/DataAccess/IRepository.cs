namespace CbrRates.Framework.DataAccess
{
    public interface IRepository
    {
        void SetUnitOfWork(IUnitOfWork unitOfWork);
    }
}
