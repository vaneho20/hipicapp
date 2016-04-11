using System;
using System.ComponentModel;

namespace Hipica.Utils.Comparison
{
    public class TypeConverter
    {
        public static object ChangeType(object value, Type conversionType)
        {
            //Throw error if null
            if (conversionType == null)
            {
                throw new ArgumentNullException("conversionType");
            }

            // If it's not a nullable type, just pass through the parameters to Convert.ChangeType

            if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                if (value == null)
                {
                    return "";
                }

                var nullableConverter = new NullableConverter(conversionType);
                conversionType = nullableConverter.UnderlyingType;
            }

            return Convert.ChangeType(value, conversionType);
        }
    }
}