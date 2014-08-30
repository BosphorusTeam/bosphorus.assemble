using System.Windows.Forms;
using Bosphorus.BootStapper.Common;
using Bosphorus.BootStapper.Program;
using Bosphorus.BootStapper.Runner;
using Bosphorus.BootStapper.Runner.AutoUpdate;

namespace Bosphorus.BootStapper.Demo
{
    public class Program: IProgram
    {
        private readonly IFileSynhronizer fileSynhronizer;
        private readonly IService service;

        public Program(IFileSynhronizer fileSynhronizer, IService service)
        {
            this.fileSynhronizer = fileSynhronizer;
            this.service = service;
        }

        static void Main(string[] args)
        {
            ConsoleRunner.Run<Program>(Environment.Development, Perspective.Debug, args);
        }

        public void Run(string[] args)
        {
            string path1 = @"\\svn-srv\Artifact";
            string path2 = @"C:\Artifact";
            bool synchronize = fileSynhronizer.Synchronize(path1, path2, "Aras.Module.*.dll");

            int sum = service.Sum(1, 3);
            System.Console.WriteLine(sum);
        }
    }
}
