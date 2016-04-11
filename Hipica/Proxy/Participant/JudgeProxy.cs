using Hipica.Filters;
using Hipica.Model.Authentication;
using Hipica.Model.Event;
using Hipica.Model.File;
using Hipica.Model.Participant;
using Hipica.Service.Participant;
using Hipica.Utils.Pager;
using Spring.Objects.Factory.Attributes;
using Spring.Transaction.Interceptor;
using System.Collections.Generic;

namespace Hipica.Proxy.Participant
{
    [Proxy]
    public class JudgeProxy : IJudgeProxy
    {
        [Autowired]
        private IJudgeService JudgeService { get; set; }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
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

        [AuthorizeEnum(Rol.ATHLETE)]
        public IList<Score> SimulateScore(Competition competition)
        {
            return this.JudgeService.SimulateScore(competition);
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