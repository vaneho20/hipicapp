using Hipicapp.Model.Account;
using Hipicapp.Repository.Account.Impl;
using Hipicapp.Service.Validator;
using NHibernate.Validator.Engine;
using System;

namespace Hipicapp.Service.Account
{
    public abstract class AbstractUserValidator<A> : AbstractValidator<A, User, long?, UserRepository> where A : Attribute
    {
        protected override bool DoIsValid(User entity, IConstraintValidatorContext context)
        {
            bool isValid = true;

            isValid = isValid && this.CheckUniqueUserName(entity, context);

            if (!isValid)
            {
                context.DisableDefaultError();
            }

            return isValid;
        }

        private bool CheckUniqueUserName(User user, IConstraintValidatorContext context)
        {
            bool isValid = true;

            User checkEmailUser = this.EntityRepository.GetByUserName(user.UserName);

            if ((checkEmailUser != null) && (user.IsNew || !checkEmailUser.Equals(user)))
            {
                isValid = false;
                //context.AddInvalid("{es.momomobile.mobi.validator.user.email.unique.message}").addPropertyNode(User.Properties.EMAIL).addConstraintViolation();
            }
            return isValid;
        }
    }
}