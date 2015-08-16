using Bosphorus.Common.Core.Application;

namespace Bosphorus.BootStapper.Runner.Console
{
    public class ConsoleRunner
    {
        public static void Run<TProgram>(Environment environment, Perspective perspective, params string[] args)
            where TProgram : class, IProgram
        {
            ConsoleApplication consoleApplication = new ConsoleApplication();
            consoleApplication.Start(environment, perspective);
            consoleApplication.IoC.Install(new Installer<TProgram>());
            IProgram program = consoleApplication.IoC.Resolve<IProgram>();
            program.Run(args);
            consoleApplication.Stop();
        }

    }
}
