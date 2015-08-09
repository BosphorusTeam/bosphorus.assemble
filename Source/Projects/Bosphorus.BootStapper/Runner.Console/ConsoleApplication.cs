using Bosphorus.BootStapper.Common;
using Bosphorus.BootStapper.Program;
using Bosphorus.BootStapper.Runner.Common;

namespace Bosphorus.BootStapper.Runner.Console
{
    internal class ConsoleApplication: AbstractApplication
    {
        public ConsoleApplication() 
            : base(Host.Console, new WorkingDirectoryAssemblyProvider())
        {
        }
    }
}
