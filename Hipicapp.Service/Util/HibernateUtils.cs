using NHibernate;
using System.Collections;
using System.Reflection;

namespace Hipicapp.Service.Util
{
    public class NHibernateUtils
    {
        public static T NullifyNHibernateUninitializedObjects<T>(T val)
        {
            if (val != null)
            {
                if (!NHibernateUtil.IsInitialized(val))
                {
                    val = default(T);
                }
                else if (isIterable(val))
                {
                    IEnumerable enumerable = (IEnumerable)val;
                    foreach (object o in enumerable)
                    {
                        NullifyNHibernateUninitializedObjects(o);
                    }
                }
                else if (val.GetType().Assembly.GetName().ToString().StartsWith("Hipicapp"))
                {
                    foreach (PropertyInfo fi in val.GetType().GetProperties())
                    {
                        if (fi.SetMethod != null)
                        {
                            object fieldValue = fi.GetValue(val);
                            object nullifiedFieldValue = NullifyNHibernateUninitializedObjects(fieldValue);
                            fi.SetValue(val, nullifiedFieldValue);
                        }
                    }
                }
            }
            return val;
        }

        private static bool isIterable(object value)
        {
            return value is IEnumerable;
        }
    }
}