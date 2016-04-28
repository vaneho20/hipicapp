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
using System.Web.Mvc;

namespace Hipicapp.Controllers.Event
{
    [Scope(ObjectScope.Request)]
    [Controller]
    [RoutePrefix("api/specialty")]
    public class SpecialtyController : HipicappApiController
    {
        [Autowired]
        public ISpecialtyProxy SpecialtyProxy { get; set; }

        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public IList<Specialty> FindAll()
        {
            return this.SpecialtyProxy.FindAll();
        }

        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/specialty/find")]
        //[Authorize(Roles = "ATHLETE")]
        public Page<Specialty> Find(SpecialtyFindRequest request)
        {
            return this.SpecialtyProxy.Paginated(request);
        }

        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public Specialty Get(long? id)
        {
            return this.SpecialtyProxy.Get(id);
        }

        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        public Specialty Save([Valid] Specialty specialty)
        {
            return this.SpecialtyProxy.Save(specialty);
        }

        [System.Web.Http.AcceptVerbs("PUT")]
        [System.Web.Http.HttpPut]
        public Specialty Update([Valid] Specialty specialty)
        {
            return this.SpecialtyProxy.Update(specialty);
        }

        [System.Web.Http.AcceptVerbs("DELETE")]
        [System.Web.Http.HttpDelete]
        public Specialty Delete(Specialty specialty)
        {
            return this.SpecialtyProxy.Delete(specialty);
        }
    }
}