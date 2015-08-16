using Bosphorus.BootStapper.Kernel;
using Bosphorus.BootStapper.Runner.Common;
using Bosphorus.Common.Core.Application;

namespace Bosphorus.BootStapper.Runner.WinForn
{
    internal class WinFormApplication: AbstractApplication
    {
        public WinFormApplication() 
            : base(Host.WinForm, new WorkingDirectoryAssemblyProvider())
        {
        }
    }
}
