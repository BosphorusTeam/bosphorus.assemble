using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Bosphorus.Assemble.BootStrapper.Runner.Demo.ResultTransformer
{
    public class QueryableResultTransformer : AbstractResultTransformer<IEnumerable<object>>
    {
        protected override IList TransformInternal(IEnumerable<object> typedValue)
        {
            List<object> result = typedValue.ToList();
            return result;
        }
    }
}