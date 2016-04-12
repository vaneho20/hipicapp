using Hipicapp.Model.Participant;
using Hipicapp.Repository.Abstract;
using NHibernate.Linq;
using Spring.Stereotype;
using System.Linq;

namespace Hipicapp.Repository.Participant
{
    [Repository]
    public class AthleteRepository : EntityRepository<Athlete, long?>, IAthleteRepository
    {
        public Athlete GetByUserId(long? userId)
        {
            return CurrentSession.Query<Athlete>().Where(x => x.UserId == userId).FirstOrDefault();
        }
    }
}