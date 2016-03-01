using Bosphorus.Assemble.BootStrapper.Runner.Console;
using Bosphorus.Assemble.BootStrapper.Runner.Demo;
using Bosphorus.Assemble.BootStrapper.Runner.WinForm;
using Bosphorus.Common.Application;

namespace Bosphorus.Assemble.BootStrapper.Demo
{
    public class Program
    {
        static void Main(string[] args)
        {
            //ConsoleRunner.Run<DemoConsole>(Environment.Development, Perspective.Debug, args, typeof(IDemoInstaller));
            //WinFormRunner.Run<DemoForm>(Environment.Development, Perspective.Debug, typeof (IDemoInstaller));
            DemoRunner.Run(Environment.Development, Perspective.Debug, typeof(IDemoInstaller));
        }
    }
}
