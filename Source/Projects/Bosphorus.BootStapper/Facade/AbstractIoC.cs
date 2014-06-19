using System.Collections.Generic;
using System.Reflection;
using Castle.Core.Internal;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace Bosphorus.BootStapper.Facade
{
    public abstract class AbstractIoC<TAssemblyProvider>
        where TAssemblyProvider : IAssemblyProvider
    {
        protected static readonly WindsorContainer container;
        private static readonly InstallerFactory installerFactory;

        static AbstractIoC()
        {
            container = new WindsorContainer();
            installerFactory = new InstallerFactory();

            container.Register(
                Classes
                    .FromThisAssembly()
                    .BasedOn<IAssemblyProvider>()
                    .WithService
                    .Self(),

                Component
                    .For<IAssemblyProvider>()
                    .ImplementedBy<TAssemblyProvider>()
                    //TODO: Think better way of name  conflict, service registration below is named with component name, and conflicts with above registration
                    .Named(typeof(IAssemblyProvider).FullName)
            );

            IAssemblyProvider assemblyProvider = container.Resolve<IAssemblyProvider>();
            IWindsorInstaller installer = BuildInstallers(assemblyProvider);
            container.Install (
                installer
            );
        }

        private static IWindsorInstaller BuildInstallers(IAssemblyProvider assemblyProvider)
        {
            IEnumerable<Assembly> assemblies = assemblyProvider.GetAssemblies();

            CompositeInstaller installer = new CompositeInstaller();
            foreach (Assembly assembly in assemblies)
            {
                IWindsorInstaller windsorInstaller = FromAssembly.Instance(assembly, installerFactory);
                installer.Add(windsorInstaller);
            }

            return installer;
        }
    }
}
