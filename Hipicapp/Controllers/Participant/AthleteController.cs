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
    [RoutePrefix("api/athletes")]
    public class AthleteController : HipicappApiController
    {
        [Autowired]
        public IAthleteProxy AthleteProxy { get; set; }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("find")]
        public Page<Athlete> Find(AthleteFindRequest request)
        {
            return this.AthleteProxy.Paginated(request);
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("get/{id}")]
        public Athlete Get(long? id)
        {
            return this.AthleteProxy.Get(id);
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("getByCurrentUser")]
        public Athlete GetByCurrentUser()
        {
            return this.AthleteProxy.GetByCurrentUser();
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("save")]
        public Athlete Save([Valid] Athlete athlete)
        {
            return this.AthleteProxy.Save(athlete);
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("register")]
        public Task<HttpResponseMessage> Register([Valid] Athlete athlete)
        {
            return this.AthleteProxy.Register(athlete);
        }

        [AcceptVerbs("PUT")]
        [HttpPut]
        [Route("update")]
        public Athlete Update([Valid] Athlete athlete)
        {
            return this.AthleteProxy.Update(athlete);
        }

        [AcceptVerbs("DELETE")]
        [HttpDelete]
        [Route("delete")]
        public Athlete Delete(Athlete athlete)
        {
            return this.AthleteProxy.Delete(athlete);
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("inscription")]
        public EnrollmentId Inscription(EnrollmentId id)
        {
            return this.AthleteProxy.Inscription(id);
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
                return this.AthleteProxy.Upload(id, fileInfo);
            }

            return null;
        }
    }
}