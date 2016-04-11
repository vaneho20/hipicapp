using Hipica.Model.Event;
using Hipica.Utils.Pager;

namespace Hipica.Proxy.Event
{
    public interface ICompetitionProxy
    {
        Page<Competition> Paginated(CompetitionFindRequest request);

        Competition Get(long? id);

        Competition Save(Competition competition);

        Competition Update(Competition competition);

        Competition Delete(Competition competition);
    }
}