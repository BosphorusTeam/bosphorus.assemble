using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Bosphorus.Common.Api.Symbol;
using Bosphorus.Common.Application;
using Bosphorus.Common.Application.Scope.Application;
using Castle.Core.Internal;
using Castle.MicroKernel.Registration;
using Environment = Bosphorus.Common.Application.Environment;

namespace Bosphorus.Assemble.BootStrapper.Runner.Demo
{
    public static class DemoRunner
    {
        private static readonly ITypeProvider typeProvider;

        static DemoRunner()
        {
            AssemblyFilter assemblyFilter = new AssemblyFilter(".");
            IEnumerable<Assembly> assemblies = ReflectionUtil.GetAssemblies(assemblyFilter);
            IEnumerable<Type> types = assemblies.SelectMany(assembly => assembly.GetTypes());
            typeProvider = new DefaultTypeProvider(types);
        }

        [STAThread]
        public static void Run(Environment environment, Perspective perspective, params Type[] installerTypes)
        {
            IoC ioc = new IoC(typeProvider, environment, perspective, Host.Console, installerTypes);
            ioc.Register(
                Component.For<ExecuterHostForm>()
            );
            ioc.Install<Installer>();

            var applicationContextInvoker = ioc.Resolve<ApplicationContextInvoker>();
            applicationContextInvoker.InvokeStarted();

            Application.EnableVisualStyles();
            var executerHostForm = ioc.Resolve<ExecuterHostForm>();

            TextWriter textWriter = new RichTextBoxWriter(executerHostForm.tbConsole);
            TextWriter compsoiteWriter = new CompositeTextWriter(System.Console.Out, textWriter);
            System.Console.SetOut(compsoiteWriter);

            Application.Run(executerHostForm);

            applicationContextInvoker.InvokeFinished();
        }
    }
}
