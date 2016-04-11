using Hipica.Model.Abstract;

namespace Hipica.Model.Event
{
    public class CompetitionFindRequest : AbstractFindRequest
    {
        public CompetitionFindFilter Filter { get; set; }
    }
}