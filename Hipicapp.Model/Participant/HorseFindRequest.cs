using Hipicapp.Model.Abstract;

namespace Hipicapp.Model.Participant
{
    public class HorseFindRequest : AbstractFindRequest
    {
        public HorseFindFilter Filter { get; set; }
    }
}