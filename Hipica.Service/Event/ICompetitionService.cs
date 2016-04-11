using Hipica.Model.Event;
using Hipica.Model.Participant;
using Hipica.Utils.Pager;
using System.Collections.Generic;

namespace Hipica.Service.Event
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