using Bosphorus.Common.Core.Application;
using Bosphorus.Common.Core.Context;
using Bosphorus.Common.Core.Context.Application;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.BootStapper.Kernel
{
    public class Installer: IWindsorInstaller
    {
        private readonly IContextListener<ApplicationContext> applicationContextListener;

        public Installer(IContextListener<ApplicationContext> applicationContextListener)
        {
            this.applicationContextListener = applicationContextListener;
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<IContextListener<ApplicationContext>>()
                    .Instance(applicationContextListener)
            );
        }
    }
}
