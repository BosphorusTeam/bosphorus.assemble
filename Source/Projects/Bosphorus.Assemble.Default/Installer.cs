using Bosphorus.Configuration.Core.Parameter;
using Bosphorus.Configuration.Default.Parameter.AppConfig;
using Bosphorus.Container.Castle.Registration.Installer;
using Bosphorus.Dao.Core.Dao;
using Bosphorus.Dao.NHibernate.Stateful.Dao;
using Bosphorus.Logging.Console.Logger;
using Bosphorus.Logging.Core.Logger;
using Bosphorus.Serialization.Core.Serializer.Binary;
using Bosphorus.Serialization.Core.Serializer.Json;
using Bosphorus.Serialization.Core.Serializer.Xml;
using Bosphorus.Serialization.Default.Serializer.Binary;
using Bosphorus.Serialization.Default.Serializer.Json;
using Bosphorus.Serialization.Default.Serializer.Xml;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Assemble.Default
{
    public class Installer: AbstractWindsorInstaller, IInfrastructureInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                Component
                    .For(typeof(ILogger<>))
                    .ImplementedBy(typeof(ConsoleLogger<>)),

                Component
                    .For(typeof(IXmlSerializer<>))
                    .ImplementedBy(typeof(DefaultXmlSerializer<>)),

                Component
                    .For(typeof(IJsonSerializer<>))
                    .ImplementedBy(typeof(DefaultJsonSerializer<>)),

                Component
                    .For(typeof(IBinarySerializer<>))
                    .ImplementedBy(typeof(DefaultBinarySerializer<>)),

                Component
                    .For(typeof(IDao<>))
                    .ImplementedBy(typeof(NHibernateStatefulDao<>)),

                Component
                    .For<IParameterProvider>()
                    .ImplementedBy<AppConfigParameterProvider>()
            );
        }
    }
}
