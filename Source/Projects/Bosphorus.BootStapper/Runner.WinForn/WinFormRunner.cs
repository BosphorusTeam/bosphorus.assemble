using System;
using System.Windows.Forms;
using Bosphorus.BootStapper.Common;
using Environment = Bosphorus.BootStapper.Common.Environment;

namespace Bosphorus.BootStapper.Runner.WinForn
{
    public class WinFormRunner
    {
        [STAThread]
        public static void Run<TForm>(Environment environment, Perspective perspective, string[] args) 
            where TForm : Form
        {
            WinFormApplication application = new WinFormApplication();
            application.Start(environment, perspective);
            application.IoC.Install(new Installer<TForm>());
            TForm form = application.IoC.Resolve<TForm>();
            Application.EnableVisualStyles();
            Application.Run(form);
            application.Stop();
        } 
    }
}
