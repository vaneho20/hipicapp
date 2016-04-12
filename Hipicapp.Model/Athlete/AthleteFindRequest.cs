using Hipicapp.Model.Abstract;

namespace Hipicapp.Model.Athlete
{
    public class AthleteFindRequest : AbstractFindRequest
    {
        public AthleteFindFilter Filter { get; set; }
    }
}