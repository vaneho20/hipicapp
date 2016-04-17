using Hipicapp.Model.Event;
using Hipicapp.Model.Participant;
using Hipicapp.Repository.Abstract;
using Spring.Stereotype;

namespace Hipicapp.Repository.Participant
{
    [Repository]
    public class ScoreRepository : EntityRepository<Score, ScoreId>, IScoreRepository
    {
        public void ResetSimulationScore(Competition competition)
        {
            CurrentSession.CreateQuery("DELETE Score s WHERE s.Id.CompetitionId = :CompetitionId")
                .SetParameter<long?>("CompetitionId", competition.Id)
                .ExecuteUpdate();
        }
    }
}