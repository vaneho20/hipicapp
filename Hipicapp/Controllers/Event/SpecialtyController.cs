using Hipicapp.Controllers.Abstract;
using Hipicapp.Filters;
using Hipicapp.Model.Event;
using Hipicapp.Proxy.Event;
using Hipicapp.Utils.Pager;
using Spring.Context.Attributes;
using Spring.Objects.Factory.Attributes;
using Spring.Objects.Factory.Support;
using Spring.Stereotype;
using System.Collections.Generic;
using System.Web.Http;

namespace Hipicapp.Controllers.Event
{
    [Scope(ObjectScope.Request)]
    [Controller]
    [RoutePrefix("api/specialties")]
    public class SpecialtyController : HipicappApiController
    {
        [Autowired]
        public ISpecialtyProxy SpecialtyProxy { get; set; }

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("findAll")]
        public IList<Specialty> FindAll()
        {
            return this.SpecialtyProxy.FindAll();
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("find")]
        public Page<Specialty> Find(SpecialtyFindRequest request)
        {
            return this.SpecialtyProxy.Paginated(request);
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("get/{id}")]
        public Specialty Get(long? id)
        {
            return this.SpecialtyProxy.Get(id);
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("save")]
        public Specialty Save([Valid] Specialty specialty)
        {
            return this.SpecialtyProxy.Save(specialty);
        }

        [AcceptVerbs("PUT")]
        [HttpPut]
        [Route("update")]
        public Specialty Update([Valid] Specialty specialty)
        {
            return this.SpecialtyProxy.Update(specialty);
        }

        [AcceptVerbs("DELETE")]
        [HttpDelete]
        [Route("delete")]
        public Specialty Delete(Specialty specialty)
        {
            return this.SpecialtyProxy.Delete(specialty);
        }
    }
}