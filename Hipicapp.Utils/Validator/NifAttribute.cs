using NHibernate.Validator.Engine;
using System;

namespace Hipicapp.Utils.Validator
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Field | AttributeTargets.Property)]
    [ValidatorClass(typeof(NifValidator))]
    public class NifAttribute : Attribute, IRuleArgs
    {
        private Type[] allowedTypes = { Type.NIF, Type.CIF, Type.NIE };

        private string message = "{validator.nif.cif.nie}";

        public string Message { get { return this.message; } set { this.message = value; } }

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