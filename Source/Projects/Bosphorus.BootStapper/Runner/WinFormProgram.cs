using System.Windows.Forms;
using Bosphorus.BootStapper.Program;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Bosphorus.BootStapper.Runner
{
    public class WinFormProgram<TForm> : IProgram
            where TForm : Form
    {
        private readonly IWindsorContainer container;

        public WinFormProgram(IWindsorContainer container)
        {
            this.container = container;
        }

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
}
