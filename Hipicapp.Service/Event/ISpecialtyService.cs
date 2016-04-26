using Hipicapp.Model.Event;
using Hipicapp.Utils.Pager;
using System.Collections.Generic;

namespace Hipicapp.Service.Event
{
    public interface ISpecialtyService
    {
        IList<Specialty> FindAll();

        Page<Specialty> Paginated(SpecialtyFindFilter filter, PageRequest pageRequest);

        Specialty Get(long? id);

        Specialty Save(Specialty specialty);

        Specialty Update(Specialty specialty);

        Specialty Delete(Specialty specialty);
    }
}