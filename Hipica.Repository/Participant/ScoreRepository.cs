using Hipica.Model.Event;
using Hipica.Model.Participant;
using Hipica.Repository.Abstract;
using Spring.Stereotype;

namespace Hipica.Repository.Participant
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