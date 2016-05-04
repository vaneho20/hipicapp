using NHibernate.Validator.Engine;
using System;

namespace Hipicapp.Utils.Validator
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Field | AttributeTargets.Property)]
    [ValidatorClass(typeof(SafeHtmlValidator))]
    public class SafeHtmlAttribute : Attribute, IRuleArgs
    {
        private WhiteListType whitelistType = WhiteListType.RELAXED;

        private string message = "{validator.safeHtml}";

        public string Message { get { return this.message; } set { this.message = value; } }

        public SafeHtmlAttribute()
        {
        }

        public SafeHtmlAttribute(WhiteListType type)
        {
            this.whitelistType = type;
        }

        public WhiteListType WhitelistType
        {
            get { return whitelistType; }
            set { whitelistType = value; }
        }
    }

    public enum WhiteListType
    {
        BASIC, BASIC_WITH_IMAGES, NONE, RELAXED, SIMPLE_TEXT
    }
}