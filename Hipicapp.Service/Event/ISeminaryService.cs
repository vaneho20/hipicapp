using Hipicapp.Model.Participant;
using System.Collections.Generic;

namespace Hipicapp.Service.Event
{
    public interface ISeminaryService
    {
        IList<Seminary> AssignAllJudges(long? competitionId);

        IList<Seminary> AssignAllJudgesById(long? competitionId, IList<long?> judgesId);

        IList<Seminary> AssignAllJudgesByFilter(long? competitionId, JudgeFindFilter findRequest);

        IList<Seminary> UnassignAllJudges(long? competitionId);

        IList<Seminary> UnassignAllJudgesById(long? competitionId, IList<long?> judgesId);

        IList<Seminary> UnassignAllJudgesByFilter(long? competitionId, JudgeFindFilter findRequest);

        Seminary AssignUnassignJudge(long? competitionId, long? judgeId);
    }
}