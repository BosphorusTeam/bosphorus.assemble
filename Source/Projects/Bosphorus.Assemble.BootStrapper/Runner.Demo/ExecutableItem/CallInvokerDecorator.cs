using System;
using System.Collections;
using Bosphorus.Common.Api.Context.Listener;
using Bosphorus.Common.Application.Scope.Call;

namespace Bosphorus.Assemble.BootStrapper.Runner.Demo.ExecutableItem
{
    public class CallInvokerDecorator: IExecutableItem
    {
        private readonly IExecutableItem decorated;
        private readonly DefaultContextInvoker<CallContext> callDefaultContextInvoker;

        public CallInvokerDecorator(IExecutableItem decorated, DefaultContextInvoker<CallContext> callDefaultContextInvoker)
        {
            this.decorated = decorated;
            this.callDefaultContextInvoker = callDefaultContextInvoker;
        }

        public IList Execute()
        {
            CallContext callContext = new CallContext();
            try
            {
                callDefaultContextInvoker.InvokeStarted(callContext);
                IList result = decorated.Execute();
                callDefaultContextInvoker.InvokeSuccessful(callContext);
                return result;
            }
            catch (Exception)
            {
                callDefaultContextInvoker.InvokeFailed(callContext);
                throw;
            }
            finally
            {
                callDefaultContextInvoker.InvokeFinished(callContext);
            }
        }

        public override string ToString()
        {
            return decorated.ToString();
        }
    }
}
