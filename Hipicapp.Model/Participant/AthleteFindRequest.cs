using Hipicapp.Model.Abstract;

namespace Hipicapp.Model.Participant
{
    public class AthleteFindRequest : AbstractFindRequest
    {
        public AthleteFindFilter Filter { get; set; }
    }
}