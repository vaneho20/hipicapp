using Hipicapp.Model.Event;
using Hipicapp.Utils.Pager;
using System.Collections.Generic;

namespace Hipicapp.Service.Event
{
    public interface ICompetitionCategoryService
    {
        IList<CompetitionCategory> FindAll();

        Page<CompetitionCategory> Paginated(CompetitionCategoryFindFilter filter, PageRequest pageRequest);

        CompetitionCategory Get(long? id);

        CompetitionCategory Save(CompetitionCategory competitionCategory);

        CompetitionCategory Update(CompetitionCategory competitionCategory);

        CompetitionCategory Delete(CompetitionCategory competitionCategory);
    }
}