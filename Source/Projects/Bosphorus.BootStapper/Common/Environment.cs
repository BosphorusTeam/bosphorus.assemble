using Bosphorus.Common.Clr.Enum;

namespace Bosphorus.BootStapper.Common
{
    public class Environment: Enumeration
    {
        public readonly static Environment Null = new Environment {Id = 1};
        public readonly static Environment Local = new Environment { Id = 2 };
        public readonly static Environment Development = new Environment { Id = 3 };
        public readonly static Environment Test = new Environment { Id = 4 };
        public readonly static Environment PreProduction = new Environment { Id = 5 };
        public readonly static Environment Production = new Environment { Id = 6 };
    }
}
