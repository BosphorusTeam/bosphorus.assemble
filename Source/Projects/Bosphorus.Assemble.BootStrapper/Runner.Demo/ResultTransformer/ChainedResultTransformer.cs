using System.Collections;
using System.Collections.Generic;

namespace Bosphorus.Assemble.BootStrapper.Runner.Demo.ResultTransformer
{
    class ChainedResultTransformer : IResultTransformer
    {
        private readonly IList<IResultTransformer> items;

        public ChainedResultTransformer()
        {
            this.items = BuildItems();
        }

        private IList<IResultTransformer> BuildItems()
        {
            IList<IResultTransformer> result = new List<IResultTransformer>();
            result.Add(new QueryableResultTransformer());
            result.Add(new ModelResultTransformer());

            return result;
        }

        public IList Transform(object value)
        {
            foreach (IResultTransformer item in items)
            {
                IList result = item.Transform(value);
                if (result == null)
                {
                    continue;
                }

                return result;
            }

            return null;
        }
    }
}