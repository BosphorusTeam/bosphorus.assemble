using System;
using Bosphorus.Common.Core.Application;
using Bosphorus.Container.Castle.Facade;
using Bosphorus.Container.Castle.Registration.Installer;
using Castle.Core.Internal;
using Environment = Bosphorus.Common.Core.Application.Environment;

namespace Bosphorus.BootStapper.Kernel
{
    public abstract class AbstractApplication : IApplication, IApplicationListener
    {
        private readonly IoC ioc;
        private readonly Host host;
        public event EventHandler<ApplicationStartEventArgs> AfterStarted;
        public event EventHandler<EventArgs> AfterFinished;

        protected AbstractApplication(Host host, IAssemblyProvider assemblyProvider)
        {
            this.host = host;
            this.ioc = new IoC(assemblyProvider);
            this.AfterStarted = delegate {};
            this.AfterFinished = delegate {};
        }

        public IoC IoC => ioc;

        public void Start(Environment environment, Perspective perspective)
        {
            ioc.Install(new Common.Installer(environment, perspective, host));
            ioc.Install(new Kernel.Installer(this));
            ioc.Install<IBootStrapInstaller>();
            ioc.Install<IInfrastructureInstaller>();

            ApplicationStartEventArgs eventArgs = new ApplicationStartEventArgs(environment, perspective, host);
            AfterStarted(this, eventArgs);
        }

        public void Stop()
        {
            AfterFinished(this, new EventArgs());
        }

    }
}