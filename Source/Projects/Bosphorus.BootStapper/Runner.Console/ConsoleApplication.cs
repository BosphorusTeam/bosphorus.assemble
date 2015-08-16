using Bosphorus.BootStapper.Kernel;
using Bosphorus.BootStapper.Runner.Common;
using Bosphorus.Common.Core.Application;

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
