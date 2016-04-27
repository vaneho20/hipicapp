using NHibernate.Validator.Engine;
using System;

namespace Hipicapp.Model.Account
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Class | AttributeTargets.Interface)]
    [ValidatorClass("Hipicapp.Service.Account.DefaultUserValidator, Hipicapp.Service, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")]
    public class ValidUserAttribute : Attribute, IRuleArgs
    {
        private string message = "{hipicapp.validator.unique}";

        public string Message { get { return this.message; } set { this.message = value; } }
    }
}