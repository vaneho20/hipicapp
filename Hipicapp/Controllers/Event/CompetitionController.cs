using Hipicapp.Controllers.Abstract;
using Hipicapp.Exceptions;
using Hipicapp.Filters;
using Hipicapp.Model.Event;
using Hipicapp.Model.File;
using Hipicapp.Model.Participant;
using Hipicapp.Proxy.Event;
using Hipicapp.Utils.Pager;
using Hipicapp.Utils.Util;
using Spring.Context.Attributes;
using Spring.Objects.Factory.Attributes;
using Spring.Objects.Factory.Support;
using Spring.Stereotype;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Hipicapp.Controllers.Event
{
    [Scope(ObjectScope.Request)]
    [Controller]
    [RoutePrefix("api/competitions")]
    public class CompetitionController : HipicappApiController
    {
        [Autowired]
        public ICompetitionProxy CompetitionProxy { get; set; }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("find")]
        public Page<Competition> Find(CompetitionFindRequest request)
        {
            return this.CompetitionProxy.Paginated(request);
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("findInscriptions")]
        public Page<Enrollment> FindInscriptions(EnrollmentFindRequest request)
        {
            return this.CompetitionProxy.PaginatedInscriptions(request);
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("get/{id}")]
        public Competition Get(long? id)
        {
            return this.CompetitionProxy.Get(id);
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("AdultRankingsBySpecialtyId/{specialtyId}")]
        public IList<Ranking> AdultRankingsBySpecialtyId([FromUri]long? specialtyId)
        {
            return this.CompetitionProxy.AdultRankingsBySpecialtyId(specialtyId);
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("findNextBySpecialtyId/{specialtyId}")]
        public IList<Competition> FindNextBySpecialtyId([FromUri]long? specialtyId)
        {
            return this.CompetitionProxy.FindNextBySpecialtyId(specialtyId);
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("findLast")]
        public IList<Competition> FindLast()
        {
            return this.CompetitionProxy.FindLast();
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("save")]
        public Competition Save([Valid] Competition competition)
        {
            return this.CompetitionProxy.Save(competition);
        }

        [AcceptVerbs("PUT")]
        [HttpPut]
        [Route("update")]
        public Competition Update([Valid] Competition competition)
        {
            return this.CompetitionProxy.Update(competition);
        }

        [AcceptVerbs("DELETE")]
        [HttpDelete]
        [Route("delete")]
        public Competition Delete(Competition competition)
        {
            return this.CompetitionProxy.Delete(competition);
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("simulateScore")]
        public IList<Score> SimulateScore([Valid] Competition competition)
        {
            return this.CompetitionProxy.SimulateScore(competition);
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("{competitionId:long}/assignAllJudges")]
        public IList<Seminary> AssignAllJudges([FromUri]long? competitionId)
        {
            return this.CompetitionProxy.AssignAllJudges(competitionId);
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("{competitionId}/assignAllJudgesById")]
        public IList<Seminary> AssignAllJudgesById([FromUri]long? competitionId, [FromBody]SeminaryIdRequest judgesId)
        {
            return this.CompetitionProxy.AssignAllJudgesById(competitionId, judgesId);
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("{competitionId}/assignAllJudgesByFilter")]
        public IList<Seminary> AssignAllJudgesByFilter([FromUri]long? competitionId, [FromBody]JudgeFindRequest findRequest)
        {
            return this.CompetitionProxy.AssignAllJudgesByFilter(competitionId, findRequest);
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("{competitionId}/unassignAllJudges")]
        public IList<Seminary> UnassignAllJudges([FromUri]long? competitionId)
        {
            return this.CompetitionProxy.UnassignAllJudges(competitionId);
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("{competitionId}/unassignAllJudgesById")]
        public IList<Seminary> UnassignAllJudgesById([FromUri]long? competitionId, [FromBody]SeminaryIdRequest judgesId)
        {
            return this.CompetitionProxy.UnassignAllJudgesById(competitionId, judgesId);
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("{competitionId}/unassignAllJudgesByFilter")]
        public IList<Seminary> UnassignAllJudgesByFilter([FromUri]long? competitionId, [FromBody]JudgeFindRequest findRequest)
        {
            return this.CompetitionProxy.UnassignAllJudgesByFilter(competitionId, findRequest);
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("{competitionId}/{judgeId}/assignUnassignJudge")]
        public Seminary AssignUnassignJudge([FromUri]long? competitionId, [FromUri]long? judgeId)
        {
            return this.CompetitionProxy.AssignUnassignJudge(competitionId, judgeId);
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
                return this.CompetitionProxy.Upload(id, fileInfo);
            }

            return null;
        }
    }
}