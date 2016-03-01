using Bosphorus.Dao.NHibernate.Fluent.ConventionApplier;
using FluentNHibernate.Conventions;

namespace Aras.Common.Customization.Bosphorus.Dao.NHibernate.Fluent.ConventionApplier
{
    public class ConventionApplier : IConventionApplier
    {
        public void Apply(string sessionAlias, IConventionFinder conventionFinder)
        {
            conventionFinder.Add(new global::Bosphorus.Dao.NHibernate.Extension.Convention.UpperCaseColumnName.Convention());
           // conventionFinder.Add(new Extension.Convention.UpperCaseValue.Convention());
            conventionFinder.Add(new global::Bosphorus.Dao.NHibernate.Extension.Convention.UpperCaseTableName.Convention());
            conventionFinder.Add(new Extension.Convention.Timestamp.Convention());
        
        }
    }
}
