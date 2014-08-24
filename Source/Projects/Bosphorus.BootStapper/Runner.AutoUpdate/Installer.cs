using System.Collections.Generic;
using System.IO;
using Bosphorus.Container.Castle.Registration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.BootStapper.Runner.AutoUpdate
{
    public class Installer: AbstractWindsorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                Component
                    .For<IFileCopier>()
                    .ImplementedBy<DefaultFileCopier>(),

                Component
                    .For<IFileCopier>()
                    .ImplementedBy<DebugDecorator>()
                    .IsDefault(),

                Component
                    .For<IEqualityComparer<FileInfo>>()
                    .ImplementedBy<FileComparer>(),

                allLoadedTypes
                    .BasedOn<IFileSynhronizer>()
                    .WithService
                    .FromInterface()
            );
        }
    }
}
