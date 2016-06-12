using Hipicapp.Model.Event;
using Hipicapp.Repository.Abstract;

namespace Hipicapp.Repository.Event
{
    public interface ICompetitionCategoryRepository : IEntityRepository<CompetitionCategory, long?>
    {
        CompetitionCategory Get(CompetitionCategory category);
    }
}