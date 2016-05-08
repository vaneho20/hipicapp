using Hipicapp.Model.Abstract;

namespace Hipicapp.Model.Event
{
    public class EnrollmentFindRequest : AbstractFindRequest
    {
        public EnrollmentFindFilter Filter { get; set; }
    }
}