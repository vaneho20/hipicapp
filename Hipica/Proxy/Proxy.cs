using Spring.Stereotype;

namespace Hipica.Proxy
{
    public class ProxyAttribute : ComponentAttribute
    {
        public ProxyAttribute()
        {
        }

        public ProxyAttribute(string name)
            : base(name)
        {
        }
    }
}