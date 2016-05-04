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
using System.Web.Http;

namespace Hipicapp.Controllers.Event
{
    [Scope(ObjectScope.Request)]
    [Controller]
    [RoutePrefix("api/competitions")]
    public class CompetitionController : HipicappApiController
    {
        [Autowired]
        public ICompetitionProxy CompetitionProxy { get; set; }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("find")]
        public Page<Competition> Find(CompetitionFindRequest request)
        {
            return this.CompetitionProxy.Paginated(request);
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("get/{id}")]
        public Competition Get(long? id)
        {
            return this.CompetitionProxy.Get(id);
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("adultRankingsBySpecialty")]
        public IList<Ranking> AdultRankingsBySpecialty([FromBody]Specialty specialty)
        {
            return this.CompetitionProxy.AdultRankingsBySpecialty(specialty);
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("save")]
        public Competition Save([Valid] Competition competition)
        {
            return this.CompetitionProxy.Save(competition);
        }

        [AcceptVerbs("PUT")]
        [HttpPut]
        [Route("update")]
        public Competition Update([Valid] Competition competition)
        {
            return this.CompetitionProxy.Update(competition);
        }

        [AcceptVerbs("DELETE")]
        [HttpDelete]
        [Route("delete")]
        public Competition Delete(Competition competition)
        {
            return this.CompetitionProxy.Delete(competition);
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("simulateScore")]
        public IList<Score> SimulateScore([Valid] Competition competition)
        {
            return this.CompetitionProxy.SimulateScore(competition);
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("{competitionId:long}/assignAllJudges")]
        public IList<Seminary> AssignAllJudges([FromUri]long? competitionId)
        {
            return this.CompetitionProxy.AssignAllJudges(competitionId);
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("{competitionId}/assignAllJudgesById")]
        public IList<Seminary> AssignAllJudgesById([FromUri]long? competitionId, [FromBody]SeminaryIdRequest judgesId)
        {
            return this.CompetitionProxy.AssignAllJudgesById(competitionId, judgesId);
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("{competitionId}/assignAllJudgesByFilter")]
        public IList<Seminary> AssignAllJudgesByFilter([FromUri]long? competitionId, [FromBody]JudgeFindRequest findRequest)
        {
            return this.CompetitionProxy.AssignAllJudgesByFilter(competitionId, findRequest);
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("{competitionId}/unassignAllJudges")]
        public IList<Seminary> UnassignAllJudges([FromUri]long? competitionId)
        {
            return this.CompetitionProxy.UnassignAllJudges(competitionId);
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("{competitionId}/unassignAllJudgesById")]
        public IList<Seminary> UnassignAllJudgesById([FromUri]long? competitionId, [FromBody]SeminaryIdRequest judgesId)
        {
            return this.CompetitionProxy.UnassignAllJudgesById(competitionId, judgesId);
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("{competitionId}/unassignAllJudgesByFilter")]
        public IList<Seminary> UnassignAllJudgesByFilter([FromUri]long? competitionId, [FromBody]JudgeFindRequest findRequest)
        {
            return this.CompetitionProxy.UnassignAllJudgesByFilter(competitionId, findRequest);
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("{competitionId}/{judgeId}/assignUnassignJudge")]
        public Seminary AssignUnassignJudge([FromUri]long? competitionId, [FromUri]long? judgeId)
        {
            return this.CompetitionProxy.AssignUnassignJudge(competitionId, judgeId);
        }
    }
}