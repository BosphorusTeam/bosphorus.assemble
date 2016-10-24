using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Bosphorus.Common.Api.Symbol;
using Bosphorus.Common.Application;
using Bosphorus.Common.Application.Scope.Application;
using Castle.Core.Internal;
using Castle.MicroKernel.Registration;
using Environment = Bosphorus.Common.Application.Environment;

namespace Bosphorus.Assemble.BootStrapper.Runner.Console
{
    public class ConsoleRunner
    {
        private static readonly ITypeProvider typeProvider;

        static ConsoleRunner()
        {
            AssemblyFilter assemblyFilter = new AssemblyFilter(".");
            IEnumerable<Assembly> assemblies = ReflectionUtil.GetAssemblies(assemblyFilter);
            IEnumerable<Type> types = assemblies.SelectMany(assembly => assembly.GetTypes());
            typeProvider = new DefaultTypeProvider(types);
        }

        public static void Run<TProgram>(Environment environment, Perspective perspective, string[] args, params Type[] installerTypes)
            where TProgram : class, IProgram
        {
            IoC ioc = new IoC(typeProvider, environment, perspective, Host.Console, installerTypes);
            ioc.Register(
                Component.For<IProgram>().ImplementedBy<TProgram>()
            );

            var applicationContextInvoker = ioc.Resolve<ApplicationContextInvoker>();

            try
            {
                applicationContextInvoker.InvokeStarted();
                IProgram program = ioc.Resolve<IProgram>();
                program.Run(args);
                applicationContextInvoker.InvokeSuccessful();
            }
            catch (Exception exception)
            {
                var handled = applicationContextInvoker.InvokeFailed(exception);
                if (!handled)
                {
                    throw;
                }
            }
            finally
            {
                applicationContextInvoker.InvokeFinished();
            }
        }

    }
}
