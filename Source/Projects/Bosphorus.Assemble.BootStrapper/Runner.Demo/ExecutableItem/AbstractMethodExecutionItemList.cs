using System;
using System.Collections.Generic;
using System.Reflection;
using Bosphorus.Assemble.BootStrapper.Runner.Demo.ResultTransformer;
using Bosphorus.Common.Api.Context.Listener;
using Bosphorus.Common.Application.Scope.Call;
using Castle.Windsor;

namespace Bosphorus.Assemble.BootStrapper.Runner.Demo.ExecutableItem
{
    public abstract class AbstractMethodExecutionItemList: IExecutionItemList
    {
        private readonly IResultTransformer resultTransformer;
        private readonly DefaultContextInvoker<CallContext> callDefaultContextInvoker;

        protected AbstractMethodExecutionItemList(IWindsorContainer container)
        {
            this.resultTransformer = container.Resolve<IResultTransformer>();
            callDefaultContextInvoker = container.Resolve<DefaultContextInvoker<CallContext>>();
        }

        public IList<IExecutableItem> Items
        {
            get
            {
                IList<IExecutableItem> executionItemList = new List<IExecutableItem>();
                MethodInfo[] methodInfos = GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
                foreach (MethodInfo methodInfo in methodInfos)
                {
                    IExecutableItem executableItem = new MethodExecutableItem(this, methodInfo, resultTransformer);
                    IExecutableItem decoratedItem = new CallInvokerDecorator(executableItem, callDefaultContextInvoker);
                    executionItemList.Add(decoratedItem);
                }

                return executionItemList;
            }
        }

        public override string ToString()
        {
            Type type = this.GetType();
            string fullName = type.FullName;
            string assemblyName = type.Assembly.GetName().Name;
            string remainder = fullName.Replace(assemblyName + "." , string.Empty);

            return remainder;
        }
    }
}
