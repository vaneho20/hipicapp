using Hipicapp.Utils.Concurrent.Atomic;
using Spring.Context;
using Spring.Stereotype;

namespace Hipicapp.Utils.Bean
{
    [Component]
    public class ApplicationContextHolder : IApplicationContextAware
    {
        private static AtomicReference<IApplicationContext> APPLICATION_CONTEXT = new AtomicReference<IApplicationContext>(null);

        public static IApplicationContext GetApplicationContext()
        {
            return APPLICATION_CONTEXT.Get;
        }

        public IApplicationContext ApplicationContext
        {
            set
            {
                APPLICATION_CONTEXT.Set(value);
            }
        }
    }
}