using Bosphorus.BootStapper.Common;
using Bosphorus.Dao.NHibernate.Fluent.PersistenceConfigurerProvider;
using FluentNHibernate.Cfg.Db;

namespace Aras.Common.Customization.Bosphorus.Dao.NHibernate.Fluent.PersistenceConfigurerProvider
{
    internal class Local : AbstractPersistenceConfigurerProvider
    {
        private readonly Perspective perspective;

        public Local(Perspective perspective)
        {
            this.perspective = perspective;
        }

        protected override IPersistenceConfigurer GetPersistenceProvider()
        {
            SQLiteConfiguration persistenceConfigurer = SQLiteConfiguration
                .Standard
                .UsingFile("Local.db3");

            if (perspective == Perspective.Debug)
            {
                persistenceConfigurer = persistenceConfigurer.ShowSql().FormatSql();
            }

            return persistenceConfigurer;
        }
    }
}
