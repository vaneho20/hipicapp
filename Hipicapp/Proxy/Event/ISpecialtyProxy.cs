using Hipicapp.Model.Event;
using Hipicapp.Utils.Pager;
using System.Collections.Generic;

namespace Hipicapp.Proxy.Event
{
    public interface ISpecialtyProxy
    {
        IList<Specialty> FindAll();

        Page<Specialty> Paginated(SpecialtyFindRequest request);

        Specialty Get(long? id);

        Specialty Save(Specialty specialty);

        Specialty Update(Specialty specialty);

        Specialty Delete(Specialty specialty);
    }
}