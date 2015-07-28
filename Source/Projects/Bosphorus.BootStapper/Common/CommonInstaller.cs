using Bosphorus.Container.Castle.Registration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.BootStapper.Common
{
    public class CommonInstaller: IWindsorInstaller
    {
        private readonly Environment environment;
        private readonly Perspective perspective;
        private readonly Host host;

        public CommonInstaller(Environment environment, Perspective perspective, Host host)
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
