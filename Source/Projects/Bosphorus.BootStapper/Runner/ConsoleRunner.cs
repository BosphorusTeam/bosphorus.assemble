using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Bosphorus.BootStapper.Common;
using Bosphorus.BootStapper.Program;
using Bosphorus.Container.Castle.Discovery;
using Castle.Core.Internal;
using Environment = Bosphorus.BootStapper.Common.Environment;

namespace Bosphorus.BootStapper.Runner
{
    public class ConsoleRunner
    {
        private static readonly Runner runner;
        private static readonly IAssemblyProvider assemblyProvider;

        static ConsoleRunner()
        {
            IAssemblyProvider workingDirectoryAssemblyProvider = new WorkingDirectoryAssemblyProvider();
            //IAssemblyProvider artifactAssemblyProvider = new DirectoryAssemblyProvider(@"c:\Artifact");
            //assemblyProvider = new CompositeAssemblyProvider(workingDirectoryAssemblyProvider, artifactAssemblyProvider);
            assemblyProvider = workingDirectoryAssemblyProvider;
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomainOnAssemblyResolve;

            runner = new Runner(assemblyProvider);
        }

        private static Assembly CurrentDomainOnAssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (args.RequestingAssembly != null)
            {
                return args.RequestingAssembly;
            }

            IEnumerable<Assembly> assemblies = assemblyProvider != null ? assemblyProvider.GetAssemblies() : AppDomain.CurrentDomain.GetAssemblies();
            List<Assembly> assemblyList = assemblies.ToList();

            Assembly exactMatchAssembly = assemblyList.FirstOrDefault(assembly => assembly.GetName().FullName == args.Name);
            if (exactMatchAssembly != null)
            {
                return exactMatchAssembly;
            }

            string[] strings = args.Name.Split(',');
            Assembly bindedAssembly = assemblyList.FirstOrDefault(assembly => assembly.GetName().Name == strings[0]);
            if (bindedAssembly != null)
            {
                return bindedAssembly;
            }

            return null;
        }

        public static void Run<TProgram>(Environment environment, Perspective perspective, params string[] args) 
            where TProgram : class, IProgram
        {
            runner.Run<TProgram>(environment, perspective, Host.Console, args);
        }
    }
}
