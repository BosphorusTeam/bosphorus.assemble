using System.Collections;

namespace Bosphorus.Assemble.BootStrapper.Runner.Demo.ResultTransformer
{
    public interface IResultTransformer
    {
        IList Transform(object value);
    }
}
