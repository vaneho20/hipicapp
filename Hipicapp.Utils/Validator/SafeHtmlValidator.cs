using NHibernate.Validator.Engine;
using NSoup;
using NSoup.Safety;

namespace Hipicapp.Utils.Validator
{
    public class SafeHtmlValidator : InitializableValidator<SafeHtmlAttribute, string>
    {
        private Whitelist Whitelist { get; set; }

        protected override void Initialize2(SafeHtmlAttribute parameters)
        {
            switch (parameters.WhitelistType)
            {
                case WhiteListType.BASIC:
                    Whitelist = Whitelist.Basic;
                    break;

                case WhiteListType.BASIC_WITH_IMAGES:
                    Whitelist = Whitelist.BasicWithImages;
                    break;

                case WhiteListType.NONE:
                    Whitelist = Whitelist.None;
                    break;

                case WhiteListType.RELAXED:
                    Whitelist = Whitelist.Relaxed;
                    break;

                case WhiteListType.SIMPLE_TEXT:
                    Whitelist = Whitelist.SimpleText;
                    break;
            }
        }

        protected override bool IsValid2(string value, IConstraintValidatorContext context)
        {
            if (value == null)
            {
                return true;
            }
            return NSoupClient.IsValid(value, this.Whitelist);
        }
    }
}