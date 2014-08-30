using System.Collections.Generic;
using System.Reflection;
using Castle.Core.Internal;

namespace Bosphorus.BootStapper.Runner
{
    public class CompositeAssemblyProvider : IAssemblyProvider
    {
        private readonly IAssemblyProvider[] assemblyProviders;

        public CompositeAssemblyProvider(params IAssemblyProvider[] assemblyProviders)
        {
            this.assemblyProviders = assemblyProviders;
        }

        public IEnumerable<Assembly> GetAssemblies()
        {
            List<Assembly> assemblies = new List<Assembly>();
            foreach (IAssemblyProvider assemblyProvider in assemblyProviders)
            {
                IEnumerable<Assembly> currentAssemblies = assemblyProvider.GetAssemblies();
                assemblies.AddRange(currentAssemblies);
            }

            return assemblies;
        }
    }
}