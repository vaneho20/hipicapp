using Hipica.Model.Account;
using Hipica.Model.Authentication;
using Hipica.Utils.Pager;
using System.Collections.Generic;

namespace Hipica.Proxy.Account
{
    public interface IUserProxy
    {
        Page<User> Paginated(UserFindRequest request);

        User Get(long? id);

        User GetCurrentUser();

        User GetByUserName(string username);

        User Save(User user);

        void Save(IList<User> users);

        User SignIn(User user);

        User ToggleEnable(User user, bool enable);

        User Delete(User user);
    }
}