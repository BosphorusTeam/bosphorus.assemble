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
    }
}