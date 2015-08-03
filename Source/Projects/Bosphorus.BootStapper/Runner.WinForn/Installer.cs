using System.Windows.Forms;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.BootStapper.Runner.WinForn
{
    internal class Installer<TForm> : IWindsorInstaller where TForm: Form
    {

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<TForm>()
            );
        }
    }
}