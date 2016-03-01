using System.Collections;

namespace Bosphorus.Assemble.BootStrapper.Runner.Demo.ResultTransformer
{
    public class ModelResultTransformer : AbstractResultTransformer<object>
    {
        protected override IList TransformInternal(object typedValue)
        {
            IList result = new ArrayList();
            result.Add(typedValue);
            return result;
        }
    }
}