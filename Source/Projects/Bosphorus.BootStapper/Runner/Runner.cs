using Castle.Core.Internal;
using Castle.MicroKernel.Registration;

namespace Bosphorus.BootStapper.Runner
{
    public class Runner<TAssemblyProvider> : Facade.AbstractIoC<TAssemblyProvider> 
        where TAssemblyProvider : IAssemblyProvider
    {
        public static void Run<TProgram>(Environment environment, Perspective perspective, params string[] args)
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
                    .Instance(perspective)
            );

            IProgram program = container.Resolve<IProgram>();
            program.Run(args);
        }

        public static void Run<TProgram>(Environment environment, params string[] args)
            where TProgram : class, IProgram
        {
            Run<TProgram>(environment, Perspective.Null, args);
        }


        public static void Run<TProgram>(params string[] args)
            where TProgram : class, IProgram
        {
            Run<TProgram>(Environment.Null, args);
        }
    }
}
