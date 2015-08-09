using Bosphorus.BootStapper.Common;
using Bosphorus.BootStapper.Program;
using Bosphorus.BootStapper.Runner.Common;

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
