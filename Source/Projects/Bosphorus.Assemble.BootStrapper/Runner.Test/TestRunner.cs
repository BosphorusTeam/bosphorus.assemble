using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Bosphorus.Common.Api.Symbol;
using Bosphorus.Common.Application;
using Castle.Core.Internal;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Environment = Bosphorus.Common.Application.Environment;

namespace Bosphorus.Assemble.BootStrapper.Runner.Test
{
    public class TestRunner
    {
        private static readonly ITypeProvider typeProvider;

        static TestRunner()
        {
            AssemblyFilter assemblyFilter = new AssemblyFilter(".");
            IEnumerable<Assembly> assemblies = ReflectionUtil.GetAssemblies(assemblyFilter);
            IEnumerable<Type> types = assemblies.SelectMany(assembly => assembly.GetTypes());
            typeProvider = new DefaultTypeProvider(types);
        }

        public static IWindsorContainer Run(Environment environment, Perspective perspective, params Type[] installerTypes)
        {
            IoC ioc = new IoC(typeProvider, environment, perspective, Host.Console, installerTypes);
            var windsorContainer = ioc.Resolve<IWindsorContainer>();
            return windsorContainer;
        }

    }
}
