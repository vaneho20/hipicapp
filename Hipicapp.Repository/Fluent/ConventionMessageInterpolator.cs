using NHibernate.Validator.Engine;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Hipicapp.Repository.Fluent
{
    public class ConventionMessageInterpolator : IMessageInterpolator
    {
        private const string EntityValidatorConvention = "{{validator.{0}}}";
        private const string EntityPropertyValidatorConvention = "{{validator.{0}.{1}}}";
        private const string EntityNameConvention = "{{friendly.class.{0}}}";
        private const string PropertyNameConvention = "{{friendly.property.{0}}}";
        private const string PropertyValueTagSubstitutor = "${{{0}{1}}}";
        private static readonly int PropertyValueTagLength = "PropertyValue".Length;

        private readonly Regex substitutions = new Regex(@"\[EntityName\]|\[PropertyName\]|(\[PropertyValue([.][A-Za-z_][A-Za-z_0-9]*)*\])", RegexOptions.Compiled);

        #region IMessageInterpolator Members

        public string Interpolate(InterpolationInfo info)
        {
            string result = info.Message;
            if (string.IsNullOrEmpty(result))
            {
                result = CreateDefaultMessage(info);
            }
            do
            {
                info.Message = Replace(result, info.Entity, info.PropertyName);
                result = info.DefaultInterpolator.Interpolate(info);
            }
            while (!Equals(result, info.Message));
            return result;
        }

        #endregion IMessageInterpolator Members

        public string CreateDefaultMessage(InterpolationInfo info)
        {
            return string.IsNullOrEmpty(info.PropertyName) ?
                string.Format(EntityValidatorConvention, GetEntityValidatorName(info))
                :
                string.Format(EntityPropertyValidatorConvention, info.Entity.Name, info.PropertyName);
        }

        private string GetEntityValidatorName(InterpolationInfo info)
        {
            var entityValidatorName = info.Entity.Name;
            var validatorType = info.Validator.GetType();
            if (validatorType.IsGenericType)
            {
                entityValidatorName = validatorType.GetGenericArguments().First().Name;
            }
            entityValidatorName = CleanValidatorPostfix(entityValidatorName);
            return entityValidatorName;
        }

        private string CleanValidatorPostfix(string entityValidatorName)
        {
            var i = entityValidatorName.LastIndexOf("Validator");
            return i > 0 ? entityValidatorName.Substring(0, i) : entityValidatorName;
        }

        public string Replace(string originalMessage, Type entity, string propName)
        {
            return substitutions.Replace(originalMessage, match =>
            {
                if ("[EntityName]".Equals(match.Value))
                {
                    return string.Format(EntityNameConvention, entity.Name);
                }
                else if (!string.IsNullOrEmpty(propName) && "[PropertyName]".Equals(match.Value))
                {
                    return string.Format(PropertyNameConvention, propName);
                }
                else if (!string.IsNullOrEmpty(propName) && match.Value.StartsWith("[PropertyValue"))
                {
                    return string.Format(PropertyValueTagSubstitutor, propName,
                                         match.Value.Trim('[', ']').Substring(PropertyValueTagLength));
                }
                return match.Value;
            });
        }
    }
}