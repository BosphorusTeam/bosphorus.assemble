using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Bosphorus.Common.Api.Symbol;
using Bosphorus.Common.Application;
using Bosphorus.Common.Application.Scope.Application;
using Castle.Core.Internal;
using Castle.MicroKernel.Registration;
using Environment = Bosphorus.Common.Application.Environment;

namespace Bosphorus.Assemble.BootStrapper.Runner.WinForm
{
    public class WinFormRunner
    {
        private static readonly ITypeProvider typeProvider;

        static WinFormRunner()
        {
            AssemblyFilter assemblyFilter = new AssemblyFilter(".");
            IEnumerable<Assembly> assemblies = ReflectionUtil.GetAssemblies(assemblyFilter);
            IEnumerable<Type> types = assemblies.SelectMany(assembly => assembly.GetTypes());
            typeProvider = new DefaultTypeProvider(types);
        }

        [STAThread]
        public static void Run<TForm>(Environment environment, Perspective perspective, params Type[] installerTypes) 
            where TForm : Form
        {
            IoC ioc = new IoC(typeProvider, environment, perspective, Host.Console, installerTypes);
            ioc.Register(
                Component.For<TForm>()
            );

            var applicationContextInvoker = ioc.Resolve<ApplicationContextInvoker>();

            try
            {
                applicationContextInvoker.InvokeStarted();

                Application.EnableVisualStyles();
                TForm form = ioc.Resolve<TForm>();
                Application.Run(form);

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
