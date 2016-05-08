using Hipicapp.Model.Event;
using Hipicapp.Model.Participant;
using Hipicapp.Utils.Pager;
using System.Collections.Generic;

namespace Hipicapp.Proxy.Event
{
    public interface ICompetitionProxy
    {
        Page<Competition> Paginated(CompetitionFindRequest request);

        Page<Enrollment> PaginatedInscriptions(EnrollmentFindRequest request);

        Competition Get(long? id);

        IList<Ranking> AdultRankingsBySpecialtyId(long? specialty);

        Competition Save(Competition competition);

        Competition Update(Competition competition);

        Competition Delete(Competition competition);

        IList<Score> SimulateScore(Competition competition);

        IList<Seminary> AssignAllJudges(long? competitionId);

        IList<Seminary> AssignAllJudgesById(long? competitionId, SeminaryIdRequest judgesId);

        IList<Seminary> AssignAllJudgesByFilter(long? competitionId, JudgeFindRequest findRequest);

        IList<Seminary> UnassignAllJudges(long? competitionId);

        IList<Seminary> UnassignAllJudgesById(long? competitionId, SeminaryIdRequest judgesId);

        IList<Seminary> UnassignAllJudgesByFilter(long? competitionId, JudgeFindRequest findRequest);

        Seminary AssignUnassignJudge(long? competitionId, long? judgeId);

        IList<Competition> FindNextBySpecialtyId(long? specialtyId);

        IList<Competition> FindLast();
    }
}