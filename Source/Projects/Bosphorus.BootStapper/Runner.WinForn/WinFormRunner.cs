using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bosphorus.BootStapper.Common;
using Bosphorus.BootStapper.Runner.Common;
using Bosphorus.BootStapper.Runner.Console;
using Bosphorus.Container.Castle.Facade;
using Castle.Core.Internal;
using Environment = Bosphorus.BootStapper.Common.Environment;

namespace Bosphorus.BootStapper.Runner.WinForn
{
    public class WinFormRunner
    {
        private readonly static IAssemblyProvider assemblyProvider;

        static WinFormRunner()
        {
            assemblyProvider = new WorkingDirectoryAssemblyProvider();
        }

        [STAThread]
        public static void Run<TForm>(Environment environment, Perspective perspective, string[] args) 
            where TForm : Form
        {
            IoC ioc = new IoC(assemblyProvider);
            ioc.Install(new CommonInstaller(environment, perspective, Host.Console));
            ioc.Install(new Installer<TForm>());

            TForm form = ioc.Resolve<TForm>();

            Application.EnableVisualStyles();
            Application.Run(form);
        } 
    }
}
