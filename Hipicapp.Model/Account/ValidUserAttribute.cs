using NHibernate.Validator.Engine;
using System;

namespace Hipicapp.Model.Account
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Class | AttributeTargets.Interface)]
    //[ValidatorClass(typeof(IInitializableValidator))]
    public class ValidUserAttribute : Attribute, IRuleArgs
    {
        public string Message { get; set; }
    }
}