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
    [System.Web.Http.RoutePrefix("api/judge")]
    public class JudgeController : HipicappApiController
    {
        [Autowired]
        public IJudgeProxy JudgeProxy { get; set; }

        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/judge/find")]
        public Page<Judge> Find(JudgeFindRequest request)
        {
            return this.JudgeProxy.Paginated(request);
        }

        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        [Route("api/judge/get")]
        public Judge Get(long? id)
        {
            return this.JudgeProxy.Get(id);
        }

        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        public Judge Save([Valid] Judge judge)
        {
            return this.JudgeProxy.Save(judge);
        }

        [System.Web.Http.AcceptVerbs("PUT")]
        [System.Web.Http.HttpPut]
        public Judge Update([Valid] Judge judge)
        {
            return this.JudgeProxy.Update(judge);
        }

        [System.Web.Http.AcceptVerbs("DELETE")]
        [System.Web.Http.HttpDelete]
        public Judge Delete(Judge judge)
        {
            return this.JudgeProxy.Delete(judge);
        }

        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        public Page<Judge> FindByWithAssignment(JudgeFindRequest findRequest)
        {
            return this.JudgeProxy.FindByWithAssignment(findRequest);
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
                return this.JudgeProxy.Upload(id, fileInfo);
            }

            return null;
        }
    }
}