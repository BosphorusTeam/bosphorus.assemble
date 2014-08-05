using Bosphorus.BootStapper.Common;
using Bosphorus.BootStapper.Program;
using Bosphorus.Container.Castle.Registration;

namespace Bosphorus.BootStapper.Runner
{
    public class TestRunner : AbstractRunner<WorkingDirectoryAssemblyProvider>
    {
        public static void Run<TProgram>(Environment environment, Perspective perspective, params string[] args)
            where TProgram : class, IProgram
        {
            Run<TProgram>(environment, perspective, Host.Test, args);
        }
    }
}
