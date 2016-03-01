using System;
using Aras.Common.Customization.Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Container.Castle.Registration;
using Bosphorus.Container.Castle.Registration.Installer;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Aras.Common.Customization.Bosphorus
{
    public class Installer: AbstractWindsorInstaller, IInfrastructureInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                Component.For<KernelListener>()
                .OnCreate((kernel, item) => item.Start())
                /*
                //Logger
                Component
                    .For(typeof (IDatabaseLoggerConfiguration<>))
                    .ImplementedBy(typeof (DatabaseLoggerConfiguration<>)),

                Component
                    .For(typeof (ILogger<>))
                    .ImplementedBy(typeof (DatabaseLogger<>)),

                // Aspect
                Component
                    .For<IContextProvider<InvocationContext>>()
                    .Forward<InvocationContextProvider>()
                    .ImplementedBy<InvocationContextProvider>()
                    .LifeStyle
                    .PerThread
                */
            );
        }
    }
}
