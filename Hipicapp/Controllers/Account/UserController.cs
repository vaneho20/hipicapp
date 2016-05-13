using Hipicapp.Controllers.Abstract;
using Hipicapp.Filters;
using Hipicapp.Model.Account;
using Hipicapp.Model.Authentication;
using Hipicapp.Proxy.Account;
using Hipicapp.Utils.Pager;
using Spring.Context.Attributes;
using Spring.Objects.Factory.Attributes;
using Spring.Objects.Factory.Support;
using Spring.Stereotype;
using System.Collections.Generic;
using System.Web.Http;

namespace Hipicapp.Controllers.Account
{
    [Scope(ObjectScope.Request)]
    [Controller]
    [RoutePrefix("api/users")]
    public class UserController : HipicappApiController
    {
        [Autowired]
        public IUserProxy UserProxy { get; set; }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("find")]
        public Page<User> Find(UserFindRequest request)
        {
            return this.UserProxy.Paginated(request);
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("getCurrentUser")]
        public User GetCurrentUser()
        {
            return this.UserProxy.GetCurrentUser();
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("get/{id}")]
        public User Get(long? id)
        {
            return this.UserProxy.Get(id);
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("getTileCount")]
        public TileCount GetTileCount()
        {
            return this.UserProxy.GetTileCount();
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("getRegistrationsBetweenDates")]
        public IList<Registration> GetRegistrationsBetweenDates([FromBody]DateRangeRequest range)
        {
            return this.UserProxy.GetRegistrationsBetweenDates(range.Ini, range.End);
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("save")]
        public User Save([Valid] User user)
        {
            return this.UserProxy.Save(user);
        }

        [AcceptVerbs("PUT")]
        [HttpPut]
        [Route("enable")]
        public User Enable([Valid] User user)
        {
            return this.UserProxy.ToggleEnable(user, true);
        }

        [AcceptVerbs("PUT")]
        [HttpPut]
        [Route("disable")]
        public User Disable([Valid] User user)
        {
            return this.UserProxy.ToggleEnable(user, false);
        }

        [AcceptVerbs("DELETE")]
        [HttpDelete]
        [Route("delete")]
        public User Delete(User user)
        {
            return this.UserProxy.Delete(user);
        }
    }
}