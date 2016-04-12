using Spring.Stereotype;

namespace Hipicapp.Proxy
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