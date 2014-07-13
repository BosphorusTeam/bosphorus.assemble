using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Bosphorus.BootStapper.Common;
using Bosphorus.BootStapper.Program;
using Bosphorus.Container.Castle.Facade;
using Castle.Core.Internal;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Environment = Bosphorus.BootStapper.Common.Environment;

namespace Bosphorus.BootStapper.Runner
{
    public class Runner<TAssemblyProvider>
        where TAssemblyProvider : IAssemblyProvider
    {
        protected static readonly WindsorContainer container;
        private static readonly IAssemblyProvider assemblyProvider;

        static Runner()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomainOnAssemblyResolve;
            container = IoC<TAssemblyProvider>.container;
            assemblyProvider = container.Resolve<IAssemblyProvider>();
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
            container.Register(
                Component
                    .For<IProgram>()
                    .ImplementedBy<TProgram>(),

                Component
                    .For<Environment>()
                    .Instance(environment),

                Component
                    .For<Perspective>()
                    .Instance(perspective)
            );

            IProgram program = container.Resolve<IProgram>();
            program.Run(args);
        }

        public static void Run<TProgram>(Environment environment, params string[] args)
            where TProgram : class, IProgram
        {
            Run<TProgram>(environment, Perspective.Null, args);
        }


        public static void Run<TProgram>(params string[] args)
            where TProgram : class, IProgram
        {
            Run<TProgram>(Environment.Null, args);
        }
    }
}
