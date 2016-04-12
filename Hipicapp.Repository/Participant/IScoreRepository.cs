using Hipicapp.Model.Event;
using Hipicapp.Model.Participant;
using Hipicapp.Repository.Abstract;

namespace Hipicapp.Repository.Participant
{
    public interface IScoreRepository : IEntityRepository<Score, ScoreId>
    {
        void ResetSimulationScore(Competition competition);
    }
}