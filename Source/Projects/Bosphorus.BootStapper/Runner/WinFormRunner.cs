using System.Windows.Forms;
using Bosphorus.BootStapper.Common;
using Bosphorus.Container.Castle.Registration;

namespace Bosphorus.BootStapper.Runner
{
    public class WinFormRunner : AbstractRunner<WorkingDirectoryAssemblyProvider>
    {
        public static void Run<TForm>(Environment environment, Perspective perspective, params string[] args)
            where TForm: Form
        {
            Run<WinFormProgram<TForm>>(environment, perspective, Host.WinForm, args);
        }
    }
}
