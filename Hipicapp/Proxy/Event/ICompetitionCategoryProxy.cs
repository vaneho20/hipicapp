using Hipicapp.Model.Event;
using Hipicapp.Utils.Pager;
using System.Collections.Generic;

namespace Hipicapp.Proxy.Event
{
    public interface ICompetitionCategoryProxy
    {
        IList<CompetitionCategory> FindAll();

        Page<CompetitionCategory> Paginated(CompetitionCategoryFindRequest request);

        CompetitionCategory Get(long? id);

        CompetitionCategory Save(CompetitionCategory competitionCategory);

        CompetitionCategory Update(CompetitionCategory competitionCategory);

        CompetitionCategory Delete(CompetitionCategory competitionCategory);
    }
}