using Hipicapp.Controllers.Abstract;
using Hipicapp.Model.Account;
using Hipicapp.Proxy.Account;
using Spring.Context.Attributes;
using Spring.Objects.Factory.Attributes;
using Spring.Objects.Factory.Support;
using Spring.Stereotype;
using System.Web.Http;

namespace Hipicapp.Controllers.Authentication
{
    [Scope(ObjectScope.Request)]
    [Controller]
    [RoutePrefix("api/authentication")]
    public class AuthenticationController : HipicappApiController
    {
        [Autowired]
        public IUserProxy UserProxy { get; set; }

        [Autowired]
        public ITicketProxy TicketProxy { get; set; }

        [AllowAnonymous]
        [Route("setup")]
        public bool Setup()
        {
            return true;
        }

        [AllowAnonymous]
        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("{userName}/resetPassword")]
        public Ticket ResetPassword([FromUri]string userName)
        {
            return this.TicketProxy.CreateTicketAndSendEmail(userName);
        }

        [AllowAnonymous]
        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("{key}/checkTicket")]
        public Ticket CheckTicket([FromUri]string key)
        {
            return this.TicketProxy.CheckTicket(key);
        }

        [AllowAnonymous]
        [AcceptVerbs("PUT")]
        [HttpPut]
        [Route("updatePassword")]
        public User UpdatePassword([FromBody]Ticket ticket)
        {
            return this.TicketProxy.UpdatePassword(ticket);
        }
    }
}