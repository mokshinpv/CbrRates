using System;
using System.Linq;
using CbrRates.Framework.Common;
using Ninject;
using Ninject.Parameters;

namespace CbrRates.Bootstrap
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;
        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
        }

        public void Release(object instance)
        {
            _kernel.Release(instance);
        }

        public TValue Get<TValue>(string name = null) where TValue : class
        {
            return _kernel.Get<TValue>(name);
        }

        public TValue Get<TValue>(Framework.Common.ConstructorArgument[] arguments, string name = null) where TValue : class
        {
            IParameter[] args = arguments.Select(a => new Ninject.Parameters.ConstructorArgument(a.Name, a.Value)).ToArray();
            return _kernel.Get<TValue>(name, args);
        }

        public object Get(Type type, string name = null)
        {
            return _kernel.Get(type, name);
        }

        public void Dispose()
        {
            _kernel.Dispose();
        }
    }
}
