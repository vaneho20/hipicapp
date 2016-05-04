using NHibernate.Validator.Engine;
using NSoup;
using NSoup.Safety;

namespace Hipicapp.Utils.Validator
{
    public class SafeHtmlValidator : InitializableValidator<SafeHtmlAttribute, string>
    {
        private Whitelist WhitelistType { get; set; }

        protected override void Initialize2(SafeHtmlAttribute parameters)
        {
            this.WhitelistType = parameters.WhitelistType;
        }

        protected override bool IsValid2(string value, IConstraintValidatorContext context)
        {
            if (value == null)
            {
                return true;
            }
            return NSoupClient.IsValid(value, this.WhitelistType);
        }
    }
}