using Hipicapp.Filters;
using Hipicapp.Model.Authentication;
using Hipicapp.Model.Event;
using Hipicapp.Model.Participant;
using Hipicapp.Service.Event;
using Hipicapp.Service.Participant;
using Hipicapp.Utils.Pager;
using Spring.Objects.Factory.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace Hipicapp.Proxy.Event
{
    [Proxy]
    public class CompetitionProxy : ICompetitionProxy
    {
        [Autowired]
        private IAthleteService AthleteService { get; set; }

        [Autowired]
        private ICompetitionService CompetitionService { get; set; }

        [Autowired]
        private ISeminaryService SeminaryService { get; set; }

        [AllowAnonymous]
        public Page<Competition> Paginated(CompetitionFindRequest request)
        {
            return this.CompetitionService.Paginated(request.Filter, request.PageRequest);
        }

        [AllowAnonymous]
        public Page<Enrollment> PaginatedInscriptions(EnrollmentFindRequest request)
        {
            var user = HttpContext.Current.GetOwinContext().Authentication.User.Claims;
            if (user != null && user.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value.Split(new char[] { ',' }).ToArray().Contains(Rol.ATHLETE.ToString()))
            {
                request.Filter.AthleteId = this.AthleteService.GetByUserId(Convert.ToInt64(user.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value)).Id;
            }
            return this.CompetitionService.PaginatedInscriptions(request.Filter, request.PageRequest);
        }

        [AllowAnonymous]
        public Competition Get(long? id)
        {
            return this.CompetitionService.Get(id);
        }

        [AllowAnonymous]
        public IList<Ranking> AdultRankingsBySpecialtyId(long? specialtyId)
        {
            return this.CompetitionService.AdultRankingsBySpecialtyId(specialtyId);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public Competition Save(Competition competition)
        {
            return this.CompetitionService.Save(competition);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public Competition Update(Competition competition)
        {
            return this.CompetitionService.Update(competition);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public Competition Delete(Competition competition)
        {
            return this.CompetitionService.Delete(competition);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public IList<Score> SimulateScore(Competition competition)
        {
            return this.CompetitionService.SimulateScore(competition);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public IList<Seminary> AssignAllJudges(long? competitionId)
        {
            return this.SeminaryService.AssignAllJudges(competitionId);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public IList<Seminary> AssignAllJudgesById(long? competitionId, SeminaryIdRequest judgesId)
        {
            return this.SeminaryService.AssignAllJudgesById(competitionId, judgesId.JudgesId);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public IList<Seminary> AssignAllJudgesByFilter(long? competitionId, JudgeFindRequest findRequest)
        {
            return this.SeminaryService.AssignAllJudgesByFilter(competitionId, findRequest.Filter);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public IList<Seminary> UnassignAllJudges(long? competitionId)
        {
            return this.SeminaryService.UnassignAllJudges(competitionId);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public IList<Seminary> UnassignAllJudgesById(long? competitionId, SeminaryIdRequest judgesId)
        {
            return this.SeminaryService.UnassignAllJudgesById(competitionId, judgesId.JudgesId);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public IList<Seminary> UnassignAllJudgesByFilter(long? competitionId, JudgeFindRequest findRequest)
        {
            return this.SeminaryService.UnassignAllJudgesByFilter(competitionId, findRequest.Filter);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public Seminary AssignUnassignJudge(long? competitionId, long? judgeId)
        {
            return this.SeminaryService.AssignUnassignJudge(competitionId, judgeId);
        }

        [AllowAnonymous]
        public IList<Competition> FindNextBySpecialtyId(long? specialtyId)
        {
            return this.CompetitionService.FindNextBySpecialtyId(specialtyId);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public IList<Competition> FindLast()
        {
            return this.CompetitionService.FindLast();
        }
    }
}