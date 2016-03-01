using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;
using NHibernate.Type;

namespace Aras.Common.Customization.Bosphorus.Dao.NHibernate.Extension.Convention.Timestamp
{
    public class Convention : IPropertyConvention, IPropertyConventionAcceptance
    {
        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            criteria.Expect(x => x.Name == "AuditCreateDate" || x.Name == "AuditModifyDate");
        }

        public void Apply(IPropertyInstance instance)
        {
            instance.CustomType<TimestampType>();
        }
    }
}
