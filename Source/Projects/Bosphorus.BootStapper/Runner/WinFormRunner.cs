using System.Windows.Forms;
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

        public static void Run<TForm>(Environment environment, Perspective perspective)
            where TForm: Form
        {
            Runner<WorkingDirectoryAssemblyProvider>.Run<Program<TForm>>(environment, perspective);
        }
    }
}
