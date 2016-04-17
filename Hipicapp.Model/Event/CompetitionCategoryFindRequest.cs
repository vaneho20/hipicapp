using Hipicapp.Model.Abstract;

namespace Hipicapp.Model.Event
{
    public class CompetitionCategoryFindRequest : AbstractFindRequest
    {
        public CompetitionCategoryFindFilter Filter { get; set; }
    }
}