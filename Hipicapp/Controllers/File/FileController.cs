using Hipicapp.Controllers.Abstract;
using Hipicapp.Model.File;
using Hipicapp.Proxies.File;
using Hipicapp.Utils.Util;
using Spring.Context.Attributes;
using Spring.Objects.Factory.Attributes;
using Spring.Objects.Factory.Support;
using Spring.Stereotype;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Hipicapp.Controllers.File
{
    [Scope(ObjectScope.Request)]
    [Controller]
    public class FileController : HipicappApiController
    {
        [Autowired]
        public IFileProxy FileProxy { get; set; }

        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        public async Task<HttpResponseMessage> Download(string id)
        {
            FileInfo fileInfo = this.FileProxy.GetContentsByUuid(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);

            if (fileInfo != null)
            {
                try
                {
                    response.Content = new ByteArrayContent(fileInfo.Contents);
                }
                catch (ArgumentNullException e)
                {
                    //throw new ApplicationRuntimeException(e);
                }

                response.Content.Headers.ContentType = new MediaTypeHeaderValue(fileInfo.ContentType);
                response.Content.Headers.ContentLength = fileInfo.Contents.LongLength;
                if (ValidationUtils.IsValidImageMimeType(fileInfo.ContentType))
                {
                    // prevent js as image
                    response.Content.Headers.Add("X-Content-Type-Options", "nosniff");
                    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("inline");
                    response.Content.Headers.ContentDisposition.FileName = fileInfo.FileName;
                }
                else
                {
                    // prevent inlining dangerous files i.e. js
                    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                    response.Content.Headers.ContentDisposition.FileName = fileInfo.FileName;
                }
            }
            else
            {
                response.StatusCode = HttpStatusCode.NotFound;
            }
            return await Task.FromResult(response);
        }
    }
}