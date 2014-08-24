using Bosphorus.BootStapper.Common;
using Bosphorus.BootStapper.Program;
using Bosphorus.Container.Castle.Registration;
using Castle.Core.Internal;

namespace Bosphorus.BootStapper.Runner
{
    public class ConsoleRunner
    {
        private static readonly Runner runner;

        static ConsoleRunner()
        {
            IAssemblyProvider assemblyProvider = new WorkingDirectoryAssemblyProvider();
            runner = new Runner(assemblyProvider);
        }

        public static void Run<TProgram>(Environment environment, Perspective perspective, params string[] args) 
            where TProgram : class, IProgram
        {
            runner.Run<TProgram>(environment, perspective, Host.Console, args);
        }
    }
}
