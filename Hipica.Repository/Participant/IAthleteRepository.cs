using Hipica.Model.Athlete;
using Hipica.Repository.Abstract;

namespace Hipica.Repository.Participant
{
    public interface IAthleteRepository : IEntityRepository<Athlete, long?>
    {
        Athlete GetByUserId(long? userId);
    }
}