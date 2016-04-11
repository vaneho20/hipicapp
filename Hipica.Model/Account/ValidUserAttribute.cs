using NHibernate.Validator.Engine;
using System;

namespace Hipica.Model.Account
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Class | AttributeTargets.Interface)]
    public class ValidUserAttribute : Attribute, IRuleArgs
    {
        public string Message { get; set; }
    }
}