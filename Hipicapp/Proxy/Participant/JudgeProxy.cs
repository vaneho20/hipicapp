using Hipicapp.Filters;
using Hipicapp.Model.Authentication;
using Hipicapp.Model.File;
using Hipicapp.Model.Participant;
using Hipicapp.Service.Participant;
using Hipicapp.Utils.Pager;
using Spring.Objects.Factory.Attributes;
using Spring.Transaction.Interceptor;
using System.Web.Http;

namespace Hipicapp.Proxy.Participant
{
    [Proxy]
    public class JudgeProxy : IJudgeProxy
    {
        [Autowired]
        private IJudgeService JudgeService { get; set; }

        [AllowAnonymous]
        public Page<Judge> Paginated(JudgeFindRequest request)
        {
            return this.JudgeService.Paginated(request.Filter, request.PageRequest);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public Judge Get(long? id)
        {
            return this.JudgeService.Get(id);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public Judge Save(Judge judge)
        {
            return this.JudgeService.Save(judge);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public Judge Update(Judge judge)
        {
            return this.JudgeService.Update(judge);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public Judge Delete(Judge judge)
        {
            return this.JudgeService.Delete(judge);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        [Transaction]
        public FileInfo Upload(long? id, FileInfo file)
        {
            var judge = this.JudgeService.Get(id);
            return this.JudgeService.Upload(judge, file.FileName, file.ContentType, file.Contents);
        }
    }
}