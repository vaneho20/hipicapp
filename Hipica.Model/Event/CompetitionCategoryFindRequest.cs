using Hipica.Model.Abstract;

namespace Hipica.Model.Event
{
    public class CompetitionCategoryFindRequest : AbstractFindRequest
    {
        public CompetitionCategoryFindFilter Filter { get; set; }
    }
}