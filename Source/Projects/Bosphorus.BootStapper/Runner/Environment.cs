using Bosphorus.Common.Clr.Enum;

namespace Bosphorus.BootStapper.Runner
{
    public class Environment: Enumeration
    {
        public static Environment Null = new Environment {Id = 1};
        public static Environment Local = new Environment {Id = 2};
        public static Environment Development = new Environment {Id = 3};
        public static Environment Test = new Environment {Id = 4};
        public static Environment Production = new Environment {Id = 5};
    }
}
