using Hipicapp.Model.Event;
using Hipicapp.Repository.Abstract;
using Spring.Stereotype;
using System.Linq;

namespace Hipicapp.Repository.Event
{
    [Repository]
    public class CompetitionCategoryRepository : EntityRepository<CompetitionCategory, long?>, ICompetitionCategoryRepository
    {
        public CompetitionCategory Get(CompetitionCategory category)
        {
            return this.GetAllQueryable()
                .FirstOrDefault(x => (x.Later == true && category.InitialYear >= x.InitialYear)
                    || (category.InitialYear >= x.InitialYear && category.FinalYear <= x.FinalYear)
                    || (x.Previous == true && category.FinalYear <= x.FinalYear));
        }
    }
}