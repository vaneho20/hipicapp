﻿using Hipicapp.Model.Account;
using Hipicapp.Repository.Abstract;
using NHibernate.Linq;
using Spring.Stereotype;
using System.Linq;

namespace Hipicapp.Repository.Account.Impl
{
    [Repository]
    public class UserRepository : EntityRepository<User, long?>, IUserRepository
    {
        public User GetByUserName(string username)
        {
            return CurrentSession.Query<User>().Where(x => x.UserName == username).FirstOrDefault();
        }
    }
}