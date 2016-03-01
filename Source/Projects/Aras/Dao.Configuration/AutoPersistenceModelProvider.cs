using System;
using Aras.Common.Customization.Bosphorus.Dao.Configuration.Override;
using Bosphorus.Aspect.Log;
using Bosphorus.Dao.NHibernate.Fluent.AutoPersistenceModelProvider;
using Castle.Core.Internal;
using FluentNHibernate.Automapping;

namespace Aras.Common.Customization.Bosphorus.Dao.Configuration
{
    public class AutoPersistenceModelProvider : AbstractAutoPersistenceModelProvider
    {
        protected override AutoPersistenceModel GetAutoPersistenceModel(IAssemblyProvider assemblyProvider)
        {
            return
                AutoMap
                    .Assemblies(typeof(ServiceLog).Assembly)
                    .Where(IsApplicable)
                    .UseOverridesFromAssemblyOf<AutoPersistenceModelProvider>();
        }

        private bool IsApplicable(Type type)
        {
            if (type == typeof (ServiceLog))
                return true;

            return false;
        }


    }
}
