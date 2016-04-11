using Hipica.Model.Event;
using Hipica.Utils.Pager;

namespace Hipica.Service.Event
{
    public interface ICompetitionService
    {
        Page<Competition> Paginated(CompetitionFindFilter filter, PageRequest pageRequest);

        Competition Get(long? id);

        Competition Save(Competition competition);

        Competition Update(Competition competition);

        Competition Delete(Competition competition);
    }
}