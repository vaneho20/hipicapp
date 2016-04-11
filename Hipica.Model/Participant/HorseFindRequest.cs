using Hipica.Model.Abstract;

namespace Hipica.Model.Participant
{
    public class HorseFindRequest : AbstractFindRequest
    {
        public HorseFindFilter Filter { get; set; }
    }
}