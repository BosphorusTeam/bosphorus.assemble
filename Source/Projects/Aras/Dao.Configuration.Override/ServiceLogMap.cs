using Bosphorus.Aspect.Log;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using NHibernate.Type;

namespace Aras.Common.Customization.Bosphorus.Dao.Configuration.Override
{
    public class ServiceLogMap : IAutoMappingOverride<ServiceLog>
    {
        public void Override(AutoMapping<ServiceLog> mapping)
        {
            mapping.Table("BOSPSERVICELOG");
            mapping.Map(x => x.Level).Column("LOGLEVEL");
            mapping.Map(x => x.DateTime).Column("LOGDATETIME").CustomType<TimestampType>();
        }
    }
}