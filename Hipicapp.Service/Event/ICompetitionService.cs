using Hipicapp.Model.Event;
using Hipicapp.Model.File;
using Hipicapp.Model.Participant;
using Hipicapp.Utils.Pager;
using System.Collections.Generic;

namespace Hipicapp.Service.Event
{
    public interface ICompetitionService
    {
        Page<Competition> Paginated(CompetitionFindFilter filter, PageRequest pageRequest);

        Page<Enrollment> PaginatedInscriptions(EnrollmentFindFilter filter, PageRequest pageRequest);

        Competition Get(long? id);

        Competition GetWithJudgesAndHorses(long? id);

        Competition Save(Competition competition);

        Competition Update(Competition competition);

        Competition Delete(Competition competition);

        IList<Score> SimulateScore(Competition competition);

        IList<Ranking> AdultRankingsBySpecialtyId(long? specialtyId);

        IList<Ranking> FullAdultRankingsBySpecialtyId(long? specialtyId);

        IList<Competition> FindNextBySpecialtyId(long? specialtyId);

        IList<Competition> FindLast();

        FileInfo Upload(Competition competition, string name, string mimeType, byte[] bytes);
    }
}