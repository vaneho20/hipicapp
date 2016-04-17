using System;

namespace Hipicapp.Utils.Validator
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Field | AttributeTargets.Property)]
    public class NifAttribute : Attribute
    {
        private Type[] allowedTypes = { Type.NIF, Type.CIF, Type.NIE };

        private string message = "{validator.nif}";

        public NifAttribute()
        {
        }

        public NifAttribute(Type[] types)
        {
            this.allowedTypes = types;
        }

        public Type[] AllowedTypes
        {
            get { return allowedTypes; }
            set { allowedTypes = value; }
        }

        public enum Type
        {
            NIF, CIF, NIE
        }
    }
}