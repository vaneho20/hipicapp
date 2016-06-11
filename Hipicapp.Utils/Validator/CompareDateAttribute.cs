using NHibernate.Validator.Engine;
using System;

namespace Hipicapp.Utils.Validator
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Field | AttributeTargets.Property)]
    [ValidatorClass(typeof(CompareDateValidator))]
    public class CompareDateAttribute : Attribute, IRuleArgs
    {
        private string message = "{validator.compareDate}";

        public string Message { get { return this.message; } set { this.message = value; } }

        public string Property { get; set; }

        private Comparator comparator = Comparator.EQ;

        public Comparator Comparator
        {
            get { return comparator; }
            set { comparator = value; }
        }

        public CompareDateAttribute()
        {
        }
    }

    public enum Comparator
    {
        EQ, LTE, LT, GTE, GT, NE
    }
}