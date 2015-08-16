using Bosphorus.Common.Core.Application;
using Bosphorus.Container.Castle.Facade;

namespace Bosphorus.BootStapper.Kernel
{
    public interface IApplication
    {
        IoC IoC { get; }

        void Start(Environment environment, Perspective perspective);

        void Stop();
    }
}