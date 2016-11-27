namespace CbrRates.Framework.BusinessLogic
{
    public enum HandlerBehaviourType
    {
        RunsInParentTransaction = 1,
        RequiresNewTransaction = 2,
        NonTransactional = 3
    }
}
