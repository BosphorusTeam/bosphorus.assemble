using System.Configuration;
using Bosphorus.Dao.NHibernate.Extension.Driver.OracleManaged;
using Bosphorus.Dao.NHibernate.Fluent.PersistenceConfigurerProvider;
using FluentNHibernate.Cfg.Db;

namespace Aras.Common.Customization.Bosphorus.Dao.NHibernate.Fluent.PersistenceConfigurerProvider
{
    internal class Production : AbstractPersistenceConfigurerProvider
    {
        protected override IPersistenceConfigurer GetPersistenceProvider()
        {
            string connectionString = GetConnectionString();

            OracleDataClientConfiguration persistenceConfigurer = OracleDataClientConfiguration
                .Oracle10
                .Managed()
                .ConnectionString(connectionString);

            return persistenceConfigurer;
        }

        private string GetConnectionString()
        {
            ConnectionStringSettings connectionStringSetting = ConfigurationManager.ConnectionStrings["Production"];
            if (connectionStringSetting != null)
            {
               return ConfigurationManager.ConnectionStrings["Production"].ConnectionString;
            }

            const string dataSource = @"
                                (DESCRIPTION=
                                    (LOAD_BALANCE=no)
                                    (ADDRESS_LIST=
                                      (ADDRESS=
                                        (PROTOCOL=TCP)
                                        (HOST=172.16.12.201)
                                        (PORT=1521)
                                      )
                                    )
                                    (CONNECT_DATA=
                                      (INSTANCE_NAME=HONEST1)
                                      (SERVICE_NAME=HOROZAIX)
                                    )
                                  )
                            ";

            string connectionString = string.Format("DATA SOURCE={0};PERSIST SECURITY INFO=True;USER ID={1};Password={2};enlist=dynamic", dataSource, "ESASLIVE", "10LIVE02ESAS09");

            return connectionString;
        }
    }
}
