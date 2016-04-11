using Hipica.Model.Event;
using Hipica.Model.Participant;
using Hipica.Repository.Abstract;

namespace Hipica.Repository.Participant
{
    public interface IScoreRepository : IEntityRepository<Score, ScoreId>
    {
        void ResetSimulationScore(Competition competition);
    }
}