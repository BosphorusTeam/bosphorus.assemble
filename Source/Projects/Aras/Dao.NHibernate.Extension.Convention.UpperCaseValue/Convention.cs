using Bosphorus.Dao.NHibernate.Extension.Convention.UpperCaseString;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;

namespace Aras.Common.Customization.Bosphorus.Dao.NHibernate.Extension.Convention.UpperCaseValue
{
    public class Convention : IUserTypeConvention
    {
        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            criteria.Expect(x => x.Property.PropertyType == typeof(string));
        }

        public void Apply(IPropertyInstance instance)
        {
            instance.CustomType<UserType>();
        }
    }
}
