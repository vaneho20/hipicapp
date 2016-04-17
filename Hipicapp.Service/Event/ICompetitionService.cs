using Hipicapp.Model.Event;
using Hipicapp.Model.Participant;
using Hipicapp.Utils.Pager;
using System.Collections.Generic;

namespace Hipicapp.Service.Event
{
    public interface ICompetitionService
    {
        Page<Competition> Paginated(CompetitionFindFilter filter, PageRequest pageRequest);

        Competition Get(long? id);

        Competition Save(Competition competition);

        Competition Update(Competition competition);

        Competition Delete(Competition competition);

        IList<Score> SimulateScore(Competition competition);
    }
}