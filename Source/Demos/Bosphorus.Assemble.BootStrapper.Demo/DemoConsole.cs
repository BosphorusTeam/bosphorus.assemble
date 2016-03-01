using System;
using Bosphorus.Assemble.BootStrapper.Runner.Console;

namespace Bosphorus.Assemble.BootStrapper.Demo
{
    public class DemoConsole: IProgram
    {
        private readonly DemoService demoService;

        public DemoConsole(DemoService demoService)
        {
            this.demoService = demoService;
        }

        public void Run(string[] args)
        {
            int sum = demoService.Sum(1, 2);
            Console.WriteLine(sum);
        }

    }
}
