using Hipicapp.Filters;
using Hipicapp.Model.Authentication;
using Hipicapp.Model.Event;
using Hipicapp.Service.Event;
using Hipicapp.Utils.Pager;
using Spring.Objects.Factory.Attributes;
using System.Collections.Generic;

namespace Hipicapp.Proxy.Event
{
    [Proxy]
    public class SpecialtyProxy : ISpecialtyProxy
    {
        [Autowired]
        private ISpecialtyService SpecialtyService { get; set; }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public IList<Specialty> FindAll()
        {
            return this.SpecialtyService.FindAll();
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public Page<Specialty> Paginated(SpecialtyFindRequest request)
        {
            return this.SpecialtyService.Paginated(request.Filter, request.PageRequest);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public Specialty Get(long? id)
        {
            return this.SpecialtyService.Get(id);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public Specialty Save(Specialty specialty)
        {
            return this.SpecialtyService.Save(specialty);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public Specialty Update(Specialty specialty)
        {
            return this.SpecialtyService.Update(specialty);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public Specialty Delete(Specialty specialty)
        {
            return this.SpecialtyService.Delete(specialty);
        }
    }
}