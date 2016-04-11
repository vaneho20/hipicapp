using Hipica.Model.Account;
using Hipica.Model.Authentication;
using Hipica.Utils.Pager;
using System.Collections.Generic;

namespace Hipica.Service.Account
{
    public interface IUserService
    {
        Page<User> Paginated(UserFindFilter filter, PageRequest pageRequest);

        User Get(long? id);

        User GetByUserName(string username);

        User Save(User user);

        void Save(IList<User> users);

        User SignIn(User user);

        User ToggleEnable(User user, bool enable);

        User Delete(User user);
    }
}