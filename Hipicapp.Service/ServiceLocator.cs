using Spring.Context.Support;

namespace Hipicapp.Service
{
    public sealed class ServiceNames
    {
        public static readonly string NHIBERNATE_SESSION_FACTORY = "NHibernateSessionFactory";

        public static readonly string USER_SERVICE = "UserService";
    }

    public class ServiceLocator
    {
        public static T LocateService<T>(string serviceName)
        {
            return ContextRegistry.GetContext().GetObject<T>(serviceName);
        }
    }
}