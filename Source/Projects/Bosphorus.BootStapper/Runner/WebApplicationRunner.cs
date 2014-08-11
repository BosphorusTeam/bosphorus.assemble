using Bosphorus.BootStapper.Common;
using Bosphorus.BootStapper.Program;
using Castle.Core.Internal;

namespace Bosphorus.BootStapper.Runner
{
    public class WebApplicationRunner<TAssemblyProvider> : AbstractRunner<TAssemblyProvider> 
        where TAssemblyProvider : IAssemblyProvider
    {
        public static void Run<TProgram>(Environment environment, Perspective perspective, params string[] args)
            where TProgram : class, IProgram
        {
            Run<TProgram>(environment, perspective, Host.IIS, args);
        }
    }
}
