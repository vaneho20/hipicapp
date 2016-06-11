using NHibernate.Validator.Engine;
using NHibernate.Validator.Util;
using System;

namespace Hipicapp.Utils.Validator
{
    public class CompareDateValidator : IInitializableStructValidator<CompareDateAttribute, DateTime>
    {
        private string Property { get; set; }

        private Comparator Comparator { get; set; }

        protected override void Initialize2(CompareDateAttribute parameters)
        {
            this.Property = parameters.Property;
            this.Comparator = parameters.Comparator;
        }

        protected override bool IsValid2(DateTime value, IConstraintValidatorContext context)
        {
            //MemberInfo member = TypeUtils.DecodeMemberAccessExpression(this.Property);

            var propertyValue = Convert.ToDateTime(context.GetPropValue(this.Property));
            var isValid = value == null || propertyValue == null;
            switch (this.Comparator)
            {
                case Validator.Comparator.EQ:
                    isValid = isValid || DateTime.Compare(value, propertyValue) == 0;
                    break;

                case Validator.Comparator.LTE:
                    isValid = isValid || DateTime.Compare(value, propertyValue) <= 0;
                    break;

                case Validator.Comparator.LT:
                    isValid = isValid || DateTime.Compare(value, propertyValue) < 0;
                    break;

                case Validator.Comparator.GTE:
                    isValid = isValid || DateTime.Compare(value, propertyValue) >= 0;
                    break;

                case Validator.Comparator.GT:
                    isValid = isValid || DateTime.Compare(value, propertyValue) > 0;
                    break;

                case Validator.Comparator.NE:
                    isValid = isValid || DateTime.Compare(value, propertyValue) != 0;
                    break;
            }
            return isValid;
        }
    }
}