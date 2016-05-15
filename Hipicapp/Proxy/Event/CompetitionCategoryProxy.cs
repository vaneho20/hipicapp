using Hipicapp.Filters;
using Hipicapp.Model.Authentication;
using Hipicapp.Model.Event;
using Hipicapp.Service.Event;
using Hipicapp.Utils.Pager;
using Spring.Objects.Factory.Attributes;
using System.Collections.Generic;
using System.Web.Http;

namespace Hipicapp.Proxy.Event
{
    [Proxy]
    public class CompetitionCategoryProxy : ICompetitionCategoryProxy
    {
        [Autowired]
        private ICompetitionCategoryService CompetitionCategoryService { get; set; }

        [AllowAnonymous]
        public IList<CompetitionCategory> FindAll()
        {
            return this.CompetitionCategoryService.FindAll();
        }

        [AllowAnonymous]
        public Page<CompetitionCategory> Paginated(CompetitionCategoryFindRequest request)
        {
            return this.CompetitionCategoryService.Paginated(request.Filter, request.PageRequest);
        }

        [AllowAnonymous]
        public CompetitionCategory Get(long? id)
        {
            return this.CompetitionCategoryService.Get(id);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public CompetitionCategory Save(CompetitionCategory competitionCategory)
        {
            return this.CompetitionCategoryService.Save(competitionCategory);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public CompetitionCategory Update(CompetitionCategory competitionCategory)
        {
            return this.CompetitionCategoryService.Update(competitionCategory);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public CompetitionCategory Delete(CompetitionCategory competitionCategory)
        {
            return this.CompetitionCategoryService.Delete(competitionCategory);
        }
    }
}