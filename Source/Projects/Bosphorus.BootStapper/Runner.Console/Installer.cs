using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.BootStapper.Runner.Console
{
    internal class Installer<TProgram> : IWindsorInstaller where TProgram : IProgram
    {

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<IProgram>()
                    .ImplementedBy<TProgram>()
                );
        }
    }
}