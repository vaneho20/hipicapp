using Hipicapp.Utils.Exceptions;
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
                    this.Whitelist = Whitelist.Basic;
                    break;

                case WhiteListType.BASIC_WITH_IMAGES:
                    this.Whitelist = Whitelist.BasicWithImages;
                    break;

                case WhiteListType.NONE:
                    this.Whitelist = Whitelist.None;
                    break;

                case WhiteListType.RELAXED:
                    this.Whitelist = Whitelist.Relaxed;
                    break;

                case WhiteListType.SIMPLE_TEXT:
                    this.Whitelist = Whitelist.SimpleText;
                    break;

                default:
                    throw new EnumConstantNotPresentException(parameters.WhitelistType, parameters.WhitelistType.ToString());
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