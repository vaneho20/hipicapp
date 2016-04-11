using Hipica.Filters;
using Hipica.Model.Authentication;
using Hipica.Model.Event;
using Hipica.Service.Event;
using Hipica.Utils.Pager;
using Spring.Objects.Factory.Attributes;
using System.Collections.Generic;

namespace Hipica.Proxy.Event
{
    [Proxy]
    public class CompetitionCategoryProxy : ICompetitionCategoryProxy
    {
        [Autowired]
        private ICompetitionCategoryService CompetitionCategoryService { get; set; }

        [AuthorizeEnum(Rol.ADMINISTRATOR, Rol.ATHLETE)]
        public IList<CompetitionCategory> FindAll()
        {
            return this.CompetitionCategoryService.FindAll();
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR, Rol.ATHLETE)]
        public Page<CompetitionCategory> Paginated(CompetitionCategoryFindRequest request)
        {
            return this.CompetitionCategoryService.Paginated(request.Filter, request.PageRequest);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR, Rol.ATHLETE)]
        public CompetitionCategory Get(long? id)
        {
            return this.CompetitionCategoryService.Get(id);
        }

        public CompetitionCategory Save(CompetitionCategory competitionCategory)
        {
            return this.CompetitionCategoryService.Save(competitionCategory);
        }

        public CompetitionCategory Update(CompetitionCategory competitionCategory)
        {
            return this.CompetitionCategoryService.Update(competitionCategory);
        }

        public CompetitionCategory Delete(CompetitionCategory competitionCategory)
        {
            return this.CompetitionCategoryService.Delete(competitionCategory);
        }
    }
}