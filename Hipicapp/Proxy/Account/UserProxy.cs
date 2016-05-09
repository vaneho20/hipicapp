using Hipicapp.Filters;
using Hipicapp.Model.Account;
using Hipicapp.Model.Authentication;
using Hipicapp.Service.Account;
using Hipicapp.Utils.Pager;
using Spring.Objects.Factory.Attributes;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;

namespace Hipicapp.Proxy.Account
{
    [Proxy]
    public class UserProxy : IUserProxy
    {
        [Autowired]
        private IUserService UserService { get; set; }

        //[Autowired]
        //private PasswordEncoder { get; set; }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public Page<User> Paginated(UserFindRequest request)
        {
            return this.UserService.Paginated(request.Filter, request.PageRequest);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public User Get(long? id)
        {
            return this.UserService.Get(id);
        }

        public User GetCurrentUser()
        {
            return this.GetByUserName(HttpContext.Current.User.Identity.Name);
        }

        public User GetByUserName(string username)
        {
            return this.UserService.GetByUserName(username);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public TileCount GetTileCount()
        {
            var tileCount = this.UserService.GetTileCount();
            tileCount.TotalConnections = Membership.GetNumberOfUsersOnline();
            return tileCount;
        }

        public User Save(User user)
        {
            return this.UserService.Save(user);
        }

        public void Save(IList<User> users)
        {
            this.UserService.Save(users);
        }

        public User SignIn(User user)
        {
            return this.UserService.Save(user);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public User ToggleEnable(User user, bool enable)
        {
            return this.UserService.ToggleEnable(user, enable);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public User Delete(User user)
        {
            return this.UserService.Delete(user);
        }
    }
}