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

        [HttpGet]
        public IList<CompetitionCategory> FindAll()
        {
            return this.CompetitionCategoryProxy.FindAll();
        }

        [HttpPost]
        [Route("api/competitionCategories/find")]
        //[Authorize(Roles = "ATHLETE")]
        public Page<CompetitionCategory> Find(CompetitionCategoryFindRequest request)
        {
            return this.CompetitionCategoryProxy.Paginated(request);
        }

        [HttpGet]
        public CompetitionCategory Get(long? id)
        {
            return this.CompetitionCategoryProxy.Get(id);
        }

        [HttpPost]
        public CompetitionCategory Save([Valid] CompetitionCategory competitionCategory)
        {
            return this.CompetitionCategoryProxy.Save(competitionCategory);
        }

        [HttpPut]
        public CompetitionCategory Update([Valid] CompetitionCategory competitionCategory)
        {
            return this.CompetitionCategoryProxy.Update(competitionCategory);
        }

        [HttpDelete]
        public CompetitionCategory Delete(CompetitionCategory competitionCategory)
        {
            return this.CompetitionCategoryProxy.Delete(competitionCategory);
        }
    }
}