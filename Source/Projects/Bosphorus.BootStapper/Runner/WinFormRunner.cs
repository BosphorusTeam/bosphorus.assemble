using System.Windows.Forms;
using Bosphorus.BootStapper.Common;
using Bosphorus.Container.Castle.Discovery;
using Castle.Core.Internal;

namespace Bosphorus.BootStapper.Runner
{
    public class WinFormRunner
    {
        private static readonly Runner runner;

        static WinFormRunner()
        {
            IAssemblyProvider assemblyProvider = new WorkingDirectoryAssemblyProvider();
            runner = new Runner(assemblyProvider);
        }

        public static void Run<TForm>(Environment environment, Perspective perspective, params string[] args)
            where TForm: Form
        {
            runner.Run<WinFormProgram<TForm>>(environment, perspective, Host.WinForm, args);
        }
    }
}
