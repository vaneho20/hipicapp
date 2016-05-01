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
    [RoutePrefix("api/judges")]
    public class JudgeController : HipicappApiController
    {
        [Autowired]
        public IJudgeProxy JudgeProxy { get; set; }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("find")]
        public Page<Judge> Find(JudgeFindRequest request)
        {
            return this.JudgeProxy.Paginated(request);
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("get/{id}")]
        public Judge Get(long? id)
        {
            return this.JudgeProxy.Get(id);
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("save")]
        public Judge Save([Valid] Judge judge)
        {
            return this.JudgeProxy.Save(judge);
        }

        [AcceptVerbs("PUT")]
        [HttpPut]
        [Route("update")]
        public Judge Update([Valid] Judge judge)
        {
            return this.JudgeProxy.Update(judge);
        }

        [AcceptVerbs("DELETE")]
        [HttpDelete]
        [Route("delete")]
        public Judge Delete(Judge judge)
        {
            return this.JudgeProxy.Delete(judge);
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("findByWithAssignment")]
        public Page<Judge> FindByWithAssignment(JudgeFindRequest findRequest)
        {
            return this.JudgeProxy.FindByWithAssignment(findRequest);
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
                return this.JudgeProxy.Upload(id, fileInfo);
            }

            return null;
        }
    }
}