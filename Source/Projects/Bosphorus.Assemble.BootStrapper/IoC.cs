using System;
using Bosphorus.Common.Api.Container;
using Bosphorus.Common.Api.Symbol;
using Bosphorus.Common.Application;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Environment = Bosphorus.Common.Application.Environment;

namespace Bosphorus.Assemble.BootStrapper
{
    public class IoC
    {
        private readonly ITypeProvider typeProvider;
        private readonly WindsorContainer container;
        public static WindsorContainer staticContainer;

        public IoC(ITypeProvider typeProvider, Environment environment, Perspective perspective, Host host, Type[] installerTypes)
        {
            this.typeProvider = typeProvider;
            this.container = new WindsorContainer();

            Installer installer = new Installer(typeProvider, environment, perspective, host);
            Install(installer);
            Install<IBosphorusInstaller>();
            Install(installerTypes);

            staticContainer = container;
        }

        public void Register(params IRegistration[] registrations)
        {
            container.Register(registrations);
        }

        public void Install<TInstaller>()
            where TInstaller : IWindsorInstaller
        {
            container.Register(
                Classes
                    .From(typeProvider.LoadedTypes)
                    .BasedOn<TInstaller>()
                    .WithService
                    .FromInterface()
            );

            TInstaller[] installers = container.ResolveAll<TInstaller>();
            Install(installers);
        }

        public void Install(params Type[] installerTypes)
        {
            foreach (Type installerType in installerTypes)
            {
                Install(installerType);
            }
        }

        public void Install(Type installerType)
        {
            container.Register(
                Classes
                    .From(typeProvider.LoadedTypes)
                    .BasedOn(installerType)
                    .WithService
                    .FromInterface()
            );

            var installers = container.ResolveAll(installerType);
            foreach (IWindsorInstaller installer in installers)
            {
                container.Install(installer);
            }
        }

        public void Install<TInstaller>(params TInstaller[] installers) 
            where TInstaller : IWindsorInstaller
        {
            foreach (var installer in installers)
            {
                container.Install(installer);
            }
        }

        public TService Resolve<TService>()
        {
            TService service = container.Resolve<TService>();
            return service;
        }

        public object Resolve(Type serviceType)
        {
            object service = container.Resolve(serviceType);
            return service;
        }
    }
}