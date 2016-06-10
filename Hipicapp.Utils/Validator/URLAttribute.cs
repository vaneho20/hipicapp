using NHibernate.Validator.Engine;
using System;

namespace Hipicapp.Utils.Validator
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Field | AttributeTargets.Property)]
    [ValidatorClass(typeof(URLValidator))]
    public class URLAttribute : Attribute, IRuleArgs
    {
        private string message = "{validator.URL}";

        public string Message { get { return this.message; } set { this.message = value; } }

        public string Scheme { get; set; }

        public string Host { get; set; }

        private int port = -1;

        public int Port { get { return this.port; } set { this.port = value; } }

        public URLAttribute()
        {
        }
    }
}