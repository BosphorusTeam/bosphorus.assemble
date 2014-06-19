using System.Net.Mime;
using System.Windows.Forms;
using Bosphorus.Container.Castle.Facade;
using Bosphorus.Container.Castle.Registration;
using Castle.MicroKernel.Registration;

namespace Bosphorus.BootStapper.Runner
{
    public class WinFormRunner : Facade.AbstractIoC<WorkingDirectoryAssemblyProvider>
    {
        public static void Run<TForm>()
            where TForm: Form
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
}
