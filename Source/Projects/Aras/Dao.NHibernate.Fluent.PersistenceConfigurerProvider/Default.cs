using System.Collections.Generic;
using Bosphorus.BootStapper.Common;
using Bosphorus.Dao.NHibernate.Fluent.PersistenceConfigurerProvider;
using FluentNHibernate.Cfg.Db;

namespace Aras.Common.Customization.Bosphorus.Dao.NHibernate.Fluent.PersistenceConfigurerProvider
{
    public class PersistenceConfigurerProvider: IPersistenceConfigurerProvider
    {
        private readonly Environment environment;
        private readonly IDictionary<Environment, IPersistenceConfigurerProvider> environmentPersistenceConfigurerMap;

        public PersistenceConfigurerProvider(Environment environment, Perspective perspective)
        {
            this.environment = environment;
            environmentPersistenceConfigurerMap = new Dictionary<Environment, IPersistenceConfigurerProvider>();
            environmentPersistenceConfigurerMap.Add(Environment.Local, new Local(perspective));
            environmentPersistenceConfigurerMap.Add(Environment.Development, new Development(perspective));
            environmentPersistenceConfigurerMap.Add(Environment.Test, new Test(perspective));
            environmentPersistenceConfigurerMap.Add(Environment.PreProduction, new PreProduction());
            environmentPersistenceConfigurerMap.Add(Environment.Production, new Production());
        }

        public IPersistenceConfigurer GetPersistenceProvider(string sessionAlias)
        {
            IPersistenceConfigurerProvider persistenceConfigurerProvider = environmentPersistenceConfigurerMap[environment];
            IPersistenceConfigurer persistenceConfigurer = persistenceConfigurerProvider.GetPersistenceProvider(sessionAlias);
            return persistenceConfigurer;
        }
    }
}
