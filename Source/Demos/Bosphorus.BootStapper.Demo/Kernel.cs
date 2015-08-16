using System;
using Bosphorus.BootStapper.Runner;
using Bosphorus.BootStapper.Runner.Console;
using Bosphorus.Common.Core.Application;
using Environment = Bosphorus.Common.Core.Application.Environment;

namespace Bosphorus.BootStapper.Demo
{
    public class Kernel: IProgram
    {
        private readonly IService service;

        public Kernel(IService service)
        {
            this.service = service;
        }

        public void Run(string[] args)
        {
            int sum = service.Sum(1, 3);
            Console.WriteLine(sum);
        }
        static void Main(string[] args)
        {
            ConsoleRunner.Run<IProgram>(Environment.Development, Perspective.Debug, args);
        }

    }
}
