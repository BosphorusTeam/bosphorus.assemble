using System;
using Bosphorus.BootStapper.Common;
using Bosphorus.Container.Castle.Facade;
using Bosphorus.Container.Castle.Registration;
using Bosphorus.Container.Castle.Registration.Installer;
using Castle.Core.Internal;
using Environment = Bosphorus.BootStapper.Common.Environment;

namespace Bosphorus.BootStapper.Program
{
    public abstract class AbstractApplication : IApplication, IApplicationListener
    {
        private readonly IoC ioc;
        private readonly Host host;
        public event EventHandler<EventArgs> AfterStarted;
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
            ioc.Install(new Installer(environment, perspective, host));
            ioc.Install(new Kernel.Installer(this));
            ioc.Install<IBootStrapInstaller>();
            ioc.Install<IInfrastructureInstaller>();
            AfterStarted(this, new EventArgs());
        }

        public void Stop()
        {
            AfterFinished(this, new EventArgs());
        }

    }
}