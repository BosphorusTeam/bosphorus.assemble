using System.Collections.Generic;
using System.Reflection;
using Castle.Core.Internal;
using Castle.MicroKernel.Registration;

namespace Bosphorus.BootStapper.Runner.Common
{
    internal class DirectoryAssemblyProvider: IAssemblyProvider
    {
        private readonly IEnumerable<Assembly> assemblies;

        public DirectoryAssemblyProvider(string directory, string mask = null)
        {
            AssemblyFilter assemblyFilter = new AssemblyFilter(directory, mask);
            assemblies = ReflectionUtil.GetAssemblies(assemblyFilter);
        }

        public IEnumerable<Assembly> GetAssemblies()
        {
            return assemblies;
        }
    }
}
