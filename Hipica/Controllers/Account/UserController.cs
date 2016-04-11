using Hipica.Controllers.Abstract;
using Hipica.Filters;
using Hipica.Model.Account;
using Hipica.Model.Authentication;
using Hipica.Proxy.Account;
using Hipica.Utils.Pager;
using Spring.Context.Attributes;
using Spring.Objects.Factory.Attributes;
using Spring.Objects.Factory.Support;
using Spring.Stereotype;
using System.Web.Mvc;

namespace Hipica.Controllers.Account
{
    [Scope(ObjectScope.Request)]
    [Controller]
    [RoutePrefix("api/users")]
    public class UserController : HipicaApiController
    {
        [Autowired]
        public IUserProxy UserProxy { get; set; }

        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        [Route("api/users/find")]
        //[Authorize(Roles = "ATHLETE")]
        public Page<User> Find(UserFindRequest request)
        {
            return this.UserProxy.Paginated(request);
        }

        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public User GetCurrentUser()
        {
            return this.UserProxy.GetCurrentUser();
        }

        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public User Get(long? id)
        {
            return this.UserProxy.Get(id);
        }

        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        public User Save([Valid] User user)
        {
            return this.UserProxy.Save(user);
        }

        [System.Web.Http.AcceptVerbs("PUT")]
        [System.Web.Http.HttpPut]
        public User Enable([Valid] User user)
        {
            return this.UserProxy.ToggleEnable(user, true);
        }

        [System.Web.Http.AcceptVerbs("PUT")]
        [System.Web.Http.HttpPut]
        public User Disable([Valid] User user)
        {
            return this.UserProxy.ToggleEnable(user, false);
        }

        [System.Web.Http.AcceptVerbs("DELETE")]
        [System.Web.Http.HttpDelete]
        public User Delete(User user)
        {
            return this.UserProxy.Delete(user);
        }
    }
}