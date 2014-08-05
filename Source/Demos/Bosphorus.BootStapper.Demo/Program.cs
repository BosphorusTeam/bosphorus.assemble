using Bosphorus.BootStapper.Common;
using Bosphorus.BootStapper.Program;
using Bosphorus.BootStapper.Runner;

namespace Bosphorus.BootStapper.Demo
{
    public class Program: IProgram
    {
        private readonly IService service;

        public Program(IService service)
        {
            this.service = service;
        }

        static void Main(string[] args)
        {
            ConsoleRunner.Run<Program>(Environment.Development, Perspective.Debug, args);
        }

        public void Run(string[] args)
        {
            int sum = service.Sum(1, 3);
            System.Console.WriteLine(sum);
        }
    }
}
