namespace Hipicapp.Backend.Models.Authentication.Migrations
{
    using Hipicapp.Backend.Authentication.Repository;
    using Hipicapp.Backend.Models.Authentication;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    public class AdsData : IAdsData
    {
        private readonly DbContext context;

        private readonly IDictionary<Type, object> repositories;

        public AdsData()
            : this(new ApplicationDbContext())
        {
        }

        public AdsData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public IRepository<ApplicationRole> UserRoles
        {
            get
            {
                return this.GetRepository<ApplicationRole>();
            }
        }

        public IRepository<UserSession> UserSessions
        {
            get
            {
                return this.GetRepository<UserSession>();
            }
        }

        public IRepository<RefreshToken> RefreshTokens
        {
            get
            {
                return this.GetRepository<RefreshToken>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(EfRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}