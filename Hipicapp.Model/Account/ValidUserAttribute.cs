using NHibernate.Validator.Engine;
using System;

namespace Hipicapp.Model.Account
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Class | AttributeTargets.Interface)]
    //[ValidatorClass(typeof(IDefaultUserValidator))]
    public class ValidUserAttribute : Attribute, IRuleArgs
    {
        public string Message { get; set; }
    }
}