using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Bosphorus.BootStapper.Common;
using Bosphorus.BootStapper.Program;
using Bosphorus.BootStapper.Runner.Common;
using Bosphorus.Container.Castle.Facade;
using Castle.Core.Internal;
using Environment = Bosphorus.BootStapper.Common.Environment;

namespace Bosphorus.BootStapper.Runner.Console
{
    public class ConsoleRunner
    {
        private readonly static IAssemblyProvider assemblyProvider;

        static ConsoleRunner()
        {
            assemblyProvider = new WorkingDirectoryAssemblyProvider();
        }

        public static void Run<TProgram>(Environment environment, Perspective perspective, params string[] args)
            where TProgram : class, IProgram
        {
            IoC ioc = new IoC(assemblyProvider);
            ioc.Install(new CommonInstaller(environment, perspective, Host.Console));
            ioc.Install(new Installer<TProgram>());

            IProgram program = ioc.Resolve<IProgram>();
            program.Run(args);
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
    }
}
