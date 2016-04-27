using Hipicapp.Backend;
using Hipicapp.Filters;
using Hipicapp.Model.Authentication;
using Hipicapp.Model.File;
using Hipicapp.Model.Participant;
using Hipicapp.Service.Account;
using Hipicapp.Service.Participant;
using Hipicapp.Utils.Pager;
using Microsoft.Owin.Testing;
using Spring.Objects.Factory.Attributes;
using Spring.Transaction.Interceptor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Hipicapp.Proxy.Participant
{
    [Proxy]
    public class AthleteProxy : IAthleteProxy
    {
        [Autowired]
        private IAthleteService AthleteService { get; set; }

        [Autowired]
        private IUserService UserService { get; set; }

        [AuthorizeEnum(Rol.ADMINISTRATOR, Rol.ATHLETE)]
        public Page<Athlete> Paginated(AthleteFindRequest request)
        {
            return this.AthleteService.Paginated(request.Filter, request.PageRequest);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR, Rol.ATHLETE)]
        public Athlete Get(long? id)
        {
            return this.AthleteService.Get(id);
        }

        [AuthorizeEnum(Rol.ATHLETE)]
        public Athlete GetByCurrentUser()
        {
            return this.AthleteService.GetByUserId(Convert.ToInt64(HttpContext.Current.GetOwinContext().Authentication.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value));
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public Athlete Save(Athlete athlete)
        {
            return this.AthleteService.Save(athlete);
        }

        [AllowAnonymous]
        public async Task<HttpResponseMessage> Register(Athlete athlete)
        {
            var unencryptedPassword = athlete.User.NewPassword;
            var model = this.AthleteService.Save(athlete);
            var testServer = TestServer.Create<Startup>();
            var requestParams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", athlete.User.UserName),
                new KeyValuePair<string, string>("password", unencryptedPassword),
                new KeyValuePair<string, string>("client_id", "hipicapp-web"),
                new KeyValuePair<string, string>("client_secret", "hipicapp@2016~~")
            };
            return await testServer.HttpClient.PostAsync("/api/token", new FormUrlEncodedContent(requestParams));
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR, Rol.ATHLETE)]
        public Athlete Update(Athlete athlete)
        {
            return this.AthleteService.Update(athlete);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public Athlete Delete(Athlete athlete)
        {
            return this.AthleteService.Delete(athlete);
        }

        [AuthorizeEnum(Rol.ATHLETE)]
        public EnrollmentId Inscription(EnrollmentId id)
        {
            return this.AthleteService.Inscription(id);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR, Rol.ATHLETE)]
        [Transaction]
        public FileInfo Upload(long? id, FileInfo file)
        {
            var athlete = this.AthleteService.Get(id);
            return this.AthleteService.Upload(athlete, file.FileName, file.ContentType, file.Contents);
        }
    }
}