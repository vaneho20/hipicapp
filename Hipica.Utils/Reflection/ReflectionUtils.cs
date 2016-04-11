using System;
using System.Linq;
using System.Reflection;

namespace Hipica.Utils
{
    public static class ReflectionUtils
    {
        /// <summary>
        /// Determines if a type is numeric.  Nullable numeric types are considered numeric.
        /// </summary>
        /// <remarks>
        /// Boolean is not considered numeric.
        /// </remarks>
        public static bool IsNumericType(Type type)
        {
            if (type == null)
            {
                return false;
            }

            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return true;

                case TypeCode.Object:
                    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        return IsNumericType(Nullable.GetUnderlyingType(type));
                    }
                    return false;
            }
            return false;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="baseType"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static PropertyInfo GetProp(Type baseType, string propertyName)
        {
            string[] parts = propertyName.Split('.');

            return (parts.Length > 1)
                ? GetProp(baseType.GetProperty(parts[0]).PropertyType, parts.Skip(1).Aggregate((a, i) => a + "." + i))
                : baseType.GetProperty(propertyName);
        }

        /// <summary>
        /// Get Property Value of Nested Classes
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propName"></param>
        /// <returns></returns>
        public static Object GetPropValue(this Object obj, String propName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }

            string[] nameParts = propName.Split('.');
            if (nameParts.Length == 1)
            {
                return obj.GetType().GetProperty(propName).GetValue(obj, null);
            }

            foreach (String part in nameParts)
            {
                if (obj == null) { return null; }

                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);
                if (info == null) { return null; }

                obj = info.GetValue(obj, null);
            }
            return obj;
        }

        /// <summary>
        /// Get Property Value of Nested Classes
        /// </summary>
        /// <typeparam name="TRet"></typeparam>
        /// <param name="obj"></param>
        /// <param name="propertyPathName"></param>
        /// <returns></returns>
        public static TRet GetPropertyValue<TRet>(this object obj, string propertyPathName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }

            string[] parts = propertyPathName.Split('.');
            string path = propertyPathName;
            object root = obj;

            if (parts.Length > 1)
            {
                path = parts[parts.Length - 1];
                parts = parts.TakeWhile((p, i) => i < parts.Length - 1).ToArray();
                string path2 = String.Join(".", parts);
                root = obj.GetPropertyValue<object>(path2);
            }

            var sourceType = root.GetType();
            return (TRet)sourceType.GetProperty(path).GetValue(root, null);
        }
    }
}