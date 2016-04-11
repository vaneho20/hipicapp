using Hipica.Model.Abstract;
using Hipica.Repository.Abstract;
using Hipica.Utils.Bean;
using Hipica.Utils.Validator;
using NHibernate;
using NHibernate.Validator.Engine;
using System;

namespace Hipica.Service.Validator
{
    public abstract class AbstractValidator<A, E, K, R> : IInitializableValidator<A, E>
        where A : Attribute
        where E : Entity<K>
        where R : IEntityRepository<E, K>
    {
        protected R EntityRepository { get; set; } // NOPMD

        protected abstract bool DoIsValid(E entity, IConstraintValidatorContext context);

        protected override void Initialize2(A parameters)
        {
            this.EntityRepository = ApplicationContextHolder.GetApplicationContext().GetObject<R>();
        }

        protected override bool IsValid2(E entity, IConstraintValidatorContext context)
        {
            bool isValid = true;

            if (entity != null)
            {
                FlushMode? flushMode = this.EntityRepository.FlushMode;
                if (flushMode == null)
                {
                    // default flush mode
                    flushMode = FlushMode.Auto;
                }

                // avoid query flush looping
                this.EntityRepository.FlushMode = FlushMode.Commit;

                try
                {
                    isValid = this.DoIsValid(entity, context);
                }
                finally
                {
                    // restore flush mode
                    this.EntityRepository.FlushMode = flushMode.Value;
                }
            }

            return isValid;
        }
    }
}