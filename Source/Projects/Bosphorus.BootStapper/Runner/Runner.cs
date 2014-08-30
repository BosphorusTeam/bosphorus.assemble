using Bosphorus.BootStapper.Common;
using Bosphorus.BootStapper.Program;
using Bosphorus.Container.Castle.Facade;
using Castle.Core.Internal;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Environment = Bosphorus.BootStapper.Common.Environment;

namespace Bosphorus.BootStapper.Runner
{
    public class Runner
    {
        private readonly IWindsorContainer container;

        public Runner(IAssemblyProvider assemblyProvider)
        {
            IoC ioc = new IoC(assemblyProvider);
            container = ioc.container;
        }

        public void Run<TProgram>(Environment environment, Perspective perspective, Host host, params string[] args)
            where TProgram : class, IProgram
        {
            container.Register(
                Component
                    .For<IProgram>()
                    .ImplementedBy<TProgram>(),

                Component
                    .For<Environment>()
                    .Instance(environment),

                Component
                    .For<Perspective>()
                    .Instance(perspective),

                Component
                    .For<Host>()
                    .Instance(host)
            );

            IProgram program = container.Resolve<IProgram>();
            program.Run(args);
        }
    }
}
