using Bosphorus.Assemble.BootStrapper.Runner.Demo.ExecutableItem;
using Castle.Windsor;

namespace Bosphorus.Assemble.BootStrapper.Demo
{
    public class DemoExecutionList: AbstractMethodExecutionItemList
    {
        private readonly DemoService demoService;

        public DemoExecutionList(IWindsorContainer container, DemoService demoService) :
            base(container)
        {
            this.demoService = demoService;
        }

        public int SumDemo()
        {
            int sum = demoService.Sum(3, 5);
            return sum;
        }
    }
}
