using Hipicapp.Model.Abstract;

namespace Hipicapp.Model.Event
{
    public class SpecialtyFindRequest : AbstractFindRequest
    {
        public SpecialtyFindFilter Filter { get; set; }
    }
}