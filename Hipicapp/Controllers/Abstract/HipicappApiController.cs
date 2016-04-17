using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Hipicapp.Controllers.Abstract
{
    public abstract class HipicappApiController : ApiController
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            this.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            this.Configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver()
            {
                IgnoreSerializableAttribute = true,
                IgnoreSerializableInterface = true
            };
        }
    }
}