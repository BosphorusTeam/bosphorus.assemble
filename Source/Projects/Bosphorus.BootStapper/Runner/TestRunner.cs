using Bosphorus.BootStapper.Common;
using Bosphorus.BootStapper.Program;
using Bosphorus.BootStapper.Runner.Common;
using Bosphorus.Container.Castle.Discovery;
using Castle.Core.Internal;

namespace Bosphorus.BootStapper.Runner
{
    public class TestRunner
    {
        private static readonly Runner runner;

        static TestRunner()
        {
            IAssemblyProvider assemblyProvider = new WorkingDirectoryAssemblyProvider();
            runner = new Runner(assemblyProvider);
        }

        public static void Run<TProgram>(Environment environment, Perspective perspective, params string[] args)
            where TProgram : class, IProgram
        {
            runner.Run<TProgram>(environment, perspective, Host.Test, args);
        }
    }
}
