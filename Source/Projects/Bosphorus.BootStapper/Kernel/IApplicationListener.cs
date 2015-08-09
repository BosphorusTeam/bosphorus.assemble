using System;

namespace Bosphorus.BootStapper.Program
{
    public interface IApplicationListener
    {
        event EventHandler<EventArgs> AfterStarted;
        event EventHandler<EventArgs> AfterFinished;
    }
}