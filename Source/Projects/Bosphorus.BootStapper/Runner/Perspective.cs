using Bosphorus.Common.Clr.Enum;

namespace Bosphorus.BootStapper.Runner
{
    public class Perspective: Enumeration
    {
        public static Perspective Null = new Perspective {Id = 1};
        public static Perspective Debug = new Perspective {Id = 2};
        public static Perspective Release = new Perspective {Id = 4};
    }
}
