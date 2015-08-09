using Bosphorus.BootStapper.Common;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.BootStapper.Program
{
    public class Installer: IWindsorInstaller
    {
        private readonly Environment environment;
        private readonly Perspective perspective;
        private readonly Host host;

        public Installer(Environment environment, Perspective perspective, Host host)
        {
            this.environment = environment;
            this.perspective = perspective;
            this.host = host;
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<Environment>()
                    .Instance(environment),

                Component
                    .For<Perspective>()
                    .Instance(perspective),

                Component
                    .For<Host>()
                    .Instance(host)
            );
        }
    }
}
