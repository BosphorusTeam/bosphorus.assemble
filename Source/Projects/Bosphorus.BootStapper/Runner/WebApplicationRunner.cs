using Bosphorus.BootStapper.Common;
using Bosphorus.BootStapper.Program;
using Castle.Core.Internal;

namespace Bosphorus.BootStapper.Runner
{
    public class WebApplicationRunner<TAssemblyProvider>
        where TAssemblyProvider : IAssemblyProvider, new()
    {
        private static readonly Runner runner;

        static WebApplicationRunner()
        {
            IAssemblyProvider assemblyProvider = new TAssemblyProvider();
            runner = new Runner(assemblyProvider);
        }

        public static void Run<TProgram>(Environment environment, Perspective perspective, params string[] args)
            where TProgram : class, IProgram
        {
            runner.Run<TProgram>(environment, perspective, Host.IIS, args);
        }
    }
}
