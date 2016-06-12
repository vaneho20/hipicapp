using Hipicapp.Model.Account;
using Hipicapp.Repository.Account;
using Hipicapp.Service.Validator;
using NHibernate.Validator.Engine;
using System;

namespace Hipicapp.Service.Account
{
    public abstract class AbstractUserValidator<A> : AbstractValidator<A, User, long?, IUserRepository> where A : Attribute
    {
        protected override bool DoIsValid(User entity, IConstraintValidatorContext context)
        {
            bool isValid = true;

            isValid = isValid && this.CheckUniqueUserName(entity, context);

            isValid = isValid && this.CheckMatchPassword(entity, context);

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
                context.AddInvalid<User, string>("{hipicapp.validator.user.email.unique}", x => x.UserName);
            }
            return isValid;
        }

        private bool CheckMatchPassword(User user, IConstraintValidatorContext context)
        {
            bool isValid = user.NewPassword != null && user.ConfirmNewPassword != null;

            if (user.NewPassword != user.ConfirmNewPassword)
            {
                isValid = false;
                context.AddInvalid<User, string>("{hipicapp.validator.user.new.password.not.equal.confirm.new.password}", x => x.NewPassword);
            }
            return isValid;
        }
    }
}