using Hipica.Filters;
using Hipica.Model.Authentication;
using Hipica.Model.Event;
using Hipica.Model.Participant;
using Hipica.Service.Event;
using Hipica.Utils.Pager;
using Spring.Objects.Factory.Attributes;
using System.Collections.Generic;

namespace Hipica.Proxy.Event
{
    [Proxy]
    public class CompetitionProxy : ICompetitionProxy
    {
        [Autowired]
        private ICompetitionService CompetitionService { get; set; }

        [AuthorizeEnum(Rol.ADMINISTRATOR, Rol.ATHLETE)]
        public Page<Competition> Paginated(CompetitionFindRequest request)
        {
            return this.CompetitionService.Paginated(request.Filter, request.PageRequest);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR, Rol.ATHLETE)]
        public Competition Get(long? id)
        {
            return this.CompetitionService.Get(id);
        }

        public Competition Save(Competition competition)
        {
            return this.CompetitionService.Save(competition);
        }

        public Competition Update(Competition competition)
        {
            return this.CompetitionService.Update(competition);
        }

        public Competition Delete(Competition competition)
        {
            return this.CompetitionService.Delete(competition);
        }

        [AuthorizeEnum(Rol.ADMINISTRATOR)]
        public IList<Score> SimulateScore(Competition competition)
        {
            return this.CompetitionService.SimulateScore(competition);
        }
    }
}