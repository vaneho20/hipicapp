using Hipicapp.Filters;
using Hipicapp.Model.Authentication;
using Hipicapp.Model.File;
using Hipicapp.Model.Participant;
using Hipicapp.Proxy.Event;
using Hipicapp.Service.Event;
using Hipicapp.Service.Participant;
using Hipicapp.Utils.Pager;
using Spring.Objects.Factory.Attributes;
using Spring.Transaction.Interceptor;
using System;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace Hipicapp.Proxy.Participant
{
    [Proxy]
    public class HorseProxy : IHorseProxy
    {
        [Autowired]
        private IAthleteService AthleteService { get; set; }

        [Autowired]
        private ICompetitionService CompetitionService { get; set; }

        [Autowired]
        private IHorseService HorseService { get; set; }

        [Autowired]
        private ISameSpecialtyPolicy SameSpecialtyPolicy { get; set; }

        [AllowAnonymous]
        public Page<Horse> Paginated(HorseFindRequest request)
        {
            /*var user = HttpContext.Current.GetOwinContext().Authentication.User.Claims;
            if (user != null && user.Any(x => x.Type == ClaimTypes.Role && x.Value.Split(new char[] { ',' }).ToArray().Contains(Rol.ATHLETE.ToString())))
            {
                request.Filter.AthleteId = this.AthleteService.GetByUserId(Convert.ToInt64(user.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value)).Id;
            }*/
            return this.HorseService.Paginated(request.Filter, request.PageRequest);
        }

        [AuthorizeEnum(Rol.ATHLETE)]
        public Page<Horse> PaginatedByCurrentUser(HorseFindRequest request)
        {
            var user = HttpContext.Current.GetOwinContext().Authentication.User.Claims;
            Athlete athlete = null;
            if (user != null && user.Any(x => x.Type == ClaimTypes.Role && x.Value.Split(new char[] { ',' }).ToArray().Contains(Rol.ATHLETE.ToString())))
            {
                athlete = this.AthleteService.GetByUserId(Convert.ToInt64(user.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value));
                request.Filter.AthleteId = athlete.Id;
            }

            var competition = this.CompetitionService.Get(request.Filter.CompetitionId);
            this.SameSpecialtyPolicy.CheckSatisfiedBy(competition.Specialty, athlete.Specialty);
            return this.HorseService.PaginatedByCurrentUser(request.Filter, request.PageRequest);
        }

        [AllowAnonymous]
        public Horse Get(long? id)
        {
            return this.HorseService.Get(id);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR, Rol.ATHLETE)]
        [Transaction]
        public Horse Save(Horse horse)
        {
            var user = HttpContext.Current.GetOwinContext().Authentication.User.Claims;
            if (user != null && user.Any(x => x.Type == ClaimTypes.Role && x.Value.Split(new char[] { ',' }).ToArray().Contains(Rol.ATHLETE.ToString())))
            {
                horse.AthleteId = this.AthleteService.GetByUserId(Convert.ToInt64(user.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value)).Id;
            }
            return this.HorseService.Save(horse);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR, Rol.ATHLETE)]
        public Horse Update(Horse horse)
        {
            return this.HorseService.Update(horse);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR, Rol.ATHLETE)]
        public Horse Delete(Horse horse)
        {
            return this.HorseService.Delete(horse);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR, Rol.ATHLETE)]
        [Transaction]
        public FileInfo Upload(long? id, FileInfo file)
        {
            var athlete = this.HorseService.Get(id);
            return this.HorseService.Upload(athlete, file.FileName, file.ContentType, file.Contents);
        }
    }
}