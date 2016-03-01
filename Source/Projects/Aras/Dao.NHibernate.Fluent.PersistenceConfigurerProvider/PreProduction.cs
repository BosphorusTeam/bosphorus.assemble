using Bosphorus.Dao.NHibernate.Extension.Driver.OracleManaged;
using Bosphorus.Dao.NHibernate.Fluent.PersistenceConfigurerProvider;
using FluentNHibernate.Cfg.Db;

namespace Aras.Common.Customization.Bosphorus.Dao.NHibernate.Fluent.PersistenceConfigurerProvider
{
    internal class PreProduction : AbstractPersistenceConfigurerProvider
    {
        protected override IPersistenceConfigurer GetPersistenceProvider()
        {
            const string dataSource = @"
                  (DESCRIPTION=
                    (LOAD_BALANCE=yes)
                    (ADDRESS_LIST=
                      (ADDRESS=
                        (PROTOCOL=TCP)
                        (HOST=172.51.211.112)
                        (PORT=1521)
                      )
                      (ADDRESS=
                        (PROTOCOL=TCP)
                        (HOST=172.51.211.113)
                        (PORT=1521)
                      )
                    )
                    (CONNECT_DATA=
                      (SERVER=dedicated)
                      (SERVICE_NAME=HOROZAIX)
                    )
                  )
            ";

            string connectionString = string.Format("DATA SOURCE={0};PERSIST SECURITY INFO=True;USER ID={1};Password={2};enlist=dynamic", dataSource, "ESASLIVE", "10live02esas09");

            OracleDataClientConfiguration persistenceConfigurer = OracleDataClientConfiguration
                .Oracle10
                .Managed()
                .ConnectionString(connectionString);

            return persistenceConfigurer;
        }
    }
}
