using Bosphorus.Common.Api.Symbol;
using Bosphorus.Common.Application;
using Castle.Facilities.Startable;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Assemble.BootStrapper
{
    public class Installer: IWindsorInstaller
    {
        private readonly ITypeProvider typeProvider;
        private readonly Environment environment;
        private readonly Perspective perspective;
        private readonly Host host;

        public Installer(ITypeProvider typeProvider, Environment environment, Perspective perspective, Host host)
        {
            this.typeProvider = typeProvider;
            this.environment = environment;
            this.perspective = perspective;
            this.host = host;
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Kernel.Resolver.AddSubResolver(new ListResolver(container.Kernel, true));
            container.Kernel.Resolver.AddSubResolver(new ArrayResolver(container.Kernel, true));
            container.AddFacility<StartableFacility>(facility => facility.DeferredTryStart());

            container.Register(
                Component
                    .For<ITypeProvider>()
                    .Instance(typeProvider),

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

            container.Register (
                Component
                    .For<IWindsorContainer>()
                    .Instance(container),

                Component
                    .For<ILazyComponentLoader>()
                    .ImplementedBy<LazyOfTComponentLoader>()
            );
        }
    }
}
