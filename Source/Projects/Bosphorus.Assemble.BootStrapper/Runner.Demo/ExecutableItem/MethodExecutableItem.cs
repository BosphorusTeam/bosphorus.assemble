using System.Collections;
using System.Reflection;
using System.Runtime.ExceptionServices;
using Bosphorus.Assemble.BootStrapper.Runner.Demo.ResultTransformer;

namespace Bosphorus.Assemble.BootStrapper.Runner.Demo.ExecutableItem
{
    public class MethodExecutableItem : IExecutableItem
    {
        private readonly object instance;
        private readonly MethodInfo methodInfo;
        private readonly IResultTransformer resultTransformer;

        public MethodExecutableItem(object instance, MethodInfo methodInfo, IResultTransformer resultTransformer)
        {
            this.instance = instance;
            this.methodInfo = methodInfo;
            this.resultTransformer = resultTransformer;
        }

        public IList Execute()
        {
            try
            {
                object value = methodInfo.Invoke(instance, new object[0]);
                IList result = resultTransformer.Transform(value);
                return result;
            }
            catch (TargetInvocationException exception)
            {
                ExceptionDispatchInfo innerExceptionDispatchInfo = ExceptionDispatchInfo.Capture(exception.InnerException);
                innerExceptionDispatchInfo.Throw();
                return null;
            }
        }

        public override string ToString()
        {
            return methodInfo.Name;
        }
    }
}