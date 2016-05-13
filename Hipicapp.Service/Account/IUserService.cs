using Hipicapp.Model.Account;
using Hipicapp.Model.Authentication;
using Hipicapp.Utils.Pager;
using System;
using System.Collections.Generic;

namespace Hipicapp.Service.Account
{
    public interface IUserService
    {
        Page<User> Paginated(UserFindFilter filter, PageRequest pageRequest);

        User Get(long? id);

        User GetByUserName(string username);

        TileCount GetTileCount();

        IList<Registration> GetRegistrationsBetweenDates(DateTime? ini, DateTime? end);

        User Save(User user);

        void Save(IList<User> users);

        User SignIn(User user);

        User ToggleEnable(User user, bool enable);

        User Delete(User user);
    }
}