using Bosphorus.BootStapper.Common;
using Bosphorus.Container.Castle.Facade;

namespace Bosphorus.BootStapper.Program
{
    public interface IApplication
    {
        IoC IoC { get; }

        void Start(Environment environment, Perspective perspective);

        void Stop();
    }
}