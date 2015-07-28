using System;
using Bosphorus.BootStapper.Common;
using Bosphorus.BootStapper.Program;
using Bosphorus.BootStapper.Runner;
using Bosphorus.BootStapper.Runner.Console;
using Environment = Bosphorus.BootStapper.Common.Environment;

namespace Bosphorus.BootStapper.Demo
{
    public class Program: IProgram
    {
        private readonly IService service;

        public Program(IService service)
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
            ConsoleRunner.Run<Program>(Environment.Development, Perspective.Debug, args);
        }

    }
}
