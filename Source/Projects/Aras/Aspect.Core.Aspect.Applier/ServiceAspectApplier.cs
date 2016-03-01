using Bosphorus.Aspect.Core.Aspect.Applier;
using Bosphorus.Aspect.Default;
using Bosphorus.Aspect.Log;
using Castle.Core;

namespace Aras.Common.Customization.Bosphorus.Aspect.Core.Aspect.Applier
{
    public class ServiceAspectApplier : IServiceAspectApplier
    {
        public bool IsApplicable(ComponentModel model)
        {
            return false;
        }

        public void Apply(ComponentModel model, ServiceAspectRegistry serviceAspectRegistry)
        {
            serviceAspectRegistry.Register(typeof(IDefaultAspect<>));
            serviceAspectRegistry.Register(typeof(ILogAspect<>));
        }
    }
}
