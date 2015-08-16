using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bosphorus.Container.Castle.Registration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.BootStapper.Kernel
{
    public class Installer: IWindsorInstaller
    {
        private readonly IApplicationListener applicationListener;

        public Installer(IApplicationListener applicationListener)
        {
            this.applicationListener = applicationListener;
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IApplicationListener>().Instance(applicationListener));
        }
    }
}
