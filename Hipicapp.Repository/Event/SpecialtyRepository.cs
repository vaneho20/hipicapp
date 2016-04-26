using Hipicapp.Model.Event;
using Hipicapp.Repository.Abstract;
using Spring.Stereotype;

namespace Hipicapp.Repository.Event
{
    [Repository]
    public class SpecialtyRepository : EntityRepository<Specialty, long?>, ISpecialtyRepository
    {
    }
}