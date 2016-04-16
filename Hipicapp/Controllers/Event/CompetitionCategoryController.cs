using Hipicapp.Controllers.Abstract;
using Hipicapp.Filters;
using Hipicapp.Model.Event;
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
    [RoutePrefix("api/competitionCategories")]
    public class CompetitionCategoryController : HipicappApiController
    {
        [Autowired]
        public ICompetitionCategoryProxy CompetitionCategoryProxy { get; set; }

        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public IList<CompetitionCategory> FindAll()
        {
            return this.CompetitionCategoryProxy.FindAll();
        }

        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/competitionCategories/find")]
        //[Authorize(Roles = "ATHLETE")]
        public Page<CompetitionCategory> Find(CompetitionCategoryFindRequest request)
        {
            return this.CompetitionCategoryProxy.Paginated(request);
        }

        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public CompetitionCategory Get(long? id)
        {
            return this.CompetitionCategoryProxy.Get(id);
        }

        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        public CompetitionCategory Save([Valid] CompetitionCategory competitionCategory)
        {
            return this.CompetitionCategoryProxy.Save(competitionCategory);
        }

        [System.Web.Http.AcceptVerbs("PUT")]
        [System.Web.Http.HttpPut]
        public CompetitionCategory Update([Valid] CompetitionCategory competitionCategory)
        {
            return this.CompetitionCategoryProxy.Update(competitionCategory);
        }

        [System.Web.Http.AcceptVerbs("DELETE")]
        [System.Web.Http.HttpDelete]
        public CompetitionCategory Delete(CompetitionCategory competitionCategory)
        {
            return this.CompetitionCategoryProxy.Delete(competitionCategory);
        }
    }
}