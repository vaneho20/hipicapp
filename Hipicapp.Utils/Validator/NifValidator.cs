using Hipicapp.Utils.Exceptions;
using Hipicapp.Utils.Util;
using NHibernate.Validator.Engine;

namespace Hipicapp.Utils.Validator
{
    public class NifValidator : IInitializableValidator<NifAttribute, string>
    {
        private Hipicapp.Utils.Validator.NifAttribute.Type[] AllowedTypes { get; set; }

        protected override void Initialize2(NifAttribute parameters)
        {
            this.AllowedTypes = parameters.AllowedTypes;
        }

        protected override bool IsValid2(string value, IConstraintValidatorContext context)
        {
            bool isValid = false;

            if (value == null)
            {
                isValid = true;
            }
            else
            {
                foreach (Hipicapp.Utils.Validator.NifAttribute.Type type in this.AllowedTypes)
                {
                    switch (type)
                    {
                        case Hipicapp.Utils.Validator.NifAttribute.Type.NIF:
                            isValid = ValidationUtils.IsValidNIF(value);
                            break;

                        case Hipicapp.Utils.Validator.NifAttribute.Type.CIF:
                            isValid = ValidationUtils.IsValidCIF(value);
                            if (!isValid)
                            {
                                isValid = ValidationUtils.IsValidCIF2(value);
                            }
                            break;

                        case Hipicapp.Utils.Validator.NifAttribute.Type.NIE:
                            isValid = ValidationUtils.IsValidNIE(value);
                            break;

                        default:
                            throw new EnumConstantNotPresentException(type, type.ToString());
                    }

                    if (isValid)
                    {
                        break;
                    }
                }
            }

            if (!isValid)
            {
                /*constraintContext.disableDefaultConstraintViolation();

                StringBuilder messageBuilder = new StringBuilder("{com.segurauto.portal.validation.");
                for (Type type : this.allowedTypes) {
                    messageBuilder.append(type.name().toLowerCase());
                    messageBuilder.append('.');
                }
                messageBuilder.append("message}");

                constraintContext.buildConstraintViolationWithTemplate(messageBuilder.toString()).addConstraintViolation();*/
            }

            return isValid;
        }
    }
}