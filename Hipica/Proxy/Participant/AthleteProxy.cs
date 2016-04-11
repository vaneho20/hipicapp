using Hipica.Filters;
using Hipica.Model.Athlete;
using Hipica.Model.Authentication;
using Hipica.Model.File;
using Hipica.Model.Participant;
using Hipica.Service.Account;
using Hipica.Service.Participant;
using Hipica.Utils.Pager;
using Spring.Objects.Factory.Attributes;
using Spring.Transaction.Interceptor;
using System;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Hipica.Proxy.Participant
{
    [Proxy]
    public class AthleteProxy : IAthleteProxy
    {
        [Autowired]
        private IAthleteService AthleteService { get; set; }

        [Autowired]
        private IUserService UserService { get; set; }

        //[Autowired]
        //private PasswordEncoder { get; set; }

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

        [AuthorizeEnum(Rol.ADMINISTRATOR, Rol.ATHLETE)]
        public Athlete Save(Athlete athlete)
        {
            return this.AthleteService.Save(athlete);
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