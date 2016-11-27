namespace CbrRates.Framework.DataAccess
{
    public interface IEntityKey<T> where T : struct
    {
        T Id { get; set; }
    }
}
