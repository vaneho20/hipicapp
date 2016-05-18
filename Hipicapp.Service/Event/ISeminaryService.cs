using Hipicapp.Model.Participant;
using Hipicapp.Utils.Pager;
using System.Collections.Generic;

namespace Hipicapp.Service.Event
{
    public interface ISeminaryService
    {
        Page<Judge> Paginated(JudgeFindFilter filter, PageRequest pageRequest);

        IList<Seminary> AssignAllJudges(long? competitionId);

        IList<Seminary> AssignAllJudgesById(long? competitionId, IList<long?> judgesId);

        IList<Seminary> AssignAllJudgesByFilter(long? competitionId, JudgeFindFilter findRequest);

        IList<Seminary> UnassignAllJudges(long? competitionId);

        IList<Seminary> UnassignAllJudgesById(long? competitionId, IList<long?> judgesId);

        IList<Seminary> UnassignAllJudgesByFilter(long? competitionId, JudgeFindFilter findRequest);

        Seminary AssignUnassignJudge(long? competitionId, long? judgeId);
    }
}