using Editorial.Service.Model.Account;
using Editorial.Service.Pager;
using System.Collections.Generic;

namespace Editorial.Service.Service.Account
{
    public interface IAccountService
    {
        Page<UserProfile> GetAll();

        UserProfile GetUserProfile(string username);

        Subscription GetSubscription(string username);

        void Save(UserProfile account);

        void Save(IList<UserProfile> accounts);
    }
}