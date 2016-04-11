using Hipica.Controllers.Abstract;
using Hipica.Filters;
using Hipica.Model.Exceptions;
using Hipica.Model.File;
using Hipica.Model.Participant;
using Hipica.Proxy.Participant;
using Hipica.Utils.Pager;
using Hipica.Utils.Util;
using Spring.Context.Attributes;
using Spring.Objects.Factory.Attributes;
using Spring.Objects.Factory.Support;
using Spring.Stereotype;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Hipica.Controllers.Participant
{
    [Scope(ObjectScope.Request)]
    [Controller]
    [RoutePrefix("api/horses")]
    public class HorseController : HipicaApiController
    {
        [Autowired]
        public IHorseProxy HorseProxy { get; set; }

        [HttpPost]
        [Route("api/horses/find")]
        //[Authorize(Roles = "ATHLETE")]
        public Page<Horse> Find(HorseFindRequest request)
        {
            return this.HorseProxy.Paginated(request);
        }

        [HttpGet]
        public Horse Get(long? id)
        {
            return this.HorseProxy.Get(id);
        }

        [HttpPost]
        public Horse Save([Valid] Horse horse)
        {
            return this.HorseProxy.Save(horse);
        }

        [HttpPut]
        public Horse Update([Valid] Horse horse)
        {
            return this.HorseProxy.Update(horse);
        }

        [HttpDelete]
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