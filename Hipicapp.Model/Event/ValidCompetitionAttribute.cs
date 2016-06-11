using NHibernate.Validator.Engine;
using System;

namespace Hipicapp.Model.Event
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Class | AttributeTargets.Interface)]
    [ValidatorClass("Hipicapp.Service.Event.DefaultCompetitionValidator, Hipicapp.Service, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")]
    public class ValidCompetitionAttribute : Attribute, IRuleArgs
    {
        private string message = "{hipicapp.validator.competition}";

        public string Message { get { return this.message; } set { this.message = value; } }
    }
}