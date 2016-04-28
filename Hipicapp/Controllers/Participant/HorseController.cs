using Hipicapp.Controllers.Abstract;
using Hipicapp.Filters;
using Hipicapp.Model.Exceptions;
using Hipicapp.Model.File;
using Hipicapp.Model.Participant;
using Hipicapp.Proxy.Participant;
using Hipicapp.Utils.Pager;
using Hipicapp.Utils.Util;
using Spring.Context.Attributes;
using Spring.Objects.Factory.Attributes;
using Spring.Objects.Factory.Support;
using Spring.Stereotype;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Hipicapp.Controllers.Participant
{
    [Scope(ObjectScope.Request)]
    [Controller]
    [RoutePrefix("api/horse")]
    public class HorseController : HipicappApiController
    {
        [Autowired]
        public IHorseProxy HorseProxy { get; set; }

        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        [Route("api/horse/find")]
        //[Authorize(Roles = "ATHLETE")]
        public Page<Horse> Find(HorseFindRequest request)
        {
            return this.HorseProxy.Paginated(request);
        }

        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public Horse Get(long? id)
        {
            return this.HorseProxy.Get(id);
        }

        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        public Horse Save([Valid] Horse horse)
        {
            return this.HorseProxy.Save(horse);
        }

        [System.Web.Http.AcceptVerbs("PUT")]
        [System.Web.Http.HttpPut]
        public Horse Update([Valid] Horse horse)
        {
            return this.HorseProxy.Update(horse);
        }

        [System.Web.Http.AcceptVerbs("DELETE")]
        [System.Web.Http.HttpDelete]
        public Horse Delete(Horse horse)
        {
            return this.HorseProxy.Delete(horse);
        }

        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        public async Task<FileInfo> Upload(long? id, HttpRequestMessage request)
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var provider = new MultipartMemoryStreamProvider();
            await request.Content.ReadAsMultipartAsync(provider);
            foreach (var file in provider.Contents)
            {
                FileInfo fileInfo = new FileInfo();
                fileInfo.FileName = file.Headers.ContentDisposition.FileName.Replace("\"", "");
                fileInfo.ContentType = file.Headers.ContentType.MediaType;
                fileInfo.Contents = await file.ReadAsByteArrayAsync();
                if (!ValidationUtils.IsValidImageMimeType(fileInfo.ContentType)
                        || !ValidationUtils.IsValidFileSize(fileInfo.Contents.LongLength))
                {
                    throw new ImageException();
                }
                return this.HorseProxy.Upload(id, fileInfo);
            }

            return null;
        }
    }
}