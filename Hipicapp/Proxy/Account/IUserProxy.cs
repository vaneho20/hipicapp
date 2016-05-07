using Hipicapp.Model.Account;
using Hipicapp.Model.Authentication;
using Hipicapp.Utils.Pager;
using System.Collections.Generic;

namespace Hipicapp.Proxy.Account
{
    public interface IUserProxy
    {
        Page<User> Paginated(UserFindRequest request);

        User Get(long? id);

        User GetCurrentUser();

        User GetByUserName(string username);

        TileCount GetTileCount();

        User Save(User user);

        void Save(IList<User> users);

        User SignIn(User user);

        User ToggleEnable(User user, bool enable);

        User Delete(User user);
    }
}