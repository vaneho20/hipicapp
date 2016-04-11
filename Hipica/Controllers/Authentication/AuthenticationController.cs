using Hipica.Controllers.Abstract;
using Hipica.Service.Account;
using Spring.Context.Attributes;
using Spring.Objects.Factory.Attributes;
using Spring.Objects.Factory.Support;
using Spring.Stereotype;
using System.Web.Http;

namespace Hipica.Controllers.Authentication
{
    [Scope(ObjectScope.Request)]
    [Controller]
    [RoutePrefix("api/authentication")]
    public class AuthenticationController : HipicaApiController
    {
        [Autowired]
        public IUserService UserService { get; set; }

        [AllowAnonymous]
        public bool Setup()
        {
            return true;
        }

        /*[HttpPut]
        public bool SignIn(SignInUserRequest d)
        {
            User user = Mapper.Map<SignInUserRequest, User>(d);
            this.UserService.SignIn(user, Mapper.Map<MeInstrumentRequest, Instrument>(d.PrincipalInstrument));
            return true;
        }*/
    }
}