using System;
using Castle.Core.Internal;

namespace Bosphorus.BootStapper.Facade
{
    public class IoC<TAssemblyProvider> : AbstractIoC<TAssemblyProvider> 
        where TAssemblyProvider : IAssemblyProvider
    {
        public static TService Resolve<TService>()
        {
            TService service = container.Resolve<TService>();
            return service;
        }

        public static object Resolve(Type serviceType)
        {
            object service = container.Resolve(serviceType);
            return service;
        }
    }
}