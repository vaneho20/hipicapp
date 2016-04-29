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
using System.Web.Http;

namespace Hipicapp.Controllers.Event
{
    [Scope(ObjectScope.Request)]
    [Controller]
    [RoutePrefix("api/competitionCategories")]
    public class CompetitionCategoryController : HipicappApiController
    {
        [Autowired]
        public ICompetitionCategoryProxy CompetitionCategoryProxy { get; set; }

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("findAll")]
        public IList<CompetitionCategory> FindAll()
        {
            return this.CompetitionCategoryProxy.FindAll();
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("find")]
        public Page<CompetitionCategory> Find(CompetitionCategoryFindRequest request)
        {
            return this.CompetitionCategoryProxy.Paginated(request);
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("get/{id}")]
        public CompetitionCategory Get(long? id)
        {
            return this.CompetitionCategoryProxy.Get(id);
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("save")]
        public CompetitionCategory Save([Valid] CompetitionCategory competitionCategory)
        {
            return this.CompetitionCategoryProxy.Save(competitionCategory);
        }

        [AcceptVerbs("PUT")]
        [HttpPut]
        [Route("update")]
        public CompetitionCategory Update([Valid] CompetitionCategory competitionCategory)
        {
            return this.CompetitionCategoryProxy.Update(competitionCategory);
        }

        [AcceptVerbs("DELETE")]
        [HttpDelete]
        [Route("delete")]
        public CompetitionCategory Delete(CompetitionCategory competitionCategory)
        {
            return this.CompetitionCategoryProxy.Delete(competitionCategory);
        }
    }
}