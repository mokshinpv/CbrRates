using System;

namespace CbrRates.Framework.Common
{
    public interface IDependencyResolver
    {
        void Release(object instance);
        TValue Get<TValue>(string name = null) where TValue : class;
        TValue Get<TValue>(ConstructorArgument[] arguments, string name = null) where TValue : class;
        object Get(Type type, string name = null);
    }
}
