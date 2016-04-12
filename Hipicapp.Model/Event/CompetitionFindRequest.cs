using Hipicapp.Model.Abstract;

namespace Hipicapp.Model.Event
{
    public class CompetitionFindRequest : AbstractFindRequest
    {
        public CompetitionFindFilter Filter { get; set; }
    }
}