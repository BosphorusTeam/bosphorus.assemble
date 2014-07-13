using System.Windows.Forms;
using Bosphorus.BootStapper.Common;
using Bosphorus.BootStapper.Program;
using Bosphorus.Container.Castle.Registration;
using Castle.MicroKernel.Registration;

namespace Bosphorus.BootStapper.Runner
{
    public class WinFormRunner : Runner<WorkingDirectoryAssemblyProvider>
    {
        private class Program<TForm> : IProgram 
            where TForm : Form
        {
            public void Run(string[] args)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                container.Register(
                    Component.For<TForm>()
                );

                TForm form = container.Resolve<TForm>();
                Application.Run(form);
            }
        }

        public new static void Run<TForm>(Environment environment, Perspective perspective, params string[] args)
            where TForm: Form
        {
            Runner<WorkingDirectoryAssemblyProvider>.Run<Program<TForm>>(environment, perspective, args);
        }
    }
}
