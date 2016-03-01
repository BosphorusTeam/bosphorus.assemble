using Bosphorus.Assemble.BootStrapper.Runner.Demo.ExecutableItem;
using Bosphorus.Assemble.BootStrapper.Runner.Demo.ResultTransformer;
using Bosphorus.Common.Api.Container;
using Bosphorus.Common.Api.Symbol;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Assemble.BootStrapper.Runner.Demo
{
    public class Installer: IBosphorusInstaller
    {
        private readonly ITypeProvider typeProvider;

        public Installer(ITypeProvider typeProvider)
        {
            this.typeProvider = typeProvider;
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<IResultTransformer>()
                    .ImplementedBy<ChainedResultTransformer>()
                    .IsDefault(),

                Classes.From(typeProvider.LoadedTypes)
                    .BasedOn<IExecutionItemList>()
                    .WithService
                    .FromInterface()
            );
        }
    }
}
