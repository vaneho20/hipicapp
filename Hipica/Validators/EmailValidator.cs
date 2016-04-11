using Microsoft.Practices.EnterpriseLibrary.Validation;
using System;
using System.Text.RegularExpressions;

namespace Hipica.Validators
{
    public class EmailValidator : Validator<string>
    {
        private static readonly Regex EmailRegex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

        public EmailValidator(string tag)
            : base(string.Empty, tag)
        {
        }

        protected override string DefaultMessageTemplate
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Validate that this string is a valid email address
        /// RegEx: \w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*
        /// </summary>
        protected override void DoValidate(string objectToValidate, object currentTarget, string key, ValidationResults validationResults)
        {
            if (string.IsNullOrEmpty(objectToValidate))
            {
                return;  //We are not going to validate for the null possibility (use a required validator for that)
            }

            Match match = EmailRegex.Match(objectToValidate);

            if (!match.Success) //If the match does not succeed, then it is an invalid email address
            {
                LogValidationResult(validationResults, "Email Address Format Is Not Valid", currentTarget, key);
            }
        }
    }
}