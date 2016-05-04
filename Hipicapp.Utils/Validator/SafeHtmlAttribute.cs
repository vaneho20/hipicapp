using NHibernate.Validator.Engine;
using NSoup.Safety;
using System;

namespace Hipicapp.Utils.Validator
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Field | AttributeTargets.Property)]
    [ValidatorClass(typeof(SafeHtmlValidator))]
    public class SafeHtmlAttribute : Attribute, IRuleArgs
    {
        private Whitelist whitelistType = Whitelist.Relaxed;

        private string message = "{validator.safeHtml}";

        public string Message { get { return this.message; } set { this.message = value; } }

        public SafeHtmlAttribute()
        {
        }

        public SafeHtmlAttribute(Whitelist type)
        {
            this.whitelistType = type;
        }

        public Whitelist WhitelistType
        {
            get { return whitelistType; }
            set { whitelistType = value; }
        }
    }
}