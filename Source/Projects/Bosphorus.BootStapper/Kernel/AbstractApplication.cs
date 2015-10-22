using System;
using Bosphorus.Common.Core.Application;
using Bosphorus.Common.Core.Context;
using Bosphorus.Common.Core.Context.Application;
using Bosphorus.Container.Castle.Facade;
using Bosphorus.Container.Castle.Registration.Installer;
using Castle.Core.Internal;
using Environment = Bosphorus.Common.Core.Application.Environment;

namespace Bosphorus.BootStapper.Kernel
{
    public abstract class AbstractApplication : IApplication, IContextListener<ApplicationContext>
    {
        private readonly IoC ioc;
        private readonly Host host;
        public event EventHandler<ContextEventArgs<ApplicationContext>> ContextStarted;
        public event EventHandler<ContextEventArgs<ApplicationContext>> ContextFinished;

        protected AbstractApplication(Host host, IAssemblyProvider assemblyProvider)
        {
            this.host = host;
            this.ioc = new IoC(assemblyProvider);
            this.ContextStarted = delegate {};
            this.ContextFinished = delegate {};
        }

        public IoC IoC => ioc;

        public void Start(Environment environment, Perspective perspective)
        {
            ioc.Install(new Common.Installer(environment, perspective, host));
            ioc.Install(new Kernel.Installer(this));
            ioc.Install<IBootStrapInstaller>();
            ioc.Install<IInfrastructureInstaller>();

            ApplicationContext applicationContext = new ApplicationContext(environment, perspective, host);
            ContextEventArgs<ApplicationContext> contextEventArgs = new ContextEventArgs<ApplicationContext>(applicationContext);
            ContextStarted(this, contextEventArgs);
        }

        public void Stop()
        {
            ApplicationContext applicationContext = null;
            ContextEventArgs<ApplicationContext> contextEventArgs = new ContextEventArgs<ApplicationContext>(applicationContext);
            ContextFinished(this, contextEventArgs);
        }

    }
}