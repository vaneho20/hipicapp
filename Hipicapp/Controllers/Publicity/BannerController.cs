using Hipicapp.Controllers.Abstract;
using Hipicapp.Exceptions;
using Hipicapp.Filters;
using Hipicapp.Model.File;
using Hipicapp.Model.Publicity;
using Hipicapp.Proxy.Publicity;
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

namespace Hipicapp.Controllers.Publicity
{
    [Scope(ObjectScope.Request)]
    [Controller]
    [RoutePrefix("api/banners")]
    public class BannerController : HipicappApiController
    {
        [Autowired]
        public IBannerProxy BannerProxy { get; set; }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("find")]
        public Page<Banner> Find(BannerFindRequest request)
        {
            return this.BannerProxy.Paginated(request);
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("get/{id}")]
        public Banner Get(long? id)
        {
            return this.BannerProxy.Get(id);
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("save")]
        public Banner Save([Valid] Banner banner)
        {
            return this.BannerProxy.Save(banner);
        }

        [AcceptVerbs("PUT")]
        [HttpPut]
        [Route("update")]
        public Banner Update([Valid] Banner banner)
        {
            return this.BannerProxy.Update(banner);
        }

        [AcceptVerbs("DELETE")]
        [HttpDelete]
        [Route("delete")]
        public Banner Delete([Valid] Banner banner)
        {
            return this.BannerProxy.Delete(banner);
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
                return this.BannerProxy.Upload(id, fileInfo);
            }

            return null;
        }
    }
}