using Hipicapp.Controllers.Abstract;
using Hipicapp.Filters;
using Hipicapp.Model.Event;
using Hipicapp.Model.Participant;
using Hipicapp.Proxy.Event;
using Hipicapp.Utils.Pager;
using Spring.Context.Attributes;
using Spring.Objects.Factory.Attributes;
using Spring.Objects.Factory.Support;
using Spring.Stereotype;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Hipicapp.Controllers.Event
{
    [Scope(ObjectScope.Request)]
    [Controller]
    [System.Web.Http.RoutePrefix("api/competition")]
    public class CompetitionController : HipicappApiController
    {
        [Autowired]
        public ICompetitionProxy CompetitionProxy { get; set; }

        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        [Route("api/competition/find")]
        //[Authorize(Roles = "ATHLETE")]
        public Page<Competition> Find(CompetitionFindRequest request)
        {
            return this.CompetitionProxy.Paginated(request);
        }

        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public Competition Get(long? id)
        {
            return this.CompetitionProxy.Get(id);
        }

        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        public Competition Save([Valid] Competition competition)
        {
            return this.CompetitionProxy.Save(competition);
        }

        [System.Web.Http.AcceptVerbs("PUT")]
        [System.Web.Http.HttpPut]
        public Competition Update([Valid] Competition competition)
        {
            return this.CompetitionProxy.Update(competition);
        }

        [System.Web.Http.AcceptVerbs("DELETE")]
        [System.Web.Http.HttpDelete]
        public Competition Delete(Competition competition)
        {
            return this.CompetitionProxy.Delete(competition);
        }

        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        //[System.Web.Http.Route("api/judges/simulateScore")]
        public IList<Score> SimulateScore([Valid] Competition competition)
        {
            return this.CompetitionProxy.SimulateScore(competition);
        }

        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("competition/{competitionId}/assignAllJudges")]
        public IList<Seminary> AssignAllJudges(long? competitionId)
        {
            return this.CompetitionProxy.AssignAllJudges(competitionId);
        }

        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        public IList<Seminary> AssignAllJudgesById(long? competitionId, SeminaryIdRequest judgesId)
        {
            return this.CompetitionProxy.AssignAllJudgesById(competitionId, judgesId);
        }

        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        public IList<Seminary> AssignAllJudgesByFilter(long? competitionId, JudgeFindRequest findRequest)
        {
            return this.CompetitionProxy.AssignAllJudgesByFilter(competitionId, findRequest);
        }

        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        public IList<Seminary> UnassignAllJudges(long? competitionId)
        {
            return this.CompetitionProxy.UnassignAllJudges(competitionId);
        }

        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        public IList<Seminary> UnassignAllJudgesById(long? competitionId, SeminaryIdRequest judgesId)
        {
            return this.CompetitionProxy.UnassignAllJudgesById(competitionId, judgesId);
        }

        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        public IList<Seminary> UnassignAllJudgesByFilter(long? competitionId, JudgeFindRequest findRequest)
        {
            return this.CompetitionProxy.UnassignAllJudgesByFilter(competitionId, findRequest);
        }

        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        public Seminary AssignUnassignJudge(long? competitionId, long? judgeId)
        {
            return this.CompetitionProxy.AssignUnassignJudge(competitionId, judgeId);
        }
    }
}