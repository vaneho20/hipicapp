using Hipicapp.Model.Event;
using Hipicapp.Model.Participant;
using Hipicapp.Utils.Pager;
using System.Collections.Generic;

namespace Hipicapp.Proxy.Event
{
    public interface ICompetitionProxy
    {
        Page<Competition> Paginated(CompetitionFindRequest request);

        Competition Get(long? id);

        Competition Save(Competition competition);

        Competition Update(Competition competition);

        Competition Delete(Competition competition);

        IList<Score> SimulateScore(Competition competition);
    }
}