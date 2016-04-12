using Hipicapp.Model.Athlete;
using Hipicapp.Repository.Abstract;

namespace Hipicapp.Repository.Participant
{
    public interface IAthleteRepository : IEntityRepository<Athlete, long?>
    {
        Athlete GetByUserId(long? userId);
    }
}