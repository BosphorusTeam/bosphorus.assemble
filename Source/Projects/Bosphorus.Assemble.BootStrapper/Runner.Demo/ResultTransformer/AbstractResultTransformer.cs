using System.Collections;

namespace Bosphorus.Assemble.BootStrapper.Runner.Demo.ResultTransformer
{
    public abstract class AbstractResultTransformer<TResult> : IResultTransformer 
        where TResult : class
    {
        public IList Transform(object value)
        {
            TResult typedValue = value as TResult;
            if (typedValue == null)
            {
                return null;
            }

            IList result = TransformInternal(typedValue);
            return result;
        }

        protected abstract  IList TransformInternal(TResult typedValue);
    }
}