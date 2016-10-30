using Bosphorus.Common.Api.Container;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Assemble.WireUp.Dao.NHibernate.UserType
{
    public abstract class AbstractUserType
    {
        protected static IWindsorContainer Container;

        public class Installer : IBosphorusInstaller
        {

            public void Install(IWindsorContainer container, IConfigurationStore store)
            {
                Container = container;
            }
        }

    }
}
