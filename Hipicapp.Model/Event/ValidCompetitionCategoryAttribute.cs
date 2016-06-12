using NHibernate.Validator.Engine;
using System;

namespace Hipicapp.Model.Event
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Class | AttributeTargets.Interface)]
    [ValidatorClass("Hipicapp.Service.Event.DefaultCompetitionCategoryValidator, Hipicapp.Service, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")]
    public class ValidCompetitionCategoryAttribute : Attribute, IRuleArgs
    {
        private string message = "{hipicapp.validator.competition.category}";

        public string Message { get { return this.message; } set { this.message = value; } }
    }
}