using NHibernate.Validator.Engine;
using System;

namespace Hipicapp.Utils.Validator
{
    public class URLValidator : InitializableValidator<URLAttribute, string>
    {
        private string Scheme { get; set; }

        private string Host { get; set; }

        private int Port { get; set; }

        protected override void Initialize2(URLAttribute parameters)
        {
            this.Scheme = parameters.Scheme;
            this.Host = parameters.Host;
            this.Port = parameters.Port;
        }

        protected override bool IsValid2(string value, IConstraintValidatorContext context)
        {
            if (value == null || value.Length == 0)
            {
                return true;
            }

            Uri uri;
            try
            {
                uri = new Uri(value);
            }
            catch (UriFormatException e)
            {
                return false;
            }

            if (Scheme != null && Scheme.Length > 0 && !uri.Scheme.Equals(Scheme))
            {
                return false;
            }

            if (Host != null && Host.Length > 0 && !uri.Host.Equals(Host))
            {
                return false;
            }

            if (Port != -1 && uri.Port != Port)
            {
                return false;
            }

            return true;
        }
    }
}