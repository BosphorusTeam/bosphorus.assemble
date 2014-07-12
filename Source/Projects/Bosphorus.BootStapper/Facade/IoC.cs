using System;
using System.Collections.Generic;
using System.Reflection;
using Castle.Core.Internal;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace Bosphorus.BootStapper.Facade
{
    public abstract class IoC<TAssemblyProvider>
        where TAssemblyProvider : IAssemblyProvider
    {
        protected internal static readonly WindsorContainer container;
        private static readonly InstallerFactory installerFactory;

        static IoC()
        {
            container = new WindsorContainer();
            installerFactory = new InstallerFactory();

            container.Register(
                Classes
                    .FromAssemblyInThisApplication()
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

        public static TService Resolve<TService>()
        {
            TService service = container.Resolve<TService>();
            return service;
        }

        public static object Resolve(Type serviceType)
        {
            object service = container.Resolve(serviceType);
            return service;
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
