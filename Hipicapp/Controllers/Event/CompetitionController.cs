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
    [RoutePrefix("api/competitions")]
    public class CompetitionController : HipicappApiController
    {
        [Autowired]
        public ICompetitionProxy CompetitionProxy { get; set; }

        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        [Route("api/competitions/find")]
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
    }
}