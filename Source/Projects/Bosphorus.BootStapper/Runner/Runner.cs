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
    public class Runner
    {
        private readonly IWindsorContainer container;
        private readonly IAssemblyProvider assemblyProvider;

        public Runner(IAssemblyProvider assemblyProvider)
        {
            IoC ioc = new IoC(assemblyProvider);
            container = ioc.container;
            this.assemblyProvider = assemblyProvider;
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomainOnAssemblyResolve;
        }

        private Assembly CurrentDomainOnAssemblyResolve(object sender, ResolveEventArgs args)
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

        public void Run<TProgram>(Environment environment, Perspective perspective, Host host, params string[] args)
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
                    .Instance(perspective),

                Component
                    .For<Host>()
                    .Instance(host)
            );

            IProgram program = container.Resolve<IProgram>();
            program.Run(args);
        }
    }
}
