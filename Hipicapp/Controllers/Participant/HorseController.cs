using Hipicapp.Controllers.Abstract;
using Hipicapp.Exceptions;
using Hipicapp.Filters;
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
using System.Web.Http;

namespace Hipicapp.Controllers.Participant
{
    [Scope(ObjectScope.Request)]
    [Controller]
    [RoutePrefix("api/horses")]
    public class HorseController : HipicappApiController
    {
        [Autowired]
        public IHorseProxy HorseProxy { get; set; }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("find")]
        public Page<Horse> Find(HorseFindRequest request)
        {
            return this.HorseProxy.Paginated(request);
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("get/{id}")]
        public Horse Get(long? id)
        {
            return this.HorseProxy.Get(id);
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("save")]
        public Horse Save([Valid] Horse horse)
        {
            return this.HorseProxy.Save(horse);
        }

        [AcceptVerbs("PUT")]
        [HttpPut]
        [Route("update")]
        public Horse Update([Valid] Horse horse)
        {
            return this.HorseProxy.Update(horse);
        }

        [AcceptVerbs("DELETE")]
        [HttpDelete]
        [Route("delete")]
        public Horse Delete(Horse horse)
        {
            return this.HorseProxy.Delete(horse);
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("upload/{id}")]
        public async Task<FileInfo> Upload([FromUri]long? id, HttpRequestMessage request)
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
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