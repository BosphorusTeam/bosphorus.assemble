using System.Collections.Generic;

namespace Bosphorus.Assemble.BootStrapper.Runner.Demo.ExecutableItem
{
    public interface IExecutionItemList
    {
        IList<IExecutableItem> Items { get; }
    }
}